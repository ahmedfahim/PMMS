<%@ Page Title="عيوب تقاطعات الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IntersectionDistresses.aspx.cs" Inherits="ASPX_Intersections_IntersectionDistresses" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            width: 50%;
        }
        .style5
        {
            font-size: small;
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
                <strong>
                    <asp:Label ID="Label4" runat="server" Text="عيوب تقاطعات الطرق الرئيسية"></asp:Label></strong>
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
                            <asp:Label ID="Label5" runat="server" Text="الشارع الرئيسي"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox AutoselectFirstItem="True" ID="ddlMainStreets" runat="server"
                                Font-Size="Medium" Filter="Contains" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged" Width="100%">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" Font-Size="Medium" />
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp;<asp:LinkButton ID="lbtnSearchMainSt" runat="server" OnClick="lbtnSearchMainSt_Click"
                                ToolTip="بحث متقدم بجزء من اسم أو رقم الطريق الرئيسي">بحث متقدم </asp:LinkButton>
                        </td>
                        <td rowspan="5">
                            <uc1:SearchMainSt ID="SearchMainSt1" runat="server" Visible="False" OnSetSearchChanged="onMainStSearchChanged" />
                        </td>
                        <td rowspan="5">
                            <uc2:SearchIntersect ID="SearchIntersect1" runat="server" Visible="False" OnSetSearchChanged="onIntersectSearchChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="التقاطعات"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainStreetIntersection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreetIntersections" DataTextField="intersection_title"
                                DataValueField="INTERSECTION_ID" OnSelectedIndexChanged="ddlMainStreetIntersection_SelectedIndexChanged"
                                CssClass="style5">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:LinkButton ID="lbtnSearchIntersect" runat="server" OnClick="lbtnSearchIntersect_Click"
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
                        <td colspan="2">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
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
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:FormView ID="frvIntersectInfo" runat="server" DataSourceID="odsIntersectionInfo">
                    <EditItemTemplate>
                        INTER_NO:
                        <asp:TextBox ID="INTER_NOTextBox" runat="server" Text='<%# Bind("INTER_NO") %>' />
                        <br />
                        INTEREC_STREET1:
                        <asp:TextBox ID="INTEREC_STREET1TextBox" runat="server" Text='<%# Bind("INTEREC_STREET1") %>' />
                        <br />
                        INTEREC_STREET2:
                        <asp:TextBox ID="INTEREC_STREET2TextBox" runat="server" Text='<%# Bind("INTEREC_STREET2") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        INTER_NO:
                        <asp:TextBox ID="INTER_NOTextBox" runat="server" Text='<%# Bind("INTER_NO") %>' />
                        <br />
                        INTEREC_STREET1:
                        <asp:TextBox ID="INTEREC_STREET1TextBox" runat="server" Text='<%# Bind("INTEREC_STREET1") %>' />
                        <br />
                        INTEREC_STREET2:
                        <asp:TextBox ID="INTEREC_STREET2TextBox" runat="server" Text='<%# Bind("INTEREC_STREET2") %>' />
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
                                    <b>
                                        <asp:Label ID="Label7" runat="server" Text="رقم التقاطع"></asp:Label></b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="INTER_NOLabel" runat="server" Text='<%# Bind("INTER_NO") %>' />
                                </td>
                                <td>
                                </td>
                                <td>
                                    <b></b>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label8" runat="server" Text="شارع رئيسي"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="INTEREC_STREET1Label" runat="server" Text='<%# Bind("INTEREC_STREET1") %>' />
                                </td>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label9" runat="server" Text="مع شارع"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="INTEREC_STREET2Label" runat="server" Text='<%# Bind("INTEREC_STREET2") %>' />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsIntersectionInfo" runat="server" SelectMethod="GetIntersection"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="intersectionID"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsIntersectionSamples" runat="server" SelectMethod="GetIntersectionSamples"
                    TypeName="JpmmsClasses.BL.IntersectionSamples" OnUpdated="odsIntersectionSamples_Updated"
                    UpdateMethod="UpdateIntersectionSampleArea">
                    <UpdateParameters>
                        <asp:Parameter Name="INTER_SAMP_ID" Type="Int32" />
                        <asp:Parameter Name="INTERSEC_SAMP_AREA" Type="Double" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                        <asp:Parameter Name="NOTES" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="intersectionID"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistressesWithCleanOne"
                    TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                <asp:GridView ID="gvIntersectionSamples" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="INTER_SAMP_ID" DataSourceID="odsIntersectionSamples"
                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvIntersectionSamples_SelectedIndexChanged"
                    OnRowUpdating="gvIntersectionSamples_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="INTER_SAMP_ID" HeaderText="INTER_SAMP_ID" ReadOnly="True"
                            SortExpression="INTER_SAMP_ID" Visible="False" />
                        <asp:BoundField DataField="INTER_SAMP_NO" HeaderText="رقم العينة" SortExpression="INTER_SAMP_NO"
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="المساحة">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Culture="ar-QA"
                                    DataType="System.Decimal" DbValue='<%# Bind("INTERSEC_SAMP_AREA") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("INTERSEC_SAMP_AREA", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:CommandField SelectText="..." ShowSelectButton="True" HeaderText="مسوحات العيوب" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%--<SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlSurvey" runat="server" Visible="False">
                    <table width="100%">
                        <tr>
                            <td>
                                <table class="style3">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="radOldSurvey" runat="server" AutoPostBack="True" Checked="True"
                                                GroupName="survey" Text="مسح موجود" OnCheckedChanged="radOldSurvey_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="radNewSurvey" runat="server" AutoPostBack="True" GroupName="survey"
                                                Text="مسح جديد" OnCheckedChanged="radNewSurvey_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="عدد المسوحات:"></asp:Label><asp:Label
                                                ID="lblSurveysCount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Panel ID="pnlNewSurvey" Visible="false" runat="server">
                                    <table class="style4">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="رقم المسح"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="rntxtSurveyNo" runat="server" DataType="System.Int16"
                                                    MinValue="0" Width="65px" MaxValue="1000">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="تاريخ المسح"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtpSurveyDate" runat="server" Width="120px">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNewSurveySave" runat="server" OnClick="btnNewSurveySave_Click"
                                                    Text="حفظ" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNewSurveyCancel" runat="server" OnClick="btnNewSurveyCancel_Click"
                                                    Text="إلغاء" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDistressDetails" runat="server" Visible="false">
                                    <table class="style4">
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Label ID="Label13" runat="server" Text="رقم المسح:"></asp:Label>
                                                    <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                                </b>
                                            </td>
                                            <td colspan="2">
                                                <b>
                                                    <asp:Label ID="Label14" runat="server" Text="تاريخ المسح:"></asp:Label>
                                                    <asp:Label ID="lblSurveyDate" runat="server"></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Label ID="Label15" runat="server" Text="رمز واسم العيب"></asp:Label>
                                                </b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                                    DataTextField="distress_title" DataValueField="DIST_CODE" AutoPostBack="True"
                                                    Width="120px" OnSelectedIndexChanged="ddlDistresses_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Label ID="Label17" runat="server" Text="الشدة"></asp:Label>
                                                </b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistressSeverity" runat="server" AppendDataBoundItems="True"
                                                    Width="120px" DataSourceID="sdsDistSeverity" DataTextField="dist_sever" DataValueField="dist_sever">
                                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="sdsDistSeverity" runat="server" SelectMethod="GetDistressSeverities"
                                                    TypeName="JpmmsClasses.BL.Lookups.DistressSeverity">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlDistresses" Name="distCode" PropertyName="SelectedValue"
                                                            Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Label ID="Label16" runat="server" Text="المساحة"></asp:Label>
                                                </b>
                                            </td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="rntxtArea" runat="server" DataType="System.Double"
                                                    MinValue="0" Width="140px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                                م2
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Label ID="Label18" runat="server" Text="ملاحظات"></asp:Label>
                                                </b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDistressNotes" runat="server" Height="33px" Width="120px" MaxLength="750"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table class="style5">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSaveDistress" runat="server" OnClick="btnSaveDistress_Click" Text="حفظ" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnCancelDistress" runat="server" OnClick="btnCancelDistress_Click"
                                                                Text="إلغاء" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsIntersectionSurveys"
                                    DataTextField="survey_title" DataValueField="survey_no" Visible="False" AutoPostBack="True"
                                    OnSelectedIndexChanged="radlOldSurveys_SelectedIndexChanged">
                                </asp:RadioButtonList>
                                <asp:ObjectDataSource ID="odsIntersectionSurveys" runat="server" SelectMethod="GetAvailableIntersectionSurveys"
                                    TypeName="JpmmsClasses.BL.DistressSurvey">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvIntersectionSamples" Name="intersectionSampleID"
                                            PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtnAddDistress" runat="server" OnClick="lbtnAddDistress_Click">إضافة عيب</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblDistressFeedback" runat="server" ForeColor="Red"></asp:Label>
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UDIEquationsHelp.pdf"
                                    Target="_blank">شرح توضيحي عن قيم نقاط الحسم وتصحيح الكثافة ومعامل التصحيح الكلي</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvIntersectDistresses" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="DIST_ID" DataSourceID="odsIntersectionSurveyDistresses"
                                    ForeColor="#333333" GridLines="None" OnRowDeleting="gvIntersectDistresses_RowDeleting"
                                    OnRowUpdating="gvIntersectDistresses_RowUpdating">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" Text="حذف"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SAMPLE_ID" HeaderText="SAMPLE_ID" ReadOnly="True" SortExpression="SAMPLE_ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="DISTRESS_TITLE" HeaderText="اسم ورمز العيب" ReadOnly="True"
                                            SortExpression="DISTRESS_TITLE" />
                                        <asp:BoundField DataField="DIST_SEVERITY" HeaderText="شدة العيب" ReadOnly="True"
                                            SortExpression="DIST_SEVERITY" />
                                        <asp:TemplateField HeaderText="المساحة (م2)" SortExpression="DIST_AREA">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="rntxtArea" runat="server" Culture="ar-QA" DataType="System.Double"
                                                    DbValue='<%# Bind("DIST_AREA", "{0:N2}") %>' MinValue="0" Width="140px">
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DIST_AREA", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DIST_DENSITY" DataFormatString="{0:N2}" HeaderText="الكثافة %"
                                            ReadOnly="True" SortExpression="DIST_DENSITY" />
                                        <asp:BoundField DataField="DEDUCT_VALUE" DataFormatString="{0:N2}" HeaderText="نقاط الحسم"
                                            ReadOnly="True" SortExpression="DEDUCT_VALUE" />
                                        <asp:BoundField DataField="DEN_DASH" DataFormatString="{0:N2}" HeaderText="تصحيح الكثافة"
                                            ReadOnly="True" SortExpression="DEN_DASH" />
                                        <asp:BoundField DataField="DEDUCT_DEN_DASH" DataFormatString="{0:N2}" HeaderText="معامل التصحيح الكلي"
                                            ReadOnly="True" SortExpression="DEDUCT_DEN_DASH" />
                                        <asp:BoundField DataField="SURVEY_DATE" DataFormatString="{0:d}" HeaderText="تاريخ المسح"
                                            ReadOnly="True" SortExpression="SURVEY_DATE" />
                                        <asp:BoundField DataField="SURVEY_DATE_H" DataFormatString="{0:d}" HeaderText="التاريخ الهجري للمسح"
                                            ReadOnly="True" SortExpression="SURVEY_DATE_H" />
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href='ViewDistressImage.aspx?DistID=<%# Eval("Dist_ID", "{0}") %>' target="_blank">
                                                    صورة</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <%-- <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsIntersectionSurveyDistresses" runat="server" SelectMethod="GetIntersectionSampleSurveyDistresses"
                    TypeName="JpmmsClasses.BL.DistressEntry.DistressEntry" DeleteMethod="DeleteIntersectionDistress"
                    OnDeleted="odsIntersectionSurveyDistresses_Deleted" OnUpdated="odsIntersectionSurveyDistresses_Updated"
                    UpdateMethod="UpdateIntersectionDistress">
                    <DeleteParameters>
                        <asp:Parameter Name="DIST_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvIntersectionSamples" Name="intersectionSampleID"
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="radlOldSurveys" Name="surveyNo" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="gvIntersectionSamples" Name="intersectSampleID"
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter Name="DIST_AREA" Type="Double" />
                        <asp:Parameter Name="DIST_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
