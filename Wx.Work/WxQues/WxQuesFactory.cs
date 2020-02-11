using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Work.WxQues;

namespace Wx.Work
{
    public class WxQuesFactory: IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            string _type = context.Request.Params["Type"];
            WxServiceBase _result = null;
            switch (_type)
            {
                case "答题首页":
                    _result = new WxQuesServiceHome();
                    break;
                case "题目信息":
                case "错题记录":
                    _result = new WxQuesServiceInfo();
                    break;

                default:
                    break;
            }
            return _result;
        }
    }
}
