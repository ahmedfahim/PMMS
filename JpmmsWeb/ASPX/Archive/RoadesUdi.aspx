<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="RoadesUdi.aspx.cs" Inherits="ASPX_Archive_RoadesUdi" %>

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
        .bold
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <h2 class="style2">
                            تفاصيل الشوارع الرئيسية حالة الرصف 
                        </h2>
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
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td dir="rtl">
                                    <asp:RadioButtonList ID="RadioButtonListType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">محاور رئيسية</asp:ListItem>
                                        <asp:ListItem Value="0">شارع رئيسي</asp:ListItem>
                                         <asp:ListItem  Value="">الكل</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RadioButtonList ID="RadioButtonListSurvey" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="3">المسح السابق</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="4">المسح الحالى</asp:ListItem>
                                         <asp:ListItem  Value="">الكل</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="عرض" Width="50px" /><asp:Label
                                        ID="Label1" runat="server" ForeColor="Red"></asp:Label>
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
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:GridView ID="gvRegionSamplesIRI" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True"
                                        PageSize="15" AllowSorting="True" OnSorting="gvRegionSamplesIRI_Sorting">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                            <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                            <asp:BoundField DataField="CENTERLINE" HeaderText="طول الشارع" DataFormatString="{0:N2}"
                                                SortExpression="CENTERLINE" />
                                            <asp:BoundField DataField="AREA" HeaderText="مساحة الشارع" DataFormatString="{0:N2}"
                                                SortExpression="AREA" />
                                            <asp:BoundField DataField="LANES" HeaderText="عدد الحارات" SortExpression="LANES" />
                                            <asp:BoundField DataField="UDI_STREET" HeaderText="حالة الرصف" SortExpression="UDI_STREET" />
                                            <asp:BoundField DataField="LTYPE" HeaderText="نوع المسارات" SortExpression="LTYPE" />
                                            <asp:BoundField DataField="LTYPECOUN" HeaderText="عدد المسارات" SortExpression="LTYPECOUN" />
                                            <asp:BoundField DataField="SURVEY_DATE" HeaderText="تاريخ المسح" DataFormatString="{0:d}"
                                                SortExpression="SURVEY_DATE" />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" SortExpression="SURVEY_NO" />
                                            <%--<asp:BoundField DataField="IS_MAINSTREETS" HeaderText="نوع الطريق" SortExpression="IS_MAINSTREETS" />--%>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
