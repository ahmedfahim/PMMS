<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="DistressManuale.aspx.cs" Inherits="ASPX_Archive_DistressManuale" %>

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
                            عيوب تحتاج حذف</h2>
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
                        &nbsp;</td>
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
                                    <asp:GridView ID="gvRegionSamplesIRI" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True"
                                        PageSize="15" 
                                        AllowSorting="True" DataSourceID="ObjectDataSource1">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="رقم الشارع" DataField="STREETNO" />
                                            <asp:BoundField DataField="SECTION" HeaderText="رقم المقطع"  />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة"  />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        SelectMethod="GetDistressManuale" TypeName="JpmmsClasses.BL.MainStreet">
                                    </asp:ObjectDataSource>
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

