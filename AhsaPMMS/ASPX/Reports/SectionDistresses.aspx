<%@ Page Title="تقرير عيوب مقاطع شبكة الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SectionDistresses.aspx.cs" Inherits="ASPX_Reports_SectionDistresses" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
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
            width: 80%;
        }
        .style2
        {
            text-align: center;
        }
        .style4
        {
            width: 171px;
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
                    <strong>تقرير عيوب مقاطع شبكة الطرق الرئيسية</strong></h2>
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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table class="style1">
                    <tr>
                        <td colspan="3">
                            <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetMainStreetSectionAvailableSurveys"
                                TypeName="JpmmsClasses.BL.DistressSurvey">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="LoadSurveyedSections"
                                TypeName="JpmmsClasses.BL.MainStreetSection">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistresses"
                                TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegionSectionSurveys" runat="server" SelectMethod="GetRegionSurroundingSectionsAvailableSurveys"
                                TypeName="JpmmsClasses.BL.DistressSurvey">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                                TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetRegionsHavingCalculatedUdi"
                                TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:RadioButton ID="radBySection" runat="server" AutoPostBack="True" Checked="True"
                                    GroupName="report" OnCheckedChanged="radBySection_CheckedChanged" Text="لمقطع محدد" />
                            </strong>
                        </td>
                        <td colspan="2">
                            <strong>
                                <asp:RadioButton ID="radbyMainStreet" runat="server" AutoPostBack="True" GroupName="report"
                                    OnCheckedChanged="radbyMainStreet_CheckedChanged" Text="مقاطع شارع رئيسي محدد" />
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>
                                <asp:RadioButton ID="radByStreetDistressAreaTotal" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radByStreetDistressAreaTotal_CheckedChanged"
                                    Text="مساحة العيوب لشارع محدد (مجموع)" />
                            </strong>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>
                                <asp:RadioButton ID="radByStreetDistressArea" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radByStreetDistressArea_CheckedChanged"
                                    Text="مساحة العيوب لشارع محدد" Visible="False" />
                            </strong>
                        </td>
                        <td>
                            <strong>
                                <asp:RadioButton ID="radByStreetAreaTotal" runat="server" AutoPostBack="True" GroupName="report"
                                    OnCheckedChanged="radByStreetAreaTotal_CheckedChanged" Text="المساحة - العيوب (مجموع)" />
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radByDate" runat="server" AutoPostBack="True" GroupName="report"
                                OnCheckedChanged="radByDate_CheckedChanged" Text="خلال فترة محددة" Style="font-weight: 700" />
                        </td>
                        <td class="style4">
                            من<telerik:RadDatePicker ID="raddtpFrom" runat="server" Enabled="False">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            إلى
                            <telerik:RadDatePicker ID="raddtpTo" runat="server" Enabled="False">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>الشارع الرئيسي </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged" Enabled="False">
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
                            <b>المقطع </b>
                        </td>
                        <td colspan="2">
                            <telerik:RadComboBox Filter="Contains" Width="500px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged" Enabled="False">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            رمز العيب
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                DataTextField="distress_title" DataValueField="dist_code" Enabled="False" OnSelectedIndexChanged="ddlDistresses_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <b>&nbsp; </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radSectionsSurroundingRegion" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radSectionsSurroundingRegion_CheckedChanged"
                                    Text="المقاطع المحيطة بالمنطقة " />
                            </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <%-- <tr>
                        <td>
                            <b>رقم المسح </b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsSampleSurveys"
                                DataTextField="survey_title" DataValueField="survey_no" OnDataBound="radlOldSurveys_DataBound">
                            </asp:RadioButtonList>
                            <asp:RadioButtonList ID="radlRegionSectionsSurveys" runat="server" DataSourceID="odsRegionSectionSurveys"
                                DataTextField="survey_title" DataValueField="survey_no" Style="text-align: right">
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radMunicSections" runat="server" AutoPostBack="True" Text="مقاطع طرق رئيسية ضمن بلدية فرعية"
                                    GroupName="report" OnCheckedChanged="radMunicSections_CheckedChanged" />
                            </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsSubMunicipality" DataTextField="munic_name" DataValueField="MUNIC_NO">
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
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير"
                                Height="21px" />
                        </td>
                        <td>
                            <asp:Button ID="btnNewSurveyCancel" runat="server" OnClick="btnNewSurveyCancel_Click"
                                Text="إلغاء" />
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
