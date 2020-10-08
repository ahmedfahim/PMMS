<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="BridgeTunnelDistTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_BridgeTunnelDistTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="DISTRESS_TYPE_ID" DataSourceID="sdsDistTypes">
        <Columns>
            <asp:BoundField DataField="DISTRESS_TYPE_ID" HeaderText="DISTRESS_TYPE_ID" 
                ReadOnly="True" SortExpression="DISTRESS_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="DISTRESS_TYPE" HeaderText="DISTRESS_TYPE" 
                SortExpression="DISTRESS_TYPE" />
            <asp:BoundField DataField="DISTRESS_TYPE_EN" HeaderText="DISTRESS_TYPE_EN" 
                SortExpression="DISTRESS_TYPE_EN" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsDistTypes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;DISTRESS_TYPE_ID&quot;, &quot;DISTRESS_TYPE&quot;, &quot;DISTRESS_TYPE_EN&quot; FROM &quot;BRIDGE_DISTRESS_TYPES&quot; ORDER BY &quot;DISTRESS_TYPE_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>

