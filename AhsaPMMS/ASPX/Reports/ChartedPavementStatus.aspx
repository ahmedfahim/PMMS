<%@ Page Title="تقرير حالة رصف المساحات المسطحة للشوارع" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ChartedPavementStatus.aspx.cs" Inherits="ASPX_Reports_ChartedPavementStatus" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            width: 30%;
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
                    <b>تقرير حالة رصف المساحات المسطحة للشوارع</b></h2>
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
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetsHavingUdiCalculated"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radSectionIntersects" runat="server" GroupName="type" Text="شوارع رئيسية - مقاطع وتقاطعات"
                    Checked="True" OnCheckedChanged="radSectionIntersects_CheckedChanged" AutoPostBack="True" />
                &nbsp;
            </td>
            <td>
                <br />
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" autoselectfirstitem="True"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                    OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radRegions" runat="server" GroupName="type" Text="مناطق شوارع فرعية"
                    OnCheckedChanged="radRegions_CheckedChanged" AutoPostBack="True" />
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" autoselectfirstitem="true"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                    Height="21px" OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
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
                &nbsp;
            </td>
            <td>
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
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
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
