<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxAccount.aspx.cs" Inherits="WxInter_WxAccount" %>
<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>呜呜呜，花钱啦</title>
    <link rel="stylesheet" href="../WxAcss/myweui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxaccount.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <%--<div class="weui-cells__title">呜呜呜，花钱啦</div>--%>
        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label class="weui-form-preview__label" style="color: blueviolet; font-size: 1.4em">本月花销</label>
                    <label id="money" class="weui-form-preview__value" style="color: red; font-size: 1.4em">¥0.00</label>
                </div>
            </div>
        </div>
        <div class="weui-cells weui-cells_form" style="margin-top: 0px">
            <div id="datediv" class="weui-cell weui-cell_select weui-cell_select-before">
                <div class="weui-cell__hd weui-select">
                    <label class="weui-label" style="color: chocolate">时间</label>
                </div>
                <div class="weui-cell__bd">
                    <input id="_lbnow" class="weui-input" type="datetime-local" style="color: chocolate" value="2017/01/18 下午3:31" />
                </div>
            </div>

            <div id="divval"></div>

            <div id="divbz" class="weui-cell">
                <div class="weui-cell__bd">
                    <textarea id="_textarea" runat="server" class="weui-textarea" placeholder="记账备注" rows="3"></textarea>
                    <div class="weui-textarea-counter"><span>0</span>/200</div>
                </div>
            </div>
            <div class="weui-btn-area">
                <a class="weui-btn weui-btn_primary" href="javascript:">确定</a>
            </div>
            <uc:WxFooter runat="server" />
        </div>
    </form>
</body>
</html>
