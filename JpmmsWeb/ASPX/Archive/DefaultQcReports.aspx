<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultQcReports.aspx.cs" Inherits="ASPX_DefaultQcReports" %>

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
            <table align="center">
                <tr align="center">
                    <td colspan="2">
                        <h2>
                            مساحه المنطقة من المساح غير مطابقه لمساحه المنطقة من النظام</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource2"
                            DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear" AppendDataBoundItems="True"
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="-1">اختر الشهر</asp:ListItem>
                            <asp:ListItem Value="0">الكل</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                            OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="3">المسح الثالث</asp:ListItem>
                            <asp:ListItem Value="4">المسح الحالي</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="style3">
                        <asp:Panel ID="pnlSurveyor" runat="server">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="style3">
                        &nbsp;
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
                            AllowSorting="True" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ROWNUM" HeaderText="مسلسل" ReadOnly="True" SortExpression="ROWNUM" />
                                <asp:TemplateField HeaderText="رقم المنطقة" SortExpression="REGION_NO">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("REGION_NO") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="Label" runat="server" Text='<%# Bind("REGION_NO") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SURVEYOR_TOTALSTREETS" HeaderText="عدد الشوارع" SortExpression="SURVEYOR_TOTALSTREETS" />
                                <asp:BoundField DataField="SURVEYOR_AREA" HeaderText="مساحة المنطقة المساح" SortExpression="SURVEYOR_AREA" />
                                <asp:BoundField DataField="region_area" HeaderText="مساحة المنطقة النظام" SortExpression="region_area" />
                                <asp:BoundField DataField="STREETSADDED" HeaderText="الشوارع المضافة" SortExpression="STREETSADDED"
                                    Visible="False" />
                                <asp:BoundField DataField="STREETSDELETED" HeaderText="الشوارع المحذوفة" SortExpression="STREETSDELETED"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="المساح" SortExpression="REGION_SURVEYOR">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("REGION_SURVEYOR") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("REGION_SURVEYOR") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="مدخل البيانات" SortExpression="REGION_DATAENTRY">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("REGION_DATAENTRY") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("REGION_DATAENTRY") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <%--    <asp:TemplateField HeaderText="سنة المسح" SortExpression="REPORTSYEAR">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("REPORTSYEAR") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="TextBox3" runat="server" Text='<%# Bind("REPORTSYEAR") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="رقم المسح" SortExpression="SURVEY_NO">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="TextBox4" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="REPORTMONTH_TITLE" HeaderText="شهر التقرير" SortExpression="REPORTMONTH_TITLE" />
                                <asp:CheckBoxField DataField="IS_REVIEWREPORT" HeaderText="التقرير" ReadOnly="True"
                                    SortExpression="IS_REVIEWREPORT" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetReportMonthsRegions"
                            TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="SelectAREAReportsQC" TypeName="JpmmsClasses.BL.Lookups.SystemUsers" 
        UpdateMethod="UpdateReportQc">
         <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="MonthYear" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="RadioButtonList1" Name="SURVEY_NO" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="DONE_BY" Type="String" DefaultValue="37"/>
            <asp:Parameter Name="SURVEYOR_TOTALSTREETS" Type="String" />
            <asp:Parameter Name="SURVEYOR_AREA" Type="String" />
            <asp:Parameter Name="SURVEY_NO" Type="String" />
            <asp:Parameter Name="REPORTSMONTH" Type="String" />
            <asp:Parameter Name="REPORTSYEAR" Type="String" />
            <asp:Parameter Name="REGION_SURVEYOR" Type="String" />
            <asp:Parameter Name="REGION_DATAENTRY" Type="String" />
            <asp:Parameter Name="STREETSDELETED" Type="String" />
            <asp:Parameter Name="STREETSADDED" Type="String" />
            <asp:Parameter Name="REGION_NO" Type="String" />
            
        </UpdateParameters>
    </asp:ObjectDataSource>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
