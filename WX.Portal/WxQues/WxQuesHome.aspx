<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxQuesHome.aspx.cs" Inherits="WxQues_WxQuesHome" %>
<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>每时每刻，随身提高</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxqueshome.js"></script>
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
            <div class="weui-form-preview__ft">
                <div class="weui-cell__bd">
                    <select id="setype" class="weui-select">
                        <option value="主治医师">主治医师</option>
                        <option value="执业药师">执业药师</option>
                        <option value="定期考核" selected="selected">定期考核</option>
                    </select>
                </div>
                <a id="lbsearch" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:void(0);">快速查询</a>
                <a class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:"></a>
                <label id="lberror" style="color: red; font-size: 1.4em">0</label>
                <label style="font-size: 1.4em">/</label>
                <label id="lbhave" style="color: blue; margin-right: 10px; font-size: 1.4em">0</label>
            </div>
        </div>

        <div class="weui-panel" style="margin-top:2px">
            <div class="weui-panel__bd">
                <div class="weui-media-box weui-media-box_small-appmsg">
                    <div id="queslist" class="weui-cells">
                        
                    </div>
                </div>
            </div>
        </div>

        <%--<uc:WxFooter runat="server" />--%>
    </form>
</body>
</html>
