<%@ Page Title="أوامر العمل" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MaintenanceOrders.aspx.cs" Inherits="ASPX_Operations_MaintenanceOrders" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/AddContractorMini.ascx" TagName="AddContractorMini"
    TagPrefix="uc1" %>
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
            width: 40%;
        }
        .style4
        {
            text-align: right;
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
                <h2>
                    <strong>أوامر العمل</strong></h2>
            </td>
            <td>
                &nbsp;
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
                            رقم العقد
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
                            اسم العقد
                        </td>
                        <td style="margin-right: 40px">
                            <asp:TextBox ID="CONTRACT_NAMETextBox" runat="server" />
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CONTRACT_NAMETextBox"
                                ErrorMessage="الرجاء إدخال اسم العقد" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            المقاول
                        </td>
                        <td style="margin-right: 40px">
                            <asp:DropDownList ID="ddlContractors" Width="100px" runat="server" DataSourceID="odsContractors"
                                DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_ID" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:LinkButton ID="btnAddContractor" runat="server" OnClick="btnAddContractor_Click">إضافة مقاول</asp:LinkButton>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlContractors"
                                ErrorMessage="الرجاء اختيار المقاول" Operator="NotEqual" ValidationGroup="insert"
                                ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            تاريخ العقد
                        </td>
                        <td style="margin-right: 40px">
                            <telerik:RadDatePicker ID="raddtpBegin" runat="server" Culture="ar-QA">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="raddtpBegin"
                                ErrorMessage="الرجاء إدخال تاريخ العقد" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            تاريخ بدء التنفيذ
                        </td>
                        <td style="margin-right: 40px">
                            <telerik:RadDatePicker ID="raddtpWorkBegin" runat="server" Culture="ar-QA">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="raddtpWorkBegin"
                                ErrorMessage="الرجاء إدخال تاريخ بدء التنفيذ" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            تاريخ الانتهاء
                        </td>
                        <td style="margin-right: 40px">
                            <telerik:RadDatePicker ID="raddtpEnd" runat="server" Culture="ar-QA">
                            </telerik:RadDatePicker>
                        </td>
                        <td style="margin-right: 40px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                ControlToValidate="raddtpEnd" ErrorMessage="الرجاء إدخال تاريخ الانتهاء" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ControlToCompare="raddtpWorkBegin"
                                ControlToValidate="raddtpEnd" ErrorMessage="تاريخ الانتهاء لايمكن ان يكون قبل تاريخ بدء التنفيذ"
                                Type="Date" ValidationGroup="insert" Operator="GreaterThan"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            حالة العقد
                        </td>
                        <td style="margin-right: 40px" class="style4">
                            <br />
                            <asp:DropDownList ID="ddlWorkStatus" runat="server">
                                <asp:ListItem Selected="True" Value="1">جاري العمل</asp:ListItem>
                                <asp:ListItem Value="2">متوقف</asp:ListItem>
                                <asp:ListItem Value="3">ملغي</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td style="margin-right: 40px">
                            &nbsp;
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
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections0" runat="server" SelectMethod="GetMainStreetIntersections"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMaintainOrders" runat="server" DeleteMethod="Delete"
                    SelectMethod="GetAll" TypeName="JpmmsClasses.BL.MaintenanceOrders" UpdateMethod="Update"
                    OnDeleted="odsMaintainOrders_Deleted" OnInserted="odsMaintainOrders_Inserted"
                    OnUpdated="odsMaintainOrders_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="MAINTAIN_ORDER_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CONTRACT_NO" Type="String" />
                        <asp:Parameter Name="CONTRACT_NAME" Type="String" />
                        <asp:Parameter Name="CONTRACTOR_ID" Type="Int32" />
                        <asp:Parameter Name="CONTRACT_DATE" Type="DateTime" />
                        <asp:Parameter Name="CONTRACT_BEGIN" Type="DateTime" />
                        <asp:Parameter Name="CONTRACT_END" Type="DateTime" />
                        <asp:Parameter Name="MAINTAIN_ORDER_ID" Type="Int32" />
                        <asp:Parameter Name="WORK_STATUS" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
            </td>
            <td>
                <uc1:AddContractorMini ID="AddContractorMini1" runat="server" OnOnContractorAdded="OnOnContractorAdded"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvMaintainOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="MAINTAIN_ORDER_ID" DataSourceID="odsMaintainOrders"
                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvMaintainOrders_SelectedIndexChanged"
                    OnRowDeleting="gvMaintainOrders_RowDeleting" OnRowUpdating="gvMaintainOrders_RowUpdating"
                    EnableModelValidation="True" OnRowDataBound="gvMaintainOrders_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                        <asp:BoundField DataField="MAINTAIN_ORDER_ID" HeaderText="MAINTAIN_ORDER_ID" ReadOnly="True"
                            SortExpression="MAINTAIN_ORDER_ID" Visible="False" />
                        <asp:TemplateField HeaderText="رقم العقد" SortExpression="CONTRACT_NO">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Width="150px" Text='<%# Bind("CONTRACT_NO") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="الرجاء إدخال رقم العقد" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("CONTRACT_NO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم العقد" SortExpression="CONTRACT_NAME">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Width="150px" Text='<%# Bind("CONTRACT_NAME") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                    ErrorMessage="الرجاء إدخال اسم العقد" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("CONTRACT_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المقاول">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" AppendDataBoundItems="True"
                                    SelectedValue='<%# Bind("CONTRACTOR_ID") %>' DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME"
                                    DataValueField="CONTRACTOR_ID">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownList2"
                                    ErrorMessage="الرجاء اختيار المقاول" Operator="NotEqual" ValidationGroup="edit"
                                    ValueToCompare="0"></asp:CompareValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ العقد" SortExpression="CONTRACT_DATE">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker4" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("CONTRACT_DATE") %>'>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadDatePicker4"
                                    ErrorMessage="الرجاء إدخال تاريخ العقد" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CONTRACT_DATE", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ بدء التنفيذ" SortExpression="CONTRACT_BEGIN">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker5" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("CONTRACT_BEGIN") %>'>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadDatePicker5"
                                    ErrorMessage="الرجاء إدخال تاريخ بدء التنفيذ" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("CONTRACT_BEGIN", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ الانتهاء" SortExpression="CONTRACT_END">
                            <EditItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker6" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("CONTRACT_END") %>'>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadDatePicker6"
                                    ErrorMessage="الرجاء إدخال تاريخ الانتهاء" ValidationGroup="edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CONTRACT_END", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حالة التنفيذ">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlWorkStatusEd" runat="server" SelectedValue='<%# Bind("WORK_STATUS") %>'>
                                    <asp:ListItem Value="1">جاري العمل</asp:ListItem>
                                    <asp:ListItem Value="2">متوقف</asp:ListItem>
                                    <asp:ListItem Value="3">ملغي</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ValidationGroup="edit" ShowEditButton="True"
                            UpdateText="حفظ" />
                        <asp:CommandField SelectText="تفاصيل" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%--  <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <td>
                </td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlDetails" runat="server" Visible="False">
                    <table class="style1">
                        <tr>
                            <td colspan="2">
                                <asp:FormView ID="FormView2" runat="server" DataKeyNames="RECORD_ID" DataSourceID="odsMaintainOrdersDetails"
                                    DefaultMode="Insert" OnItemInserting="FormView2_ItemInserting">
                                    <EditItemTemplate>
                                        RECORD_ID:
                                        <asp:Label ID="RECORD_IDLabel1" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                                        <br />
                                        TRAFF_ENHANCE_ID:
                                        <asp:TextBox ID="TRAFF_ENHANCE_IDTextBox" runat="server" Text='<%# Bind("TRAFF_ENHANCE_ID") %>' />
                                        <br />
                                        DETAILS:
                                        <asp:TextBox ID="DETAILSTextBox" runat="server" Text='<%# Bind("DETAILS") %>' />
                                        <br />
                                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" />
                                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" />
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    تفاصيل أمر الصيانة
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="DETAILSTextBox" runat="server" MaxLength="1500" Text='<%# Bind("DETAILS") %>'
                                                        Width="235px" TextMode="MultiLine" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DETAILSTextBox"
                                                        ErrorMessage="الرجاء إدخال بيان التفاصيل" ValidationGroup="details"></asp:RequiredFieldValidator>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                                        Text="حفظ" ValidationGroup="details" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                        Text="إلغاء" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        RECORD_ID:
                                        <asp:Label ID="RECORD_IDLabel" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                                        <br />
                                        TRAFF_ENHANCE_ID:
                                        <asp:Label ID="TRAFF_ENHANCE_IDLabel" runat="server" Text='<%# Bind("TRAFF_ENHANCE_ID") %>' />
                                        <br />
                                        DETAILS:
                                        <asp:Label ID="DETAILSLabel" runat="server" Text='<%# Bind("DETAILS") %>' />
                                        <br />
                                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" />
                                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                                            Text="New" />
                                    </ItemTemplate>
                                </asp:FormView>
                                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetAllDistrictsHavingRegions"
                                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="odsMaintainOrdersDetails" runat="server" DeleteMethod="DeleteDetail"
                                    InsertMethod="InsertDetail" SelectMethod="GetAllDetails" TypeName="JpmmsClasses.BL.MaintenanceOrders"
                                    UpdateMethod="UpdateDetail" OnDeleted="odsMaintainOrdersDetails_Deleted" OnInserted="odsMaintainOrdersDetails_Inserted"
                                    OnUpdated="odsMaintainOrdersDetails_Updated">
                                    <DeleteParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:ControlParameter ControlID="gvMaintainOrders" Name="MAINTAIN_ORDER_ID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                        <asp:Parameter Name="DETAILS" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvMaintainOrders" Name="MAINTAIN_ORDER_ID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:ControlParameter ControlID="gvMaintainOrders" Name="MAINTAIN_ORDER_ID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                        <asp:Parameter Name="DETAILS" Type="String" />
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td rowspan="3" valign="top">
                                <asp:Panel ID="pnlLocations" Visible="false" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td width="30%">
                                                &nbsp;شارع
                                            </td>
                                            <td width="70%">
                                                <telerik:RadComboBox AutoselectFirstItem="True" ID="ddlMainStreets" runat="server"
                                                    AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="odsMainStreets"
                                                    Filter="Contains" Width="200px" Font-Size="Medium" DataTextField="MAIN_NAME"
                                                    DataValueField="STREET_ID" OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged"
                                                    Visible="False">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-right: 80px">
                                                <asp:RadioButton ID="radSection" runat="server" AutoPostBack="True" Checked="True"
                                                    GroupName="type" Text="مقطع" OnCheckedChanged="radSection_CheckedChanged" />
                                                &nbsp;
                                            </td>
                                            <td rowspan="2">
                                                <telerik:RadComboBox AutoselectFirstItem="true" ID="ddlMainStreetSection" Filter="Contains"
                                                    Width="200px" Font-Size="Medium" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                    DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                                    Visible="False">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                                <telerik:RadComboBox AutoselectFirstItem="true" ID="ddlMainStreetIntersection" Filter="Contains"
                                                    Width="200px" Font-Size="Medium" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                    DataSourceID="odsMainStreetIntersections0" DataTextField="intersection_title"
                                                    DataValueField="INTERSECTION_ID" Visible="False">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-right: 80px">
                                                <asp:RadioButton ID="radIntersect" runat="server" AutoPostBack="True" GroupName="type"
                                                    Text="تقاطع" OnCheckedChanged="radIntersect_CheckedChanged" />&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-right: 80px">
                                                <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" GroupName="type"
                                                    OnCheckedChanged="radRegion_CheckedChanged" Text="منطقة فرعية" />
                                            </td>
                                            <td>
                                                <telerik:RadComboBox AutoselectFirstItem="true" ID="ddlRegions" runat="server" Filter="Contains"
                                                    Width="200px" Font-Size="Medium" AppendDataBoundItems="True" AutoPostBack="True"
                                                    DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                                    OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged" Visible="False">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                                <br />
                                                <telerik:RadComboBox AutoselectFirstItem="True" ID="ddlRegionSecondaryStreets" Filter="Contains"
                                                    Width="200px" Font-Size="Medium" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                    DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" DataValueField="STREET_ID">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-right: 80px">
                                                <asp:RadioButton ID="radDistricts" runat="server" AutoPostBack="True" GroupName="type"
                                                    OnCheckedChanged="radDistricts_CheckedChanged" Text="حي فرعي" />
                                            </td>
                                            <td>
                                                <telerik:RadComboBox AutoselectFirstItem="true" ID="ddlRegionNames" runat="server"
                                                    Filter="Contains" Width="200px" Font-Size="Medium" AppendDataBoundItems="True"
                                                    AutoPostBack="True" DataSourceID="odsDistricts" DataTextField="dist_name" DataValueField="dist_name">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-right: 80px">
                                                <asp:RadioButton ID="radMunics" runat="server" AutoPostBack="True" GroupName="type"
                                                    OnCheckedChanged="radMunics_CheckedChanged" Text="بلدية فرعية" />
                                            </td>
                                            <td align="right">
                                                <telerik:RadComboBox AutoselectFirstItem="true" ID="ddlMunic" runat="server" AppendDataBoundItems="True"
                                                    AutoPostBack="True" DataSourceID="odsSubMunicipality" DataTextField="munic_name"
                                                    Filter="Contains" Width="200px" Font-Size="Medium" DataValueField="munic_name">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="margin-right: 80px">
                                                <table class="style3">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblAddFeedback" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnAddLocation" runat="server" OnClick="btnAddLocation_Click" Text="إضافة" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnCancelLocation" runat="server" OnClick="btnCancelLocation_Click"
                                                                Text="إلغاء" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-right: 80px" colspan="2">
                                                &nbsp; &nbsp;
                                                <asp:GridView ID="gvLocations" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    DataSourceID="odsMaintainOrdersLocations" DataKeyNames="RECORD_ID" ForeColor="#333333"
                                                    GridLines="None" AllowPaging="True" OnRowDeleting="gvLocations_RowDeleting">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" SortExpression="RECORD_ID"
                                                            Visible="False" />
                                                        <asp:BoundField DataField="HEADING" HeaderText="النوع" SortExpression="HEADING" />
                                                        <asp:BoundField DataField="NUM" HeaderText="الرقم" SortExpression="NUM" />
                                                        <asp:BoundField DataField="TITLE" HeaderText="المكان" SortExpression="TITLE" />
                                                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
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
                                                <asp:ObjectDataSource ID="odsMaintainOrdersLocations" runat="server" DeleteMethod="DeleteMaintenanceOrdersDetailLocations"
                                                    OnDeleted="odsMaintainOrdersLocations_Deleted" SelectMethod="GetMaintenanceOrdersDetailLocations"
                                                    TypeName="JpmmsClasses.BL.MaintenanceOrders">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                                    </DeleteParameters>
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="gvMaintainOrdersDetails" Name="maintenanceOrderDetailID"
                                                            PropertyName="SelectedValue" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvMaintainOrdersDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="RECORD_ID" DataSourceID="odsMaintainOrdersDetails"
                                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvMaintainOrdersDetails_SelectedIndexChanged"
                                    OnRowDeleting="gvMaintainOrdersDetails_RowDeleting" OnRowUpdating="gvMaintainOrdersDetails_RowUpdating">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                                            Visible="False" />
                                        <asp:TemplateField HeaderText="تفاصيل أمر الصيانة" SortExpression="DETAILS">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DETAILS") %>' TextMode="MultiLine"
                                                    Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1"
                                                    ErrorMessage="الرجاء إدخال بيان التفاصيل" ValidationGroup="detailsed"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DETAILS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ValidationGroup="detailsed"
                                            ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:CommandField SelectText="المواقع" ShowSelectButton="True" />
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
