using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Wx.Core
{
    public class DataBase
    {
        #region 成员
        private static string _str = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};jet oledb:database password=";
        private static string _conn = string.Empty;
        #endregion

        #region 构造
        public DataBase(string p_name)
        {
            string _access = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!_access.EndsWith("\\")) _access += "\\";
            _access += "WxData\\" + p_name;
            _conn = string.Format(_str, _access);
        }
        #endregion

        #region 私有
        public DataTable query(string sql)
        {
            DataTable _result = null;
            DataSet _dataSet = new DataSet();
            using (OleDbConnection _connection = new OleDbConnection(_conn))
            {
                try
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();

                    _connection.Open();
                    using (OleDbCommand _command = new OleDbCommand())
                    {
                        _command.Connection = _connection;
                        _command.CommandText = sql;
                        _command.CommandType = CommandType.Text;
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                        {
                            adapter.SelectCommand = _command;
                            adapter.Fill(_dataSet);
                            if (_dataSet != null)
                                _result = _dataSet.Tables[0];
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.WriteTxtLog(e.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _result;
        }

        public int execNonQuery(string sql)
        {
            int _result = 0;
            using (OleDbConnection _connection = new OleDbConnection(_conn))
            {
                try
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();

                    _connection.Open();
                    using (OleDbCommand _command = new OleDbCommand())
                    {
                        _command.Connection = _connection;
                        _command.CommandText = sql;
                        _command.CommandType = CommandType.Text;
                        _result = _command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Logger.WriteTxtLog(e.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _result;
        }

        public int execNonQuery(string sql, List<OleDbParameter> Params)
        {
            int _result = 0;
            using (OleDbConnection _connection = new OleDbConnection(_conn))
            {
                try
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();

                    _connection.Open();
                    using (OleDbCommand _command = new OleDbCommand())
                    {
                        _command.Connection = _connection;
                        _command.CommandText = sql;
                        _command.Parameters.AddRange(Params.ToArray());
                        _command.CommandType = CommandType.Text;
                        _result = _command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Logger.WriteTxtLog(e.Message + "\n" + GetExecSqlString(sql, Params));
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _result;
        }

        public object getScalar(string sql)
        {
            object _result = null;
            using (OleDbConnection _connection = new OleDbConnection(_conn))
            {
                try
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();

                    _connection.Open();
                    using (OleDbCommand _command = new OleDbCommand())
                    {
                        _command.Connection = _connection;
                        _command.CommandText = sql;
                        _command.CommandType = CommandType.Text;
                        _result = _command.ExecuteScalar();
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _result;
        }

        public int execProc(string ProcName, List<OleDbParameter> Params)
        {
            int _result = -1;
            using (OleDbConnection _connection = new OleDbConnection(_conn))
            {
                try
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();

                    _connection.Open();
                    using (OleDbCommand _command = new OleDbCommand())
                    {
                        _command.Connection = _connection;
                        _command.CommandText = ProcName;
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddRange(Params.ToArray());
                        _result = _command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _result;
        }
        
        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>    
        public void executeSqlTran(Hashtable SQLStringList)
        {
            using (OleDbConnection conn = new OleDbConnection(_conn))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();

                    try
                    {
                        //循环    
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            try
                            {
                                string cmdText = myDE.Key.ToString();
                                OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                                PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                trans.Commit();
                            }
                            catch (Exception e)
                            {
                                if (!e.Message.Contains("由于将在索引"))
                                    throw;
                            }
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        private void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;    
            if (cmdParms != null)
            {
                foreach (OleDbParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 公共
    
        public static string GetExecSqlString(string p_sql, List<OleDbParameter> p_param)
        {
            string tempSql = p_sql;
            foreach (var item in p_param)
            {
                string tempParamName = item.ParameterName.IndexOf(':') > -1 ? item.ParameterName : ":" + item.ParameterName;
                string value = item.Value.ToString() == null ? "NULL" : item.Value.ToString();
                switch (item.DbType)
                {
                    case DbType.AnsiString:
                    case DbType.String:
                        tempSql = tempSql.Replace(tempParamName, "'" + value + "'");
                        break;
                    case DbType.DateTime:
                    case DbType.Date:
                        tempSql = tempSql.Replace(tempParamName, string.Format("To_Date('{0}','YYYY-MM-DD HH24:MI:SS')", value));
                        break;
                    default:
                        value = string.IsNullOrEmpty(value) ? "NULL" : value;
                        tempSql = tempSql.Replace(tempParamName, value);
                        break;
                }
            }

            return tempSql;
        }

        #endregion
    }
}
