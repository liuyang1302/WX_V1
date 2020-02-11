using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Data
{
    public class DataSms
    {
        #region 成员

        private string _loadOpenId = "SELECT OPENID FROM WX_WC_USER WHERE PHONE = '{0}'";
        private string _insertSms = "INSERT INTO WX_SM_INFO (OPENID, PHONE, COMEFROM, TYPE, CONTENT, SMSDATE, ITEMDATE) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
        private string _querySms = "SELECT * FROM WX_SM_INFO WHERE OPENID = '{0}' AND PHONE = '{1}' AND COMEFROM = '{2}' AND CONTENT = '{3}' AND SMSDATE = #{4}#";

        private string _smsList = "SELECT PHONE, COMEFROM, TYPE, SMSDATE, CONTENT FROM WX_SM_INFO WHERE SMSDATE >= #{0}# AND SMSDATE <= #{1}# {2} ORDER BY SMSDATE DESC";
        #endregion

        /// <summary>
        /// 获取用户标识
        /// </summary>
        /// <param name="p_phone"></param>
        /// <returns></returns>
        public string GetOpenId(string p_phone)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadOpenId, p_phone));
            if (_dt == null || _dt.Rows.Count == 0 || _dt.Rows[0][0] is DBNull)
                return string.Empty;
            return _dt.Rows[0].Str(0);
        }

        /// <summary>
        /// 保存短信信息
        /// </summary>
        /// <param name="OpenId"></param>
        /// <param name="Phone"></param>
        /// <param name="ComeFrom"></param>
        /// <param name="Type"></param>
        /// <param name="Content"></param>
        /// <param name="SmsDate"></param>
        /// <returns></returns>
        public bool SaveSms(string OpenId, string Phone, string ComeFrom, string Type, string Content, string SmsDate)
        {
            //判断是否存在
            string _qusql = string.Format(_querySms, OpenId, Phone, ComeFrom, Content, SmsDate);
            DataTable _dt = DataAccess.Query(_qusql);
            if (_dt != null && _dt.Rows.Count > 0)
                return true;

            //插入数据
            string _now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string _sql = string.Format(_insertSms, OpenId, Phone, ComeFrom, Type, Content, SmsDate, _now);
            bool _is = DataAccess.ExecNonQuery(_sql) > 0;

            //记帐
            if (_is && (Type == "支出" || Type == "收入"))
            {
                DataAgent.OutBill.SaveSmsOutBill(OpenId, SmsDate, Content);
            }

            return _is;

        }

        public DataTable LoadSmsList(string OpenId, string Type, string SDate, string EDate)
        {
            //暂时不管OpenId
            string _type = "";
            if (string.IsNullOrEmpty(Type) || Type == "全部")
            {
                _type = "";
            }
            else if (Type == "帐户收支")
            {
                _type = " AND TYPE IN ('收入','支出')";
            }
            else
            {
                _type = " AND TYPE = '" + Type + "'";
            }
            SDate = SDate + " 00:00:00";
            EDate = EDate + " 23:59:59";
            string _sql = string.Format(_smsList, SDate, EDate, _type);
            DataTable _dt = DataAccess.Query(_sql);

            //测试
            //if (Type == "帐户收支")
            //{
            //    BatchBillOut(_dt);
            //}

            return _dt;
        }

        public void BatchBillOut(DataTable p_dt)
        {
            foreach (DataRow _dr in p_dt.Rows)
            {
                string _openid = DataAgent.Sms.GetOpenId(_dr.Str("PHONE")); //用户标识
                if (_openid == "") continue;
                string _msg = _dr.Str("CONTENT");
                DataAgent.OutBill.SaveSmsOutBill(_openid, _dr.Str("SMSDATE"), _msg);
            }
        }



    }
}
