<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EquipmentUpdateErorrIRI.aspx.cs" Inherits="ASPX_Archive_EquipmentUpdateErorrIRI" %>

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
        .style3
        {
            text-align: right;
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
                    تأكيد ربط المقاطع المرسومة مع معدة رصف الطريق &nbsp;IRI</h2>
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
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvERorrIRI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" 
                                PageSize="15" DataSourceID="ObjectDataSource1" 
                                DataKeyNames="SECTION_NO,MAIN_NO,Lane,SURVEY_NO" 
                                onrowupdating="gvERorrIRI_RowUpdating">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" ReadOnly="true" />
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO" ReadOnly="true"  />
                                    <asp:BoundField DataField="section_id" HeaderText="رقم  الفريد للمقطع" SortExpression="section_id"  />
                                    <asp:BoundField DataField="Lane" HeaderText="نوع الحارة" SortExpression="Lane"  ReadOnly="true"/>
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" SortExpression="SURVEY_NO"  ReadOnly="true"/>
                                    <asp:CommandField ShowEditButton="True" CancelText="إلغاء" EditText="تحديث" 
                                        UpdateText="موافق" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                SelectMethod="GetStreetsUpdateErorrIRI" TypeName="JpmmsClasses.BL.MainStreet" 
                                UpdateMethod="UpdateStreetsUpdateErorrIRI">
                                <UpdateParameters>
                                    <asp:Parameter Name="section_id" Type="String" />
                                    <asp:Parameter Name="section_no" Type="String" />
                                    <asp:Parameter Name="Lane" Type="String" />
                                    <asp:Parameter Name="main_no" Type="String" />
                                    <asp:Parameter Name="SURVEY_NO" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
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
