<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="LandingWorkOrder.aspx.cs" Inherits="ASPX_Archive_LandingWorkOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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
    <table>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnUpdate" runat="server" Text="تحديث حالة أوامر العمل" ForeColor="Blue"
                    OnClick="BtnUpdate_Click" />
                <br />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="notification" 
                    NavigateUrl="~/ASPX/Archive/UdiRegionsReviews.aspx?UDI=TRUE" Target="_blank">
                    حالة الشوارع الفرعية ممتاز / جيد<span id="spanRegionsExcellent" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
                <br />
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                    مقاطع الطرق الرئيسية ممتاز / جيد <span id="spanSectionsExcellent" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                    التقاطع الطرق الرئيسية ممتاز / جيد <span id="spanInterSectionsExcellent" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="notification" 
                    NavigateUrl="~/ASPX/Archive/UdiRegionsReviews.aspx?UDI=FALSE" Target="_blank">
                    حالة الشوارع الفرعية مقبول / ضعيف<span id="spanRegionsPoor" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                    مقاطع الطرق الرئيسية مقبول / ضعيف <span id="spanSectionsPoor" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                    التقاطع الطرق الرئيسية مقبول / ضعيف <span id="spanInterSectionsPoor" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink7" runat="server" CssClass="notification" 
                    NavigateUrl="~/ASPX/Archive/WorkorderQcUdi.aspx" Target="_blank">
                   حالة الشوارع الفرعية غير مكتملة<span id="spanRegionsWorkorderUdi" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink9" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                   حالة المقاطع الرئيسية غير مكتملة<span id="spanSectionWorkorderUdi" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink11" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                   حالة التقاطع الرئيسية غير مكتملة<span id="spanInterSectionWorkorderUdi" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink8" runat="server" CssClass="notification" 
                    NavigateUrl="~/ASPX/Archive/WorkorderQcMin.aspx" Target="_blank">
                   قرارات الشوارع الفرعية غير مكتملة<span id="spanRegionsWorkorderMin" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink10" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                   قرارات المقاطع الرئيسية غير مكتملة<span id="spanSectionWorkorderMin" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink12" runat="server" CssClass="notification" 
                    NavigateUrl="#" Target="_blank">
                   قرارات التقاطع الرئيسية غير مكتملة<span id="spanInterSectionWorkorderMin" runat="server" 
                    class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

