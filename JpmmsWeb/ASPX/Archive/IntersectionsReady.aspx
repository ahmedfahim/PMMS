<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IntersectionsReady.aspx.cs" Inherits="ASPX_Archive_IntersectionsReady" %>

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
                                ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" AutoGenerateColumns="False"
                                OnSelectedIndexChanging="gvRegionSamplesEqupment_SelectedIndexChanging" OnRowDeleting="gvRegionSamplesEqupment_RowDeleting">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField SelectText="تفاصيل" ShowSelectButton="True" />
                                    <asp:BoundField DataField="STREET_ID" HeaderText="رقم الشارع الفريد" ReadOnly="True"
                                        SortExpression="STREET_ID" />
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" ReadOnly="True" SortExpression="SURVEY_NO" />
                                    <asp:BoundField DataField="TOTALINTERSECTIONS" HeaderText="تقاطعات النظام" SortExpression="TOTALINTERSECTIONS" />
                                    <asp:BoundField DataField="DISTRESSINTERSECTIONS" HeaderText="تقاطعات العيوب" SortExpression="DISTRESSINTERSECTIONS" />
                                    <asp:BoundField DataField="DIFF_INTERSECTIONS_DISTRESS" HeaderText="الفرق" SortExpression="DIFF_INTERSECTIONS_DISTRESS" />
                                    <asp:BoundField DataField="TOTALLENGTH" HeaderText="طول التقاطعات" SortExpression="TOTALLENGTH" />
                                    <asp:BoundField DataField="arname" HeaderText="اسم الشارع" 
                                        SortExpression="arname" />
                                    <asp:CommandField DeleteText="اعتماد الشارع" ShowDeleteButton="True" />
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
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" ReadOnly="True" SortExpression="SURVEY_NO" />
                                    <asp:BoundField DataField="INTERSECTION_ID" HeaderText="رقم التقاطع الفريد" ReadOnly="True"
                                        SortExpression="INTERSECTION_ID" />
                                    <asp:BoundField DataField="INTER_NO" HeaderText="رقم التقاطع" SortExpression="INTER_NO" />
                                    <asp:BoundField DataField="INTEREC_STREET1" HeaderText="من" SortExpression="INTEREC_STREET1" />
                                    <asp:BoundField DataField="INTEREC_STREET2" HeaderText="إلي" SortExpression="INTEREC_STREET2" />
                                    <asp:BoundField DataField="INTER_LENGTH" HeaderText="طول التقاطع" ReadOnly="True"
                                        SortExpression="INTER_LENGTH" />
                                    <asp:BoundField DataField="INTER_DISTRESS" HeaderText="عيوب التقاطع" ReadOnly="True"
                                        SortExpression="INTER_DISTRESS" />
                                    <asp:CheckBoxField DataField="Recived" HeaderText="مستلم" 
                                        SortExpression="Recived" />
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
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
