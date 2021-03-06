<%@ Page Title="تقرير مستوى تخدد الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="RuttingReport.aspx.cs" Inherits="ASPX_Reports_RuttingReport" %>

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
            width: 150px;
            height: 16px;
        }
        .style4
        {
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <strong>تقرير مستوى تخدد الطرق الرئيسية</strong></h2>
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
            <td class="style4">
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="LoadMainStreetsHavingCalculatedRutting"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radByIntersects" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" class="style3" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByMainLanes" runat="server" Checked="True" GroupName="report"
                        Text="مسارات شارع محدد" AutoPostBack="True" OnCheckedChanged="radByMainLanes_CheckedChanged" />
                </b>
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="main_no"
                    OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
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
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByIntersects" runat="server" GroupName="report" Text="تقاطعات شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radByIntersects_CheckedChanged" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByAllLanes" runat="server" GroupName="report" Text="مسارات كل الطرق الرئيسية"
                        AutoPostBack="True" OnCheckedChanged="radByAllLanes_CheckedChanged" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByAllinters122" runat="server" GroupName="report" Text="تقاطعات كل الطرق الرئيسية"
                        AutoPostBack="True" OnCheckedChanged="radByAllLanes_CheckedChanged" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td style="text-align: right">
                <%--<asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsRuttingSurveys"
                    DataTextField="survey_title" DataValueField="survey_no" Height="27px">
                </asp:RadioButtonList>
                <asp:ObjectDataSource ID="odsRuttingSurveys" runat="server" SelectMethod="GetMainStreetIriSurveys"
                    TypeName="JpmmsClasses.BL.RuttingReport">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainNo" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="radByAllLanes" Name="allRoads" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByIntersects" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByAllinters122" DefaultValue="true" Name="allintersect"
                            PropertyName="Checked" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
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
