<%@ Page Title="معاملات تقييم حالة الرصف" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="UdiRates.aspx.cs" Inherits="ASPX_Lookups_UdiRates" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    <b>معاملات تقييم حالة الرصف</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="RATING_ID" DataSourceID="odsUdiRatings" ForeColor="#333333" GridLines="None"
                    OnRowUpdating="GridView1_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="RATING_ID" HeaderText="RATING_ID" ReadOnly="True" SortExpression="RATING_ID"
                            Visible="False" />
                        <asp:BoundField DataField="U_RATING" HeaderText="التقييم" ReadOnly="True" SortExpression="U_RATING" />
                        <asp:TemplateField HeaderText="الحد الأدنى" SortExpression="MIN">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="txtMin" runat="server" Culture="ar-SA" DbValue='<%# Bind("MIN") %>'
                                    DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                    <NumberFormat DecimalDigits="2" />
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("MIN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الحد الأعلى" SortExpression="MAX">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="txtMax" runat="server" Culture="ar-SA" DbValue='<%# Bind("MAX") %>'
                                    DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                    <NumberFormat DecimalDigits="2" />
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("MAX") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <%--  <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsUdiRatings" runat="server" SelectMethod="GetAll" TypeName="JpmmsClasses.BL.Lookups.UdiRating"
                    UpdateMethod="Update" OnUpdated="odsUdiRatings_Updated">
                    <UpdateParameters>
                        <asp:Parameter Name="MIN" Type="Double" />
                        <asp:Parameter Name="MAX" Type="Double" />
                        <asp:Parameter Name="RATING_ID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
