<%@ Page Title="بيانات المساحين" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Surveyors.aspx.cs" Inherits="ASPX_Lookups_Surveyors" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style3">
                    <strong>بيانات المساحين</strong></h2>
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="SURVEYOR_NO" DataSourceID="odsSurveyor"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting" EnableModelValidation="True">
                    <EditItemTemplate>
                        SURVEYOR_NO:
                        <asp:Label ID="SURVEYOR_NOLabel1" runat="server" Text='<%# Eval("SURVEYOR_NO") %>' />
                        <br />
                        SURVEYOR_NAME:
                        <asp:TextBox ID="SURVEYOR_NAMETextBox" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>' />
                        <br />
                        SURVEYOR_WORK_ENDDATE:
                        <asp:TextBox ID="SURVEYOR_WORK_ENDDATETextBox" runat="server" Text='<%# Bind("SURVEYOR_WORK_ENDDATE") %>' />
                        <br />
                        SURVEYOR_WORK_STARTDATE:
                        <asp:TextBox ID="SURVEYOR_WORK_STARTDATETextBox" runat="server" Text='<%# Bind("SURVEYOR_WORK_STARTDATE") %>' />
                        <br />
                        SURVEYOR_PHONE_NO:
                        <asp:TextBox ID="SURVEYOR_PHONE_NOTextBox" runat="server" Text='<%# Bind("SURVEYOR_PHONE_NO") %>' />
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
                                    اسم المساح
                                </td>
                                <td>
                                    <asp:TextBox ID="SURVEYOR_NAMETextBox" Width="120px" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="insert"
                                        ControlToValidate="SURVEYOR_NAMETextBox" runat="server" ErrorMessage="الرجاء إدخال الاسم"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    تاريخ بدء العمل
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("SURVEYOR_WORK_STARTDATE") %>'>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    تاريخ نهاية العمل
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("SURVEYOR_WORK_ENDDATE") %>'>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("SUSPENDED") %>' Text="موقوف من العمل؟" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    رقم الجوال
                                </td>
                                <td>
                                    <asp:TextBox ID="SURVEYOR_PHONE_NOTextBox" runat="server" Text='<%# Bind("SURVEYOR_PHONE_NO") %>'
                                        Width="120px" />
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
                        SURVEYOR_NO:
                        <asp:Label ID="SURVEYOR_NOLabel" runat="server" Text='<%# Eval("SURVEYOR_NO") %>' />
                        <br />
                        SURVEYOR_NAME:
                        <asp:Label ID="SURVEYOR_NAMELabel" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>' />
                        <br />
                        SURVEYOR_WORK_ENDDATE:
                        <asp:Label ID="SURVEYOR_WORK_ENDDATELabel" runat="server" Text='<%# Bind("SURVEYOR_WORK_ENDDATE") %>' />
                        <br />
                        SURVEYOR_WORK_STARTDATE:
                        <asp:Label ID="SURVEYOR_WORK_STARTDATELabel" runat="server" Text='<%# Bind("SURVEYOR_WORK_STARTDATE") %>' />
                        <br />
                        SURVEYOR_PHONE_NO:
                        <asp:Label ID="SURVEYOR_PHONE_NOLabel" runat="server" Text='<%# Bind("SURVEYOR_PHONE_NO") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsSurveyor" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    SelectMethod="GetAllSurveyors" TypeName="JpmmsClasses.BL.Surveyor" UpdateMethod="Update"
                    OnDeleted="sdsSurveyors_Deleted" OnInserted="sdsSurveyors_Inserted" OnUpdated="sdsSurveyors_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="SURVEYOR_NO" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="SURVEYOR_NAME" Type="String" />
                        <asp:Parameter Name="SURVEYOR_WORK_STARTDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_WORK_ENDDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_PHONE_NO" Type="String" />
                        <asp:Parameter Name="SUSPENDED" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SURVEYOR_NAME" Type="String" />
                        <asp:Parameter Name="SURVEYOR_WORK_STARTDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_WORK_ENDDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_PHONE_NO" Type="String" />
                        <asp:Parameter Name="SURVEYOR_NO" Type="Int32" />
                        <asp:Parameter Name="SUSPENDED" Type="Boolean" />
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
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="GridView2" runat="server" DataSourceID="odsSurveyor"
                    AutoGenerateColumns="False" DataKeyNames="SURVEYOR_NO" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnRowDeleting="GridView2_RowDeleting" OnRowUpdating="GridView2_RowUpdating"
                    EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowEditButton="True" CancelText="إلغاء" EditText="تعديل" ValidationGroup="edit"
                            UpdateText="حفظ" />
                        <asp:BoundField DataField="SURVEYOR_NO" HeaderText="SURVEYOR_NO" ReadOnly="True"
                            SortExpression="SURVEYOR_NO" Visible="False" />
                        <asp:TemplateField HeaderText="اسم المساح" SortExpression="SURVEYOR_NAME">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Width="120px" Text='<%# Bind("SURVEYOR_NAME") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="edit" ControlToValidate="TextBox3"
                                    runat="server" ErrorMessage="الرجاء إدخال الاسم"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ بدء العمل" SortExpression="SURVEYOR_WORK_STARTDATE">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker11" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("SURVEYOR_WORK_STARTDATE") %>'>
                                </telerik:RadDatePicker>
                                <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SURVEYOR_WORK_STARTDATE", "{0:d}") %>'></asp:TextBox>--%>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SURVEYOR_WORK_STARTDATE", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ نهاية العمل" SortExpression="SURVEYOR_WORK_ENDDATE">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker13" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("SURVEYOR_WORK_ENDDATE") %>'>
                                </telerik:RadDatePicker>
                                <%--<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SURVEYOR_WORK_ENDDATE", "{0:d}") %>'></asp:TextBox>--%>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SURVEYOR_WORK_ENDDATE", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="SUSPENDED" HeaderText="موقوف من العمل؟" />
                        <asp:BoundField DataField="SURVEYOR_PHONE_NO" HeaderText="رقم الجوال" SortExpression="SURVEYOR_PHONE_NO" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%--<SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
