using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxInter_WxMsgSuccess : System.Web.UI.Page
{
    private string Msg = string.Empty;
    private string OpenID = string.Empty;
    private string NickName = string.Empty;
    private string Lasturl = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        OpenID = Request.QueryString["OpenID"];
        NickName = Request.QueryString["NickName"];
        Msg = Request.QueryString["Msg"];
        if (Request.UrlReferrer != null)
            Lasturl = Request.UrlReferrer.AbsoluteUri;

        if (!string.IsNullOrEmpty(Msg))
        {
            _msg.InnerText = Msg;
        }
    }

    protected void OnButOkClick(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("WxAccBill.aspx?OpenID={0}&NickName={1}", OpenID, NickName), true);
    }

    protected void OnButReClick(object sender, EventArgs e)
    {
        Response.Redirect(Lasturl, true);
    }
}