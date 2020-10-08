<%@ Page Title="تقرير بيانات المناطق والشوارع الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SecondaryStInfoReport.aspx.cs" Inherits="ASPX_Reports_SecondaryStInfoReport" %>

<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
                    <b>تقرير بيانات المناطق والشوارع الفرعية</b></h2>
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
                &nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                &nbsp;<asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllMunicRegions"
                    TypeName="JpmmsClasses.BL.Municpiality">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMunic" Name="munic" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                البلدية الفرعية
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" autoselectfirstitem="true"
                    ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSubMunicipality" DataTextField="munic_name" DataValueField="munic_name"
                    OnSelectedIndexChanged="ddlMunic_SelectedIndexChanged">
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
                اسم المنطقة
            </td>
            <td>
                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" autoselectfirstitem="true"
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
                رقم الشارع الفرعي
            </td>
            <td>
                <asp:TextBox ID="txtStNo" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                اسم الشارع الفرعي<br />
                (يحتوي على)
            </td>
            <td>
                &nbsp;<asp:TextBox ID="txtStName" runat="server" Height="42px" TextMode="MultiLine"></asp:TextBox>
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
                    <tr>
                        <td colspan="2" style="margin-right: 200px">
                            <asp:RadioButton ID="radUsesConsider" runat="server" AutoPostBack="True" GroupName="uses"
                                Text="الأخذ في الاعتبار لبيانات الاستخدامات المجاورة" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radUsesIgnore" runat="server" AutoPostBack="True" Checked="True"
                                Text="عدم الأخذ في الاعتبار " CssClass="style11" />
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
                            <asp:CheckBox ID="chkNewlyBuilt" runat="server" Text="مباني قيد التشييد" Checked="True" />
                            <asp:CheckBox ID="chkSchools" runat="server" Text="مدارس" Checked="True" />
                        </td>
                        <td>
                            &nbsp;<asp:CheckBox ID="chkMasjid" runat="server" Text="مسجد/جامع" Checked="True" />
                            <asp:CheckBox ID="chkSport" runat="server" Text="نوادي رياضية" Checked="True" />
                        </td>
                        <td>
                            &nbsp;<asp:CheckBox ID="chkHospital" runat="server" Text="مستشفى/مستوصف" Checked="True" />
                            <asp:CheckBox ID="chkOtherUtils" runat="server" Text="استخدامات أخرى" AutoPostBack="True"
                                Checked="True" />
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
                                GroupName="holes" Text="الكل" CssClass="style11" />
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
                            <asp:RadioButton ID="radConcreteBlocksExists" runat="server" AutoPostBack="True"
                                GroupName="concrete" Text="توجد حواجز خرسانية" CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radConcreteBlocksNone" runat="server" AutoPostBack="True" GroupName="concrete"
                                Text="لاتوجد حواجز خرسانية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radConcreteBlocksBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="concrete" Text="الكل" CssClass="style11" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 120px">
                            <asp:RadioButton ID="radBumpsExists" runat="server" AutoPostBack="True" GroupName="Bumps"
                                Text="توجد مطبات صناعية" CssClass="style11" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radBumpsNone" runat="server" AutoPostBack="True" GroupName="Bumps"
                                Text="لاتوجد مطبات صناعية" CssClass="style11" />
                        </td>
                        <td>
                            <asp:RadioButton ID="radBumpsBoth" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="Bumps" Text="الكل" CssClass="style11" />
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
                        <td style="margin-right: 120px" colspan="4">
                            &nbsp;<asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
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
