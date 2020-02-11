using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work
{
    public class WpCodeFacory : IWxFactory
    {
        #region Data

        private static DataTable _dt;
        private static string _conn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};jet oledb:database password=";
        private static string _insert = "insert into codes(Code, Flag, Data, IsUsable, Message, LastDate, ItemDate) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

        private static string _allcodes;
        private static List<string> _clicodes = new List<string>();

        public WpCodeFacory()
        {
            string _access = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!_access.EndsWith("\\")) _access += "\\";
            //_access += "WxData\\dzcode.accdb";
            _access += "WxData\\dzcode.mdb";
            _conn = string.Format(_conn, _access);
            _dt = WpQuery("select * from Codes");
        }

        private DataTable WpQuery(string sql)
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

        private int WpExecNonQuery(string sql)
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

        #endregion


        public string Result(HttpContext context)
        {
            string _result = string.Empty;
            string _type = context.Request.Params["Type"].ToUpper();
            if (_type == "CODES")
            {
                string _date = context.Request.Params["Date"];
                _result = GetCodes(_date);
            }
            else if (_type == "CODEINFO")
            {
                _result = GetCodeInfo();
            }
            else if (_type == "SAVECODE")
            {
                string _info = context.Request.Params["Info"];
                string _date = context.Request.Params["Date"];
                _result = SaveCode(_info, _date);
            }
            else if (_type == "WXGETCODES")
            {
                string _tab = context.Request.Params["Tab"];
                string _date = context.Request.Params["Date"];
                _result = GetWxCode(_tab, _date);
            }
            return _result;
        }

        private string GetCodes(string _date)
        {
            if (string.IsNullOrEmpty(_date))
            {
                if (!string.IsNullOrEmpty(_allcodes))
                {
                    return _allcodes;
                }

                foreach (DataRow _dr in _dt.Rows)
                {
                    _allcodes += _dr.Str("Code") + "|";
                    Insert(_dr.Str("Code"));
                }
                return _allcodes;
            }
            else
            {
                string _result = string.Empty;
                foreach (string _code in _clicodes)
                {
                    _result += _code + "|";
                }
                return _result;
            }
        }

        private string GetCodeInfo()
        {
            string _result = string.Empty;
            string _columns = string.Empty;
            foreach (DataColumn _dc in _dt.Columns)
            {
                _columns += _dc.ColumnName + "|";
            }
            foreach (DataRow _dr in _dt.Rows)
            {
                _result += ";";
                foreach (DataColumn _dc in _dt.Columns)
                {
                    _result += _dr.Str(_dc.ColumnName) + "|";
                }
            }

            return _columns.TrimEnd('|') + _result.TrimEnd('|');
        }

        private string GetWxCode(string _tab, string _date)
        {
            string _result = string.Empty;

            DateTime? _now = null;
            if (!string.IsNullOrEmpty(_date))
                _now = Convert.ToDateTime(_date);

            int _index = 100;
            for (int i = _dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow _dr = _dt.Rows[i];

                if (_tab == "可用" && _dr.Str("IsUsable") != "1")
                    continue;
                else if (_tab == "有效" && _dr.Str("Message") == "无效")
                    continue;

                if (_now != null && _dr.ToDateTime("ItemDate") < _now.Value)
                    continue;

                _result += _dr.Str("Code") + "|" + _dr.Str("Message") + "|" + _dr.ToDateTime("LastDate").ToString("yyyy-MM-dd") + "|"
                    + _dr.ToDateTime("ItemDate").ToString("yyyy-MM-dd HH:mm") + ";";

                if (_tab == "全部" && _index == 0)
                    break;
                _index--;
            }

            if (_result != string.Empty)
            {
                _result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|" + _dt.Rows.Count + ";" + _result;
            }

            return _result.TrimEnd(';');
        }

        private string SaveCode(string _info, string _date)
        {
            string[] _infos = _info.Split('|');
            string _now = DateTime.Now.ToString();
            if (string.IsNullOrEmpty(_infos[5])) _infos[5] = _now;
            string _sql = string.Format(_insert, _infos[0], _infos[1], _infos[2], _infos[3], _infos[4], _infos[5], _now);
            int _exec = WpExecNonQuery(_sql);
            if (_exec > 0)
            {
                DataRow _dr = _dt.NewRow();
                _dr[1] = _infos[0];
                _dr[2] = _infos[1];
                _dr[3] = _infos[2];
                _dr[4] = _infos[3];
                _dr[5] = _infos[4];
                _dr[6] = _infos[5];
                _dr[7] = _now;
                _dt.Rows.Add(_dr);

                Insert(_dr.Str("Code"));
                _allcodes += _dr.Str("Code") + "|";
            }
            return GetCodes(_date);
        }

        private void Insert(string _date)
        {
            if (_clicodes.Count > 30)
                _clicodes.RemoveAt(0);
            _clicodes.Add(_date);
        }

        public WxServiceBase Services(HttpContext context)
        {
            return null;
        }
    }
}
