<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SideBarrierTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_SideBarrierTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BARRIER_TYPE_ID"
        DataSourceID="sdsBarrierTypes">
        <Columns>
            <asp:BoundField DataField="BARRIER_TYPE_ID" HeaderText="BARRIER_TYPE_ID" ReadOnly="True"
                SortExpression="BARRIER_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="BARRIER_TYPES" HeaderText="BARRIER_TYPES" SortExpression="BARRIER_TYPES" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsBarrierTypes" runat="server" ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;BARRIER_TYPE_ID&quot;, &quot;BARRIER_TYPES&quot; FROM &quot;BRIDGE_BARRIER_TYPES&quot; ORDER BY &quot;BARRIER_TYPE_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>
