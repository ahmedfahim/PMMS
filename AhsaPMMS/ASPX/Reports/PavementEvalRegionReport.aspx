<%@ Page Title="تقرير تقييم حالة رصف مناطق الشوارع الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="PavementEvalRegionReport.aspx.cs" Inherits="ASPX_Reports_PavementEvalRegionReport" %>

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
            <td colspan="2">
                <h2 class="style2">
                    <strong>تقرير تقييم حالة رصف مناطق الشوارع الفرعية</strong></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
                <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetRegionDistrictAvailableSurveys"
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
                        <asp:ControlParameter ControlID="radByRegion" Name="forRegion" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByRegionName" Name="forSubdist" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByRegionsAreaName" Name="forDist" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radbyMunicName" Name="forMunic" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByRegionTotal" Name="isRegionTotal" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetRegionsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubdistricts" runat="server" SelectMethod="GetSubdistrictsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetMunicipalityHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                    TypeName="JpmmsClasses.BL.SecondaryStreets">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetDistrictsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="30%">
                <b>
                    <asp:RadioButton ID="radByRegion" runat="server" AutoPostBack="True" Checked="True"
                        GroupName="report" OnCheckedChanged="radByRegion_CheckedChanged" Text="لشوارع منطقة محددة" />
                </b>
            </td>
            <td rowspan="2" width="85%" style="width: 0%">
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
            <td rowspan="8" width="85%" style="width: 42%">
                <asp:RadioButton ID="radAllDists" runat="server" Checked="True" GroupName="type"
                    Text="كل العيوب" />
                <br />
                <asp:RadioButton ID="radPatchDistsOnly" runat="server" GroupName="type" Text="عيوب الترقيعات فقط" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radByRegionTotal" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radByRegionTotal_CheckedChanged" Text="لمنطقة محددة (متوسط)" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radByRegionName" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radByRegionName_CheckedChanged" Text="لشوارع حي فرعي محدد" />
                </b>
            </td>
            <td rowspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegionNames" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSubdistricts" DataTextField="SUBdistRICT" DataValueField="SUBdistRICT"
                    OnSelectedIndexChanged="ddlRegionNames_SelectedIndexChanged">
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
                    <asp:RadioButton ID="radByRegionNameTotal" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radByRegionName_CheckedChanged" Text="لمناطق حي فرعي محدد (متوسط)" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radByRegionsAreaName" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radByRegionsAreaName_CheckedChanged" Text="لشوارع حي محدد" />
                </b>
            </td>
            <td rowspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlDistrict" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsDistricts" DataTextField="dist_name" DataValueField="dist_name"
                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
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
                    <asp:RadioButton ID="radByRegionsAreaNameTotal" runat="server" AutoPostBack="True"
                        GroupName="report" OnCheckedChanged="radByRegionsAreaName_CheckedChanged" Text="لمناطق حي محدد (متوسط)" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b>
                    <asp:RadioButton ID="radbyMunicName" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radbyMunicName_CheckedChanged" Text="لشوارع بلدية محددة" />
                </b>
            </td>
            <td class="style3" rowspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSubMunicipality" DataTextField="munic_name" DataValueField="munic_name"
                    OnSelectedIndexChanged="ddlMunic_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td class="style3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b>
                    <asp:RadioButton ID="radbyMunicTotal" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radbyMunicName_CheckedChanged" Text="لمناطق بلدية محددة (متوسط)" />
                </b>
            </td>
            <td class="style3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="3">
                <asp:CheckBox ID="chkWithDistresses" runat="server" Enabled="False" Text="التقرير يتضمن العيوب" />
            </td>
        </tr>
        <%-- <tr>
            <td>
                <b>رقم المسح </b>
            </td>
            <td colspan="3">
                <asp:RadioButtonList ID="radlOldSurveys" runat="server">
                </asp:RadioButtonList>
            </td>
        </tr>--%>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
            </td>
            <td colspan="2">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
