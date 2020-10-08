<%@ Page Title="بيانات جسور التقاطع" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Bridges.aspx.cs" Inherits="ASPX_Intersections_Bridges" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        .style8
        {
            font-size: small;
            font-weight: bold;
        }
        .style9
        {
            width: 40%;
        }
        .style10
        {
            font-size: medium;
        }
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        .style5
        {
            font-weight: bold;
            direction: rtl;
        }
        .style11
        {
            width: 30%;
        }
        .style12
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
                    <b>بيانات جسور التقاطع</b></h2>
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
                <asp:FormView ID="FormView1" runat="server" DataSourceID="odsIntersectionInfo">
                    <ItemTemplate>
                        <strong>رقم التقاطع: </strong>
                        <asp:Label ID="lblIntersectNo" runat="server" Text='<%# Bind("INTER_NO") %>'></asp:Label>
                        &nbsp; &nbsp; <strong>
                            <br />
                            شارع رئيسي:&nbsp; </strong>
                        <asp:Label ID="lblIntersectStreet1" runat="server" Text='<%# Bind("INTEREC_STREET1") %>'></asp:Label>
                        &nbsp; &nbsp; &nbsp; <strong>مع شارع: </strong>
                        <asp:Label ID="lblIntersectStreet2" runat="server" Text='<%# Bind("INTEREC_STREET2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsBridgeType" runat="server" SelectMethod="GetBridgeTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSurfaceTypes" runat="server" SelectMethod="GetBridgeSurfaceTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsBarrierTypes" runat="server" SelectMethod="GetBridgeBarrierTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSupporterTypes" runat="server" SelectMethod="GetBridgeSupporterTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsCammerTypes" runat="server" SelectMethod="GetBridgeCammerTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsIntersectionInfo" runat="server" SelectMethod="GetIntersection"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="intersectionID" QueryStringField="InterID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>رقم الجسر</b>
            </td>
            <td>
                <asp:TextBox ID="txtBridgeNo" Width="120px" runat="server" MaxLength="3"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>اسم الجسر </b>
            </td>
            <td>
                <asp:TextBox ID="txtBridgeName" runat="server" Width="218px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>&nbsp; </b>
            </td>
            <td>
                <asp:CheckBox ID="chkPedestrian" runat="server" Text="جسر مشاة؟" CssClass="style12" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>&nbsp; </b>
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkLight" runat="server" AutoPostBack="True" OnCheckedChanged="ChkLight_CheckedChanged"
                                Text="الإنارة" CssClass="style12" />
                        </td>
                        <td>
                            <b>الموقع</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLightLocation" Width="120px" runat="server" Enabled="False" CssClass="style10"></asp:TextBox>
                        </td>
                        <td>
                            <b>العدد</b>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtLightCount" runat="server" Culture="ar-QA" DataType="System.Int16"
                                Enabled="False" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            <b>مقاول التنفيذ </b>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlContractors" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_NO">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlContractors"
                                ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td colspan="2">
                            <b>ارتفاع الجسر (م)</b>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtBridgeHeight" runat="server" Culture="ar-QA"
                                DataType="System.Double" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rntxtBridgeHeight"
                                ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            نوع الجسر
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlBridgeType" runat="server" AppendDataBoundItems="True" DataSourceID="odsBridgeType"
                                DataTextField="BRIDGE_TYPE" DataValueField="BRIDGE_TYPE_ID">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlBridgeType"
                                ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td class="style12" colspan="2">
                            عدد الفتحات
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtOpeningsCount" runat="server" Culture="ar-QA"
                                DataType="System.Int16" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            نوع الكمرات
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlCammerTypes" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsCammerTypes" DataTextField="CAMMER_TYPE" DataValueField="CAMMER_TYPE_ID">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlCammerTypes"
                                ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td class="style12" colspan="2">
                            ارتفاع الكمرات
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtCammerHeight" runat="server" Culture="ar-QA"
                                DataType="System.Double" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            نوع المساند
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlSupporterTypes" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsSupporterTypes" DataTextField="SUPPORTER_TYPE" DataValueField="SUPPORTER_TYPE_ID">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlSupporterTypes"
                                ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td class="style12" colspan="2">
                            عدد المساند
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtSupportersCount" runat="server" Culture="ar-QA"
                                DataType="System.Int16" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            نوع الحواجز
                            <br />
                            الجانببة
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlBarrierTypes" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsBarrierTypes" DataTextField="BARRIER_TYPES" DataValueField="BARRIER_TYPE_ID">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlBarrierTypes"
                                ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td class="style12" colspan="2">
                            الطبقة السطحية
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSurfaceTypes" runat="server" AppendDataBoundItems="True"
                                DataSourceID="odsSurfaceTypes" DataTextField="SURFACE_TYPE" DataValueField="SURFACE_TYPE_ID">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlSurfaceTypes"
                                ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            <b>عدد المسارات </b>
                        </td>
                        <td colspan="3">
                            <telerik:RadNumericTextBox ID="rntxtLanesCount" runat="server" Culture="ar-QA" DataType="System.Int16"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rntxtLanesCount"
                                ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">
                            <b>عرض المسار الواحد</b>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtLaneWidth" runat="server" Culture="ar-QA" DataType="System.Double"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rntxtLaneWidth"
                                ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                            <b>عرض بلاطة
                                <br />
                                الجسر </b>
                        </td>
                        <td colspan="3">
                            <telerik:RadNumericTextBox ID="rntxtTileWidth" runat="server" Culture="ar-QA" DataType="System.Double"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rntxtTileWidth"
                                ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12" colspan="2">
                            <b>عرض الطريق
                                <br />
                                عند المدخل </b>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtEntryWidth" runat="server" Culture="ar-QA" DataType="System.Double"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rntxtEntryWidth"
                                ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>ارتفاع الرصيف</b>
                        </td>
                        <td colspan="3">
                            <telerik:RadNumericTextBox ID="rntxtCurbHeight" runat="server" Culture="ar-QA" DataType="System.Double"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td colspan="2">
                            <b>عرض الرصيف</b>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntxtCurbWidth" runat="server" Culture="ar-QA" DataType="System.Double"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>&nbsp; </b>
                        </td>
                        <td colspan="3">
                            <asp:CheckBox ID="chkCurved" runat="server" Text="الجسر منحني؟" />
                        </td>
                        <td colspan="2">
                            <b>&nbsp; </b>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPerpend" runat="server" Text="الجسر متعامد مع الطريق؟" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>الإحداثيات </b>
                        </td>
                        <td colspan="6">
                            <table align="center" class="style15">
                                <tr>
                                    <td class="style2" style="direction: ltr">
                                        X
                                    </td>
                                    <td class="style2">
                                        Y
                                    </td>
                                    <td class="style2">
                                        Z
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtX" runat="server" Culture="ar-QA" DataType="System.Double"
                                            MinValue="0" Width="125px">
                                            <NumberFormat DecimalDigits="20" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtY" runat="server" Culture="ar-QA" DataType="System.Double"
                                            MinValue="0" Width="125px">
                                            <NumberFormat DecimalDigits="20" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="rntxtZ" runat="server" Culture="ar-QA" DataType="System.Double"
                                            MinValue="0" Width="125px">
                                            <NumberFormat DecimalDigits="20" />
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>سنة التشييد</b>
                        </td>
                        <td colspan="2">
                            <telerik:RadNumericTextBox ID="rntxtBYear" runat="server" Culture="ar-QA" DataType="System.Int16"
                                MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rntxtBYear"
                                ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td colspan="2">
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
            <td>
                <b>الأرصفة والجزر </b>
            </td>
            <td>
                <table class="style9">
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkMidIsland" runat="server" Text="جزيرة وسطية" AutoPostBack="True"
                                CssClass="style8" OnCheckedChanged="ChkMidIsland_CheckedChanged" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkMidIslandGood" runat="server" AutoPostBack="True" Text="بحالة جيدة"
                                Enabled="False" />
                        </td>
                        <td>
                            عرض<telerik:RadNumericTextBox ID="rntxtMidIslandWidth" runat="server" Culture="ar-QA"
                                DataType="System.Double" Enabled="False" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkSideWalk" runat="server" Text="رصيف جانبي" AutoPostBack="True"
                                CssClass="style8" OnCheckedChanged="ChkSideWalk_CheckedChanged" />
                        </td>
                        <td style="margin-right: 40px">
                            <asp:CheckBox ID="chkSideCurbGood" runat="server" AutoPostBack="True" Text="بحالة جيدة"
                                Enabled="False" />
                        </td>
                        <td style="margin-right: 40px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkShoulders" runat="server" Text="أكتاف الطريق" AutoPostBack="True"
                                CssClass="style8" OnCheckedChanged="chkShoulders_CheckedChanged" />
                        </td>
                        <td style="margin-right: 40px">
                            <asp:CheckBox ID="chkShouldersGood" runat="server" AutoPostBack="True" Text="بحالة جيدة"
                                Enabled="False" />
                        </td>
                        <td style="margin-right: 40px">
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
            <td>
                <b>العلامات الأرضية </b>
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkElect_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkElect_MH_CheckedChanged"
                                Text="مناهل كهرباء" CssClass="style12" />
                        </td>
                        <td>
                            <b>العدد&nbsp; </b>
                            <telerik:RadNumericTextBox ID="rnTxtElect_MHCount" runat="server" Culture="ar-QA"
                                DataType="System.Int16" Enabled="False" MinValue="0" Width="125px">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkSTC_MH" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSTC_MH_CheckedChanged"
                                Text="مناهل هاتف" CssClass="style12" />
                        </td>
                        <td>
                            <b>العدد&nbsp; </b>
                            <telerik:RadNumericTextBox ID="rntxtSTC_MHCount" runat="server" Culture="ar-QA" DataType="System.Int16"
                                MinValue="0" Width="125px" Enabled="False">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkTrafficSigns" runat="server" AutoPostBack="True" Text="توجد دهانات أرضية وعلامات مرورية"
                                CssClass="style5" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkGuideSigns" runat="server" AutoPostBack="True" Text="توجد لوحات إرشادية"
                                CssClass="style5" />
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
                &nbsp;<asp:CheckBox ID="chkDrainExist" runat="server" AutoPostBack="True" Text="يوجد نظام لتصريف السيول"
                    CssClass="style5" />
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
            <td>
                <b>تفاصيل إضافية</b>
            </td>
            <td>
                <asp:TextBox ID="txtDetails" runat="server" Width="520px" Height="76px" TextMode="MultiLine"></asp:TextBox>
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
            <td>
                &nbsp;
            </td>
            <td>
                <table class="style11">
                    <tr>
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="حفظ"
                                CssClass="style10" />
                        </td>
                        <td>
                            <asp:Button ID="UpdateCancelButton" runat="server" OnClick="UpdateCancelButton_Click"
                                Text="إلغاء" CssClass="style10" />
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvBridges" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="odsBridges" ForeColor="#333333" GridLines="None"
                    EmptyDataText="لاتوجد بيانات للعرض" DataKeyNames="BRIDGE_ID" OnRowDeleting="gvBridges_RowDeleting">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BRIDGE_ID" HeaderText="BRIDGE_ID" SortExpression="BRIDGE_ID"
                            Visible="False" />
                        <asp:BoundField DataField="BRIDGE_NAME" HeaderText="اسم الجسر" SortExpression="BRIDGE_NAME" />
                        <asp:CheckBoxField HeaderText="جسر مشاة؟" DataField="PEDESTRIAN" />
                        <asp:HyperLinkField DataNavigateUrlFields="BRIDGE_ID" DataNavigateUrlFormatString="EditBridge.aspx?id={0}"
                            HeaderText="تعديل" Text="..." />
                        <asp:HyperLinkField DataNavigateUrlFields="BRIDGE_ID" DataNavigateUrlFormatString="~/aspx/operations/TunnelBridgesFiles.aspx?tunnelID=0&amp;bridgeID={0}"
                            HeaderText="ملفات التسليم الإنشائي" Target="_blank" Text="..." />
                        <asp:HyperLinkField DataNavigateUrlFields="BRIDGE_ID" HeaderText="التقييم" Text="..."
                            DataNavigateUrlFormatString="~/aspx/operations/TunnelBridgesEval.aspx?tunnelID=0&amp;bridgeID={0}"
                            Target="_blank" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsBridges" runat="server" SelectMethod="GetIntersectionBridges"
                    TypeName="JpmmsClasses.BL.Bridge" DeleteMethod="Delete">
                    <DeleteParameters>
                        <asp:Parameter Name="BRIDGE_ID" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="intersectID" QueryStringField="InterID" Type="Int32" />
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
    </table>
</asp:Content>
