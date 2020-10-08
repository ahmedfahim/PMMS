<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="BrowserUpgrade.aspx.cs"
    Inherits="BrowserUpgrade" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Controls/HeaderNoMenu.ascx" TagName="HeaderNoMenu" TagPrefix="uc2" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>الرجاء تحديث المتصفح</title>
    <link href="./Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        div.img
        {
            margin: 2px;
            border: 1px solid #0000ff;
            height: auto;
            width: auto;
            float: left;
            text-align: center;
        }
        div.img img
        {
            display: inline;
            margin: 3px;
            border: 1px solid #ffffff;
        }
        div.img a:hover img
        {
            border: 1px solid #0000ff;
        }
        div.desc
        {
            text-align: center;
            font-weight: normal;
            width: 120px;
            margin: 2px;
        }
        a
        {
            color: Violet;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc2:HeaderNoMenu ID="HeaderNoMenu1" runat="server" />
        <h2 style="text-align: center">
            الرجاء تحديث المتصفح، إصدارة متصفحك قديمة وقد لايعمل عليها هذا البرنامج جيدا!</h2>
        <ul>
            <li>يرجى التحديث من هذا <a href="http://www.microsoft.com/windows/internet-explorer/worldwide-sites.aspx">
                الرابط لآخر إصدارة من Microsoft Internet Explorer</a>.</li>
            <li>كما يمكنك استعمال أياً من المتصفحات <a href="http://www.mozilla.org/en-US/firefox/fx/#desktop">
                FireFox</a> أو <a href="http://www.apple.com/safari/download/">Safari</a> أو <a href="http://www.google.com/chrome">
                    Google Chrome</a>.</li>
        </ul>
        <br />
        <uc3:Footer ID="Footer1" runat="server" />
    </div>
    </form>
</body>
</html>
