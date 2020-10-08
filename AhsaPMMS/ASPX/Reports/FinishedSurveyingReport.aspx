<%@ Page Title="تقرير المناطق والشوارع الممسوحة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="FinishedSurveyingReport.aspx.cs" Inherits="ASPX_Reports_FinishedSurveyingReport" %>

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
        .style5
        {
            height: 24px;
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
                    <b>تقرير المناطق والشوارع الممسوحة</b></h2>
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
            <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
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
                <table class="style3">
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSection" runat="server" GroupName="type" Text="طرق رئيسية ممسوحة المقاطع"
                                AutoPostBack="True" Checked="True" />
                        </td>
                        <td style="margin-right: 40px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radIntersection" runat="server" GroupName="type" Text="طرق رئيسية ممسوحة التقاطعات"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق شوارع فرعية ممسوحة "
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="style5">
                            <asp:RadioButton ID="radSurveyedSections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radSurveyedIntersects" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radTrafficCounting" runat="server" GroupName="type" Text="طرق رئيسية تم تنفيذ العد المروري لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radFwd" runat="server" GroupName="type" Text="طرق رئيسية تم تنفيذ اختبار الحمل الساقط FWD لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radIriSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس الوعورة IRI لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radIntersectIri" runat="server" GroupName="type" Text="طرق رئيسية تم قياس الوعورة IRI لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radGprSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس سماكة طبقات الرصف GPR لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radGprIntersect" runat="server" GroupName="type" Text="طرق رئيسية تم قياس سماكة طبقات الرصف GPR لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radSkidSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس مقاومة الانزلاق SKID لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radSkidIntersects" runat="server" GroupName="type" Text="طرق رئيسية تم قياس مقاومة الانزلاق SKID لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radRuttingSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس التخدد Rutting لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radRuttingIntersects" runat="server" GroupName="type" Text="طرق رئيسية تم قياس التخدد Rutting لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radSectionPhotos" runat="server" GroupName="type" Text="شوارع رئيسية لها صور ضمن معرض الصور"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="style5">
                            <asp:RadioButton ID="radRegionPhotos" runat="server" GroupName="type" Text="مناطق شوارع فرعية لها صور ضمن معرض الصور"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radSectionNoPhotos" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radIntersectNoPhotos" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radRegionNoPhotos" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radSectionQc" runat="server" GroupName="type" Text="شوارع رئيسية أجري لمقاطعها مسح ضبط جودة"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radIntersectQc" runat="server" GroupName="type" Text="شوارع رئيسية أجري لتقاطعاتها مسح ضبط جودة"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radRegionQc" runat="server" GroupName="type" Text="مناطق شوارع فرعية أجري لها مسح ضبط جودة"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radReSurveySections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية متوجبة إعادة المسح" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radReSurveyIntersect" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية متوجبة إعادة المسح" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radReSurveyRegions" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية متوجبة إعادة المسح" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radNonSurveyedSections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية غير ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radNonSurveyedIntersects" runat="server" AutoPostBack="True"
                                GroupName="type" Text="تقاطعات طرق رئيسية غير ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radNonSurveyedRegions" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية غير ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radClosedRegions" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية لايمكن مسحها" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:RadioButton ID="radNonSurveySectionsStreets" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="طرق رئيسية غير ممسوحة المقاطع" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:RadioButton ID="radNonSurveyIntersectStreets" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="طرق رئيسية غير ممسوحة التقاطعات" />
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButton ID="radNonCompleteSections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="طرق رئيسية غير مكتملة مسح المقاطع" />
                        </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:RadioButton ID="radNonCompleteIntersects" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="طرق رئيسية غير مكتملة مسح التقاطعات" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:RadioButton ID="radNonCompleteSurveyingRegions" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="مناطق طرق فرعية غير مكتملة المسح" />
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
