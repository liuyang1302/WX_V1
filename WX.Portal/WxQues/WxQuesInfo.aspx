<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxQuesInfo.aspx.cs" Inherits="WxQues_WxQuesInfo" %>
<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>书山有路勤为径</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxquesinfo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />

        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em"></label>
                </div>
            </div>
            <div class="weui-form-preview__ft">
                <a id="lbhcount" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: green">本科目共 0 题</a>
                <a id="lbhecount" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red">已做 0 题 | 做错 0 题</a>
            </div>
        </div>

        <div class="weui-form-preview">
            <div class="weui-form-preview__hd">
                <div class="weui-form-preview__item" style="height: 20px;">
                    <label id="lbqtit" class="weui-form-preview__label" style="color: black; font-size: 18px; margin-top: -10px"></label>
                </div>
            </div>
            <div class="weui-form-preview__bd">
                <div class="weui-form-preview__item">
                    <label id="lbqcontent" class="weui-form-preview__label" style="color: black; font-size: 18px;"></label>

                </div>
            </div>
            <div id="couses" class="button-sp-area" style="padding-bottom: 10px"></div>
        </div>

        <div id="dialog" />

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
