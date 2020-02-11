<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxSmsSend.aspx.cs" Inherits="WxSms_WxSmsSend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <script src="../WxAjs/zepto.min.js"></script>

    <style type="text/css">
        #TextArea1 {
            height: 217px;
            width: 692px;
        }

        #Button1 {
            width: 77px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <textarea id="TextArea1" runat="server" name="S1"></textarea>
            </p>
            <p>
                &nbsp;
            </p>
            <p>
                <input id="send" name="send" type="button" value="发 送"  />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </p>
            <p>
                &nbsp;&nbsp;&nbsp; &nbsp;
            </p>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#send").on('click', function () {

                var _user = $("#TextArea1").val();

                $.ajax({
                    url: "../WxHandlers/WxSmsService.ashx",
                    data: { data:_user },
                    async: true,
                    success: function (data) {

                        alert(data);
                    } });
            });
        });

    </script>
</body>
</html>
