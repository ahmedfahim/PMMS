<%@ Page Title="قرارات الصيانة للعيوب" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MaintDeciding.aspx.cs" Inherits="ASPX_Lookups_MaintDeciding" %>

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
            <td colspan="3" class="style2">
                <h2>
                    <b>قرارات الصيانة للعيوب</b></h2>
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
            <td colspan="3">
                <%--<asp:FormView ID="FormView1" runat="server" DataKeyNames="RECORD_ID" DataSourceID="odsMaintDeciding"
                    DefaultMode="Insert">
                    <EditItemTemplate>
                        RECORD_ID:
                        <asp:Label ID="RECORD_IDLabel1" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                        <br />
                        DIST_CODE:
                        <asp:TextBox ID="DIST_CODETextBox" runat="server" Text='<%# Bind("DIST_CODE") %>' />
                        <br />
                        DIST_SEVER:
                        <asp:TextBox ID="DIST_SEVERTextBox" runat="server" Text='<%# Bind("DIST_SEVER") %>' />
                        <br />
                        DENSITY_FROM:
                        <asp:TextBox ID="DENSITY_FROMTextBox" runat="server" Text='<%# Bind("DENSITY_FROM") %>' />
                        <br />
                        DENSITY_TO:
                        <asp:TextBox ID="DENSITY_TOTextBox" runat="server" Text='<%# Bind("DENSITY_TO") %>' />
                        <br />
                        MAINT_DEC_ID:
                        <asp:TextBox ID="MAINT_DEC_IDTextBox" runat="server" Text='<%# Bind("MAINT_DEC_ID") %>' />
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
                                    <b>العيب</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="odsDistresses" DataTextField="distress_title" DataValueField="dist_code"
                                        SelectedValue='<%# Bind("DIST_CODE") %>'>
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الشدة</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        SelectedValue='<%# Bind("DIST_SEVER") %>'>
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                        <asp:ListItem>L</asp:ListItem>
                                        <asp:ListItem>M</asp:ListItem>
                                        <asp:ListItem>H</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>قرار الصيانة
                                        <br />
                                        للكثافة المنخفضة</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="odsMaintDecisions" DataTextField="decision_title" DataValueField="RECOMMENDED_DECISION_ID"
                                        SelectedValue='<%# Bind("low_dens_maint_dec") %>'>
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>قرار الصيانة
                                        <br />
                                        للكثافة المتوسطة</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="odsMaintDecisions" DataTextField="decision_title" DataValueField="RECOMMENDED_DECISION_ID"
                                        SelectedValue='<%# Bind("med_dens_maint_dec") %>'>
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>قرار الصيانة
                                        <br />
                                        للكثافة العالية</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList5" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="odsMaintDecisions" DataTextField="decision_title" DataValueField="RECOMMENDED_DECISION_ID"
                                        SelectedValue='<%# Bind("high_dens_maint_dec") %>'>
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        CssClass="style2" Text="حفظ" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="إلغاء" />
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        RECORD_ID:
                        <asp:Label ID="RECORD_IDLabel" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                        <br />
                        DIST_CODE:
                        <asp:Label ID="DIST_CODELabel" runat="server" Text='<%# Bind("DIST_CODE") %>' />
                        <br />
                        DIST_SEVER:
                        <asp:Label ID="DIST_SEVERLabel" runat="server" Text='<%# Bind("DIST_SEVER") %>' />
                        <br />
                        DENSITY_FROM:
                        <asp:Label ID="DENSITY_FROMLabel" runat="server" Text='<%# Bind("DENSITY_FROM") %>' />
                        <br />
                        DENSITY_TO:
                        <asp:Label ID="DENSITY_TOLabel" runat="server" Text='<%# Bind("DENSITY_TO") %>' />
                        <br />
                        MAINT_DEC_ID:
                        <asp:Label ID="MAINT_DEC_IDLabel" runat="server" Text='<%# Bind("MAINT_DEC_ID") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>--%>
                <asp:ObjectDataSource ID="odsMaintDeciding" runat="server" InsertMethod="Insert"
                    SelectMethod="GetAll" TypeName="JpmmsClasses.BL.Lookups.MaintDeciding" UpdateMethod="UpdateDecision"
                    OnUpdated="odsMaintDeciding_Updated">
                    <InsertParameters>
                        <asp:Parameter Name="DIST_CODE" Type="Int32" />
                        <asp:Parameter Name="DIST_SEVER" Type="Char" />
                        <asp:Parameter Name="low_dens_maint_dec" Type="Int32" />
                        <asp:Parameter Name="med_dens_maint_dec" Type="Int32" />
                        <asp:Parameter Name="high_dens_maint_dec" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        <asp:Parameter Name="MAINT_DEC_ID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:ObjectDataSource ID="odsMaintDecisions" runat="server" SelectMethod="GetAllDecisions"
                    TypeName="JpmmsClasses.BL.Lookups.MaintDecision" UpdateMethod="Update">
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
                <asp:ObjectDataSource ID="odsDistresses" runat="server" InsertMethod="Insert" SelectMethod="GetAllDistresses"
                    TypeName="JpmmsClasses.BL.Distress" UpdateMethod="Update">
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
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="RECORD_ID" DataSourceID="odsMaintDeciding" ForeColor="#333333"
                    GridLines="None" PageSize="9" EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                            Visible="False" />
                        <asp:BoundField DataField="distress_title" HeaderText="العيب" SortExpression="distress_title"
                            ReadOnly="True" />
                        <asp:BoundField DataField="DIST_SEVER" HeaderText="الشدة" SortExpression="DIST_SEVER"
                            ReadOnly="True" />
                        <asp:BoundField DataField="DENSITY_FROM" HeaderText="الكثافة من " SortExpression="DENSITY_FROM"
                            ReadOnly="True" />
                        <asp:BoundField DataField="DENSITY_TO" HeaderText="الكثافة إلى" SortExpression="DENSITY_TO"
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="قرار الصيانة" SortExpression="RECOMMENDED_DECISION">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList30" runat="server" AppendDataBoundItems="True"
                                    AutoPostBack="True" DataSourceID="odsMaintDecisions" DataTextField="decision_title"
                                    DataValueField="RECOMMENDED_DECISION_ID" SelectedValue='<%# Bind("MAINT_DEC_ID") %>'>
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("RECOMMENDED_DECISION") %>'></asp:Label>
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
                    <SortedDescendingHeaderStyle BackColor="#4870BE" /> --%>
                </asp:GridView>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
