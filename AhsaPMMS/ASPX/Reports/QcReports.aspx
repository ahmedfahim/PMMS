<%@ Page Title="تقارير مسوحات ضبط الجودة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="QcReports.aspx.cs" Inherits="ASPX_Reports_QcReports" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
            width: 50%;
        }
        .style4
        {
            width: 40%;
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
                    <b>تقارير مسوحات ضبط الجودة</b></h2>
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
            <td colspan="3">
                &nbsp; &nbsp;<asp:ObjectDataSource ID="odsSurveyor" runat="server" DeleteMethod="Delete"
                    InsertMethod="Insert" SelectMethod="GetAllSurveyors" TypeName="JpmmsClasses.BL.Surveyor"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="SURVEYOR_NO" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="SURVEYOR_NAME" Type="String" />
                        <asp:Parameter Name="SURVEYOR_WORK_STARTDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_WORK_ENDDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_PHONE_NO" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SURVEYOR_NAME" Type="String" />
                        <asp:Parameter Name="SURVEYOR_WORK_STARTDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_WORK_ENDDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_PHONE_NO" Type="String" />
                        <asp:Parameter Name="SURVEYOR_NO" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
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
                            <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق شوارع فرعية"
                                AutoPostBack="True" Checked="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radSection" runat="server" GroupName="type" Text="مقاطع" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radIntersection" runat="server" GroupName="type" Text="تقاطعات"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSummary" runat="server" Checked="True" GroupName="details"
                                Text="ملخص" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radDetails" runat="server" GroupName="details" Text="تفصيلي"
                                AutoPostBack="True" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSuccess" runat="server" GroupName="success" Text="ناجح" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radFail" runat="server" GroupName="success" Text="راسب" AutoPostBack="True" />
                        </td>
                        <td>
                            &nbsp;<asp:RadioButton ID="radSuccessAll" runat="server" GroupName="success" Text="الكل"
                                AutoPostBack="True" Checked="True" />
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
                اسم المساح
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="ddlSurveyor" runat="server" DataSourceID="odsSurveyor"
                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                اسم المراقب
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="ddlQcSurveyor" runat="server" DataSourceID="odsSurveyor"
                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                خلال الفترة من
            </td>
            <td>
                <table class="style4">
                    <tr>
                        <td>
                            <telerik:RadDatePicker ID="raddtpFrom" runat="server">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            إلى
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="raddtpTo" runat="server">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                                    ViewSelectorText="x">
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
