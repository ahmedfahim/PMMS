<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="AllSuerveyEquipments.aspx.cs" Inherits="ASPX_Archive_AllSuerveyEquipments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" EnableModelValidation="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
        BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Main_NO" HeaderText="MAIN_NO" SortExpression="Main_NO" />
            <asp:BoundField DataField="ARNAME" HeaderText="ARNAME" SortExpression="ARNAME" />
            <asp:BoundField DataField="SURVEY_NO" HeaderText="SURVEY_NO" SortExpression="SURVEY_NO" />
            <asp:BoundField DataField="IS_CLOSED" HeaderText="IS_CLOSED" SortExpression="IS_CLOSED" />
            <asp:BoundField DataField="IS_IRI" HeaderText="IS_IRI" SortExpression="IS_IRI" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllSuervey"
        TypeName="JpmmsClasses.BL.MainStreet">
      <%--  <SelectParameters>
            <asp:Parameter DefaultValue="true" Name="IRI" Type="Boolean" />
        </SelectParameters>--%>
    </asp:ObjectDataSource>
</asp:Content>
