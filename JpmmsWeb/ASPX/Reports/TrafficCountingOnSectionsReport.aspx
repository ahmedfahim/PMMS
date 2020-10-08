<%@ Page Title="تقرير نتائج العد المروري على الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="TrafficCountingOnSectionsReport.aspx.cs" Inherits="ASPX_Reports_TrafficCountingOnSectionsReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--   <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
        .RadPicker_Default
        {
            vertical-align: middle;
        }
        .RadPicker_Default .RadInput
        {
            vertical-align: baseline;
        }
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <h2 class="style2">
                    <strong>تقرير نتائج العد المروري على الطرق الرئيسية</strong></h2>
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
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="LoadMainStreetHavingTrafficCounting"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="20%">
                <b>
                    <asp:RadioButton ID="radMainSt" runat="server" Checked="True" GroupName="type" OnCheckedChanged="radMainSt_CheckedChanged"
                        Text="على الطريق الرئيسي " AutoPostBack="True" />
                </b>
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" DataSourceID="odsMainStreets"
                    DataTextField="main_title" DataValueField="STREET_ID">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radSectionsSurroundingRegion" runat="server" Text="المقاطع المحيطة للمنطقة"
                        OnCheckedChanged="radSectionsSurroundingRegion_CheckedChanged" GroupName="type"
                        AutoPostBack="True" />
                </b>
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                    Enabled="False">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="chkDates" runat="server" OnCheckedChanged="chkDates_CheckedChanged"
                        Text="خلال فترة محددة" GroupName="type" AutoPostBack="True" />
                </b>
            </td>
            <td>
                من
                <telerik:RadDatePicker ID="raddtpFrom" runat="server" Enabled="False">
                    <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                        ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;إلى
                <telerik:RadDatePicker ID="raddtpTo" runat="server" Enabled="False">
                    <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                        ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radAll" runat="server" Text="جميع الطرق الرئيسية" OnCheckedChanged="radAll_CheckedChanged"
                        GroupName="type" AutoPostBack="True" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
