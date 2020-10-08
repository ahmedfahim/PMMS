<%@ Page Title="تغيير كلمة السر" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ASPX_Security_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" align="left">
        <tr>
            <td>
                <br />
                <table border="0" align="right" id="TABLE2" cellspacing="5" style="width: 59%">
                    <tr>
                        <td colspan="2" class="style1">
                            <h2>
                                <b>تغيير كلمة السر</b></h2>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                            </asp:SiteMapPath>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="style1">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 205px; text-align: right;" align="right">
                            <b>اسم المستخدم</b>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 205px; text-align: right;" align="right">
                            <b style="text-align: right">كلمة السر القديمة</b>
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="207px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 205px; text-align: right;" align="right">
                            <b>كلمة السر الجديدة</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnewPassword" runat="server" TextMode="Password" Width="207px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 205px; text-align: right;" align="right">
                            <b>تأكيد كلمة السر</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" Width="207px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="text-align: right">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 28px">
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                Text="حفظ" ValidationGroup="insert" OnClick="ImageButton2_Click" />
                            &nbsp;
                            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="إلغاء" OnClick="ImageButton1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
