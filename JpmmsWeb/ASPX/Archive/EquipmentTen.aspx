<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EquipmentTen.aspx.cs" Inherits="ASPX_Archive_EquipmentTen" %>

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
                            تكرار&nbsp; الحارات مع معدة رصف الطريق &nbsp;IRI</h2>
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
                                    <table align="center" class="style3">
                                        <tr>
                                            <td>
                                                <b>الشارع الرئيسي </b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged" DataSourceID="odsRegions"
                                                    DataTextField="MAIN_NO" DataValueField="STREET_ID">
                                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblFeedback1" runat="server" ForeColor="Red"></asp:Label>
                                                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetStreetsIRI"
                                                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <b>
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                     <%--   <asp:ListItem Value="3" Enabled="False">المسح الثالث</asp:ListItem>
                                                        <asp:ListItem Value="4" Enabled="False">المسح الرابع</asp:ListItem>
                                                        <asp:ListItem Value="5" Enabled="False">المسح الخامس</asp:ListItem>--%>
                                                    </asp:RadioButtonList>
                                                </b>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <b>
                                                    <asp:RadioButtonList ID="RadioBtnListSYS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioBtnListSYS_SelectedIndexChanged"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="2" Selected="True">في النظام</asp:ListItem>
                                                        <asp:ListItem Value="1">في المعدة</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </b>
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
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvERorrLanes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="Main_no" HeaderText="رقم الشارع" />
                                            <asp:BoundField DataField="TOTAL" HeaderText="عدد التكرار" />
                                            <asp:BoundField DataField="SECTION_ID" HeaderText="رقم المقطع الفريد" SortExpression="SECTION_ID" />
                                            <asp:BoundField DataField="LANE_TYPE" HeaderText="نوع الحارة" SortExpression="LANE_TYPE" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                    <asp:GridView ID="gvERorrLanesIRI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="TOTAL" HeaderText="عدد التكرار" />
                                            <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO" />
                                            <asp:BoundField DataField="LANE_TYPE" HeaderText="نوع الحارة" SortExpression="LANE_TYPE" />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" />
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
