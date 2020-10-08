<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="EquipmentFiveteenValid.aspx.cs" Inherits="ASPX_Archive_EquipmentFiveteenValid" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="center">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 >
                    تأكيد إضافة شارع جديد لدوره الإدخال
                </h2>
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
                            <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="BtnEND" runat="server" ForeColor="Red" OnClick="BtnEND_Click" Text="اضافه الشارع" />
                            <asp:Button ID="BtnYes" runat="server" OnClick="BtnYes_Click" Text="نعم" Visible="False" />
                            <asp:Button ID="BtnNO" runat="server" OnClick="BtnNO_Click" Text="لا" Visible="False" />
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
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
