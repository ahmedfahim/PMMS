<%@ Page Title="تقرير عيوب تقاطعات شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IntersectionDistresses.aspx.cs" Inherits="ASPX_Reports_IntersectionDistresses" %>

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
            width: 80%;
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
                    <strong>تقرير عيوب تقاطعات شبكة الطرق</strong></h2>
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
            <td colspan="3">
                <table class="style1">
                    <tr>
                        <td colspan="3">
                            <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetsHavingIntersectionsSurveyDistresses"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="Get_AvailableIntersectionSurveys"
                                TypeName="JpmmsClasses.BL.DistressSurvey">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="intersectionID"
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsMainStreetIntersections" runat="server" SelectMethod="LoadSurveyedIntersections"
                                TypeName="JpmmsClasses.BL.Intersection">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                                TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistresses"
                                TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:RadioButton ID="radByIntersection" runat="server" AutoPostBack="True" Checked="True"
                                    GroupName="report" OnCheckedChanged="radBySection_CheckedChanged" Text="لتقاطع محدد" />
                        </td>
                        <td>
                            <b>
                                <asp:RadioButton ID="radbyMainStreet" runat="server" AutoPostBack="True" GroupName="report"
                                    OnCheckedChanged="radbyMainStreet_CheckedChanged" Text="تقاطعات شارع رئيسي محدد" />
                        </td>
                        <td>
                            <b></b></b> </b> <b>
                                <asp:RadioButton ID="radByMunic" runat="server" GroupName="report" Text="ضمن نطاق بلدية"
                                    AutoPostBack="True" OnCheckedChanged="radByMunic_CheckedChanged" />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b>
                                <asp:RadioButton ID="radByStreetDistressAreaTotal" runat="server" AutoPostBack="True"
                                    GroupName="report" OnCheckedChanged="radByStreetDistressAreaTotal_CheckedChanged"
                                    Text="مساحة العيوب لشارع محدد (مجموع)" />
                        </td>
                        <td>
                            </b> </b> <b>
                                <asp:RadioButton ID="radByStreetAreaTotal" runat="server" AutoPostBack="True" GroupName="report"
                                    OnCheckedChanged="radByStreetAreaTotal_CheckedChanged" Text="المساحة - العيوب (مجموع)" />
                            </b>
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
                            <b>&nbsp;
                        </td>
                        <td>
                            <b>&nbsp;
                        </td>
                        <td>
                            </b> </b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>الشارع الرئيسي </b>
                        </td>
                        <td>
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="True"
                                id="ddlMainStreets" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsMainStreets" datatextfield="main_title" datavaluefield="STREET_ID"
                                onselectedindexchanged="ddlMainStreets_SelectedIndexChanged" enabled="False">
                                 <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>التقاطع </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains"  Width="200px" Font-Size="Medium" autoselectfirstitem="true"
                                id="ddlMainStreetIntersection" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsMainStreetIntersections" datatextfield="intersection_title"
                                datavaluefield="INTERSECTION_ID" onselectedindexchanged="ddlMainStreetIntersection_SelectedIndexChanged">
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
                            <b>البلدية</b>
                        </td>
                        <td>
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="True"
                                id="ddlMunic" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsSubMunicipality" datatextfield="munic_name" datavaluefield="MUNIC_NO">
                                 <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>رمز العيب </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                DataTextField="distress_title" DataValueField="dist_code" Enabled="False">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <b>رقم المسح </b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsSampleSurveys"
                                DataTextField="survey_title" DataValueField="survey_no">
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>--%>
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
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
