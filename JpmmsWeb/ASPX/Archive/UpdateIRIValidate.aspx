<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="UpdateIRIValidate.aspx.cs" Inherits="ASPX_Archive_UpdateIRIValidate" %>

<%@ Register Assembly="UtilitiesLibrary" Namespace="UtilitiesLibrary.Controls" TagPrefix="cc1" %>
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
                    المقاطع تم تغيرها بحاله الوعورة
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
                <table>
                    <tr>
                        <td>
                            <cc1:OneClickButton ID="BtnIRI" runat="server" OnClick="BtnIRI_Click" Text="تصحيح التغيير"
                                ReplaceTitleTo="يرجى الإنتظار" />
                            <cc1:OneClickButton ID="BtnSHAPE" runat="server" OnClick="Button1_Click" Text="تأكيد التغيير"
                                ReplaceTitleTo="يرجى الإنتظار" />
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                           
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvERorrIRI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" 
                                PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع " SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع " SortExpression="SECTION_NO" />
                                    <asp:BoundField DataField="SECTION_ID" HeaderText="رقم المقطع الفريد" SortExpression="SECTION_ID" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسحة" SortExpression="SURVEY_NO" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                             <asp:GridView ID="gvERorrDistress" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" 
                                PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع " SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع " SortExpression="SECTION_NO" />
                                    <asp:BoundField DataField="SECTION_ID" HeaderText="رقم المقطع الفريد" SortExpression="SECTION_ID" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسحة" SortExpression="SURVEY_NO" />
                                </Columns>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            </asp:GridView>
                           <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ValidateUpdateIRI"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>--%>
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
