<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReportsQC.aspx.cs" Inherits="ASPX_Archive_ReportsQC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" EnableModelValidation="True" AllowSorting="True"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
        BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="REGION_TITLE" HeaderText="رقم المنطقة" SortExpression="REGION_TITLE" />
            <asp:BoundField DataField="SURVEYOR_AREA" HeaderText="مساحة المنطقة" SortExpression="SURVEYOR_AREA" />
            <asp:BoundField DataField="SURVEYOR_TOTALSTREETS" HeaderText="عدد الشوارع" SortExpression="SURVEYOR_TOTALSTREETS" />
            <asp:BoundField DataField="STREETSADDED" HeaderText="الشوارع المضافة" SortExpression="STREETSADDED" />
            <asp:BoundField DataField="STREETSDELETED" HeaderText="الشوارع المحذوفة" SortExpression="STREETSDELETED" />
            <asp:BoundField DataField="SURVEYOR_NAME" HeaderText="اسم المساح" SortExpression="SURVEYOR_NAME" />
            <asp:BoundField DataField="USERNAME" HeaderText="اسم المدخل" SortExpression="USERNAME" />
            <asp:BoundField DataField="REPORTMONTH_TITLE" HeaderText="شهر التقرير " SortExpression="REPORTMONTH_TITLE" />
            <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" SortExpression="SURVEY_NO" />
            <asp:CheckBoxField DataField="IS_DATAENTRYFINSH" HeaderText="تم الإدخال" SortExpression="IS_DATAENTRYFINSH" />
            <asp:CheckBoxField DataField="IS_REVIEWDATAENTRY" HeaderText="مراجعه الإدخال" SortExpression="IS_REVIEWDATAENTRY" />
            <asp:CheckBoxField DataField="IS_REVIEWREPORT" HeaderText="طباعة التقرير" SortExpression="IS_REVIEWREPORT" />
            <%--  <asp:CheckBoxField DataField="IS_REVIEWQC" HeaderText="ضبط الجودة" SortExpression="IS_REVIEWQC" />
           <asp:BoundField DataField="REPORTSYEAR" HeaderText="السنة" SortExpression="REPORTSYEAR" />
            <asp:CheckBoxField DataField="IS_REVIEWGIS" HeaderText=" مراجعه الرسم" SortExpression="IS_REVIEWGIS" />
            --%>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
   <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetReportsQC"
        TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>--%>
</asp:Content>
