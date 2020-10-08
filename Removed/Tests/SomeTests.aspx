<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="SomeTests.aspx.cs" Inherits="ASPX_Tests_SomeTests" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadComboBox ID="RadComboBox1" Runat="server" 
        AppendDataBoundItems="True" AutoPostBack="True">
    </telerik:RadComboBox>
    <br />
</asp:Content>

