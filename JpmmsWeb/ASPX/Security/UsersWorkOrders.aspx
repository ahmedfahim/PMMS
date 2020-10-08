<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesWorkOrders.master" AutoEventWireup="true" CodeFile="UsersWorkOrders.aspx.cs" Inherits="ASPX_Security_UsersWorkOrders" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style1">
                    <strong>مستخدمي نظام أوامر العمل </strong>
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="USER_ID" DataSourceID="odsUsers"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting">
                    <EditItemTemplate>
                        LABUSER_ID:
                        <asp:Label ID="LABUSER_IDLabel1" runat="server" Text='<%# Eval("LABUSER_ID") %>' />
                        <br />
                        USERNAME:
                        <asp:TextBox ID="USERNAMETextBox" runat="server" Text='<%# Bind("USERNAME") %>' />
                        <br />
                        SUSPENDED:
                        <asp:TextBox ID="SUSPENDEDTextBox" runat="server" Text='<%# Bind("SUSPENDED") %>' />
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
                                    <b>اسم المستخدم </b>
                                </td>
                                <td>
                                    <asp:TextBox ID="USERNAMETextBox" runat="server" Text='<%# Bind("USERNAME") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="USERNAMETextBox"
                                        ValidationGroup="save" Display="Dynamic" ForeColor="Red" ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>كلمة السر </b>
                                </td>
                                <td>
                                    <asp:TextBox ID="user_passwordTextBox" runat="server" Text='<%# Bind("PASSWORD") %>'
                                        TextMode="Password" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="user_passwordTextBox"
                                        ValidationGroup="save" Display="Dynamic" ForeColor="Red" ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>تأكيد كلمة السر </b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" />
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToCompare="txtRePassword"
                                        ValidationGroup="save" ControlToValidate="user_passwordTextBox" ErrorMessage="كلمة السر لاتطابق تأكيدها"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>&nbsp; </b>
                                </td>
                                <td style="text-align: right">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("SUSPENDED") %>' Text="موقوف" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: right">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("IS_ADMIN") %>' Text="مدير للنظام" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2" style="text-align: right">
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("CAN_EDIT") %>' Text="يمكنه تعديل البيانات" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                            Text="حفظ" ValidationGroup="save" />
                                    </b>
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
                        LABUSER_ID:
                        <asp:Label ID="LABUSER_IDLabel" runat="server" Text='<%# Eval("LABUSER_ID") %>' />
                        <br />
                        USERNAME:
                        <asp:Label ID="USERNAMELabel" runat="server" Text='<%# Bind("USERNAME") %>' />
                        <br />
                        SUSPENDED:
                        <asp:Label ID="SUSPENDEDLabel" runat="server" Text='<%# Bind("SUSPENDED") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsUsers" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    SelectMethod="GetAll" TypeName="JpmmsClasses.BL.Lookups.SystemUsers" UpdateMethod="Update"
                    OnDeleted="odsLabUsers_Deleted" OnInserted="odsLabUsers_Inserted" OnUpdated="odsLabUsers_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="USER_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="USERNAME" Type="String" />
                        <asp:Parameter Name="SUSPENDED" Type="Boolean" />
                        <asp:Parameter Name="is_admin" Type="Boolean" />
                        <asp:Parameter Name="can_edit" Type="Boolean" />
                        <asp:Parameter Name="USER_ID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="USERNAME" Type="String" />
                        <asp:Parameter Name="PASSWORD" Type="String" />
                        <asp:Parameter Name="SUSPENDED" Type="Boolean" />
                        <asp:Parameter Name="is_admin" Type="Boolean" />
                        <asp:Parameter Name="can_edit" Type="Boolean" />
                    </InsertParameters>
                </asp:ObjectDataSource>
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
                <asp:GridView ID="gvUsers" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="USER_ID" DataSourceID="odsUsers" ForeColor="#333333"
                    GridLines="None" Style="text-align: center" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged"
                    OnRowDeleting="gvUsers_RowDeleting" OnRowUpdating="gvUsers_RowUpdating">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="USER_ID" HeaderText="USER_ID" ReadOnly="True" SortExpression="USER_ID"
                            Visible="False" />
                        <asp:TemplateField HeaderText="اسم المستخدم" SortExpression="USERNAME">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("USERNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("USERNAME") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                    Display="Dynamic" ErrorMessage="الرجاء الإدخال!" ValidationGroup="update"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="SUSPENDED" HeaderText="موقوف" SortExpression="SUSPENDED" />
                        <asp:CheckBoxField DataField="IS_ADMIN" HeaderText="مدير للنظام" SortExpression="IS_ADMIN" />
                        <asp:CheckBoxField DataField="CAN_EDIT" SortExpression="CAN_EDIT" HeaderText="يمكنه تعديل البيانات" />
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" ValidationGroup="update"
                            UpdateText="حفظ" />
                        <asp:CommandField SelectText="الصلاحيات" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlUserDetails" runat="server" Visible="False">
                    <table>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkGeneralInfo" runat="server" Style="text-align: right" Text="البيانات الوصفية لشبكة الطرق" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkDistresses" runat="server" Text="العيوب  الطرقية" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkUDI" runat="server" Text="حالة الرصف لشبكة الطرق" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkMaintDecisions" runat="server" Text="قرارات الصيانة لشبكة الطرق" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkMaintPrio" runat="server" Text="أولويات الصيانة لشبكة الطرق" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkSurveyingInfo" runat="server" Text="بيانات المسح" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkSystemAdmin" runat="server" Text="المستخدمين والمعلومات الأساسية للنظام" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkReports" runat="server" Text="التقارير" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkOperations" runat="server" Text="العمليات ( التحسينات المرورية وأوامر الصيانة)" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSavePermissions" runat="server" OnClick="btnSavePermissions_Click"
                                                Text="حفظ" CssClass="style2" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelPermissions" runat="server" OnClick="btnCancelPermissions_Click"
                                                Text="إلغاء" CssClass="style2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <strong>تغيير كلمة السر</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>كلمة السر الجديدة </b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChangeUserPassword" runat="server" TextMode="Password" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtChangeUserPassword"
                                                ValidationGroup="edit" Display="Dynamic" ForeColor="Red" ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>تأكيد كلمة السر الجديدة </b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChangeUserPasswordConfirm" runat="server" TextMode="Password" />
                                            <asp:CompareValidator ID="CompareValidator11" runat="server" ForeColor="Red" ControlToCompare="txtChangeUserPassword"
                                                ValidationGroup="edit" ControlToValidate="txtChangeUserPasswordConfirm" ErrorMessage="كلمة السر لاتطابق تأكيدها"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnChangePassword" runat="server" ValidationGroup="edit" Text="تغيير كلمة السر"
                                                CssClass="style2" OnClick="btnChangePassword_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

