using System;
using System.Collections;
/*
* 微信公众平台核心
* 版权: --刘洋
* 日志: 2017-04-12 创建
*/
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Wx.Core;

namespace Wx.Work
{
    public class SchoolData : DataBase
    {
        private const string _name = "School.accdb";

        public SchoolData(string p_name) : base(p_name)
        {

        }

        public static DataTable Query(string sql)
        {
            return new SchoolData(_name).query(sql);
        }

        public static int ExecNonQuery(string sql)
        {
            return new SchoolData(_name).execNonQuery(sql);
        }

        public static int ExecNonQuery(string sql, List<OleDbParameter> Params)
        {
            return new SchoolData(_name).execNonQuery(sql, Params);
        }

        public static object GetScalar(string sql)
        {
            return new SchoolData(_name).getScalar(sql);
        }

        public static int ExecProc(string ProcName, List<OleDbParameter> Params)
        {
            return new SchoolData(_name).execProc(ProcName, Params);
        }

        public static void ExecuteSqlTran(Hashtable p_ht)
        {
            new SchoolData(_name).executeSqlTran(p_ht);
        }

        public static bool 语音记录(string p_name)
        {
            string _sql = string.Format("insert into 语音记录(名称,时间) values ('{0}',now())", p_name);
            return SchoolData.ExecNonQuery(_sql) > 0;
        }
    }
}
