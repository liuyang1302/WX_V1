using System.Web;
using Wx.Work.WxHisInfo;

namespace Wx.Work
{
    class HisInfoFactory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            return new HisInfoService();
        }
    }
}
