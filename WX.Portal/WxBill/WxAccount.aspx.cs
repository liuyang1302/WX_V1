using System;

public partial class WxInter_WxAccount : System.Web.UI.Page
{
    private string OpenID = string.Empty;
    private string NickName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        OpenID = Request.QueryString["OpenID"];
        NickName = Request.QueryString["NickName"];
        openid.InnerHtml = OpenID;
        nickname.InnerHtml = NickName;
        if (string.IsNullOrEmpty(OpenID))
            Response.Redirect("WxMsgWarn.aspx", true);
    }
}