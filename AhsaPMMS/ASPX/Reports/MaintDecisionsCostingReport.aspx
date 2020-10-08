<%@ Page Title="تقرير تكلفة تنفيذ قرارات صيانة رصف شبكة الطرق في حالة الميزانية المفتوحة"
    Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true"
    CodeFile="MaintDecisionsCostingReport.aspx.cs" Inherits="ASPX_Reports_MaintDecisionsCostingReport" %>

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
        .style3
        {
            direction: rtl;
        }
        .style4
        {
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
                    <strong style="direction: ltr">تقرير تكلفة تنفيذ قرارات صيانة رصف شبكة الطرق في حالة
                        الميزانية المفتوحة</strong></h2>
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
            <td>
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetsHavingMaintenanceDecisions"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radByMainLanes" Name="isServiceLanes" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByIntersections" Name="forIntersections" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByRegionNo" Name="isRegion" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetMunicipalitiesHavingMaintenanceDecisions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetDistrictsHavingMaintenanceDecisions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSurveyedSubdistricts" runat="server" SelectMethod="GetSubdistrictsHavingMaintenanceDecisions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                    TypeName="JpmmsClasses.BL.SecondaryStreets">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetRegionsHavingMaintenanceDecisions"
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
            </td>
            <td width="70%">
            </td>
            <td width="10%">
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <asp:RadioButton ID="radByMainLanes" runat="server" Checked="True" GroupName="report"
                    Text="مقاطع طريق رئيسي" AutoPostBack="True" OnCheckedChanged="radByMainLanes_CheckedChanged" />
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                    OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <asp:RadioButton ID="radByIntersections" runat="server" GroupName="report" Text="تقاطعات طريق رئيسي"
                    AutoPostBack="True" OnCheckedChanged="radByIntersections_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <asp:RadioButton ID="radByRegionNo" runat="server" GroupName="report" Text="منطقة محددة"
                    AutoPostBack="True" OnCheckedChanged="radByRegionNo_CheckedChanged" />
            </td>
            <td colspan="2" rowspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="SUBdistRICT" DataValueField="region_id"
                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
                <br />
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlRegionSecondaryStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" DataValueField="street_id">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <asp:RadioButton ID="radSectionsSurroundingRegion" runat="server" AutoPostBack="True"
                    GroupName="report" OnCheckedChanged="radSectionsSurroundingRegion_CheckedChanged"
                    Text="المقاطع المحيطة بالمنطقة " />
            </td>
        </tr>
        <tr>
            <td>
                <b>&nbsp; </b>
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <asp:RadioButton ID="radByRegionName" runat="server" GroupName="report" Text="حي فرعي محدد"
                    AutoPostBack="True" OnCheckedChanged="radByRegionName_CheckedChanged" />
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegionNames" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSurveyedSubdistricts" DataTextField="SUBdistRICT" DataValueField="SUBdistRICT"
                    OnSelectedIndexChanged="ddlRegionNames_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <asp:RadioButton ID="radByRegionsAreaName" runat="server" AutoPostBack="True" GroupName="report"
                    OnCheckedChanged="radByRegionsAreaName_CheckedChanged" Text="حي محدد" />
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlDistrict" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsDistricts" DataTextField="dist_name" DataValueField="dist_name"
                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
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
            <td colspan="2" rowspan="4">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSubMunicipality" DataTextField="MUNIC_NAME" DataValueField="MUNIC_NAME"
                    OnSelectedIndexChanged="ddlMunic_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radMunicSections" runat="server" GroupName="report" Text="مقاطع ضمن بلدية فرعية محددة"
                        AutoPostBack="True" OnCheckedChanged="radByMunicName_CheckedChanged" />
                </b>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radMunicIntersects" runat="server" GroupName="report" Text="تقاطعات ضمن بلدية فرعية محددة"
                        AutoPostBack="True" OnCheckedChanged="radByMunicName_CheckedChanged" />
                </b>
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
            <td class="style3">
                <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetRegionsAndMainStreetSectionIntersections"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlRegionNames" Name="subdistrict" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlDistrict" Name="districtName" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlMunic" Name="municName" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="radByRegionNo" Name="forRegion" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByRegionName" Name="forSubdist" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByRegionsAreaName" Name="forDist" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radbyMunicName" Name="forMunic" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="radByMainLanes" Name="lane" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByIntersections" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSectionSurveys" runat="server" SelectMethod="GetRegionSurroundingSectionsAvailableSurveys"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <%--<asp:RadioButtonList ID="radlRegionSectionsSurveys" runat="server" DataSourceID="odsRegionSectionSurveys"
                    DataTextField="survey_title" DataValueField="survey_no" Style="text-align: right">
                </asp:RadioButtonList>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style3">
                <asp:Panel ID="pnlInDetails" runat="server" Visible="False">
                    <asp:RadioButton ID="radDetails" runat="server" Checked="True" GroupName="details"
                        Text="تفصيلي" AutoPostBack="True" OnCheckedChanged="radDetails_CheckedChanged" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="radTotal" runat="server" GroupName="details" Text="ملخص إجمالي"
                        AutoPostBack="True" OnCheckedChanged="radTotal_CheckedChanged" />
                </asp:Panel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style3">
                <asp:CheckBox ID="chkNotDoing" runat="server" AutoPostBack="True" Text="مع استبعاد عناصر شبكة الطرق التي صدرت لها أوامر عمل أو تمت صيانتها "
                    Visible="False" />
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
