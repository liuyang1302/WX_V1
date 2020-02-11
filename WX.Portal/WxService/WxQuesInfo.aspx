<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxQuesInfo.aspx.cs" Inherits="WxService_WxQuesInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline-table">
            <div style="display: inline-block; vertical-align: top; display: none">
                <label style="text-align: center;">科目项目</label>
                <asp:Button Text="保存" runat="server" Style="margin-left: 80px" OnClick="OnSaveCourseClick" /><br />
                <br />
                <asp:TextBox ID="tbcourse" Width="220px" runat="server"></asp:TextBox><br />
            </div>
            <div style="display: inline-block; margin-left: 20px; display: none">
                <asp:ListBox ID="lbcourse" runat="server" Width="220px" Height="150px"></asp:ListBox>
                <br />
                <label style="text-align: center; margin-left: -250px">------------------------------------------------------------------------------------------------------------------------------------</label>
            </div>
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
                            <asp:BoundField DataField="InfoCode" HeaderText="编号" SortExpression="编号" />
                            <asp:BoundField DataField="Content" HeaderText="内容" SortExpression="内容" HeaderStyle-Width="650px" />
                            <asp:BoundField DataField="Answer" HeaderText="结果" SortExpression="结果" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>

            <div style="margin-left: 10; vertical-align: top;">
                <label style="text-align: center;">题目内容</label>
                <asp:Button Text="保存" runat="server" Style="margin-left: 510px" OnClick="OnSaveInfoClick" /><br />
                <label>编码</label>
                <asp:TextBox ID="tbcode" runat="server" Width="200px"></asp:TextBox>
                <asp:ListBox ID="lbcourseselect" runat="server" SelectionMode="Single" Rows="1" Width="380px" Style="margin-top: 23px; margin-bottom: 10px"></asp:ListBox><br />
                <asp:TextBox ID="tbcontent" runat="server" Height="179px" Width="620px" TextMode="MultiLine" Style="margin-top: 10px"></asp:TextBox>
                <br />
                <div style="margin-top: 10px">
                    <label style="text-align: center;">A</label>
                    <asp:TextBox ID="tbA" runat="server" Width="605px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px">
                    <label style="text-align: center;">B</label>
                    <asp:TextBox ID="tbB" runat="server" Width="605px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px">
                    <label style="text-align: center;">C</label>
                    <asp:TextBox ID="tbC" runat="server" Width="605px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px">
                    <label style="text-align: center;">D</label>
                    <asp:TextBox ID="tbD" runat="server" Width="605px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px">
                    <label style="text-align: center;">E</label>
                    <asp:TextBox ID="tbE" runat="server" Width="605px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px">
                    <label style="text-align: center;">F</label>
                    <asp:TextBox ID="tbF" runat="server" Width="605px"></asp:TextBox>
                </div>
                <label>答案</label>
                <asp:ListBox ID="lbanswer" runat="server" SelectionMode="Single" Rows="1" Width="100px" Style="margin-top: 23px; margin-bottom: 10px">
                    <asp:ListItem Value="A" Text="A" />
                    <asp:ListItem Value="B" Text="B" />
                    <asp:ListItem Value="C" Text="C" />
                    <asp:ListItem Value="D" Text="D" />
                    <asp:ListItem Value="E" Text="E" />
                    <asp:ListItem Value="F" Text="F" />
                </asp:ListBox>

                <asp:Button Text="保 存" runat="server" Style="margin-top: 10px; margin-left: 10px" OnClick="OnSaveInfoClick" />
                <asp:TextBox ID="tbsave" runat="server" Width="205px"></asp:TextBox>
                <br />
            </div>
        </div>
    </form>
</body>
</html>