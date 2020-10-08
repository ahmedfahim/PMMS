<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ChangeLanguage.aspx.cs" Inherits="ASPX_Home_ChangeLanguage" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h3 class="style2">
                    <b>تغيير لغة النظام</b></h3>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="radArabic" runat="server" AutoPostBack="True" GroupName="lang"
                    OnCheckedChanged="radArabic_CheckedChanged" Text="اللغة العربية" />
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
                <asp:RadioButton ID="radEnglish" runat="server" AutoPostBack="True" GroupName="lang"
                    OnCheckedChanged="radEnglish_CheckedChanged" Text="English" />
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
