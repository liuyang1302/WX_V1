using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Work.School;

namespace Wx.Work
{
    public class SchoolFactory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            string _type = context.Request.Params["Type"];
            WxServiceBase _result = null;
            if (_type == "voice") //音频转换
            {
                _result = new SchoolVoiceInfo();
            }
            else if (_type == "read") //阅读
            {
                _result = new SchoolRead();
            }
            else
            {
                _result = new SchoolServiceInfo();
            }
            return _result;
        }
    }
}
