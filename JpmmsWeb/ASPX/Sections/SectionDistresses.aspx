<%@ Page Title="العيوب الطرقية للمقاطع" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SectionDistresses.aspx.cs" Inherits="ASPX_Sections_SectionDistresses" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../ASCX/SearchMainSt.ascx" TagName="SearchMainSt" TagPrefix="uc1" %>
<%@ Register Src="../../ASCX/SearchSection.ascx" TagName="SearchSection" TagPrefix="uc2" %>
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
            text-align: right;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 70%;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 30%;
            float: right;
        }
        .style6
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
                    <strong>العيوب الطرقية للمقاطع</strong></h2>
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
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            الشارع الرئيسي
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlMainStreets" runat="server" Sorted="True" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreets" DataTextField="main_title"
                                DataValueField="STREET_ID" OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <%--  </editable:EditableDropDownList> <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreets" DataTextField="main_title"
                                DataValueField="ID3" OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>--%>
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
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
            <td colspan="3" align="right">
                <asp:FormView ID="frvSectionInfo" runat="server" DataSourceID="odsSectionInfo" Width="45%">
                    <EditItemTemplate>
                        SECTION_NO:
                        <asp:TextBox ID="SECTION_NOTextBox" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                        <br />
                        SEC_DIRECTION:
                        <asp:TextBox ID="SEC_DIRECTIONTextBox" runat="server" Text='<%# Bind("SEC_DIRECTION") %>' />
                        <br />
                        SEC_ORDER:
                        <asp:TextBox ID="SEC_ORDERTextBox" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                        <br />
                        SEC_LENGTH:
                        <asp:TextBox ID="SEC_LENGTHTextBox" runat="server" Text='<%# Bind("SEC_LENGTH") %>' />
                        <br />
                        SEC_WIDTH:
                        <asp:TextBox ID="SEC_WIDTHTextBox" runat="server" Text='<%# Bind("SEC_WIDTH") %>' />
                        <br />
                        FROM_STREET:
                        <asp:TextBox ID="FROM_STREETTextBox" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                        <br />
                        TO_STREET:
                        <asp:TextBox ID="TO_STREETTextBox" runat="server" Text='<%# Bind("TO_STREET") %>' />
                        <br />
                        DISTRICT:
                        <asp:TextBox ID="DISTRICTTextBox" runat="server" Text='<%# Bind("DISTRICT") %>' />
                        <br />
                        MUNICIPALITY:
                        <asp:TextBox ID="MUNICIPALITYTextBox" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                        <br />
                        MAIN_NO:
                        <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                        <br />
                        SUBDIST_ID:
                        <asp:TextBox ID="SUBDIST_IDTextBox" runat="server" Text='<%# Bind("SUBDIST_ID") %>' />
                        <br />
                        MAIN_ST_TITLE:
                        <asp:TextBox ID="MAIN_ST_TITLETextBox" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        SECTION_NO:
                        <asp:TextBox ID="SECTION_NOTextBox" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                        <br />
                        SEC_DIRECTION:
                        <asp:TextBox ID="SEC_DIRECTIONTextBox" runat="server" Text='<%# Bind("SEC_DIRECTION") %>' />
                        <br />
                        SEC_ORDER:
                        <asp:TextBox ID="SEC_ORDERTextBox" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                        <br />
                        SEC_LENGTH:
                        <asp:TextBox ID="SEC_LENGTHTextBox" runat="server" Text='<%# Bind("SEC_LENGTH") %>' />
                        <br />
                        SEC_WIDTH:
                        <asp:TextBox ID="SEC_WIDTHTextBox" runat="server" Text='<%# Bind("SEC_WIDTH") %>' />
                        <br />
                        FROM_STREET:
                        <asp:TextBox ID="FROM_STREETTextBox" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                        <br />
                        TO_STREET:
                        <asp:TextBox ID="TO_STREETTextBox" runat="server" Text='<%# Bind("TO_STREET") %>' />
                        <br />
                        DISTRICT:
                        <asp:TextBox ID="DISTRICTTextBox" runat="server" Text='<%# Bind("DISTRICT") %>' />
                        <br />
                        MUNICIPALITY:
                        <asp:TextBox ID="MUNICIPALITYTextBox" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                        <br />
                        MAIN_NO:
                        <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                        <br />
                        SUBDIST_ID:
                        <asp:TextBox ID="SUBDIST_IDTextBox" runat="server" Text='<%# Bind("SUBDIST_ID") %>' />
                        <br />
                        MAIN_ST_TITLE:
                        <asp:TextBox ID="MAIN_ST_TITLETextBox" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
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
                                    <b>البلدية</b>
                                </td>
                                <td>
                                    <asp:Label ID="MUNICIPALITYLabel" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                                </td>
                                <td>
                                    <b>الحي</b>
                                </td>
                                <td>
                                    <asp:Label ID="DISTRICTLabel" runat="server" Text='<%# Bind("DISTRICT") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>رقم المقطع</b>
                                </td>
                                <td>
                                    <asp:Label ID="SECTION_NOLabel" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                                </td>
                                <td>
                                    <b></b>
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
                                    <asp:Label ID="MAIN_ST_TITLELabel" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
                                </td>
                                <td>
                                    <b>الاتجاه</b>
                                </td>
                                <td>
                                    <asp:Label ID="SEC_DIRECTIONLabel" runat="server" Text='<%# Bind("DIRECTION_name") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>من</b>
                                </td>
                                <td>
                                    <asp:Label ID="FROM_STREETLabel" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                                </td>
                                <td class="style6">
                                    <b>إلى </b>
                                </td>
                                <td>
                                    <asp:Label ID="TO_STREETLabel" runat="server" Text='<%# Bind("TO_STREET") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>رقم تسلسل<br />
                                        المقطع</b>
                                </td>
                                <td>
                                    <asp:Label ID="SEC_ORDERLabel" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                                </td>
                                <td>
                                    <b>&nbsp; الطول</b> (م)
                                </td>
                                <td>
                                    &nbsp;<asp:Label ID="SEC_ORDERLabel0" runat="server" Text='<%# Bind("SEC_LENGTH", "{0:N2}") %>' />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsSectionInfo" runat="server" SelectMethod="GetSectionInfo"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:RadioButtonList ID="radlLanes" runat="server" AutoPostBack="True" DataSourceID="odsSectionLanes"
                    DataTextField="LANE_TYPE" DataValueField="LANE_ID" OnSelectedIndexChanged="radlLanes_SelectedIndexChanged"
                    RepeatDirection="Horizontal" OnDataBound="radlLanes_DataBound">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:ObjectDataSource ID="odsSectionLanes" runat="server" SelectMethod="GetSectionLanes"
                    TypeName="JpmmsClasses.BL.Lane" OnUpdated="odsSectionLanes_Updated">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
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
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvLaneSamples" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="SAMPLE_ID" DataSourceID="odsLaneSamples" ForeColor="#333333" GridLines="None"
                    OnSelectedIndexChanged="gvLaneSamples_SelectedIndexChanged" OnRowUpdating="gvLaneSamples_RowUpdating"
                    AllowPaging="True" EnableModelValidation="True" OnPageIndexChanging="gvLaneSamples_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SAMPLE_ID" HeaderText="SAMPLE_ID" ReadOnly="True" SortExpression="SAMPLE_ID"
                            Visible="False" />
                        <asp:BoundField DataField="SAMPLE_NO" HeaderText="رقم العينة" SortExpression="SAMPLE_NO"
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="الطول" SortExpression="SAMPLE_LENGTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Culture="ar-QA"
                                    DataType="System.Decimal" DbValue='<%# Bind("SAMPLE_LENGTH") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SAMPLE_LENGTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العرض" SortExpression="SAMPLE_WIDTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Culture="ar-QA"
                                    DataType="System.Decimal" DbValue='<%# Bind("SAMPLE_WIDTH") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SAMPLE_WIDTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" ReadOnly="True"
                            SortExpression="AREA" />
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
                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistressesWithCleanOne"
                    TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsLaneSamples" runat="server" SelectMethod="GetLaneSamples"
                    TypeName="JpmmsClasses.BL.LaneSample" UpdateMethod="UpdateLaneInfo" OnUpdated="odsLaneSamples_Updated">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radlLanes" Name="laneID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SAMPLE_LENGTH" Type="Double" />
                        <asp:Parameter Name="SAMPLE_WIDTH" Type="Double" />
                        <asp:Parameter Name="SAMPLE_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                        <asp:Parameter Name="NOTES" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
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
                                                    MinValue="0" Width="65px" MaxValue="1000">
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
                                            <td class="style6">
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
                                                <asp:DropDownList ID="ddlDistressSeverity" runat="server" DataSourceID="sdsDistSeverity"
                                                    DataTextField="dist_sever" DataValueField="dist_sever" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="N">اختيار</asp:ListItem>
                                                    <asp:ListItem>L</asp:ListItem>
                                                    <asp:ListItem>M</asp:ListItem>
                                                    <asp:ListItem>H</asp:ListItem>
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
                                <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsSampleSurveys"
                                    DataTextField="survey_title" DataValueField="survey_no" Visible="False" AutoPostBack="True"
                                    OnSelectedIndexChanged="radlOldSurveys_SelectedIndexChanged">
                                </asp:RadioButtonList>
                                &nbsp;<asp:ObjectDataSource ID="odsSampleSurveys" runat="server" SelectMethod="GetAvailableSurveys"
                                    TypeName="JpmmsClasses.BL.DistressSurvey">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvLaneSamples" Name="sampleID" PropertyName="SelectedValue"
                                            Type="Int32" />
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
                                    Target="_blank">شرح توضيحي عن قيم نقاط الحسم وتصحيح الكثافة ومعامل التصحيح الكلي </asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvDistresses" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataKeyNames="DIST_ID" DataSourceID="odsSectionsurveyDistresses" ForeColor="#333333"
                                    GridLines="None" OnRowDeleting="gvDistresses_RowDeleting" OnRowUpdating="gvDistresses_RowUpdating">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" Text="حذف"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DIST_ID" Visible="False" />
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
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <%--<SortedAscendingCellStyle BackColor="#F5F7FB" />
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
                <asp:ObjectDataSource ID="odsSectionsurveyDistresses" runat="server" SelectMethod="GetSectionSampleSurveyDistresses"
                    TypeName="JpmmsClasses.BL.DistressEntry.DistressEntry" DeleteMethod="DeleteSectionDistress"
                    UpdateMethod="UpdateSectionDistress" OnDeleted="odsSectionsurveyDistresses_Deleted"
                    OnUpdated="odsSectionsurveyDistresses_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="DIST_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvLaneSamples" Name="sampleID" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="radlOldSurveys" Name="surveyNo" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="gvLaneSamples" Name="sampleID" PropertyName="SelectedValue"
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
