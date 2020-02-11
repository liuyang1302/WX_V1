using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxQues_WxQuesSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        openid.InnerHtml = Request.QueryString["OpenID"];
        nickname.InnerHtml = Request.QueryString["NickName"];
        questype.InnerHtml = Request.QueryString["QuesType"];
    }
}