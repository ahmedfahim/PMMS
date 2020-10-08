<%@ Page Title="إصدار رخصة حفريات مرافق عامة على مقطع" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DrillingPermitsIssue.aspx.cs" Inherits="ASPX_Sections_DrillingPermitsIssue" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <b>إصدار رخصة حفريات مرافق عامة على مقطع</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table align="center" class="style3">
                    <tr>
                        <td>
                            الشارع الرئيسي
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="street_id"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            المقاطع
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreetIntersections" DataTextField="section_from_to"
                                DataValueField="section_id" OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">إلغاء</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsMainStreetIntersections" runat="server" SelectMethod="GetMainStreetSections"
                                TypeName="JpmmsClasses.BL.MainStreetSection">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
                <asp:Label ID="lblPermits" runat="server" Font-Size="22pt"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
