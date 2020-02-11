using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Work.WxSms;

namespace Wx.Work
{
    public class WxSmsFactory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            string _type = context.Request.Params["Type"].ToUpper();
            WxServiceBase _result = null;
            switch (_type)
            {
                case "PHONE": //手机发送的短信
                    _result = new WxSmsPhone();
                    break;
                case "短信列表":
                    _result = new WxSmsList();
                    break;
                default:
                    break;
            }
            return _result;
        }
    }
}
