<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ASPX_Tests_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            font: normal 9pt tahoma;
            text-align: right;
        }
        input, textarea, select
        {
            font: normal 11pt tahoma;
            height: 21px;
            direction: rtl;
        }
    </style>
</head>
<body style="direction: rtl">
    <form id="form1" runat="server">
    <div style="direction: rtl">
        <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetMainStreetsHavingUdiCalculated"
            TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
        <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
            AutoPostBack="True" DataSourceID="odsMainStreets" DataTextField="MAIN_NAME" DataValueField="ID3"
            OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
        </asp:DropDownList>
    </div>
</body>
</html>
</form>
<p style="direction: rtl">
    &nbsp;</p>
