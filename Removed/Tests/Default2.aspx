<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="ASPX_Tests_Default2" %>

<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            font: normal 9pt tahoma;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
        TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
    <cc2:ComboBox ID="ComboBox1" runat="server" DataSourceID="odsRegions" DataTextField="region_title"
        DataValueField="region_id" MaxLength="0" Style="display: inline;">
    </cc2:ComboBox>
    </form>
</body>
</html>
