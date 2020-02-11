<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxAccBill.aspx.cs" Inherits="WxInter_WxAccBill" %>
<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>每天随手记，轻松微理财</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxaccbill.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item">
                    <label id="lbnow" class="weui-form-preview__label" style="color: chocolate; font-size: large">2017年01月01日</label>
                    <label id="lbname" class="weui-form-preview__value" style="color: chocolate; font-size: large; text-align: right"></label>
                </div>
            </div>
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label class="weui-form-preview__label" style="color: green; font-size: 1.4em">收入总额</label>
                    <label id="lbinsum" class="weui-form-preview__value">¥0.00</label>
                </div>
            </div>
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label class="weui-form-preview__label" style="color: red; font-size: 1.4em">支出总额</label>
                    <label id="lboutsum" class="weui-form-preview__value">¥0.00</label>
                </div>
            </div>
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label class="weui-form-preview__label" style="color: blueviolet; font-size: 1.4em">结余金额</label>
                    <label id="lbsubsum" class="weui-form-preview__value">¥0.00</label>
                </div>
            </div>

            <div class="weui-panel weui-panel_access">
                <div class="weui-panel__bd">
                    <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                        <div class="weui-media-box__hd">
                            <img class="weui-media-box__thumb" alt="" src="WxBillImg/tian.png" />
                        </div>
                        <div class="weui-media-box__bd">
                            <h4 class="weui-media-box__title">今天</h4>
                            <label id="lbday" class="weui-media-box__desc">2017年01月01日</label>
                            <div style="text-align: right; overflow: hidden; margin-top: -50px;">
                                <label id="odsum" class="weui-media-box__desc" style="color: red; font-size: 1em">$0.00</label><br />
                                <label id="idsum" class="weui-media-box__desc" style="color: green; font-size: 1em; margin-top: 5px;">$0.00</label>
                            </div>
                        </div>
                    </a>
                    <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                        <div class="weui-media-box__hd">
                            <img class="weui-media-box__thumb" alt="" src="WxBillImg/zhou.png" />
                        </div>
                        <div class="weui-media-box__bd">
                            <h4 class="weui-media-box__title">本周</h4>
                            <label id="lbweek" class="weui-media-box__desc">01月01日-01月07日</label>
                        </div>
                        <div style="text-align: right; overflow: hidden;">
                            <label id="owsum" class="weui-media-box__desc" style="color: red; font-size: 1em">$0.00</label><br />
                            <label id="iwsum" class="weui-media-box__desc" style="color: green; font-size: 1em; margin-top: 5px;">$0.00</label>
                        </div>
                    </a>
                    <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                        <div class="weui-media-box__hd">
                            <img class="weui-media-box__thumb" alt="" src="WxBillImg/zhang1.jpg" />
                        </div>
                        <div class="weui-media-box__bd">
                            <h4 class="weui-media-box__title">本月</h4>
                            <label id="lbmonth" class="weui-media-box__desc">01月01日-01月31日</label>
                        </div>
                        <div style="text-align: right; overflow: hidden;">
                            <label id="omsum" class="weui-media-box__desc" style="color: red; font-size: 1em">$0.00</label><br />
                            <label id="imsum" class="weui-media-box__desc" style="color: green; font-size: 1em; margin-top: 5px;">$0.00</label>
                        </div>
                    </a>
                    <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                        <div class="weui-media-box__hd">
                            <img class="weui-media-box__thumb" alt="" src="WxBillImg/yue.png" />
                        </div>
                        <div class="weui-media-box__bd">
                            <h4 class="weui-media-box__title">本年</h4>
                            <label id="lbyear" class="weui-media-box__desc">01月01日-12月31日</label>
                        </div>
                        <div style="text-align: right; overflow: hidden;">
                            <label id="oysum" class="weui-media-box__desc" style="color: red; font-size: 1em">$0.00</label><br />
                            <label id="iysum" class="weui-media-box__desc" style="color: green; font-size: 1em; margin-top: 5px;">$0.00</label>
                        </div>
                    </a>
                </div>
            </div>

            <div class="weui-panel weui-panel_access"></div>
            <div class="weui-tab">
                <div class="weui-tab__panel"></div>
                <div class="weui-tabbar">
                    <a id="butacc" class="weui-tabbar__item weui-btn weui-btn_plain-default" href="javascript:void(0);" style="color: red; font-size: medium; margin: 5px">支 出</a>
                    <a id="butinc" class="weui-tabbar__item weui-btn weui-btn_plain-default" href="javascript:void(0);" style="color: green; font-size: medium; margin: 5px">收 入</a>
                    <a id="butrep" class="weui-tabbar__item weui-btn weui-btn_plain-default" href="javascript:void(0);" style="color: chocolate; font-size: medium; margin: 5px">报 表</a>
                </div>
            </div>

            <uc:WxFooter runat="server" />

        </div>
    </form>
</body>
</html>
