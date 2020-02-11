using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Wx.Core;

namespace Wx.Work
{
    public class HtnFacory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            string _result = string.Empty;
            StreamReader _sr = new StreamReader(context.Request.InputStream);
            string _request = _sr.ReadToEnd();

            if (_request == "SQL")
            {
                _result = AtHtnService.GetConSql();
            }
            else
            {
                System.GC.Collect();
                _result = AtHtnService.SaveData(_request);
            }

            return _result;
        }

        public WxServiceBase Services(HttpContext context)
        {
            return null;
        }
    }

    public class AtHtnService
    {
        private static string _conkey = "";
        private static Dictionary<string, HtnDataInfo> _sqlinfo = new Dictionary<string, HtnDataInfo>();

        static AtHtnService()
        {
            DataTable _dt = HtnData.SerSource;
            foreach (DataRow _dr in _dt.Rows)
            {
                _sqlinfo[_dr.Str("SQLKey")] = new HtnDataInfo(_dr);
            }
        }

        /// <summary>
        /// 获取要查询的SQL语句
        /// </summary>
        /// <returns></returns>
        public static string GetConSql()
        {
            if (_sqlinfo.Count == 0)
                return string.Empty;

            if (string.IsNullOrEmpty(_conkey))
            {
                _conkey = _sqlinfo.First().Key;
                return _conkey + ";" + _sqlinfo[_conkey].Select;
            }
            else if (_conkey == _sqlinfo.Last().Key)
            {
                _conkey = _sqlinfo.First().Key;
                return _conkey + ";" + _sqlinfo[_conkey].Select;
            }

            bool _is = false;
            foreach (var item in _sqlinfo)
            {
                if (item.Key == _conkey)
                {
                    _is = true;
                    continue;
                }
                if (_is || _sqlinfo.Count == 1)
                {
                    _conkey = item.Key;
                    return _conkey + ";" + _sqlinfo[_conkey].Select;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="p_xml"></param>
        /// <returns></returns>
        public static string SaveData(string p_xml)
        {
            HtnSaveData _save = new HtnSaveData(p_xml);

            if (string.IsNullOrEmpty(_save.Key) || !_sqlinfo.ContainsKey(_save.Key))
                return "No TableName";

            HtnDataInfo _info = _sqlinfo[_save.Key];
            return _save.Exec(_info);
        }
    }

    /// <summary>
    /// 数据信息
    /// </summary>
    public class HtnDataInfo
    {
        #region 成员

        private bool _sqlup;
        private string _sqlkey;
        private string _sqlval;
        private string _sqlpk;
        private string _insert;
        private string _update;
        private string _exist;
        private DataTable _model;
        private List<string> _ids;

        #endregion

        #region 属性

        public string SqlKey { get { return _sqlkey; } }
        public bool IsUpdate { get { return _sqlup; } }
        public string Select { get { return GetSelect(); } }
        public string Insert { get { return GetInsert(); } }
        public string Update { get { return GetUpdate(); } }
        public string Exist { get { return _exist; } }
        public DataTable Model { get { return _model; } }

        #endregion

        #region 构造

        public HtnDataInfo(DataRow p_dr)
        {
            _ids = new List<string>();
            _sqlkey = p_dr.Str("SQLKey");
            _sqlval = p_dr.Str("SQLVal");
            _sqlpk = p_dr.Str("SQLPk");
            _sqlup = p_dr.Str("SQLUp") == "1";
            _model = HtnData.Query("select top 1 * from " + _sqlkey);
            _exist = string.Format("select count(*) as [len] from {0} where {1} = ", _sqlkey, _model.Columns[0].ColumnName) + "'{0}'";

        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取Select语句
        /// </summary>
        /// <returns></returns>
        private string GetSelect()
        {
            string _result = _sqlval;
            if (!_result.Contains("{0}"))
            {
                return _result;
            }

            if (_sqlkey == "HTN_TreatmentHistoryItem")
            {
                return GetHTNItem();
            }

            if (string.IsNullOrEmpty(_sqlpk))
            {
                return _result.Replace("{0}", "");
            }

            string _sql = string.Format("select max([{0}]) as maxkey from {1}", _sqlpk, _sqlkey);
            DataTable _dt = HtnData.Query(_sql);
            if (_dt == null || _dt.Rows.Count == 0)
            {
                return _result.Replace("{0}", "");
            }

            DataRow _dr = _dt.Rows[0];
            string _kekval = _dr.Str("maxkey");
            if (string.IsNullOrEmpty(_kekval))
            {
                return _result.Replace("{0}", "");
            }

            if (_dt.Columns[0].DataType == typeof(DateTime) || _dt.Columns[0].DataType == typeof(string))
            {
                _result = string.Format(_result, " AND " + _sqlpk + " >= '" + _kekval + "'");
            }
            else
            {
                _result = string.Format(_result, " AND " + _sqlpk + " >= " + _kekval);
            }

            return _result;
        }

        /// <summary>
        /// 特殊处理
        /// </summary>
        /// <returns></returns>
        private string GetHTNItem()
        {
            string _result = _sqlval;
            string _ids = string.Empty;

            //string _sql = "SELECT ID FROM HTN_TREATMENTHISTORY WHERE ID NOT IN (SELECT TREATMENTID FROM HTN_TREATMENTHISTORYITEM)";
            string _sql = "select top 100 ID from HTN_TreatmentHistory a where not exists (select 1 from HTN_TreatmentHistoryItem b where a.ID = b.TreatmentId)";
            DataTable _dt = HtnData.Query(_sql);

            if (_dt == null || _dt.Rows.Count == 0)
                return string.Empty;

            foreach (DataRow _dr in _dt.Rows)
            {
                _ids += string.Format("'{0}',", _dr.Str("ID"));
            }
            _ids = _ids.TrimEnd(',');

            string _filter = string.Format(" AND TREATMENTID IN ({0})", _ids);
            _result = string.Format(_result, _filter);

            return _result;
        }

        /// <summary>
        /// 获取Insert语句
        /// </summary>
        /// <returns></returns>
        private string GetInsert()
        {
            if (string.IsNullOrEmpty(_insert))
            {
                string _sqlcol = "";
                string _sqlval = "";
                string _sql = "insert into {0} ({1}) values ({2})";

                for (int i = 0; i < _model.Columns.Count; i++)
                {
                    DataColumn _dc = _model.Columns[i];
                    _sqlcol += "[" + _dc.ColumnName + "]" + ",";
                    _sqlval += ":V" + ((i + 1).ToString().PadLeft(3, '0')) + ",";
                }
                _sqlcol = _sqlcol.TrimEnd(','); _sqlval = _sqlval.TrimEnd(',');
                _insert = string.Format(_sql, _sqlkey, _sqlcol, _sqlval);
            }
            return _insert;
        }

        /// <summary>
        /// 获取Update语句
        /// </summary>
        /// <returns></returns>
        private string GetUpdate()
        {
            if (string.IsNullOrEmpty(_update))
            {
                string _sqlcol = "";
                string _sqlval = "";
                string _sql = "update {0} set {1} where {2}";

                for (int i = 0; i < _model.Columns.Count; i++)
                {
                    DataColumn _dc = _model.Columns[i];
                    if (i == 0)
                    {
                        _sqlval = "[" + _dc.ColumnName + "] = :V001";
                    }
                    else
                    {
                        _sqlcol += " [" + _dc.ColumnName + "] = :V" + ((i + 1).ToString().PadLeft(3, '0')) + ",";
                    }
                }
                _sqlcol = _sqlcol.TrimEnd(',');
                _update = string.Format(_sql, _sqlkey, _sqlcol, _sqlval);
            }
            return _update;
        }

        /// <summary>
        /// 缓存判断是否存在
        /// </summary>
        /// <param name="p_dr"></param>
        /// <returns></returns>
        public bool IsExist(DataRow p_dr)
        {
            string _key = p_dr.Str(0);
            if (string.IsNullOrEmpty(_key)) return false;
            if (_ids.Contains(_key)) return true;
            _ids.Add(_key);
            if (_ids.Count > 1000)
            {
                _ids.RemoveAt(0);
            }
            return false;
        }

        /// <summary>
        /// 数据库种判断是否存在
        /// </summary>
        /// <param name="p_dr"></param>
        /// <returns></returns>
        public bool IsRowExist(DataRow p_dr)
        {
            DataTable _existdt = HtnData.Query(string.Format(_exist, p_dr.Str(0)));
            return _existdt != null && _existdt.Rows.Count > 0 && _existdt.Rows[0].Str("len") != "0";
        }

        #endregion
    }

    public class HtnSaveData
    {
        private DataTable _dt;

        public string Key { get; set; }

        public HtnSaveData(string p_xml)
        {
            _dt = HtnData.XmlToData(p_xml);
            if (_dt == null || _dt.Rows.Count == 0)
                return;
            Key = _dt.TableName;
        }

        public string Exec(HtnDataInfo p_info)
        {
            string _result = "OK";
            if (p_info == null) return _result;

            string _sql = string.Empty;
            //Hashtable _ht = new Hashtable();
            foreach (DataRow _dr in _dt.Rows)
            {
                if (p_info.IsUpdate) //可更新
                {
                    _sql = p_info.IsRowExist(_dr) ? p_info.Update : p_info.Insert;
                }
                else if (!p_info.IsExist(_dr))
                {
                    _sql = p_info.Insert;
                }

                if (string.IsNullOrEmpty(_sql)) continue;

                //_ht.Add(_sql, GetParams(p_info, _dr));
                int r = HtnData.ExecNonQuery(_sql, GetParams(p_info, _dr));
            }

            //HtnData.ExecuteSqlTran(_ht);
            return _result;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <returns></returns>
        private List<OleDbParameter> GetParams(HtnDataInfo p_info, DataRow p_dr)
        {
            DataTable _dt = p_dr.Table;
            List<OleDbParameter> _params = new List<OleDbParameter>();

            for (int i = 0; i < _dt.Columns.Count; i++)
            {
                DataColumn _dc = _dt.Columns[i];
                _params.Add(new OleDbParameter()
                {
                    ParameterName = "V" + ((i + 1).ToString().PadLeft(3, '0')),
                    Value = TrParamValue(p_dr.Str(_dc.ColumnName)),
                    DbType = ConDbType(p_info.Model.Columns[_dc.ColumnName])
                });
            }

            return _params;
        }

        private string TrParamValue(string p_val)
        {
            if (p_val.ToUpper() == "TRUE")
            {
                return "1";
            }
            else if (p_val.ToUpper() == "FALSE")
            {
                return "0";
            }
            return p_val;
        }

        private DbType ConDbType(DataColumn p_dc)
        {
            if (p_dc.DataType == typeof(DateTime))
            {
                return DbType.DateTime;
            }
            else if (p_dc.DataType == typeof(int))
            {
                return DbType.Int32;
            }
            else if (p_dc.DataType == typeof(double))
            {
                return DbType.Double;
            }
            else if (p_dc.DataType == typeof(decimal))
            {
                return DbType.Decimal;
            }
            return DbType.String;
        }

        private OleDbType ConOleType(DataColumn p_dc)
        {
            if (p_dc.DataType == typeof(DateTime))
            {
                return OleDbType.Date;
            }
            else if (p_dc.DataType == typeof(int))
            {
                return OleDbType.Integer;
            }
            else if (p_dc.DataType == typeof(double))
            {
                return OleDbType.Double;
            }
            else if (p_dc.DataType == typeof(decimal))
            {
                return OleDbType.Decimal;
            }
            return OleDbType.VarChar;
        }
    }


}
