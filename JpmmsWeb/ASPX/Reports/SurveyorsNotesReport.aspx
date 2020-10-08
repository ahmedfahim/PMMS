<%@ Page Title="تقرير الملاحظات على المسح" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SurveyorsNotesReport.aspx.cs" Inherits="ASPX_Reports_SurveyorsNotesReport" %>

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
                    <strong>تقرير الملاحظات على المسح</strong></h2>
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
                نوع المسح
            </td>
            <td>
                <asp:RadioButton ID="radSection" runat="server" Checked="True" GroupName="type" Text="مقاطع" />
                <br />
                <asp:RadioButton ID="radIntersection" runat="server" GroupName="type" Text="تقاطعات" />
                <br />
                <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق شوارع فرعية" />
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
