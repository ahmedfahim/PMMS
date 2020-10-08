<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderForReports.ascx.cs"
    Inherits="Controls_HeaderForReports" %>
<link href="../Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
<!--Header Table Start -->
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    
</style>
<table align="center" cellpadding="0" dir="rtl" cellspacing="0" style="width: 982px;
    border-collapse: collapse; margin-bottom: 0px;">
    <!--Upper Banner (Upper Menu) Start-->
    <tr>
        <td class="TopBar">
            <div class="UpperMenu">
                <ul>
                    <li><a id="A2" href="~/aspx/home/DefaultReports.aspx" runat="server">الصفحة الرئيسية</a></li>
                    <li><a href="http://www.jeddah.gov.sa/index.php">أمانة محافظة جدة</a></li>
                    <li><a id="A1" href="~/JpmmsManual.pdf" runat="server">المساعدة</a></li>
                </ul>
            </div>
            <div style="text-align: left; color: #FF6600;">
                اسم المستخدم:
                <asp:Label ID="lblUserName" runat="server" Text="" CssClass="style1"></asp:Label></div>
        </td>
    </tr>
    <!--Upper Banner (Upper Menu) End-->
    <!--Main Banner Start-->
    <tr>
        <td valign="top" style="width: 100%; height: 128px; background: #0B78BD;">
            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 128px;">
                <tr>
                    <!--Right Cell (Amana Logo) Start-->
                    <td style="width: 130px; height: 128px;" rowspan="2">
                        <a href="http://www.jeddah.gov.sa/index.php">
                            <img id="Img1" src="../Images/AmanahLogo.png" runat="server" alt="أمانة محافظة جدة"
                                title="أمانة محافظة جدة" width="130" height="128" border="0" /></a>
                    </td>
                    <!--Right Cell (Amana Logo) End-->
                    <!--Middle Cell (Flash) Start-->
                    <td class="UpperBannerRepeat">
                        <br />
                    </td>
                    <!--Middle Cell (Flash) End-->
                    <!--Left Cell (TagLine) Start-->
                    <!--Left Cell (TagLine) Start-->
                    <td style="width: 150px; height: 128px;" rowspan="2">
                        <a href="http://www.jeddah.gov.sa/eServices/index.php">
                            <img id="Img2" src="~/Images/Header/eServices.jpg" runat="server" alt="الخدمات الإلكترونية"
                                title="الخدمات الإلكترونية" width="150" height="128" border="0" /></a>
                    </td>
                    <!--Left Cell (TagLine) End-->
                    <!--Left Cell (TagLine) End-->
                </tr>
                <!--Main Menu Row Start-->
                <tr>
                    <td class="UpperBannerMainMenu" align="center" valign="bottom">
                        <div style="width: 673px; height: 24px; border: 0px red solid; margin: 0px; padding: 0px;">
                            <table width="673px" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
                                height: 24px">
                                <tr>
                                    <td valign="top" width="136px" height="24px">
                                    </td>
                                    <td valign="top" width="135px" height="24px">
                                    </td>
                                    <td valign="top" width="135px" height="24px">
                                    </td>
                                    <td valign="top" width="134px" height="24px">
                                    </td>
                                    <td valign="top" width="133px" height="24px">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <!--Main Menu Row End-->
            </table>
        </td>
    </tr>
    <!--Main Banner End-->
    <!--Main Menu Content Row Start-->
    <tr>
        <td valign="top" style="width: 100%;" align="center">
            <div id="MainMenuTitleBG" style="margin: 0px; padding: 0px; width: 982px; height: 27px;
                background: url('../images/MainMenu/MenuContentHeader.jpg') no-repeat;">
                <div align="Center">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
                        AsyncPostBackTimeout="0">
                    </asp:ScriptManager>
                    <telerik:RadMenu ID="RadMenu1" runat="server" Style="top: 0px; right: 0px">
                        <Items>
                            <telerik:RadMenuItem runat="server" Owner="RadMenu1" Text="وسائط عرض مرئية">
                                <Items>
                                    <telerik:RadMenuItem runat="server" Text="معرض الفيديو">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/ImagesGallery.aspx"
                                        Text="معرض الصور">
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Text="التقارير">
                                <Items>
                                    <telerik:RadMenuItem runat="server" Text="تقارير البيانات الوصفية">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="دليل عناصر شبكة الطرق" NavigateUrl="~/ASPX/Reports/ReportIntersectionInfo.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="المقاطع" NavigateUrl="~/ASPX/Reports/SectionsInfoReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="التقاطعات" NavigateUrl="~/ASPX/Reports/IntersectInfoReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="مناطق الشوارع الفرعية" NavigateUrl="~/ASPX/Reports/SecondaryStInfoReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="العينات" NavigateUrl="~/ASPX/Reports/LaneSamplesInfoReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="الجسور والأنفاق *" NavigateUrl="~/ASPX/Reports/BridgesTunnelsInfoReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="إجمالي العلامات الوصفية" NavigateUrl="~/ASPX/Reports/RoadPartsCountReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="الجولات الرقابية *" NavigateUrl="~/ASPX/Reports/MonitoringRoundsReport.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="المقاطع">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text=" العيوب" NavigateUrl="~/ASPX/Reports/SectionDistresses.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف" NavigateUrl="~/ASPX/Reports/PavementEvalSectionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="أولويات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تكلفة تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="نتائج العد المروري" NavigateUrl="~/ASPX/Reports/TrafficCountingOnSectionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="حالة الوعورة" NavigateUrl="~/ASPX/Reports/IRI_Report.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="اختبارات مقاومة الانزلاق" NavigateUrl="~/ASPX/Reports/SkidReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="نتائج قياس الحمل الساقط للشارع" NavigateUrl="~/ASPX/Reports/FWD_Reports.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قياس سماكات طبقات الرصف" NavigateUrl="~/ASPX/Reports/GPR_Report.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قياس تخدد طبقة الرصف" NavigateUrl="~/ASPX/Reports/RuttingReport.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="التقاطعات">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text=" العيوب" NavigateUrl="~/ASPX/Reports/IntersectionDistresses.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف" NavigateUrl="~/ASPX/Reports/PavementEvalIntersectionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="أولويات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تكلفة تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="حالة الوعورة" NavigateUrl="~/ASPX/Reports/IRI_Report.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="اختبارات مقاومة الانزلاق" NavigateUrl="~/ASPX/Reports/SkidReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قياس سماكات طبقات الرصف" NavigateUrl="~/ASPX/Reports/GPR_Report.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قياس تخدد طبقة الرصف" NavigateUrl="~/ASPX/Reports/RuttingReport.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="المناطق والشوارع الفرعية">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="العيوب" NavigateUrl="~/ASPX/Reports/RegionDistressesReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="أولويات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف" NavigateUrl="~/ASPX/Reports/PavementEvalRegionReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تكلفة تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="تقارير الرسوم البيانية">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="حالة رصف المساحات المسطحة لشبكة الطرق"
                                                NavigateUrl="../ASPX/Reports/PavementStatus.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="حالة رصف المساحات المسطحة للشوارع" NavigateUrl="../ASPX/Reports/ChartedPavementStatus.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="نماذج المسح" NavigateUrl="~/ASPX/Reports/SurveyingFormsReport.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="ضبط جودة المسوحات" NavigateUrl="~/ASPX/Reports/QcReports.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="التحسينات المرورية وأوامر الصيانة *" NavigateUrl="~/ASPX/Reports/TrafficEnhancesMaintOrdersReport.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="كميات المساحين">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="المسح المتأخر على المساحين - مقاطع، تقاطعات، مناطق"
                                                NavigateUrl="~/ASPX/Reports/SurveyorsLateWorkReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="إنتاج المساحين - مقاطع، تقاطعات، مناطق"
                                                NavigateUrl="~/ASPX/Reports/SurveyorsProductionReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="المسوحات ذات الملاحظات  - مقاطع، تقاطعات، مناطق"
                                                NavigateUrl="~/ASPX/Reports/SurveyorsNotesReport.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="الشوارع الممسوحة" NavigateUrl="~/ASPX/Reports/FinishedSurveyingReport.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="كميات العيوب على عناصر شبكة الطرق" NavigateUrl="~/ASPX/Reports/DistressQuantities.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف لكامل شبكة الطرق" NavigateUrl="~/ASPX/Reports/PavementStatusAllRoads.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="ميزانية تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/BudgetMaintDecisions.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="عمليات صيانة عناصر شبكة الطرق *" NavigateUrl="~/ASPX/Reports/FeedbackReports.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="مقارنة حالة الرصف عبر المسوحات" NavigateUrl="~/ASPX/Reports/UdiCompareReport.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="تقارير أخرى متنوعة" NavigateUrl="~/ASPX/Reports/ReportingOthers.aspx" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Owner="RadMenu1" Text="تقارير الخرائط" Visible="false">
                                <Items>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/MainStreetsUdiMap.aspx"
                                        Target="_blank" Text="حالة رصف الشوارع الرئيسية" />
                                    <telerik:RadMenuItem runat="server" Text="حالة رصف مناطق الشوارع الفرعية" NavigateUrl="~/ASPX/Reports/MapReports/RegionsUdiMap.aspx"
                                        Target="_blank" />
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/MainStMaintDecisionsMap.aspx"
                                        Target="_blank" Text="قرارات الصيانة للطرق الرئيسية" />
                                    <telerik:RadMenuItem runat="server" Text="قرارات الصيانة للشوارع الفرعية" NavigateUrl="~/ASPX/Reports/MapReports/RegionsSecondStMaintdecisionMap.aspx"
                                        Target="_blank" />
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/FwdMaps.aspx"
                                        Target="_blank" Text="حالة التقييم الإنشائي للطرق الرئيسية" />
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/IriMaps.aspx"
                                        Target="_blank" Text="حالة وعورة الطرق الرئيسية" />
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/SkidMaps.aspx"
                                        Target="_blank" Text=" مقاومة الانزلاق للشوارع الرئيسية" />
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/TrafficCountingMaps.aspx"
                                        Target="_blank" Text="العد المروري للشوارع الرئيسية" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Text="المساعدة">
                                <Items>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/JpmmsManual.pdf" Text="دليل المستخدم">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="../ASPX/Home/logout.aspx" Text="الخروج من النظام">
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenu>
                </div>
            </div>
        </td>
    </tr>
    <!--Main Menu Content Row End-->
</table>
<!--Header Table End -->
