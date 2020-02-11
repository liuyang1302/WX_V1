<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxMsgWarn.aspx.cs" Inherits="WxInter_WxMsgWarn" %>

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
        <div class="page msg_warn js_show">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-warn weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 id="_msg" runat="server"  class="weui-msg__title">操作失败</h2>
                    <p class="weui-msg__desc">操作失败,可以返回前页重新操作或者返回记账首页<a href="javascript:void(0);">文字链接</a></p>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a class="weui-btn weui-btn_primary" href="javascript:history.back();">返回操作</a>
                        <asp:Button ID="_butRe" runat="server" class="weui-btn weui-btn_default" Text="记账首页" OnClick="OnButReClick" />
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
