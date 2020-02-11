<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolSx.aspx.cs" Inherits="WxSchool_SchoolSx" %>

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
    <script src="js/SchoolSx.js"></script>
</head>
<body>
    <form id="form1" onkeydown="if(event.keyCode==13){return false;}">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />

        <div id="divtm" class="weui-form-preview">
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

        <div id="divcontent" class="weui-form-preview" style="background-image: url(Img/sxtd.jpg)">
            <div class="weui-form-preview__hd">
                <div class="weui-form-preview__item" style="height: 20px;">
                    <label id="lbqtit" class="weui-form-preview__label" style="color: black; font-size: 24px; margin-top: -10px;"></label>
                </div>
            </div>
            <div class="weui-form-preview__bd">
                <div class="weui-form-preview__item">
                    <div id="lbqcontent" class="weui-form-preview__btn weui-form-preview__btn_default" style="color: black; font-size: 48px; margin-top: -20px;">
                    </div>
                </div>
            </div>
            <div style="text-align: center; margin-top: -20px;">
                <img id="imgok" src="Img/ok.png" style="width: 120px; height: 100px; display: none" />
                <img id="imger" src="Img/er.png" style="width: 120px; height: 100px; display: none" />
            </div>

            <div style="text-align: center;">
                <input id="tda" style="width: 250px; height: 53px; font-size: 36px; color: blue; font-family: SimSun; line-height: 53px"></input>
            </div>
            <%--<div style="text-align: center; margin-top:50px">
                <a id="1" style="width: 250px; height: 35px; font-size: 36px; color: blue">下一题</a>
            </div>--%>

            <%--<div id="dialog" style="height:100px">
                <div class='js_dialog' id='wxconfirm'>
                    <div class='weui-mask'></div>
                    <div class='weui-dialog'>
                        <div class='weui-dialog__hd' style='color: '><strong class='weui-dialog__title'>正确</strong></div>
                        <div class='weui-dialog__bd'>正确1</div>
                        <div class='weui-dialog__ft'>
                            <a id='no' class='weui-dialog__btn weui-dialog__btn_default' href='javascript:;'>重新做</a>
                            <a id='ok' class='weui-dialog__btn weui-dialog__btn_primary' href='javascript:;'>下一题</a>
                        </div>padding-bottom: 10px
                    </div>
                </div>
            </div>--%>

            <div id="cousess" class="button-sp-area" style="text-align: center; margin-top: 50px; height: 100px">
                <a id='next' class='weui-btn weui-btn_plain-default' href='javascript:;' style='margin: 10px 15px;'>提交</a>
            </div>
        </div>

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
