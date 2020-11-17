<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolShiWen.aspx.cs" Inherits="WxSchool_SchoolShiWen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>书山有路勤为径</title>
    <link rel="stylesheet" href="css/weui.css" />
    <link rel="stylesheet" href="css/example.css" />
    <script src="js/zepto.min.js"></script>
    <script src="js/schoolshiwen.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="id" runat="server" style="display: none" />

        <div id="divtm" class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 20px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em"></label>
                </div>
            </div>

            <div style="clear: both; height: auto; margin-top: 10px; margin-bottom: 5px; overflow: hidden;">
                <audio id="_audio" style="cursor: pointer; outline: none; float: left; margin-bottom: 5px; margin-left: 5px; margin-right: 5px;" controls="controls" autoplay="autoplay"></audio>
                <span id="_info" style="margin-left: 10px; float: left; margin-top: 7px; font-size: 14px;"></span>
            </div>
        </div>

        <div id="content" class="content" style="margin-left: 20px; margin-right: 20px; height: auto;"></div>

        <div class="weui-panel" style="margin-top: 2px">
            <div class="weui-panel__bd">
                <div class="weui-media-box weui-media-box_small-appmsg">
                    <div id="list" class="weui-cells">
                        
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
