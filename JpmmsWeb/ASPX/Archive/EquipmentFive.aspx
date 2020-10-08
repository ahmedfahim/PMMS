<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="EquipmentFive.aspx.cs" Inherits="ASPX_Archive_EquipmentFive" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
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
                    الحمل الساقط مقاطع&nbsp; FWD</h2>
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
                            <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="MAIN_NO" 
                                DataValueField="STREET_ID" 
                                onselectedindexchanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetStreetsFWD"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                                    <b>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        RepeatDirection="Horizontal" AutoPostBack="True" Enabled="false" 
                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                            <asp:ListItem Value="3" >المسح الثالث</asp:ListItem>
                                            <asp:ListItem Value="4" >المسح الحالي</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </b>
                        </td>
                        <td>
                            &nbsp;</td>
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
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table >
                    <tr>
                        <td>
                <asp:GridView ID="gvRegionSections" runat="server"
                    AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333"
                    GridLines="None" EnableModelValidation="True"
                    PageSize="15">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns> 
                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع"  SortExpression="ARNAME" />
                        <asp:BoundField DataField="COUNTSECTION" HeaderText="العدد المقاطع" 
                            SortExpression="COUNTSECTION" />
                        <asp:BoundField DataField="COUNTLANE" HeaderText="عدد الحارات" 
                            SortExpression="COUNTLANE" />
                       
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
                <asp:GridView ID="gvRegionIRI" runat="server"
                    AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333"
                    GridLines="None" EnableModelValidation="True"
                    PageSize="15">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns> 
                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع"  SortExpression="ARNAME" />
                        <asp:BoundField DataField="COUNTSECTION" HeaderText="العدد المقاطع" 
                            SortExpression="COUNTSECTION" />
                        <asp:BoundField DataField="COUNTLANE" HeaderText="عدد الحارات" 
                            SortExpression="COUNTLANE" />
                       
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
                <asp:GridView ID="gvRegionSamplesSECTION" runat="server"
                    AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333"
                    GridLines="None" EnableModelValidation="True"
                    PageSize="15" onrowcreated="gvRegionSamplesSECTION_RowCreated" AllowSorting="True" 
                                onsorting="gvRegionSamplesSECTION_Sorting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SN" HeaderText="م" SortExpression="SN" />
                        <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" 
                            SortExpression="SECTION_NO" />
                        <asp:BoundField DataField="TCountLane" HeaderText="عدد الحارات" 
                            SortExpression="TCountLane" />
                        <asp:BoundField DataField="LTYPE" HeaderText="نوع الحارة" 
                            SortExpression="LTYPE" />
                        <asp:BoundField DataField="SECTION_ID" HeaderText="الرقم الفريد" 
                            SortExpression="SECTION_ID" Visible="False" />
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
                <asp:GridView ID="gvRegionSamplesIRI" runat="server"
                    AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333"
                    GridLines="None" EnableModelValidation="True"
                    PageSize="15" onrowcreated="gvRegionSamplesIRI_RowCreated" AllowSorting="True" 
                                onsorting="gvRegionSamplesIRI_Sorting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" 
                            SortExpression="SECTION_NO" />
                        <asp:BoundField DataField="TCountIRI" HeaderText="عدد الحارات" 
                            SortExpression="TCountIRI" />
                        <asp:BoundField DataField="LTYPE" HeaderText="نوع الحارة" 
                            SortExpression="LTYPE" />
                        <asp:BoundField DataField="SECTION_ID" HeaderText="الرقم الفريد" 
                            SortExpression="SECTION_ID" Visible="False" />
                        <asp:BoundField DataField="TCountLane" HeaderText="مراجعة الحارات" 
                            ReadOnly="True" SortExpression="TCountLane" />
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
                &nbsp;</td>
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

