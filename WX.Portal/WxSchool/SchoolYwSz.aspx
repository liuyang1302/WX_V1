<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolYwSz.aspx.cs" Inherits="WxSchool_SchoolYwSz" %>
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
    <script src="js/schoolywsz.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />

        <div id="divtm" class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em">生字学习</label>
                </div>
            </div>
            <div class="weui-form-preview__ft">
                <a id="lbcount" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: green">本科目共 0 题</a>
                <a id="lbnext" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red">下一字</a>
            </div>
        </div>

        <div id="divcontent" class="weui-form-preview" style="background-image: url(Img/ywtd3.jpg); background-position-x: -10px;">

            <div style="height: 20px"></div>

            <div class="weui-form-preview__ft" style="height: 120px; line-height: 120px;">
                <a id="apy" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red; font-weight: 500; font-size: 7em"></a>
            </div>

            <div class="weui-form-preview__ft" style="height: 150px; line-height: 150px;">
                <a id="azi" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red; font-weight: 500; font-size: 9em"></a>
            </div>

        </div>

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
