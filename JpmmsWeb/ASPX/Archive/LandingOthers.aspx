<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="LandingOthers.aspx.cs" Inherits="ASPX_Archive_LandingOthers" %>

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
                    <td colspan="4" align="center">
                        <h2>
                            <asp:Label ID="Label1" runat="server" Text="معدة الحمل الساقط" Font-Italic="True"
                                ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink57" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentValidate.aspx?FWD"
                            Target="_blank">
                            حارات غير موجوده بالنظام وموجودة بالمعدة <span id="spanValidateFWDLane" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink56" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotIn_FWD_GPR_SKID.aspx?FWD"
                            Target="_blank">
                            مقاطع غير موجوده بالنظام وموجودة بالمعدة <span id="spanValidateFWDSection" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SysNotIn_FWD_GPR_SKID.aspx?FWD"
                            Target="_blank">
                            مقاطع موجودة بالنظام وغير موجودة بالمعدة<span id="spanValidateFWD" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink75" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrMainNO.aspx?FWD"
                            Target="_blank">
                            مقاطع غير مطابقة للشارع<span id="spanSectionsMainNOFWD" runat="server" class="badge"></span>
                        </asp:HyperLink>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink68" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrDistress.aspx?FWD"
                            Target="_blank">
                            مقاطع عدّلت وبهاعيوب <span id="spanDistreesFWD" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink52" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/FinshedFWD.aspx"
                            Target="_blank">
                            الادخال النهائي <span id="spanFinshedFWD" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink55" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentFive.aspx"
                            Target="_blank">
                            مقاطع الحمل الساقط 
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink51" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/ReadyFWD.aspx"
                            Target="_blank">
                            معالجة الحمل الساقط 
                        </asp:HyperLink>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=FWD"
                            Target="_blank">
                            شوارع تحتاج مستخلص <span id="spanFWDNoReady" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink78" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentSectionsDetails.aspx?id=FWD"
                            Target="_blank">
                            تفاصيل شوارع المعده
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
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
                    <td colspan="4" align="center">
                        <h2>
                            <asp:Label ID="Label2" runat="server" Text="معدة مقاومة الإنزلاق" Font-Italic="True"
                                ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink64" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentValidate.aspx?SKID"
                            Target="_blank">
                            حارات غير موجوده بالنظام وموجودة بالمعدة <span id="spanValidateSKIDLane" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink65" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotIn_FWD_GPR_SKID.aspx?SKID"
                            Target="_blank">
                            مقاطع غير موجوده بالنظام وموجودة بالمعدة <span id="spanValidateSKIDSection" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SysNotIn_FWD_GPR_SKID.aspx?SKID"
                            Target="_blank">
                            مقاطع موجودة بالنظام وغير موجودة بالمعدة<span id="spanValidateSKID" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink76" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrMainNO.aspx?SKID"
                            Target="_blank">
                            مقاطع غير مطابقة للشارع<span id="spanSectionsMainNOSKID" runat="server" class="badge"></span>
                        </asp:HyperLink>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink69" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrDistress.aspx?SKID"
                            Target="_blank">
                            مقاطع عدّلت وبهاعيوب <span id="spanDistreesSKID" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink73" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/LanesDeletedDistress.aspx?SKID"
                            Target="_blank">
                            حارات عدّلت وبهاعيوب <span id="spanDistreesDeletedSKID" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentFour.aspx"
                            Target="_blank">
                             مقاطع مقاومة الإنزلاق 
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmenSKIDIRI.aspx?id=SKID"
                            Target="_blank">
                            تحتاج المسح بـ IRI <span id="spanIRISKID" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink71" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=SKID"
                            Target="_blank">
                            شوارع تحتاج مستخلص <span id="spanSKIDNoReady" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink54" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentTenSKID.aspx?id=ALL"
                            Target="_blank">
                            الحارات المكررة <span id="spanDublicateSKID" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink53" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentTwoSkid.aspx"
                            Target="_blank">
                             مقارنة المعدة والنظام 
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink79" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/MissingEquipment.aspx?id=SKID"
                            Target="_blank">
                            الشوارع الناقصة MFV <span id="spanMFVSKID" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="4" align="center">
                        <h2>
                            <asp:Label ID="Label3" runat="server" Text="معدة سماكات الطبقات " Font-Italic="True"
                                ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink63" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentValidate.aspx?GPR"
                            Target="_blank">
                            حارات غير موجوده بالنظام وموجودة بالمعدة <span id="spanValidateGPRLane" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink67" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotIn_FWD_GPR_SKID.aspx?GPR"
                            Target="_blank">
                            مقاطع غير موجوده بالنظام وموجودة بالمعدة <span id="spanValidateGPRSections" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SysNotIn_FWD_GPR_SKID.aspx?GPR"
                            Target="_blank">
                            مقاطع موجودة بالنظام وغير موجودة بالمعدة<span id="spanValidateGPR" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink77" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrMainNO.aspx?GPR"
                            Target="_blank">
                            مقاطع غير مطابقة للشارع<span id="spanSectionsMainNOGPR" runat="server" class="badge"></span>
                        </asp:HyperLink>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink70" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SectionsErorrDistress.aspx?GPR"
                            Target="_blank">
                            مقاطع عدّلت وبهاعيوب <span id="spanDistreesGPR" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink74" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/LanesDeletedDistress.aspx?GPR"
                            Target="_blank">
                            حارات عدّلت وبهاعيوب <span id="spanDistreesDeletedGPR" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink58" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentThree.aspx"
                            Target="_blank">
                            مقاطع سماكة الطبقات
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink82" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmenSKIDIRI.aspx?id=GPR"
                            Target="_blank">
                            تحتاج المسح بـ IRI <span id="spanIRIGPR" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink72" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=GPR"
                            Target="_blank">
                            شوارع تحتاج مستخلص <span id="spanGPRNoReady" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink60" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/EquipmentTenGPR.aspx?id=ALL"
                            Target="_blank">
                            الحارات المكررة <span id="spanDublicateGPR" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink61" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/EquipmentTwoGPR.aspx"
                            Target="_blank">
                            مقارنة المعدة والنظام 
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink80" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/MissingEquipment.aspx?id=GPR"
                            Target="_blank">
                            الشوارع الناقصة MFV <span id="spanMFVGPR" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="4" align="center">
                        <h2>
                            <asp:Label ID="Label4" runat="server" Text="أصول الطرق  الرئيسية " Font-Italic="True"
                                ForeColor="#FF3300"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/CompletedASSETES.aspx?ID=ASSETES"
                            Target="_blank">
                            مراجعة الأصول
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=ASSETES"
                            Target="_blank">
                            شوارع تحتاج مستخلص <span id="spanASSETESNoReady" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink81" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/MissingEquipment.aspx?id=ASSETES"
                            Target="_blank">
                            الشوارع الناقصة MFV <span id="spanMFVASSETS" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink83" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/CompletedASSETES.aspx"
                            Target="_blank">
                             مستخلصات غير مطابقة <span id="spanCompareASSETS" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
