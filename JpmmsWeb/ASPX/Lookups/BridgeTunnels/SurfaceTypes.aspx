<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="SurfaceTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_SurfaceTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="SURFACE_TYPE_ID" DataSourceID="sdsSurfaceTypes">
        <Columns>
            <asp:BoundField DataField="SURFACE_TYPE_ID" HeaderText="SURFACE_TYPE_ID" 
                ReadOnly="True" SortExpression="SURFACE_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="SURFACE_TYPE" HeaderText="SURFACE_TYPE" 
                SortExpression="SURFACE_TYPE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsSurfaceTypes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;SURFACE_TYPE_ID&quot;, &quot;SURFACE_TYPE&quot; FROM &quot;BRIDGE_SURFACE_TYPES&quot; ORDER BY &quot;SURFACE_TYPE_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>

