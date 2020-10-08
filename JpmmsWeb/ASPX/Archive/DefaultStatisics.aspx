<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="DefaultStatisics.aspx.cs" Inherits="ASPX_Archive_DefaultStatisics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
        EnableModelValidation="True" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="TOTAL" HeaderText="عدد المناطق" 
                SortExpression="TOTAL" />
            <asp:BoundField DataField="ARNAME" HeaderText="البلديات" 
                SortExpression="ARNAME" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetAllRegionsSUBMUNICIPALITY" TypeName="JpmmsClasses.BL.Region">
    </asp:ObjectDataSource>
</asp:Content>

