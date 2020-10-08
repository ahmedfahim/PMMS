<%@ Page Title="البحث في بيانات التحسينات المرورية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SearchTrafficEnhances.aspx.cs" Inherits="ASPX_Operations_TrafficEnhances_SearchTrafficEnhances" %>

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
                    <b>البحث في بيانات التحسينات المرورية</b></h2>
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
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ASPX/Operations/TrafficEnhances/TrafficEnhances.aspx">إضافة مقترح تحسين مروري جديد</asp:HyperLink>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="RECORD_ID" DataSourceID="odsTrafficEnhancesAll"
                    ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                            Visible="False" />
                        <asp:BoundField DataField="PROPOSE_TITLE" HeaderText="اسم مقترح التحسين المروري"
                            SortExpression="PROPOSE_TITLE" />
                        <asp:BoundField DataField="APPROVE_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الاعتماد"
                            SortExpression="APPROVE_DATE" />
                        <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية الفرعية" SortExpression="MUNIC_NAME" />
                        <asp:BoundField DataField="LETTER_FROM" HeaderText="خطاب وارد من" SortExpression="LETTER_FROM" />
                        <asp:BoundField DataField="LETTER_NO" HeaderText="رقم الخطاب" SortExpression="LETTER_NO" />
                        <asp:BoundField DataField="LETTER_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الخطاب"
                            SortExpression="LETTER_DATE" />
                        <asp:BoundField DataField="COMMITTE_HEAD_NAME" HeaderText="لجنة الدراسة والاعتماد برئاسة"
                            SortExpression="COMMITTE_HEAD_NAME" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" SortExpression="NOTES" />
                        <asp:HyperLinkField DataNavigateUrlFields="RECORD_ID" DataNavigateUrlFormatString="EditTrafficEnhance.aspx?ID={0}"
                            Target="_blank" HeaderText="تعديل" Text="..." />
                        <asp:HyperLinkField DataNavigateUrlFields="RECORD_ID" DataNavigateUrlFormatString="TrafficEnhancesDetails.aspx?ID={0}"
                            Target="_blank" HeaderText="التفاصيل والأماكن" Text="..." />
                        <asp:HyperLinkField DataNavigateUrlFields="RECORD_ID" DataNavigateUrlFormatString="TrafficEnhanceFiles.aspx?ID={0}"
                            Target="_blank" HeaderText="الملفات" Text="..." />
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
                <asp:ObjectDataSource ID="odsTrafficEnhancesAll" runat="server" DeleteMethod="DeleteTrafficEnhance"
                    SelectMethod="GetAll" TypeName="JpmmsClasses.BL.TrafficEnhances" OnDeleted="odsTrafficEnhancesAll_Deleted">
                    <DeleteParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
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
        </tr>
    </table>
</asp:Content>
