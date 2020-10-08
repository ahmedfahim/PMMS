<%@ Page Title="أوزان معاملات اولويات الصيانة" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MaintPrioWeights.aspx.cs" Inherits="ASPX_Lookups_MaintPrioWeights" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            width: 20%;
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
                    <b>أوزان معاملات اولويات الصيانة</b></h2>
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
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                    <cc1:TabPanel runat="server" HeaderText="تصنيف الطريق" ID="TabPanel1">
                        <ContentTemplate>
                            <table width="50%">
                                <tr>
                                    <td>
                                        وزن الأولوية لحالة الرصف المقبولة للطرق الرئيسية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="MAIN_ST_GOOD_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="MAIN_ST_GOOD_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية لحالة الرصف السيئة للطرق الرئيسية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="MAIN_ST_POOR_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="MAIN_ST_POOR_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية لحالة الرصف المقبولة للشوارع الفرعية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="SECOND_ST_GOOD_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="SECOND_ST_GOOD_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية لحالة الرصف السيئة للشوارع الفرعية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="SECOND_ST_POOR_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="SECOND_ST_POOR_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="النشاط الجانبي للطرق الرئيسية - مقاطع وتقاطعات"
                        ID="TabPanel2">
                        <ContentTemplate>
                            <table width="50%">
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام السكني
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="HOUSES_SECTIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="HOUSES_SECTIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام التجاري
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="COMMERIAL_SECTIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="COMMERIAL_SECTIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام الصناعي وورش الصيانة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="INDISTERIAL_SECTIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="INDISTERIAL_SECTIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام استراحات
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="REST_HOUSE_SECTIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="REST_HOUSE_SECTIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام حدائق ومنتزهات
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="GARDENS_SECTIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="GARDENS_SECTIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام مرافق خدمية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="PUBLICS_SECTIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="PUBLICS_SECTIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="النشاط الجانبي لطرق المناطق الفرعية" ID="TabPanel4">
                        <ContentTemplate>
                            <table width="50%">
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام السكني
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="HOUSES_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="HOUSES_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام التجاري
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="COMMERIAL_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="COMMERIAL_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام الصناعي وورش الصيانة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="INDISTERIAL_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="INDISTERIAL_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام استراحات
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="REST_HOUSE_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="REST_HOUSE_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام حدائق ومنتزهات
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="GARDENS_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="GARDENS_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام مرافق خدمية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="PUBLICS_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="PUBLICS_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام مدارس
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="SCHOOL_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="SCHOOL_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام مسجد/جامع
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="MASJID_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="MASJID_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام مستشفى/مستوصف
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="HOSPITAL_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="HOSPITAL_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام نوادي رياضية
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="SPORT_CLUB_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="SPORT_CLUB_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدام مباني قيد التشييد
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="NEW_BUILDINGS_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="NEW_BUILDINGS_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية للاستخدامات الأخرى
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="OTHER_UTIL_REGIONSTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="OTHER_UTIL_REGIONSTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="حجم العد المروري" ID="TabPanel3">
                        <ContentTemplate>
                            <table width="50%">
                                <tr>
                                    <td>
                                        وزن الأولوية في حالة الكثافة المرورية المنخفضة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="TRAFFIC_LOW_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="TRAFFIC_LOW_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية في حالة الكثافة المرورية المتوسطة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="TRAFFIC_MEDIUM_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="TRAFFIC_MEDIUM_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية في حالة الكثافة المرورية المرتفعة
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="TRAFFIC_HIGH_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="TRAFFIC_HIGH_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        وزن الأولوية في حالة الكثافة المرورية المرتفعة جدا
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="TRAFFIC_VERY_HIGH_WEIGHTTextBox" runat="server" Culture="ar-SA"
                                            DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="الرجاء الإدخال"
                                            ControlToValidate="TRAFFIC_VERY_HIGH_WEIGHTTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false"
                                Text="إلغاء" />
                        </td>
                    </tr>
                </table>
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
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
