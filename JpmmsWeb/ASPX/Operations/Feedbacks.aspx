<%@ Page Title="عمليات صيانة عناصر شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Feedbacks.aspx.cs" Inherits="ASPX_Operations_Feedbacks" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2" colspan="2">
                <h2>
                    عمليات صيانة عناصر شبكة الطرق</h2>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center" width="40%">
                <table class="style1">
                    <tr>
                        <td>
                            <b>رقم العقد </b>
                        </td>
                        <td>
                            <asp:TextBox ID="CONTRACT_NOTextBox" runat="server" />
                        </td>
                        <td>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CONTRACT_NOTextBox"
                                ErrorMessage="الرجاء إدخال رقم العقد" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>المقاول </b>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:DropDownList ID="ddlContractors" Width="100px" runat="server" DataSourceID="odsContractors"
                                DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_ID" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlContractors"
                                ErrorMessage="الرجاء اختيار المقاول" Operator="NotEqual" ValidationGroup="insert"
                                ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>رقم أمر العمل </b>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:TextBox ID="txtJobOrderNo" runat="server" />
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtJobOrderNo"
                                ErrorMessage="الرجاء إدخال رقم أمر العمل" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>تاريخ أمر العمل </b>
                        </td>
                        <td style="margin-right: 40px">
                            <telerik:RadDatePicker ID="rdtpJobOrder" runat="server" Culture="ar-QA">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdtpJobOrder"
                                ErrorMessage="الرجاء إدخال تاريخ أمر العمل" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>تاريخ التنفيذ </b>
                        </td>
                        <td style="margin-right: 40px">
                            <telerik:RadDatePicker ID="rdtpFinishDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rdtpFinishDate"
                                ErrorMessage="الرجاء إدخال تاريخ التنفيذ" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddContract" runat="server" OnClick="btnAddContract_Click" Text="حفظ"
                                ValidationGroup="insert" />
                        </td>
                        <td style="margin-right: 40px">
                            <asp:Button ID="btnCancelContract" runat="server" Text="إلغاء" OnClick="btnCancelContract_Click" />
                        </td>
                        <td style="margin-right: 40px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                &nbsp;
                <asp:GridView ID="gvFeedbacks" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="odsFeedbacks" EnableModelValidation="True" ForeColor="#333333"
                    GridLines="None" DataKeyNames="FEEDBACK_ID" OnSelectedIndexChanged="gvFeedbacks_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="FEEDBACK_ID" HeaderText="FEEDBACK_ID" SortExpression="FEEDBACK_ID"
                            Visible="False" />
                        <asp:BoundField DataField="CONTRACT_NO" HeaderText="رقم العقد" SortExpression="CONTRACT_NO" />
                        <asp:BoundField DataField="FINISH_DATE" DataFormatString="{0:d}" HeaderText="تاريخ التنفيذ"
                            SortExpression="FINISH_DATE" />
                        <asp:BoundField DataField="JOB_ORDER_NO" HeaderText="رقم أمر العمل" SortExpression="JOB_ORDER_NO" />
                        <asp:BoundField DataField="JOB_ORDER_DATE" DataFormatString="{0:d}" HeaderText="تاريخ أمر العمل"
                            SortExpression="JOB_ORDER_DATE" />
                        <asp:BoundField DataField="CONTRACTOR_NAME" HeaderText="المقاول" SortExpression="CONTRACTOR_NAME" />
                        <asp:HyperLinkField DataNavigateUrlFields="Feedback_id" DataNavigateUrlFormatString="FeedbackFiles.aspx?id={0}"
                            HeaderText="ملفات" Target="_blank" Text="..." />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField SelectText="تفاصيل" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFeedbacks" runat="server" DeleteMethod="Delete" OnDeleted="odsFeedbacks_Deleted"
                    OnUpdated="odsFeedbacks_Updated" SelectMethod="GetAll" TypeName="JpmmsClasses.BL.MaintenanceFeedback"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="FEEDBACK_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="FEEDBACK_ID" Type="Int32" />
                        <asp:Parameter Name="CONTRACT_NO" Type="String" />
                        <asp:Parameter Name="CONTRACTOR_ID" Type="Int32" />
                        <asp:Parameter Name="JOB_ORDER_NO" Type="String" />
                        <asp:Parameter Name="JOB_ORDER_DATE" Type="DateTime" />
                        <asp:Parameter Name="FINISH_DATE" Type="DateTime" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel runat="server" ID="pnlDetails" Visible="false">
                    <table width="60%">
                        <tr>
                            <td width="30%">
                                &nbsp;
                            </td>
                            <td width="70%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="margin-right: 80px">
                                <b>
                                    <asp:RadioButton ID="radSection" runat="server" AutoPostBack="True" Checked="True"
                                        GroupName="type" OnCheckedChanged="radSection_CheckedChanged" Text="مقطع" />
                                    &nbsp; </b>
                            </td>
                            <td rowspan="2">
                                <asp:Panel ID="pnlMainSt" runat="server" Visible="false">
                                    شارع
                                    <telerik:RadComboBox ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                        AutoPostBack="True" AutoselectFirstItem="True" DataSourceID="odsMainStreets"
                                        Filter="Contains" Width="200px" Font-Size="Medium" DataTextField="MAIN_NAME"
                                        DataValueField="STREET_ID" OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" Font-Size="Medium" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <br />
                                    <telerik:RadComboBox ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True"
                                        AutoPostBack="True" AutoselectFirstItem="true" DataSourceID="odsMainStreetSections"
                                        Filter="Contains" Width="200px" Font-Size="Medium" DataTextField="section_from_to"
                                        DataValueField="section_id" OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" Font-Size="Medium" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <telerik:RadComboBox ID="ddlMainStreetIntersection" runat="server" AppendDataBoundItems="True"
                                        AutoPostBack="True" AutoselectFirstItem="true" DataSourceID="odsMainStreetIntersections0"
                                        Filter="Contains" Width="200px" Font-Size="Medium" DataTextField="intersection_title"
                                        DataValueField="INTERSECTION_ID" OnSelectedIndexChanged="ddlMainStreetIntersection_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" Font-Size="Medium" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <br />
                                    العينة
                                    <asp:DropDownList ID="ddlSamples" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="odsSamples" DataTextField="sample_title" DataValueField="sample_id"
                                        OnSelectedIndexChanged="ddlSamples_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Text="اختيار" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="margin-right: 80px">
                                <b>
                                    <asp:RadioButton ID="radIntersect" runat="server" AutoPostBack="True" GroupName="type"
                                        OnCheckedChanged="radIntersect_CheckedChanged" Text="تقاطع" />
                                    &nbsp; </b>
                            </td>
                        </tr>
                        <tr>
                            <td style="margin-right: 80px">
                                <b>
                                    <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" GroupName="type"
                                        OnCheckedChanged="radRegion_CheckedChanged" Text="منطقة فرعية" />
                                </b>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    AutoselectFirstItem="true" DataSourceID="odsRegions" DataTextField="region_title"
                                    Filter="Contains" Width="200px" Font-Size="Medium" DataValueField="region_id"
                                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" Font-Size="Medium" />
                                    </Items>
                                </telerik:RadComboBox>
                                <br />
                                <telerik:RadComboBox ID="ddlRegionSecondaryStreets" runat="server" AppendDataBoundItems="True"
                                    AutoPostBack="True" AutoselectFirstItem="True" DataSourceID="odsRegionSecondaryStreets"
                                    Filter="Contains" Width="200px" Font-Size="Medium" DataTextField="second_st_title"
                                    DataValueField="STREET_ID" OnSelectedIndexChanged="ddlRegionSecondaryStreets_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" Font-Size="Medium" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="margin-right: 80px">
                                <b>حالة الرصف قبل الصيانة </b>
                            </td>
                            <td>
                                <asp:Label ID="lblUdiBefore" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ui-priority-primary" style="margin-right: 80px">
                                <b>قرار الصيانة </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMaintDecisions" runat="server" AppendDataBoundItems="True"
                                    AutoPostBack="True" DataSourceID="odsAllMaintDecisions" DataTextField="RECOMMENDED_DECISION_AR"
                                    DataValueField="RECOMMENDED_DECISION_ID" OnSelectedIndexChanged="ddlMaintDecisions_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="margin-right: 80px">
                                <b>حالة الرصف بعد الصيانة </b>
                            </td>
                            <td>
                                <asp:Label ID="lblUdiAfter" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="margin-right: 80px">
                                <b>تاريخ تنفيذ الصيانة </b>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="rdtpMaintDate" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="margin-right: 80px">
                                <table class="style2">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelLocation" runat="server" OnClick="btnCancelLocation_Click"
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
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                    TypeName="JpmmsClasses.BL.SecondaryStreets">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="GetMainStreetSectionsNonR4R3"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSamples" runat="server" SelectMethod="GetMainStreetSamples"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radIntersect" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="interID" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsAllMaintDecisions" runat="server" SelectMethod="GetAllDecisionsNonDoNothing"
                    TypeName="JpmmsClasses.BL.Lookups.MaintDecision"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections0" runat="server" SelectMethod="GetMainStreetIntersections"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="gvFeedbackDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="RECORD_ID" EnableModelValidation="True" ForeColor="#333333"
                    GridLines="None" DataSourceID="odsMaintFeedbackDetails">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                            Visible="False" />
                        <asp:BoundField DataField="HEADING" HeaderText="النوع" />
                        <asp:BoundField DataField="big_element" HeaderText="الوصف" ReadOnly="True" />
                        <asp:BoundField DataField="sample_element" ReadOnly="True" HeaderText="رقم العينة" />
                        <asp:TemplateField HeaderText="نوع الصيانة" SortExpression="MAINT_DEC_ID">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlMaintDecisionsEd" runat="server" AppendDataBoundItems="True"
                                    AutoPostBack="True" DataSourceID="odsAllMaintDecisions" DataTextField="RECOMMENDED_DECISION_AR"
                                    DataValueField="RECOMMENDED_DECISION_ID" SelectedValue='<%# Bind("MAINT_DEC_ID") %>'>
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RECOMMENDED_DECISION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UDI_BEFORE" HeaderText="حالة الرصف قبل الصيانة" SortExpression="UDI_BEFORE"
                            ReadOnly="True" />
                        <asp:BoundField DataField="UDI_AFTER" HeaderText="حالة الرصف بعد الصيانة" ReadOnly="True"
                            SortExpression="UDI_AFTER" />
                        <asp:TemplateField HeaderText="تاريخ الصيانة">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="rdtpMaintDate" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("maint_date") %>'>
                                </telerik:RadDatePicker>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("maint_date", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsMaintFeedbackDetails" runat="server" DeleteMethod="DeleteFeedbackLocation"
                    SelectMethod="GetAllFeedbackLocations" TypeName="JpmmsClasses.BL.MaintenanceFeedback"
                    UpdateMethod="UpdateFeedbackLocation" OnDeleted="odsMaintFeedbackDetails_Deleted"
                    OnUpdated="odsMaintFeedbackDetails_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvFeedbacks" Name="feedbackID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        <asp:Parameter Name="MAINT_DEC_ID" Type="Int32" />
                        <asp:Parameter Name="MAINT_DATE" Type="DateTime" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
