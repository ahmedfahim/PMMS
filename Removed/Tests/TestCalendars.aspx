<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCalendars.aspx.cs" Inherits="ASPX_Tests_TestCalendars" %>

<%@ Register Src="../../ASCX/Hijri2Greg.ascx" TagName="Hijri2Greg" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:Hijri2Greg ID="Hijri2Greg1" runat="server" />
    <asp:Button ID="btnShowDates" runat="server" onclick="btnShowDates_Click" 
        Text="Show Dates" />
        <br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" ></asp:TextBox>
    </form>
    <p style="direction: ltr">
        &nbsp;</p>
</body>
</html>
