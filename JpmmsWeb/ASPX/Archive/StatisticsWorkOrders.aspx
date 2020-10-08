<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="StatisticsWorkOrders.aspx.cs" Inherits="ASPX_Archive_StatisticsWorkOrders" %>

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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <h2 class="style2">
                            شوارع تحتاج صيانة</h2>
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
                                    <b>نوع الشارع&nbsp; </b>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioBtnStreetType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">المحاور</asp:ListItem>
                                        <asp:ListItem Value="1">الرئيسي</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الحالة&nbsp; </b>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioBtnStreetStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">الضعيف</asp:ListItem>
                                        <asp:ListItem Value="3">المقبول والضعيف</asp:ListItem>
                                        <asp:ListItem Value="5">الجيد والممتاز</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>التقرير </b>
                                </td>
                                <td>
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">احصائية</asp:ListItem>
                                        <asp:ListItem Value="2">الشوارع</asp:ListItem>
                                    </asp:CheckBoxList>
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
                                    <asp:Button ID="BtnShow" runat="server" OnClick="BtnShow_Click" Text="عرض" />
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
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvStatWorkOrder" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15"
                                        OnDataBound="gvStatWorkOrder_DataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="TOTAL" HeaderText="العدد" SortExpression="TOTAL" />
                                            <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية" SortExpression="MUNIC_NAME" />
                                            <asp:BoundField DataField="UDI_RATE" HeaderText="حالة الرصف" SortExpression="UDI_RATE" />
                                             <asp:BoundField DataField="totalArea" HeaderText="مساحة المقاطع" SortExpression="totalArea" />
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
                                    <asp:GridView ID="gvStatWorkOrderDetails" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None"
                                        PageSize="15" OnDataBound="gvStatWorkOrderDetails_DataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية" SortExpression="MUNIC_NAME" />
                                            <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                            <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                            <asp:BoundField DataField="UDI_RATE" HeaderText="حالة الرصف" SortExpression="UDI_RATE" />
                                            <asp:BoundField DataField="AREA" HeaderText="مساحة المقاطع" SortExpression="AREA" />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" SortExpression="SURVEY_NO" />
                                            <asp:BoundField DataField="STREETAREAIRI" HeaderText=" الشارع م2 IRI" SortExpression="STREETAREAIRI" />
                                            <asp:BoundField DataField="STREETAREASHAPE" HeaderText=" الشارع م2 كامل" SortExpression="STREETAREASHAPE" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
