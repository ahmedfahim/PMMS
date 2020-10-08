<%@ Page Title="تقرير بيانات المقاطع" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SectionsInfoReport.aspx.cs" Inherits="ASPX_Reports_SectionsInfoReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
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
            width: 15%;
        }
        .style11
        {
            font-weight: bold;
        }
        .style12
        {
            width: 15%;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    <b>تقرير بيانات المقاطع</b></h2>
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
            <td class="style3">
                &nbsp;
            </td>
            <td>
                &nbsp;
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
            <td class="style12">
                اسم الشارع الرئيسي
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style12">
                وصف المقطع
                <br />
                (يحتوي على)
            </td>
            <td>
                &nbsp;<asp:TextBox ID="txtSectionTitle" runat="server" Height="42px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style12">
                الاتجاه
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="ddlDirection" runat="server">
                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                    <asp:ListItem Value="N">شمال</asp:ListItem>
                    <asp:ListItem Value="S">جنوب</asp:ListItem>
                    <asp:ListItem Value="E">شرق</asp:ListItem>
                    <asp:ListItem Value="W">غرب</asp:ListItem>
                    <asp:ListItem Value="NE">شمال شرق</asp:ListItem>
                    <asp:ListItem Value="SE">جنوب شرق</asp:ListItem>
                    <asp:ListItem Value="NW">شمال غرب</asp:ListItem>
                    <asp:ListItem Value="SW">جنوب غرب</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style12">
                يحيط بالمنطقة
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                    ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <%--  <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radIslandConside" runat="server" AutoPostBack="True" GroupName="island"
                                Text="الأخذ في الاعتبار لبيانات الأرصفة" CssClass="style11" />
                        </td>
                        <td colspan="2">
                            <asp:RadioButton ID="radIslandIgnore" runat="server" AutoPostBack="True" GroupName="island"
                                Checked="True" Text="عدم الأخذ في الاعتبار " CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkMidIsland" runat="server" Text="جزيرة وسطية" AutoPostBack="True"
                                CssClass="style10" Checked="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkSideIsland" runat="server" Text="جزيرة فاصلة" AutoPostBack="True"
                                CssClass="style10" Checked="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkSideWalk" runat="server" Text="رصيف جانبي" AutoPostBack="True"
                                CssClass="style10" Checked="True" />
                        </td>
                        <td class="style10">
                            &nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radHasMidIsland" runat="server" AutoPostBack="True" GroupName="midisland"
                                Text="توجد جزيرة وسطية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radNotMidIsland" runat="server" AutoPostBack="True" GroupName="midisland"
                                Text="لاتوجد جزيرة وسطية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radMidIslandBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="midisland" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radHasSideIsland" runat="server" AutoPostBack="True" GroupName="sidisland"
                                Text="توجد جزيرة فاصلة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radNotSideIsland" runat="server" AutoPostBack="True" GroupName="sidisland"
                                Text="لاتوجد جزيرة فاصلة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radSideIslandBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="sidisland" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radHasSideCurb" runat="server" AutoPostBack="True" GroupName="sideCurb"
                                Text="يوجد رصيف جانبي" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radNotSideCurb" runat="server" AutoPostBack="True" GroupName="sideCurb"
                                Text="لايوجد رصيف جانبي" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radSideCurbBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="sideCurb" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radTreesConsider" runat="server" AutoPostBack="True" GroupName="trees"
                                Text="الأخذ في الاعتبار لبيانات التشجير" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radTreesIgnore" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="trees" Text="عدم الأخذ في الاعتبار " Style="font-weight: 700" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkAg_MID" runat="server" Text="جزيرة وسطية" Checked="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkAg_SID" runat="server" Text="جزيرة فاصلة" Checked="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkAg_SEC" runat="server" Text="رصيف جانبي" Checked="True" />
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 200px">
                            <asp:RadioButton ID="radUsesConsider" runat="server" AutoPostBack="True" GroupName="uses"
                                Text="الأخذ في الاعتبار لبيانات الاستخدامات المجاورة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radUsesIgnore" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="uses" Text="عدم الأخذ في الاعتبار " CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            <asp:CheckBox ID="ChkHousing" runat="server" Text="سكنية" Checked="True" />
                            <asp:CheckBox ID="ChkCommercial" runat="server" Text="تجارية" Checked="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkPublics" runat="server" Text="خدمية" Checked="True" />
                            <asp:CheckBox ID="ChkIndisterial" runat="server" Text="مناطق صيانة" Checked="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkGarden" runat="server" Text="حدائق ومنتزهات" Checked="True" />
                            <asp:CheckBox ID="ChkRest_House" runat="server" Text="استراحات" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            <asp:RadioButton ID="radHolesConsider" runat="server" AutoPostBack="True" GroupName="holes"
                                Text="الأخذ في الاعتبار لبيانات العلامات الأرضية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radHolesIgnore" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="holes" Text="عدم الأخذ في الاعتبار " CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:CheckBox ID="ChkDrinage_CBs" runat="server" Checked="true" AutoPostBack="True"
                                Text="مصائد تصريف سيول" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkDrinage_MH" runat="server" Checked="true" AutoPostBack="True"
                                Text="مناهل تصريف سيول" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkSTC_MH" runat="server" Checked="true" AutoPostBack="True" Text="مناهل هاتف" />
                            <asp:CheckBox ID="ChkElect_MH" runat="server" Checked="true" AutoPostBack="True"
                                Text="مناهل كهرباء" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkWater_MH" runat="server" AutoPostBack="True" Text="مناهل مياه"
                                Checked="True" />
                            <asp:CheckBox ID="ChkSewage_MH" runat="server" AutoPostBack="True" Text="مناهل صرف صحي"
                                Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            <asp:RadioButton ID="radDrillingsConsider" runat="server" AutoPostBack="True" GroupName="drills"
                                Text="الأخذ في الاعتبار لبيانات الحفريات الموجودة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radDrillingsIgnore" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="drills" Text="عدم الأخذ في الاعتبار " CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            <asp:CheckBox ID="chkDrillingSTC" runat="server" Checked="true" AutoPostBack="True"
                                Text="خدمات اتصالات" />
                            <asp:CheckBox ID="chkDrillingElec" runat="server" AutoPostBack="True" Checked="true"
                                Text="خدمات كهرباء" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkDrillingWater" runat="server" AutoPostBack="True" Checked="true"
                                Text="خدمات مياه" />
                            <asp:CheckBox ID="chkDrillingSewage" runat="server" AutoPostBack="True" Checked="true"
                                Text="خدمات صرف صحي" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            <asp:RadioButton ID="radSurveyed" runat="server" AutoPostBack="True" GroupName="dist"
                                Text="أجري له مسح عيوب" CssClass="style11" Checked="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radNotSurveyed" runat="server" AutoPostBack="True" GroupName="dist"
                                Text="لم يجرى له مسح عيوب" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radSurveyedBoth" runat="server" AutoPostBack="True" GroupName="dist"
                                Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 120px">
                            <asp:RadioButton ID="radSoilExists" runat="server" AutoPostBack="True" GroupName="soil"
                                Text="توجد أجزاء ترابية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radSoilNon" runat="server" AutoPostBack="True" GroupName="soil"
                                Text="لاتوجد أجزاء ترابية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radSoilBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="soil" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radLightingExists" runat="server" AutoPostBack="True" GroupName="light"
                                Text="توجد إنارة" CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radLightNon" runat="server" AutoPostBack="True" GroupName="light"
                                Text="لاتوجد إنارة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radLightBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="light" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radBridgesExists" runat="server" AutoPostBack="True" GroupName="bridge"
                                Text="توجد جسور" CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radBridgesNone" runat="server" AutoPostBack="True" GroupName="bridge"
                                Text="لاتوجد جسور" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radBridgesBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="bridge" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radTunnelExists" runat="server" AutoPostBack="True" GroupName="tunnel"
                                Text="توجد أنفاق" CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radTunnelNone" runat="server" AutoPostBack="True" GroupName="tunnel"
                                Text="لاتوجد أنفاق" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radTunnelBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="tunnel" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radPedestBridgeExists" runat="server" AutoPostBack="True" GroupName="pedest"
                                Text="توجد جسور مشاة" CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radPedestBridgeNotExists" runat="server" AutoPostBack="True"
                                GroupName="pedest" Text="لاتوجد جسور مشاة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radPedestBridgeBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="pedest" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radR4Is" runat="server" AutoPostBack="True" GroupName="r4" Text="المقطع مستحدث R4"
                                CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radNotR4" runat="server" AutoPostBack="True" GroupName="r4"
                                Text="المقطع غير مستحدث" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radR4Both" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="r4" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px" colspan="2">
                            في الفترة من
                            <telerik:RadDatePicker ID="rdtpFrom" runat="server">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td colspan="2">
                            إلى
                            <telerik:RadDatePicker ID="rdtpTo" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radIsR3" runat="server" AutoPostBack="True" GroupName="r3" Text="  المقطع مصان حديثا R3"
                                CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radNotR3" runat="server" AutoPostBack="True" GroupName="r3"
                                Text="المقطع غير مصان حديثا" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radR3Both" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="r3" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px" colspan="2">
                            في الفترة من
                            <telerik:RadDatePicker ID="rdtpR3From" runat="server">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td colspan="2">
                            إلى
                            <telerik:RadDatePicker ID="rdtpR3To" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px" colspan="4">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
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
