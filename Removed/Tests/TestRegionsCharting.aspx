<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestRegionsCharting.aspx.cs"
    Inherits="ASPX_Tests_TestRegionsCharting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        input, textarea, select
        {
            font: normal 11pt tahoma;
            height: 21px;
            direction: rtl;
        }
        table
        {
            font: normal 9pt tahoma;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <p style="direction: rtl">
        <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
            DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
            OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
            TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
    </p>
    </form>
</body>
</html>
