﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Header.ascx.vb" Inherits="Controls_Header" %>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<!--Header Table Start -->
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
    AsyncPostBackTimeout="0">
</asp:ScriptManager>
<div class="art-header">
    <br />
    <div class="art-header-jpeg">
    </div>
</div>
<telerik:RadMenu ID="RadMenu1" runat="server" Style="top: 0px; right: 0px">
    <Items>
        <telerik:RadMenuItem Text="البيانات العامة للطرق">
            <Items>
                <telerik:RadMenuItem runat="server" Text="البيانات العامة للطرق الرئيسية" NavigateUrl="~/ASPX/Sections/MainStreets.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="البيانات الوصفية للطرق ">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="مقاطع الطرق الرئيسية" NavigateUrl="../ASPX/Sections/SectionInfo.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="تقاطعات الطرق الرئيسية" NavigateUrl="../ASPX/Intersections/IntersectionInfo.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="المناطق والطرق الفرعية" NavigateUrl="~/ASPX/Regions/RegionInfo.aspx">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="بيانات عيوب الطرق">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="مقاطع الطرق الرئيسية" NavigateUrl="~/ASPX/Sections/SectionDistresses.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="تقاطعات الطرق الرئيسية" NavigateUrl="~/ASPX/Intersections/IntersectionDistresses.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="المناطق والطرق الفرعية" NavigateUrl="~/ASPX/Regions/Regiondistresses.aspx">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="بيانات الطرق المستحدثة *" NavigateUrl="~/ASPX/Sections/R4StreetsInfo.aspx">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="العمليات">
            <Items>
                <telerik:RadMenuItem Text="حدود التدخل لمعايير التقييم" NavigateUrl="~/ASPX/Lookups/MaintDecLimits.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="وحدة تكلفة قرارات الصيانة " NavigateUrl="~/ASPX/Lookups/MaintDecisions.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="أوزان معاملات اولويات الصيانة" NavigateUrl="~/ASPX/Lookups/MaintPrioWeights.aspx">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="تقييم حالة الرصف">
            <Items>
                <telerik:RadMenuItem runat="server" Text="معاملات تقييم حالة الرصف" NavigateUrl="~/ASPX/Lookups/UdiRates.aspx" />
                <telerik:RadMenuItem runat="server" Text="حساب حالة الرصف" NavigateUrl="~/ASPX/Operations/PavementStatusCalc.aspx">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="قرارات الصيانة">
            <Items>
                <telerik:RadMenuItem runat="server" Text="قرارات الصيانة لعناصر شبكة الطرق" NavigateUrl="~/ASPX/Operations/MaintenanceDecisionCalc.aspx" />
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="ميزانية وتكاليف الصيانة">
            <Items>
                <telerik:RadMenuItem runat="server" Text="ميزانية تكاليف كامل الشبكة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="ميزانية الصيانة بدون اوامر العمل الصادرة"
                    NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx?doing=1">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="تحديد أولويات الصيانة لميزانية محدودة"
                    NavigateUrl="~/ASPX/Reports/BudgetMaintDecisions.aspx">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
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
                        <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف" NavigateUrl="~/ASPX/Reports/PavementEvalRegionReport.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="أولويات الصيانة" NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx">
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
                <telerik:RadMenuItem runat="server" Text="الشوارع الممسوحة" NavigateUrl="~/ASPX/Reports/FinishedSurveyingReport.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="كميات العيوب على عناصر شبكة الطرق" NavigateUrl="~/ASPX/Reports/DistressQuantities.aspx" />
                <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف لكامل شبكة الطرق" NavigateUrl="~/ASPX/Reports/PavementStatusAllRoads.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="ميزانية تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/BudgetMaintDecisions.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="عمليات صيانة عناصر شبكة الطرق *" NavigateUrl="~/ASPX/Reports/FeedbackReports.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="مقارنة حالة الرصف عبر المسوحات" NavigateUrl="~/ASPX/Reports/UdiCompareReport.aspx" />
                <telerik:RadMenuItem runat="server" Text="تقارير أخرى متنوعة" NavigateUrl="~/ASPX/Reports/ReportingOthers.aspx">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Owner="RadMenu1" Text="تقارير الخرائط">
            <Items>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/MainStreetsUdiMap.aspx"
                    Target="_blank" Text="حالة رصف الشوارع الرئيسية">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="حالة رصف مناطق الشوارع الفرعية" NavigateUrl="~/ASPX/Reports/MapReports/RegionsUdiMap.aspx"
                    Target="_blank">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/MainStMaintDecisionsMap.aspx"
                    Target="_blank" Text="قرارات الصيانة للطرق الرئيسية">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="قرارات الصيانة للشوارع الفرعية" NavigateUrl="~/ASPX/Reports/MapReports/RegionsSecondStMaintdecisionMap.aspx"
                    Target="_blank">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/FwdMaps.aspx"
                    Target="_blank" Text="حالة التقييم الإنشائي للطرق الرئيسية">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/IriMaps.aspx"
                    Target="_blank" Text="حالة وعورة الطرق الرئيسية">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/SkidMaps.aspx"
                    Target="_blank" Text=" مقاومة الانزلاق للشوارع الرئيسية">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MapReports/TrafficCountingMaps.aspx"
                    Target="_blank" Text="العد المروري للشوارع الرئيسية">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="إدارة النظام">
            <Items>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Security/Users.aspx" Text="الصلاحيات والمستخدمين">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Security/ChangePassword.aspx"
                    Text="تغيير كلمة السر">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="إعدادات النظام">
                    <Items>
                        <telerik:RadMenuItem runat="server" NavigateUrl="../ASPX/Lookups/DistressTypes.aspx"
                            Text="انواع العيوب">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="../ASPX/Lookups/MaintDeciding.aspx"
                            Text="قرارات الصيانة للعيوب">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="وحدة تكلفة قرارات الصيانة " NavigateUrl="~/ASPX/Lookups/MaintDecisions.aspx">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="../ASPX/Lookups/Surveyors.aspx"
                            Text="المساحين">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Lookups/Contractors.aspx"
                            Text="المقاولين">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="../ASPX/Home/logout.aspx" Text="الخروج من النظام">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="...">
            <Items>
                <telerik:RadMenuItem runat="server" Text="ضبط الجودة">
                    <Items>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/QC/SectionsQC.aspx" Text="مقاطع طرق رئيسية">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/QC/IntersectQC.aspx" Text="تقاطعات طرق رئيسية">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/QC/RegionQC.aspx" Text="مناطق شوارع فرعية">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/SurveyingInfo/SyurveyQty.aspx"
                    Text="كمية المسح">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/MaintenanceOrders.aspx"
                    Text="أوامر العمل *">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/TrafficEnhances/SearchTrafficEnhances.aspx"
                    Text="التحسينات المرورية *">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Sections/DrillingPermitsIssue.aspx"
                    Text="رخص الحفريات على المقاطع *">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="البلاغات - حالة الرصف وقرارات الصيانة *"
                    NavigateUrl="~/ASPX/Operations/MaintDecUdi.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="مقارنة حالة رصف عناصر شبكة الطرق عبر المسوحات *"
                    NavigateUrl="~/ASPX/Operations/UdiCompare.aspx">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="عمليات صيانة عناصر شبكة الطرق *" NavigateUrl="~/ASPX/Operations/Feedbacks.aspx">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem Text="المساعدة">
            <Items>
                <telerik:RadMenuItem runat="server" NavigateUrl="~/JpmmsManual.pdf" Text="دليل المستخدم">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
    </Items>
</telerik:RadMenu>
