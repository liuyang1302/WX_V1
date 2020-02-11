<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolVoice.aspx.cs" Inherits="WxSchool_SchoolVoice" %>

<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>书山有路勤为径</title>
    <link rel="stylesheet" href="../WxAcss/myweui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="js/audio.min.js"></script>
    <script src="js/voice-2.0.js"></script>
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="js/schoolvoice.js"></script>
</head>

<script>
    audiojs.events.ready(function () {
        var as = audiojs.createAll();
    });
</script>

<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="state" runat="server" style="display: none" />
        <div id="cntent" runat="server" style="display: none" />
        <div id="name" runat="server" style="display: none" />

        <div id="divtm" class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em"></label>
                </div>
            </div>
            <div class="weui-form-preview__ft">
                <a id="lbplay" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: green">播 放</a>
                <a id="lbstop" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red">停 止</a>
            </div>
        </div>

        <div class="weui-panel" style="margin-top: 2px">
            <div class="weui-panel__bd">
                <div class="weui-media-box weui-media-box_small-appmsg">
                    <div id="voices" class="weui-cells">
                    </div>
                </div>
            </div>
        </div>

        <uc:WxFooter runat="server" />
    </form>
</body>

</html>
