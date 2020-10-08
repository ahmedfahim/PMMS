<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="DeleteInterSections.aspx.cs" Inherits="ASPX_Archive_DeleteInterSections" %>

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
                    حذف التقاطع</h2>
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
                                DataValueField="MAIN_NO" 
                                onselectedindexchanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                                <asp:ListItem Value="0">الكل</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;<asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetStreets"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                                &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        <b>    التقاطع الرئيسي </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSections" runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                                onselectedindexchanged="ddlSections_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                                <asp:Button ID="BtnEND" runat="server" ForeColor="Red" onclick="BtnEND_Click" 
                                    Text="حذف" />
                                <asp:Button ID="BtnYes" runat="server" onclick="BtnYes_Click" Text="نعم" 
                                    Visible="False" />
                                <asp:Button ID="BtnNO" runat="server" onclick="BtnNO_Click" Text="لا" 
                                    Visible="False" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                                &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnDelete" runat="server" ForeColor="Red" onclick="BtnDelted_Click" 
                                    Text="حذف المتكرر من الخارج" />
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


