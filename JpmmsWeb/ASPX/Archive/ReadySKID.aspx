<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReadySKID.aspx.cs" Inherits="ASPX_Archive_ReadySKID" %>

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
            text-align: right;
        }
        .bold
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    &nbsp;معالجة مقاومة الإنزلاق المسح الجديد&nbsp; SKID</h2>
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
                <table align="center" class="style3">
                    <tr>
                        <td>
                            <b>الشارع الرئيسي </b>
                        </td>
                        <td>
                            <%--   <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" 
                                AutoPostBack="True" DataSourceID="odsRegions" DataTextField="MAIN_NO" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>--%>
                            <telerik:RadComboBox Filter="Contains" Width="75px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="MAIN_NO" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;<asp:Label ID="lblFeedback1" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;<asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="ReadySKID"
                                TypeName="JpmmsClasses.BL.MainStreet">
                                <SelectParameters>
                                    <asp:Parameter Name="MAIN_NO" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblFeedback0" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetStreetsInfo"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="STREET_ID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvRegionSections" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="COUNTSECTION" HeaderText="العدد المقاطع" SortExpression="COUNTSECTION" />
                                    <asp:BoundField DataField="COUNTLANE" HeaderText="عدد الحارات" SortExpression="COUNTLANE" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:GridView ID="gvRegionIRI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="COUNTSECTION" HeaderText="العدد المقاطع" SortExpression="COUNTSECTION" />
                                    <asp:BoundField DataField="COUNTLANE" HeaderText="عدد الحارات" SortExpression="COUNTLANE" />
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
                            <asp:GridView ID="gvRegionSamplesSECTION" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True"
                                PageSize="15" OnRowCreated="gvRegionSamplesSECTION_RowCreated" AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" />
                                    <asp:BoundField DataField="LANE" HeaderText="نوع الحارة" />
                                    <asp:BoundField DataField="LEN" HeaderText="الطول" />
                                    <asp:BoundField HeaderText="ملاحظات" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:GridView ID="gvRegionSamplesIRI" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True"
                                PageSize="15" OnRowCreated="gvRegionSamplesIRI_RowCreated" AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" />
                                    <asp:BoundField DataField="LANE" HeaderText="نوع الحارة" />
                                    <asp:BoundField HeaderText="الطول" />
                                    <asp:BoundField HeaderText="ملاحظات" />
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
            </td>
        </tr>
        <tr>
            <td colspan="3">
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
    </table>
</asp:Content>
