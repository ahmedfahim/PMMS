<%@ Page Title="المعلومات العامة للمناطق والشوارع الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="RegionInfo.aspx.cs" Inherits="ASPX_Regions_RegionInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchRegion.ascx" TagName="SearchRegion" TagPrefix="uc1" %>
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
        }
        .style2
        {
            text-align: center;
        }
        .style4
        {
            text-align: center;
        }
        .bold
        {
            text-align: right;
        }
        .style5
        {
            font-weight: bold;
        }
        .style7
        {
            text-align: right;
        }
        .style8
        {
            text-align: right;
        }
        .style9
        {
            text-align: right;
            font-weight: bold;
        }
        .style10
        {
            font-size: small;
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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    <strong>المناطق والشوارع الفرعية</strong></h2>
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
                <table align="center">
                    <tr>
                        <td>
                            <b>المنطقة الفرعية </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" autoselectfirstitem="true"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnSearch" runat="server" OnClick="lbtnSearch_Click" ToolTip="بحث متقدم بجزء من اسم أو رقم المنطقة الفرعية">بحث متقدم</asp:LinkButton>
                        </td>
                        <td rowspan="7">
                            <uc1:SearchRegion ID="SearchRegion1" runat="server" OnSetSearchChanged="OnSetSearchChanged"
                                Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FormView ID="FormView1" runat="server" DataSourceID="odsRegionInfo" Width="80%">
                                <EditItemTemplate>
                                    REGION_NO:
                                    <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                    <br />
                                    ARNAME:
                                    <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                                    <br />
                                    MUNIC_NAME:
                                    <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                    <br />
                                    REGION_NAME:
                                    <asp:TextBox ID="REGION_NAMETextBox" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                    <br />
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Update" />
                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    REGION_NO:
                                    <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                    <br />
                                    ARNAME:
                                    <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                                    <br />
                                    MUNIC_NAME:
                                    <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                    <br />
                                    REGION_NAME:
                                    <asp:TextBox ID="REGION_NAMETextBox" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                    <br />
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        Text="Insert" />
                                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel" />
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <b>رقم المنطقة </b>
                                            </td>
                                            <td>
                                                <b>اسم المنطقة</b>
                                            </td>
                                            <td>
                                                <b>البلدية الفرعية </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="REGION_NOLabel" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="REGION_NAMELabel" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="MUNIC_NAMELabel" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:FormView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="lnkSurveyor" runat="server" OnClick="lnkSurveyor_Click" Visible="False">تسليم المساح</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>الشارع الفرعي</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegionSecondaryStreets" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title"
                                DataValueField="STREET_ID" OnSelectedIndexChanged="ddlRegionSecondaryStreets_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                    TypeName="JpmmsClasses.BL.SecondaryStreets">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSpeedBumpTypes" runat="server" SelectMethod="GetSpeedBumpsTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionInfo" runat="server" SelectMethod="GetRegionInfo"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlSecondarySt" Visible="false" runat="server" HorizontalAlign="Center">
                    <table class="style4">
                        <tr>
                            <td colspan="3" style="text-align: right">
                                <asp:LinkButton ID="lnkDetails" runat="server" OnClick="lnkDetails_Click">بيانات عامة</asp:LinkButton>
                                &nbsp; &nbsp;
                                <asp:LinkButton ID="lnkAg" runat="server" OnClick="lnkAg_Click">  العلامات الأرضية والإنارة</asp:LinkButton>
                                &nbsp; &nbsp;
                                <asp:LinkButton ID="lnkIslands" runat="server" OnClick="lnkIslands_Click">الأرصفة والجزر</asp:LinkButton>
                                &nbsp; &nbsp;
                                <asp:LinkButton ID="lnkUses" runat="server" OnClick="lnkUses_Click">الاستخدامات المجاورة</asp:LinkButton>
                                &nbsp; &nbsp;
                                <asp:LinkButton ID="lnkMainholes" runat="server" OnClick="lnkMainholes_Click">المناهل والمصائد</asp:LinkButton>
                                &nbsp; &nbsp;
                                <asp:LinkButton ID="lnkDrills" runat="server" OnClick="lnkDrills_Click">حفريات الخدمات</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: right">
                                <asp:HyperLink ID="lnkGallery" runat="server" Target="_blank">استعراض صور الشارع الفرعي</asp:HyperLink>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:MultiView ID="mlvSectionInfo" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View1" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <b>اسم الشارع
                                                        <br />
                                                        الفرعي </b>
                                                </td>
                                                <td colspan="3" style="text-align: right">
                                                    <asp:TextBox ID="txtSecondStArName" runat="server" Width="240px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <b>&nbsp; رقم الشارع الفرعي </b>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtSecondStNo" runat="server" ReadOnly="true" Width="72px"></asp:TextBox>
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
                                                    <b>الطول </b>
                                                </td>
                                                <td class="style8">
                                                    <telerik:RadNumericTextBox ID="rntxtLength" runat="server" AutoPostBack="True" DataType="System.Decimal"
                                                        MinValue="0" OnTextChanged="rntxtSectionWidth_TextChanged">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <b>العرض</b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtWidth" runat="server" AutoPostBack="True" DataType="System.Decimal"
                                                        MinValue="0" OnTextChanged="rntxtSectionWidth_TextChanged">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td class="style5">
                                                    <b>المساحة </b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtArea" runat="server" DataType="System.Decimal"
                                                        MinValue="0" ReadOnly="True">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    طول القسم
                                                    <br />
                                                    الترابي
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtUnpavedLength" runat="server" AutoPostBack="True"
                                                        DataType="System.Decimal" MinValue="0" OnTextChanged="rntxtSectionWidth_TextChanged">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="style8" colspan="3">
                                                    تاريخ آخر مسح
                                                    <telerik:RadDatePicker ID="rdtpSurveyDate" runat="server">
                                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="3" rowspan="2">
                                                    <table class="style11">
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style9">
                                                    ملاحظات
                                                </td>
                                                <td colspan="7" style="text-align: right">
                                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="197px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table>
                                            <tr>
                                                <td class="style8">
                                                    &nbsp;
                                                </td>
                                                <td class="style8">
                                                    <asp:CheckBox ID="ChkLight" runat="server" AutoPostBack="True" OnCheckedChanged="ChkLight_CheckedChanged"
                                                        Style="font-weight: 700" Text="توجد إنارة" />
                                                </td>
                                                <td>
                                                    <b>الموقع </b>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtLightLocation" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>العدد</b>&nbsp;
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
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtLightGood" runat="server" CssClass="style5" Culture="ar-QA"
                                                        DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtLightFair" runat="server" CssClass="style5" Culture="ar-QA"
                                                        DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtLightPoor" runat="server" CssClass="style5" Culture="ar-QA"
                                                        DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0" Width="40px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bold">
                                                    &nbsp;
                                                </td>
                                                <td class="bold" colspan="4">
                                                    <asp:CheckBox ID="chkSpeedBumps" runat="server" AutoPostBack="True" OnCheckedChanged="chkSpeedBumps_CheckedChanged"
                                                        Style="font-weight: 700" Text="توجد مطبات صناعية" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID="chkLegal" runat="server" AutoPostBack="True" Enabled="False" Text="نظامية" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID="chkIllegal" runat="server" AutoPostBack="True" Enabled="False"
                                                        Style="text-align: right" Text="غير نظامية" />
                                                </td>
                                                <td class="bold">
                                                    العدد
                                                    <telerik:RadNumericTextBox ID="rntxtSpeedBumpsCount" runat="server" AutoPostBack="True"
                                                        MaxValue="100" Enabled="False" MinValue="0" Style="text-align: right" Width="50px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td style="text-align: right">
                                                    <b>النوع</b>
                                                    <asp:DropDownList ID="ddlSpeedBumpType" runat="server" AppendDataBoundItems="True"
                                                        DataSourceID="odsSpeedBumpTypes" DataTextField="SPEED_BUMP_TYPE" DataValueField="SPEED_BUMP_TYPE_ID"
                                                        Enabled="False">
                                                        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bold">
                                                    &nbsp;
                                                </td>
                                                <td class="bold" colspan="4">
                                                    <asp:CheckBox ID="chkConcreteBlocks" runat="server" AutoPostBack="True" OnCheckedChanged="chkConcreteBlocks_CheckedChanged"
                                                        Style="font-weight: 700" Text="توجد حواجز خرسانية" />
                                                </td>
                                                <td style="text-align: right">
                                                    العدد
                                                    <telerik:RadNumericTextBox ID="rntxtConcreteBlocks" runat="server" AutoPostBack="True"
                                                        Enabled="False" MinValue="0" Width="50px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td style="text-align: right">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="style8">
                                                    <asp:CheckBox ID="ChkMidIsland" runat="server" AutoPostBack="True" CssClass="style10"
                                                        OnCheckedChanged="ChkMidIsland_CheckedChanged" Text="توجد جزيرة وسطية" />
                                                </td>
                                                <td>
                                                    <b>تقييم</b>&nbsp; <b>الحالة</b>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:RadioButton ID="chkMidGood" runat="server" Enabled="False" GroupName="mid" Text="جيدة" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="chkMidFair" runat="server" Enabled="False" GroupName="mid" Text="متوسطة" />
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="chkMidPoor" runat="server" Enabled="False" GroupName="mid" Text="سيئة" />
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
                                                <td class="style8">
                                                    <asp:CheckBox ID="ChkSideWalk" runat="server" AutoPostBack="True" CssClass="style8"
                                                        OnCheckedChanged="ChkSideWalk_CheckedChanged" Text="يوجد رصيف جانبي" />
                                                </td>
                                                <td>
                                                    <b>تقييم</b> &nbsp; <b>الحالة</b>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:RadioButton ID="chkSideGood" runat="server" GroupName="side" Text="جيدة" />
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="chkSideFair" runat="server" GroupName="side" Text="متوسطة" />
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="chkSidePoor" runat="server" GroupName="side" Text="سيئة" />
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
                                    <asp:View ID="View4" runat="server">
                                        <table class="style4" width="90%">
                                            <tr>
                                                <td class="style7">
                                                    <b>الاستخدامات المجاورة </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style7">
                                                    <asp:CheckBox ID="ChkHousing" runat="server" Text="سكنية" CssClass="style5" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="ChkCommercial" runat="server" Text="تجارية" CssClass="style5" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="ChkPublics" runat="server" CssClass="style5" Text="خدمية" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="ChkRest_House" runat="server" CssClass="style5" Text="استراحات" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style7">
                                                    <asp:CheckBox ID="ChkGarden" runat="server" CssClass="style5" Text="حدائق ومنتزهات" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="chkSchools" runat="server" CssClass="style5" Text="مدارس" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="ChkIndisterial" runat="server" CssClass="style5" Text="مناطق صيانة" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="chkMasjid" runat="server" CssClass="style5" Text="مسجد/جامع" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="margin-right: 80px" class="style7">
                                                    <asp:CheckBox ID="chkSport" runat="server" CssClass="style5" Text="نوادي رياضية" />
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="chkNewlyBuilt" runat="server" CssClass="style5" Text="مباني قيد التشييد" />
                                                </td>
                                                <td class="style7">
                                                    &nbsp;
                                                </td>
                                                <td class="style7">
                                                    <asp:CheckBox ID="chkHospital" runat="server" CssClass="style5" Text="مستشفى/مستوصف" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="margin-right: 160px; text-align: right;" colspan="2">
                                                    <asp:CheckBox ID="chkOtherUtils" runat="server" AutoPostBack="True" CssClass="style5"
                                                        OnCheckedChanged="chkOtherUtils_CheckedChanged" Text="استخدامات أخرى" />
                                                    &nbsp;تفاصيل
                                                </td>
                                                <td class="style7">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="margin-right: 80px" colspan="4">
                                                    &nbsp;
                                                    <asp:TextBox ID="txtOtherDetails" runat="server" Enabled="False" TextMode="MultiLine"
                                                        Width="197px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View5" runat="server">
                                        <table>
                                            <tr>
                                                <td colspan="8">
                                                    <b>المناهل والمصائد</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style9">
                                                    العدد وفق الحالة
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
                                                <td class="style9">
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
                                            </tr>
                                            <tr>
                                                <td class="bold">
                                                    <asp:CheckBox ID="ChkDrinage_CBs" runat="server" AutoPostBack="True" OnCheckedChanged="ChkDrinage_CBs_CheckedChanged"
                                                        Style="font-weight: 700" Text="مصائد تصريف سيول" />
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
                                                        Culture="ar-QA" DataType="System.Int16" Enabled="False" MaxValue="100" MinValue="0"
                                                        Width="40px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td class="bold">
                                                    <b>
                                                        <asp:CheckBox ID="ChkElect_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkElect_MH_CheckedChanged"
                                                            Text="مناهل كهرباء" />
                                                    </b>
                                                </td>
                                                <td>
                                                    <b>
                                                        <telerik:RadNumericTextBox ID="rnTxtElect_MH_Good" runat="server" Culture="ar-QA"
                                                            DataType="System.Int16" Enabled="False" MinValue="0" MaxValue="100" Width="40px">
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </b>
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
                                                <td class="bold">
                                                    <asp:CheckBox ID="ChkDrinage_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkDrinage_MH_CheckedChanged"
                                                        Text="مناهل تصريف سيول" Style="font-weight: 700" />
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtDrinage_MH_Good" runat="server" Culture="ar-QA"
                                                        MaxValue="100" DataType="System.Int16" MinValue="0" Width="40px" Enabled="False">
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
                                                <td class="bold">
                                                    <b>
                                                        <asp:CheckBox ID="ChkSTC_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSTC_MH_CheckedChanged"
                                                            Text="مناهل هاتف" />
                                                    </b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtSTC_MH_Good" runat="server" Culture="ar-QA" DataType="System.Int16"
                                                        MaxValue="100" MinValue="0" Width="40px" Enabled="False">
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
                                                <td class="bold">
                                                    <asp:CheckBox ID="ChkSewage_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSewage_MH_CheckedChanged"
                                                        Text="مناهل صرف صحي" Style="font-weight: 700" />
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rntxtSewage_MH_Good" runat="server" Culture="ar-QA"
                                                        MinValue="0" Width="40px" MaxValue="100" DataType="System.Int16" Enabled="False">
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
                                                <td class="bold">
                                                    <b>
                                                        <asp:CheckBox ID="ChkWater_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkWater_MH_CheckedChanged"
                                                            Text="مناهل مياه" Style="text-align: right" />
                                                    </b>
                                                </td>
                                                <td>
                                                    <telerik:RadNumericTextBox ID="rnTxtWater_MH_Good" runat="server" Culture="ar-QA"
                                                        MaxValue="100" DataType="System.Int32" MinValue="0" Width="40px" Enabled="False">
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
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View6" runat="server">
                                        <table>
                                            <tr>
                                                <td class="style5" colspan="8">
                                                    الحفريات القائمة
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:CheckBox ID="chkDrillingSTC" runat="server" AutoPostBack="True" Text="خدمات اتصالات"
                                                        Style="font-weight: 700" OnCheckedChanged="chkDrillingSTC_CheckedChanged" />
                                                </td>
                                                <td colspan="3">
                                                    الطول
                                                    <telerik:RadNumericTextBox ID="rntxtDrillingSTC" runat="server" Culture="ar-QA" DataType="System.Int16"
                                                        MinValue="0" Width="125px" Enabled="False">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td style="text-align: right">
                                                    <b>
                                                        <asp:CheckBox ID="chkDrillingElec" runat="server" AutoPostBack="True" Text="خدمات كهرباء"
                                                            OnCheckedChanged="chkDrillingElec_CheckedChanged" Style="text-align: right" />
                                                    </b>
                                                </td>
                                                <td colspan="3">
                                                    الطول
                                                    <telerik:RadNumericTextBox ID="rntxtDrillingElec" runat="server" Culture="ar-QA"
                                                        DataType="System.Int32" MinValue="0" Width="125px" Enabled="False">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:CheckBox ID="chkDrillingWater" runat="server" AutoPostBack="True" Text="خدمات مياه"
                                                        Style="font-weight: 700; text-align: right;" OnCheckedChanged="chkDrillingWater_CheckedChanged" />
                                                </td>
                                                <td colspan="3">
                                                    الطول
                                                    <telerik:RadNumericTextBox ID="rntxtDrillingWater" runat="server" Culture="ar-QA"
                                                        DataType="System.Int16" MinValue="0" Width="125px" Enabled="False">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:CheckBox ID="chkDrillingSewage" runat="server" AutoPostBack="True" Text="خدمات صرف صحي"
                                                            OnCheckedChanged="chkDrillingSewage_CheckedChanged" Style="text-align: right" />
                                                    </b>
                                                </td>
                                                <td colspan="3">
                                                    الطول
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
                            <td class="bold" colspan="8">
                                <asp:Label ID="lblFeedbackInsert" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table width="40%">
                                    <tr>
                                        <td>
                                            <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="حفظ بيانات الشارع الفرعي" />
                                        </td>
                                        <td>
                                            &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" OnClick="UpdateCancelButton_Click"
                                                Text="إلغاء" />
                                        </td>
                                    </tr>
                                </table>
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
                                <telerik:RadNumericTextBox ID="rntxtSurveyNo" runat="server" MinValue="0" Value="3" Enabled="false"
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
                                <asp:TextBox ID="TextBox1" runat="server" Height="24px" TextMode="MultiLine" Width="50%"
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
                        SelectMethod="GetRegionSurveyingWork" TypeName="JpmmsClasses.BL.SurveyorSubmitJob"
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlRegions" Name="id" PropertyName="SelectedValue"
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
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
