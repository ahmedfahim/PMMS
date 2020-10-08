<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTestChart.aspx.cs" Inherits="ASPX_Tests_ViewTestChart" %>

<%--<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            font: normal 9pt tahoma;
            text-align: right;
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
    </div>
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
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </p>
    </form>
</body>
</html>
