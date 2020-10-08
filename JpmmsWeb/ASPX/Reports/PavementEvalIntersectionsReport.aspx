<%@ Page Title="تقرير تقييم حالة رصف تقاطعات شبكة الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="PavementEvalIntersectionsReport.aspx.cs" Inherits="ASPX_Reports_PavementEvalIntersectionsReport" %>

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
            width: 50%;
        }
        .style4
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
            <td>
                <h2 class="style2">
                    <strong>تقرير تقييم حالة رصف تقاطعات شبكة الطرق الرئيسية</strong></h2>
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
            <td colspan="3">
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
                &nbsp;
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetHavingIntersectionWithCalculatedUdi"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections" runat="server" SelectMethod="GetUdiCalculatedIntersectionForMainStreet"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="Get_AvailableIntersectionSurveysForUdi"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="radByIntersect" Name="forIntersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="intersectID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByIntersect" runat="server" Checked="True" GroupName="report"
                        Text="تقاطع محدد" AutoPostBack="True" OnCheckedChanged="radByIntersect_CheckedChanged" />
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
                                DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td rowspan="5">
                            <asp:RadioButton ID="radAllDists" runat="server" Checked="True" GroupName="type"
                                Text="كل العيوب" />
                            <br />
                            <asp:RadioButton ID="radPatchDistsOnly" runat="server" GroupName="type" Text="عيوب الترقيعات فقط" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>التقاطع </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreetIntersection" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreetIntersections" DataTextField="intersection_title"
                                DataValueField="INTERSECTION_ID" OnSelectedIndexChanged="ddlMainStreetIntersection_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <%--< <tr>
                        <td>
                            <b>رقم المسح </b>
                        </td>
                        <td>
                            asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsSampleSurveys"
                                DataTextField="SURVEY_title" DataValueField="survey_no">
                            </asp:RadioButtonList>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <b>البلدية</b>
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
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpDwnListMonth" runat="server" Enabled="False" AppendDataBoundItems="True"
                                DataSourceID="ObjectDataSource1" DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear">
                                <asp:ListItem Value="-1">اختر الشهر</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetReportMonthsRegions"
                                TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radbyStreet" runat="server" GroupName="report" Text="تقاطعات شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radbyStreet_CheckedChanged" />
                </b>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByMonth" runat="server" AutoPostBack="True" GroupName="report"
                        Text="شهري" oncheckedchanged="radByMonth_CheckedChanged" />
                </b>
            </td>
        </tr>
        <tr>
            <td style="margin-right: 80px">
                <b>
                    <asp:RadioButton ID="radByMunic" runat="server" GroupName="report" Text="ضمن نطاق بلدية"
                        AutoPostBack="True" OnCheckedChanged="radByMunic_CheckedChanged" />
                </b>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table class="style4">
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
                            <asp:RadioButton ID="radDetails" runat="server" Checked="True" GroupName="details"
                                Text="على مستوى عينات التقاطع" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radTotal" runat="server" GroupName="details" Text="على مستوى التقاطع"
                                AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkWithDistresses" runat="server" GroupName="details" AutoPostBack="True"
                                Text="تقرير متضمن لحالة الرصف العينات مع العيوب" />
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
