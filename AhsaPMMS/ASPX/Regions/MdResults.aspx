<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MdResults.aspx.cs" Inherits="ASPX_Regions_MdResults" %>

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
        نتيجة حساب قرارات الصيانة</h2>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <asp:GridView ID="gvSecondaryMaintDecisions" runat="server" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <%-- DataKeyNames="RECORD_ID" <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                Visible="False" />--%>
            <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
            <asp:BoundField DataField="ARNAME" HeaderText="الاسم" SortExpression="ARNAME" />
            <asp:BoundField DataField="SECOND_NO" HeaderText="رقم الشارع الفرعي" SortExpression="SECOND_NO" />
            <asp:BoundField DataField="survey_no" HeaderText="رقم المسح" />
            <asp:BoundField DataField="UDI_RATE" HeaderText="حالة الرصف" SortExpression="UDI_RATE" />
            <asp:BoundField DataField="UDI" DataFormatString="{0:N0}" HeaderText="UDI" SortExpression="UDI" />
            <asp:BoundField DataField="RECOMMENDED_DECISION" HeaderText="قرار الصيانة" SortExpression="RECOMMENDED_DECISION" />
            <asp:BoundField DataField="MAINT_AREA" DataFormatString="{0:N2}" HeaderText="مساحة الصيانة"
                SortExpression="MAINT_AREA" />
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
    </div>
    </form>
</body>
</html>
