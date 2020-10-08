<%@ Page Title="الطرق والشوارع المستحدثة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="R4StreetsInfo.aspx.cs" Inherits="ASPX_Sections_R4StreetsInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            direction: ltr;
        }
        .style4
        {
            width: 100%;
            font-size: medium;
        }
        .style8
        {
            font-size: small;
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
            font-size: small;
            direction: ltr;
            font-weight: bold;
        }
        .style14
        {
            font-size: small;
            font-weight: bold;
        }
        .style15
        {
            font-weight: bold;
        }
        .style16
        {
            text-align: center;
            font-size: large;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style16">
                <h2>
                    الطرق والشوارع المستحدثة
                </h2>
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
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetR4MainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table class="style4">
                    <tr>
                        <td colspan="8" valign="top">
                            <table class="style4">
                                <tr>
                                    <td>
                                        <table class="style4">
                                            <tr>
                                                <td>
                                                    <table class="style4">
                                                        <tr>
                                                            <td class="style12">
                                                                الرقم
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtNo" runat="server" MaxLength="3"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <b>الاسم </b>
                                                            </td>
                                                            <td class="style14">
                                                                <asp:TextBox ID="txtName" runat="server" MaxLength="70"></asp:TextBox>
                                                            </td>
                                                            <td colspan="3">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style12">
                                                                الشارع الرئيسي
                                                            </td>
                                                            <td colspan="8">
                                                                <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                                                    AutoPostBack="True" DataSourceID="odsMainStreets" DataTextField="main_title"
                                                                    DataValueField="STREET_ID" 
                                                                    OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style12">
                                                                تاريخ الاستحداث
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="radR4Date" runat="server">
                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td class="style14" colspan="2">
                                                                تاريخ الافتتاح
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="radR4OpeningDate" runat="server">
                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td class="style14">
                                                                تاريخ المسح
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="radR4SurveyDate" runat="server">
                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td class="style14">
                                                                تاريخ تعريف المقاطع
                                                            </td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="radR4SectionsDate" runat="server">
                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style12" colspan="3">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radR4Date"
                                                                    ErrorMessage="الرجاء إدخال تاريخ الاستحداث"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="radR4OpeningDate"
                                                                    ErrorMessage="الرجاء إدخال تاريخ الافتتاح" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radR4SurveyDate"
                                                                    ErrorMessage="الرجاء إدخال تاريخ المسح" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="style14" colspan="2">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="radR4SectionsDate"
                                                                    ErrorMessage="الرجاء إدخال تاريخ تعريف المقاطع" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style12">
                                                                مقاول التنفيذ
                                                            </td>
                                                            <td colspan="4">
                                                                <asp:DropDownList ID="ddlContractors" runat="server" AppendDataBoundItems="True"
                                                                    DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_NO">
                                                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="style14">
                                                                الكثافة السكانية
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPopulation" runat="server">
                                                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                                    <asp:ListItem Value="H">مرتفعة</asp:ListItem>
                                                                    <asp:ListItem Value="M">متوسطة</asp:ListItem>
                                                                    <asp:ListItem Value="L">منخفضة</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="style14">
                                                                الطول
                                                            </td>
                                                            <td>
                                                                <telerik:RadNumericTextBox ID="rntxtSectionLength" runat="server" AutoPostBack="True"
                                                                    DataType="System.Decimal" MinValue="0">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style12">
                                                                &nbsp;
                                                            </td>
                                                            <td colspan="4">
                                                                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlContractors"
                                                                    ErrorMessage="الرجاء اختيار مقاول التنفيذ" Style="font-size: small; font-weight: 700"
                                                                    ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                                            </td>
                                                            <td class="style14">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlPopulation"
                                                                    ErrorMessage="الرجاء اختيار الكثافة السكانية" Style="font-size: small; font-weight: 700"
                                                                    ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                                            </td>
                                                            <td class="style14">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rntxtSectionLength"
                                                                    ErrorMessage="الرجاء إدخال الطول" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2">
                            <table class="style4">
                                <tr>
                                    <td colspan="2">
                                        <span class="style10">
                                            <asp:CheckBox ID="chkNotPavedbyMunic" runat="server" AutoPostBack="True" Text="لم يتم رصفه على حساب الأمانة" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style10">
                                        تفاصيل
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNotpavedByDetails" runat="server" CssClass="style10" Height="66px"
                                            MaxLength="500" TextMode="MultiLine" Width="133px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span class="style8"><span class="style10">
                                            <asp:CheckBox ID="chkOwnedByMunic" runat="server" AutoPostBack="True" Text="تعود ملكيته للأمانة" />
                                        </span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        تفاصيل
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOwnedByMunicDetails" runat="server" CssClass="style10" Height="66px"
                                            MaxLength="500" TextMode="MultiLine" Width="133px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="6">
                            <table class="style4">
                                <tr>
                                    <td class="style14" valign="top">
                                        الطبيعة الطبوغرافية للمنطقة
                                    </td>
                                    <td class="style10" colspan="3">
                                        <asp:TextBox ID="txtTopographic" runat="server" CssClass="style10" Height="66px"
                                            MaxLength="500" TextMode="MultiLine" Width="442px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style14" valign="top">
                                        نوع وطبيعة التربة
                                    </td>
                                    <td class="style10" colspan="3">
                                        <asp:TextBox ID="txtSoilType" runat="server" CssClass="style10" Height="66px" MaxLength="500"
                                            TextMode="MultiLine" Width="442px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" colspan="2">
                                        احتياجات الطريق
                                    </td>
                                    <td colspan="2">
                                        <b><span class="style10">الاستخدامات المجاورة </span></b><span class="style10"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="ChkMidIsland" runat="server" AutoPostBack="True" CssClass="style10"
                                                Text="يحتاج إلى جزيرة وسطية" />
                                        </b><span class="style14">&nbsp;</span>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkNeedSigns" runat="server" AutoPostBack="True" CssClass="style8"
                                                Text="يحتاج إلى علامات  مرورية وإرشادية" />
                                        </b>
                                    </td>
                                    <td>
                                        <span class="style14">
                                            <asp:CheckBox ID="ChkHousing" Text="سكنية" runat="server" />
                                        </span>
                                    </td>
                                    <td>
                                        <span class="style14">
                                            <asp:CheckBox ID="ChkCommercial" runat="server" Text="تجارية" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkNeedTrees" runat="server" AutoPostBack="True" CssClass="style8"
                                                Text="يحتاج إلى تشجير" />
                                        </b><span class="style14">&nbsp;&nbsp; </span>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkNeedServiceLanes" runat="server" AutoPostBack="True" CssClass="style8"
                                                Text="يحتاج إلى مسارات خدمة" />
                                        </b>
                                    </td>
                                    <td>
                                        <span class="style14">
                                            <asp:CheckBox ID="ChkPublics" runat="server" Text="خدمية" />
                                        </span>
                                    </td>
                                    <td>
                                        <span class="style14">
                                            <asp:CheckBox ID="ChkGarden" runat="server" Text="حدائق ومنتزهات" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style15">
                                        <span class="style14">
                                            <asp:CheckBox ID="chkLight" runat="server" AutoPostBack="True" Text="يحتاج إلى إنارة" />
                                        </span>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkNeedSpeedBumps" runat="server" AutoPostBack="True" CssClass="style8"
                                                Text="يحتاج إلى مطبات صناعية" />
                                        </b>
                                    </td>
                                    <td>
                                        <span class="style14">
                                            <asp:CheckBox ID="ChkRest_House" runat="server" Text="استراحات" />
                                        </span>
                                    </td>
                                    <td>
                                        <span class="style14">
                                            <asp:CheckBox ID="ChkIndisterial" runat="server" Text="مناطق صيانة" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:CheckBox ID="chkInfra" runat="server" AutoPostBack="True" CssClass="style8"
                                                Text="يحتاج إلى أعمال بنية تحتية" />
                                        </b>
                                    </td>
                                    <td class="style15">
                                        <span class="style14">
                                            <asp:CheckBox ID="chkInnerWater" runat="server" AutoPostBack="True" Text="توجد مياه جوفية" />
                                        </span>
                                    </td>
                                    <td colspan="2">
                                        <span class="style14">
                                            <asp:CheckBox ID="chkWarehouses" runat="server" Text="مستودعات" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <b>عدد المسارات التي يحتاجها
                                            <br />
                                            الشارع</b>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtNeededlanesCount" runat="server" DataType="System.Int32"
                                            MaxValue="10" MinValue="0">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td class="style8">
                                        <b>تفاصيل إضافية </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMoreDetails" runat="server" CssClass="style10" Height="66px"
                                            MaxLength="500" TextMode="MultiLine" Width="133px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rntxtNeededlanesCount"
                                            ErrorMessage="الرجاء إدخال عدد المسارات المطلوبة" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style8">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <strong><span class="style10">العلامات الأرضية</span></strong><span class="style10">
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span class="style10">
                                <asp:CheckBox ID="ChkDrinage_CBs" runat="server" AutoPostBack="True" OnCheckedChanged="ChkDrinage_CBs_CheckedChanged"
                                    Style="font-weight: 700" Text="مصائد تصريف سيول" />
                            </span>
                        </td>
                        <td colspan="2">
                            <span class="style8">العدد</span></span></span><telerik:RadNumericTextBox ID="rntxtDrinage_CBCount"
                                runat="server" Culture="ar-QA" DataType="System.Int16" MinValue="0" Width="125px"
                                Enabled="False" CssClass="style11">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td colspan="2">
                            <b><span class="style10">
                                <asp:CheckBox ID="ChkElect_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkElect_MH_CheckedChanged"
                                    Text="مناهل كهرباء" />
                            </span></b><span class="style10"></span>
                        </td>
                        <td colspan="2">
                            <span class="style10">العدد</span></span><b>
                                <telerik:RadNumericTextBox ID="rnTxtElect_MHCount" runat="server" Culture="ar-QA"
                                    DataType="System.Int16" Enabled="False" MinValue="0" Width="125px">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <span class="style10">&nbsp; </span></b><span class="style10"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span class="style10">
                                <asp:CheckBox ID="ChkDrinage_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkDrinage_MH_CheckedChanged"
                                    Style="font-weight: 700" Text="مناهل تصريف سيول" />
                            </span>
                        </td>
                        <td colspan="2">
                            <span class="style8">العدد</span></span></span><telerik:RadNumericTextBox ID="rntxtDrinage_MHCount"
                                runat="server" Culture="ar-QA" DataType="System.Int16" MinValue="0" Width="125px"
                                Enabled="False" CssClass="style8">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td colspan="2">
                            <b><span class="style10">
                                <asp:CheckBox ID="ChkSTC_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSTC_MH_CheckedChanged"
                                    Text="مناهل هاتف" />
                            </span></b><span class="style10"></span>
                        </td>
                        <td colspan="2">
                            <span class="style10">العدد </span></span>
                            <telerik:RadNumericTextBox ID="rntxtSTC_MHCount" runat="server" Culture="ar-QA" DataType="System.Int16"
                                MinValue="0" Width="125px" Enabled="False">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" colspan="2">
                            <span class="style10">
                                <asp:CheckBox ID="ChkSewage_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSewage_MH_CheckedChanged"
                                    Style="font-weight: 700" Text="مناهل صرف صحي" />
                            </span>
                        </td>
                        <td colspan="2">
                            <span class="style10">العدد </span></span>
                            <telerik:RadNumericTextBox ID="rntxtSewage_MHCount" runat="server" Culture="ar-QA"
                                DataType="System.Int16" MinValue="0" Width="125px" Enabled="False">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td colspan="2">
                            <b><span class="style10">
                                <asp:CheckBox ID="ChkWater_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkWater_MH_CheckedChanged"
                                    Text="مناهل مياه" />
                            </span></b><span class="style10"></span>
                        </td>
                        <td colspan="2">
                            <span class="style10">العدد </span></span>
                            <telerik:RadNumericTextBox ID="rnTxtWater_MHCount" runat="server" Culture="ar-QA"
                                DataType="System.Int32" MinValue="0" Width="125px" Enabled="False">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="style10">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            مقاول الإنارة
                        </td>
                        <td class="style10">
                            <asp:DropDownList ID="ddlLightingContractor" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_NO">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style10">
                            تاريخ الاستلام
                        </td>
                        <td class="style10">
                            <telerik:RadDatePicker ID="radLightingFinishDate" runat="server">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
                        </td>
                        <td class="style10">
                            رقم العقد
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="txtLightingContractNo" MaxLength="50" runat="server"></asp:TextBox>
                        </td>
                        <td class="style10">
                            اسم المشروع
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="txtLightingContractName" MaxLength="500" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" colspan="2">
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlLightingContractor"
                                ErrorMessage="الرجاء اختيار مقاول التنفيذ" Style="font-size: small; font-weight: 700"
                                ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="radLightingFinishDate"
                                ErrorMessage="الرجاء إدخال تاريخ الاستلام" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLightingContractNo"
                                ErrorMessage="الرجاء إدخال رقم العقد" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtLightingContractName"
                                ErrorMessage="الرجاء إدخال اسم المشروع" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            مقاول التشجير
                        </td>
                        <td class="style10">
                            <asp:DropDownList ID="ddlTreesContractor" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_NO">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style10">
                            تاريخ الاستلام
                        </td>
                        <td class="style10">
                            <telerik:RadDatePicker ID="rdtpTreesFinishDate" runat="server">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
                        </td>
                        <td class="style10">
                            رقم العقد
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="txtTreesContractNo" MaxLength="50" runat="server"></asp:TextBox>
                        </td>
                        <td class="style10">
                            اسم المشروع
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="txtTreesContractName" MaxLength="500" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" colspan="2">
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlTreesContractor"
                                ErrorMessage="الرجاء اختيار مقاول التنفيذ" Style="font-size: small; font-weight: 700"
                                ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rdtpTreesFinishDate"
                                ErrorMessage="الرجاء إدخال تاريخ الاستلام" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTreesContractNo"
                                ErrorMessage="الرجاء إدخال رقم العقد" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtTreesContractName"
                                ErrorMessage="الرجاء إدخال اسم المشروع" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            مقاول الأرصفة
                        </td>
                        <td class="style10">
                            <asp:DropDownList ID="ddlPavingContractor" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_NO">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style10">
                            تاريخ الاستلام
                        </td>
                        <td class="style10">
                            <telerik:RadDatePicker ID="rdtpPavingFinishDate" runat="server">
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker>
                        </td>
                        <td class="style10">
                            رقم العقد
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="txtpavingContractNo" MaxLength="50" runat="server"></asp:TextBox>
                        </td>
                        <td class="style10">
                            اسم المشروع
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="txtpavingContractName" MaxLength="500" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" colspan="2">
                            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlContractors"
                                ErrorMessage="الرجاء اختيار مقاول التنفيذ" Style="font-size: small; font-weight: 700"
                                ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rdtpPavingFinishDate"
                                ErrorMessage="الرجاء إدخال تاريخ الاستلام" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtpavingContractNo"
                                ErrorMessage="الرجاء إدخال رقم العقد" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style10" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtpavingContractName"
                                ErrorMessage="الرجاء إدخال اسم المشروع" Style="font-weight: 700; font-size: small"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" colspan="8">
                            <span class="style10">
                                <asp:Label ID="lblFeedbackSave" runat="server" ForeColor="Red"></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td colspan="2">
                            <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="حفظ"
                                CssClass="style10" />
                        </td>
                        <td colspan="2">
                            &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" OnClick="UpdateCancelButton_Click"
                                Text="إلغاء" CssClass="style10" />
                        </td>
                        <td class="style10" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:GridView ID="gvR4Streets" runat="server" DataSourceID="odsR4StreetsInfo" AllowPaging="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="R4_ST_ID" ForeColor="#333333"
                    GridLines="None" EnableModelValidation="True">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="R4_ST_ID" HeaderText="R4_ST_ID" ReadOnly="True" SortExpression="R4_ST_ID"
                            Visible="False" />
                        <asp:BoundField DataField="R4_NO" HeaderText="الرقم" SortExpression="R4_NO" />
                        <asp:BoundField DataField="R4_NAME" HeaderText="اسم الطريق المستحدث" SortExpression="R4_NAME" />
                        <asp:BoundField DataField="R4_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الاستحداث"
                            SortExpression="R4_DATE" />
                        <asp:HyperLinkField DataNavigateUrlFields="R4_ST_ID" DataNavigateUrlFormatString="EditR4Street.aspx?id={0}"
                            HeaderText="تعديل" Text="..." />
                        <asp:HyperLinkField DataNavigateUrlFields="R4_ST_ID" DataNavigateUrlFormatString="R4tests.aspx?R4ID={0}"
                            HeaderText="الاختبارات" Text="..." />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsR4StreetsInfo" runat="server" DeleteMethod="Delete"
                    SelectMethod="GetR4StreetsList" TypeName="JpmmsClasses.BL.R4Streets" OnDeleted="odsR4StreetsInfo_Deleted">
                    <DeleteParameters>
                        <asp:Parameter Name="R4_ST_ID" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
