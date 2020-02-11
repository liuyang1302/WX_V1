<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="WxHisInfo_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="js/index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbnow" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em">2017年04月27日</label>
                    <label id="lbname" class="weui-form-preview__value" style="color: blueviolet; font-size: 1.4em"></label>
                </div>
            </div>
        </div>

        <div class="weui-form-preview__ft">
            <div class="weui-cell__bd">&nbsp;&nbsp;&nbsp;客户列表</div>
            <a class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:"></a>
            <%--<label id="lberror1" style="color: red; font-size: 1.4em">0</label>
            <label style="font-size: 1.4em">/</label>--%>
            <label id="ywhave" style="color: blue; margin-right: 10px; font-size: 1.4em">0</label>
        </div>
        <div class="weui-panel" style="margin-top: 2px">
            <div class="weui-panel__bd">
                <div class="weui-media-box weui-media-box_small-appmsg">
                    <div id="yw" class="weui-cells">
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
