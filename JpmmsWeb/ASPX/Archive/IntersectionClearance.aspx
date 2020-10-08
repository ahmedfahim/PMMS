<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="IntersectionClearance.aspx.cs" Inherits="ASPX_Archive_IntersectionClearance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    <asp:Label ID="Label1" runat="server" Text="شوارع تحتاج مستخلص"></asp:Label>
                </h2>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="gvRegionSamplesEqupment" runat="server" CellPadding="4" EnableModelValidation="True"
                                ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" 
                                AutoGenerateColumns="False"  DataKeyNames="STREET_ID"
                                DataSourceID="ObjectDataSource1" 
                                onrowupdating="gvRegionSamplesEqupment_RowUpdating">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="STREET_ID" HeaderText="رقم الشارع الفريد" ReadOnly="True"
                                        SortExpression="STREET_ID" />
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                                    <asp:CheckBoxField DataField="IS_READY" HeaderText="التقرير" SortExpression="IS_READY" />
                                     <asp:CommandField CancelText="إلغاء" EditText="إدخال" ShowEditButton="True" UpdateText="حفظ" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetInterSectionsClearance"
                                TypeName="JpmmsClasses.BL.MainStreet" UpdateMethod="UpdateInterSectionsClearance">
                                <UpdateParameters>
                                    <asp:Parameter Name="STREET_ID" Type="String" />
                                    <asp:Parameter Name="IS_READY" Type="Boolean" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
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
