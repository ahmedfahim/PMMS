<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesWorkOrders.master" AutoEventWireup="true" CodeFile="WorkOrdersPiriority.aspx.cs" Inherits="ASPX_Lookups_WorkOrdersPiriority" %>

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
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <h2 class="style2">
                    <b>أواويات الصيانة </b></h2>
            </td>
            <td rowspan="3">
                &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
    </table>
    <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
    </asp:DropDownList>
                            &nbsp;
                            <asp:ObjectDataSource ID="odsRegionInfo" runat="server" SelectMethod="GetRegionInfo"
                                TypeName="JpmmsClasses.BL.Region">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                                TypeName="JpmmsClasses.BL.Region">
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ARNAME" HeaderText="اسم الحي" />
            <asp:BoundField DataField="SECOND_ARNAME" HeaderText="اسم الشارع" />
            <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" />
            <asp:BoundField DataField="SUBDISTRICT" HeaderText="اسم المنطقه وقمها" />
            <asp:BoundField DataField="SECOND_ST_NO" HeaderText="رقم العينة" />
            <asp:BoundField DataField="UDI_RATE" HeaderText="تقيم احاله الرصف" />
            <asp:BoundField DataField="UDI" HeaderText="قيمه حاله الرصف" />
            <asp:BoundField DataField="MAINT_DECISION" HeaderText="قرار الصيانه" />
            <asp:BoundField DataField="MAINT_AREA" HeaderText="مساحه الصيانة" />
            <asp:BoundField DataField="UDI_ENHANCE" HeaderText="القيمه بعد التصحيح" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
</asp:Content>

