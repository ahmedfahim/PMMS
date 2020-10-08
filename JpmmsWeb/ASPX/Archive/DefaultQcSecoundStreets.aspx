<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="DefaultQcSecoundStreets.aspx.cs" Inherits="ASPX_Archive_DefaultQcSecoundStreets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        .bold
        {
            text-align: right;
        }
                
        .RadPicker_Default
        {
            vertical-align: middle;
        }
        .RadPicker_Default table.rcTable .rcInputCell
        {
            padding: 0 4px 0 0;
        }
        .style3
    {
        height: 18px;
    }
                
.RadPicker_Default .RadInput
{
	vertical-align:baseline;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    مراجعه عينات الشوارع</h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor"  runat="server">
                  
                    <table align="center" width="60%">
<%--
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="DrpDwnListMonth" runat="server" 
                                    AppendDataBoundItems="True" AutoPostBack="True" 
                                    DataSourceID="ObjectDataSource2" DataTextField="REPORTMONTH_TITLE" 
                                    DataValueField="REPORTMONTH_ID">
                                    <asp:ListItem Value="-1">اختر الشهر</asp:ListItem>
                                    <asp:ListItem Value="0">الكل</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                    SelectMethod="GetReportMonthsRegions" TypeName="JpmmsClasses.BL.Lookups.SystemUsers">
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="PanelNewStreets" runat="server" Visible="true">
                                    <asp:GridView ID="gvRegionSamples" runat="server" 
                                        CellPadding="4" ForeColor="#333333" 
                                        GridLines="None" PageSize="15" 
                                        AllowSorting="True" DataSourceID="ObjectDataSource1" 
                                        AutoGenerateColumns="False" EnableModelValidation="True">
                                        <AlternatingRowStyle BackColor="White" />
                                          <Columns>
                                              <asp:BoundField DataField="STREET_ID" HeaderText="الرقم الفريد" 
                                                  SortExpression="STREET_ID" />
                                              <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                                              <asp:BoundField DataField="SECOND_ST_NO" HeaderText="رقم العينة" 
                                                  SortExpression="SECOND_ST_NO" />
                                              <asp:BoundField DataField="SECOND_ARNAME" 
                                                  HeaderText="اسم الشارع" SortExpression="SECOND_ARNAME" />
                                              <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" 
                                                  SortExpression="NOTES" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                       
                                    </asp:GridView>
                                 
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        SelectMethod="GetSECOND_ST_NO" 
                                        TypeName="JpmmsClasses.BL.Lookups.SystemUsers">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="Month" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
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
        </tr>
    </table>
</asp:Content>


