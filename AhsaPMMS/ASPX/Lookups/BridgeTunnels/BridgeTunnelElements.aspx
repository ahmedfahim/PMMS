<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="BridgeTunnelElements.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_BridgeTunnelElements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="B_ELEMENT_ID" DataSourceID="sdsElements">
        <Columns>
            <asp:BoundField DataField="B_ELEMENT_ID" HeaderText="B_ELEMENT_ID" 
                ReadOnly="True" SortExpression="B_ELEMENT_ID" Visible="False" />
            <asp:BoundField DataField="B_ELEMENT_NAME" HeaderText="B_ELEMENT_NAME" 
                SortExpression="B_ELEMENT_NAME" />
            <asp:BoundField DataField="FOR_BRIDGE" HeaderText="FOR_BRIDGE" 
                SortExpression="FOR_BRIDGE" Visible="False" />
            <asp:BoundField DataField="FOR_TUNNEL" HeaderText="FOR_TUNNEL" 
                SortExpression="FOR_TUNNEL" Visible="False" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsElements" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;B_ELEMENT_ID&quot;, &quot;B_ELEMENT_NAME&quot;, &quot;FOR_BRIDGE&quot;, &quot;FOR_TUNNEL&quot; FROM &quot;BRIDGE_ELEMENTS&quot; ORDER BY &quot;B_ELEMENT_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>

