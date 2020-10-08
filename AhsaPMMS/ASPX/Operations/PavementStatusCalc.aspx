<%@ Page Title="حساب حالة الرصف لعناصر شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="PavementStatusCalc.aspx.cs" Inherits="ASPX_Operations_PavementStatusCalc" %>

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
            font-size: small;
            font-weight: bold;
        }
        .style3
        {
            width: 60%;
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
                    حساب حالة الرصف لعناصر شبكة الطرق</h2>
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
            <td>
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
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
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetSurveyedRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetsHavingSurveyDistresses"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radByIntersections" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetSurveyedMunicipalities"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetSurveyedDistricts"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSurveyedSubdistricts" runat="server" SelectMethod="GetSurveyedSubdistricts"
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
            <td width="15%">
                <b></b>
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
                        Text="مقاطع طريق رئيسي محدد" AutoPostBack="True" OnCheckedChanged="radByMainLanes_CheckedChanged" />
                </b>
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
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByIntersections" runat="server" GroupName="report" Text="تقاطعات طريق رئيسي محدد"
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
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByRegionName" runat="server" GroupName="report" Text="حي فرعي محدد"
                        AutoPostBack="True" OnCheckedChanged="radByRegionName_CheckedChanged" />
                </b>
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
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByRegionsAreaName" runat="server" AutoPostBack="True" GroupName="report"
                        OnCheckedChanged="radByRegionsAreaName_CheckedChanged" Text="حي محدد" />
                </b>
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
            <td colspan="2" rowspan="2">
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
            <td colspan="3">
                <b>&nbsp; </b>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlOldSurveys" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSampleSurveys" DataTextField="survey_no" DataValueField="survey_no"
                    Visible="False">
                    <asp:ListItem Selected="True" Value="0">المسح الأخير</asp:ListItem>
                </asp:DropDownList>
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
                &nbsp;
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="حساب حالة الرصف" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                        </td>
                        <td>
                            <asp:Button ID="btnRoadNetworkUdiCalc" runat="server" OnClick="btnRoadNetworkUdiCalc_Click"
                                OnClientClick="return confirm('حساب حالة الرصف لكامل الشبكة سيستغرق وقتا، هل تريد مواصلة الحساب؟');"
                                Text="حساب حالة الرصف لكامل الشبكة" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
