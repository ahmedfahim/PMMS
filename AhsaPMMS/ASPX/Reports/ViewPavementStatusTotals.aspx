<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPavementStatusTotals.aspx.cs"
    Inherits="ASPX_Reports_ViewPavementStatusTotals" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>إجمالي حالة رصف المساحات المسطحة بالمتر المربع في مدينة جدة</title>
    <style type="text/css">
        .style1
        {
            width: 60%;
        }
        .style2
        {
            width: 50%;
        }
        .style3
        {
            width: 70%;
        }
        .style4
        {
            color: #FFFFFF;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td style="text-align: center" colspan="2">
                <img alt="" src="../../Images/pmms_header.png" style="width: 1002px; height: 103px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; direction: rtl" colspan="2">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; direction: rtl" colspan="2">
                <h4>
                    إجمالي حالة رصف المساحات المسطحة بالمتر المربع في مدينة جدة</h4>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; direction: rtl" colspan="2">
                <b>وقت وتاريخ استخراج التقرير </b>
                <asp:Label ID="lblDateTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                &nbsp;
                <table class="style2">
                    <tr>
                        <td colspan="3">
                            <b>الشوارع الرئيسية</b>
                        </td>
                        <td valign="top">
                            <b>الشوارع الفرعية</b>
                        </td>
                        <td valign="top">
                            <b>الإجمالي</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>مقاطع</b>
                        </td>
                        <td>
                            <b>تقاطعات</b>
                        </td>
                        <td>
                            <b>إجمالي</b>
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
                            <asp:Label ID="lblTotalSections" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalIntersects" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalMainSt" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRegionsTotal" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; direction: rtl" colspan="2">
                <h4>
                    حالة رصف المساحات المسطحة للشوارع الرئيسية (م2)</h4>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <table class="style3">
                    <tr>
                        <td colspan="4">
                            <b>حالة الرصف</b>
                        </td>
                        <td rowspan="2">
                            <b>الإجمالي</b>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#009933">
                            <b>ممتاز</b>
                        </td>
                        <td bgcolor="Blue" class="style4">
                            جيد
                        </td>
                        <td bgcolor="Yellow">
                            <b>مقبول</b>
                        </td>
                        <td bgcolor="Red">
                            <b>ضعيف</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMainStTotalExcellent" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMainStTotalGood" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMainStTotalFair" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMainStTotalPoor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMainStTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; direction: rtl" colspan="2">
                <h4>
                    حالة رصف المساحات المسطحة للشوارع الفرعية (م2)</h4>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <table class="style3">
                    <tr>
                        <td colspan="4">
                            <b>حالة الرصف</b>
                        </td>
                        <td rowspan="2">
                            <b>الإجمالي</b>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#009933">
                            <b>ممتاز</b>
                        </td>
                        <td bgcolor="Blue" class="style4">
                            جيد
                        </td>
                        <td bgcolor="Yellow">
                            <b>مقبول</b>
                        </td>
                        <td bgcolor="Red">
                            <b>ضعيف</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRegionsTotalExcellent" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRegionsTotalGood" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRegionsTotalFair" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRegionsTotalPoor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalRegions" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;
            </td>
            <td style="text-align: center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <b>نسبة حالة الرصف لإجمالي مساحات الشوارع الرئيسية</b>
            </td>
            <td style="text-align: center">
                <b>نسبة حالة الرصف لإجمالي مساحات الشوارع الفرعية</b>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Chart ID="chtMainStUDI" runat="server" Height="315px" Width="546px" Palette="SeaGreen">
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="JPMMS UDI Chart">
                        </asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series ChartType="Pie" Name="Series1" IsValueShownAsLabel="true" Legend="Legend1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                            <Area3DStyle Enable3D="True"></Area3DStyle>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <td style="text-align: center">
                <asp:Chart ID="chtRegionsUDI" runat="server" Height="315px" Width="546px" Palette="SeaGreen">
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="JPMMS UDI Chart">
                        </asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series ChartType="Pie" Name="Series1" IsValueShownAsLabel="true" Legend="Legend1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                            <Area3DStyle Enable3D="True"></Area3DStyle>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
