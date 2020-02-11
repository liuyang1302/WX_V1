<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>宸汐之家</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=0" />
    <link href="WxAcss/style.css" rel="stylesheet" />
    <script src="WxAjs/zepto.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div class="wxapi_container">
            <div class="wxapi_index_container">
                <ul class="label_box lbox_close wxapi_index_list">
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="WxBill/WxAccBill.aspx">随手记</a></li>
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-image">记一笔</a></li>
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-voice">收一笔</a></li>
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-smart">报一报</a></li>
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="WxQues/WxQuesHome.aspx">定期考核</a></li>
                    <%--<li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-device">查短信</a></li>
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-location">电子码</a></li>--%>
                    <li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-webview">汐汐学习</a></li>
                    <%--<li class="label_item wxapi_index_item"><a class="label_inner" href="#menu-scan">客户信息</a></li>--%>
                </ul>
            </div>
        </div>
    </form>
    <script>

        $(function () {

            function init() {

                var _html = "";
                var _params = "?OpenID=" + $("#openid").html() + "&NickName=" + $("#nickname").html();
                var _li1 = "<li class='label_item wxapi_index_item'><a class='label_inner' href='";
                var _li2 = "'>";
                var _li3 = "</a></li>";

                _html += _li1 + "WxBill/WxAccBill.aspx" + _params + _li2 + "随手记" + _li3;
                _html += _li1 + "WxBill/WxAccount.aspx" + _params + _li2 + "记一笔" + _li3;
                _html += _li1 + "WxBill/WxIncome.aspx" + _params + _li2 + "收一笔" + _li3;
                _html += _li1 + "WxBill/WxReport.aspx" + _params + _li2 + "报一报" + _li3;
                _html += _li1 + "WxQues/WxQuesHome.aspx" + _params + _li2 + "定期考核" + _li3;
                //_html += _li1 + "WxSms/WxSmsList.aspx" + _params + _li2 + "查短信" + _li3;
                //_html += _li1 + "WxSms/WpCodes.html" + _params + _li2 + "电子码" + _li3;
                _html += _li1 + "WxSchool/index.html" + _params + _li2 + "汐汐学习" + _li3;
                //_html += _li1 + "WxHisInfo/index.aspx" + _params + _li2 + "客户信息" + _li3;

                $(".wxapi_index_list").html(_html);
            }

            init();
        });

    </script>
</body>

</html>
