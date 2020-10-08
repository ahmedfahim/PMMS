<%@ Page Title="تقرير تقييم حالة رصف مقاطع شبكة الطرق " Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="PavementEvalSectionsReport.aspx.cs" Inherits="ASPX_Reports_PavementEvalSectionsReport" %>

<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
            width: 70%;
        }
        .style4
        {
            width: 30%;
        }
        .style5
        {
            width: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="style4" colspan="3">
                <h2 class="style2">
                    <strong>تقرير تقييم حالة رصف مقاطع شبكة الطرق </strong>
                </h2>
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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td>
                &nbsp;
                <%--<asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetsHavingUdiCalculated"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>--%>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetStreetsIRI"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="LoadUdiCalculatedSections"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetRegionsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetMainStreetSectionAvailableSurveys"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainSt" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSectionSurveys" runat="server" SelectMethod="GetRegionSurroundingSectionsAvailableSurveys"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <b>
                    <asp:RadioButton ID="radBySamples" runat="server" Checked="True" GroupName="report"
                        Text="العينات في مقطع/شارع محدد" AutoPostBack="True" OnCheckedChanged="radBySamples_CheckedChanged" />
                </b>
            </td>
            <td colspan="2" rowspan="3">
                <table align="right" class="style3">
                    <tr>
                        <td>
                            <b>الشارع الرئيسي </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="main_no" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td rowspan="3">
                            <asp:RadioButton ID="radAllDists" runat="server" Checked="True" GroupName="type"
                                Text="كل العيوب" />
                            <br />
                            <asp:RadioButton ID="radPatchDistsOnly" runat="server" GroupName="type" Text="عيوب الترقيعات فقط" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                       <%--     <b>المقطع </b>--%>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true" Visible="false"
                                ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td>
                            <b>رقم المسح </b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsSampleSurveys"
                                DataTextField="survey_title" DataValueField="survey_no" OnSelectedIndexChanged="radlOldSurveys_SelectedIndexChanged">
                            </asp:RadioButtonList>
                            <asp:RadioButtonList ID="radlRegionSectionsSurveys" runat="server" DataSourceID="odsRegionSectionSurveys"
                                DataTextField="survey_title" DataValueField="survey_no" Style="text-align: right"
                                OnDataBound="radlRegionSectionsSurveys_DataBound">
                            </asp:RadioButtonList>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <b>
                    <asp:RadioButton ID="radByLanes" runat="server" GroupName="report" Text="المسارات في مقطع/شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radByLanes_CheckedChanged" Visible="False" />
                </b>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px" class="style4">
                <b>
                    <asp:RadioButton ID="radSectionsOfMainStreet" runat="server" GroupName="report" Text="مقاطع شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radSectionsOfMainStreet_CheckedChanged"
                        Visible="False" />
                </b>
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radRegionSurroundSections" runat="server" GroupName="report"
                        Text="مسارات المقاطع المحيطة بالمنطقة " AutoPostBack="True" OnCheckedChanged="radRegionSurroundSections_CheckedChanged"
                        Visible="False" />
                </b>
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    Visible="false" DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
                <br />
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>
                    <asp:RadioButton ID="radLanesByMunic" runat="server" GroupName="report" Text="مسارات الطرق الرئيسية ضمن بلدية"
                        AutoPostBack="True" OnCheckedChanged="radLanesByMunic_CheckedChanged" Visible="False" />
                </b>
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    Visible="false" DataSourceID="odsSubMunicipality" DataTextField="munic_name"
                    DataValueField="MUNIC_NO">
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
            <td colspan="3">
                <b>
                    <asp:RadioButton ID="radSectionsByMunic" runat="server" GroupName="report" Text="مقاطع الطرق الرئيسية ضمن بلدية"
                        AutoPostBack="True" OnCheckedChanged="radSectionsByMunic_CheckedChanged" Visible="False" />
                </b>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:CheckBox ID="chkWithDistresses" runat="server" Enabled="False" Text="التقرير يتضمن العيوب" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table class="style5">
                    <tr>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
