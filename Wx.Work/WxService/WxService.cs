using System.Web;

namespace Wx.Work
{
    public abstract class WxService
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            IWxFactory _factory = null;
            switch (context.Handler.ToString())
            {
                //记帐
                case "Wx.Work.WxBillService":
                    _factory = new WxBillFactory();
                    break;
                //答题
                case "Wx.Work.WxQuesService":
                    _factory = new WxQuesFactory();
                    break;
                //短信
                case "Wx.Work.WxSmsService":
                    _factory = new WxSmsFactory();
                    break;
                //网票
                case "Wx.Work.WpCodeService":
                    _factory = new WpCodeFacory();
                    break;
                //高血压数据同步
                case "Wx.Work.HtnService":
                    _factory = new HtnFacory();
                    break;
                //高血压小程序
                case "Wx.Work.HtnProService":
                    _factory = new HtnProFacory();
                    break;
                //汐汐学习
                case "Wx.Work.SchoolService":
                case "Wx.Work.WxVoiceService":
                    _factory = new SchoolFactory();
                    break;
                case "Wx.Work.ShareService":
                    _factory = new ShareFactory();
                    break;
                case "Wx.Work.WxHisInfoService":
                    _factory = new HisInfoFactory();
                    break;

            }
            context.Response.ContentType = "text/plain";
            string _result = _factory == null ? string.Empty : _factory.Result(context);
            context.Response.Write(_result);
        }
    }

    public class WxBillService : WxService, IHttpHandler { }
    public class WxQuesService : WxService, IHttpHandler { }
    public class WxSmsService : WxService, IHttpHandler { }
    public class WpCodeService : WxService, IHttpHandler { }
    public class HtnService : WxService, IHttpHandler { }
    public class HtnProService : WxService, IHttpHandler { }
    public class SchoolService : WxService, IHttpHandler { }
    public class ShareService : WxService, IHttpHandler { }
    public class WxVoiceService : WxService, IHttpHandler { }
    public class WxHisInfoService : WxService, IHttpHandler { }



}
