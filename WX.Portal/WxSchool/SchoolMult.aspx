<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolMult.aspx.cs" Inherits="WxSchool_SchoolMult" %>

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
    <script src="js/SchoolMult.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />
        <a id="aa" href="javascript:">
            <img src="Img/99.jpg" style="width: auto; height: auto; max-width: 100%; max-height: 100%; margin-bottom: 30px" />
        </a>
        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
