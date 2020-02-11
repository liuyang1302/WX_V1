using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //label.Text = Wx.Inter.Class1.Hello();
        Response.Redirect("WxHome.aspx", true);
    }

    protected void OnButAccessTokenClick(object sender, EventArgs e)
    {
        //Server.Transfer("/WxService/WxBaseInfo.aspx");

        Response.Redirect("WxService/WxBaseInfo.aspx", false);

    }

    protected void OnButWxMenu(object sender, EventArgs e)
    {
        Response.Redirect("WxService/WxMenu.aspx", false);
    }
}