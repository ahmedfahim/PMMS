<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="ReportingOthersNEWs.aspx.cs" Inherits="ASPX_Reports_ReportingOthersNEWs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <b>إنتاجية الشوارع الممسوحة</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                              
         
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                <asp:ListItem Value="3">المسح الثالث</asp:ListItem>
                                <asp:ListItem Selected="True" Value="4">المسح الحالي</asp:ListItem>
                                <asp:ListItem Value="0">الكل</asp:ListItem>
                                <asp:ListItem Value="-1">اجمالي المسح السابق </asp:ListItem>
                            </asp:RadioButtonList>
                              
         
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                              
         
                            <asp:DropDownList ID="DrpDwnListMonth" runat="server" 
                                AppendDataBoundItems="True" DataSourceID="ObjectDataSource1" 
                                DataTextField="REPORTMONTH_TITLE" DataValueField="MonthYear">
                                <asp:ListItem Value="-1">اختر الشهر</asp:ListItem>
                                <asp:ListItem Value="0">الكل</asp:ListItem>
                            </asp:DropDownList>
                       
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
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
                <asp:CheckBox ID="CheckBoxOne" runat="server" Text="انجاز المسح" />
                       
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                              
         
                <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
                       
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
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