<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Hijri2Greg.ascx.cs" Inherits="ASCX_Hijri2Greg" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 30%;
    }
</style>
<table class="style1">
    <tr>
        <td>
            <telerik:RadMaskedTextBox ID="MaskedTextBox1" runat="server" Mask="##/##/####" AutoPostBack="True"
                OnTextChanged="MaskedTextBox1_TextChanged" TextWithLiterals="//" Width="125px">
            </telerik:RadMaskedTextBox>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblRadSelectedDate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
