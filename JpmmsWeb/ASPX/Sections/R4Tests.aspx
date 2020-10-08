<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="R4Tests.aspx.cs"
    Inherits="ASPX_Sections_R4Tests" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>اختبارات الطرق المحدثة</title>
    <link href="../../Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        div.img
        {
            margin: 2px;
            border: 1px solid #0000ff;
            height: auto;
            width: auto;
            float: left;
            text-align: center;
        }
        div.img img
        {
            display: inline;
            margin: 3px;
            border: 1px solid #ffffff;
        }
        div.img a:hover img
        {
            border: 1px solid #0000ff;
        }
        div.desc
        {
            text-align: center;
            font-weight: normal;
            width: 120px;
            margin: 2px;
        }
    </style>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
    <div>
        <div>
            <table align="center" cellpadding="0" cellspacing="0" style="width: 982px; border-collapse: collapse;
                margin-bottom: 0px;">
                <!--Upper Banner (Upper Menu) Start-->
                <tr>
                    <td class="TopBar">
                        <div class="UpperMenu">
                            <ul>
                                <li>
                                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ASPX/Home/Default.aspx" runat="server">الصفحة الرئيسية</asp:HyperLink></li>
                                <li><a href="http://www.jeddah.gov.sa/index.php">أمانة محافظة جدة</a></li>
                            </ul>
                        </div>
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
                                        <img id="Img1" runat="server" src="~/Images/Header/AmanaLogo.jpg" alt="أمانة محافظة جدة"
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
                                <!-- ../.. -->
                                <td style="width: 150px; height: 128px;" rowspan="2">
                                    <a href="http://www.jeddah.gov.sa/eServices/index.php">
                                        <img id="Img2" runat="server" src="~/Images/Header/eServices.jpg" alt="الخدمات الإلكترونية"
                                            title="الخدمات الإلكترونية" width="150" height="128" border="0" /></a>
                                </td>
                                <!--Left Cell (TagLine) End-->
                                <!--Left Cell (TagLine) End-->
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <!--Main Menu Row Start-->
                            <tr>
                                <td class="UpperBannerMainMenu" align="center" valign="bottom">
                                    <div style="width: 100%; height: 24px; border: 0px red solid; margin: 0px; padding: 0px;">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
                                            height: 24px">
                                            <tr>
                                                <td valign="top" colspan="4" width="136px" height="24px">
                                                    <%--<a class="headerbar" href="../ASPX/Home/Default.aspx" >
                                        الصفحة الرئيسية</a>--%>
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
                            background: url('../../images/MainMenu/MenuContentHeader.jpg') no-repeat;">
                        </div>
                    </td>
                </tr>
                <!--Main Menu Content Row End-->
            </table>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <telerik:RadMenu ID="RadMenu1" runat="server" Style="top: 0px; right: 0px">
                    <Items>
                        <%-- <telerik:RadMenuItem Text="الصفحة الرئيسية" NavigateUrl="../ASPX/Home/Default.aspx">
                        </telerik:RadMenuItem>--%>
                        <telerik:RadMenuItem Text="معلومات عامة">
                            <Items>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Sections/SectionInfo.aspx" Text="مقاطع الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Intersections/IntersectionInfo.aspx" Text="التقاطعات">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Regions/RegionInfo.aspx"
                                    Text="المناطق والشوارع الفرعية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Sections/R4StreetsInfo.aspx"
                                    Text="الطرق المستحدثة">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/ImagesGallery.aspx"
                                    Text="معرض صور شبكة الطرق">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="العيوب الطرقية">
                            <Items>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Sections/SectionDistresses.aspx" Text="العيوب الطرقية لمقاطع الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Intersections/IntersectionDistresses.aspx"
                                    Text="العيوب الطرقية لتقاطعات الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Regions/Regiondistresses.aspx"
                                    Text="العيوب الطرقية للمناطق والشوارع الفرعية">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="بيانات المسح">
                            <Items>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/SurveyingInfo/SurveyingInfo.aspx"
                                    Text="معلومات المسح">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/SurveyingInfo/SyurveyQty.aspx"
                                    Text="كميات المسح">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="تقييم حالة الرصف">
                            <Items>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Sections/UdiSections.aspx" Text="حالة الرصف لمقاطع الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Intersections/IntersectionUDI.aspx" Text="حالة الرصف لتقاطعات الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Regions/RegionsUDI.aspx" Text="حالة الرصف للمناطق والشوارع الفرعية">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="قرارات الصيانة">
                            <Items>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Sections/SectionMaintenanceDecisions.aspx"
                                    Text="قرارات الصيانة لمقاطع الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Intersections/IntersectsMaintenaceDecisions.aspx"
                                    Text="قرارات الصيانة لتقاطعات الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Regions/RegionsMaintenanceDecisions.aspx"
                                    Text="قرارات الصيانة للمناطق والشوارع الفرعية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="../ASPX/Operations/UDI.aspx" Text="قرارات الصيانة لكامل شبكة الطرق">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="أولويات الصيانة">
                            <Items>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Sections/SectionMaintenancePriorities.aspx"
                                    Text="أولويات  الصيانة لمقاطع الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Intersections/IntersectMaintenancePriorities.aspx"
                                    Text="أولويات  الصيانة لتقاطعات الطرق الرئيسية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Regions/RegionMaintenancePriorities.aspx"
                                    Text="أولويات  الصيانة للمناطق والشوارع الفرعية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="ضبط معاملات الأولوية للمقاطع">
                                    <Items>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Sections/SectionPriorityParameters.aspx"
                                            Text="المقاطع" />
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Intersections/IntersectionPriorityParams.aspx"
                                            Text="التقاطعات" />
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Regions/RegionPriorityParameters.aspx"
                                            Text="المناطق الفرعية" />
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="العمليات">
                            <Items>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/MaintenanceOrders.aspx"
                                    Text="اوامر الصيانة">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/TrafficEnhances.aspx"
                                    Text="التحسينات المرورية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Operations/MaintDecisionsPricing.aspx"
                                    Text="تقدير تكلفة تنفيذ قرارات الصيانة">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="إدارة النظام">
                            <Items>
                                <telerik:RadMenuItem NavigateUrl="../ASPX/Lookups/DistressTypes.aspx" Text="انواع العيوب">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem NavigateUrl="../ASPX/Lookups/Surveyors.aspx" Text="المساحين">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Lookups/Contractors.aspx"
                                    Text="المقاولين">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Lookups/Units.aspx" Text="وحدات القياس">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Lookups/Materials.aspx" Text="مواد تنفيذ قرارات الصيانة">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Lookups/MaintOperations.aspx"
                                    Text="عمليات تنفيذ قرارات الصيانة">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Security/Users.aspx" Text="المستخدمين وصلاحياتهم">
                                </telerik:RadMenuItem>
                                <%-- <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Home/ChangeLanguage.aspx"
                            Text="لغة النظام" meta:resourcekey="RadMenuItemResource32">
                        </telerik:RadMenuItem>--%>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="التقارير">
                            <Items>
                                <telerik:RadMenuItem Text="تقارير المعلومات العامة">
                                    <Items>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/SectionsInfoReport.aspx" Text="المقاطع">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/IntersectInfoReport.aspx" Text="التقاطعات">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/SecondaryStInfoReport.aspx" Text="المناطق والشوارع الفرعية">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/LaneSamplesInfoReport.aspx" Text="العينات">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/BridgesTunnelsInfoReport.aspx" Text="الجسور والأنفاق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="../ASPX/Reports/RoadPartsCountReport.aspx" Text="إجمالي العلامات الوصفية">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="../ASPX/Reports/MonitoringRoundsReport.aspx" Text="الجولات الرقابية">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="المقاطع">
                                    <Items>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/ReportSectionsInfo.aspx"
                                            Text="معلومات عامة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SectionDistresses.aspx"
                                            Text="معلومات العيوب">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/PavementEvalSectionsReport.aspx"
                                            Text="تقييم حالة الرصف">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/IRI_Report.aspx"
                                            Text="حالة الوعورة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx"
                                            Text="قرارات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx"
                                            Text="أولويات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx"
                                            Text="تكلفة تنفيذ قرارات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/TrafficCountingOnSectionsReport.aspx"
                                            Text="نتائج العد المروري">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SkidReport.aspx"
                                            Text="تصحيح معامل مقاومة الانزلاق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/FWD_Reports.aspx"
                                            Text="نتائج قياس التحمل الساقط للشارع">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/GPR_Report.aspx"
                                            Text="قياس سماكات طبقات الرصف">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" Text="قياس تخدد طبقة الرصف">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="التقاطعات">
                                    <Items>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/ReportIntersectionInfo.aspx" Text="معلومات عامة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/IntersectionDistresses.aspx" Text="معلومات العيوب">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/PavementEvalIntersectionsReport.aspx"
                                            Text="تقييم حالة الرصف">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx"
                                            Text="قرارات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx"
                                            Text="أولويات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx"
                                            Text="تكلفة تنفيذ قرارات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/IRI_Report.aspx" Text="حالة الوعورة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/SkidReport.aspx" Text="تصحيح معامل مقاومة الانزلاق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/GPR_Report.aspx" Text="قياس سماكات طبقات الرصف">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="المناطق والشوارع الفرعية">
                                    <Items>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/ReportSecondaryStreetsRegions.aspx"
                                            Text="معلومات عامة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/RegionDistressesReport.aspx" Text="معلومات العيوب">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/PavementEvalRegionReport.aspx" Text="تقييم حالة الرصف">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/MaintenanceDecisionsReport.aspx"
                                            Text="قرارات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/MaintenancePrioritiesReport.aspx"
                                            Text="أولويات الصيانة">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/MaintDecisionsCostingReport.aspx"
                                            Text="تكلفة تنفيذ قرارات الصيانة">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="تقارير الرسوم البيانية">
                                    <Items>
                                        <telerik:RadMenuItem NavigateUrl="../ASPX/Reports/PavementStatus.aspx" Text="حالة رصف المساحات المسطحة لشبكة الطرق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem NavigateUrl="../ASPX/Reports/ChartedPavementStatus.aspx" Text="حالة رصف المساحات المسطحة للشوارع">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenuItem>
                                <%--<telerik:RadMenuItem Text="الصيانة وجداول الكميات" NavigateUrl="~/ASPX/Reports/ViewBillOfQuantitiesReport.aspx" />--%>
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/CostingMaintDecisionsReport.aspx"
                                    Text="تكاليف تنفيذ قرارات الصيانة" />
                                <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/TrafficEnhancesMaintOrdersReport.aspx"
                                    Text="اوامر الصيانة والتحسينات المرورية">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="تقارير المسح">
                                    <Items>
                                        <telerik:RadMenuItem NavigateUrl="~/ASPX/Reports/SurveyorsLateWorkReport.aspx" Text="المسح المتأخر على المساحين - مقاطع، تقاطعات، مناطق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SurveyorsProductionReport.aspx"
                                            Owner="" Text="إنتاج المساحين - مقاطع، تقاطعات، مناطق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SurveyorsQtyDelivery.aspx"
                                            Owner="" Text="الكمية - التاريخ التسليم - مقاطع، تقاطعات، مناطق">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" NavigateUrl="~/ASPX/Reports/SurveyorsNotesReport.aspx"
                                            Owner="" Text="المسوحات ذات الملاحظات  - مقاطع، تقاطعات، مناطق">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem NavigateUrl="../ASPX/Home/logout.aspx" Text="خروج">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenu>
            </div>
            <table border="0" width="700" style="padding: 1px; background-position: bottom; background-repeat: repeat;"
                align="center">
                <tr>
                    <td valign="top" width="500" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="500" colspan="3">
                        <h3 style="text-align: center">
                            اختبارات الطرق المستحدثة</h3>
                    </td>
                </tr>
                <td valign="top" width="500">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TestID,R4ID"
                        DataSourceID="odsR4StreetsTest" EnableModelValidation="True" Caption="الاختبارات المضافة"
                        CellPadding="4" ForeColor="#333333" Width="500px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="if (confirm('هل تريد حذف هذا الاختبار؟')==false) return false;"
                                        Text="حذف"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TESTNAME" HeaderText="اسم الاختبار" SortExpression="TESTNAME" />
                            <asp:TemplateField HeaderText="الحالة" SortExpression="ISPASS">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" OnPreRender="Label1_PreRender" Text='<%# Bind("ISPASS") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ISPASS") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الملف" SortExpression="FILENAME">
                                <ItemTemplate>
                                    <a id="A1" runat="server" target="_blank" href='<%# "~/Uploads/"+ Eval("FILENAME") %>'>
                                        ...</a>
                                    <%-- <asp:HyperLink ID="HyperLink2" runat="server" 
                                    NavigateUrl='<%# Bind("FILENAME") %>'>اضغط هنا </asp:HyperLink>--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FILENAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="R4ID" HeaderText="R4ID" SortExpression="R4ID" Visible="False" />
                            <asp:BoundField DataField="TESTID" HeaderText="TESTID" SortExpression="TESTID" Visible="False" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataTemplate>
                            <span class="style1">لا توجد اختبارات مضافة</span>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
                <td>
                    <asp:ObjectDataSource ID="odsR4StreetsTestTypes" runat="server" TypeName="JpmmsClasses.BL.R4Streets"
                        SelectMethod="GetR4StreetTestTypes"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsR4StreetsTest0" runat="server" SelectMethod="GetR4StreetTest"
                        TypeName="JpmmsClasses.BL.R4Streets" DeleteMethod="DeleteTest" InsertMethod="InsertNewTest"
                        UpdateMethod="UpdateTest">
                        <DeleteParameters>
                            <asp:Parameter Name="R4ID" Type="Int32" />
                            <asp:Parameter Name="TestID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:QueryStringParameter Name="R4ID" QueryStringField="R4ID" Type="Int32" />
                            <asp:Parameter Name="TestID" Type="Int32" />
                            <asp:Parameter Name="FileName" Type="String" />
                            <asp:Parameter Name="IsPass" Type="Int32" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="R4ID" QueryStringField="R4ID" Type="Int32" />
                            <asp:ControlParameter ControlID="GridView1" Name="TestID" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="R4ID" Type="Int32" />
                            <asp:Parameter Name="TestID" Type="Int32" />
                            <asp:Parameter Name="FileName" Type="String" />
                            <asp:Parameter Name="IsPass" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsR4StreetsTest" runat="server" SelectMethod="GetR4StreetTestList"
                        TypeName="JpmmsClasses.BL.R4Streets" DeleteMethod="DeleteTest">
                        <DeleteParameters>
                            <asp:Parameter Name="R4ID" Type="Int32" />
                            <asp:Parameter Name="TestID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="R4ID" QueryStringField="R4ID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td valign="top">
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="odsR4StreetsTest0" DefaultMode="Insert"
                        EnableModelValidation="True" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"
                        Caption="إضافة اختبار جديد" OnItemInserted="FormView1_ItemInserted" Width="320px">
                        <EditItemTemplate>
                            R4ID:
                            <asp:TextBox ID="R4IDTextBox" runat="server" Text='<%# Bind("R4ID") %>' />
                            <br />
                            TESTID:
                            <asp:TextBox ID="TESTIDTextBox" runat="server" Text='<%# Bind("TESTID") %>' />
                            <br />
                            ISPASS:
                            <asp:TextBox ID="ISPASSTextBox" runat="server" Text='<%# Bind("ISPASS") %>' />
                            <br />
                            FILENAME:
                            <asp:TextBox ID="FILENAMETextBox" runat="server" Text='<%# Bind("FILENAME") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        اسم الاختبار
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsR4StreetsTestTypes"
                                            DataTextField="TESTNAME" DataValueField="TESTID" SelectedValue='<%# Bind("TestID") %>'>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        الحالة:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("ISPASS") %>'>
                                            <asp:ListItem Value="1">ناجح</asp:ListItem>
                                            <asp:ListItem Value="0">راسب</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        تحديد الملف
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="updDistressImage" runat="server" />
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
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="تحميل الملف"
                                            ValidationGroup="save" Width="100px" />
                                        <asp:Label ID="lblOperation" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#C60000"></asp:Label>
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
                                        <asp:HiddenField ID="HFfileName" runat="server" Value='<%# Bind("FileName") %>' />
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
                                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                            Text="حفظ" />
                                        &nbsp;<asp:LinkButton ID="InsertButton0" runat="server" CausesValidation="True" CommandName="Cancel"
                                            Text="الغاء" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            R4ID:
                            <asp:Label ID="R4IDLabel" runat="server" Text='<%# Bind("R4ID") %>' />
                            <br />
                            TESTID:
                            <asp:Label ID="TESTIDLabel" runat="server" Text='<%# Bind("TESTID") %>' />
                            <br />
                            ISPASS:
                            <asp:Label ID="ISPASSLabel" runat="server" Text='<%# Bind("ISPASS") %>' />
                            <br />
                            FILENAME:
                            <asp:Label ID="FILENAMELabel" runat="server" Text='<%# Bind("FILENAME") %>' />
                            <br />
                        </ItemTemplate>
                    </asp:FormView>
                    </tr>
                    <tr>
                        <td valign="top" width="500">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td valign="top">
                        &nbsp;</tr>
                    </tr>
                    <tr>
                        <td valign="top" width="500" colspan="3">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    </table>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    </div>
</body>
</html>
