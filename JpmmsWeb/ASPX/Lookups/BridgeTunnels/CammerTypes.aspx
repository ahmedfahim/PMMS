<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="CammerTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_CammerTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CAMMER_TYPE_ID" DataSourceID="sdsCammerTypes">
        <Columns>
            <asp:BoundField DataField="CAMMER_TYPE_ID" HeaderText="CAMMER_TYPE_ID" 
                ReadOnly="True" SortExpression="CAMMER_TYPE_ID" />
            <asp:BoundField DataField="CAMMER_TYPE" HeaderText="CAMMER_TYPE" 
                SortExpression="CAMMER_TYPE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsCammerTypes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;CAMMER_TYPE_ID&quot;, &quot;CAMMER_TYPE&quot; FROM &quot;BRIDGE_CAMMER_TYPES&quot; ORDER BY &quot;CAMMER_TYPE_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>

