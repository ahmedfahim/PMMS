<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ASPX_Tests_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
        TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
    <telerik:RadComboBox ID="RadComboBox1" runat="server" DataSourceID="odsRegions" DataTextField="region_title"
        DataValueField="region_id" Filter="Contains" AppendDataBoundItems="True" AutoPostBack="True">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="اختيار" Value="0" Selected="true" />
        </Items>
    </telerik:RadComboBox>
    <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
        TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
    <telerik:RadComboBox ID="RadComboBox2" runat="server"  Filter="Contains"
        DataSourceID="odsMainStreets" DataTextField="main_title"
        DataValueField="street_id"  AppendDataBoundItems="True" 
        AutoPostBack="True">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="اختيار" Value="0" Selected="true" />
        </Items>
    </telerik:RadComboBox>
    <br />
    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show" />
    <br />
    <asp:Label ID="lbl" runat="server"></asp:Label>
</asp:Content>
