<%@ Page Title="تقارير متنوعة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReportingOthers.aspx.cs" Inherits="ASPX_Reports_ReportingOthers" %>

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
            width: 20%;
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
                    تقارير متنوعة</h2>
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
            <td>
            </td>
            <td>
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
            <td>
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radAreas" runat="server" Checked="True" GroupName="type" Text="المساحات مدخلة العيوب"
                    AutoPostBack="True" OnCheckedChanged="radAreas_CheckedChanged" />
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
                <b>خلال يوم</b>
                <telerik:RadDatePicker ID="raddtpFrom" runat="server">
                </telerik:RadDatePicker>
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
                <asp:RadioButton ID="radNetworkArea" runat="server" GroupName="type" Text="مساحة كامل الشبكة"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
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
                <asp:RadioButton ID="radIntersectTypes" runat="server" GroupName="type" Text="انواع التقاطعات"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
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
                <asp:RadioButton ID="radMaintDeciding" runat="server" GroupName="type" Text="قرارات الصيانة للعيوب"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="radMaintDecisions" runat="server" GroupName="type" Text="قرارات الصيانة "
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RadioButton ID="radSurveyors" runat="server" GroupName="type" Text="المساحين"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;</td>
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="lblTotal" runat="server" ReadOnly="True" TextMode="MultiLine" BorderStyle="Groove"
                    Height="150px" Visible="False" Width="40%"></asp:TextBox>
            </td>
            <td>
                &nbsp;
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
    </table>
</asp:Content>
