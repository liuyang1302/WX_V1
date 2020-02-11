using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxQues_WxQuesHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        openid.InnerHtml = Request.QueryString["OpenID"];
        nickname.InnerHtml = Request.QueryString["NickName"];
        //测试
        if (string.IsNullOrEmpty(openid.InnerHtml))
        {
            //openid.InnerHtml = "ooR2x0aJR3Xwa5p1dgX6YT-4trMs";
            //nickname.InnerHtml = "刘洋";
            openid.InnerHtml = "医生";
            nickname.InnerHtml = "医生";
        }
    }
}