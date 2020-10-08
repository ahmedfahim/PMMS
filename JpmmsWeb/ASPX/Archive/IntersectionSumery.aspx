<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IntersectionSumery.aspx.cs" Inherits="ASPX_Archive_IntersectionSumery" %>

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
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </h2>
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
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="gvRegionSamplesEqupment" runat="server" CellPadding="4" EnableModelValidation="True"
                                ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Notes" HeaderText="حالة التقاطعات" SortExpression="Notes" />
                                    <asp:BoundField DataField="AREA_sum" HeaderText="طول التقاطعات" SortExpression="AREA_sum" />
                                    <asp:BoundField DataField="TCOUNT" HeaderText="عدد التقاطعات" 
                                        SortExpression="TCOUNT" />
                                    <asp:CheckBoxField DataField="IS_READY" HeaderText="جاهز للمستخلص" SortExpression="IS_READY" />
                                    <asp:CheckBoxField DataField="IS_REVIEWREPORT" HeaderText="جاهز للتقرير" SortExpression="IS_REVIEWREPORT" />
                                    <asp:CheckBoxField DataField="IS_REVIEWDATAENTRY" HeaderText="تمت المراجعة" SortExpression="IS_REVIEWDATAENTRY" />
                                    <asp:CheckBoxField DataField="IS_REVIEWGIS" HeaderText="تحت الرسم" SortExpression="IS_REVIEWGIS" />
                                    <asp:CheckBoxField DataField="IS_DATAENTRYFINSH" HeaderText="تم الادخال" SortExpression="IS_DATAENTRYFINSH" />
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
