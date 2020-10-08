<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="BridgeTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="BRIDGE_TYPE_ID" DataSourceID="sdBridgeTypes">
        <Columns>
            <asp:BoundField DataField="BRIDGE_TYPE_ID" HeaderText="BRIDGE_TYPE_ID" 
                ReadOnly="True" SortExpression="BRIDGE_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="BRIDGE_TYPE" HeaderText="BRIDGE_TYPE" 
                SortExpression="BRIDGE_TYPE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdBridgeTypes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;BRIDGE_TYPE_ID&quot;, &quot;BRIDGE_TYPE&quot; FROM &quot;BRIDGE_TYPES&quot; ORDER BY &quot;BRIDGE_TYPE&quot;">
    </asp:SqlDataSource>
</asp:Content>

