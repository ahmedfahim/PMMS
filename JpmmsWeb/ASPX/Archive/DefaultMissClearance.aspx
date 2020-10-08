<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultMissClearance.aspx.cs" Inherits="ASPX_Archive_DefaultMissClearance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Without
        {
            background-color: #555;
            color: Yellow;
            text-decoration: none;
            padding: 10px 21px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            width: 120px;
            top: -42px;
            right: 8px;
        }
        .Without:hover
        {
            background: none;
            color: black;
        }
        .notification
        {
            background-color: #555;
            color: white;
            text-decoration: none;
            padding: 10px 21px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            width: 120px;
            top: 0px;
            right: 0px;
        }
        
        .notification:hover
        {
            background: Aqua;
            color: Black;
        }
        
        .notification .badge
        {
            position: absolute;
            top: -10px;
            right: -10px;
            padding: 5px 10px;
            border-radius: 50%;
            background-color: red;
            color: white;
        }
        .notifyBall
        {
            display: block;
            -webkit-border-radius: 30px;
            -moz-border-radius: 30px;
            border-radius: 30px;
            background-color: #FFF;
            -webkit-box-shadow: 1px 1px 5px #808080;
            -moz-box-shadow: 1px 1px 5px #808080;
            box-shadow: 1px 1px 5px #808080;
            padding: 10px;
            width: 30px;
            height: 30px;
            margin: 0 auto;
            line-height: 30px;
            text-align: center;
            position: relative;
            -webkit-border-radius: 20px;
            -moz-border-radius: 20px;
            border-radius: 20px;
            border: 2px solid #FFF;
            width: 5px;
            height: 4px;
            background-color: #226598;
            position: relative;
            top: -25px;
            right: 30px;
            font-size: 10px;
            line-height: 7px;
            font-family: 'Roboto' , sans-serif;
            font-weight: 400;
            color: #FFF;
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..."  Style="padding: 10px;
                    position: fixed; top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label7" runat="server" Font-Italic="True" ForeColor="Blue" Text="تقاطعات سمكات الطبقات"></asp:Label>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/IntersectionClearance.aspx"
                                Target="_blank">
                                شوارع تحتاج مستخلص <span id="spanIntersectionGPR" runat="server" class="badge"></span>
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
            </table>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label6" runat="server" Font-Italic="True" ForeColor="Blue" Text="تقاطعات العيوب"></asp:Label>
                            <asp:HyperLink ID="HyperLink22" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/IntersectionClearance.aspx"
                                Target="_blank">
                                شوارع تحتاج مستخلص <span id="spanInterSectionsClearance" runat="server" class="badge">
                                </span>
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
            </table>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label5" runat="server" Font-Italic="True" ForeColor="#FF3300" Text="معدة العيوب و الوعورة"></asp:Label>
                            &nbsp;
                            <asp:HyperLink ID="HyperLink58" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=IRIDDF"
                                Target="_blank">
                                <span id="spanIRIDDFNoReady" runat="server" class="badge"></span>شوارع تحتاج مستخلص
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
            </table>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label1" runat="server" Font-Italic="True" ForeColor="#FF3300" Text="معدة الحمل الساقط"></asp:Label>
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=FWD"
                                Target="_blank">
                                شوارع تحتاج مستخلص <span id="spanFWDNoReady" runat="server" class="badge"></span>
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
            </table>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label2" runat="server" Font-Italic="True" ForeColor="#FF3300" Text="معدة مقاومة الإنزلاق"></asp:Label>
                            <asp:HyperLink ID="HyperLink71" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=SKID"
                                Target="_blank">
                                شوارع تحتاج مستخلص <span id="spanSKIDNoReady" runat="server" class="badge"></span>
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
            </table>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label3" runat="server" Font-Italic="True" ForeColor="#FF3300" Text="معدة سماكات الطبقات "></asp:Label>
                            <asp:HyperLink ID="HyperLink72" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=GPR"
                                Target="_blank">
                                شوارع تحتاج مستخلص <span id="spanGPRNoReady" runat="server" class="badge"></span>
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
            </table>
            <table width="60%">
                <tr>
                    <td align="left">
                        <h2>
                            <asp:Label ID="Label4" runat="server" Font-Italic="True" ForeColor="#FF3300" Text="أصول الطرق  الرئيسية "></asp:Label>
                            &nbsp;
                            <asp:HyperLink ID="HyperLink10" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/NotCompleted.aspx?ID=ASSETES"
                                Target="_blank">
                                شوارع تحتاج مستخلص <span id="spanASSETESNoReady" runat="server" class="badge"></span>
                            </asp:HyperLink>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
