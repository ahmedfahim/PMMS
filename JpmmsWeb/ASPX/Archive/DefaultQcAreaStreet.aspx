<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultQcAreaStreet.aspx.cs" Inherits="ASPX_Archive_DefaultQcAreaStreet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <h3 align="center">
                    الشوارع المتجاوزة في  
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <Columns>
                        <asp:CommandField SelectText="اختر" ShowSelectButton="True" />
                        <asp:BoundField DataField="NUMROW" HeaderText="مسلسل" SortExpression="NUMROW" />
                        <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية" SortExpression="MUNIC_NAME" />
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="رقم العينة" SortExpression="SECOND_ST_NO" />
                        <asp:BoundField DataField="SECOND_ARNAME" HeaderText="اسم الشارع" SortExpression="SECOND_ARNAME" />
                        <asp:BoundField DataField="SECOND_ST_WIDTH" HeaderText="عرض الشارع" SortExpression="SECOND_ST_WIDTH" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <h3 align="center">
                    &nbsp;</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField SelectText="اختر" ShowSelectButton="True" />
                        <asp:BoundField DataField="NUMROW" HeaderText="مسلسل" SortExpression="NUMROW" />
                        <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية" SortExpression="MUNIC_NAME" />
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="رقم العينة" SortExpression="SECOND_ST_NO" />
                        <asp:BoundField DataField="SECOND_ARNAME" HeaderText="اسم الشارع" SortExpression="SECOND_ARNAME" />
                        <asp:BoundField DataField="SECOND_ST_LENGTH" HeaderText="طول الشارع" SortExpression="SECOND_ST_LENGTH" />
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h3 align="center">
                    &nbsp;</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:CommandField SelectText="اختر" ShowSelectButton="True" />
                        <asp:BoundField DataField="NUMROW" HeaderText="مسلسل" SortExpression="NUMROW" />
                        <asp:BoundField DataField="INTER_NO" HeaderText="رقم التقاطع" SortExpression="INTER_NO" />
                        <asp:BoundField DataField="INTEREC_STREET1" HeaderText="من" SortExpression="INTEREC_STREET1" />
                        <asp:BoundField DataField="INTEREC_STREET2" HeaderText="إلى" SortExpression="INTEREC_STREET2" />
                        <asp:BoundField DataField="survey_no" HeaderText="رقم المسح" SortExpression="survey_no" />
                        <asp:BoundField DataField="survey_date" HeaderText="تاريخ المسح" SortExpression="survey_date" />
                        <asp:BoundField DataField="MAIN_NAME" HeaderText="اسم الشارع" SortExpression="MAIN_NAME" />
                        <asp:BoundField DataField="INTERSECTION_AREA" HeaderText="مساحة التقاطع" SortExpression="INTERSECTION_AREA" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
