<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddContractMini.ascx.cs"
    Inherits="ASCX_AddContractMini" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<p style="direction: rtl">
    <asp:Panel runat="server" Visible="false" ID="pnlContract">
        <table>
            <tr>
                <td>
                    <b>رقم العقد </b>
                </td>
                <td>
                    <asp:TextBox ID="CONTRACT_NOTextBox" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>اسم العقد </b>
                </td>
                <td style="margin-right: 40px">
                    <asp:TextBox ID="CONTRACT_NAMETextBox" runat="server" />
                </td>
                <td style="margin-right: 40px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>المقاول </b>
                </td>
                <td style="margin-right: 40px">
                    <asp:DropDownList ID="ddlContractors" runat="server" DataSourceID="odsContractors"
                        DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_ID" AppendDataBoundItems="True"
                        Width="80px">
                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="margin-right: 40px">
                    <%--<asp:LinkButton ID="btnAddContractor" runat="server" OnClick="btnAddContractor_Click">إضافة مقاول</asp:LinkButton>--%>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <b>تاريخ العقد </b>
                </td>
                <td style="margin-right: 40px">
                    <telerik:RadDatePicker ID="raddtpBegin" runat="server" Culture="ar-QA"><Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar><DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton></telerik:RadDatePicker>
                </td>
                <td style="margin-right: 40px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>تاريخ بدء التنفيذ </b>
                </td>
                <td style="margin-right: 40px">
                    <telerik:RadDatePicker ID="raddtpWorkBegin" runat="server" Culture="ar-QA"><Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar><DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton></telerik:RadDatePicker>
                </td>
                <td style="margin-right: 40px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>تاريخ الانتهاء </b>
                </td>
                <td style="margin-right: 40px">
                    <telerik:RadDatePicker ID="raddtpEnd" runat="server" Culture="ar-QA"></telerik:RadDatePicker>
                </td>
                <td style="margin-right: 40px">
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddContract" runat="server" ValidationGroup="insert" OnClick="btnAddContract_Click"
                        Text="حفظ" />
                </td>
                <td style="margin-right: 40px">
                    <asp:Button ID="btnCancelContract" runat="server" Text="إلغاء" OnClick="btnCancelContract_Click" />
                </td>
                <td style="margin-right: 40px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:ObjectDataSource ID="odsContractors" runat="server" 
                        SelectMethod="GetContractorsList" TypeName="JpmmsClasses.BL.Lookups.Contractor">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </asp:Panel>
    &nbsp;</p>
