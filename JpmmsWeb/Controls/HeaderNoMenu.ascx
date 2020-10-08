<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderNoMenu.ascx.cs"
    Inherits="Controls_HeaderNoMenu" %>
<!--Header Table Start -->
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table align="center" cellpadding="0" dir="rtl" cellspacing="0" style="width: 982px;
    border-collapse: collapse; margin-bottom: 0px;">
    <!--Upper Banner (Upper Menu) Start-->
    <tr>
        <td class="TopBar">
            <div class="UpperMenu">
                <ul>
                    <li><a href="http://www.jeddah.gov.sa/index.php">أمانة محافظة جدة</a></li>
                </ul>
            </div>
        </td>
    </tr>
    <!--Upper Banner (Upper Menu) End-->
    <!--Main Banner Start-->
    <tr>
        <td valign="top" style="width: 100%; height: 128px; background: #0B78BD;">
            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 128px;">
                <tr>
                    <!--Right Cell (Amana Logo) Start-->
                    <td style="width: 130px; height: 128px;" rowspan="2">
                        <a href="http://www.jeddah.gov.sa/index.php">
                            <img src="../Images/AmanahLogo.png" runat="server" alt="أمانة محافظة جدة" title="أمانة محافظة جدة"
                                width="130" height="150" border="0" /></a>
                    </td>
                    <!--Right Cell (Amana Logo) End-->
                    <!--Middle Cell (Flash) Start-->
                    <td class="UpperBannerRepeat">
                        <br />
                    </td>
                    <!--Middle Cell (Flash) End-->
                    <!--Left Cell (TagLine) Start-->
                    <!--Left Cell (TagLine) Start-->
                    <td style="width: 150px; height: 128px;" rowspan="2">
                        <a href="http://www.jeddah.gov.sa/eServices/index.php">
                            <img src="~/Images/Header/eServices.jpg" runat="server" alt="الخدمات الإلكترونية"
                                title="الخدمات الإلكترونية" width="150" height="150" border="0" /></a>
                    </td>
                    <!--Left Cell (TagLine) End-->
                    <!--Left Cell (TagLine) End-->
                </tr>
                <!--Main Menu Row Start-->
                <%--    <tr>
                    <td class="UpperBannerMainMenu" align="center" valign="bottom">
                       
                    </td>
                </tr>--%>
                <!--Main Menu Row End-->
            </table>
        </td>
    </tr>
    <!--Main Banner End-->
    <!--Main Menu Content Row Start-->
    <tr>
        <td valign="top" style="width: 100%;" align="center">
            <%--  <div id="MainMenuTitleBG" style="margin: 0px; padding: 0px; width: 982px; height: 27px;
                background: url('../images/MainMenu/MenuContentHeader.jpg') no-repeat;">
            </div>--%>
        </td>
    </tr>
    <!--Main Menu Content Row End-->
</table>
<!--Header Table End -->
