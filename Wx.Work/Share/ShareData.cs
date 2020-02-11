using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Wx.Core;

namespace Wx.Work.Share
{
    public class ShareData : DataBase
    {
        private const string _name = "share.accdb";
        public ShareData(string p_name) : base(p_name)
        {

        }

        public static DataTable Query(string sql)
        {
            return new ShareData(_name).query(sql);
        }

        public static int ExecNonQuery(string sql)
        {
            return new ShareData(_name).execNonQuery(sql);
        }

        public static int ExecNonQuery(string sql, List<OleDbParameter> Params)
        {
            return new ShareData(_name).execNonQuery(sql, Params);
        }

        public static object GetScalar(string sql)
        {
            return new ShareData(_name).getScalar(sql);
        }

        public static int ExecProc(string ProcName, List<OleDbParameter> Params)
        {
            return new ShareData(_name).execProc(ProcName, Params);
        }

        public static void ExecuteSqlTran(Hashtable p_ht)
        {
            new ShareData(_name).executeSqlTran(p_ht);
        }
    }
}
