<%@ Page Title="عيوب المناطق والشوارع الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="RegionDistresses.aspx.cs" Inherits="ASPX_Regions_Regiondistresses" %>

<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchRegion.ascx" TagName="SearchRegion" TagPrefix="uc1" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
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
            text-align: right;
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
                    <strong>عيوب المناطق والطرق الفرعية</strong></h2>
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
                            <b>المنطقة الفرعية </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:LinkButton ID="lbtnSearch" runat="server" OnClick="lbtnSearch_Click" ToolTip="بحث متقدم بجزء من اسم أو رقم المنطقة الفرعية">بحث متقدم</asp:LinkButton>
                            <asp:ObjectDataSource ID="odsRegionInfo" runat="server" SelectMethod="GetRegionInfo"
                                TypeName="JpmmsClasses.BL.Region">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                                TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                        </td>
                        <td rowspan="3">
                            <uc1:SearchRegion ID="SearchRegion1" Visible="false" OnSetSearchChanged="OnSetSearchChanged"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FormView ID="frvRegionInfo" runat="server" DataSourceID="odsRegionInfo" Width="80%">
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
                        <td>
                            <asp:LinkButton ID="lbtnPagingNO" runat="server" OnClick="lbtnPagingNO_Click">صفحات</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtnPagingYes" runat="server" OnClick="lbtnPagingYes_Click">الكل</asp:LinkButton>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">إلغاء</asp:LinkButton>
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
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvRegionSamples" runat="server" DataSourceID="odsRegionSamples"
                    AutoGenerateColumns="False" DataKeyNames="STREET_ID" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="gvRegionSamples_SelectedIndexChanged"
                    OnRowUpdating="gvRegionSamples_RowUpdating" AllowPaging="True" EnableModelValidation="True"
                    PageSize="15" OnPageIndexChanged="gvRegionSamples_PageIndexChanged" 
                    onrowupdated="gvRegionSamples_RowUpdated">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="STREET_ID" HeaderText="STREET_ID" ReadOnly="True" SortExpression="STREET_ID"
                            Visible="False" />
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="الرقم" SortExpression="SECOND_ST_NO"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SECOND_AR_NAME" HeaderText="اسم الشارع الفرعي" SortExpression="SECOND_AR_NAME" />
                        <asp:TemplateField HeaderText="الطول" SortExpression="SECOND_ST_LENGTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtLengthSecST" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_LENGTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SECOND_ST_LENGTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العرض" SortExpression="SECOND_ST_WIDTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtWidthSecST" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_WIDTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SECOND_ST_WIDTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" SortExpression="AREA"
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="ملاحظات">
                            <EditItemTemplate>
                                <%--       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NOTES") %>'></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList1" runat="server" 
                                    AppendDataBoundItems="True" DataSourceID="ObjectsNOTES" DataTextField="NOTES" 
                                    DataValueField="NOTES" SelectedValue='<%# Bind("NOTES") %>'>
                                    <%--<asp:ListItem>يوجد اعمال بناء وجزء منه بلاط</asp:ListItem>
                                  <asp:ListItem>جزء من الشارع بلاط</asp:ListItem>
                                   <asp:ListItem>تراب</asp:ListItem>
                                    <asp:ListItem>موقف</asp:ListItem>
                                    <asp:ListItem>موقف خاص</asp:ListItem>
                                    <asp:ListItem>بلاط و تراب</asp:ListItem>
                                    <asp:ListItem>خرسانه</asp:ListItem>
                                    <asp:ListItem>مغلق</asp:ListItem>
                                    <asp:ListItem>مغلق امني</asp:ListItem>
                                    <asp:ListItem>اسفلت غير نظامي</asp:ListItem>
                                    <asp:ListItem>يوجد معدات بالشارع</asp:ListItem>
                                    <asp:ListItem>يوجد مخلفات بالشارع</asp:ListItem>
                                    <asp:ListItem>شارع متهالك</asp:ListItem>
                                    <asp:ListItem>داخل منطقه عسكريه</asp:ListItem>
                                    <asp:ListItem>داخل محطه قطار</asp:ListItem>
                                    <asp:ListItem>جزء من الشارع تراب</asp:ListItem>
                                    <asp:ListItem>جزء من الشارع مغلق</asp:ListItem>
                                    <asp:ListItem>داخل منطقه جبليه</asp:ListItem>
                                    <asp:ListItem>يوجد اعمال صيانه</asp:ListItem>
                                    <asp:ListItem>يوجد جزيره وسطيه</asp:ListItem>
                                    <asp:ListItem>يوجد اعمال صرف صحي </asp:ListItem>
                                    <asp:ListItem>يوجد اعمال بناء بالشارع</asp:ListItem>
                                    <asp:ListItem>يوجد مطبات غير نظاميه</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectsNOTES" runat="server" SelectMethod="GetNoteStreets" 
                                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("NOTES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DISTRESS" HeaderText="العيوب" ReadOnly="True" SortExpression="DISTRESS" />
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:CommandField ShowSelectButton="True" SelectText="إدخال" HeaderText="العمليات" />
                        <asp:BoundField DataField="NOTESOLD" HeaderText="المسح السابق" ReadOnly="True" />
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
                <asp:ObjectDataSource ID="odsRegionSamples" runat="server" SelectMethod="GetRegionSamplesWithDISTRESS"
                    TypeName="JpmmsClasses.BL.Region" OnUpdated="odsRegionSamples_Updated" UpdateMethod="UpdateSecondaryStreetSampleArea">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="ServeyNo" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="STREET_ID" Type="Int32" />
                        <asp:Parameter Name="SECOND_AR_NAME" Type="String" />
                        <asp:Parameter Name="SECOND_ST_LENGTH" Type="Double" />
                        <asp:Parameter Name="SECOND_ST_WIDTH" Type="Double" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                        <asp:Parameter Name="NOTES" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="sdsDistSeverity" runat="server" SelectMethod="GetDistressSeverities"
                    TypeName="JpmmsClasses.BL.Lookups.DistressSeverity">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlDistresses" Name="distCode" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSurveys" runat="server" SelectMethod="GetRegionSecondaryStreetAvailableSurveys"
                    TypeName="JpmmsClasses.BL.DistressSurvey">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvRegionSamples" Name="secondStID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistressesSecoundry"
                    TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
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
                                            عدد المسوحات:<asp:Label ID="lblSurveysCount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Panel ID="pnlNewSurvey" Visible="false" runat="server">
                                    <table class="style4">
                                        <tr>
                                            <td>
                                                رقم المسح
                                            </td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="rntxtSurveyNo" runat="server" DataType="System.Int16"
                                                    MinValue="3" Width="65px" MaxValue="1000" Enabled="true">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </td>
                                            <td>
                                                تاريخ المسح
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtpSurveyDate" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNewSurveySave" runat="server" OnClick="btnNewSurveySave_Click"
                                                    Text="حفظ" style="height: 26px" />
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
                                    <table>
                                        <tr>
                                            <td class="style5">
                                                <b>رقم المسح:
                                                    <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                                </b>
                                            </td>
                                            <td colspan="2">
                                                <b>&nbsp; تاريخ المسح:
                                                    <asp:Label ID="lblSurveyDate" runat="server"></asp:Label>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>رمز واسم العيب </b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                                    DataTextField="distress_title" DataValueField="DIST_CODE" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlDistresses_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>الشدة </b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistressSeverity" runat="server" AppendDataBoundItems="True"
                                                    DataSourceID="sdsDistSeverity" DataTextField="dist_sever" DataValueField="dist_sever">
                                                    <asp:ListItem Selected="True" Value="N">اختيار</asp:ListItem>
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
                                            <td>
                                                <b>المساحة </b>
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
                                                <b>ملاحظات </b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDistressNotes" runat="server" Height="33px" MaxLength="750" TextMode="MultiLine"></asp:TextBox>
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
                                <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsRegionSurveys"
                                    DataTextField="survey_title" DataValueField="survey_no" Visible="False" AutoPostBack="True"
                                    OnSelectedIndexChanged="radlOldSurveys_SelectedIndexChanged">
                                </asp:RadioButtonList>
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
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvDistresses" runat="server" AutoGenerateColumns="False" DataSourceID="odsSecondaryStSurveyDistresses"
                    CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="DIST_ID" OnRowDeleting="gvDistresses_RowDeleting"
                    OnRowUpdating="gvDistresses_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClientClick="return confirm('هل تريد الحذف فعلا؟');"
                                    CommandName="Delete" Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DIST_ID" Visible="False" />
                        <asp:BoundField DataField="SAMPLE_ID" HeaderText="SAMPLE_ID" SortExpression="SAMPLE_ID"
                            Visible="False" ReadOnly="True" />
                        <asp:BoundField DataField="DISTRESS_TITLE" HeaderText="اسم ورمز العيب" SortExpression="DISTRESS_TITLE"
                            ReadOnly="True" />
                        <asp:BoundField DataField="DIST_SEVERITY" HeaderText="شدة العيب" SortExpression="DIST_SEVERITY"
                            ReadOnly="True" />
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
                        <asp:BoundField DataField="DIST_DENSITY" HeaderText="الكثافة %" ReadOnly="True" SortExpression="DIST_DENSITY"
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="DEDUCT_VALUE" DataFormatString="{0:N2}" HeaderText="نقاط الحسم"
                            SortExpression="DEDUCT_VALUE" ReadOnly="True" />
                        <asp:BoundField DataField="DEN_DASH" DataFormatString="{0:N2}" HeaderText="تصحيح الكثافة"
                            SortExpression="DEN_DASH" ReadOnly="True" />
                        <asp:BoundField DataField="DEDUCT_DEN_DASH" DataFormatString="{0:N2}" HeaderText="معامل التصحيح الكلي"
                            SortExpression="DEDUCT_DEN_DASH" ReadOnly="True" />
                        <asp:BoundField DataField="SURVEY_DATE" DataFormatString="{0:d}" HeaderText="تاريخ المسح"
                            SortExpression="SURVEY_DATE" ReadOnly="True" />
                        <asp:BoundField DataField="SURVEY_DATE_H" DataFormatString="{0:d}" HeaderText="التاريخ الهجري للمسح"
                            SortExpression="SURVEY_DATE_H" ReadOnly="True" />
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="ViewDistressImage.aspx?DistID=<%# Eval("Dist_ID", "{0}") %>" target="_blank">
                                    صورة</a>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:ObjectDataSource ID="odsSecondaryStSurveyDistresses" runat="server" SelectMethod="GetRegionSecondaryStreetSurveyDistresses"
                    TypeName="JpmmsClasses.BL.DistressEntry.DistressEntry" DeleteMethod="DeleteSecondaryStreetRegionDistress"
                    OnDeleted="odsSecondaryStSurveyDistresses_Deleted" OnUpdated="odsSecondaryStSurveyDistresses_Updated"
                    UpdateMethod="UpdateRegionSecondaryStreetDistress">
                    <DeleteParameters>
                        <asp:Parameter Name="DIST_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvRegionSamples" Name="secondStID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="radlOldSurveys" Name="surveyNo" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="gvRegionSamples" Name="secondarystID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:Parameter Name="DIST_AREA" Type="Double" />
                        <asp:Parameter Name="DIST_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
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
        </tr>
    </table>
</asp:Content>
