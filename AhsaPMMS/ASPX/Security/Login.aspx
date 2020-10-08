<%@ Page Title="الدخول للنظام" Language="C#" MasterPageFile="~/MasterPage/Services.master"
    AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="ASPX_Security_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 13%;
        }
        .style2
        {
            height: 18px;
        }
        .style4
        {
            width: 17%;
        }
        .style5
        {
            width: 13%;
            height: 32px;
        }
        .style6
        {
            width: 17%;
            height: 32px;
        }
        .style8
        {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <marquee class="marquee" direction="RIGHT">
                                 أمانة محــــافــظـة جــــــدة تــــــــرحـــــب بــــــكـــم - مـشـروع تـطويـر نـظـام صـيـانة الـطـرق
              </marquee>
    <table width="100%">
        <tr>
            <td colspan="3" class="style8" align="center" bgcolor="#66CCFF">
                <asp:Label ID="Label1" runat="server" Text="أمـــانـة محافظـــــة جـــــده تـــرحـــــب بــــــكـــــم"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style8">
                <h2 style="text-align: center">
                    الدخول للنظام</h2>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:LinkButton ID="lnkReports" runat="server" OnClick="lnkReports_Click">استعراض تقارير النظام</asp:LinkButton>
            </td>
            <td class="style4">
                &nbsp;<asp:LinkButton ID="lnkData" runat="server" OnClick="lnkData_Click">الدخول لاستعراض البيانات</asp:LinkButton>
            </td>
            <td width="85%" align="center" rowspan="5" style="width: 42%">
                <img alt="" src="../../Images/pmms_intro.png" style="height: 200px; width: 52%" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                <b>
                    <asp:Label ID="lblUserName" runat="server" Text="اسم المستخدم:"></asp:Label>
                </b>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtUserName" runat="server" Width="150px" BorderColor="#FFFFCC"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <b>
                    <asp:Label ID="lblPassword" runat="server" Text="كلمة السر:"></asp:Label>
                </b>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="150px" BorderColor="#FFFFCC"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="style5">
                <b dir="ltr">
                    <asp:Button ID="btnLogin" runat="server" Height="25px" OnClick="btnLogin_Click" Text="دخول"
                        Width="58px" />
                </b>
            </td>
            <td align="center" class="style6">
                &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء"
                    UseSubmitBehavior="False" ValidationGroup="save" Height="25px" Width="58px" />
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                <asp:RadioButton ID="radArabic" runat="server" AutoPostBack="True" GroupName="lang"
                    Visible="false" OnCheckedChanged="radArabic_CheckedChanged" Text="لغة واجهة النظام: - اللغة العربية"
                    Checked="True" />
                <asp:RadioButton ID="radEnglish" runat="server" AutoPostBack="True" GroupName="lang"
                    Visible="false" OnCheckedChanged="radEnglish_CheckedChanged" Text="English" />
            </td>
            <td class="style4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
