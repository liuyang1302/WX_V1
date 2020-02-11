using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;
using Wx.Core;
using Wx.Core.Data;

namespace Wx.Work
{
    public class HtnData
    {
        #region 成员

        private static string _dataname = "Htn.accdb";

        #endregion

        #region 属性

        public static DataTable SerSource { get; private set; }
        public static DataTable AppSource { get; private set; }
        public static Dictionary<string, string> SerDic { get; private set; }
        public static Dictionary<string, string> AppDic { get; private set; }

        #endregion

        #region 构造

        static HtnData()
        {
            InitSource();
        }

        #endregion

        #region 资源

        public static void InitSource()
        {
            SerSource = null;
            AppSource = null;
            SerDic = new Dictionary<string, string>();
            AppDic = new Dictionary<string, string>();

            DataTable _dt = Query("SELECT * FROM HTN_SQL");

            SerSource = _dt.Clone();
            AppSource = _dt.Clone();

            foreach (DataRow _dr in _dt.Rows)
            {
                if (_dr.Str("SQLIs") != "1") continue; //未启用
                if (_dr.Str("SQLType") == "服务")
                {
                    DataRow _ndr = SerSource.NewRow();
                    _dr.Copy(_ndr);
                    SerSource.Rows.Add(_ndr);
                    SerDic[_dr.Str("SQLKey")] = _dr.Str("SQLVal");
                }
                else
                {
                    AppSource.Rows.Add(_dr);
                    AppDic[_dr.Str("SQLKey")] = _dr.Str("SQLVal");
                }
            }
        }

        #endregion

        #region 公共

        public static DataTable Query(string sql)
        {
            return new DataAccess(_dataname).query(sql);
        }

        public static int ExecNonQuery(string sql)
        {
            return new DataAccess(_dataname).execNonQuery(sql);
        }

        public static int ExecNonQuery(string sql, List<OleDbParameter> Params)
        {
            return new DataAccess(_dataname).execNonQuery(sql, Params);
        }

        public static object GetScalar(string sql)
        {
            return new DataAccess(_dataname).getScalar(sql);
        }

        public static int ExecProc(string ProcName, List<OleDbParameter> Params)
        {
            return new DataAccess(_dataname).execProc(ProcName, Params);
        }

        public static void ExecuteSqlTran(Hashtable p_ht)
        {
            new DataAccess(_dataname).executeSqlTran(p_ht);
        }

        #endregion

        #region 工具

        public static DataTable XmlToData(string xmlData)
        {
            DataSet _ds = XmlToDataSet(xmlData);
            if (_ds == null || _ds.Tables.Count == 0)
                return null;
            return _ds.Tables[0];
        }

        public static DataSet XmlToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static string DataToWx(DataTable p_dt)
        {
            if (p_dt == null || p_dt.Rows.Count == 0)
                return string.Empty;

            string _result = string.Empty;
            int _length = p_dt.Columns.Count;
            foreach (DataRow _dr in p_dt.Rows)
            {
                if (_result != string.Empty)
                    _result += ";";
                for (int i = 0; i < _length; i++)
                {
                    _result += _dr.Str(i) + "|";
                }
            }
            return _result;
        }

        public static DataTable WxToData(string p_wx)
        {
            return null;
        }
        #endregion
    }
}
