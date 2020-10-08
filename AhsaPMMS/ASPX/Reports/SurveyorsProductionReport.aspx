<%@ Page Title="تقرير إنتاجية المساحين" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SurveyorsProductionReport.aspx.cs" Inherits="ASPX_Reports_SurveyorsProductionReport" %>

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
                    <strong>تقرير إنتاجية المساحين</strong></h2>
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
                <asp:ObjectDataSource ID="odsSurveyors" runat="server" SelectMethod="GetAllsurveyors"
                    TypeName="JpmmsClasses.BL.Surveyor"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>اسم المساح </b>
            </td>
            <td>
                <asp:DropDownList ID="ddlSurveyor" runat="server" AppendDataBoundItems="True" DataSourceID="odsSurveyors"
                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO">
                    <asp:ListItem Selected="True" Value="0">الكل</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>في الفترة من </b>
            </td>
            <td>
                <telerik:RadDatePicker ID="raddtpFrom" runat="server">
                </telerik:RadDatePicker>
                إلى
                <telerik:RadDatePicker ID="raddtpTo" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>نوع المسح </b>
            </td>
            <td>
                <asp:RadioButton ID="radSection" runat="server" Checked="True" GroupName="type" Text="مقاطع" />
                <br />
                <asp:RadioButton ID="radIntersection" runat="server" GroupName="type" Text="تقاطعات" />
                <br />
                <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق شوارع فرعية" />
                <br />
                <asp:RadioButton ID="radTotal" runat="server" GroupName="type" Text="إجمالي تسليم المساحين" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:TextBox ID="lblTotal" runat="server" ReadOnly="True" TextMode="MultiLine" 
                    BorderStyle="Groove" Height="150px" Visible="False" Width="40%"></asp:TextBox>
            </td>
            <td>
                &nbsp;
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
