<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxHome.aspx.cs" Inherits="WxHome" %>

<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>宸汐之家</title>
    <link rel="stylesheet" href="WxAcss/weui.css" />
    <link rel="stylesheet" href="WxAcss/example.css" />
    <script src="WxAjs/zepto.min.js"></script>
    <script src="WxAjs/wxhome.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divreg" class="page js_show input">
            <div class="page__hd">
                <p class="page__desc" style="color: black">欢迎来到宸汐之家</p>
            </div>
            <div class="page__bd">
                <div class="weui-cells__title">注册用户名</div>
                <div class="weui-cells">
                    <div class="weui-cell">
                        <div class="weui-cell__bd">
                            <input id="user" class="weui-input" type="text" placeholder="用户名" />
                        </div>
                    </div>
                    <div class="weui-cell">
                        <div class="weui-cell__bd">
                            <input id="pswd" class="weui-input" type="password" placeholder="密   码" />
                        </div>
                    </div>
                </div>
                <div class="weui-btn-area">
                    <a class="weui-btn weui-btn_primary" id="submit" href="javascript:">确定</a>
                </div>
            </div>
            <uc:WxFooter runat="server" />
        </div>

        <div id="divhome" class="weui-form-preview">
            <div class="weui-form-preview__hd">
                <div class="weui-form-preview__item" style="height: 20px;">
                    <label id="lbqtit" class="weui-form-preview__label" style="color: black; font-size: 18px; margin-top: -10px">欢迎来到宸汐之家</label>
                </div>
            </div>
            <div class="weui-form-preview__bd">
                <div class="weui-form-preview__item">
                    <%--<label id="lbqcontent" class="weui-form-preview__label" style="color: black; font-size: 18px;"></label>--%>
                    <img src="WxAcss/cxcome.jpg" height="100%" width="100%" />
                </div>
            </div>
            <div id="couses" class="button-sp-area" style="padding-bottom: 10px">
                <a id="bill" class='weui-btn weui-btn_plain-primary' href='javascript:;' style='margin: 15px 15px;'>随 手 记</a>
                <a id='ques' class='weui-btn weui-btn_plain-primary' href='javascript:;' style='margin: 15px 15px;'>随 身 答</a>
                <a id='reus' class='weui-btn weui-btn_plain-default' href='javascript:;' style='margin: 15px 15px;'>切换用户</a>
            </div>
        </div>

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
