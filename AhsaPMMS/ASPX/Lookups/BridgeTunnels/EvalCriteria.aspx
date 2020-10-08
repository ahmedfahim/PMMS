<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EvalCriteria.aspx.cs" Inherits="ASPX_Lookups_BridgeTunnels_EvalCriteria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CRITERIA_ID"
        DataSourceID="sdsEvalCriteria">
        <Columns>
            <asp:BoundField DataField="CRITERIA_ID" HeaderText="CRITERIA_ID" ReadOnly="True"
                SortExpression="CRITERIA_ID" Visible="False" />
            <asp:BoundField DataField="CRITERIA_NAME" HeaderText="CRITERIA_NAME" SortExpression="CRITERIA_NAME" />
            <asp:BoundField DataField="DETAILS" HeaderText="DETAILS" SortExpression="DETAILS" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsEvalCriteria" runat="server" ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;CRITERIA_ID&quot;, &quot;CRITERIA_NAME&quot;, &quot;DETAILS&quot; FROM &quot;BRIDGE_EVAL_CRITERIA&quot; ORDER BY &quot;CRITERIA_ID&quot;">
    </asp:SqlDataSource>
</asp:Content>
