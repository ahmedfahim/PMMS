<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="TunnelTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_TunnelTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="TUNNEL_TYPE_ID" DataSourceID="sdsTunnelTypes">
        <Columns>
            <asp:BoundField DataField="TUNNEL_TYPE_ID" HeaderText="TUNNEL_TYPE_ID" 
                ReadOnly="True" SortExpression="TUNNEL_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="TUNNEL_TYPE" HeaderText="TUNNEL_TYPE" 
                SortExpression="TUNNEL_TYPE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsTunnelTypes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;TUNNEL_TYPE_ID&quot;, &quot;TUNNEL_TYPE&quot; FROM &quot;TUNNEL_TYPES&quot; ORDER BY &quot;TUNNEL_TYPE_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>

