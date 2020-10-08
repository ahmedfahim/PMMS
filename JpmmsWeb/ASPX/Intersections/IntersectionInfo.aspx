<%@ Page Title="المعلومات الوصفية لتقاطعات الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IntersectionInfo.aspx.cs" Inherits="ASPX_Intersections_IntersectionInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchMainSt.ascx" TagName="SearchMainSt" TagPrefix="uc1" %>
<%@ Register Src="../../ASCX/SearchIntersect.ascx" TagName="SearchIntersect" TagPrefix="uc2" %>
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
            text-align: center;
            font-size: large;
        }
        .style3
        {
            width: 50%;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            font-weight: bold;
        }
        .style6
        {
            font-size: small;
        }
        .style8
        {
            font-size: small;
        }
        .style9
        {
            height: 26px;
        }
        .style10
        {
            text-align: right;
        }
        .RadPicker_Default
        {
            vertical-align: middle;
        }
        .RadPicker_Default table.rcTable .rcInputCell
        {
            padding: 0 4px 0 0;
        }
        .style11
        {
            width: 100%;
            vertical-align: middle;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin: 0;
            padding: 0;
        }
        .style13
        {
            text-align: center;
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
                <strong>تقاطعات الطرق الرئيسية</strong>
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
                            <telerik:RadComboBox ID="ddlMainStreets" runat="server" Filter="Contains" AutoselectFirstItem="True"
                                AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="odsMainStreets"
                                DataTextField="main_title" DataValueField="STREET_ID" Width="200px" OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged"
                                Font-Size="Medium">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnSearchMainSt" runat="server" OnClick="lbtnSearchMainSt_Click"
                                ToolTip="بحث متقدم بجزء من اسم أو رقم الطريق الرئيسي">بحث متقدم </asp:LinkButton>
                        </td>
                        <td rowspan="4">
                            <uc1:SearchMainSt ID="SearchMainSt1" runat="server" Visible="False" OnSetSearchChanged="onMainStSearchChanged" />
                        </td>
                        <td rowspan="4">
                            <uc2:SearchIntersect ID="SearchIntersect1" runat="server" Visible="False" OnSetSearchChanged="onIntersectSearchChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            التقاطعات
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainStreetIntersection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreetIntersections" DataTextField="intersection_title"
                                DataValueField="INTERSECTION_ID" OnSelectedIndexChanged="ddlMainStreetIntersection_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnSearchIntersect" runat="server" OnClick="lbtnSearchIntersect_Click"
                                ToolTip="بحث متقدم بجزء من اسم أو رقم التقاطع">بحث متقدم </asp:LinkButton>
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
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsMainStreetIntersections" runat="server" SelectMethod="GetMainStreetIntersections"
                                TypeName="JpmmsClasses.BL.Intersection">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsIntersectionTypes" runat="server" SelectMethod="GetAll"
                                TypeName="JpmmsClasses.BL.Lookups.IntersectType"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsIntersectControlTypes" runat="server" SelectMethod="GetAll"
                                TypeName="JpmmsClasses.BL.Lookups.IntersectControlType"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsSpeedBumpTypes" runat="server" SelectMethod="GetSpeedBumpsTypes"
                                TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <img alt="" src="../../Images/loading2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlLinks" runat="server" Visible="false">
                    <asp:LinkButton ID="lnkDetails" runat="server" OnClick="lnkDetails_Click">بيانات عامة</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkUses" runat="server" OnClick="lnkUses_Click">الاستخدامات المجاورة</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkIslands" runat="server" OnClick="lnkIslands_Click">الأرصفة والجزر</asp:LinkButton>&nbsp;
                    &nbsp;
                    <asp:LinkButton ID="lnkBridges" runat="server" OnClick="lnkBridges_Click">الجسور والأنفاق</asp:LinkButton>&nbsp;
                    &nbsp;
                    <asp:LinkButton ID="lnkLights" runat="server" OnClick="lnkLights_Click">الإنارة واللوحات </asp:LinkButton>&nbsp;
                    &nbsp;
                    <asp:LinkButton ID="lnkAg" runat="server" OnClick="lnkAg_Click">العلامات الأرضية والتشجير</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkMainholes" runat="server" OnClick="lnkMainholes_Click">المناهل والمصائد</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkDrills" runat="server" OnClick="lnkDrills_Click">حفريات الخدمات</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkSurveyor" runat="server" OnClick="lnkSurveyor_Click">تسليم المساح</asp:LinkButton>
                    <br />
                </asp:Panel>
                <asp:Panel ID="pnlIntersect" Visible="false" runat="server">
                    <asp:MultiView ID="mlvSectionInfo" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <table class="style4">
                                <tr>
                                    <td class="style12">
                                        <strong>رقم التقاطع: </strong>
                                        <asp:Label ID="lblIntersectNo" runat="server"></asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                    <td>
                                        <strong>الطريق الرئيسي:&nbsp; </strong>
                                        <asp:Label ID="lblIntersectStreet1" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <strong>مع الطريق الرئيسي: </strong>
                                        <asp:Label ID="lblIntersectStreet2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                        <asp:HyperLink ID="lnkGallery" Target="_blank" runat="server">استعراض صور التقاطع</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="3">
                                        تاريخ آخر مسح<telerik:RadDatePicker ID="rdtpSurveyDate" runat="server">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        طريقة التحكم بالتقاطع
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlIntersectControlTypes" runat="server" AppendDataBoundItems="True"
                                            Width="235px" DataSourceID="odsIntersectControlTypes" DataTextField="INTERSECT_CTRL_TYPE"
                                            DataValueField="INTERSECT_CTRL_TYPE_ID">
                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نوع التقاطع
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlIntersectTypes" runat="server" AppendDataBoundItems="True"
                                            AutoPostBack="True" DataSourceID="odsIntersectionTypes" DataTextField="INTERSECT_TYPE"
                                            DataValueField="INTERSECT_TYPE_ID" OnSelectedIndexChanged="ddlIntersectTypes_SelectedIndexChanged"
                                            Width="120px">
                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" style="direction: ltr">
                                        <asp:Image ID="imgIntersectType" runat="server" Height="300px" Width="400px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="9" style="text-align: center">
                                        <b>جهة الشارع الرئيسي&nbsp; </b>&nbsp; &nbsp;
                                    </td>
                                    <td colspan="10" style="text-align: center">
                                        <b>جهة الشارع الرئيسي المتقاطع </b>&nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>الاستخدامات المجاورة </b>
                                    </td>
                                    <td colspan="10">
                                        <b>الاستخدامات المجاورة </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkHousing" runat="server" Text="سكنية" />
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkCommercial" runat="server" Text="تجارية" />
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkPublics" runat="server" Text="خدمية" />
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkHousingIntersect" runat="server" Text="سكنية" />
                                    </td>
                                    <td colspan="5">
                                        <asp:CheckBox ID="ChkCommercialIntersect" runat="server" Text="تجارية" />
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="ChkPublicsIntersect" runat="server" Text="خدمية" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkGarden" runat="server" Text="حدائق ومنتزهات" />
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkRest_House" runat="server" Text="استراحات" />
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkIndisterial" runat="server" Text="مناطق صيانة" />
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkGardenIntersect" runat="server" Text="حدائق ومنتزهات" />
                                    </td>
                                    <td colspan="5">
                                        <asp:CheckBox ID="ChkRest_HouseIntersect" runat="server" Text="استراحات" />
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="ChkIndisterialIntersect" runat="server" Text="مناطق صيانة" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="5" style="text-align: center">
                                        <b>جهة الشارع الرئيسي&nbsp; </b>&nbsp; &nbsp;&nbsp;
                                    </td>
                                    <td colspan="5" style="text-align: center">
                                        <b>جهة الشارع الرئيسي المتقاطع </b>&nbsp; &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>العرض</b>&nbsp;
                                    </td>
                                    <td colspan="3">
                                        <b>تقييم الحالة</b>&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;<b>العرض</b>
                                    </td>
                                    <td colspan="3">
                                        <b>تقييم الحالة</b>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkMidIsland" runat="server" Text="جزيرة وسطية" OnCheckedChanged="ChkMidIsland_CheckedChanged"
                                            AutoPostBack="True" CssClass="style5" />
                                        &nbsp;
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtMidIsWidth" runat="server" Enabled="false" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkMidGood" runat="server" GroupName="mid" Text="جيدة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkMidFair" runat="server" GroupName="mid" Text="متوسطة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkMidPoor" runat="server" GroupName="mid" Text="سيئة" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkMidIslandIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkMidIslandIntersect_CheckedChanged" Text="جزيرة وسطية" />
                                        &nbsp;
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtMidIsWidthIntersect" runat="server" Enabled="false"
                                            MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkMidIntersectGood" runat="server" GroupName="midInter" Text="جيدة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkMidIntersectFair" runat="server" GroupName="midInter" Text="متوسطة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkMidIntersectPoor" runat="server" GroupName="midInter" Text="سيئة" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkSideIsland" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkSideIsland_CheckedChanged" Text="جزيرة فاصلة" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSideIsWidth" runat="server" Enabled="False" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSideLGood" runat="server" GroupName="sideL" Text="جيدة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSideLFair" runat="server" GroupName="sideL" Text="متوسطة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSideLPoor" runat="server" GroupName="sideL" Text="سيئة" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkSideIslandIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkSideIslandIntersect_CheckedChanged" Text="جزيرة فاصلة" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSideIsWidthIntersect" runat="server" Enabled="False"
                                            MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSideLGoodIntersect" runat="server" GroupName="sideLInter"
                                            Text="جيدة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSideLFairIntersect" runat="server" GroupName="sideLInter"
                                            Text="متوسطة" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSideLPoorIntersect" runat="server" GroupName="sideLInter"
                                            Text="سيئة" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style9">
                                        <asp:CheckBox ID="ChkSideWalk" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkSideWalk_CheckedChanged" Text="رصيف جانبي" />
                                        &nbsp;&nbsp;
                                    </td>
                                    <td class="style9">
                                        <telerik:RadNumericTextBox ID="rntxtSideWalkWidth" runat="server" Enabled="False"
                                            MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td class="style9">
                                        <asp:RadioButton ID="chkSideGood" runat="server" GroupName="side" Text="جيدة" />
                                    </td>
                                    <td class="style9">
                                        <asp:RadioButton ID="chkSideFair" runat="server" GroupName="side" Text="متوسطة" />
                                    </td>
                                    <td class="style9">
                                        <asp:RadioButton ID="chkSidePoor" runat="server" GroupName="side" Text="سيئة" />
                                    </td>
                                    <td class="style9">
                                        <asp:CheckBox ID="ChkSideWalkIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkSideWalkIntersect_CheckedChanged" Text="رصيف جانبي" />
                                        &nbsp;
                                    </td>
                                    <td class="style9">
                                        <telerik:RadNumericTextBox ID="rntxtSideWalkWidthIntersect" runat="server" Enabled="False"
                                            MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td class="style9">
                                        <asp:RadioButton ID="chkSideIntersectGood" runat="server" GroupName="sideInter" Text="جيدة" />
                                    </td>
                                    <td class="style9">
                                        <asp:RadioButton ID="chkSideIntersectFair" runat="server" GroupName="sideInter" Text="متوسطة" />
                                    </td>
                                    <td class="style9">
                                        <asp:RadioButton ID="chkSideIntersectPoor" runat="server" GroupName="sideInter" Text="سيئة" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View4" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="6">
                                        <asp:CheckBox ID="chkMultilevel" runat="server" AutoPostBack="True" Style="direction: ltr;
                                            font-weight: 700;" Text="متعدد المستويات؟" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkBridges" runat="server" Text="توجد جسور" AutoPostBack="True"
                                            OnCheckedChanged="ChkBridge_CheckedChanged" />
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="ChkTunnel" runat="server" AutoPostBack="True" OnCheckedChanged="ChkTunnel_CheckedChanged"
                                            Text="توجد أنفاق" />
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkBridgesIntersect" runat="server" Text="توجد جسور" AutoPostBack="True"
                                            OnCheckedChanged="chkBridgesIntersect_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkTunnelIntersect" runat="server" Text="توجد أنفاق" AutoPostBack="True"
                                            OnCheckedChanged="ChkTunnelIntersect_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        تفاصيل
                                        <asp:TextBox ID="txtBrdg_TUNEL_TYPE" runat="server" CssClass="style6" Enabled="False"
                                            MaxLength="150" Width="248px"></asp:TextBox>
                                    </td>
                                    <td colspan="3">
                                        &nbsp; تفاصيل
                                        <asp:TextBox ID="txtBrdg_TUNEL_TYPEIntersect" runat="server" CssClass="style6" Enabled="False"
                                            MaxLength="150" Width="248px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        <asp:HyperLink ID="hlnkBridges" runat="server" Target="_blank" Visible="False">بيانات جسور التقاطع</asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="hlnkTunnels" runat="server" Target="_blank" Visible="False">بيانات أنفاق التقاطع</asp:HyperLink>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        <b style="text-align: center">جهة الشارع الرئيسي المتقاطع </b>&nbsp; &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkWalkerBridges" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="chkWalkerBridges_CheckedChanged" Style="font-size: small;"
                                            Text="توجد جسور مشاة؟" />
                                    </td>
                                    <td>
                                        <b>النوع</b><span class="style10"><span class="style8"><asp:DropDownList ID="ddlwalkerBridgeType"
                                            runat="server" AppendDataBoundItems="True" DataSourceID="odsBridgeType" DataTextField="PEDESTRIAN_BRIDGE_TYPE"
                                            DataValueField="TYPE_ID" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                        </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsBridgeType" runat="server" SelectMethod="GetPedestrianBridgeTypes"
                                                TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                                        </span></span>
                                    </td>
                                    <td>
                                        <b>العدد</b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtWalkerBridgesCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWalkerBridgesIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="chkWalkerBridgesIntersect_CheckedChanged" Style="font-size: small"
                                            Text="توجد جسور مشاة؟" />
                                    </td>
                                    <td>
                                        <b>النوع</b><span class="style10"><span class="style8"><asp:DropDownList ID="ddlwalkerBridgeTypeIntersect"
                                            runat="server" AppendDataBoundItems="True" DataSourceID="odsBridgeType" DataTextField="PEDESTRIAN_BRIDGE_TYPE"
                                            DataValueField="TYPE_ID" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                        </asp:DropDownList>
                                        </span></span>
                                    </td>
                                    <td>
                                        <b>العدد</b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtWalkerBridgesCountIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View5" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="8">
                                        &nbsp;
                                    </td>
                                    <td colspan="7" style="text-align: center">
                                        <b>جهة الشارع الرئيسي المتقاطع </b>&nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkLight" runat="server" AutoPostBack="True" OnCheckedChanged="ChkLight_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد إنارة" />
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>الموقع&nbsp;&nbsp; </b>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtLightLocation" runat="server" Enabled="False" Width="120px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <b>جيد</b>&nbsp;
                                    </td>
                                    <td>
                                        <b>مقبول</b>&nbsp;
                                    </td>
                                    <td>
                                        <b>سيء</b>&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkLightIntersect" runat="server" AutoPostBack="True" OnCheckedChanged="ChkLightIntersect_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد إنارة" />
                                        &nbsp;
                                    </td>
                                    <td>
                                        الموقع&nbsp;&nbsp;
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtLightLocationIntersect" runat="server" Enabled="False" Width="120px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <b>جيد</b>&nbsp;
                                    </td>
                                    <td>
                                        <b>مقبول</b>&nbsp;
                                    </td>
                                    <td>
                                        <b>سيء</b>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b></b>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        العدد وفق الحالة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightGood" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightFair" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b></b>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        العدد وفق الحالة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightGoodIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightFairIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtLightPoorIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>عدد اللوحات الإعلانية </b>
                                    </td>
                                    <td>
                                        MegaCom
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtMegacomCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        Moby
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtMobyCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        UniPole
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtUnipoleCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>عدد اللوحات الإعلانية </b>
                                    </td>
                                    <td>
                                        MegaCom
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtMegacomCountIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        Moby
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtMobyCountIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        UniPole
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtUnipoleCountIntersect" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>عدد اللوحات الإرشادية</b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtGuideSignsCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        <b>عدد اللوحات الإرشادية</b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtGuideSignsIntersectCount" runat="server" CssClass="style11"
                                            Culture="ar-QA" DataType="System.Int16" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
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
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View6" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="5" class="style13">
                                        <b>جهة الشارع الرئيسي</b>
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <b>جهة الشارع الرئيسي المتقاطع </b>&nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:CheckBox ID="chkServiceLane" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkBridge_CheckedChanged" Text="يوجد مسار خدمة" />
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkServiceLaneIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkBridge_CheckedChanged" Text="يوجد مسار خدمة" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:CheckBox ID="chkOpeningService" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkBridge_CheckedChanged" Text="توجد فتحة بين المسار الرئيسي والخدمة" />
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkOpeningServiceIntersect" runat="server" AutoPostBack="True"
                                            CssClass="style5" OnCheckedChanged="ChkBridge_CheckedChanged" Text="توجد فتحة بين المسار الرئيسي والخدمة" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:CheckBox ID="chkUturnMain" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkBridge_CheckedChanged" Text=" فتحة دوران" />
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkUturnIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkBridge_CheckedChanged" Text=" فتحة دوران" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkPavMarkers" runat="server" AutoPostBack="True" OnCheckedChanged="chkPavMarkers_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد علامات أرضية وخطوط مشاة" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPavePaints" runat="server" Enabled="False" Text="دهانات" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPaveCeramics" runat="server" AutoPostBack="True" Enabled="False"
                                            Text="سيراميك" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSlopeMain" runat="server" Enabled="False" Text="منحدرات" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPavMarkersIntersect" runat="server" AutoPostBack="True" OnCheckedChanged="chkPavMarkersIntersect_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد علامات أرضية وخطوط مشاة" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPavePaintsIntersect" runat="server" Enabled="False" Text="دهانات" />
                                        <asp:CheckBox ID="chkPaveCeramicsIntersect" runat="server" AutoPostBack="True" Enabled="False"
                                            Text="سيراميك" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSlopeInterSect" runat="server" Enabled="False" Text="منحدرات" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>نوع المطب الصناعي</b>
                                    </td>
                                    <td colspan="3">
                                        <span class="style10"><span class="style8">
                                            <asp:DropDownList ID="ddlSpeedBumpType" runat="server" DataSourceID="odsSpeedBumpTypes"
                                                DataTextField="SPEED_BUMP_TYPE" DataValueField="SPEED_BUMP_TYPE_ID" AppendDataBoundItems="True"
                                                Enabled="False">
                                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                            </asp:DropDownList>
                                        </span></span>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <b>نوع المطب الصناعي</b>
                                    </td>
                                    <td>
                                        <span class="style10"><span class="style8">
                                            <asp:DropDownList ID="ddlSpeedBumpTypeIntersect" runat="server" AppendDataBoundItems="True"
                                                DataSourceID="odsSpeedBumpTypes" DataTextField="SPEED_BUMP_TYPE" DataValueField="SPEED_BUMP_TYPE_ID"
                                                Enabled="False">
                                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                            </asp:DropDownList>
                                        </span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:CheckBox ID="chkSoilParts" runat="server" AutoPostBack="True" OnCheckedChanged="chkSoilParts_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد أجزاء ترابية" />
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkSoilPartsIntersect" runat="server" AutoPostBack="True" OnCheckedChanged="chkSoilPartsIntersect_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد أجزاء ترابية" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        طول
                                        <telerik:RadNumericTextBox ID="rntxtUnpavedLength" runat="server" DataType="System.Decimal"
                                            MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td colspan="2">
                                        عرض
                                        <telerik:RadNumericTextBox ID="rntxtUnpavedWidth" runat="server" DataType="System.Decimal"
                                            MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        طول
                                        <telerik:RadNumericTextBox ID="rntxtUnpavedLengthIntersect" runat="server" DataType="System.Decimal"
                                            MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        عرض
                                        <telerik:RadNumericTextBox ID="rntxtUnpavedWidthIntersect" runat="server" DataType="System.Decimal"
                                            MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:CheckBox ID="chkConcreteBlocks" runat="server" AutoPostBack="True" OnCheckedChanged="chkConcreteBlocks_CheckedChanged"
                                            Style="font-weight: 700" Text="توجد حواجز خرسانية مؤقتة" />
                                        &nbsp;&nbsp;&nbsp; العدد&nbsp;
                                        <telerik:RadNumericTextBox ID="rntxtConcreteBlocks" runat="server" MinValue="0" Width="50px"
                                            Enabled="False">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkConcreteBlocks_intersect" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chkConcreteBlocks_intersect_CheckedChanged" Style="font-weight: 700"
                                            Text="توجد حواجز خرسانية مؤقتة" />
                                        &nbsp;&nbsp;&nbsp; العدد&nbsp;&nbsp;<telerik:RadNumericTextBox ID="rntxtConcreteBlocks_intersect"
                                            runat="server" Enabled="False" MinValue="0" Width="50px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <b>مكان التشجير </b>&nbsp;<table>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="ChkAg_MID" runat="server" Text="جزيرة وسطية" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ChkAg_SID" runat="server" Text="جزيرة فاصلة" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ChkAg_SEC" runat="server" Text="رصيف جانبي" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="3">
                                        <b>مكان التشجير</b>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="ChkAg_MIDIntersect" runat="server" Text="جزيرة وسطية" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ChkAg_SIDIntersect" runat="server" Text="جزيرة فاصلة" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ChkAg_SECIntersect" runat="server" Text="رصيف جانبي" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View7" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="4">
                                        <b>المناهل والمصائد</b>&nbsp; <b>جهة الشارع الرئيسي</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>العدد وفق الحالة</b>
                                    </td>
                                    <td>
                                        <b>بحالة جيدة</b>
                                    </td>
                                    <td>
                                        <b>مقبول</b>
                                    </td>
                                    <td>
                                        <b>سيئ</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkDrinage_CBs" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkDrinage_CBs_CheckedChanged" Text="مصائد تصريف سيول" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBGood" runat="server" Culture="ar-QA"
                                            Enabled="False" MaxValue="100" MinValue="0" Width="40px">
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
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkDrinage_MH" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkDrinage_MH_CheckedChanged" Text="مناهل تصريف سيول" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MHGood" runat="server" Culture="ar-QA"
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
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkSewage_MH" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkSewage_MH_CheckedChanged" Text="مناهل صرف صحي" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MHGood" runat="server" Culture="ar-QA"
                                            Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_Fair" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_Poor" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkElect_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkElect_MH_CheckedChanged"
                                                Text="مناهل كهرباء" />
                                        </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MHGood" runat="server" Culture="ar-QA"
                                                Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                            &nbsp; </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_Fair" runat="server" CssClass="style8"
                                                Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                                Width="40px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_Poor" runat="server" CssClass="style8"
                                                Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                                Width="40px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkSTC_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSTC_MH_CheckedChanged"
                                                Text="مناهل هاتف" />
                                        </b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MHGood" runat="server" Culture="ar-QA" DataType="System.Int16"
                                            Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_Fair" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_Poor" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkWater_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkWater_MH_CheckedChanged"
                                                Text="مناهل مياه" />
                                        </b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MHGood" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_Fair" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_Poor" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>المناهل والمصائد</b> &nbsp; <b>جهة الشارع الرئيسي المتقاطع </b>&nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>العدد وفق الحالة</b>
                                    </td>
                                    <td>
                                        <b>بحالة جيدة</b>
                                    </td>
                                    <td>
                                        <b>مقبول </b>
                                    </td>
                                    <td>
                                        <b>سيئ</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkDrinage_CBsIntersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkDrinage_CBsIntersect_CheckedChanged" Text="مصائد تصريف سيول" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBGoodIntersect" runat="server" Culture="ar-QA"
                                            Enabled="False" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBFairIntersect" runat="server" CssClass="style5"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_CBPoorIntersect" runat="server" CssClass="style5"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkDrinage_MH_Intersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkDrinage_MH_Intersect_CheckedChanged" Text="مناهل تصريف سيول" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MHGoodIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MH_FairIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtDrinage_MH_PoorIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkSewage_MH_Intersect" runat="server" AutoPostBack="True" CssClass="style5"
                                            OnCheckedChanged="ChkSewage_MH_Intersect_CheckedChanged" Text="مناهل صرف صحي" />
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MHGoodIntersect" runat="server" Culture="ar-QA"
                                            Enabled="False" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_FairIntersect" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSewage_MH_PoorIntersect" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkElect_MHIntersect" runat="server" AutoPostBack="True" OnCheckedChanged="ChkElect_MHIntersect_CheckedChanged"
                                                Text="مناهل كهرباء" />
                                        </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MHGoodIntersect" runat="server" Culture="ar-QA"
                                                Enabled="False" MinValue="0" Width="40px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                            &nbsp; </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_FairIntersect" runat="server" CssClass="style8"
                                                Culture="ar-QA" DataType="System.Int16" Enabled="False" MinValue="0" Width="40px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </b>
                                    </td>
                                    <td>
                                        <b>
                                            <telerik:RadNumericTextBox ID="rnTxtElect_MH_PoorIntersect" runat="server" CssClass="style8"
                                                Culture="ar-QA" DataType="System.Int16" Enabled="False" MinValue="0" Width="40px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkSTC_MH_Intersect" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSTC_MH_Intersect_CheckedChanged"
                                                Text="مناهل هاتف" />
                                        </b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MHGoodIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Int16" Enabled="False" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_FairIntersect" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtSTC_MH_PoorIntersect" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkWater_MH_Intersect" runat="server" AutoPostBack="True" OnCheckedChanged="ChkWater_MH_Intersect_CheckedChanged"
                                                Text="مناهل مياه" />
                                        </b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MHGoodIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Int32" Enabled="False" MinValue="0" Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_FairIntersect" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rnTxtWater_MH_PoorIntersect" runat="server" CssClass="style8"
                                            Culture="ar-QA" DataType="System.Int32" Enabled="False" MaxValue="100" MinValue="0"
                                            Width="40px">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View8" runat="server">
                            <table class="style4">
                                <tr>
                                    <td colspan="4">
                                        <b>الحفريات القائمة&nbsp; جهة الشارع الرئيسي</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:CheckBox ID="chkDrillingSTC" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingSTC_CheckedChanged"
                                            Style="font-weight: 700" Text="خدمات اتصالات" />
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingSTC" runat="server" Culture="ar-QA" DataType="System.Double"
                                            Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkDrillingElec" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingElec_CheckedChanged"
                                                Style="text-align: right" Text="خدمات كهرباء" />
                                        </b>
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingElec" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:CheckBox ID="chkDrillingWater" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingWater_CheckedChanged"
                                            Style="font-weight: 700; text-align: right;" Text="خدمات مياه" />
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingWater" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkDrillingSewage" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingSewage_CheckedChanged"
                                                Style="text-align: right" Text="خدمات صرف صحي" />
                                        </b>
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingSewage" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <b>الحفريات القائمة&nbsp; جهة الشارع الرئيسي المتقاطع &nbsp; &nbsp; </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:CheckBox ID="chkDrillingSTC_Intersect" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingSTC_Intersect_CheckedChanged"
                                            Style="font-weight: 700" Text="خدمات اتصالات" />
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingSTC_Intersect" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkDrillingElecIntersect" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingElecIntersect_CheckedChanged"
                                                Style="text-align: right" Text="خدمات كهرباء" />
                                        </b>
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingElecIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:CheckBox ID="chkDrillingWaterIntersect" runat="server" AutoPostBack="True" OnCheckedChanged="chkDrillingWaterIntersect_CheckedChanged"
                                            Style="font-weight: 700; text-align: right;" Text="خدمات مياه" />
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingWaterIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkDrillingSewageIntersect" runat="server" AutoPostBack="True"
                                                OnCheckedChanged="chkDrillingSewageIntersect_CheckedChanged" Style="text-align: right"
                                                Text="خدمات صرف صحي" />
                                        </b>
                                    </td>
                                    <td>
                                        الطول
                                        <telerik:RadNumericTextBox ID="rntxtDrillingSewageIntersect" runat="server" Culture="ar-QA"
                                            DataType="System.Double" Enabled="False" MinValue="0" Width="80px">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                    <br />
                    <table width="100%">
                        <tr>
                            <td colspan="19" class="style10">
                                <asp:Label ID="lblFeedbackSave" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="19" style="text-align: center">
                                <asp:Button ID="UpdateButton" runat="server" CssClass="style6" OnClick="UpdateButton_Click"
                                    Text="حفظ بيانات التقاطع" />
                                &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" CssClass="style6" OnClick="UpdateCancelButton_Click"
                                    Text="إلغاء" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
                            </td>
                            <td>
                                <table align="right" class="style4">
                                    <tr>
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
                        SelectMethod="GetIntersectionSurveyingWork" TypeName="JpmmsClasses.BL.SurveyorSubmitJob"
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="id" PropertyName="SelectedValue"
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
</asp:Content>
