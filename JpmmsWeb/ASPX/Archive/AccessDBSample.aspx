<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="AccessDBSample.aspx.cs" Inherits="ASPX_Archive_AccessDBSample" %>

<%@ Register Assembly="UtilitiesLibrary" Namespace="UtilitiesLibrary.Controls" TagPrefix="cc1" %>
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
            text-align: right;
        }
        .bold
        {
            text-align: right;
        }
        .style4
        {
            height: 18px;
        }
    </style>
    <script type="text/javascript">
        var hash = {
            '.mdb': 1
        };

        function check_extension(filename, BtnUpload) {
            var re = /\..+$/;
            var ext = filename.match(re);
            var submitEl = document.getElementById('<%= BtnUpload.ClientID %>');
            if (hash[ext]) {
                submitEl.disabled = false;
                return true;
            } else {
                alert("الملف المدخل يجب ان يكون مايكروسوفت أكسس");
                submitEl.disabled = true;

                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUpload" />
        </Triggers>
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <h2 class="style2">
                            معدة ROMDAS</h2>
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
                        <table align="center" class="style3">
                            <tr>
                                <td>
                                    <b>ملفات مرفقة سابقا </b>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>ادخل ملف المعدة </b>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:FileUpload ID="FileUpload1" runat="server" size="20" onchange="check_extension(this.value,'BtnUpload');" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc1:OneClickButton ID="BtnUpload" runat="server" Text="ارفق" disabled="disabled"
                                        OnClick="BtnUpload_Click" ReplaceTitleTo="يرجى الإنتظار" />
                                    <asp:Label ID="lblUploadStatus" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc1:OneClickButton ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="نقل البيانات"
                                        Enabled="false" ReplaceTitleTo="يرجى الإنتظار" />
                                    <cc1:OneClickButton ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="حذف البيانات"
                                        Enabled="false" ReplaceTitleTo="يرجى الإنتظار" />
                                        <%--<cc1:OneClickButton ID="BtnValidate" runat="server" OnClick="BtnValidate_Click" Text="تدقيق البيانات"
                                        Enabled="false" ReplaceTitleTo="يرجى الإنتظار" />--%>
                                    <asp:Label ID="LblTransfare" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblFeedbackPosition" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:Label ID="lblFeedbackStatus" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
                                        EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    </asp:GridView>
                                    <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999"
                                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" EnableModelValidation="True"
                                        ForeColor="Black">
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="style4">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
