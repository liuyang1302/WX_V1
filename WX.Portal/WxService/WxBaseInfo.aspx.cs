using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxService_WxBaseInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GetAccessTokenClick(object sender, EventArgs e)
    {
        _tbAccessToken.Text = Wx.Inter.WxAgent.GetAccessToken();
    }
}