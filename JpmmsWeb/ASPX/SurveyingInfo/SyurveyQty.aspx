<%@ Page Title="كميات المسح" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SyurveyQty.aspx.cs" Inherits="ASPX_SurveyingInfo_SyurveyQty" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        .style3
        {
            width: 40%;
        }
        .style5
        {
            font-size: small;
        }
        .style6
        {
            text-align: center;
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <strong>كميات المسح</strong></h2>
            </td>
            <td class="style5">
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
            <td colspan="3">
                <asp:ObjectDataSource ID="odsSurveyors" runat="server" SelectMethod="GetAllsurveyors"
                    TypeName="JpmmsClasses.BL.Surveyor"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style5">
                <table class="style1">
                    <tr>
                        <td class="style5">
                            المساح
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSurveyor" runat="server" AppendDataBoundItems="True" DataSourceID="odsSurveyors"
                                DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" CssClass="style5">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <span class="style5">في الفترة مابين
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="raddtpFrom" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            إلى
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="raddtpTo" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp; </span>
                        </td>
                        <td colspan="2">
                            <table align="right" class="style3">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="بحث" CssClass="style5" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء"
                                            CssClass="style5" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <span class="style5">&nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            </span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <h4 class="style5">
                    <strong>المقاطع</strong></h4>
            </td>
            <td class="style2">
                <h4 class="style5">
                    <strong>التقاطعات</strong></h4>
            </td>
            <td class="style2">
                <h4 class="style5">
                    <strong>المناطق الفرعية</strong></h4>
            </td>
        </tr>
        <tr class="style5">
            <td align="center">
                المجموع:
                <asp:Label ID="lblSectionsTotal" runat="server"></asp:Label>
            </td>
            <td align="center">
                المجموع:
                <asp:Label ID="lblIntersectsTotal" runat="server"></asp:Label>
            </td>
            <td align="center">
                المجموع:
                <asp:Label ID="lblRegionsTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" class="style5">
                المجموع الإجمالي:
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" class="style5">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="gvSurveyedSections" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="لاتوجد بيانات"
                    CssClass="style5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SECTION_NO" HeaderText="الرقم" SortExpression="SECTION_NO" />
                        <asp:BoundField DataField="SECTION_AREA" DataFormatString="{0:N2}" HeaderText="المساحة"
                            SortExpression="SECTION_AREA" />
                        <asp:BoundField DataField="RECEIVE_DATE" DataFormatString="{0:d}" HeaderText="تاريخ التسليم"
                            SortExpression="RECEIVE_DATE" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </td>
            <td valign="top">
                <asp:GridView ID="gvSurveyedIntersects" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="لاتوجد بيانات"
                    CssClass="style5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="INTER_NO" HeaderText="الرقم" SortExpression="INTER_NO" />
                        <asp:BoundField DataField="INTERSECTION_AREA" DataFormatString="{0:N2}" HeaderText="المساحة"
                            SortExpression="INTERSECTION_AREA" />
                        <asp:BoundField DataField="RECEIVE_DATE" DataFormatString="{0:d}" HeaderText="تاريخ التسليم"
                            SortExpression="RECEIVE_DATE" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </td>
            <td valign="top">
                <asp:GridView ID="gvSurveyedRegion" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" EmptyDataText="لاتوجد بيانات" CssClass="style5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SUBDISTRICT" HeaderText="الاسم" SortExpression="SUBDISTRICT" />
                        <asp:BoundField DataField="REGION_NO" HeaderText="الرقم" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="REGION_AREA" DataFormatString="{0:N2}" HeaderText="المساحة"
                            SortExpression="REGION_AREA" />
                        <asp:BoundField DataField="RECEIVE_DATE" DataFormatString="{0:d}" HeaderText="تاريخ التسليم"
                            SortExpression="RECEIVE_DATE" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
