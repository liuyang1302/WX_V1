/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wx.Inter.Domain;

namespace Wx.Inter
{
    /// <summary>
    /// 全局系统资源
    /// </summary>
    public static class WxResource
    {
        public static readonly string AppId = "wx300924caf9671b67";
        public static readonly string AppSecret = "80262450ff15434c55777d218d82b8cf";
        public static readonly string Token = "LIUCHENXI515"; //自定义Token
        public static readonly string EncodingAESKey = "2G67Lu4fDlsJ8jUHRaIfzty64h37wMuIGRTYI0RDfbN"; //消息加解密密钥

        public static readonly string AppIdTest = "wx72497c46cbbcec6d";
        public static readonly string AppSecretTest = "60f2f52e450305a47c4006525c865f5";

        //public static readonly string DNS = "http://apple1302.gicp.net/";
        public static readonly string DNS = "https://www.cxhome.xyz/";
        public static readonly string InterRootUrl = DNS + "WxBill/";

        public static readonly string InterWxAccBill = InterRootUrl + "WxAccBill.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWxAccount = InterRootUrl + "WxAccount.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWxIncome = InterRootUrl + "WxIncome.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWxReport = InterRootUrl + "WxReport.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWxQues = DNS + "WxQues/WxQuesHome.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWxMsgSuccess = "WxMsgSuccess.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWxMsgWarn = "WxMsgWarn.aspx?OpenID={0}&NickName={1}";

        public static readonly string InterWxSms = DNS + "WxSms/WxSmsList.aspx?OpenID={0}&NickName={1}";
        public static readonly string InterWpCode = DNS + "WxSms/WpCodes.html?OpenID={0}&NickName={1}";

        public static readonly string InterWxSchool = DNS + "WxSchool/index.html?OpenID={0}&NickName={1}";

        public static readonly string InterWxHisInfo = DNS + "WxHisInfo/index.aspx?OpenID={0}&NickName={1}";

        public static readonly string PostInterString = "<a href ='{0}'>{1}</a>";

        public static readonly string Default = DNS + "Default.aspx?OpenID={0}&NickName={1}";

        public static List<User> Users { get; set; }

    }
}
