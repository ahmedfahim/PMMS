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
        .style4
        {
            height: 23px;
        }
        .style5
        {
            width: 60px;
        }
        .style6
        {
            height: 23px;
            width: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="style5">
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
            <td class="style6">
            </td>
            <td class="style4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" class="style3" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="style4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radLENGTH" runat="server" GroupName="type" Text="مجموع أطوال الشوارع للمنطقة"
                    AutoPostBack="True" OnCheckedChanged="radLENGTH_CheckedChanged" />
                &nbsp;<br />
                &nbsp;<asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True"
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                    Enabled="False">
                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radAreas" runat="server" Checked="True" GroupName="type" Text="المساحات مدخلة العيوب ليوم"
                    AutoPostBack="True" OnCheckedChanged="radAreas_CheckedChanged" />
                &nbsp;
                <telerik:RadDatePicker ID="raddtpFrom" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
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
            <td class="style5">
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
            <td class="style5">
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
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radMaintDecisions" runat="server" GroupName="type" Text="قرارات الصيانة "
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radSurveyors" runat="server" GroupName="type" Text="المساحين"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radFWD" runat="server" GroupName="type" Text="عدد نقاط معده الحمل الساقط"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radGPR" runat="server" GroupName="type" Text="الأطوال الممسوحة بمعدة قياس سمك الطبقات"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radSKID" runat="server" GroupName="type" Text="الأطوال الممسوحة بمعدة قياس مقاومة الأنزلاق"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radIRI" runat="server" GroupName="type" Text="قياسات إستوائية سطح الطريق"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radAssets" runat="server" GroupName="type" Text="قياسات المسح التصويري الرقمي"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radDIST" runat="server" GroupName="type" Text="قياسات مسح الأضرار في الأسطح الأسفلتية"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="radRegionsALL" runat="server" GroupName="type" Text="اجمالي إنتاجية المسح البصري مع الرئيسي السابق"
                    AutoPostBack="True" OnCheckedChanged="radNetworkArea_CheckedChanged" />
            </td>
            <td>
                &nbsp;
            </td>
            </tr>
            <tr>
                <td class="style5">
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
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="lblTotal" runat="server" ReadOnly="True" TextMode="MultiLine" BorderStyle="Groove"
                    Height="150px" Width="40%"></asp:TextBox>
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
