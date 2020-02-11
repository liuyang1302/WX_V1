using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;
using Wx.Work.Htn;

namespace Wx.Work
{
    public class HtnProFacory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            WxServiceBase _result = new WxDefaultService();

            string _type = context.Request.Params["Type"];
            switch (_type)
            {
                case "IsUser":
                case "RegUser":
                    _result = new HtnProServiceUser();
                    break;
                case "Main_TopScroll":
                case "Main_":
                    _result = new HtnProServiceMain();
                    break;
                default:
                    break;
            }

            return _result;

        }
    }

    public class HtnEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        public string Pic { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public string HtmlContent { get; set; }
        public string CreateTime { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
    }
}
