<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="LaneSectionsErorrs.aspx.cs" Inherits="ASPX_Archive_LaneSectionsErorrs" %>

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
                    حارات مربوطة خطأ بالمقاطع &nbsp; <br />
                    مراجعه العيوب قبل الإدخال النهائي
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
                            <asp:GridView ID="gvDistress" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                EnableModelValidation="True" PageSize="15" DataSourceID="ObjectDataSource2" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO"
                                        ReadOnly="true" />
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO"
                                        ReadOnly="true" />
                                    <asp:CheckBoxField DataField="IS_DDF" HeaderText="مدخل نهائي" ReadOnly="True" SortExpression="IS_DDF" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسح" SortExpression="SURVEY_NO" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                            <asp:GridView ID="gvERorrIRI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15"
                                DataSourceID="ObjectDataSource1" DataKeyNames="SECTION_NO,MAIN_NO">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO"
                                        ReadOnly="true" />
                                    <asp:BoundField DataField="LANE_TYPE" HeaderText="نوع الحارة" />
                                    <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO"
                                        ReadOnly="true" />
                                    <asp:BoundField DataField="section_id" HeaderText="رقم  الفريد للمقطع" SortExpression="section_id" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetErorrSectionLane"
                                TypeName="JpmmsClasses.BL.MainStreet" UpdateMethod="UpdateStreetsUpdateErorrIRI">
                                <UpdateParameters>
                                    <asp:Parameter Name="section_id" Type="String" />
                                    <asp:Parameter Name="section_no" Type="String" />
                                    <asp:Parameter Name="Lane" Type="String" />
                                    <asp:Parameter Name="main_no" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetSectionsErorrIRIDISTRESS"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
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
