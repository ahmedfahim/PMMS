<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesWorkOrders.master" AutoEventWireup="true" CodeFile="PMcontrols.aspx.cs" Inherits="ASPX_Lookups_PMcontrols" %>

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
                    <strong>مديرين المشروع</strong></h2>
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="CONTRACTOR_ID" DataSourceID="odsContractor"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting">
                    <EditItemTemplate>
                        CONTRACTOR_ID:
                        <asp:Label ID="CONTRACTOR_IDLabel1" runat="server" Text='<%# Eval("CONTRACTOR_ID") %>' />
                        <br />
                        CONTRACTOR_NO:
                        <asp:TextBox ID="CONTRACTOR_NOTextBox" runat="server" Text='<%# Bind("CONTRACTOR_NO") %>' />
                        <br />
                        CONTRACTOR_NAME:
                        <asp:TextBox ID="CONTRACTOR_NAMETextBox" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                        <br />
                        PHONE:
                        <asp:TextBox ID="PHONETextBox" runat="server" Text='<%# Bind("PHONE") %>' />
                        <br />
                        FAX:
                        <asp:TextBox ID="FAXTextBox" runat="server" Text='<%# Bind("FAX") %>' />
                        <br />
                        MOBILE:
                        <asp:TextBox ID="MOBILETextBox" runat="server" Text='<%# Bind("MOBILE") %>' />
                        <br />
                        EMAIL:
                        <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
                        <br />
                        ProjectManager:
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProjectManager") %>' />
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
                                   الإسم 
                                </td>
                                <td>
                                    <asp:TextBox ID="CONTRACTOR_NAMETextBox" Width="120px" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="insert"
                                        runat="server" ControlToValidate="CONTRACTOR_NAMETextBox" ErrorMessage="الرجاء إدخال الاسم "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   التليفون
                                </td>
                                <td>
                                    <asp:TextBox ID="CONTRACTOR_NOTextBox" Width="120px" runat="server" Text='<%# Bind("CONTRACTOR_NO") %>' />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    البريد الإلكتروني
                                </td>
                                <td>
                                    <asp:TextBox ID="PHONETextBox" Width="120px" runat="server" Text='<%# Bind("PHONE") %>' />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                  الرقم الوظيفي
                                </td>
                                <td style="margin-right: 80px">
                                <asp:TextBox ID="WorkunmTextBox" Width="120px" runat="server" Text='<%# Bind("PHONE") %>' />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    طبيعة عمل مدير المشروع
                                </td>
                                <td style="margin-right: 80px">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="-1">اختر طبيعة العمل</asp:ListItem>
                                        <asp:ListItem Value="1">مدير المشروع المقاول</asp:ListItem>
                                        <asp:ListItem Value="2">مدير المشروع الأستشاري</asp:ListItem>
                                        <asp:ListItem Value="3">مدير المشروع الأمانة</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr>
                                <td>
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        ValidationGroup="insert" Text="حفظ" />
                                </td>
                                <td style="margin-right: 160px">
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
                        CONTRACTOR_ID:
                        <asp:Label ID="CONTRACTOR_IDLabel" runat="server" Text='<%# Eval("CONTRACTOR_ID") %>' />
                        <br />
                        CONTRACTOR_NO:
                        <asp:Label ID="CONTRACTOR_NOLabel" runat="server" Text='<%# Bind("CONTRACTOR_NO") %>' />
                        <br />
                        CONTRACTOR_NAME:
                        <asp:Label ID="CONTRACTOR_NAMELabel" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                        <br />
                        PHONE:
                        <asp:Label ID="PHONELabel" runat="server" Text='<%# Bind("PHONE") %>' />
                        <br />
                        FAX:
                        <asp:Label ID="FAXLabel" runat="server" Text='<%# Bind("FAX") %>' />
                        <br />
                        MOBILE:
                        <asp:Label ID="MOBILELabel" runat="server" Text='<%# Bind("MOBILE") %>' />
                        <br />
                        EMAIL:
                        <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' />
                        <br /> 
                        ProjectManager:
                        <asp:Label ID="ProjectManagerLabel" runat="server" Text='<%# Bind("ProjectManager") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsProjects" runat="server"
                    SelectMethod="GetAllProjectssList" 
                    TypeName="JpmmsClasses.BL.Lookups.Projects">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractor" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OnDeleted="odsContractor_Deleted" OnInserted="odsContractor_Inserted" OnUpdated="odsContractor_Updated"
                    SelectMethod="GetAllContractorsList" TypeName="JpmmsClasses.BL.Lookups.Contractor"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="CONTRACTOR_ID" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CONTRACTOR_NAME" Type="String" />
                        <asp:Parameter Name="PHONE" Type="String" />
                        <asp:Parameter Name="FAX" Type="String" />
                        <asp:Parameter Name="MOBILE" Type="String" />
                        <asp:Parameter Name="EMAIL" Type="String" />
                        <asp:Parameter Name="CONTRACTOR_NO" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CONTRACTOR_NAME" Type="String" />
                        <asp:Parameter Name="PHONE" Type="String" />
                        <asp:Parameter Name="FAX" Type="String" />
                        <asp:Parameter Name="MOBILE" Type="String" />
                        <asp:Parameter Name="EMAIL" Type="String" />
                        <asp:Parameter Name="CONTRACTOR_NO" Type="String" />
                        <asp:Parameter Name="CONTRACTOR_ID" Type="String" />
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
                    CellPadding="4" DataKeyNames="CONTRACTOR_ID" DataSourceID="odsContractor" ForeColor="#333333"
                    GridLines="None" OnRowDeleting="GridView1_RowDeleting" 
                    OnRowUpdating="GridView1_RowUpdating" EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:BoundField DataField="CONTRACTOR_ID" HeaderText="CONTRACTOR_No" ReadOnly="True"
                            SortExpression="CONTRACTOR_ID" Visible="False" />
                        <asp:BoundField DataField="CONTRACTOR_No" HeaderText="الإسم" 
                            SortExpression="CONTRACTOR_No" />
                        <asp:BoundField DataField="CONTRACTOR_NAME" HeaderText="التليفون" 
                            SortExpression="CONTRACTOR_NAME" />
                        <asp:BoundField DataField="PHONE" HeaderText="البريد الإلكتروني" 
                            SortExpression="PHONE" />
                        <asp:BoundField DataField="FAX" HeaderText="الرقم الوظيفي" 
                            SortExpression="FAX" />
                        <asp:BoundField DataField="MOBILE" HeaderText="طبيعة العمل" 
                            SortExpression="MOBILE" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
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
        </tr>
    </table>
</asp:Content>
