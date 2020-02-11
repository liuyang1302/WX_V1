<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolEdit.aspx.cs" Inherits="WxSchool_SchoolEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline-table">
            <div style="display: inline;">
                <asp:Panel ID="Panel1" runat="server" Height="210px" ScrollBars="Auto">
                    <asp:GridView ID="GridView1" runat="server" Height="50px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="类型" HeaderText="类型" SortExpression="类型" />
                            <asp:BoundField DataField="题目" HeaderText="题目" SortExpression="题目" HeaderStyle-Width="650px" />
                            <asp:BoundField DataField="答案" HeaderText="答案" SortExpression="答案" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>

            <div style="margin-left: 10; vertical-align: top;">
                <label style="text-align: center;">题目内容</label>
                <asp:Button Text="保存" runat="server" Style="margin-left: 510px" OnClick="OnSaveInfoClick" /><br />
                <label>编码</label>
                <asp:TextBox ID="tbcode" runat="server" Width="200px"></asp:TextBox>
                <asp:ListBox ID="lbtype" runat="server" SelectionMode="Single" Rows="1" Width="380px" Style="margin-top: 23px; margin-bottom: 10px"></asp:ListBox>
                <br />
                <asp:TextBox ID="tbcontent" runat="server" Height="179px" Width="620px" TextMode="MultiLine" Style="margin-top: 10px"></asp:TextBox>
                <br />
                <div style="margin-top: 10px">
                    <label style="text-align: center;">答案</label>
                    <asp:TextBox ID="tbsave" runat="server" Width="590px"></asp:TextBox>
                </div>
                <br />
                <asp:Button Text="保 存" runat="server" Style="margin-top: 10px; margin-left: 10px" OnClick="OnSaveInfoClick" />
                <br />
                <asp:Button Text="批 量" runat="server" Style="margin-top: 10px; margin-left: 10px" OnClick="OnSaveBactInfoClick" />
            </div>
        </div>
    </form>
</body>
</html>
