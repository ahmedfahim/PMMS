<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchRegion.ascx.cs"
    Inherits="ASCX_SearchRegion" %>
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
            <asp:RadioButton ID="radByNumber" runat="server" GroupName="search" Text="رقم المنطقة" />
        </td>
        <td rowspan="2">
            <asp:TextBox ID="txtNumSearch" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButton ID="radByName" runat="server" Checked="True" GroupName="search"
                Text="اسم المنطقة" />
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
                DataKeyNames="region_id" CellPadding="4" ForeColor="#333333" GridLines="None"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="gvSearch_PageIndexChanging">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField SelectText="اختيار" ShowSelectButton="True" />
                    <asp:BoundField DataField="REGION_ID" HeaderText="region_id" InsertVisible="False"
                        ReadOnly="True" SortExpression="REGION_ID" Visible="False" />
                    <asp:BoundField DataField="REGION_NO" HeaderText="الرقم" SortExpression="REGION_NO" />
                    <asp:BoundField DataField="region_title" HeaderText="الاسم" ReadOnly="True" SortExpression="region_title" />
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
