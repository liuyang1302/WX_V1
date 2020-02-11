using System.Web;
using Wx.Work.School;

namespace Wx.Work
{
    public class ShareFactory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            WxServiceBase _result = new Wx.Work.Share.ShareService();
            return _result;
        }
    }
}
