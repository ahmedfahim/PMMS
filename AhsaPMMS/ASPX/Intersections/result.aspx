﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="ASPX_Intersections_result" %>

<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            font: normal 9pt tahoma;
            text-align: right;
        }
        #form1
        {
            direction: rtl;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Header ID="Header1" runat="server" />
    </div>
    <h2 style="text-align: center">
        نتيجة حساب حالة الرصف</h2>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <asp:GridView ID="gvIntersectUDI" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None" OnRowDataBound="gvIntersectUDI_RowDataBound">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" SortExpression="RECORD_ID"
                Visible="False" />
            <asp:BoundField DataField="inter_no" HeaderText="الرقم" SortExpression="inter_no" />
            <asp:BoundField DataField="INTERSECT_TITLE" HeaderText="وصف التقاطع" SortExpression="INTERSECT_TITLE" />
            <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" SortExpression="SURVEY_NO" />
            <asp:BoundField DataField="INTERSECTION_AREA" HeaderText="المساحة" SortExpression="INTERSECTION_AREA"
                DataFormatString="{0:N2}" />
            <asp:BoundField DataField="UDI_VALUE" HeaderText="قيمة UDI" DataFormatString="{0:N0}"
                SortExpression="UDI_VALUE" />
            <asp:TemplateField HeaderText="حالة الرصف" SortExpression="UDI_RATE">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UDI_RATE") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRateUDI" runat="server" Text='<%# Bind("UDI_RATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <hr />
    <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
