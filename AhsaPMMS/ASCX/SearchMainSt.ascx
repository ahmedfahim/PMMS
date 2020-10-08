<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchMainSt.ascx.cs"
    Inherits="ASCX_SearchMainSt" %>
<style type="text/css">
    .style1
    {
        width: 60%;
        direction: rtl;
    }
</style>
<style type="text/css">
    .style1
    {
        width: 60%;
        direction: rtl;
    }
</style>
<table class="style1">
    <tr>
        <td width="20%">
            <asp:RadioButton ID="radByNumber" runat="server" GroupName="search" Text="رقم الطريق" />
        </td>
        <td rowspan="2">
            <asp:TextBox ID="txtNumSearch" Width="120px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButton ID="radByName" runat="server" Checked="True" GroupName="search"
                Text="اسم الطريق" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="بحث" CausesValidation="False" />
        </td>
        <td>
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvSearch" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" DataKeyNames="STREET_ID" ForeColor="#333333" GridLines="None"
                OnPageIndexChanging="gvSearch_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                EnableModelValidation="True">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField SelectText="اختيار" ShowSelectButton="True" />
                    <asp:BoundField DataField="STREET_ID" HeaderText="STREET_ID" InsertVisible="False"
                        ReadOnly="True" SortExpression="STREET_ID" Visible="False" />
                    <asp:BoundField DataField="MAIN_NO" HeaderText="الرقم" SortExpression="MAIN_NO" />
                    <asp:BoundField DataField="main_st_title" HeaderText="الاسم" ReadOnly="True" SortExpression="main_st_title" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
</table>
