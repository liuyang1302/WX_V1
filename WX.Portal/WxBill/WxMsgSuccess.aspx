<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxMsgSuccess.aspx.cs" Inherits="WxInter_WxMsgSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>每天随手记，轻松微理财</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page msg_success js_show">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 id="_msg" runat="server" class="weui-msg__title">操作成功</h2>
                    <p class="weui-msg__desc">本次操作已经成功，可以进入记账首页或者继续记录<a href="javascript:void(0);">文字链接</a></p>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <asp:Button ID="_butOk" runat="server" class="weui-btn weui-btn_primary" Text="记账首页" OnClick="OnButOkClick" />
                        <asp:Button ID="_butRe" runat="server" class="weui-btn weui-btn_default" Text="继续记录" OnClick="OnButReClick" />
                    </p>
                </div>
                <div class="weui-msg__extra-area">
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a class="weui-footer__link" href="javascript:void(0);">底部链接文本</a>
                        </p>
                        <p class="weui-footer__text">Copyright © 2008-2017 cxhome.win</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
