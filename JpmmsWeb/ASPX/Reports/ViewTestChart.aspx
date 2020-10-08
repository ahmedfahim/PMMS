<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTestChart.aspx.cs" Inherits="ASPX_Tests_ViewTestChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            font: normal 9pt tahoma;
            text-align: right;
        }
        .style1
        {
            width: 118px;
        }
    </style>
</head>
<body>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
    </body>
    </html>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%">
            <tr>
                <td align="center">
                    <img alt="" src="../../Images/pmms_header.png" style="width: 1002px; height: 103px" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:FormView ID="frvSectionInfo" runat="server" DataSourceID="odsMainStInfo" Width="45%">
                        <EditItemTemplate>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td class="style1">
                                        <b>الشارع الرئيسي</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="MAIN_ST_TITLELabel" runat="server" Text='<%# Bind("main_name") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="odsMainStInfo" runat="server" SelectMethod="GetMainStreetByID"
                        TypeName="JpmmsClasses.BL.MainStreet">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Chart ID="chkMainStUDI" runat="server" Height="403px" Width="721px" Palette="SeaGreen">
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
                    <p>
                        <asp:Chart ID="chkMainstBars" runat="server" Height="403px" Width="721px">
                            <Titles>
                                <asp:Title Name="JPMMS UDI Chart">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series ChartType="Column" Name="Series1" IsValueShownAsLabel="true" Legend="Legend1">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY IntervalType="Number">
                                    </AxisY>
                                    <AxisX>
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
