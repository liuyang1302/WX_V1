<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxIncome.aspx.cs" Inherits="WxInter_WxIncome" %>
<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>每天随手记，轻松微理财</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxincome.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div class="weui-cells__title">来钱啦，美美滴</div>
        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label class="weui-form-preview__label" style="color: blueviolet; font-size: 1.4em">结余金额</label>
                    <label id="lbssum" class="weui-form-preview__value" style="font-size: 1.4em">¥0.00</label>
                </div>
            </div>
            <div class="weui-form-preview__ft">
                <a id="lbisum" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: green">收入：¥0.00</a>
                <a id="lbosum" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red">支出：¥0.00</a>
            </div>
        </div>

        <div class="weui-cells weui-cells_form">
            <div class="weui-cell">
                <div class="weui-cell__hd">
                    <label class="weui-label" style="color: chocolate">记账时间</label>
                </div>
                <div class="weui-cell__bd">
                    <%-- yyyy-MM-ddTHH:mm --%>
                    <input id="lbnow" class="weui-input" type="datetime-local" value="" style="color: chocolate" />
                </div>
            </div>

            <div class="weui-cell"></div>
            <div class="weui-cell weui-cell_select weui-cell_select-after">
                <div class="weui-cell__hd">
                    <label class="weui-label" for="">收入类型</label>
                </div>
                <div class="weui-cell__bd">
                    <select id="setype" class="weui-select">
                        <option value="工资收入">工资收入</option>
                        <option value="奖金收入">奖金收入</option>
                        <option value="报销收入">报销收入</option>
                        <option value="网络收入">网络收入</option>
                        <option value="账号调整">账号调整</option>
                        <option value="收入期初">收入期初</option>
                        <option value="其他收入">其他收入</option>
                    </select>
                </div>
            </div>

            <div class="weui-cell"></div>
            <div class="weui-cell">
                <div class="weui-cell__bd">
                    <input id="money" runat="server" class="weui-input weui-input-number" type="number" step="0.01" placeholder="￥金额(CNY)" pattern="[0-9]*" style="text-align: right" />
                </div>
            </div>

            <div class="weui-cell"></div>
            <div class="weui-cell">
                <div class="weui-cell__bd">
                    <textarea id="textarea" runat="server" class="weui-textarea" placeholder="记账备注" rows="4"></textarea>
                    <div class="weui-textarea-counter"><span>0</span>/200</div>
                </div>
            </div>

            <div class="weui-cell"></div>
            <div class="weui-btn-area">
                <a class="weui-btn weui-btn_primary" href="javascript:">确定</a>
            </div>

        </div>

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
