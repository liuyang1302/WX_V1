using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxSms
{
    /// <summary>
    /// 手机短信接受
    /// </summary>
    public class WxSmsPhone : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            string _result = string.Empty;

            StreamReader _dr = new StreamReader(context.Request.InputStream);
            string _val = _dr.ReadToEnd();

            //Logger.WriteTxtLog("短信记录：" + _val);
            //测试同步
            try
            {
                _result = BatchSaveSmsData(_val);
                if (_result != "OK")
                {
                    Logger.WriteTxtLog("短信记录失败：" + _result + "\r\n" + _val);
                }
            }
            catch (Exception e)
            {
                Logger.WriteTxtLog("短信记录异常：" + e.Message);
            }
            finally
            {
                _result = "OK";
            }

            return _result;
        }

        private string BatchSaveSmsData(string p_val)
        {
            string _result = "OK";
            if (!p_val.Contains("&"))
            {
                return SaveSmsData(p_val);
            }

            string[] _items = p_val.Split('&');
            foreach (string item in _items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                _result = SaveSmsData(item);
            }
            return _result;
        }

        private string SaveSmsData(string p_val)
        {
            string _result = "OK";
            if (!p_val.Contains("|"))
            {
                return "接收转发内容的格式不对";
            }

            string[] _vals = p_val.Split('|');
            if (_vals.Length != 4)
            {
                return "接收转发内容的数量不对";
            }

            string _myphone = _vals[0];  //自己的手机号
            string _cophone = _vals[1];  //信息来源
            string _comedate = _vals[2]; //短信时间
            string _message = _vals[3];  //短信内容

            if (_message.Contains("转发短信来自"))
                return _result;

            string _openid = DataAgent.Sms.GetOpenId(_myphone); //用户标识

            string _type = "";
            if (_message.Contains("验证码"))
            {
                _type = "验证码";
            }
            else if (_message.Contains("支出"))
            {
                _type = "支出";
            }
            bool _is = DataAgent.Sms.SaveSms(_openid, _myphone, _cophone, _type, _message, _comedate);

            if (!_is)
            {
                _result = "短信保存失败！";
            }

            return _result;
        }
    }
}
