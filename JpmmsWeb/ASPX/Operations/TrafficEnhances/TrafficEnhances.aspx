<%@ Page Title="التحسينات المرورية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="TrafficEnhances.aspx.cs" Inherits="ASPX_Operations_TrafficEnhances_TrafficEnhances" %>

<%@ Register Src="../../../ASCX/Hijri2Greg.ascx" TagName="Hijri2Greg" TagPrefix="uc2" %>
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
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h2 class="style2">
                    &nbsp;</h2>
            </td>
            <td>
                <h2>
                    <b>التحسينات المرورية</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>اسم المقترح</b>
            </td>
            <td width="70%">
                <asp:TextBox runat="server" ID="PROPOSE_TITLETextBox" />
            </td>
            <td width="5%">
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PROPOSE_TITLETextBox"
                    ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>التاريخ </b>
            </td>
            <td width="70%" style="direction: rtl">
                <uc2:Hijri2Greg ID="ucProposeDate" runat="server" />
            </td>
            <td width="5%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>البلدية الفرعية</b>
            </td>
            <td width="70%" style="direction: rtl">
                <asp:DropDownList ID="ddlMunic" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsSubMunicipality" DataTextField="munic_name" DataValueField="munic_name">
                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="5%">
                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlMunic"
                    ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>وفق خطاب وارد من </b>
            </td>
            <td width="70%" style="direction: rtl">
                <asp:DropDownList ID="ddlLetterFrom" runat="server">
                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                    <asp:ListItem>الإدارة العامة للمرور</asp:ListItem>
                    <asp:ListItem>إمارة المنطقة</asp:ListItem>
                    <asp:ListItem>عدد من المواطنين</asp:ListItem>
                    <asp:ListItem>جهة حكومية/مستشفى/مدرسة</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="5%">
                &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlLetterFrom"
                    ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>برقم </b>
            </td>
            <td width="70%">
                <asp:TextBox ID="LETTER_NOTextBox" runat="server" />
            </td>
            <td width="5%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>بتاريخ</b>
            </td>
            <td width="70%">
                <uc2:Hijri2Greg ID="ucLetterDate" runat="server" />
            </td>
            <td width="5%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>لجنة الاعتماد برئاسة</b>
            </td>
            <td width="70%">
                <asp:TextBox ID="COMMITTE_HEAD_NAMETextBox" runat="server" />
            </td>
            <td width="5%">
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="COMMITTE_HEAD_NAMETextBox"
                    ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="25%">
                <b>ملاحظات</b>
            </td>
            <td width="70%">
                <asp:TextBox ID="NOTESTextBox" runat="server" TextMode="MultiLine" />
            </td>
            <td width="5%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="25%">
                &nbsp;
            </td>
            <td width="70%">
                <table class="style3">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="5%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="15%" colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
