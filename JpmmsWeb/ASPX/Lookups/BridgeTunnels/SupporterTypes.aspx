<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="SupporterTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_SupporterTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="SUPPORTER_TYPE_ID" DataSourceID="sdsSupporterTypes">
        <Columns>
            <asp:BoundField DataField="SUPPORTER_TYPE_ID" HeaderText="SUPPORTER_TYPE_ID" 
                ReadOnly="True" SortExpression="SUPPORTER_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="SUPPORTER_TYPE" HeaderText="SUPPORTER_TYPE" 
                SortExpression="SUPPORTER_TYPE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsSupporterTypes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;SUPPORTER_TYPE_ID&quot;, &quot;SUPPORTER_TYPE&quot; FROM &quot;BRIDGE_SUPPORTER_TYPES&quot; ORDER BY &quot;SUPPORTER_TYPE_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>

