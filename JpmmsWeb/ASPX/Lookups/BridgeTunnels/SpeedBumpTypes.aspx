<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SpeedBumpTypes.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_SpeedBumpTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SPEED_BUMP_TYPE_ID"
        DataSourceID="sdsSpeedBumpTypes">
        <Columns>
            <asp:BoundField DataField="SPEED_BUMP_TYPE_ID" HeaderText="SPEED_BUMP_TYPE_ID" ReadOnly="True"
                SortExpression="SPEED_BUMP_TYPE_ID" Visible="False" />
            <asp:BoundField DataField="SPEED_BUMP_TYPE" HeaderText="SPEED_BUMP_TYPE" SortExpression="SPEED_BUMP_TYPE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsSpeedBumpTypes" runat="server" ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;SPEED_BUMP_TYPE_ID&quot;, &quot;SPEED_BUMP_TYPE&quot; FROM &quot;SPEED_BUMP_TYPES&quot; ORDER BY &quot;SPEED_BUMP_TYPE&quot;">
    </asp:SqlDataSource>
</asp:Content>
