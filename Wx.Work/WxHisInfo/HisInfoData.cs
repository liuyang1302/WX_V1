using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Wx.Core;

namespace Wx.Work.WxHisInfo
{
    public class HisInfoData : DataBase
    {
        private const string _name = "HisInfo.accdb";
        public HisInfoData(string p_name) : base(p_name)
        {

        }

        public static DataTable Query(string sql)
        {
            return new HisInfoData(_name).query(sql);
        }

        public static int ExecNonQuery(string sql)
        {
            return new HisInfoData(_name).execNonQuery(sql);
        }

        public static int ExecNonQuery(string sql, List<OleDbParameter> Params)
        {
            return new HisInfoData(_name).execNonQuery(sql, Params);
        }

        public static object GetScalar(string sql)
        {
            return new HisInfoData(_name).getScalar(sql);
        }

        public static int ExecProc(string ProcName, List<OleDbParameter> Params)
        {
            return new HisInfoData(_name).execProc(ProcName, Params);
        }

        public static void ExecuteSqlTran(Hashtable p_ht)
        {
            new HisInfoData(_name).executeSqlTran(p_ht);
        }
    }
}
