<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxMenu.aspx.cs" Inherits="WxService_WxMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="_gv" runat="server"></asp:GridView>
         <br />
        <asp:Button ID="_butUp" runat="server" Text="保存并发布" OnClick="OnbutUpClick" />
    </div>
    </form>
</body>
</html>
