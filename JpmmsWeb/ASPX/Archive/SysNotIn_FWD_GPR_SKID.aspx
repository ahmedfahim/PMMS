<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SysNotIn_FWD_GPR_SKID.aspx.cs" Inherits="ASPX_Archive_SysNotIn_FWD_GPR_SKID" %>

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
                    مقاطع بالنظام وغير موجودة بالمعدة &nbsp;
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
                                        OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged"
                                        DataTextField="MAIN_NO" DataValueField="MAIN_NO">
                                        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblFeedback1" runat="server" ForeColor="Red"></asp:Label>
                                  
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
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
                                    &nbsp;
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
</asp:Content>
