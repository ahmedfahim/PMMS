<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesWorkOrders.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="ASPX_Lookups_Projects" %>


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
                    <strong>المشاريع</strong></h2>
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="Projects_ID" DataSourceID="odsProjects"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting" 
                    EnableModelValidation="True">
                    <EditItemTemplate>
                        Projects_ID:
                        <asp:Label ID="Projects_IDLabel1" runat="server" Text='<%# Eval("Projects_ID") %>' />
                        <br />
                        Projects_NO:
                        <asp:TextBox ID="Projects_NOTextBox" runat="server" Text='<%# Bind("Projects_NO") %>' />
                        <br />
                        Projects_NAME:
                        <asp:TextBox ID="Projects_NAMETextBox" runat="server" Text='<%# Bind("Projects_NAME") %>' />
                       
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
                                    اسم المشروع
                                </td>
                                <td>
                                    <asp:TextBox ID="Projects_NAMETextBox" Width="220px" runat="server" 
                                        Text='<%# Bind("Projects_NAME") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="insert"
                                        runat="server" ControlToValidate="Projects_NAMETextBox" ErrorMessage="الرجاء إدخال الاسم "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    رقم المشروع
                                </td>
                                <td>
                                    <asp:TextBox ID="Projects_NOTextBox" Width="220px" runat="server" 
                                        Text='<%# Bind("Projects_NO") %>' />
                                </td>
                                <td>
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
                        Projects_ID:
                        <asp:Label ID="Projects_IDLabel" runat="server" Text='<%# Eval("Projects_ID") %>' />
                        <br />
                        Projects_NO:
                        <asp:Label ID="Projects_NOLabel" runat="server" Text='<%# Bind("Projects_NO") %>' />
                        <br />
                        Projects_NAME:
                        <asp:Label ID="Projects_NAMELabel" runat="server" Text='<%# Bind("Projects_NAME") %>' />
                       
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsProjects" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OnDeleted="odsProjects_Deleted" OnInserted="odsProjects_Inserted" OnUpdated="odsProjects_Updated"
                    SelectMethod="GetAllProjectssList" TypeName="JpmmsClasses.BL.Lookups.Projects"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Projects_ID" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Projects_NAME" Type="String" />
                        <asp:Parameter Name="Projects_NO" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Projects_NAME" Type="String" />
                        <asp:Parameter Name="Projects_NO" Type="String" />
                        <asp:Parameter Name="Projects_ID" Type="Int32" />
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
                    CellPadding="4" DataKeyNames="Projects_ID" DataSourceID="odsProjects" ForeColor="#333333"
                    GridLines="None" OnRowDeleting="GridView1_RowDeleting" 
                    OnRowUpdating="GridView1_RowUpdating" EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:BoundField DataField="Projects_ID" HeaderText="Projects_No" ReadOnly="True"
                            SortExpression="Projects_ID" Visible="False" />
                        <asp:BoundField DataField="Projects_No" HeaderText="رقم المقاول" SortExpression="Projects_No" />
                        <asp:BoundField DataField="Projects_NAME" HeaderText="اسم المقاول" SortExpression="Projects_NAME" />
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
                
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

