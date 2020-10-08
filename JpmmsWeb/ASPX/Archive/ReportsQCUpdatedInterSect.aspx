<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReportsQCUpdatedInterSect.aspx.cs" Inherits="ASPX_Archive_ReportsQCUpdatedInterSect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="style2">
                إدخال التقرير الشهري التقاطعات الرئيسية</h2>
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
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ROWNUM" HeaderText="مـ" ReadOnly="True" SortExpression="ROWNUM" />
                    <asp:TemplateField HeaderText="رقم التقاطع" SortExpression="INTER_NO">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("INTER_NO") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="Label" runat="server" Text='<%# Bind("INTER_NO") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="INTERSECTION_area" HeaderText="مساحة النظام" ReadOnly="True"
                        SortExpression="INTERSECTION_area" />
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
                    <asp:BoundField DataField="REPORTSYEAR" HeaderText="سنة المسح" SortExpression="REPORTSYEAR"
                        ReadOnly="True" />
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
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#FFFBD6" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectReportsQCInterSect"
                TypeName="JpmmsClasses.BL.Lookups.SystemUsers" UpdateMethod="UpdateReportQcInterSect">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" Name="MonthYear" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="RadioButtonList1" Name="SURVEY_NO" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SURVEYOR_AREA" Type="String" />
                    <asp:Parameter Name="MonthYear" Type="String" />
                    <asp:Parameter Name="INTER_NO" Type="String" />
                    <asp:Parameter Name="SURVEY_NO" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetReportMonthsIntersect"
                TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
