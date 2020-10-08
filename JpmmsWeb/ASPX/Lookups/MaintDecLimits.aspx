<%@ Page Title="حدود التدخل لمعايير التقييم واتخاذ القرارات" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MaintDecLimits.aspx.cs" Inherits="ASPX_Lookups_MaintDecLimits" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-weight: bold;
        }
        .style3
        {
            text-align: center;
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
                <h2 class="style3">
                    <b>حدود التدخل لمعايير التقييم واتخاذ القرارات</b></h2>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:FormView ID="FormView1" runat="server" DataSourceID="odsLimits" DefaultMode="Edit"
                    OnItemUpdating="FormView1_ItemUpdating">
                    <EditItemTemplate>
                        <table class="style1">
                            <tr>
                                <td colspan="2">
                                    <b>المقاطع - حدود المعاملات لاتخاذ القرارات</b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة الرصف UDI (جيد)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="UDI_LIMIT_S" runat="server" Culture="ar-SA" DbValue='<%# Bind("UDI_LIMIT_S") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="UDI_LIMIT_S"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الوعورة IRI (جيد)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="IRI_LIMIT_S" runat="server" Culture="ar-SA" DbValue='<%# Bind("IRI_LIMIT_S") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="IRI_LIMIT_S"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الحمل الساقط FWD (متوسط)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="FWD_LIMIT_MED_S" runat="server" Culture="ar-SA" DbValue='<%# Bind("FWD_LIMIT_MED_S") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="1000" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="FWD_LIMIT_MED_S"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الحمل الساقط FWD (سيء)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="FWD_LIMIT_S" runat="server" Culture="ar-SA" DbValue='<%# Bind("FWD_LIMIT_S") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="1000" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="FWD_LIMIT_S"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <b>السماكة&nbsp;&nbsp; GPR (سم)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="GPR_LIMIT_S" runat="server" Culture="ar-SA" DbValue='<%# Bind("GPR_LIMIT_S") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="GPR_LIMIT_S"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>مقاومة الانزلاق SKID</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="SKID_LIMIT_S" runat="server" Culture="ar-SA" DbValue='<%# Bind("SKID_LIMIT_S") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="SKID_LIMIT_S"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>عينات المقاطع - حدود المعاملات لاتخاذ القرارات</b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة الرصف UDI (جيد)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="UDI_LIMIT_SM" runat="server" Culture="ar-SA" DbValue='<%# Bind("UDI_LIMIT_SM") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="UDI_LIMIT_SM"></asp:RequiredFieldValidator>
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
                                    <b>التقاطعات - حدود المعاملات لاتخاذ القرارات</b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة الرصف UDI (جيد)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="UDI_LIMIT_I" runat="server" Culture="ar-SA" DbValue='<%# Bind("UDI_LIMIT_I") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="UDI_LIMIT_I"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الوعورة IRI (جيد)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="IRI_LIMIT_I" runat="server" Culture="ar-SA" DbValue='<%# Bind("IRI_LIMIT_I") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="IRI_LIMIT_I"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <b>السماكة&nbsp;&nbsp; GPR (سم)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="GPR_LIMIT_ITextBox" runat="server" Culture="ar-SA"
                                        DbValue='<%# Bind("GPR_LIMIT_I") %>' DataType="System.Double" LabelCssClass=""
                                        MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="GPR_LIMIT_ITextBox"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>مقاومة الانزلاق SKID</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="SKID_LIMIT_ITextBox" runat="server" Culture="ar-SA"
                                        DbValue='<%# Bind("SKID_LIMIT_I") %>' DataType="System.Double" LabelCssClass=""
                                        MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="SKID_LIMIT_ITextBox"></asp:RequiredFieldValidator>
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
                                    <b>عينات التقاطعات - حدود المعاملات لاتخاذ القرارات</b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة الرصف UDI (جيد)</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="UDI_LIMIT_IS" runat="server" Culture="ar-SA" DbValue='<%# Bind("UDI_LIMIT_IS") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="UDI_LIMIT_IS"></asp:RequiredFieldValidator>
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
                                    <b>المناطق الفرعية - حدود المعاملات لاتخاذ القرارات</b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة الرصف UDI </b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="UDI_LIMIT_R" runat="server" Culture="ar-SA" DbValue='<%# Bind("UDI_LIMIT_R") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="UDI_LIMIT_R"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b></b>
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
                                    <b>الشوارع الفرعية - حدود المعاملات لاتخاذ القرارات</b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>حالة الرصف UDI </b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="UDI_LIMIT_SEC_ST" runat="server" Culture="ar-SA" DbValue='<%# Bind("UDI_LIMIT_SEC_ST") %>'
                                        DataType="System.Double" LabelCssClass="" MaxValue="100" MinValue="0">
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="الرجاء الإدخال"
                                        ControlToValidate="UDI_LIMIT_SEC_ST"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                        CssClass="style2" Text="حفظ" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="إلغاء" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                    </InsertItemTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="odsLimits" runat="server" SelectMethod="GetMaintDecisionsLimits"
        TypeName="JpmmsClasses.BL.Lookups.MaintDecision" UpdateMethod="UpdateMaintDecisionParameters"
        OnUpdated="odsLimits_Updated">
        <UpdateParameters>
            <asp:Parameter Name="IRI_LIMIT_S" Type="Double" />
            <asp:Parameter Name="FWD_LIMIT_S" Type="Double" />
            <asp:Parameter Name="FWD_LIMIT_MED_S" Type="Double" />
            <asp:Parameter Name="GPR_LIMIT_S" Type="Double" />
            <asp:Parameter Name="UDI_LIMIT_S" Type="Double" />
            <asp:Parameter Name="SKID_LIMIT_S" Type="Double" />
            <asp:Parameter Name="UDI_LIMIT_SM" Type="Double" />
            <asp:Parameter Name="IRI_LIMIT_I" Type="Double" />
            <asp:Parameter Name="GPR_LIMIT_I" Type="Double" />
            <asp:Parameter Name="UDI_LIMIT_I" Type="Double" />
            <asp:Parameter Name="SKID_LIMIT_I" Type="Double" />
            <asp:Parameter Name="UDI_LIMIT_R" Type="Double" />
            <asp:Parameter Name="UDI_LIMIT_SEC_ST" Type="Double" />
            <asp:Parameter Name="UDI_LIMIT_IS" Type="Double" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
