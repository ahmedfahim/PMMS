<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DeleteSecANDInterSec.aspx.cs" Inherits="ASPX_Archive_DeleteSecANDInterSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center">
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ASPX/Archive/DeleteSections.aspx"
                    Font-Size="Large">مقطع</asp:HyperLink>
                <br />
                <br />
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ASPX/Archive/DeleteInterSections.aspx"
                    Font-Size="Large">تقاطع</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
