<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Header.ascx.vb" Inherits="Controls_Header" %>
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
                    <li><a id="A2" href="~" runat="server">الصفحة الرئيسية</a></li>
                    <li><a href="http://www.jeddah.gov.sa/index.php">أمانة محافظة جدة</a></li>
                    <li><a id="A1" href="~/JpmmsManual.pdf" target="_blank" runat="server">المساعدة</a></li>
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
                            <img src="../Images/AmanahLogo.png" runat="server" alt="أمانة محافظة جدة" title="أمانة محافظة جدة"
                                width="130" height="128" border="0" /></a>
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
                            <img src="~/Images/Header/eServices.jpg" runat="server" alt="الخدمات الإلكترونية"
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
                                    <telerik:RadMenuItem Text="ضبط الجودة">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="إدخال الجودة">
                                                <Items>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/QC/SectionsQC.aspx" Text="مقاطع طرق رئيسية">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/QC/IntersectQC.aspx" Text="تقاطعات طرق رئيسية">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/QC/RegionQC.aspx" Text="مناطق شوارع فرعية">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="المسح القديم">
                                                <Items>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultQcOld.aspx"
                                                        Text=" ضبط الجودة ">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultQcOldStreet.aspx"
                                                        Text="مساحة الشوارع">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="المسح البصري">
                                                <Items>
                                                    <%--   <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/default.aspx" Text="استلام المناطق">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/ChangeSecoundST.aspx"
                                                Text="تعديل العينات">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="نماذج المسح" NavigateUrl="~/ASPX/Reports/SurveyingFormsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/defaultTables.aspx"
                                                Text="جداول المسح">
                                            </telerik:RadMenuItem>--%>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/InsertStreet.aspx"
                                                        Text="شارع جديد">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/InsertFile.aspx"
                                                        Text="الملفات">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/UniqeStreets.aspx"
                                                        Text="الأرقام الفريدة">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SurveyingReport.aspx"
                                                        Text="شوارع  جاري العمل عليها">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/InsertGis.aspx" Text="ملفات المسح الجغرافي">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultQcUdi.aspx"
                                                        Text=" مراجعه شوارع حالة الرصف">
                                                    </telerik:RadMenuItem>
                                                    <%--   <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/ReportsQCUpdated.aspx"
                                                Text="إدخال التقرير الشهري">
                                            </telerik:RadMenuItem>
                                          <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultRegions.aspx"
                                                Text="المناطق القابلة للمسح">
                                            </telerik:RadMenuItem>--%>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <%--  <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/RegionsErorr.aspx"
                                        Text="المناطق المكررة">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/ReportsQC.aspx" Text="إستعراض التقرير الشهري ">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/UniqeStreets.aspx"
                                        Text="الأرقام الفريدة">
                                    </telerik:RadMenuItem>--%>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultStatisics.aspx"
                                                Text="احصائيات">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/InsertQuality.aspx"
                                                Text="ملفات ضبط الجودة">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultQuality.aspx"
                                                Text="استلام ضبط الجودة">
                                            </telerik:RadMenuItem>
                                            <%--  <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DataEntryFinshed.aspx"
                                        Text="مدخلين البيانات">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DataEntryNotFinshed.aspx"
                                        Text="مناطق  جاري العمل عليها">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DataEntryReviewed.aspx"
                                        Text="مراجعه وتدقيق البيانات">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/ReportReview.aspx"
                                        Text="مراجعه حالة الرصف وقرارات الصيانة">
                                    </telerik:RadMenuItem>--%>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Owner="RadMenu1" Text="المستخلصات">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="تقارير أخرى متنوعة" NavigateUrl="~/ASPX/Reports/ReportingOthers.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="شوارع تحتاج مستخلص" NavigateUrl="~/ASPX/Archive/DefaultMissClearance.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="تقاطعات الطرق الرئيسية">
                                                <Items>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DefaultClearance.aspx"
                                                        Text="ملخص تقاطعات الطرق">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/PavementEvalIntersectionsReport.aspx"
                                                        Text="تقرير تقيم تقاطعات الطرق">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="سماكه الطبقات">
                                                <Items>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentGPR.aspx"
                                                        Text="ملخص سماكات طبقات الرصف">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/GPR_Report.aspx"
                                                        Text="تقرير سماكات طبقات الرصف">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="الحمل الساقط">
                                                <Items>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentFWD.aspx"
                                                        Text="ملخص قياس الحمل الساقط">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/FWD_Reports.aspx"
                                                        Text="تقرير قياس الحمل الساقط ">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="مقاومة الانزلاق">
                                                <Items>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentSKID.aspx"
                                                        Text="ملخص اختبارات مقاومة الانزلاق">
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SkidReport.aspx"
                                                        Text="تقرير اختبارات مقاومة الانزلاق">
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="معدة MFV متعددة المهام">
                                                <Items>
                                                    <telerik:RadMenuItem Text="الأصول">
                                                        <Items>
                                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentASSETS.aspx"
                                                                Text="ملخص أصول الطرق الرئيسية">
                                                            </telerik:RadMenuItem>
                                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/AssetsReport.aspx"
                                                                Text="تقرير أصول الطرق الرئيسية">
                                                            </telerik:RadMenuItem>
                                                        </Items>
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem Text="حالة الوعورة">
                                                        <Items>
                                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentIRI.aspx"
                                                                Text="ملخص حالة الوعورة">
                                                            </telerik:RadMenuItem>
                                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/IRI_Report.aspx"
                                                                Text="تقرير حالة الوعورة">
                                                            </telerik:RadMenuItem>
                                                        </Items>
                                                    </telerik:RadMenuItem>
                                                    <telerik:RadMenuItem Text="العيوب">
                                                        <Items>
                                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentDDF.aspx"
                                                                Text="ملخص العيوب">
                                                            </telerik:RadMenuItem>
                                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/PavementEvalSectionsReport.aspx"
                                                                Text="تقرير تقييم حالة الرصف">
                                                            </telerik:RadMenuItem>
                                                        </Items>
                                                    </telerik:RadMenuItem>
                                                </Items>
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <%--         <telerik:RadMenuItem runat="server" Text="بيانات الطرق المستحدثة *" NavigateUrl="~/ASPX/Sections/R4StreetsInfo.aspx">
                                    </telerik:RadMenuItem>--%>
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem Text="حالة الرصف وقرارات الصيانة">
                                <Items>
                                    <telerik:RadMenuItem runat="server" Text="معاملات تقييم حالة الرصف" NavigateUrl="~/ASPX/Lookups/UdiRates.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="حساب حالة الرصف" NavigateUrl="~/ASPX/Operations/PavementStatusCalc.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="قرارات الصيانة لعناصر شبكة الطرق" NavigateUrl="~/ASPX/Operations/MaintenanceDecisionCalc.aspx" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Owner="RadMenu1" Text="الحالة العامة للطرق">
                                <Items>
                                    <telerik:RadMenuItem Text=" تحميل سريع بدون التنبيهات">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="متابعة أوامر العمل بدون تنبية" NavigateUrl="~/ASPX/Archive/LandingWorkOrder.aspx?Note=False">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text=" مقاطع الطرق الرئيسية بدون تنبية" NavigateUrl="~/ASPX/Archive/LandingMFV.aspx?Note=False">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text=" المناطق والطرق الفرعية بدون تنبية" NavigateUrl="~/ASPX/Archive/LandingRegions.aspx?Note=False">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="معدات اخرى بدون تنبية" NavigateUrl="~/ASPX/Archive/LandingOthers.aspx?Note=False">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text=" تقاطعات الطرق الرئيسية بدون تنبية" NavigateUrl="~/ASPX/Archive/LandingInterSections.aspx?Note=False">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem Text="تحميل عادى مع التنبيهات">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="متابعة أوامر العمل مع التنبية" NavigateUrl="~/ASPX/Archive/LandingWorkOrder.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text=" مقاطع الطرق الرئيسية مع التنبية" NavigateUrl="~/ASPX/Archive/LandingMFV.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text=" المناطق والطرق الفرعية مع التنبية" NavigateUrl="~/ASPX/Archive/LandingRegions.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="معدات اخرى  مع التنبية" NavigateUrl="~/ASPX/Archive/LandingOthers.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text=" تقاطعات الطرق الرئيسية مع تنبية" NavigateUrl="~/ASPX/Archive/LandingInterSections.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="النظم الجغرافية">
                                <Items>
                                    <telerik:RadMenuItem runat="server" Text="موقف الشوارع">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentSectionsDetails.aspx"
                                                Text="تفاصيل الشوارع الرئيسية">
                                            </telerik:RadMenuItem>
                                            <%--  <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/RowDataEquipment.aspx"
                                                Text="الشوارع الرئيسية الممسوحة بكل المعدات">
                                            </telerik:RadMenuItem>--%>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentThrteen.aspx"
                                                Text="الشوارع الرئيسية بالمعدة">
                                            </telerik:RadMenuItem>
                                            <%--      <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentTwelve.aspx"
                                                Text="الشوارع الرئيسية بالنظام">
                                            </telerik:RadMenuItem>--%>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/ThirdEquipment.aspx"
                                        Text="GIS الخرائط الجغرافية">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentDrawIRI.aspx"
                                        Text="GIS الرسم الجغرافي">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentFiveteen.aspx"
                                        Text="أضافة شارع جديد لدوره الإدخال">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/MainErorr.aspx" Text="الشوارع المكررة">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EightEquipment.aspx"
                                        Text="رسم الحارات">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/NineEquipment.aspx"
                                        Text="رسم العينات">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentSamples.aspx"
                                        Text="العينات الخطأ">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentSix.aspx"
                                        Text="العينات الناقصة">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentNine.aspx"
                                        Text="ربط المقاطع الجديده مع حاله الوعورة ">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/LaneSectionsErorrs.aspx"
                                        Text="حارات مربوطة خطأ بالمقاطع ">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentFourteen.aspx"
                                        Text="مراجعة أطوال المعده والنظام">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/EquipmentTwo.aspx"
                                        Text="مقارنة أطوال المعده والنظام   IRI" Target="_blank">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DeleteSections.aspx"
                                        Text="حذف المقاطع">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/DeleteInterSections.aspx"
                                        Text="حذف التقاطع">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Archive/SectionsFromTO.aspx"
                                        Text=" المقاطع من الي ">
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
                                            <%--     <telerik:RadMenuItem runat="server" Text="الجسور والأنفاق *" NavigateUrl="~/ASPX/Reports/BridgesTunnelsInfoReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="إجمالي العلامات الوصفية" NavigateUrl="~/ASPX/Reports/RoadPartsCountReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="الجولات الرقابية *" NavigateUrl="~/ASPX/Reports/MonitoringRoundsReport.aspx">
                                            </telerik:RadMenuItem>--%>
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
                                            <%--    <telerik:RadMenuItem runat="server" Text="تكلفة تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="نتائج العد المروري" NavigateUrl="~/ASPX/Reports/TrafficCountingOnSectionsReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قياس تخدد طبقة الرصف" NavigateUrl="~/ASPX/Reports/RuttingReport.aspx">
                                            </telerik:RadMenuItem>--%>
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
                                            <%-- <telerik:RadMenuItem runat="server" Text="تكلفة تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="قياس تخدد طبقة الرصف" NavigateUrl="~/ASPX/Reports/RuttingReport.aspx">
                                            </telerik:RadMenuItem>--%>
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
                                            <%-- <telerik:RadMenuItem runat="server" Text="تكلفة تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx">
                                            </telerik:RadMenuItem>--%>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <%-- <telerik:RadMenuItem runat="server" Text="تقارير الرسوم البيانية">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="حالة رصف المساحات المسطحة لشبكة الطرق"
                                                NavigateUrl="../ASPX/Reports/PavementStatus.aspx">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Text="حالة رصف المساحات المسطحة للشوارع" NavigateUrl="../ASPX/Reports/ChartedPavementStatus.aspx">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="ضبط جودة المسوحات" NavigateUrl="~/ASPX/Reports/QcReports.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="التحسينات المرورية وأوامر الصيانة *" NavigateUrl="~/ASPX/Reports/TrafficEnhancesMaintOrdersReport.aspx">
                                    </telerik:RadMenuItem>
                                    <%-- <telerik:RadMenuItem runat="server" Text="كميات المساحين">
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
                                    </telerik:RadMenuItem>--%>
                                    <telerik:RadMenuItem runat="server" Text="الشوارع الممسوحة" NavigateUrl="~/ASPX/Reports/FinishedSurveyingReport.aspx">
                                    </telerik:RadMenuItem>
                                    <%-- <telerik:RadMenuItem runat="server" Text="كميات العيوب على عناصر شبكة الطرق" NavigateUrl="~/ASPX/Reports/DistressQuantities.aspx" />
                                    <telerik:RadMenuItem runat="server" Text="تقييم حالة الرصف لكامل شبكة الطرق" NavigateUrl="~/ASPX/Reports/PavementStatusAllRoads.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="ميزانية تنفيذ قرارات الصيانة" NavigateUrl="~/ASPX/Reports/BudgetMaintDecisions.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="عمليات صيانة عناصر شبكة الطرق *" NavigateUrl="~/ASPX/Reports/FeedbackReports.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="مقارنة حالة الرصف عبر المسوحات" NavigateUrl="~/ASPX/Reports/UdiCompareReport.aspx" /> <telerik:RadMenuItem runat="server" Text="إنتاجية مناطق المسح الجغرافي" NavigateUrl="~/ASPX/Reports/ReportingOthersNEWsGis.aspx">
                                    </telerik:RadMenuItem>--%>
                                   <telerik:RadMenuItem runat="server" Text="إنتاجية الشوارع الممسوحة" NavigateUrl="~/ASPX/Reports/ReportingOthersNEWs.aspx">
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenuItem>
                            <%-- <telerik:RadMenuItem Text="العمليات">
                                <Items>
                                    <telerik:RadMenuItem Text="الميزانية والتكاليف">
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
                                    <telerik:RadMenuItem Text="حدود التدخل لمعايير التقييم" NavigateUrl="~/ASPX/Lookups/MaintDecLimits.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem Text="وحدة تكلفة قرارات الصيانة " NavigateUrl="~/ASPX/Lookups/MaintDecisions.aspx">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="أوزان معاملات اولويات الصيانة" NavigateUrl="~/ASPX/Lookups/MaintPrioWeights.aspx">
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenuItem>--%>
                            <telerik:RadMenuItem Text="إدارة النظام">
                                <Items>
                                    <%-- <telerik:RadMenuItem runat="server" Owner="RadMenu1" Text="المعرض">
                                        <Items>
                                            <telerik:RadMenuItem runat="server" Text="معرض الفيديو">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/ImagesGallery.aspx"
                                                Text="معرض الصور">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>--%>
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
                            <%--<telerik:RadMenuItem runat="server" Text="...">
                                <Items>
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
                            </telerik:RadMenuItem>--%>
                            <telerik:RadMenuItem Text="المساعدة">
                                <Items>
                                    <telerik:RadMenuItem runat="server" NavigateUrl="~/JpmmsManual.pdf" Text="دليل المستخدم">
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
