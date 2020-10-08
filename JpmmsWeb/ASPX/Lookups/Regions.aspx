<%@ Page Title="المناطق الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Regions.aspx.cs" Inherits="ASPX_Lookups_Regions" %>

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
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .style3
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
                    <b>المناطق الفرعية</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;<asp:ObjectDataSource ID="odsRegionsInfo" runat="server" SelectMethod="GetRegionsFullInfo"
                    TypeName="JpmmsClasses.BL.Region" OnUpdated="odsRegionsInfo_Updated" UpdateMethod="UpdateRegion">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridView1" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="REGION_NO" Type="String" />
                        <asp:Parameter Name="SUBDISTRICT_ID" Type="Int32" />
                        <asp:Parameter Name="REGION_ID" Type="Int32" />
                        <asp:Parameter Name="SURVEYABLE" Type="Boolean" />
                        <asp:Parameter Name="NOTES" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetRegionsFullInfo"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubdists" runat="server" SelectMethod="GetAllSubdistricts"
                    TypeName="JpmmsClasses.BL.Lookups.DistrictSubdistrict"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="REGION_ID" DataSourceID="odsRegionsInfo"
                    EnableModelValidation="True" DefaultMode="Edit" Visible="False">
                    <EditItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <b>رقم المنطقة</b>
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="RadMaskedTextBox1" runat="server" Mask="######" Text='<%# Bind("REGION_NO") %>'
                                        Width="65px">
                                    </telerik:RadMaskedTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>تتبع للحي الفرعي</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsSubdists" DataTextField="ARNAME"
                                        DataValueField="ID1" SelectedValue='<%# Bind("SUBDISTRICT_ID") %>' AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("SURVEYABLE").ToString()=="1" %>'
                                        Text="المنطقة قابلة للمسح؟" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>ملاحظات</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Text='<%# Bind("NOTES") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                        CssClass="style3" Text="حفظ" />
                                </td>
                                <td style="margin-right: 80px">
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="إلغاء" OnClick="UpdateCancelButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        REGION_ID:
                        <asp:TextBox ID="REGION_IDTextBox" runat="server" Text='<%# Bind("REGION_ID") %>' />
                        <br />
                        REGION_NO:
                        <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                        <br />
                        SUBDISTRICT:
                        <asp:TextBox ID="SUBDISTRICTTextBox" runat="server" Text='<%# Bind("SUBDISTRICT") %>' />
                        <br />
                        DIST_NAME:
                        <asp:TextBox ID="DIST_NAMETextBox" runat="server" Text='<%# Bind("DIST_NAME") %>' />
                        <br />
                        DIST_NO:
                        <asp:TextBox ID="DIST_NOTextBox" runat="server" Text='<%# Bind("DIST_NO") %>' />
                        <br />
                        SUBMUNICIP:
                        <asp:TextBox ID="SUBMUNICIPTextBox" runat="server" Text='<%# Bind("SUBMUNICIP") %>' />
                        <br />
                        SUBDISTRIC:
                        <asp:TextBox ID="SUBDISTRICTextBox" runat="server" Text='<%# Bind("SUBDISTRIC") %>' />
                        <br />
                        ARNAME:
                        <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                        <br />
                        ENNAME:
                        <asp:TextBox ID="ENNAMETextBox" runat="server" Text='<%# Bind("ENNAME") %>' />
                        <br />
                        DISTRICTNO:
                        <asp:TextBox ID="DISTRICTNOTextBox" runat="server" Text='<%# Bind("DISTRICTNO") %>' />
                        <br />
                        DISTRICT_ID:
                        <asp:TextBox ID="DISTRICT_IDTextBox" runat="server" Text='<%# Bind("DISTRICT_ID") %>' />
                        <br />
                        SUBDISTRICT_ID:
                        <asp:TextBox ID="SUBDISTRICT_IDTextBox" runat="server" Text='<%# Bind("SUBDISTRICT_ID") %>' />
                        <br />
                        MUNIC_NAME:
                        <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        REGION_ID:
                        <asp:Label ID="REGION_IDLabel" runat="server" Text='<%# Eval("REGION_ID") %>' />
                        <br />
                        REGION_NO:
                        <asp:Label ID="REGION_NOLabel" runat="server" Text='<%# Bind("REGION_NO") %>' />
                        <br />
                        SUBDISTRICT:
                        <asp:Label ID="SUBDISTRICTLabel" runat="server" Text='<%# Bind("SUBDISTRICT") %>' />
                        <br />
                        DIST_NAME:
                        <asp:Label ID="DIST_NAMELabel" runat="server" Text='<%# Bind("DIST_NAME") %>' />
                        <br />
                        DIST_NO:
                        <asp:Label ID="DIST_NOLabel" runat="server" Text='<%# Bind("DIST_NO") %>' />
                        <br />
                        SUBMUNICIP:
                        <asp:Label ID="SUBMUNICIPLabel" runat="server" Text='<%# Bind("SUBMUNICIP") %>' />
                        <br />
                        SUBDISTRIC:
                        <asp:Label ID="SUBDISTRICLabel" runat="server" Text='<%# Bind("SUBDISTRIC") %>' />
                        <br />
                        ARNAME:
                        <asp:Label ID="ARNAMELabel" runat="server" Text='<%# Bind("ARNAME") %>' />
                        <br />
                        ENNAME:
                        <asp:Label ID="ENNAMELabel" runat="server" Text='<%# Bind("ENNAME") %>' />
                        <br />
                        DISTRICTNO:
                        <asp:Label ID="DISTRICTNOLabel" runat="server" Text='<%# Bind("DISTRICTNO") %>' />
                        <br />
                        DISTRICT_ID:
                        <asp:Label ID="DISTRICT_IDLabel" runat="server" Text='<%# Bind("DISTRICT_ID") %>' />
                        <br />
                        SUBDISTRICT_ID:
                        <asp:Label ID="SUBDISTRICT_IDLabel" runat="server" Text='<%# Bind("SUBDISTRICT_ID") %>' />
                        <br />
                        MUNIC_NAME:
                        <asp:Label ID="MUNIC_NAMELabel" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="REGION_ID"
                    DataSourceID="odsRegions" EnableModelValidation="True" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="REGION_ID" HeaderText="REGION_ID" ReadOnly="True" SortExpression="REGION_ID"
                            Visible="False" />
                        <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="SUBDISTRICT" HeaderText="اسم المنطقة" SortExpression="SUBDISTRICT" />
                        <asp:BoundField DataField="ENNAME" HeaderText="الاسم الانجليزي للمنطقة" SortExpression="ENNAME" />
                        <asp:BoundField DataField="SUBDISTRIC" HeaderText="رقم الحي الفرعي" SortExpression="SUBDISTRIC" />
                        <asp:BoundField DataField="DIST_NO" HeaderText="رقم الحي" SortExpression="DIST_NO"
                            Visible="False" />
                        <asp:BoundField DataField="DIST_NAME" HeaderText="الحي" SortExpression="DIST_NAME" />
                        <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية" SortExpression="MUNIC_NAME" />
                        <asp:BoundField DataField="SURVEYABLE_text" HeaderText="حالة المنطقة" ReadOnly="True" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                        <asp:CommandField SelectText="تعديل" ShowSelectButton="True" />
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
