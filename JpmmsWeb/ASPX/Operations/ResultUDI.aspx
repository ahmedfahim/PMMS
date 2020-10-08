<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultUDI.aspx.cs" Inherits="ASPX_Operations_ResultUDI" %>

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
        نتيجة حساب حالة الرصف </h2>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <hr />
    <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
