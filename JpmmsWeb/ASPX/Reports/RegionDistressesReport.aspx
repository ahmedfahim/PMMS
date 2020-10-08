<%@ Page Title="تقرير عيوب مناطق الشوارع الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="RegionDistressesReport.aspx.cs" Inherits="ASPX_Reports_RegionDistressesReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
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
        .style3
        {
            height: 24px;
        }
        .RadPicker_Default
        {
            vertical-align: middle;
        }
        .RadPicker_Default table.rcTable .rcInputCell
        {
            padding: 0 4px 0 0;
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
        .style4
        {
            width: 171px;
        }
        .style5
        {
            font-weight: bold;
        }
        .style6
        {
            height: 24px;
            font-weight: bold;
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
                    <strong>تقرير عيوب مناطق الشوارع الفرعية</strong></h2>
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
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table class="style1">
                    <tr>
                        <td colspan="3">
                            <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetAvailableRegionSurveys"
                                TypeName="JpmmsClasses.BL.DistressSurvey">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="radAllRegionsDistressArea" Name="isTotal" PropertyName="Checked"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="radByRegionAreaTotal" Name="forDistresses" PropertyName="Checked"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="radByDate" Name="inDates" PropertyName="Checked"
                                        Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                                TypeName="JpmmsClasses.BL.SecondaryStreets">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistresses"
                                TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetMunicipalityHavingCalculatedUdi"
                                TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetSurveyedSecondaryStreetRegion"
                                TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radbyRegion" runat="server" AutoPostBack="True" Checked="True"
                                    GroupName="report" OnCheckedChanged="radbyRegion_CheckedChanged" Text="لمنطقة أو شارع فرعي محدد" />
                        </td>
                        <td class="style4">
                            <b>
                                <asp:RadioButton ID="radByMuncipality" runat="server" AutoPostBack="True" GroupName="report"
                                    Text="لبلدية فرعية محدة" OnCheckedChanged="radByMuncipality_CheckedChanged" />
                            </b>
                        </td>
                        <td>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b>
                                <asp:RadioButton ID="radByRegionDistressAreaTotal" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radByRegionDistressAreaTotal_CheckedChanged"
                                    Text="المساحة الرمز العيوب لحي فرعي محدد" />
                            </b>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radByRegionDistressArea" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radByRegionDistressArea_CheckedChanged"
                                    Text="مساحة العيوب لحي فرعي محدد" />
                        </td>
                        <td class="style4">
                            <b>
                                <asp:RadioButton ID="radByRegionAreaTotal" runat="server" AutoPostBack="True" GroupName="report"
                                    OnCheckedChanged="radByRegionAreaTotal_CheckedChanged" Text="المساحة - العيوب (مجموع)" />
                        </td>
                        <td>
                            <b>
                                <asp:RadioButton ID="radByRegionDistressAreaSeverity" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radByRegionDistressAreaSeverity_CheckedChanged"
                                    Text="المساحة الرمز العيوب الشدة لحي فرعي محدد" />
                            </b></b>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3" colspan="2">
                            <b>
                                <asp:RadioButton ID="radAllRegionsDistressArea" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radAllRegionsDistressArea_CheckedChanged"
                                    Text="مساحة العيوب لجميع الأحياء الفرعية الممسوحة" />
                        </td>
                        <td class="style6">
                            <asp:RadioButton ID="radByRegionDistressAreaSeverityTotal" runat="server" AutoPostBack="True"
                                GroupName="report" OnCheckedChanged="radByRegionDistressAreaSeverityTotal_CheckedChanged"
                                Text="المساحة الرمز العيوب الشدة لحي فرعي محدد (مجموع)" />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b>&nbsp;
                        </td>
                        <td>
                            &nbsp;</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radByDate" runat="server" AutoPostBack="True" GroupName="report"
                                    OnCheckedChanged="radByDate_CheckedChanged" Text="خلال فترة محددة" />
                            </b>
                        </td>
                        <td class="style4">
                            <b>من</b><telerik:RadDatePicker ID="raddtpFrom" runat="server" Enabled="False">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <b>إلى </b>
                            <telerik:RadDatePicker ID="raddtpTo" runat="server" Enabled="False">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            المنطقة و الشارع الفرعي
                        </td>
                        <td class="style4">
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlRegionSecondaryStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" DataValueField="STREET_ID">
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
                        <td class="style5">
                            البلدية الفرعية
                        </td>
                        <td class="style4">
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsSubMunicipality" DataTextField="munic_name" DataValueField="munic_name"
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
                        <td class="style5">
                            رمز العيب
                        </td>
                        <td class="style4">
                            <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                DataTextField="distress_title" DataValueField="dist_code" Enabled="False" OnSelectedIndexChanged="ddlDistresses_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                <asp:ListItem Value="-1">الترقيعات وعيوبها</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="style5">
                            رقم المسح
                        </td>
                        <td class="style4">
                            <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsSampleSurveys"
                                DataTextField="survey_title" DataValueField="survey_no">
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnlDists" runat="server" Visible="False">
                                <asp:RadioButton ID="radAllDistress" runat="server" Checked="True" GroupName="type"
                                    Text="كل العيوب" />
                                <br />
                                <asp:RadioButton ID="radPatchDistsOnly" runat="server" GroupName="type" Text="عيوب الترقيعات" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
                        </td>
                        <td class="style4">
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
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
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
