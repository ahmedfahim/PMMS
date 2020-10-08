<%@ Page Title="البيانات الوصفية لمقاطع الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SectionInfo.aspx.cs" Inherits="ASPX_Sections_SectionInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchMainSt.ascx" TagName="SearchMainSt" TagPrefix="uc1" %>
<%@ Register Src="../../ASCX/SearchSection.ascx" TagName="SearchSection" TagPrefix="uc2" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
            direction: rtl;
        }
        .style2
        {
            font-size: large;
            text-align: center;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 100%;
            font-size: medium;
        }
        .style5
        {
            font-weight: bold;
            direction: rtl;
        }
        .style6
        {
            width: 100%;
        }
        .style7
        {
            height: 245px;
        }
        .style8
        {
            font-size: small;
        }
        .style9
        {
            direction: rtl;
            font-size: medium;
        }
        .style10
        {
            font-size: small;
        }
        .style11
        {
            font-weight: bold;
            direction: rtl;
            font-size: small;
        }
        .style12
        {
            font-size: small;
            font-weight: bold;
        }
        .style13
        {
            text-align: right;
        }
        .style14
        {
            direction: rtl;
        }
        .style16
        {
            height: 22px;
        }
        .style17
        {
            width: 30%;
        }
        .style18
        {
            width: 40%;
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
                <strong style="text-align: center">مقاطع الطرق الرئيسية</strong>
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
            <td>
                &nbsp;
            </td>
            <td class="style2">
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
                <table align="center" class="style3">
                    <tr>
                        <td>
                            الطريق الرئيسي
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnSearchMainSt" runat="server" OnClick="lbtnSearchMainSt_Click"
                                ToolTip="بحث متقدم بجزء من اسم أو رقم الطريق الرئيسي">بحث متقدم</asp:LinkButton>
                        </td>
                        <td rowspan="5">
                            <uc1:SearchMainSt ID="SearchMainSt1" runat="server" Visible="false" OnSetSearchChanged="onMainStSearchChanged" />
                        </td>
                        <td rowspan="5">
                            <uc2:SearchSection ID="SearchSection1" runat="server" Visible="false" OnSetSearchChanged="onSectionSearchChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblOwnershipDetails" runat="server" ForeColor="#009900"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            المقاطع
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreetIntersections" DataTextField="section_from_to"
                                DataValueField="section_id" OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnSearchSection" runat="server" OnClick="lbtnSearchSection_Click"
                                ToolTip="بحث متقدم بجزء من اسم أو رقم المقطع">بحث متقدم</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">إلغاء</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsBridgeType" runat="server" SelectMethod="GetPedestrianBridgeTypes"
                                TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsMainStreetIntersections" runat="server" SelectMethod="GetMainStreetSections"
                                TypeName="JpmmsClasses.BL.MainStreetSection">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlSectionInfo" Visible="false" runat="server">
        <table class="style4">
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="lnkDetails" runat="server" OnClick="lnkDetails_Click">بيانات عامة</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkAg" runat="server" OnClick="lnkAg_Click">العلامات الأرضية والتشجير</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkIslands" runat="server" OnClick="lnkIslands_Click">الأرصفة والجزر</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkUses" runat="server" OnClick="lnkUses_Click">الاستخدامات المجاورة</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkLights" runat="server" OnClick="lnkLights_Click">الإنارة واللوحات </asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkBridges" runat="server" OnClick="lnkBridges_Click">الجسور والأنفاق</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkMainholes" runat="server" OnClick="lnkMainholes_Click">المناهل والمصائد</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkDrills" runat="server" OnClick="lnkDrills_Click">حفريات الخدمات</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkLaneSamples" runat="server" OnClick="lnkLaneSamples_Click">المسارات والعينات</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkSurveyor" runat="server" OnClick="lnkSurveyor_Click">تسليم المساح</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table class="style4">
                        <tr>
                            <td class="style12">
                                <span class="style10">البلدية الفرعية </span>
                            </td>
                            <td>
                                <span class="style8">
                                    <asp:Label ID="lblSubMunicip" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td style="font-size: small">
                                <b>الحي </b>
                            </td>
                            <td>
                                <asp:Label ID="lblDistrict" runat="server" Style="font-size: small"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblID" runat="server" Style="font-size: small" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr class="style8">
                            <td>
                                <b>رقم المقطع </b>
                            </td>
                            <td>
                                <asp:Label ID="lblSectionNo" runat="server"></asp:Label>
                            </td>
                            <td>
                                <b>&nbsp; </b>
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
                        <tr class="style8">
                            <td>
                                <b>الطريق الرئيسي </b>
                            </td>
                            <td>
                                <asp:Label ID="lblMainStName" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                            <td>
                                <b>من </b>
                            </td>
                            <td>
                                <asp:Label ID="lblSectionFrom" runat="server"></asp:Label>
                            </td>
                            <td>
                                <b>إلى</b>
                            </td>
                            <td>
                                <asp:Label ID="lblSectionTo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:HyperLink ID="lnkGallery" runat="server" Target="_blank" CssClass="style10">استعراض صور المقطع</asp:HyperLink>
                                <span class="style10">&nbsp; </span>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:MultiView ID="mlvSectionInfo" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <table class="style4">
                                <tr>
                                    <td class="style10">
                                        الاتجاه
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDirection" runat="server" CssClass="style10">
                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                            <asp:ListItem Value="N">شمال - N</asp:ListItem>
                                            <asp:ListItem Value="S">جنوب - S</asp:ListItem>
                                            <asp:ListItem Value="E">شرق - E</asp:ListItem>
                                            <asp:ListItem Value="W">غرب - W</asp:ListItem>
                                            <asp:ListItem Value="NE">شمال شرق - NE</asp:ListItem>
                                            <asp:ListItem Value="SE">جنوب شرق - SE</asp:ListItem>
                                            <asp:ListItem Value="NW">شمال غرب - NW</asp:ListItem>
                                            <asp:ListItem Value="SW">جنوب غرب - SW</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style10">
                                        الطول
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSectionLength" runat="server" AutoPostBack="True"
                                            DataType="System.Decimal" MinValue="0" OnTextChanged="rntxtSectionWidth_TextChanged">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td class="style10">
                                        العرض
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSectionWidth" runat="server" AutoPostBack="True"
                                            DataType="System.Decimal" MinValue="0" OnTextChanged="rntxtSectionWidth_TextChanged">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td class="style10">
                                        المساحة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSectionArea" runat="server" DataType="System.Decimal"
                                            MinValue="0" ReadOnly="True">
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="style8">
                                        <span class="style10">رقم تسلسل المقطع </span>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSectionOrder" runat="server" DataType="System.Int16"
                                            MaxValue="200" MinValue="0" Width="60px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <span class="style10">&nbsp; </span>
                                    </td>
                                    <td>
                                        <span class="style8">&nbsp; </span>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="style8">
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkR4" runat="server" AutoPostBack="True" OnCheckedChanged="chkR4_CheckedChanged"
                                            Text="الطريق مستحدث R4؟" />
                                    </td>
                                    <td>
                                        تاريخ الاستحداث
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="rdtpR4Date" runat="server" Enabled="False">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkR3" runat="server" AutoPostBack="True" Text="الطريق مصان حديثاً R3؟"
                                            OnCheckedChanged="chkR3_CheckedChanged" />
                                    </td>
                                    <td>
                                        تاريخ الصيانة
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="rdtpR3Date" runat="server" Enabled="False">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr class="style8">
                                    <td colspan="2">
                                        <span class="style10">
                                            <asp:CheckBox ID="chkPavedbyMunic" runat="server" AutoPostBack="True" Text="تم رصفه على حساب الأمانة" />
                                        </span>
                                    </td>
                                    <td colspan="3" valign="top">
                                        تفاصيل
                                        <asp:TextBox ID="txtNotpavedByDetails" runat="server" CssClass="style10" Height="66px"
                                            MaxLength="500" TextMode="MultiLine" Width="133px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <span class="style8"><span class="style10">
                                            <asp:CheckBox ID="chkOwnedByMunic" runat="server" AutoPostBack="True" Text="تعود ملكيته للأمانة" />
                                        </span></span>
                                    </td>
                                    <td colspan="2" valign="top">
                                        تفاصيل<asp:TextBox ID="txtOwnedByMunicDetails" runat="server" CssClass="style10"
                                            Height="66px" MaxLength="500" TextMode="MultiLine" Width="133px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="style8">
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td colspan="3" valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        تاريخ آخر مسح
                                    </td>
                                    <td colspan="2" valign="top">
                                        <telerik:RadDatePicker ID="rdtpSurveyDate" runat="server">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table width="50%">
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkSoilParts" runat="server" AutoPostBack="True" OnCheckedChanged="chkSoilParts_CheckedChanged"
                                            Text="أجزاء ترابية" Style="font-size: small" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        طول
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtUnpavedLength" runat="server" MinValue="0" DataType="System.Decimal">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="style10">عرض </span>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtUnpavedWidth" runat="server" MinValue="0" DataType="System.Decimal">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span class="style10">&nbsp; </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkPavemarkers" runat="server" AutoPostBack="True" OnCheckedChanged="chkPavemarkers_CheckedChanged"
                                            Style="font-size: small" Text="توجد علامات أرضية بين المسارات" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <asp:CheckBox ID="chkMarkerPaints" runat="server" CssClass="style8" Enabled="False"
                                            Text="دهانات" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMarkerCeramics" runat="server" CssClass="style8" Enabled="false"
                                            Text="سيراميك" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <span class="style8"></span><b><span class="style10">مكان التشجير</span></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:CheckBox ID="ChkAg_MID" runat="server" Text="جزيرة وسطية" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:CheckBox ID="ChkAg_SID" runat="server" Text="جزيرة فاصلة" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:CheckBox ID="ChkAg_SEC" runat="server" Text="رصيف جانبي" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <table class="style4">
                                <tr>
                                    <td class="style10">
                                        <b><span class="style10">الأرصفة والجزر </span></b>
                                    </td>
                                    <td class="style12" colspan="4">
                                        تقييم الأرصفة
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkMidIsland" runat="server" Text="جزيرة وسطية" OnCheckedChanged="ChkMidIsland_CheckedChanged"
                                            AutoPostBack="True" CssClass="style8" />
                                        <span class="style10">&nbsp;عرض </span>
                                        <telerik:RadNumericTextBox ID="rntxtMidIsWidth" runat="server" Enabled="false" MinValue="0"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td style="font-size: small">
                                        <asp:RadioButton ID="chkMidGood" runat="server" Enabled="False" GroupName="mid" Text="جيدة" />
                                    </td>
                                    <td colspan="2" style="font-size: small">
                                        <asp:RadioButton ID="chkMidFair" runat="server" Enabled="False" GroupName="mid" Text="متوسطة" />&nbsp;
                                        <asp:RadioButton ID="chkMidPoor" runat="server" Enabled="False" Text="سيئة" GroupName="mid" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkSideIsland" runat="server" Text="جزيرة فاصلة" OnCheckedChanged="ChkSideIsland_CheckedChanged"
                                            AutoPostBack="True" CssClass="style8" />
                                        <span class="style8">&nbsp;&nbsp; عرض </span>
                                        <telerik:RadNumericTextBox ID="rntxtSideIsWidth" runat="server" Enabled="False" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td style="font-size: small">
                                        <asp:RadioButton ID="chkSideLGood" runat="server" GroupName="sideL" Text="جيدة" />
                                    </td>
                                    <td colspan="2" style="font-size: small">
                                        <asp:RadioButton ID="chkSideLFair" runat="server" GroupName="sideL" Text="متوسطة" />
                                        &nbsp;
                                        <asp:RadioButton ID="chkSideLPoor" runat="server" GroupName="sideL" Text="سيئة" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkSideWalk" runat="server" Text="رصيف جانبي" AutoPostBack="True"
                                            OnCheckedChanged="ChkSideWalk_CheckedChanged" CssClass="style8" />
                                        <span class="style8">&nbsp; عرض </span>
                                        <telerik:RadNumericTextBox ID="rntxtSideWalkWidth" runat="server" Enabled="False"
                                            MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td style="font-size: small">
                                        <asp:RadioButton ID="chkSideGood" runat="server" GroupName="side" Text="جيدة" />
                                    </td>
                                    <td colspan="2" style="font-size: small">
                                        <asp:RadioButton ID="chkSideFair" runat="server" GroupName="side" Text="متوسطة" />
                                        &nbsp;
                                        <asp:RadioButton ID="chkSidePoor" runat="server" Text="سيئة" GroupName="side" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View4" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="3">
                                        <b><span class="style10">الاستخدامات المجاورة </span></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkHousing" runat="server" CssClass="style8" Text="سكنية" />&nbsp;&nbsp;
                                        &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkCommercial" runat="server" CssClass="style8" Text="تجارية" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkPublics" runat="server" CssClass="style8" Text="خدمية" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkGarden" runat="server" CssClass="style8" Text="حدائق ومنتزهات" />
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkRest_House" runat="server" CssClass="style8" Text="استراحات" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkIndisterial" runat="server" CssClass="style8" Text="مناطق صيانة" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View5" runat="server">
                            <table class="style4">
                                <tr>
                                    <td class="style12" colspan="5">
                                        الإنارة
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-size: small">
                                        <asp:CheckBox ID="ChkLight" runat="server" AutoPostBack="True" CssClass="style8"
                                            OnCheckedChanged="ChkLight_CheckedChanged" Style="direction: ltr" Text="توجد إنارة" />
                                        &nbsp; الموقع
                                        <asp:TextBox ID="txtLightLocation" runat="server" CssClass="style10" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="style8">
                                        جيد
                                    </td>
                                    <td>
                                        <span style="font-size: small">مقبول</span>
                                    </td>
                                    <td>
                                        <span style="font-size: small">سيء</span>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-size: small; text-align: left">
                                        &nbsp; &nbsp; العدد وفق الحالة
                                    </td>
                                    <td class="style8">
                                        <telerik:RadNumericTextBox ID="rntxtLightGood" runat="server" CssClass="style11"
                                            Width="40px" Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100"
                                            MinValue="0">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightFair" runat="server" CssClass="style11"
                                            Width="40px" Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100"
                                            MinValue="0">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightPoor" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr class="style8">
                                    <td>
                                        <asp:CheckBox ID="chkPropertyConflict" runat="server" Enabled="false" Text="موقع الإنارة متعارض مع الملكيات" />
                                    </td>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="5">
                                        &nbsp;عدد لوحات التحكم بالإنارة&nbsp;&nbsp;
                                        <telerik:RadNumericTextBox ID="rntxtLightControlsCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="5">
                                        &nbsp;عدد اللوحات الإعلانية MegaCom
                                        <telerik:RadNumericTextBox ID="rntxtMegacomCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                        <span><span class="style8">Moby </span></span><span class="style8"></span>
                                        <telerik:RadNumericTextBox ID="rntxtMobyCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                        UniPole
                                        <telerik:RadNumericTextBox ID="rntxtUnipoleCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        &nbsp;عدد اللوحات الإرشادية
                                        <telerik:RadNumericTextBox ID="rntxtGuideSignsCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td colspan="2">
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View6" runat="server">
                            <table width="40%">
                                <tr>
                                    <td class="style8" colspan="7">
                                        <asp:CheckBox ID="chkWalkerBridges" runat="server" AutoPostBack="True" OnCheckedChanged="chkWalkerBridges_CheckedChanged"
                                            Style="font-size: small" Text="توجد جسور مشاة؟" />
                                        &nbsp;&nbsp; النوع<asp:DropDownList ID="ddlwalkerBridgeType" runat="server" AppendDataBoundItems="True"
                                            DataSourceID="odsBridgeType" DataTextField="PEDESTRIAN_BRIDGE_TYPE" DataValueField="TYPE_ID"
                                            Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp; العدد
                                        <telerik:RadNumericTextBox ID="rntxtWalkerBridgesCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <strong class="style8">نوع حدود المقطع:</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        &nbsp;<span class="style8"><asp:CheckBox ID="ChkIntersection_TL" runat="server" Text="إشارة مرور" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:CheckBox ID="ChkIntersection_Open" runat="server" Text="دوار" />
                                            &nbsp;<asp:CheckBox ID="chkBorderOthers" runat="server" Text="أخرى" />
                                            &nbsp;</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:TextBox ID="txtSectionBorderType" runat="server" CssClass="style10" Enabled="False"
                                            MaxLength="150"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="2">
                                        <asp:CheckBox ID="chkMultilevel" runat="server" AutoPostBack="True" OnCheckedChanged="ChkLight_CheckedChanged"
                                            Style="direction: ltr" Text="متعدد المستويات؟" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="2">
                                        الجسور والأنفاق
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:CheckBox ID="chkBridges" runat="server" AutoPostBack="True" OnCheckedChanged="ChkTunnel_CheckedChanged"
                                            Text="توجد جسور " />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:CheckBox ID="ChkTunnel" runat="server" AutoPostBack="True" OnCheckedChanged="ChkTunnel_CheckedChanged"
                                            Text="توجد أنفاق" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="2">
                                        تفاصيل
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:TextBox ID="txtBrdg_TUNEL_TYPE" runat="server" CssClass="style10" Enabled="False"
                                            MaxLength="150"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8" colspan="2">
                                        <asp:HyperLink ID="hlnkBridges" runat="server" CssClass="style8" Target="_blank"
                                            Visible="False">بيانات جسور المقطع</asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="hlnkTunnels" runat="server" CssClass="style8" Target="_blank"
                                            Visible="False">بيانات أنفاق المقطع</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View7" runat="server">
                            <table class="style4">
                                <tr>
                                    <td class="style14">
                                        <b style="font-size: small">المناهل والمصائد</b>
                                    </td>
                                    <td colspan="5" class="style13">
                                        <b><span class="style8">العدد وفق الحالة</span></b>
                                    </td>
                                </tr>
                                <tr class="style8">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>جيد</b>
                                    </td>
                                    <td>
                                        <b>مقبول</b>
                                    </td>
                                    <td>
                                        <b>سيء</b>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>جيد</b>
                                    </td>
                                    <td>
                                        <b>مقبول</b>
                                    </td>
                                    <td>
                                        <b>سيء&nbsp; </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <span class="style10">
                                            <asp:CheckBox ID="ChkDrinage_CBs" runat="server" AutoPostBack="True" OnCheckedChanged="ChkDrinage_CBs_CheckedChanged"
                                                Style="font-weight: 700" Text="مصائد تصريف سيول" />
                                        </span>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBGood" runat="server" CssClass="style5"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBFair" runat="server" CssClass="style5"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBPoor" runat="server" CssClass="style5"
                                            MaxValue="100" Culture="ar-QA" DataType="System.Int16" Enabled="False" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                        <span class="style8">&nbsp; </span>
                                    </td>
                                    <td>
                                        <b><span class="style10">
                                            <asp:CheckBox ID="ChkElect_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkElect_MH_CheckedChanged"
                                                Text="مناهل كهرباء" />
                                        </span></b><span class="style10"></span>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_Good" runat="server" Culture="ar-QA"
                                                MaxValue="100" DataType="System.Int16" Enabled="False" MinValue="0" Width="40px"
                                                CssClass="style8">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_Fair" runat="server" Culture="ar-QA"
                                                MaxValue="100" DataType="System.Int16" Enabled="False" MinValue="0" Width="40px"
                                                CssClass="style8">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_Poor" runat="server" Culture="ar-QA"
                                                MaxValue="100" DataType="System.Int16" Enabled="False" MinValue="0" Width="40px"
                                                CssClass="style8">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <span class="style10">
                                            <asp:CheckBox ID="ChkDrinage_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkDrinage_MH_CheckedChanged"
                                                Style="font-weight: 700" Text="مناهل تصريف سيول" />
                                        </span>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MH_Good" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MH_Fair" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MH_Poor" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b><span class="style10">
                                            <asp:CheckBox ID="ChkSTC_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSTC_MH_CheckedChanged"
                                                Text="مناهل هاتف" />
                                        </span></b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_Good" runat="server" Culture="ar-QA" DataType="System.Int16"
                                            Enabled="False" MaxValue="100" MinValue="0" Width="40px" CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_Fair" runat="server" Culture="ar-QA" DataType="System.Int16"
                                            Enabled="False" MaxValue="100" MinValue="0" Width="40px" CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_Poor" runat="server" Culture="ar-QA" DataType="System.Int16"
                                            Enabled="False" MaxValue="100" MinValue="0" Width="40px" CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        <span class="style10">
                                            <asp:CheckBox ID="ChkSewage_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSewage_MH_CheckedChanged"
                                                Style="font-weight: 700" Text="مناهل صرف صحي" />
                                        </span>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_Good" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" MinValue="0" Width="40px" Enabled="False" MaxValue="100"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_Fair" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_Poor" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b><span class="style10">
                                            <asp:CheckBox ID="ChkWater_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkWater_MH_CheckedChanged"
                                                Text="مناهل مياه" />
                                        </span></b><span class="style10"></span>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_Good" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" MinValue="0" Width="40px" Enabled="False" MaxValue="100"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_Fair" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0" Width="40px"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_Poor" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0" Width="40px"
                                            CssClass="style8">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View8" runat="server">
                            <table class="style4">
                                <tr>
                                    <td class="style11" colspan="8">
                                        الحفريات القائمة
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="style10">
                                            <asp:CheckBox ID="chkDrillingSTC" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingSTC_CheckedChanged"
                                                Style="font-weight: 700" Text="خدمات اتصالات" />
                                        </span>
                                    </td>
                                    <td colspan="3" style="font-size: small">
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingSTC" runat="server" Culture="ar-QA" DataType="System.Int16"
                                            Enabled="False" MinValue="0" Width="125px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b><span class="style10">
                                            <asp:CheckBox ID="chkDrillingElec" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingElec_CheckedChanged"
                                                Text="خدمات كهرباء" />
                                        </span></b><span class="style10"></span>
                                    </td>
                                    <td colspan="3">
                                        <span class="style10">الطول </span>
                                        <telerik:RadNumericTextBox ID="rntxtDrillingElec" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" Enabled="False" MinValue="0" Width="125px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        <span class="style10">
                                            <asp:CheckBox ID="chkDrillingWater" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingWater_CheckedChanged"
                                                Style="font-weight: 700" Text="خدمات مياه" />
                                        </span>
                                    </td>
                                    <td colspan="3">
                                        <span class="style10">الطول </span>
                                        <telerik:RadNumericTextBox ID="rntxtDrillingWater" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" MinValue="0" Width="125px" Enabled="False">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b><span class="style10">
                                            <asp:CheckBox ID="chkDrillingSewage" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingSewage_CheckedChanged"
                                                Text="خدمات صرف صحي" />
                                        </span></b><span class="style10"></span>
                                    </td>
                                    <td colspan="3">
                                        <span class="style10">الطول </span>
                                        <telerik:RadNumericTextBox ID="rntxtDrillingSewage" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" MinValue="0" Width="125px" Enabled="False">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
            <tr>
                <td class="style10" colspan="8">
                    <asp:Label ID="lblFeedbackSave" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    <table width="40%" class="style18">
                        <tr>
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CssClass="style10" OnClick="UpdateButton_Click"
                                    Text="حفظ بيانات المقطع" />
                            </td>
                            <td>
                                <asp:Button ID="UpdateCancelButton" runat="server" CssClass="style10" OnClick="UpdateCancelButton_Click"
                                    Text="إلغاء" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="4">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table class="style4">
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlSurveyor" Visible="false" runat="server">
                    <b>تسليم المساح</b>
                    <br />
                    <table align="center" width="60%">
                        <tr>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="90%">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                المساح
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSurveyor" runat="server" AppendDataBoundItems="True" DataSourceID="odsSurveyors"
                                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" CssClass="style5">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                تاريخ الاستلام
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="raddtpIssueDate" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                تاريخ التسليم
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="raddtpDeliveryDate" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                رقم المسح
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtSurveyNo" runat="server" MinValue="0" Value="1"
                                    CssClass="style5">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                ملاحظات
                            </td>
                            <td>
                                <asp:TextBox ID="txtNotes" runat="server" Height="24px" TextMode="MultiLine" Width="50%"
                                    CssClass="style5"></asp:TextBox>
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
                                <table align="right" class="style4">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
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
                    </table>
                    <br />
                    <asp:GridView ID="gvSurveyorJob" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CssClass="style5" DataKeyNames="RECORD_ID" DataSourceID="odsSurveySubmitJobs"
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                            <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" SortExpression="RECORD_ID"
                                Visible="False" />
                            <%--  <asp:BoundField DataField="TITLE" HeaderText="النوع" ReadOnly="True" 
                                SortExpression="TITLE" />
                            <asp:BoundField DataField="NUM" HeaderText="الرقم" ReadOnly="True" 
                                SortExpression="NUM" />--%>
                            <asp:TemplateField HeaderText="اسم المساح" SortExpression="SURVEYOR_NAME">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSurveyor" runat="server" AppendDataBoundItems="True" DataSourceID="odsSurveyors"
                                        DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" SelectedValue='<%# Bind("SURVEYOR_ID") %>'>
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم المسح" SortExpression="SURVEY_NO">
                                <EditItemTemplate>
                                    <telerik:RadNumericTextBox ID="rntxtSurveyNo0" runat="server" DbValue='<%# Bind("SURVEY_NO") %>'
                                        MinValue="0" Width="60px">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الاستلام" SortExpression="ISSUE_DATE">
                                <EditItemTemplate>
                                    <telerik:RadDatePicker ID="raddtpIssueDate0" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("ISSUE_DATE", "{0:d}") %>'
                                        Width="150px">
                                    </telerik:RadDatePicker>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("ISSUE_DATE", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ التسليم" SortExpression="RECEIVE_DATE">
                                <EditItemTemplate>
                                    <telerik:RadDatePicker ID="raddtpDeliveryDate" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("RECEIVE_DATE", "{0:d}") %>'>
                                    </telerik:RadDatePicker>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("RECEIVE_DATE", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="تاريخ الاعتماد" SortExpression="ACCEPT_DATE">
                                <EditItemTemplate>
                                    <telerik:RadDatePicker ID="raddtpAcceptDate0" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("ACCEPT_DATE", "{0:d}") %>'
                                        Width="150px">
                                    </telerik:RadDatePicker>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("ACCEPT_DATE", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم المستخلص" SortExpression="MUSTUKHLAS_ID">
                                <EditItemTemplate>
                                    <telerik:RadNumericTextBox ID="rntxtMustakhlasNo0" runat="server" Culture="ar-QA"
                                        DataType="System.Double" DbValue='<%# Bind("MUSTUKHLAS_ID") %>' MinValue="0"
                                        Width="125px">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("MUSTUKHLAS_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="ملاحظات" SortExpression="NOTES">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("NOTES") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("NOTES") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsSurveySubmitJobs" runat="server" DeleteMethod="Delete"
                        OnDeleted="odsSurveySubmitJobs_Deleted" OnUpdated="odsSurveySubmitJobs_Updated"
                        SelectMethod="GetSectionSurveyingWork" TypeName="JpmmsClasses.BL.SurveyorSubmitJob"
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlMainStreetSection" Name="id" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="RECORD_ID" Type="Int32" />
                            <asp:Parameter Name="SURVEYOR_ID" Type="Int32" />
                            <asp:Parameter Name="ISSUE_DATE" Type="String" />
                            <asp:Parameter Name="RECEIVE_DATE" Type="String" />
                            <asp:Parameter Name="SURVEY_NO" Type="String" />
                            <asp:Parameter Name="notes" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSurveyors" runat="server" SelectMethod="GetAllsurveyors"
                        TypeName="JpmmsClasses.BL.Surveyor"></asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table class="style4">
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlSamplesLanes" Visible="false" runat="server">
                    <table class="style4">
                        <tr>
                            <td>
                                <h3 class="style10">
                                    <strong style="direction: ltr">
                                        <asp:ObjectDataSource ID="odsSpeedBumpTypes" runat="server" SelectMethod="GetSpeedBumpsTypes"
                                            TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                                        المسارات والعينات<asp:ObjectDataSource ID="odsSectionLanes" runat="server" OnUpdated="odsSectionLanes_Updated"
                                            SelectMethod="GetSectionLanes" TypeName="JpmmsClasses.BL.Lane" UpdateMethod="UpdateLaneInfo">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                                                    Type="Int32" />
                                            </SelectParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="LANE_LENGTH" Type="Double" />
                                                <asp:Parameter Name="LANE_WIDTH" Type="Double" />
                                                <asp:Parameter Name="SAMPLE_COUNT" Type="Int32" />
                                                <asp:Parameter Name="SAMPLE_AREA" Type="Double" />
                                                <asp:Parameter Name="LANE_ID" Type="Int32" />
                                            </UpdateParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="odsLaneSamples" runat="server" SelectMethod="GetLaneSamples"
                                            TypeName="JpmmsClasses.BL.LaneSample">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="gvLanes" Name="laneID" PropertyName="SelectedValue"
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="odsParkingMethods" runat="server" SelectMethod="GetAll"
                                            TypeName="JpmmsClasses.BL.Lookups.ParkingMethods"></asp:ObjectDataSource>
                                    </strong>
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7" valign="top">
                                &nbsp;
                                <asp:GridView ID="gvLanes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="style10" DataKeyNames="LANE_ID" DataSourceID="odsSectionLanes" ForeColor="#333333"
                                    GridLines="None" OnSelectedIndexChanged="gvLanes_SelectedIndexChanged" OnRowUpdating="gvLanes_RowUpdating">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:BoundField DataField="LANE_ID" HeaderText="LANE_ID" ReadOnly="True" SortExpression="LANE_ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="LANE_TYPE" HeaderText="نوع المسار" ReadOnly="True" SortExpression="LANE_TYPE" />
                                        <asp:TemplateField HeaderText="طول المسار" SortExpression="LANE_LENGTH">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Culture="ar-QA"
                                                    DataType="System.Double" DbValue='<%# Bind("LANE_LENGTH") %>' MinValue="0" Width="125px">
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadNumericTextBox1"
                                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="editlane"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LANE_LENGTH", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="عرض المسار" SortExpression="LANE_WIDTH">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Culture="ar-QA"
                                                    DataType="System.Double" DbValue='<%# Bind("LANE_WIDTH") %>' MinValue="0" Width="125px">
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadNumericTextBox2"
                                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="editlane"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("LANE_WIDTH", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="عدد العينات" SortExpression="SAMPLE_COUNT">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox3" runat="server" Culture="ar-QA"
                                                    DataType="System.Double" DbValue='<%# Bind("SAMPLE_COUNT") %>' MinValue="0" Width="125px">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadNumericTextBox3"
                                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="editlane"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SAMPLE_COUNT") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="مساحة العينات" SortExpression="SAMPLE_AREA">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox30" runat="server" Culture="ar-QA"
                                                    DataType="System.Double" DbValue='<%# Bind("SAMPLE_AREA") %>' MinValue="0" Width="125px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadNumericTextBox30"
                                                    ErrorMessage="الرجاء الإدخال" ValidationGroup="editlane"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("SAMPLE_AREA", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField SelectText="العينات" ShowSelectButton="True" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                </asp:GridView>
                                <b>
                                    <asp:GridView ID="gvLaneSamples" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        CssClass="style10" DataKeyNames="SAMPLE_ID" DataSourceID="odsLaneSamples" ForeColor="#333333"
                                        GridLines="None" OnSelectedIndexChanged="gvLaneSamples_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SAMPLE_ID" HeaderText="SAMPLE_ID" ReadOnly="True" SortExpression="SAMPLE_ID"
                                                Visible="False" />
                                            <asp:BoundField DataField="SAMPLE_NO" HeaderText="رقم العينة" ReadOnly="True" SortExpression="SAMPLE_NO" />
                                            <asp:BoundField DataField="SAMPLE_LENGTH" DataFormatString="{0:N2}" HeaderText="الطول"
                                                ReadOnly="True" SortExpression="SAMPLE_LENGTH" Visible="False" />
                                            <asp:BoundField DataField="SAMPLE_WIDTH" DataFormatString="{0:N2}" HeaderText="العرض"
                                                ReadOnly="True" SortExpression="SAMPLE_WIDTH" Visible="False" />
                                            <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" ReadOnly="True"
                                                SortExpression="AREA" />
                                            <asp:CommandField SelectText="التفاصيل" ShowSelectButton="True" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </b>
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlSampleInfo" runat="server" Visible="False">
                                    <table class="style6">
                                        <tr>
                                            <td class="style8">
                                                <b>رقم العينة
                                                    <asp:TextBox ID="rntxtSampleNo" runat="server" CssClass="style8"></asp:TextBox>
                                                </b>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td rowspan="3">
                                                <span class="style8">&nbsp; </span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span class="style10">
                                                    <br />
                                                </span>&nbsp; &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8" colspan="2">
                                                <b>الطول </b>
                                                <telerik:RadNumericTextBox ID="rntxtSampleLength" runat="server" AutoPostBack="True"
                                                    CssClass="style9" MinValue="0" OnTextChanged="rntxtSampleLength_TextChanged"
                                                    Width="50px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                                متر&nbsp;&nbsp; <b><span class="style8">العرض </span></b>
                                                <telerik:RadNumericTextBox ID="rntxtSampleWidth" runat="server" AutoPostBack="True"
                                                    CssClass="style9" MinValue="0" OnTextChanged="rntxtSampleLength_TextChanged"
                                                    Width="50px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                                متر&nbsp;&nbsp;&nbsp; <b><span class="style8">المساحة </span></b>
                                                <telerik:RadNumericTextBox ID="rntxtSampleArea" runat="server" AutoPostBack="True"
                                                    CssClass="style9" MinValue="0" ReadOnly="True" Width="50px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                                م2
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style10" colspan="2">
                                                <span class="style10">
                                                    <asp:CheckBox ID="chkSpeedBumps" runat="server" AutoPostBack="True" CssClass="style5"
                                                        OnCheckedChanged="chkSpeedBumps_CheckedChanged" Text="توجد مطبات صناعية" />
                                                    &nbsp;
                                                    <asp:CheckBox ID="chkLegal" runat="server" AutoPostBack="True" Enabled="False" Text="نظامية" />
                                                    &nbsp; <span class="style8">
                                                        <asp:CheckBox ID="chkIllegal" runat="server" AutoPostBack="True" Enabled="False"
                                                            Text="غير نظامية" />
                                                        &nbsp;&nbsp; العدد
                                                        <telerik:RadNumericTextBox ID="rntxtSpeedBumpsCount" runat="server" AutoPostBack="True"
                                                            Enabled="False" MinValue="0" Width="50px">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                        &nbsp; النوع<asp:DropDownList ID="ddlSpeedBumpType" runat="server" DataSourceID="odsSpeedBumpTypes"
                                                            DataTextField="SPEED_BUMP_TYPE" DataValueField="SPEED_BUMP_TYPE_ID" AppendDataBoundItems="True"
                                                            Enabled="False">
                                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </span></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style10" colspan="3">
                                                <asp:Panel ID="pnlConcBlocks" runat="server" Visible="False">
                                                    <span class="style10">
                                                        <asp:CheckBox ID="chkConcreteBlocks" runat="server" AutoPostBack="True" OnCheckedChanged="chkConcreteBlocks_CheckedChanged"
                                                            Style="font-weight: 700" Text="توجد حواجز خرسانية مؤقتة" />
                                                        &nbsp;&nbsp; العدد
                                                        <telerik:RadNumericTextBox ID="rntxtConcreteBlocks" runat="server" AutoPostBack="True"
                                                            Enabled="False" MinValue="0" Width="50px">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </span>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style10" colspan="3">
                                                <asp:Panel runat="server" ID="pnlServiceMainOpening" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:CheckBox ID="chkOpening" runat="server" AutoPostBack="True" CssClass="style8"
                                                                    OnCheckedChanged="chkHasOpening_CheckedChanged" Style="font-weight: 700" Text="توجد فتحة بين الطريق الرئيسي وطريق الخدمة" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style10">
                                                                الطول
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="rntxtOpeningLength" runat="server" AutoPostBack="True"
                                                                    Enabled="False" MinValue="0" Width="50px">
                                                                    <NumberFormat DecimalDigits="2" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td class="style10">
                                                                العرض
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="rntxtOpeningWidth" runat="server" AutoPostBack="True"
                                                                    Enabled="False" MinValue="0" Width="50px">
                                                                    <NumberFormat DecimalDigits="2" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <span class="style10">&nbsp; </span>
                                                            </td>
                                                            <td class="style8">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlParking" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td class="style10" colspan="2">
                                                                <span class="style10">
                                                                    <asp:CheckBox ID="chkParking" runat="server" AutoPostBack="True" CssClass="style5"
                                                                        OnCheckedChanged="chkParking_CheckedChanged" Text="العينة موقف" />
                                                                </span>
                                                            </td>
                                                            <td class="style10">
                                                                نمط الوقوف
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlParkingMethods" runat="server" AppendDataBoundItems="True"
                                                                    CssClass="style10" DataSourceID="odsParkingMethods" DataTextField="PARKING_METHOD"
                                                                    DataValueField="PARKING_METHOD_ID" Enabled="False">
                                                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlUTurn" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td class="style10" colspan="2">
                                                                <asp:CheckBox ID="chkUTurn" runat="server" AutoPostBack="True" OnCheckedChanged="chkUTurn_CheckedChanged"
                                                                    Style="font-weight: 700" Text="توجد فتحة دوران U-Turn" />
                                                            </td>
                                                            <td colspan="2">
                                                                <span class="style10">الطول </span><span class="style8"></span>
                                                                <telerik:RadNumericTextBox ID="rntxtUTurnLength" runat="server" AutoPostBack="True"
                                                                    Enabled="False" MinValue="0" Width="50px">
                                                                    <NumberFormat DecimalDigits="2" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td colspan="2">
                                                                <span class="style10">العرض </span>
                                                                <telerik:RadNumericTextBox ID="rntxtUTurnWidth" runat="server" AutoPostBack="True"
                                                                    Enabled="False" MinValue="0" Width="50px">
                                                                    <NumberFormat DecimalDigits="2" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlPaint" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td class="style10" colspan="2">
                                                                <asp:CheckBox ID="chkSidewalkPainted" runat="server" AutoPostBack="True" CssClass="style5"
                                                                    OnCheckedChanged="chkSidewalkPainted_CheckedChanged" Text="يوجد دهان للأرصفة" />
                                                            </td>
                                                            <td class="style10" colspan="2">
                                                                <asp:CheckBox ID="chkSidewalkPaintGood" runat="server" AutoPostBack="True" OnCheckedChanged="ChkLight_CheckedChanged"
                                                                    Text="دهان الأرصفة بحالة جيدة" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlPedestPass" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td class="style10">
                                                                <asp:CheckBox ID="chkPedestrain" runat="server" AutoPostBack="True" CssClass="style5"
                                                                    OnCheckedChanged="chkPedestrain_CheckedChanged" Text="توجد عناصر مشاة" />
                                                            </td>
                                                            <td class="style10">
                                                                <asp:CheckBox ID="chkPedestrianGood" runat="server" AutoPostBack="True" Enabled="False"
                                                                    Text="عناصر المشاة بحالة جيدة" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlHandicapped" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td class="style10" colspan="2">
                                                                <asp:CheckBox ID="chkHandicappedSlopes" runat="server" AutoPostBack="True" CssClass="style5"
                                                                    OnCheckedChanged="chkhandicappedSlopes_CheckedChanged" Text="يوجد منحدرات معاقين" />
                                                            </td>
                                                            <td class="style10" colspan="2">
                                                                <asp:CheckBox ID="chkHandicappedSlopeGood" runat="server" AutoPostBack="True" Enabled="False"
                                                                    Text="منحدرات المعاقين بحالة جيدة" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="style16">
                                                <asp:Label ID="lblSampleFeedback" runat="server" CssClass="style8" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8" colspan="3">
                                                <table align="center" class="style17">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSaveSampleDetails" runat="server" CssClass="style8" OnClick="btnSaveSampleDetails_Click"
                                                                Text="حفظ بيانات العينة" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSampleSaveCancel" runat="server" CssClass="style8" OnClick="btnSampleSaveCancel_Click"
                                                                Text="إلغاء" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
