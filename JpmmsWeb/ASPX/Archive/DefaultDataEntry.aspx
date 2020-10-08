<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="DefaultDataEntry.aspx.cs" Inherits="ASPX_Archive_DefaultDataEntry" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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
        .style5
        {
            font-weight: bold;
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
                    مدخلين البيانات</h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
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
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor"  runat="server">
                  
                    <table align="center" width="60%">
                        <tr>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="90%">
                                &nbsp;
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="3">المسح الثالث</asp:ListItem>
                                    <asp:ListItem Value="4">المسح الحالي</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="style5">
                                  من</td>
                            <td>
                                <telerik:RadDatePicker ID="raddtpFrom" runat="server" Enabled="true">
                                    <calendar id="Calendar1" runat="server" usecolumnheadersasselectors="False" 
                                        userowheadersasselectors="False" viewselectortext="x">
                                    </calendar>
                                    <datepopupbutton hoverimageurl="" imageurl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td class="style5">
                                إلى</td>
                            <td>
                                <telerik:RadDatePicker ID="raddtpTo" runat="server" Enabled="true">
                                    <calendar id="Calendar2" runat="server" usecolumnheadersasselectors="False" 
                                        userowheadersasselectors="False" viewselectortext="x">
                                    </calendar>
                                    <datepopupbutton hoverimageurl="" imageurl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnAll" runat="server" OnClick="btnAll_Click" Text="عرض" />
                                <asp:Button ID="btnDetials" runat="server" OnClick="btnDetials_Click" 
                                    Text="تفصيلي" />
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
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="PanelALL" runat="server" Visible="false">
                                    <asp:GridView ID="gvAll" runat="server" 
                                        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                                        GridLines="None" PageSize="15" AllowSorting="True"
                                        AutoGenerateColumns="False" onsorting="gvAll_Sorting">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="USERNAME" HeaderText="اسم المدخل" 
                                                SortExpression="USERNAME" />
                                            <asp:BoundField DataField="TotalStreets" HeaderText="مجموع الشوارع" 
                                                SortExpression="TotalStreets" />
                                            <asp:BoundField DataField="TotaDISTRESS" HeaderText="مجموع العيوب" 
                                                SortExpression="TotaDISTRESS" />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" 
                                                SortExpression="SURVEY_NO" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                       
                                    </asp:GridView>
                                   
                                    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        SelectMethod="GetDataEntry" 
                                        TypeName="JpmmsClasses.BL.Lookups.SystemUsers">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="RadioButtonList1" Name="SURVEY_NO" 
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="PanelDetials" runat="server" Visible="false">
                                    <asp:GridView ID="gvDetials" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" EnableModelValidation="True" 
                                        ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" 
                                        onsorting="gvDetials_Sorting">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="USERNAME" HeaderText="اسم المدخل" 
                                                SortExpression="USERNAME" />
                                            <asp:BoundField DataField="TotalStreets" HeaderText="مجموع الشوارع" SortExpression="TotalStreets" />
                                               <asp:BoundField DataField="TotaDISTRESS" HeaderText="مجموع العيوب" SortExpression="TotaDISTRESS" />
                                            <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" 
                                                SortExpression="REGION_NO" />
                                            <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" 
                                                SortExpression="SURVEY_NO" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                    <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                        SelectMethod="GetDataEntryDetials" 
                                        TypeName="JpmmsClasses.BL.Lookups.SystemUsers">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="RadioButtonList1" Name="SURVEY_NO" 
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
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

