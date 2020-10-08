<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchSection.ascx.cs"
    Inherits="ASCX_SearchSection" %>
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
            <asp:RadioButton ID="radByNumber" runat="server" GroupName="search" Text="رقم المقطع" />
        </td>
        <td rowspan="2">
            <asp:TextBox ID="txtNumSearch" Width="120px" Checked="True" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButton ID="radByName" runat="server" GroupName="search" Text="وصف المقطع"
                Checked="True" />
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
                CellPadding="4" DataKeyNames="SECTION_ID" ForeColor="#333333" GridLines="None"
                OnPageIndexChanging="gvSearch_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField SelectText="اختيار" ShowSelectButton="True" />
                    <asp:BoundField DataField="SECTION_ID" HeaderText="SECTION_ID" InsertVisible="False"
                        ReadOnly="True" SortExpression="SECTION_ID" Visible="False" />
                    <asp:BoundField DataField="SECTION_NO" HeaderText="الرقم" SortExpression="SECTION_NO" />
                    <asp:BoundField DataField="section_from_to" HeaderText="الاسم" ReadOnly="True" SortExpression="section_from_to" />
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
