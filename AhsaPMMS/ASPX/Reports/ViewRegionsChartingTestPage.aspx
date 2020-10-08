<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRegionsChartingTestPage.aspx.cs"
    Inherits="ASPX_Tests_ViewRegionsChartingTestPage" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <img alt="" src="../../Images/pmms_header.png" style="width: 1002px; height: 103px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FormView1" runat="server" DataSourceID="odsRegionInfo" Width="80%">
                    <EditItemTemplate>
                        REGION_NO:
                        <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                        <br />
                        ARNAME:
                        <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                        <br />
                        MUNIC_NAME:
                        <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                        <br />
                        REGION_NAME:
                        <asp:TextBox ID="REGION_NAMETextBox" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        REGION_NO:
                        <asp:TextBox ID="REGION_NOTextBox0" runat="server" Text='<%# Bind("REGION_NO") %>' />
                        <br />
                        ARNAME:
                        <asp:TextBox ID="ARNAMETextBox0" runat="server" Text='<%# Bind("ARNAME") %>' />
                        <br />
                        MUNIC_NAME:
                        <asp:TextBox ID="MUNIC_NAMETextBox0" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                        <br />
                        REGION_NAME:
                        <asp:TextBox ID="REGION_NAMETextBox0" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    <b>رقم المنطقة </b>
                                </td>
                                <td>
                                    <b>اسم المنطقة</b>
                                </td>
                                <td>
                                    <b>البلدية الفرعية </b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="REGION_NOLabel" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="REGION_NAMELabel" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="MUNIC_NAMELabel" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsRegionInfo" runat="server" SelectMethod="GetRegionInfo"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="regionID" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Chart ID="chkMainStUDI" runat="server" Height="315px" Width="546px" Palette="SeaGreen">
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
                    <asp:Chart ID="chkMainstBars" runat="server" Height="343px" Width="578px">
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
