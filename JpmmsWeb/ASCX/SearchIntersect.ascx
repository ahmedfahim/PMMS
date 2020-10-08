<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchIntersect.ascx.cs"
    Inherits="ASCX_SearchIntersect" %>
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
            <asp:RadioButton ID="radByNumber" runat="server" GroupName="search"  Checked="True" Text="رقم التقاطع" />
        </td>
        <td rowspan="2">
            <asp:TextBox ID="txtNumSearch" Width="120px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButton ID="radByName" runat="server" Width="120px" GroupName="search"
                Text="وصف التقاطع" />
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
            <asp:GridView ID="gvSearch" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" DataKeyNames="INTERSECTION_ID" ForeColor="#333333" GridLines="None"
                OnPageIndexChanging="gvSearch_PageIndexChanging" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EnableModelValidation="True">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField SelectText="اختيار" ShowSelectButton="True" />
                    <asp:BoundField DataField="INTERSECTION_ID" HeaderText="INTERSECTION_ID" InsertVisible="False"
                        ReadOnly="True" SortExpression="INTERSECTION_ID" Visible="False" />
                    <asp:BoundField DataField="INTER_NO" HeaderText="الرقم" SortExpression="INTER_NO" />
                    <asp:BoundField DataField="intersection_title" HeaderText="الاسم" ReadOnly="True"
                        SortExpression="intersection_title" />
                    <asp:BoundField DataField="Main_no" HeaderText="رقم الشارع" ReadOnly="True" 
                        SortExpression="Main_no" />
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
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
</table>
