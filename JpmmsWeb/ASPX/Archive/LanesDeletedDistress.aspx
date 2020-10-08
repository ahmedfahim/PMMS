<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="LanesDeletedDistress.aspx.cs" Inherits="ASPX_Archive_LanesDeletedDistress" %>

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
                            حارات غير موجودة بمعده الوعورة وغير موجودة بالنظام لمعدة&nbsp; &nbsp;
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
                        <table align="center" class="style3">
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
                                                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged" DataTextField="MAIN_NO"
                                                    DataValueField="MAIN_NO">
                                                    <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                                                    <asp:ListItem Value="0">الكل</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblFeedback1" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:GridView ID="gvRegionSamplesEqupment" runat="server" CellPadding="4" EnableModelValidation="True"
                                        ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" AutoGenerateColumns="False"
                                        DataKeyNames="MAIN_NO">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                                            <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" ReadOnly="True" SortExpression="SECTION_NO" />
                                            <asp:BoundField DataField="LANE" HeaderText="الحارة" SortExpression="LANE" />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="المسح" SortExpression="SURVEY_NO" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
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
