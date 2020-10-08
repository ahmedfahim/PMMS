<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="LandingInterSections.aspx.cs" Inherits="ASPX_Archive_LandingInterSections" %>

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
            top: 0px;
            right: 0px;
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
        .style1
        {
            width: 4px;
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
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DefaultQcReportsInterSect.aspx?id=0"
                            Target="_blank">
                            مراجعة مساحة التقارير الشهرية <span id="spanValidateAREA" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                        <br />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DefaultQcUdi.aspx?id=Intersect"
                            Target="_blank">
                            مراجعه التقاطعات الفرعية حالة الرصف <span id="spanQcUdi" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/DefaultQcMain.aspx?id=Intersect"
                            Target="_blank">
                            مراجعه التقاطعات الفرعية قرارات الصيانة <span id="spanQcMain" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink29" runat="server" CssClass="notification" 
                            NavigateUrl="~/aspx/Archive/DefaultQcAreaStreet.aspx?ID=Area" Target="_blank">
                            تقاطع متجاوز مساحة<span ID="spanIntersectionArea" 
                            runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink25" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/InsertIntersectionGis.aspx"
                            Target="_blank">
                            رسم التقاطعات <span id="spanInsertGis" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink23" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/InterSectionsMissing.aspx"
                            Target="_blank">
                            تقاطعات تحتاج استلام <span id="spanInterSectionsMissing" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="notification" NavigateUrl="~/aspx/Archive/IntersectionsReady.aspx?ID=0"
                            Target="_blank">
                            شوارع تحتاج مراجعه <span id="spanIntersectionsEditReady" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                        <br />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="notification" NavigateUrl="~/aspx/Archive/IntersectionsReady.aspx?ID=1"
                            Target="_blank">
                            شوارع جاهزة للادخال <span id="spanIntersectionsReady" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink22" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/IntersectionClearance.aspx"
                            Target="_blank">
                            شوارع تحتاج مستخلص <span id="spanInterSectionsClearance" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/InterSectionnotFinshed.aspx"
                            Target="_blank">
                            تقاطعات جاري العمل عليها <span id="spanInterSectionsNotFinshed" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink15" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/IntersectionReviewed.aspx"
                            Target="_blank">
                            تقاطعات المراجعة والتدقيق <span id="spanInterSectionsFinshed" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink16" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/InterSectionReportReview.aspx"
                            Target="_blank">
                            تقاطعات مراجعة حالة الرصف وقرارات الصيانة <span id="spanInterSectionsReportReview"
                                runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink21" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/defaultIntersect.aspx"
                            Target="_blank">استلام التقاطعات</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink18" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/InterSectionFinshed.aspx"
                            Target="_blank"> مدخلين البيانات</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink26" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/ReportsQCUpdatedInterSect.aspx" Target="_blank">إدخال التقرير الشهري</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink27" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/IntersectionSumery.aspx" Target="_blank">متابعة التقاطعات</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink28" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/InterSectionsMissing.aspx?ID=0" Target="_blank">تقاطعات تم استلام</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink24" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/InterSectionsDrawing.aspx" Target="_blank">موقف التقاطعات</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink30" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/DefaultInterSections.aspx" Target="_blank"> حالة التقاطعات</asp:HyperLink>
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
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
