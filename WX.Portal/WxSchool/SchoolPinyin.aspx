<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolPinyin.aspx.cs" Inherits="WxSchool_SchoolPinyin" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />

        <%--<div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em"></label>
                </div>
            </div>
        </div>
        <div class="weui-form-preview" >
            <img src="Img/pinyin.png" style="width: auto; height:auto; max-width:100%;max-height:100%;" />
        </div>--%>
        <img src="Img/pinyin.png" style="width: auto; height: auto; max-width: 100%; max-height: 100%; margin-bottom: 30px" />

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
