using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Data
{
    public class DataUser
    {
        private string _selallSql = "SELECT * FROM WX_WC_USER";
        private string _selSql = "SELECT * FROM WX_WC_USER WHERE OpenId = '{0}'";
        private string _insertSql = "INSERT INTO WX_WC_USER (SubScribe,OpenId,NickName,Sex,Language,City,Province,Country,HeadImgUrl,SubscribeTime) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
        private string _insertsSql = "INSERT INTO WX_WC_USER (OpenId,NickName) VALUES ('{0}','{1}')";

        private string _sepSql = "SELECT * FROM WX_WC_USER WHERE OpenId = '{0}' AND pwd = '{1}'";
        private string _insertpSql = "INSERT INTO WX_WC_USER (OpenId, NickName, pwd) VALUES ('{0}','{1}','{2}')";

        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAllUser()
        {
            DataTable _dt = DataAccess.Query(_selallSql);
            return _dt;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public DataTable LoadWxUser(string OpenId)
        {
            if (string.IsNullOrEmpty(OpenId)) return null;
            DataTable _dt = DataAccess.Query(string.Format(_selSql, OpenId));
            return _dt;
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public string LoadWxUserName(string OpenId)
        {
            DataTable _dt = LoadWxUser(OpenId);
            if (_dt == null || _dt.Rows.Count == 0)
                return string.Empty;
            return _dt.Rows[0]["NickName"].ToString();
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="SubScribe">是否订阅</param>
        /// <param name="OpenId">用户的标识</param>
        /// <param name="NickName">用户的昵称</param>
        /// <param name="Sex">用户的性别 值为1时是男性，值为2时是女性，值为0时是未知</param>
        /// <param name="Language">用户所在城市</param>
        /// <param name="City">用户所在国家</param>
        /// <param name="Province">用户所在省份</param>
        /// <param name="Country">用户的语言，简体中文为zh_CN</param>
        /// <param name="HeadImgUrl">用户头像</param>
        /// <param name="SubscribeTime">用户关注时间</param>
        /// <returns></returns>
        public bool SaveWxUser(string SubScribe, string OpenId, string NickName, string Sex, string Language, string City, string Province, string Country, string HeadImgUrl, string SubscribeTime)
        {
            int _result = 0;
            string _sql = string.Format(_insertSql, SubScribe, OpenId, NickName, Sex, Language, City, Province, Country, HeadImgUrl, SubscribeTime);
            _result = DataAccess.ExecNonQuery(_sql);
            return _result > 0;
        }

        /// <summary>
        /// 保存简单用户信息
        /// </summary>
        /// <param name="OpenId"></param>
        /// <param name="NickName"></param>
        /// <returns></returns>
        public bool SaveWxUser(string OpenId, string NickName)
        {
            int _result = 0;
            string _sql = string.Format(_insertsSql, OpenId, NickName);
            _result = DataAccess.ExecNonQuery(_sql);
            return _result > 0;
        }

        public DataTable LoadWxUser(string OpenId, string Password)
        {
            if (string.IsNullOrEmpty(OpenId)) return null;
            DataTable _dt = DataAccess.Query(string.Format(_sepSql, OpenId, Password));
            return _dt;
        }


        public bool SaveWxUser(string OpenId, string NickName, string Password)
        {
            int _result = 0;
            string _sql = string.Format(_insertpSql, OpenId, NickName, Password);
            _result = DataAccess.ExecNonQuery(_sql);
            return _result > 0;
        }



    }
}
