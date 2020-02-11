using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxHisInfo
{
    public class HisInfoService : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            return AtWeb.Get(HttpUtility.UrlDecode("http://apple1302.gicp.net/HisInfo/GetHisInfo.ashx?" + context.Request.QueryString.ToString()));
        }
    }
}
