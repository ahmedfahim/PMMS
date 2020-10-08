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
        .style6
        {
            height: 100px;
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
                       
                       
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radIntersection" runat="server" GroupName="type" Text="طرق رئيسية ممسوحة التقاطعات"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق شوارع فرعية ممسوحة "
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            <asp:RadioButton ID="radSurveyedSections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSurveyedIntersects" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radTrafficCounting" runat="server" GroupName="type" Text="طرق رئيسية تم تنفيذ العد المروري لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radFwd" runat="server" GroupName="type" Text="طرق رئيسية تم تنفيذ اختبار الحمل الساقط FWD لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radIriSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس الوعورة IRI لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radIntersectIri" runat="server" GroupName="type" Text="طرق رئيسية تم قياس الوعورة IRI لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radGprSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس سماكة طبقات الرصف GPR لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radGprIntersect" runat="server" GroupName="type" Text="طرق رئيسية تم قياس سماكة طبقات الرصف GPR لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSkidSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس مقاومة الانزلاق SKID لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSkidIntersects" runat="server" GroupName="type" Text="طرق رئيسية تم قياس مقاومة الانزلاق SKID لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radRuttingSections" runat="server" GroupName="type" Text="طرق رئيسية تم قياس التخدد Rutting لمقاطعها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radRuttingIntersects" runat="server" GroupName="type" Text="طرق رئيسية تم قياس التخدد Rutting لتقاطعاتها"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSectionPhotos" runat="server" GroupName="type" Text="شوارع رئيسية لها صور ضمن معرض الصور"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            <asp:RadioButton ID="radRegionPhotos" runat="server" GroupName="type" Text="مناطق شوارع فرعية لها صور ضمن معرض الصور"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSectionNoPhotos" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radIntersectNoPhotos" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radRegionNoPhotos" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSectionSurveyedNoPhotos" runat="server" 
                                AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية ممسوحة لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radIntersectSurveyedNoPhotos" runat="server" 
                                AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية ممسوحة لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radRegionSurveyedNoPhotos" runat="server" 
                                AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية ممسوحة لاتوجد لها صور ضمن معرض الصور" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSectionQc" runat="server" GroupName="type" Text="شوارع رئيسية أجري لمقاطعها مسح ضبط جودة"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radIntersectQc" runat="server" GroupName="type" Text="شوارع رئيسية أجري لتقاطعاتها مسح ضبط جودة"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radRegionQc" runat="server" GroupName="type" Text="مناطق شوارع فرعية أجري لها مسح ضبط جودة"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radReSurveySections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية متوجبة إعادة المسح" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radReSurveyIntersect" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطعات طرق رئيسية متوجبة إعادة المسح" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radReSurveyRegions" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية متوجبة إعادة المسح" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radNonSurveyedSections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مقاطع طرق رئيسية غير ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radNonSurveyedIntersects" runat="server" AutoPostBack="True"
                                GroupName="type" Text="تقاطعات طرق رئيسية غير ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radNonSurveyedRegions" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية غير ممسوحة" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radClosedRegions" runat="server" AutoPostBack="True" GroupName="type"
                                Text="مناطق طرق فرعية لايمكن مسحها" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="radNonSurveySectionsStreets" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="طرق رئيسية غير ممسوحة المقاطع" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="radNonSurveyIntersectStreets" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="طرق رئيسية غير ممسوحة التقاطعات" />
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radNonCompleteSections" runat="server" AutoPostBack="True" GroupName="type"
                                Text="طرق رئيسية غير مكتملة مسح المقاطع" />
                        </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="radNonCompleteIntersects" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="طرق رئيسية غير مكتملة مسح التقاطعات" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="radNonCompleteSurveyingRegions" runat="server" AutoPostBack="True"
                                    GroupName="type" Text="مناطق طرق فرعية غير مكتملة المسح" />
                            </td>
                    </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                    </tr>
                        <tr>
                            <td>
                              
         
                                <asp:RadioButton ID="radByMonth" runat="server" AutoPostBack="True"  GroupName="type"
                                    Text="شهري" oncheckedchanged="radByMonth_CheckedChanged"  />
                            </td>
                    </tr>
                        <tr>
                            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" GroupName="type" Enabled="False" >
                    <asp:ListItem Value="3" >المسح الثالث مناطق</asp:ListItem>
                    <asp:ListItem Value="4">المسح الحالي مناطق </asp:ListItem>
                    <asp:ListItem Value="0">الكل مناطق</asp:ListItem>
                    <asp:ListItem Value="03">المسح الثالث تقاطعات</asp:ListItem>
                    <asp:ListItem Value="04">المسح الحالي تقاطعات </asp:ListItem>
                    <asp:ListItem Value="00">الكل تقاطعات</asp:ListItem>
                </asp:RadioButtonList>
                     
                      
                            <asp:DropDownList ID="DrpDwnListMonth" runat="server" 
                    Enabled="False" AppendDataBoundItems="True" DataSourceID="ObjectDataSource1" 
                                    DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear">
                                <asp:ListItem Value="-1">اختر الشهر</asp:ListItem>
                                <asp:ListItem Value="0">الكل</asp:ListItem>
                            </asp:DropDownList>
                       
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
                &nbsp;</td>
            <td>
                              
         
                                <br />
                              
         
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                    SelectMethod="GetReportMonthsRegions" TypeName="JpmmsClasses.BL.Lookups.SystemUsers">
                                </asp:ObjectDataSource>
                       
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style6">
        </td>
         <td colspan="2" class="style6">
                                <asp:RadioButton ID="radByDate" runat="server" AutoPostBack="True"  GroupName="type"
                                    Text="خلال فترة محددة" oncheckedchanged="radByDate_CheckedChanged" Visible="false" /><br />
          <%--<b>من</b>--%>
          <telerik:RadDatePicker ID="raddtpFrom" runat="server" Enabled="False" Visible="false">
                                <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
         <%-- <b>إلى </b>--%>
                            <telerik:RadDatePicker ID="raddtpTo" runat="server" Enabled="False" Visible="false">
                                <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
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
