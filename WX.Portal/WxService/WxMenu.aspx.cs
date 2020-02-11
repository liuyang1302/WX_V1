using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wx.Core.Data;

public partial class WxService_WxMenu : System.Web.UI.Page
{
    DataTable _dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        _dt = DataAccess.Query("SELECT * FROM WX_WC_MENU");
        _gv.DataSource = _dt;
        _gv.DataBind();
    }

    protected void OnbutUpClick(object sender, EventArgs e)
    {
        Wx.Inter.Domain.Menu _menu = new Wx.Inter.Domain.Menu();
        Wx.Inter.Domain.Button _button = new Wx.Inter.Domain.Button()
        {
            key = "subkey1",
            name = "子按钮1",
            sub_button = null,
            type = "click",
            url = "http://"
        };
        _menu.button = new List<Wx.Inter.Domain.Button> { _button };
        Wx.Inter.Domain.MenuGroup mg = new Wx.Inter.Domain.MenuGroup()
        {
            menu = _menu
        };

        string postData = mg.ToJsonString();

        Wx.Inter.Request.CreateMenuRequest createRequest = new Wx.Inter.Request.CreateMenuRequest()
        {
            AccessToken = Wx.Inter.WxAccToken.AccessTokenStr,
            SendData = postData
        };

        Wx.Inter.Interface.IMpClient mpClient = new Wx.Inter.MpClient();
        Wx.Inter.Response.CreateMenuResponse createResponse = mpClient.Execute(createRequest);

        if (createResponse.IsError)
        {
            
            string _msg = string.Format("创建菜单失败，错误信息为：" + createResponse.ErrInfo.ErrCode + "-" + createResponse.ErrInfo.ErrMsg);
            Response.Write("<script>alert('"+ _msg + "!');</script>");
        }
        else
        {
            Response.Write("<script>alert('创建菜单成功');</script>");
        }


    }
}