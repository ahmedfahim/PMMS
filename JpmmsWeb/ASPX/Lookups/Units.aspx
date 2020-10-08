<%@ Page Title="وحدات القياس" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Units.aspx.cs" Inherits="ASPX_Lookups_Units" %>

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
                    <b>وحدات القياس</b></h2>
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="UNIT_ID" DataSourceID="odsUnits"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting">
                    <EditItemTemplate>
                        UNIT_ID:
                        <asp:Label ID="UNIT_IDLabel1" runat="server" Text='<%# Eval("UNIT_ID") %>' />
                        <br />
                        UNIT_NAME:
                        <asp:TextBox ID="UNIT_NAMETextBox" runat="server" Text='<%# Bind("UNIT_NAME") %>' />
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
                                    اسم وحدة القياس
                                </td>
                                <td>
                                    <asp:TextBox ID="UNIT_NAMETextBox" Width="120px" runat="server" Text='<%# Bind("UNIT_NAME") %>' />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="insert"
                                        ControlToValidate="UNIT_NAMETextBox" runat="server" ErrorMessage="الرجاء إدخال الاسم "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        ValidationGroup="insert" Text="حفظ" />
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
                        UNIT_ID:
                        <asp:Label ID="UNIT_IDLabel" runat="server" Text='<%# Eval("UNIT_ID") %>' />
                        <br />
                        UNIT_NAME:
                        <asp:Label ID="UNIT_NAMELabel" runat="server" Text='<%# Bind("UNIT_NAME") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsUnits" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    SelectMethod="GetAll" TypeName="JpmmsClasses.BL.Lookups.Unit" UpdateMethod="Update"
                    OnDeleted="odsUnits_Deleted" OnInserted="odsUnits_Inserted" OnUpdated="odsUnits_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="UNIT_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="UNIT_NAME" Type="String" />
                        <asp:Parameter Name="UNIT_ID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="UNIT_NAME" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: right">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="text-align: right">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyNames="UNIT_ID" DataSourceID="odsUnits" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:BoundField DataField="UNIT_ID" HeaderText="UNIT_ID" ReadOnly="True" SortExpression="UNIT_ID"
                            Visible="False" />
                        <asp:BoundField DataField="UNIT_NAME" HeaderText="وحدة القياس" SortExpression="UNIT_NAME" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
    </table>
</asp:Content>
