<%@ Page Title="الأحياء الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SubDistrict.aspx.cs" Inherits="ASPX_Lookups_SubDistrict" %>

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
        .style3
        {
            font-weight: bold;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        
        .style5
        {
            font-weight: bold;
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
                    <b>الأحياء الفرعية</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID1" DataSourceID="odsSubdistEdit"
                    DefaultMode="Edit" EnableModelValidation="True">
                    <EditItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <b>الاسم العربي</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <b>الاسم الانجليزي</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="ENNAMETextBox" runat="server" Text='<%# Bind("ENNAME") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>رقم الحي الفرعي</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxtSUBDISTRIC" runat="server" CssClass="style5"
                                        Culture="ar-QA" DataType="System.Int16" DbValue='<%# Bind("SUBDISTRIC") %>' MaxValue="100"
                                        MinValue="0" Width="40px">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <b>يتبع للحي</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistricts"
                                        DataTextField="ARNAME" DataValueField="DIST_ID" SelectedValue='<%# Bind("DISTRICTNO") %>'>
                                        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                        CssClass="style3" Text="حفظ" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        OnClick="UpdateCancelButton_Click" Text="إلغاء" />
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        ARNAME:
                        <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                        <br />
                        ENNAME:
                        <asp:TextBox ID="ENNAMETextBox" runat="server" Text='<%# Bind("ENNAME") %>' />
                        <br />
                        ID1:
                        <asp:TextBox ID="ID1TextBox" runat="server" Text='<%# Bind("ID1") %>' />
                        <br />
                        DISTRICTNO:
                        <asp:TextBox ID="DISTRICTNOTextBox" runat="server" Text='<%# Bind("DISTRICTNO") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        ARNAME:
                        <asp:Label ID="ARNAMELabel" runat="server" Text='<%# Bind("ARNAME") %>' />
                        <br />
                        ENNAME:
                        <asp:Label ID="ENNAMELabel" runat="server" Text='<%# Bind("ENNAME") %>' />
                        <br />
                        ID1:
                        <asp:Label ID="ID1Label" runat="server" Text='<%# Eval("ID1") %>' />
                        <br />
                        DISTRICTNO:
                        <asp:Label ID="DISTRICTNOLabel" runat="server" Text='<%# Bind("DISTRICTNO") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID1"
                    DataSourceID="odsSubdist" EnableModelValidation="True" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ARNAME" HeaderText="الاسم العربي" SortExpression="ARNAME" />
                        <asp:BoundField DataField="ENNAME" HeaderText="الاسم الانجليزي" SortExpression="ENNAME" />
                        <asp:BoundField DataField="DISTRICTNO" HeaderText="DISTRICTNO" SortExpression="DISTRICTNO"
                            Visible="False" />
                        <asp:BoundField DataField="SUBDISTRIC" HeaderText="رقم الحي الفرعي" SortExpression="SUBDISTRIC" />
                        <asp:BoundField DataField="ID1" HeaderText="ID1" ReadOnly="True" SortExpression="ID1"
                            Visible="False" />
                        <asp:CommandField SelectText="تعديل" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetAllDistricts"
                    TypeName="JpmmsClasses.BL.Lookups.DistrictSubdistrict"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubdistEdit" runat="server" SelectMethod="GetSubDistFullInfo"
                    TypeName="JpmmsClasses.BL.Lookups.DistrictSubdistrict" UpdateMethod="UpdateSubdistrict"
                    OnUpdated="odsSubdistEdit_Updated">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridView1" Name="subDistID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ARNAME" Type="String" />
                        <asp:Parameter Name="ENNAME" Type="String" />
                        <asp:Parameter Name="DISTRICTNO" Type="Int32" />
                        <asp:Parameter Name="SUBDISTRIC" Type="Int32" />
                        <asp:Parameter Name="ID1" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubdist" runat="server" SelectMethod="GetAllSubdistricts"
                    TypeName="JpmmsClasses.BL.Lookups.DistrictSubdistrict"></asp:ObjectDataSource>
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
