<%@ Page Title="تقرير مستوى وعورة الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IRI_Report.aspx.cs" Inherits="ASPX_Reports_IRI_Report" %>

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
                    <strong>تقرير مستوى وعورة الطرق الرئيسية</strong></h2>
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
            <td class="style4">
                &nbsp;&nbsp;
            </td>
            <td>
                <%--      <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="LoadMainStreetsHavingCalculatedIri"
                    TypeName="JpmmsClasses.BL.MainStreet">--%>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetStreetsIRI"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
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
                    DataSourceID="odsMainStreets" DataTextField="MAIN_NO" DataValueField="STREET_ID"
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
                    <asp:RadioButton ID="radByIntersections" runat="server" GroupName="report" Text="تقاطعات شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radByIntersections_CheckedChanged" />
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
                        AutoPostBack="True" OnCheckedChanged="radByAllLanes_CheckedChanged" Visible="false" />
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
                    <asp:RadioButton ID="radByAllIntersects" runat="server" GroupName="report" Text="تقاطعات كل الطرق الرئيسية"
                        AutoPostBack="True" OnCheckedChanged="radByAllIntersects_CheckedChanged" Visible="false" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <%--   <tr>
            <td class="style4">
                <b>رقم المسح </b>
            </td>
            <td style="text-align: right">
                <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsIriSurveys"
                    DataTextField="survey_title" DataValueField="survey_no" Height="27px">
                </asp:RadioButtonList>
                <asp:ObjectDataSource ID="odsIriSurveys" runat="server" SelectMethod="GetMainStreetIriSurveys"
                    TypeName="JpmmsClasses.BL.IriReport">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainNo" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="radByIntersections" Name="isIntersection" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByAllLanes" Name="allRoads" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByAllIntersects" Name="allIntersects" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
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
