<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="LandingRegions.aspx.cs" Inherits="ASPX_Archive_LandingRegions" %>

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
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="BtnUpdate" runat="server" Text="تحديث حالة المناطق الفرعية" ForeColor="Blue"
                            OnClick="BtnUpdate_Click" />
                        <br />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
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
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="notification" NavigateUrl="~/aspx/Archive/DefaultQcAreaStreet.aspx?ID=Width"
                            Target="_blank">
                            الشوارع الفرعية المتجاوزه في العرض <span id="spanRegionsWidth" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                        <br />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/RegionClosed.aspx?ID=False"
                            Target="_blank">
                            المناطق المغلقة وبها شوارع فرعية <span id="spanRegionsColsed" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DefaultQcSecoundStreets.aspx"
                            Target="_blank">
                            مراجعه الشوارع الفرعية عينات <span id="spanSecoundStreets" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink28" runat="server" CssClass="notification" 
                            NavigateUrl="~/ASPX/Archive/DublicateErorrStreets.aspx" Target="_blank">  شوارع جديدة غير مطابقة<span 
                            id="spanDublicateStreets" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="notification" NavigateUrl="~/aspx/Archive/DefaultQcAreaStreet.aspx?ID=Length"
                            Target="_blank">
                            الشوارع الفرعية المتجاوزه في الطول<span id="spanRegionsLength" runat="server" class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/RegionClosed.aspx?ID=True"
                            Target="_blank">
                            المناطق المفتوحة بدون شوارع فرعية <span id="spanRegionsOpend" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DefaultQcUdi.aspx?id=Regions"
                            Target="_blank">
                            مراجعه الشوارع الفرعية حالة الرصف <span id="spanQcUdi" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink19" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/default.aspx" Target="_blank">استلام كل المناطق الفرعية</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/RegionsNotes.aspx?ID=True"
                            Target="_blank">
                            المناطق المغلقـة ولايوجد بها ملاحظات <span id="spanRegionsClosedNote" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/RegionsNotes.aspx?ID=False"
                            Target="_blank">
                            المناطق المفتوحة وعليها ملاحظات <span id="spanRegionsOpenedNote" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" CssClass="Without" NavigateUrl="~/ASPX/Archive/DefaultQcMain.aspx?ID=Regions"
                            Target="_blank">
                            مراجعه الشوارع الفرعية قرارات الصيانة <span id="spanQcMain" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink22" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Reports/SurveyingFormsReport.aspx" Target="_blank">نماذج مسح المناطق الفرعية</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DataEntryNotFinshed.aspx"
                            Target="_blank">
                            مناطق جاري العمل عليها <span id="spanRegionsNotFinshed" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink15" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DataEntryReviewed.aspx"
                            Target="_blank">
                            مناطق المراجعة والتدقيق <span id="spanRegionsFinshed" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink16" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/ReportReview.aspx"
                            Target="_blank">
                            مناطق مراجعة حالة الرصف وقرارات الصيانة <span id="spanRegionsReportReview" runat="server"
                                class="badge"></span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/DefaultDataEntry.aspx" Target="_blank">تقرير إدخال بيانات المناطق</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink13" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/RegionsErorr.aspx"
                            Target="_blank">
                            مناطق مكررة تحتاج مراجعة <span id="spanRegionsError" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/DefaultQcReports.aspx?id=0"
                            Target="_blank">
                            مراجعة مساحة التقارير الشهرية <span id="spanValidateAREA" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink17" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/ReportsQC.aspx?id=0"
                            Target="_blank">  ضبط ومراجعة التقارير الشهرية<span id="spanValidateReports" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink20" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/ChangeSecoundST.aspx" Target="_blank">تعديل عينات المناطق الفرعية </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink25" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/SecondryNewStreets.aspx?id=0"
                            Target="_blank">  شوارع جديده تحتاج بيانات<span 
                            id="spanNewStreets" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink26" runat="server" CssClass="notification" 
                            NavigateUrl="~/ASPX/Archive/SecondryNewStreets.aspx?id=1" Target="_blank"> ضبط ومراجعة انتاجية المساحين<span 
                            id="spanNewStreetsQC" runat="server" class="badge">
                            </span>
                        </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink27" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Reports/SurveyorsProductionReport.aspx" Target="_blank">إنتاج المساحين مناطق فرعية</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink23" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/defaultTables.aspx" Target="_blank">جداول مسح المناطق الفرعية</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/DefaultUDIStreet.aspx" Target="_blank"> مساحة الشوارع الفرعية </asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink24" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/ReportsQCUpdated.aspx" Target="_blank">إدخال التقرير الشهري</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink18" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/DataEntryFinshed.aspx" Target="_blank">مناطق مدخلين البيانات</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink21" runat="server" CssClass="Without" 
                            NavigateUrl="~/ASPX/Archive/DefaultRegions.aspx" Target="_blank">المناطق القابلة للمسح</asp:HyperLink>
&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
