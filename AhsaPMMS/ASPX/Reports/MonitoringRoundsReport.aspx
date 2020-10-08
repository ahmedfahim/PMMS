<%@ Page Title="تقارير الجولات الرقابية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MonitoringRoundsReport.aspx.cs" Inherits="ASPX_Reports_MonitoringRoundsReport" %>

<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
            <td>
                <h2 class="style2">
                    <strong>تقارير الجولات الرقابية</strong></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
                <br />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunicsHavingRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetAllDistrictsHavingRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSurveyedSubdistricts" runat="server" SelectMethod="GetAllSubdistrictsHavingRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="15%">
                <b>&nbsp; </b>
            </td>
            <td width="70%">
                &nbsp;
            </td>
            <td width="15%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByMainLanes" runat="server" Checked="True" GroupName="report"
                        Text="مسارات شارع محدد" AutoPostBack="True" OnCheckedChanged="radByMainLanes_CheckedChanged" />
                </b>
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByIntersections" runat="server" GroupName="report" Text="تقاطعات شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radByIntersections_CheckedChanged" />
                </b>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByRegionNo" runat="server" GroupName="report" Text="منطقة محددة"
                        AutoPostBack="True" OnCheckedChanged="radByRegionNo_CheckedChanged" />
                </b>
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByRegionName" runat="server" GroupName="report" Text="لحي فرعي محدد"
                        AutoPostBack="True" OnCheckedChanged="radByRegionName_CheckedChanged" />
                </b>
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegionNames" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSurveyedSubdistricts" DataTextField="SUBDISTRICT" DataValueField="SUBDISTRICT">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByRegionsAreaName" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radByRegionsAreaName_CheckedChanged" Text="أحياء فرعية محددة" />
                </b>
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlDistrict" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsDistricts" DataTextField="dist_name" DataValueField="dist_name">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByMunicName" runat="server" GroupName="report" Text="بلدية فرعية محددة"
                        AutoPostBack="True" OnCheckedChanged="radByMunicName_CheckedChanged" />
                </b>
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSubMunicipality" DataTextField="MUNIC_NAME" DataValueField="MUNIC_NAME">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
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
