<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="CompletedASSETES.aspx.cs" Inherits="ASPX_Archive_CompletedASSETES" %>

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
                    المستخلصات للإصول</h2>
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
               <asp:Label ID="lblFeedbackTotal" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="المستخلص رقم"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="ObjectDataSource1" DataTextField="CLEARANCE_ASSETS" DataValueField="CLEARANCE_ASSETS"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="-1">اختر</asp:ListItem>
                    <asp:ListItem Value="ALL">الكل</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="CompareASSETS"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:Parameter Name="CLEARANCE" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvASSETES" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" AllowSorting="true"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" 
                                PageSize="15" onsorting="gvASSETES_Sorting">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" SortExpression="SURVEY_NO" />
                                    <asp:BoundField DataField="CLEARANCE_ASSETS" HeaderText="مستخلص النظام" SortExpression="CLEARANCE_ASSETS" />
                                    <asp:BoundField DataField="SURVEY_MONTH" HeaderText="مستخلص الأصول" SortExpression="SURVEY_MONTH" />
                                     <asp:CheckBoxField DataField="IS_ASSETS" HeaderText="خالص" SortExpression="IS_ASSETS" />
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
