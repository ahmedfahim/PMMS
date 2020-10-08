<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultInterSections.aspx.cs" Inherits="ASPX_Archive_DefaultInterSections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
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
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    <asp:Label ID="Label1" runat="server" Text="تقاطعات الشوارع الرئيسية"></asp:Label>
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
                &nbsp;
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
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" CellPadding="3"
                                EnableModelValidation="True" GridLines="Vertical" BackColor="White" BorderColor="#999999"
                                BorderStyle="None" BorderWidth="1px" DataSourceID="ObjectDataSource1">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="اسم الشارع" SortExpression="Title" />
                                    <asp:BoundField DataField="INTER_NO" HeaderText="رقم التقاطع" SortExpression="INTER_NO" />
                                    <asp:BoundField DataField="INTEREC_STREET1" HeaderText="من" SortExpression="INTEREC_STREET1" />
                                    <asp:BoundField DataField="INTEREC_STREET2" HeaderText="إلي" SortExpression="INTEREC_STREET2" />
                                    <asp:BoundField DataField="INTER_DISTRESS" HeaderText="عيوب" ReadOnly="True" SortExpression="INTER_DISTRESS" />
                                    <asp:CheckBoxField DataField="Recived" HeaderText="استلام" SortExpression="Recived" />
                                    <asp:CheckBoxField DataField="NotFinshed" HeaderText="ادخال" SortExpression="Recived" />
                                    <asp:CheckBoxField DataField="GIS" HeaderText="رسم" SortExpression="Recived" />
                                    <asp:CheckBoxField DataField="Finshed" HeaderText="مراجعة" SortExpression="Recived" />
                                    <asp:CheckBoxField DataField="Reviwed" HeaderText="تقارير" SortExpression="Recived" />
                                    <asp:CheckBoxField DataField="Reports" HeaderText="جاهز" SortExpression="Recived" />
                                    <asp:CheckBoxField DataField="CLEARANCE" HeaderText="مستخلص" SortExpression="Recived" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="DetialsInterSections"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;
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
</asp:Content>
