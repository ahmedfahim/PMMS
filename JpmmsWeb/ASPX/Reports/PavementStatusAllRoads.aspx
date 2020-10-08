<%@ Page Title="تقرير حالة رصف شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="PavementStatusAllRoads.aspx.cs" Inherits="ASPX_Reports_PavementStatusAllRoads" %>

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
        .style3
        {
            width: 50%;
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
                    <b>تقرير حالة رصف شبكة الطرق</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
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
            <td>
                <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetRegionsAndMainStreetSectionIntersections"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radRegionSecondary" Name="regions" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radSection" Name="sections" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radIntersection" Name="intersects" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetMunicipalityHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
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
                    <%-- <tr>
                        <td>
                            <b>رقم المسح</b>
                        </td>
                        <td colspan="3">
                            <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsAllRoadsSurveys"
                                DataTextField="survey_no" DataValueField="survey_no" OnDataBound="radlOldSurveys_DataBound">
                            </asp:RadioButtonList>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق الشوارع الفرعية"
                                    AutoPostBack="True" Checked="True" OnCheckedChanged="radRegionSecondary_CheckedChanged" />
                            </b>
                        </td>
                        <td>
                            <b>البلدية الفرعية</b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsSubMunicipality" DataTextField="munic_name" DataValueField="munic_name">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <b>
                                <asp:RadioButton ID="radSection" runat="server" GroupName="type" Text="مسارات مقاطع الشوارع الرئيسية"
                                    AutoPostBack="True" OnCheckedChanged="radSection_CheckedChanged" />
                            </b>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <b>
                                <asp:RadioButton ID="radIntersection" runat="server" GroupName="type" Text="تقاطعات الشوارع الرئيسية"
                                    AutoPostBack="True" OnCheckedChanged="radIntersection_CheckedChanged" />
                            </b>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>رقم المسح:</b>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlOldSurveys" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsSampleSurveys" DataTextField="survey_no" DataValueField="survey_no">
                                <asp:ListItem Selected="True" Value="0">المسح الأخير</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
            </td>
            <td>
                &nbsp;<asp:Button ID="btnNewSurveyCancel" runat="server" OnClick="btnNewSurveyCancel_Click"
                    Text="إلغاء" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
