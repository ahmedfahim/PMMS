<%@ Page Title="أنواع العيوب" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DistressTypes.aspx.cs" Inherits="ASPX_Lookups_DistressTypes" %>

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
                    <b>أنواع العيوب </b>
                </h2>
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="DIST_CODE" DataSourceID="odsDistresses"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting">
                    <EditItemTemplate>
                        DIST_CODE:
                        <asp:Label ID="DIST_CODELabel1" runat="server" Text='<%# Eval("DIST_CODE") %>' />
                        <br />
                        DISTRESS_AR_TYPE:
                        <asp:TextBox ID="DISTRESS_AR_TYPETextBox" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                        <br />
                        DISTRESS_EN_TYPE:
                        <asp:TextBox ID="DISTRESS_EN_TYPETextBox" runat="server" Text='<%# Bind("DISTRESS_EN_TYPE") %>' />
                        <br />
                        DISTRESS_SEVERITY:
                        <asp:TextBox ID="DISTRESS_SEVERITYTextBox" runat="server" Text='<%# Bind("DISTRESS_SEVERITY") %>' />
                        <br />
                        DISTRESS_DENSITY_L:
                        <asp:TextBox ID="DISTRESS_DENSITY_LTextBox" runat="server" Text='<%# Bind("DISTRESS_DENSITY_L") %>' />
                        <br />
                        DISTRESS_DENSITY_M:
                        <asp:TextBox ID="DISTRESS_DENSITY_MTextBox" runat="server" Text='<%# Bind("DISTRESS_DENSITY_M") %>' />
                        <br />
                        DISTRESS_DENSITY_H:
                        <asp:TextBox ID="DISTRESS_DENSITY_HTextBox" runat="server" Text='<%# Bind("DISTRESS_DENSITY_H") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    رمز العيب
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Culture="ar-QA"
                                        DataType="System.Double" DbValue='<%# Bind("DIST_CODE") %>' MinValue="0" Width="125px">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="insert"
                                        ControlToValidate="RadNumericTextBox1" runat="server" ErrorMessage="الرجاء إدخال رمز العيب"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    الاسم العربي
                                </td>
                                <td>
                                    <asp:TextBox ID="DISTRESS_AR_TYPETextBox" runat="server" Width="120px" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="insert"
                                        ControlToValidate="DISTRESS_AR_TYPETextBox" runat="server" ErrorMessage="الرجاء إدخال الاسم العربي"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    الاسم الانجليزي
                                </td>
                                <td>
                                    <asp:TextBox ID="DISTRESS_EN_TYPETextBox" runat="server" Width="120px" Text='<%# Bind("DISTRESS_EN_TYPE") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="insert"
                                        ControlToValidate="DISTRESS_EN_TYPETextBox" runat="server" ErrorMessage="الرجاء إدخال الاسم الانجليزي"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("DISTRESS_SEVERITY") %>'
                                        Text="متعدد الشدات" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Density L
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Culture="ar-QA"
                                        DataType="System.Double" DbValue='<%# Bind("DISTRESS_DENSITY_L") %>' MinValue="0"
                                        Width="125px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Density M
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBox3" runat="server" Culture="ar-QA"
                                        DataType="System.Double" DbValue='<%# Bind("DISTRESS_DENSITY_M") %>' MinValue="0"
                                        Width="125px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Density H
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBox4" runat="server" Culture="ar-QA"
                                        DataType="System.Double" DbValue='<%# Bind("DISTRESS_DENSITY_H") %>' MinValue="0"
                                        Width="125px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" ValidationGroup="insert"
                                        CommandName="Insert" Text="حفظ" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="إلغاء" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        DIST_CODE:
                        <asp:Label ID="DIST_CODELabel" runat="server" Text='<%# Eval("DIST_CODE") %>' />
                        <br />
                        DISTRESS_AR_TYPE:
                        <asp:Label ID="DISTRESS_AR_TYPELabel" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                        <br />
                        DISTRESS_EN_TYPE:
                        <asp:Label ID="DISTRESS_EN_TYPELabel" runat="server" Text='<%# Bind("DISTRESS_EN_TYPE") %>' />
                        <br />
                        DISTRESS_SEVERITY:
                        <asp:Label ID="DISTRESS_SEVERITYLabel" runat="server" Text='<%# Bind("DISTRESS_SEVERITY") %>' />
                        <br />
                        DISTRESS_DENSITY_L:
                        <asp:Label ID="DISTRESS_DENSITY_LLabel" runat="server" Text='<%# Bind("DISTRESS_DENSITY_L") %>' />
                        <br />
                        DISTRESS_DENSITY_M:
                        <asp:Label ID="DISTRESS_DENSITY_MLabel" runat="server" Text='<%# Bind("DISTRESS_DENSITY_M") %>' />
                        <br />
                        DISTRESS_DENSITY_H:
                        <asp:Label ID="DISTRESS_DENSITY_HLabel" runat="server" Text='<%# Bind("DISTRESS_DENSITY_H") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsDistresses" runat="server" InsertMethod="Insert" SelectMethod="GetAllDistresses"
                    TypeName="JpmmsClasses.BL.Distress" UpdateMethod="Update" OnDeleted="odsDistresses_Deleted"
                    OnInserted="odsDistresses_Inserted" OnUpdated="odsDistresses_Updated">
                    <InsertParameters>
                        <asp:Parameter Name="DIST_CODE" Type="Int32" />
                        <asp:Parameter Name="DISTRESS_AR_TYPE" Type="String" />
                        <asp:Parameter Name="DISTRESS_EN_TYPE" Type="String" />
                        <asp:Parameter Name="DISTRESS_SEVERITY" Type="Boolean" />
                        <asp:Parameter Name="DISTRESS_DENSITY_L" Type="Double" />
                        <asp:Parameter Name="DISTRESS_DENSITY_M" Type="Double" />
                        <asp:Parameter Name="DISTRESS_DENSITY_H" Type="Double" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="DIST_CODE" Type="Int32" />
                        <asp:Parameter Name="DISTRESS_AR_TYPE" Type="String" />
                        <asp:Parameter Name="DISTRESS_EN_TYPE" Type="String" />
                        <asp:Parameter Name="DISTRESS_SEVERITY" Type="Boolean" />
                        <asp:Parameter Name="DISTRESS_DENSITY_L" Type="Double" />
                        <asp:Parameter Name="DISTRESS_DENSITY_M" Type="Double" />
                        <asp:Parameter Name="DISTRESS_DENSITY_H" Type="Double" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyNames="DIST_CODE" DataSourceID="odsDistresses" PageSize="20" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowEditButton="True" CancelText="إلغاء" EditText="تعديل" UpdateText="حفظ"
                            ValidationGroup="edit" />
                        <asp:BoundField DataField="DIST_CODE" HeaderText="رمز العيب" ReadOnly="True" SortExpression="DIST_CODE" />
                        <asp:TemplateField HeaderText="الاسم العربي" SortExpression="DISTRESS_AR_TYPE">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="edit" ControlToValidate="TextBox1"
                                    runat="server" ErrorMessage="الرجاء إدخال الاسم العربي"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الاسم الانجليزي" SortExpression="DISTRESS_EN_TYPE">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DISTRESS_EN_TYPE") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="edit" ControlToValidate="TextBox2"
                                    runat="server" ErrorMessage="الرجاء إدخال الاسم الانجليزي"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DISTRESS_EN_TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="DISTRESS_SEVERITY" HeaderText="متعدد الشدات؟" />
                        <asp:BoundField DataField="DISTRESS_SEVERITY" HeaderText="متعدد الشدات؟" SortExpression="DISTRESS_SEVERITY"
                            Visible="False" />
                        <asp:BoundField DataField="DISTRESS_DENSITY_L" HeaderText="Density L" SortExpression="DISTRESS_DENSITY_L"
                            DataFormatString="{0:N1}" />
                        <asp:BoundField DataField="DISTRESS_DENSITY_M" HeaderText="Density M" SortExpression="DISTRESS_DENSITY_M"
                            DataFormatString="{0:N1}" />
                        <asp:BoundField DataField="DISTRESS_DENSITY_H" HeaderText="Density H" SortExpression="DISTRESS_DENSITY_H"
                            DataFormatString="{0:N1}" />
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
        </tr>
    </table>
</asp:Content>
