<%@ Page Title="ميزانية قرارات صيانة شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="BudgetMaintDecisions.aspx.cs" Inherits="ASPX_Reports_BudgetMaintDecisions" %>

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
        .style4
        {
            width: 40%;
        }
        .style5
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
                    <strong>ميزانية قرارات صيانة شبكة الطرق</strong></h2>
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
                <b>&nbsp; </b>
            </td>
            <td width="70%">
                &nbsp;
            </td>
            <td width="10%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByMainLanes" runat="server" Checked="True" GroupName="report"
                        Text="مقاطع طريق رئيسي" AutoPostBack="True" OnCheckedChanged="radByMainLanes_CheckedChanged" />
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
                    <asp:RadioButton ID="radByIntersections" runat="server" GroupName="report" Text="تقاطعات طريق رئيسي"
                        AutoPostBack="True" OnCheckedChanged="radByIntersections_CheckedChanged" />
                </b>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByRegionNo" runat="server" GroupName="report" Text="منطقة محددة"
                        AutoPostBack="True" OnCheckedChanged="radByRegionNo_CheckedChanged1" />
                </b>
            </td>
            <td colspan="2">
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="SUBdistRICT" DataValueField="region_id"
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
                        AutoPostBack="True" OnCheckedChanged="radByRegionName_CheckedChanged1" />
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
                        Text="حي محدد" OnCheckedChanged="radByRegionsAreaName_CheckedChanged1" />
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
            <td colspan="2" rowspan="3">
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
            <td>
                &nbsp;
            </td>
            <td>
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
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Panel ID="pnlBudget" runat="server">
                    <table class="style4">
                        <tr>
                            <td>
                                <b>الميزانية المقترحة</b>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtTotalAmount" runat="server" MinValue="0" OnTextChanged="rntxtTotalAmount_TextChanged"
                                    AutoPostBack="True" ReadOnly="True">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                &nbsp;<b>ريال</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>النسبة المتاحة %</b>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtPercent" runat="server" MaxValue="100" MinValue="0"
                                    OnTextChanged="rntxtPercent_TextChanged" Value="100" Width="50px" AutoPostBack="True">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>الميزانية المتاحة
                                    <br />
                                    حسب النسبة</b>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtBudget" runat="server" MinValue="0">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <b>ريال</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <b>خيارات الأولويات</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <asp:RadioButton ID="radUdiAsc" runat="server" Checked="True" GroupName="sort" Text="حسب مستوى الأضرار من الأسوأ للأحسن" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <asp:RadioButton ID="radUdiDesc" runat="server" GroupName="sort" Text="حسب مستوى الأضرار من الأحسن للأسوأ" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <asp:RadioButton ID="radPrio" runat="server" GroupName="sort" Text="الترتيب حسب معاملات الأولوية" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <b>نوع التقرير </b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <asp:RadioButton ID="radDetails" runat="server" Checked="True" GroupName="details"
                                    Text="تفصيلي" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <asp:RadioButton ID="radTotal" runat="server" GroupName="details" Text="ملخص إجمالي" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style5">
                                <asp:RadioButton ID="radMaintLengths" runat="server" GroupName="details" Text="ملخص المساحات لكل نوع صيانة" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
