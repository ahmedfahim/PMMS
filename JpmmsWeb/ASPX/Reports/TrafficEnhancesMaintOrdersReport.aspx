<%@ Page Title="تقرير التحسينات المرورية وأوامر الصيانة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="TrafficEnhancesMaintOrdersReport.aspx.cs" Inherits="ASPX_Reports_TrafficEnhancesMaintOrdersReport" %>

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
            width: 50%;
        }
        .style4
        {
            height: 12px;
        }
        .style5
        {
            height: 19px;
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
                    <b>تقرير التحسينات المرورية وأوامر الصيانة </b>
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
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
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
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
                            <asp:RadioButton ID="radTrafficEnhanceLocations" runat="server" Checked="True" GroupName="type"
                                Text="مواقع تحسين مروري" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radTrafficEnhanceDetails" runat="server" GroupName="type" Text="تفاصيل تحسين مروري" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radMaintOrder" runat="server" GroupName="type" Text="أمر صيانة" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                يتضمن الإجراء
            </td>
            <td>
                <asp:TextBox ID="txtDetail" runat="server" Width="371px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                المقاول
            </td>
            <td>
                <asp:DropDownList ID="ddlContractors" runat="server" DataSourceID="odsContractors"
                    DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_No" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                للفترة بين
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            <telerik:RadDatePicker ID="raddtpFrom" runat="server">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            إلى
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="raddtpTo" runat="server">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radAllRoads" runat="server" AutoPostBack="True" Checked="True"
                    GroupName="road" OnCheckedChanged="radAllRoads_CheckedChanged" Text="كامل شبكة الطرق" />
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
                <asp:RadioButton ID="radMainSt" runat="server" AutoPostBack="True" GroupName="road"
                    OnCheckedChanged="radMainSt_CheckedChanged" Text="شارع رئيسي" />
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreets" DataTextField="MAIN_NAME" DataValueField="STREET_ID">
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
                <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" GroupName="road"
                    OnCheckedChanged="radRegion_CheckedChanged" Text="منطقة فرعية" />
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id">
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
            <td class="style5" colspan="3">
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
