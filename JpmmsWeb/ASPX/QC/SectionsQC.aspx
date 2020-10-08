<%@ Page Title="ضبط الجودة لمسوحات مقاطع الشوارع الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SectionsQC.aspx.cs" Inherits="ASPX_QC_SectionsQC" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchSection.ascx" TagName="SearchSection" TagPrefix="uc2" %>
<%@ Register Src="../../ASCX/SearchMainSt.ascx" TagName="SearchMainSt" TagPrefix="uc1" %>
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
        .style3
        {
            height: 116px;
        }
        .style4
        {
            width: 50%;
            float: right;
        }
        .style5
        {
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
            <td colspan="2">
                <h2 class="style2">
                    <b>ضبط الجودة لمسوحات مقاطع الشوارع الرئيسية</b></h2>
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
            <td colspan="2">
                <asp:ObjectDataSource ID="odsSectionLanes" runat="server" SelectMethod="GetSectionLanes"
                    TypeName="JpmmsClasses.BL.Lane">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlSections" Name="sectionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsLaneSamples" runat="server" SelectMethod="GetLaneSamples"
                    TypeName="JpmmsClasses.BL.LaneSample" UpdateMethod="UpdateLaneInfo">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlLanes" Name="laneID" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SAMPLE_LENGTH" Type="Double" />
                        <asp:Parameter Name="SAMPLE_WIDTH" Type="Double" />
                        <asp:Parameter Name="SAMPLE_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="GetMainStreetSections"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainSt" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td rowspan="2">
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click">بحث عن مسح ضبط جودة سابق</asp:LinkButton>
                <br />
                <asp:Panel runat="server" ID="pnlEntry">
                    <table width="80%">
                        <tr>
                            <td width="20%">
                                <b>تاريخ ضبط الجودة</b>
                            </td>
                            <td width="40%">
                                <telerik:RadDatePicker ID="rdtpQcDate" runat="server" Culture="Arabic (Qatar)">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td width="20%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdtpQcDate"
                                    ErrorMessage="الرجاء إدخال تاريخ ضبط الجودة" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            </td>
                            <td width="10%" rowspan="10">
                                <uc1:SearchMainSt ID="SearchMainSt1" runat="server" Visible="false" OnSetSearchChanged="onMainStSearchChanged" />
                            </td>
                            <td width="10%" rowspan="10">
                                <uc2:SearchSection ID="SearchSection1" runat="server" Visible="false" OnSetSearchChanged="onSectionSearchChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>تاريخ المسح</b>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="rdtpSurveyDate" runat="server" Culture="Arabic (Qatar)">
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdtpSurveyDate"
                                    ErrorMessage="الرجاء إدخال تاريخ المسح" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>اسم المساح</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSurveyor" runat="server" DataSourceID="odsSurveyor" DataTextField="SURVEYOR_NAME"
                                    DataValueField="SURVEYOR_NO" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ValidationGroup="insert"
                                    ControlToValidate="ddlSurveyor" ErrorMessage="الرجاء اختيار المساح" Operator="NotEqual"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>اسم المراقب</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlQcSurveyor" runat="server" DataSourceID="odsSurveyor" DataTextField="SURVEYOR_NAME"
                                    DataValueField="SURVEYOR_NO" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlQcSurveyor"
                                    ErrorMessage="الرجاء اختيار المراقب" Operator="NotEqual" ValidationGroup="insert"
                                    ValueToCompare="0"></asp:CompareValidator>
                                <br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="مساح المنطقة لايمكن ان يكون هو نفس المراقب"
                                    ControlToCompare="ddlSurveyor" ControlToValidate="ddlQcSurveyor" Operator="NotEqual"
                                    ValidationGroup="insert"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>الشارع الرئيسي</b>
                            </td>
                            <td>
                                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                    ID="ddlMainSt" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                                    OnSelectedIndexChanged="ddlMainSt_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:LinkButton ID="lbtnSearch" runat="server" OnClick="lbtnSearch_Click" ToolTip="بحث متقدم بجزء من اسم أو رقم الطريق الرئيسي">بحث متقدم </asp:LinkButton>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>المقطع</b>
                            </td>
                            <td>
                                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                    ID="ddlSections" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                    OnSelectedIndexChanged="ddlSections_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:LinkButton ID="lbtnSearchSection" runat="server" OnClick="lbtnSearchSection_Click"
                                    ToolTip="بحث متقدم بجزء من اسم أو رقم المقطع">بحث متقدم </asp:LinkButton>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlSections"
                                    ErrorMessage="الرجاء اختيار المقطع" Operator="NotEqual" ValidationGroup="insert"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                مساحة المقطع
                            </td>
                            <td>
                                <asp:Label ID="lblSectionAreaSum" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>المسار </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLanes" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="odsSectionLanes" DataTextField="LANE_TYPE" DataValueField="LANE_ID"
                                    OnSelectedIndexChanged="ddlLanes_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="ddlLanes"
                                    ErrorMessage="الرجاء اختيار المسار" Operator="NotEqual" ValidationGroup="insert"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>العينة</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSamples" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="odsLaneSamples" DataTextField="SAMPLE_NO" DataValueField="SAMPLE_ID">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlSamples"
                                    ErrorMessage="الرجاء اختيار العينة" Operator="NotEqual" ValidationGroup="insert"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" OnClick="UpdateButton_Click" ValidationGroup="insert"
                                    Text="حفظ" CssClass="style5" />
                            </td>
                            <td>
                                <asp:Button ID="UpdateCancelButton" runat="server" OnClick="UpdateCancelButton_Click"
                                    Text="إلغاء" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel Visible="false" runat="server" ID="pnlSearch">
                    <table width="40%">
                        <tr>
                            <td>
                                <b>اسم المساح</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSurveyorSearch" runat="server" DataSourceID="odsSurveyor"
                                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" AppendDataBoundItems="True"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>الشارع الرئيسي</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMainStSearch" runat="server" AppendDataBoundItems="True"
                                    AutoPostBack="True" DataSourceID="odsMainStreets" DataTextField="main_title"
                                    DataValueField="STREET_ID" OnSelectedIndexChanged="ddlMainSt_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
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
                                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">إلغاء</asp:LinkButton>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:ObjectDataSource ID="odsSurveyor" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    SelectMethod="GetAllSurveyors" TypeName="JpmmsClasses.BL.Surveyor" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="SURVEYOR_NO" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="SURVEYOR_NAME" Type="String" />
                        <asp:Parameter Name="SURVEYOR_WORK_STARTDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_WORK_ENDDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_PHONE_NO" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SURVEYOR_NAME" Type="String" />
                        <asp:Parameter Name="SURVEYOR_WORK_STARTDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_WORK_ENDDATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_PHONE_NO" Type="String" />
                        <asp:Parameter Name="SURVEYOR_NO" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="direction: rtl">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistressesWithCleanOne"
                    TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="sdsDistSeverity" runat="server" SelectMethod="GetDistressSeverities"
                    TypeName="JpmmsClasses.BL.Lookups.DistressSeverity">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlDistresses" Name="distCode" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="gvQChecks" runat="server" DataSourceID="odsQChecks" AllowPaging="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="QC_CHECK_ID" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="gvQChecks_SelectedIndexChanged" OnRowDeleting="gvQChecks_RowDeleting"
                    OnRowUpdating="gvQChecks_RowUpdating" AllowSorting="True">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="QC_CHECK_ID" HeaderText="QC_CHECK_ID" ReadOnly="True"
                            SortExpression="QC_CHECK_ID" Visible="False" />
                        <asp:TemplateField HeaderText="تاريخ ضبط الجودة" SortExpression="QC_DATE">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="rdtpQcDate" runat="server" Culture="Arabic (Qatar)" DbSelectedDate='<%# Bind("QC_DATE") %>'>
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdtpQcDate"
                                    ErrorMessage="الرجاء إدخال تاريخ ضبط الجودة" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("QC_DATE", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ المسح" SortExpression="SURVEY_DATE">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="rdtpSurveyDate" runat="server" Culture="Arabic (Qatar)"
                                    SelectedDate='<%# Bind("SURVEY_DATE") %>' DbSelectedDate='<%# Bind("SURVEY_DATE") %>'>
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdtpSurveyDate"
                                    ErrorMessage="الرجاء إدخال تاريخ المسح" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("SURVEY_DATE", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم المساح" SortExpression="SURVEYOR_NAME">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSurveyor" runat="server" DataSourceID="odsSurveyor" DataTextField="SURVEYOR_NAME"
                                    DataValueField="SURVEYOR_NO" AppendDataBoundItems="True" SelectedValue='<%# Bind("SURVEYOR_ID") %>'>
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ValidationGroup="edit"
                                    ControlToValidate="ddlSurveyor" ErrorMessage="الرجاء اختيار المساح" Operator="NotEqual"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم المراقب" SortExpression="QCHECKER_NAME">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlQcSurveyor" runat="server" DataSourceID="odsSurveyor" DataTextField="SURVEYOR_NAME"
                                    DataValueField="SURVEYOR_NO" AppendDataBoundItems="True" SelectedValue='<%# Bind("QC_CHECKER_ID") %>'>
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlQcSurveyor"
                                    ErrorMessage="الرجاء اختيار المراقب" Operator="NotEqual" ValidationGroup="edit"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("QCHECKER_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MAIN_TITLE" HeaderText="الشارع الرئيسي" SortExpression="MAIN_TITLE"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SECTION_TITLE" HeaderText="المقطع" SortExpression="SECTION_TITLE"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SAMPLE_TITLE" HeaderText="العينة" SortExpression="SAMPLE_TITLE"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SURV_RATING" HeaderText="تقييم المساح" ReadOnly="True"
                            SortExpression="SURV_RATING" Visible="False" />
                        <asp:CheckBoxField DataField="IS_CORRECTED" HeaderText="تم تصحيحه؟" />
                        <asp:CommandField SelectText="تفاصيل" ShowSelectButton="True" CancelText="إلغاء"
                            EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" ValidationGroup="edit" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsQCheckDists" runat="server" InsertMethod="AddQCheckDistressRecord"
                    SelectMethod="GetQcDistress" TypeName="JpmmsClasses.BL.QcCheck" DeleteMethod="DeleteQCheckDistress"
                    OnDeleted="odsQCheckDists_Deleted" OnUpdated="odsQCheckDists_Updated" UpdateMethod="UpdateQCheckDistress">
                    <DeleteParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        <asp:Parameter Name="SURV_DIST_AREA" Type="Double" />
                        <asp:Parameter Name="QC_DIST_AREA" Type="Double" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvQChecks" Name="qcID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="gvQChecks" Name="QC_CHECK_ID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:Parameter Name="DIST_CODE" Type="Int32" />
                        <asp:Parameter Name="DIST_SEVERITY" Type="Char" />
                        <asp:Parameter Name="SURV_DIST_AREA" Type="Double" />
                        <asp:Parameter Name="QC_DIST_AREA" Type="Double" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsQChecks" runat="server" DeleteMethod="Delete" SelectMethod="GetAllSectionsQChecks"
                    TypeName="JpmmsClasses.BL.QcCheck" OnDeleted="odsQChecks_Deleted" UpdateMethod="UpdateSectionQcCheckRecord"
                    OnUpdated="odsQChecks_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="QC_CHECK_ID" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="sectionID" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlSurveyorSearch" Name="surveyorID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlMainStSearch" Name="mainStID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="QC_DATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEY_DATE" Type="DateTime" />
                        <asp:Parameter Name="SURVEYOR_ID" Type="Int32" />
                        <asp:Parameter Name="QC_CHECKER_ID" Type="Int32" />
                        <asp:Parameter Name="QC_CHECK_ID" Type="Int32" />
                        <asp:Parameter Name="IS_CORRECTED" Type="Boolean" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                <asp:FormView ID="frvRating" runat="server" DataSourceID="odsSurveyorRating" Visible="False"
                    OnDataBound="frvRating_DataBound">
                    <EditItemTemplate>
                        SURV_SUM_POINTS:
                        <asp:TextBox ID="SURV_SUM_POINTSTextBox" runat="server" Text='<%# Bind("SURV_SUM_POINTS") %>' />
                        <br />
                        SURV_SUM_MAX_POINTS:
                        <asp:TextBox ID="SURV_SUM_MAX_POINTSTextBox" runat="server" Text='<%# Bind("SURV_SUM_MAX_POINTS") %>' />
                        <br />
                        SURV_RATE:
                        <asp:TextBox ID="SURV_RATETextBox" runat="server" Text='<%# Bind("SURV_RATE") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        SURV_SUM_POINTS:
                        <asp:TextBox ID="SURV_SUM_POINTSTextBox" runat="server" Text='<%# Bind("SURV_SUM_POINTS") %>' />
                        <br />
                        SURV_SUM_MAX_POINTS:
                        <asp:TextBox ID="SURV_SUM_MAX_POINTSTextBox" runat="server" Text='<%# Bind("SURV_SUM_MAX_POINTS") %>' />
                        <br />
                        SURV_RATE:
                        <asp:TextBox ID="SURV_RATETextBox" runat="server" Text='<%# Bind("SURV_RATE") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <b>نقاط المساح </b>
                                </td>
                                <td>
                                    <asp:Label ID="SURV_SUM_POINTSLabel" runat="server" Text='<%# Bind("SURV_SUM_POINTS") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>النقاط العظمى </b>
                                </td>
                                <td>
                                    <asp:Label ID="SURV_SUM_MAX_POINTSLabel" runat="server" Text='<%# Bind("SURV_SUM_MAX_POINTS") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>تقييم المساح</b>
                                </td>
                                <td>
                                    <asp:Label ID="SURV_RATELabel" runat="server" Text='<%# Bind("SURV_RATE") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة المسح</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SURV_RATING") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <%--    <asp:LinkButton ID="lnkRemoveDistress" CommandArgument='<%# Bind("QC_CHECK_ID") %>'
                                        Visible='<%# (Eval("SURV_RATING").ToString()!="ناجح") %>' OnClientClick="return confirm('هل تريد الحذف فعلا؟');"
                                        runat="server" OnClick="lnkRemoveDistress_Click">حذف عيوب جميع عينات مسار المقطع</asp:LinkButton>--%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsSurveyorRating" runat="server" SelectMethod="GetSurveyorRatingForQC"
                    TypeName="JpmmsClasses.BL.QcCheck">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvQChecks" Name="qcID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td class="style3" colspan="2">
                &nbsp;<br />
                <asp:Panel ID="pnlDists" runat="server" Visible="false">
                    <table align="right" class="style4">
                        <tr>
                            <td>
                                <b>رمز واسم العيب </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                    DataTextField="distress_title" DataValueField="DIST_CODE" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDistresses_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>الشدة</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistressSeverity" runat="server" AppendDataBoundItems="True"
                                    DataSourceID="sdsDistSeverity" DataTextField="dist_sever" DataValueField="dist_sever">
                                    <asp:ListItem Value="N">اختيار</asp:ListItem>
                                    <asp:ListItem>L</asp:ListItem>
                                    <asp:ListItem>M</asp:ListItem>
                                    <asp:ListItem>H</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <b>مساحة العيب للمساح </b>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtDistSurvArea" runat="server" Culture="Arabic (Qatar)"
                                    DataType="System.Double" MinValue="0" Width="140px">
                                    <NumberFormat DecimalDigits="2" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>مساحة العيب للمراقب </b>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtDistQcArea" runat="server" Culture="Arabic (Qatar)"
                                    DataType="System.Double" MinValue="0" Width="140px">
                                    <NumberFormat DecimalDigits="2" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSaveDist" runat="server" OnClick="btnSaveDist_Click" Text="حفظ"
                                    CausesValidation="false" ValidationGroup="insertDist" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelDist" runat="server" OnClick="btnCancelDist_Click" Text="إلغاء" />
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="style3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlData" Visible="false" runat="server">
                    <table width="100%">
                        <tr>
                            <td colspan="4">
                                <b>تفاصيل شدات العيوب</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="gvQcDistress" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataKeyNames="RECORD_ID" DataSourceID="odsQCheckDists" ForeColor="#333333" GridLines="None"
                                    AllowPaging="True" Visible="False" OnRowDeleting="gvQcDistress_RowDeleting" OnRowUpdating="gvQcDistress_RowUpdating">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:BoundField DataField="QC_CHECK_ID" HeaderText="QC_CHECK_ID" SortExpression="QC_CHECK_ID"
                                            Visible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="DIST_TITLE" HeaderText="نوع العيب" SortExpression="DIST_TITLE"
                                            ReadOnly="True" />
                                        <asp:BoundField DataField="DIST_SEVERITY" HeaderText="الشدة" SortExpression="DIST_SEVERITY"
                                            ReadOnly="True" />
                                        <asp:TemplateField HeaderText="كمية المساح" SortExpression="SURV_DIST_AREA">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="rntxtAreaSurv" runat="server" Culture="ar-QA" DataType="System.Double"
                                                    DbValue='<%# Bind("SURV_DIST_AREA", "{0:N2}") %>' MinValue="0" Width="140px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label21" runat="server" Text='<%# Bind("SURV_DIST_AREA", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="كمية المراقب" SortExpression="QC_DIST_AREA">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="rntxtAreaQC" runat="server" Culture="ar-QA" DataType="System.Double"
                                                    DbValue='<%# Bind("QC_DIST_AREA", "{0:N2}") %>' MinValue="0" Width="140px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label22" runat="server" Text='<%# Bind("QC_DIST_AREA", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="SURV_DIST_AREA" HeaderText="كمية المساح" SortExpression="SURV_DIST_AREA"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="QC_DIST_AREA" HeaderText="كمية المراقب" SortExpression="QC_DIST_AREA"
                                            DataFormatString="{0:0.00}" />--%>
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="DIFFERENCE" DataFormatString="{0:0.00}" HeaderText="الفرق %"
                                            SortExpression="DIFFERENCE" ReadOnly="True" />
                                        <asp:BoundField DataField="SURV_WEIGHT_SEV" HeaderText="وزن الشدة للمساح" SortExpression="SURV_WEIGHT_SEV"
                                            DataFormatString="{0:0.00}" ReadOnly="True" />
                                        <asp:BoundField DataField="CHECKER_WEIGHT_SEV" DataFormatString="{0:0.00}" HeaderText="وزن الشدة للمراقب"
                                            SortExpression="CHECKER_WEIGHT_SEV" ReadOnly="True" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="حذف"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <b>إجمالي العيوب</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="gvQcDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="RECORD_ID"
                                    DataSourceID="odsQcDetails" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" Visible="False">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="QC_CHECK_ID" HeaderText="QC_CHECK_ID" SortExpression="QC_CHECK_ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="DIST_TITLE" HeaderText="نوع العيب" SortExpression="DIST_TITLE" />
                                        <asp:BoundField DataField="SURV_AREA_SUM" HeaderText="كمية المساح" SortExpression="SURV_AREA_SUM"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="QC_AREA_SUM" HeaderText="كمية المراقب" SortExpression="QC_AREA_SUM"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="DIFFERENCE" HeaderText="الفرق %" SortExpression="DIFFERENCE"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="SURV_DIST_WEIGHT" HeaderText="وزن الشدة للمساح" SortExpression="SURV_DIST_WEIGHT"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="DIST_WEIGHT" HeaderText="وزن العيب" SortExpression="DIST_WEIGHT"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="SURV_DIST_POINTS" HeaderText="نقاط المساح" SortExpression="SURV_DIST_POINTS"
                                            DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="DIST_MAX_POINTS" HeaderText="النقاط العظمى" SortExpression="DIST_MAX_POINTS"
                                            DataFormatString="{0:0.00}" />
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsQcDetails" runat="server" SelectMethod="GetQcDetails"
                                    TypeName="JpmmsClasses.BL.QcCheck">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvQChecks" Name="qcID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
