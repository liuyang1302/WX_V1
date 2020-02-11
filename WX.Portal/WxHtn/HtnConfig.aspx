<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtnConfig.aspx.cs" Inherits="WxHtn_HtnConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 352px;
        }

        .auto-style2 {
            width: 352px;
            height: 443px;
            vertical-align: top;
        }

        .auto-style3 {
            height: 443px;
            vertical-align: top;
        }

        .auto-style4 {
            height: 443px;
            vertical-align: top;
            width: 678px;
        }

        .auto-style5 {
            width: 678px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <table style="width: 100%; height: 646px;">
                <tr>
                    <td class="auto-style2">
                        <asp:ListBox ID="ListBox1" runat="server" Height="776px" Width="283px"  AutoPostBack ="true" OnSelectedIndexChanged="OnSelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td class="auto-style4">
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="276px" Font-Size="16px" Font-Bold="true"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="添 加" Width="92px" OnClick="Button1_Click" />
                        &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="保 存" Width="92px" OnClick="Button2_Click" />
                        &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="删 除" Width="92px" OnClick="Button3_Click" />
                        <br />
                        <br />
                        <asp:DropDownList ID="DropDownList1" runat="server" style="height:30px" Width="283px" Font-Size="16px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="是否启用" />
                        &nbsp;
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="是否更新" />
                        &nbsp;
                        <asp:TextBox ID="TextBox3" runat="server" Height="17px" Width="125px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" Height="643px" Width="653px" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>



        </div>
    </form>
</body>
</html>
