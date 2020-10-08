<%@ Page Title="قرارات الصيانة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MaintDecisions.aspx.cs" Inherits="ASPX_Lookups_MaintDecisions" %>

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
            <td class="style2">
                <h2>
                    <b>قرارات الصيانة</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
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
                <asp:ObjectDataSource ID="odsUnits" runat="server" SelectMethod="GetAll" TypeName="JpmmsClasses.BL.Lookups.Unit">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMaintDecisions" runat="server" SelectMethod="GetAllDecisions"
                    TypeName="JpmmsClasses.BL.Lookups.MaintDecision" OnUpdated="odsMaintDecisions_Updated"
                    UpdateMethod="Update">
                    <UpdateParameters>
                        <asp:Parameter Name="UNIT_ID" Type="Int32" />
                        <asp:Parameter Name="UNIT_PRICE" Type="Double" />
                        <asp:Parameter Name="RECOMMENDED_DECISION_ID" Type="Int32" />
                        <asp:Parameter Name="LIFECYCLE_AGE" Type="Int32" />
                        <asp:Parameter Name="THICKNESS" Type="Double" />
                        <asp:Parameter Name="UDI_ENHANCE" Type="Int32" />
                        <asp:Parameter Name="DECISION_TYPE" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
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
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="RECOMMENDED_DECISION_ID" DataSourceID="odsMaintDecisions"
                    ForeColor="#333333" GridLines="None" OnRowUpdating="GridView1_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ"
                            ValidationGroup="edit" />
                        <asp:BoundField DataField="RECOMMENDED_DECISION_ID" HeaderText="RECOMMENDED_DECISION_ID"
                            ReadOnly="True" SortExpression="RECOMMENDED_DECISION_ID" Visible="False" />
                        <asp:BoundField DataField="RECOMMENDED_DECISION" HeaderText="قرار الصيانة" SortExpression="RECOMMENDED_DECISION"
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="نوع قرار الصيانة">
                            <EditItemTemplate>
                                <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("DECISION_TYPE") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("DECISION_TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="وحدة القياس">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlUnits" runat="server" Width="120px" AppendDataBoundItems="True"
                                    DataSourceID="odsUnits" DataTextField="UNIT_NAME" DataValueField="UNIT_ID" SelectedValue='<%# Bind("UNIT_ID") %>'>
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlUnits"
                                    ErrorMessage="الرجاء اختيار وحدة القياس" Operator="NotEqual" ValidationGroup="edit"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("unit_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="سعر الوحدة (ريال)" SortExpression="UNIT_PRICE">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Culture="ar-QA"
                                    DataType="System.Double" DbValue='<%# Bind("UNIT_PRICE") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadNumericTextBox1"
                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("UNIT_PRICE", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="سماكة التنفيذ (سم)">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox11" runat="server" Culture="ar-QA"
                                    DataType="System.Double" DbValue='<%# Bind("THICKNESS") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadNumericTextBox11"
                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("THICKNESS", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="دورة عمر الصيانة (سنة)">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox12" runat="server" Culture="ar-QA"
                                    DataType="System.Double" DbValue='<%# Bind("LIFECYCLE_AGE") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadNumericTextBox12"
                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("LIFECYCLE_AGE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مقدار تحسن حالة الرصف">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="txtUDI_ENHANCE" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("UDI_ENHANCE") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtUDI_ENHANCE"
                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("UDI_ENHANCE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
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
                &nbsp;
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
