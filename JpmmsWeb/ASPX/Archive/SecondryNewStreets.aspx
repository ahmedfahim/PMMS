<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SecondryNewStreets.aspx.cs" Inherits="ASPX_Archive_SecondryNewStreets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <h3 align="center">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </h3>
                <br />
                <asp:Button ID="BtnNEW" runat="server" OnClick="BtnNEW_Click" Text="نقل الشوارع الجديده "
                    Width="120px" />
                <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
                &nbsp;
                <asp:Button ID="BtnALLStreets" runat="server"  Text="تحديث البلدية والحي والحي الفرعي لكل الشوارع "
                    Width="263px" onclick="BtnALLStreets_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <Columns>
                        <asp:CommandField SelectText="اختر" ShowSelectButton="True" />
                        <asp:BoundField DataField="street_id" HeaderText="رقم الشارع الفريد" SortExpression="street_id" />
                        <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="رقم العينة" SortExpression="SECOND_ST_NO" />
                        <asp:BoundField DataField="SECOND_ARNAME" HeaderText="اسم الشارع" SortExpression="SECOND_ARNAME" />
                        <asp:BoundField DataField="SECOND_ST_WIDTH" HeaderText="عرض الشارع" SortExpression="SECOND_ST_WIDTH" />
                        <asp:BoundField DataField="SECOND_ST_LENGTH" HeaderText="طول الشارع" SortExpression="SECOND_ST_LENGTH" />
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
                        <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية" SortExpression="MUNIC_NAME" />
                        <asp:BoundField DataField="subdistrict" HeaderText="الحي" SortExpression="subdistrict" />
                        <asp:BoundField DataField="survey_no" HeaderText="رقم المسح" SortExpression="survey_no" />
                        <asp:BoundField DataField="survey_date" HeaderText="تاريخ المسح" SortExpression="survey_date" />
                        <asp:BoundField DataField="SURVEYORS_AREA" HeaderText="مساحة المساح" SortExpression="SURVEYORS_AREA" />
                        <asp:BoundField DataField="STREETS_AREA" HeaderText="مساحة النظام" SortExpression="STREETS_AREA" />
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
    </table>
</asp:Content>
