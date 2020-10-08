<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReportsQCUpdated.aspx.cs" Inherits="ASPX_Archive_ReportsQCUpdated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="style2">
        إدخال التقرير الشهري مناطق فرعية</h2>
    <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource2"
        DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear" AppendDataBoundItems="True"
        AutoPostBack="True">
        <asp:ListItem Selected="True" Value="-1">اختر الشهر</asp:ListItem>
        <asp:ListItem Value="0">الكل</asp:ListItem>
    </asp:DropDownList>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="3">المسح الثالث</asp:ListItem>
        <asp:ListItem Value="4">المسح الحالي</asp:ListItem>
    </asp:RadioButtonList>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="ObjectDataSource1"
        EnableModelValidation="True" AllowSorting="True" AutoGenerateColumns="False"
        OnRowUpdating="GridView1_RowUpdating" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ROWNUM" HeaderText="مـ" ReadOnly="True" SortExpression="ROWNUM" />
            <asp:TemplateField HeaderText="رقم المنطقة" SortExpression="REGION_NO">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("REGION_NO") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Label" runat="server" Text='<%# Bind("REGION_NO") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SURVEYOR_TOTALSTREETS" HeaderText="الشوارع" SortExpression="SURVEYOR_TOTALSTREETS"
                ReadOnly="true" />
            <asp:BoundField DataField="region_area" HeaderText="مساحة النظام" ReadOnly="True"
                SortExpression="region_area" />
            <asp:BoundField DataField="SURVEYOR_AREA" HeaderText="مساحة المساح" SortExpression="SURVEYOR_AREA" />
            <asp:TemplateField HeaderText="المساح" SortExpression="REGION_SURVEYOR">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("REGION_SURVEYOR") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("REGION_SURVEYOR") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="مدخل البيانات" SortExpression="REGION_DATAENTRY">
                <EditItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("REGION_DATAENTRY") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("REGION_DATAENTRY") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="سنة المسح" SortExpression="REPORTSYEAR">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("REPORTSYEAR") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="TextBox3" runat="server" Text='<%# Eval("REPORTSYEAR") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="رقم المسح" SortExpression="SURVEY_NO">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="TextBox4" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="شهر التقرير" SortExpression="MonthYear">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2"
                        DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear" Enabled="False"
                        SelectedValue='<%# Bind("MonthYear") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2"
                        DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear" SelectedValue='<%# Bind("MonthYear") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IS_REVIEWREPORT" HeaderText="التقرير" ReadOnly="True"
                SortExpression="IS_REVIEWREPORT" />
            <asp:CommandField ShowEditButton="True" CancelText="إلغاء" EditText="تعديل" UpdateText="حفظ"
                SelectText="اختيار" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectReportsQC"
        TypeName="JpmmsClasses.BL.Lookups.SystemUsers" UpdateMethod="UpdateReportQc">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="MonthYear" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="RadioButtonList1" Name="SURVEY_NO" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="SURVEYOR_AREA" Type="String" />
            <asp:Parameter Name="MonthYear" Type="String" />
            <asp:Parameter Name="REGION_NO" Type="String" />
            <asp:Parameter Name="SURVEY_NO" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetReportMonthsRegions"
        TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>
</asp:Content>
