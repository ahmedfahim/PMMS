<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="LandingMFV.aspx.cs" Inherits="ASPX_Archive_LandingMFV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Without
        {
            background-color: #555;
            color: Yellow;
            text-decoration: none;
            padding: 10px 21px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            width: 120px;
            top: 0px;
            right: 0px;
        }
        .Without:hover
        {
            background: none;
            color: black;
        }
        .notification
        {
            background-color: #555;
            color: white;
            text-decoration: none;
            padding: 10px 21px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            width: 120px;
            top: 0px;
            right: 0px;
        }
        
        .notification:hover
        {
            background: Aqua;
            color: Black;
        }
        
        .notification .badge
        {
            position: absolute;
            top: -10px;
            right: -10px;
            padding: 5px 10px;
            border-radius: 50%;
            background-color: red;
            color: white;
        }
        .notifyBall
        {
            display: block;
            -webkit-border-radius: 30px;
            -moz-border-radius: 30px;
            border-radius: 30px;
            background-color: #FFF;
            -webkit-box-shadow: 1px 1px 5px #808080;
            -moz-box-shadow: 1px 1px 5px #808080;
            box-shadow: 1px 1px 5px #808080;
            padding: 10px;
            width: 30px;
            height: 30px;
            margin: 0 auto;
            line-height: 30px;
            text-align: center;
            position: relative;
            -webkit-border-radius: 20px;
            -moz-border-radius: 20px;
            border-radius: 20px;
            border: 2px solid #FFF;
            width: 5px;
            height: 4px;
            background-color: #226598;
            position: relative;
            top: -25px;
            right: 30px;
            font-size: 10px;
            line-height: 7px;
            font-family: 'Roboto' , sans-serif;
            font-weight: 400;
            color: #FFF;
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..."  Style="padding: 10px;
                    position: fixed; top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="6" align="center">
                        <h2>
                            <asp:Label ID="Label1" runat="server" Text="الإدخال" Font-Italic="True" ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink27" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/FirstEquipment.aspx"
                            Target="_blank">
                            استلام الشوارع <span id="spanNewStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink31" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SevenEquipment.aspx"
                            Target="_blank">
                            شوارع لتحديث الادخال <span id="spanUpdateStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink44" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentEleven.aspx?AREA"
                            Target="_blank">
                            تحديث اطوال العينات <span id="spanSamplesAreaStreet" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink45" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/TwentyEquipment.aspx"
                            Target="_blank">
                            شوارع للادخال النهائي <span id="spanFinshStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink50" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DistressManuale.aspx"
                            Target="_blank">
                            عيوب تحتاج حذف <span id="spanDistressmanuale" runat="server" class="badge"></span>
                        </asp:HyperLink>
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
                        <asp:HyperLink ID="HyperLink75" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/SectionsErorrMainNO.aspx?IRI"
                            Target="_blank">
                            IRI مقاطع غير مطابقة <span id="spanSectionsMainNOIRI" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink76" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/SectionsErorrMainNO.aspx?DDF"
                            Target="_blank">
                            DDF مقاطع غير مطابقة <span id="spanSectionsMainNODDF" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink52" runat="server" CssClass="Without" NavigateUrl="~/aspx/Archive/TwentyEquipment.aspx?DID"
                            Target="_blank">
                            ادخال عيوب المعدة </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/ISEquipmentIRIDDF.aspx"
                            Target="_blank">
                            اعادة بالمعدة حذف <span id="spanDEquipStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink36" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentTen.aspx?IRI"
                            Target="_blank">
                            الحارات المكررة بالمعدة<span id="spanLaneDublicateIRI" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="6" align="center">
                        <h2>
                            <asp:Label ID="Label2" runat="server" Text="التحليل" Font-Italic="True" ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink29" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SecoundEquipment.aspx"
                            Target="_blank">
                            شوارع تحتاج للمراجعة <span id="spanEditStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink42" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/FourEquipment.aspx"
                            Target="_blank">
                            شوارع منتهية الرسم <span id="spanFDrawStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink28" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NinteenEquipment.aspx"
                            Target="_blank">
                            اعادة بالمعدة <span id="spanEquipStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentOne.aspx"
                            Target="_blank">
                            مقاطع المعدة والنظام</span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentTwo.aspx"
                            Target="_blank">
                           حارات المعدة والنظام </span>
                        </asp:HyperLink>
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
                        <asp:HyperLink ID="HyperLink13" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentEight.aspx"
                            Target="_blank">
                            العيوب مع حالة الوعورة</span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentTen.aspx"
                            Target="_blank">
                             الحارات المكررة لشارع</span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentSix.aspx"
                            Target="_blank">
                             العينات الناقصة لشارع </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink53" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentSeven.aspx"
                            Target="_blank">
                             العينات المكررة لشارع </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink54" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentSamples.aspx"
                            Target="_blank">
                            العينات الخطأ لشارع </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="6" align="center">
                        <h2>
                            <asp:Label ID="Label3" runat="server" Text="نظم المعلومات الجغرافية" Font-Italic="True"
                                ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink25" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentFiveteen.aspx"
                            Target="_blank">
                            إضافة الشوارع الجديدة<span id="spanNewStreetGIS" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink30" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/ThirdEquipment.aspx"
                            Target="_blank">
                            مقاطع تحتاج للرسم <span id="spanDrawStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink41" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsUpdate.aspx"
                            Target="_blank">
                            مقاطع ناقصة بيانات <span id="spanDrawUpdateStreet" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink40" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentSix.aspx?ALL"
                            Target="_blank">
                            العينات الناقصة <span id="spanMissSample" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink37" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentUpdateErorrIRI.aspx"
                            Target="_blank">
                            المقاطع الخطأ بالمعدة<span id="spanErorrIRI" runat="server" class="badge"></span>
                        </asp:HyperLink>
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
                        <asp:HyperLink ID="HyperLink34" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/LaneSectionsErorrs.aspx"
                            Target="_blank">
                            الحارات الخطأ بالمقاطع <span id="spanLaneSecErorr" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink35" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentTen.aspx?SYS"
                            Target="_blank">
                            الحارات المكررة بالنظام <span id="spanLaneDublicate" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink38" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentSeven.aspx?ALL"
                            Target="_blank">
                            العينات المكررة <span id="spanSampleDublicate" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink39" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentSamples.aspx?ALL"
                            Target="_blank">
                            العينات الخطأ <span id="spanLaneSampleErorr" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink56" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/StreetDeleted.aspx"
                            Target="_blank">
                            الشوارع المحذوفة <span id="spanStreetsDeleted" runat="server" class="badge"></span>
                        </asp:HyperLink>
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
                        <asp:HyperLink ID="HyperLink59" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/SectionsFromTO.aspx"
                            Target="_blank">
                            المقاطع من - الى <span id="spanSecFromTO" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink62" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/MainErorr.aspx"
                            Target="_blank">
                            الشوارع المكررة <span id="spanMainErorr" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink60" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/DeleteSecANDInterSec.aspx"
                            Target="_blank">
                             حذف مقطع او تقاطع </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink61" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentSectionsDetails.aspx"
                            Target="_blank">
                            تفاصيل مقاطع الشوارع <span></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink63" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/RoadesUdi.aspx"
                            Target="_blank">
                            تفاصيل حالة الشوارع <span></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="6" align="center">
                        <h2>
                            <asp:Label ID="Label4" runat="server" Text="مراجعة التحليل" Font-Italic="True" ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink43" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SixEquipment.aspx"
                            Target="_blank">
                            شوارع تحتاج ضبط جودة<span id="spanQDrawStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink15" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/EquipmentFourteen.aspx" Target="_blank">
                            اطوال المعده والنظام </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink16" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentEight.aspx"
                            Target="_blank">
                            العيوب مع حاله الوعورة </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink81" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/EquipmentTwo.aspx" Target="_blank">
                           حارات المعدة والنظام </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink17" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/EquipmentValidate.aspx?IRI" Target="_blank">
                            حالة الوعورة غير مكتمل </span>
                        </asp:HyperLink>
                        &nbsp;
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
                        <asp:HyperLink ID="HyperLink18" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/LaneSectionsErorrs.aspx" Target="_blank">
                            مراجعة الإدخال النهائي </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink0" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentSixsteen.aspx"
                            Target="_blank">
                            شوارع المسحة الثالث <span id="spanExiststStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentSixsteenNew.aspx"
                            Target="_blank">
                            شوارع المسحة الحالي <span id="spanExiststStreetNext" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink80" runat="server" CssClass="notification"
                            NavigateUrl="~/ASPX/Archive/EquipmentNotCompleted.aspx" Target="_blank">
                            شوارع غير مكتملة <span id="spanISNotComplete" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink55" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentOld.aspx"
                            Target="_blank">
                            الشوارع الغير محللة </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="notification" 
                            NavigateUrl="~/ASPX/Archive/EquipmentFiveteenValid.aspx" Target="_blank">
                            تأكيد الشوارع الجديدة <span id="spanGisStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink19" runat="server" CssClass="notification" 
                            NavigateUrl="~/ASPX/Archive/EquipmentNine.aspx" Target="_blank">
                            شوارع تحتاج تحديث<span id="spanStreetsErorr" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink82" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/EquipmentTwelve.aspx" Target="_blank">
                           أطوال الشوارع  </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink79" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/StatisticsWorkOrders.aspx" Target="_blank">
                           شوارع تحتاج لصيانة
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink78" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/AccessDBSample.aspx" Target="_blank">
                            معدة (ROMDAS)
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center" colspan="6">
                        <h2>
                            <asp:Label ID="Label5" runat="server" Font-Italic="True" ForeColor="#FF3300" Text="مراجعة الإدخال"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink77" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/UpdateIRIValidate.aspx"
                            Target="_blank">
                            مقاطع عدّلت IRI<span id="spanErorrData" runat="server" class="badge"> </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink49" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DeletedSamples.aspx"
                            Target="_blank">
                            عينات حذفت وبها عيوب <span id="spanMinStreetSampleDelete" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink48" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentDistress.aspx?MIN"
                            Target="_blank">
                            حساب قرارات الصيانة <span id="spanMinStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                        <asp:HyperLink ID="HyperLink58" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=IRIDDF"
                            Target="_blank">
                            شوارع تحتاج مستخلص 
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink83" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/RowDataEquipment.aspx" Target="_blank">
                            الممسوحة بكل المعدات </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
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
                        <asp:HyperLink ID="HyperLink46" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentDistress.aspx?DID"
                            Target="_blank">
                            مراجعة العيوب <span id="spanQDistrssStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink57" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrDistress.aspx?DDF"
                            Target="_blank">
                            مقاطع عدّلت وبها عيوب<span id="spanSectionsErorrDistress" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink47" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentDistress.aspx?UDI"
                            Target="_blank">
                            حساب حالة الرصف <span id="spanUdiStreet" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                        <asp:HyperLink ID="HyperLink51" runat="server" CssClass="Without" NavigateUrl="~/aspx/Archive/DeleteDistressStreets.aspx"
                            Target="_blank">
                            حذف عيوب المعدة </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
