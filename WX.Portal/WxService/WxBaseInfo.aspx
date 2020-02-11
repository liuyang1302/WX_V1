<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxBaseInfo.aspx.cs" Inherits="WxService_WxBaseInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="_tbAccessToken" runat="server" Width="466px" Height="90px" TextMode="MultiLine" />
        <br />
        <br />
        <asp:Button ID="_butAccessToken" runat="server" Text="获取AccessToken" OnClick="GetAccessTokenClick" />
    </div>
    </form>
</body>
</html>
