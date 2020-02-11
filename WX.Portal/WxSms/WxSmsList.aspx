<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxSmsList.aspx.cs" Inherits="WxSms_WxSmsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>短信接收列表</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxsmslist.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div class="page js_show navbar">
            <div class="page__bd" style="height: 100%;">
                <div class="weui-tab">
                    <div class="weui-navbar">
                        <div id="navbar1" class="weui-navbar__item weui-bar__item_on" style="color: red">全部</div>
                        <div id="navbar2" class="weui-navbar__item" style="color: green">验证码</div>
                        <div id="navbar3" class="weui-navbar__item" style="color: chocolate">帐户收支</div>
                        <%--<div id="navbar4" class="weui-navbar__item" style="color: blueviolet">电子码</div>--%>
                    </div>
                    <%--  时间过滤  --%>
                    <div id="_timediv" class="page__bd" style="margin-top: 30px; position: absolute; z-index: 500; width: 100%;">
                        <div class="weui-cells weui-cells_form">
                            <div class="weui-form-preview__ft">
                                <label class="weui-label" style="color: chocolate; margin-left: 15px">开始</label>
                                <input id="sdate" class="weui-input" type="date" style="color: chocolate; height: 3em; margin-left: 8px" value="2017-04-01" />
                                <a class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:"></a>
                                <label class="weui-label" style="color: chocolate; margin-left: 15px">结束</label>
                                <input id="edate" class="weui-input" type="date" style="color: chocolate; height: 3em; margin-left: 8px" value="2017-04-30" />
                            </div>
                        </div>
                    </div>

                    <div class="weui-tab__panel">
                        <%-- 全部 --%>
                        <div id="panel1" runat="server" style="margin-top: 110px;"></div>

                        <%-- 验证码  --%>
                        <div id="panel2" runat="server" style="margin-top: 110px; display: none"></div>

                        <%-- 账户收支  --%>
                        <div id="panel3" runat="server" style="margin-top: 110px; display: none"></div>

                        <%-- 账户收支  --%>
                        <%--<div id="panel4" runat="server" style="margin-top: 110px; display: none"></div>--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
