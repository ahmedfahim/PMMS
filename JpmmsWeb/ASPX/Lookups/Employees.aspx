<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Employees.aspx.cs" Inherits="ASPX_Lookups_Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="EMPLOYEE_ID" DataSourceID="sdsEmployees"
        DefaultMode="Insert">
        <EditItemTemplate>
            EMPLOYEE_ID:
            <asp:Label ID="EMPLOYEE_IDLabel1" runat="server" Text='<%# Eval("EMPLOYEE_ID") %>' />
            <br />
            EMP_NAME:
            <asp:TextBox ID="EMP_NAMETextBox" runat="server" Text='<%# Bind("EMP_NAME") %>' />
            <br />
            EMP_JOB:
            <asp:TextBox ID="EMP_JOBTextBox" runat="server" Text='<%# Bind("EMP_JOB") %>' />
            <br />
            EMP_PHONE:
            <asp:TextBox ID="EMP_PHONETextBox" runat="server" Text='<%# Bind("EMP_PHONE") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            EMPLOYEE_ID:
            <asp:TextBox ID="EMPLOYEE_IDTextBox" runat="server" Text='<%# Bind("EMPLOYEE_ID") %>' />
            <br />
            EMP_NAME:
            <asp:TextBox ID="EMP_NAMETextBox" runat="server" Text='<%# Bind("EMP_NAME") %>' />
            <br />
            EMP_JOB:
            <asp:TextBox ID="EMP_JOBTextBox" runat="server" Text='<%# Bind("EMP_JOB") %>' />
            <br />
            EMP_PHONE:
            <asp:TextBox ID="EMP_PHONETextBox" runat="server" Text='<%# Bind("EMP_PHONE") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            EMPLOYEE_ID:
            <asp:Label ID="EMPLOYEE_IDLabel" runat="server" Text='<%# Eval("EMPLOYEE_ID") %>' />
            <br />
            EMP_NAME:
            <asp:Label ID="EMP_NAMELabel" runat="server" Text='<%# Bind("EMP_NAME") %>' />
            <br />
            EMP_JOB:
            <asp:Label ID="EMP_JOBLabel" runat="server" Text='<%# Bind("EMP_JOB") %>' />
            <br />
            EMP_PHONE:
            <asp:Label ID="EMP_PHONELabel" runat="server" Text='<%# Bind("EMP_PHONE") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New" />
        </ItemTemplate>
    </asp:FormView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID"
        DataSourceID="sdsEmployees">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="EMPLOYEE_ID" ReadOnly="True"
                SortExpression="EMPLOYEE_ID" Visible="False" />
            <asp:BoundField DataField="EMP_NAME" HeaderText="EMP_NAME" SortExpression="EMP_NAME" />
            <asp:BoundField DataField="EMP_JOB" HeaderText="EMP_JOB" SortExpression="EMP_JOB" />
            <asp:BoundField DataField="EMP_PHONE" HeaderText="EMP_PHONE" SortExpression="EMP_PHONE" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>"
        DeleteCommand="DELETE FROM &quot;EMPLOYEES&quot; WHERE &quot;EMPLOYEE_ID&quot; = ?"
        InsertCommand="INSERT INTO &quot;EMPLOYEES&quot; (&quot;EMPLOYEE_ID&quot;, &quot;EMP_NAME&quot;, &quot;EMP_JOB&quot;, &quot;EMP_PHONE&quot;) VALUES (?, ?, ?, ?)"
        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;EMPLOYEE_ID&quot;, &quot;EMP_NAME&quot;, &quot;EMP_JOB&quot;, &quot;EMP_PHONE&quot; FROM &quot;EMPLOYEES&quot; ORDER BY &quot;EMP_NAME&quot;"
        UpdateCommand="UPDATE &quot;EMPLOYEES&quot; SET &quot;EMP_NAME&quot; = ?, &quot;EMP_JOB&quot; = ?, &quot;EMP_PHONE&quot; = ? WHERE &quot;EMPLOYEE_ID&quot; = ?">
        <DeleteParameters>
            <asp:Parameter Name="EMPLOYEE_ID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EMPLOYEE_ID" Type="Decimal" />
            <asp:Parameter Name="EMP_NAME" Type="String" />
            <asp:Parameter Name="EMP_JOB" Type="String" />
            <asp:Parameter Name="EMP_PHONE" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="EMP_NAME" Type="String" />
            <asp:Parameter Name="EMP_JOB" Type="String" />
            <asp:Parameter Name="EMP_PHONE" Type="String" />
            <asp:Parameter Name="EMPLOYEE_ID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
