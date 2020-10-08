<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EquipmentSectionsDetails.aspx.cs" Inherits="ASPX_Archive_EquipmentSectionsDetails" %>

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
            text-align: right;
        }
        .bold
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <h2 class="style2">
                            تفاصيل الشوارع الرئيسية المعده
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
                        <table align="center">
                            <tr>
                                <td>
                                    <b>الشارع الرئيسي </b>
                                    <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="odsRegions" DataTextField="arname" DataValueField="MAIN_NO" OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged"
                                        Width="40%">
                                        <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                                        <asp:ListItem Value="0">الكل</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetSectionsDetailsIRI"
                                        TypeName="JpmmsClasses.BL.MainStreet">
                                        <SelectParameters>
                                            <asp:Parameter Name="MAIN_NO" Type="String" ConvertEmptyStringToNull="true" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="عرض" Width="50px" Visible="false"/>
                                    <asp:Label
                                        ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td dir="rtl">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                        <asp:ListItem  Value="1">من المعدة</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="2">من النظام</asp:ListItem>
                                        <asp:ListItem Value="0">جديد من المعدة</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvRegionSamplesNEW" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True"
                                        PageSize="15">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SN" HeaderText="مسلسل" SortExpression="SN" Visible="false" />
                                            <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO" />
                                            <asp:BoundField DataField="SEC_LANES_TYPE" HeaderText="نوع الحارة" SortExpression="SEC_LANES_TYPE" />
                                            <asp:BoundField DataField="SEC_LANES_COUNT" HeaderText="عدد الحارات" SortExpression="SEC_LANES_COUNT" />
                                            <asp:BoundField DataField="SEC_LENGTH" HeaderText="طول المقطع" SortExpression="SEC_LENGTH" />
                                            <asp:BoundField DataField="SEC_WIDTH" HeaderText="عرض المقطع" SortExpression="SEC_WIDTH" />
                                            <asp:BoundField DataField="SEC_LANES_LENGTH" HeaderText="طول كل الحارات" SortExpression="SEC_LANES_LENGTH" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                                <td>
                                    <asp:GridView ID="gvRegionSamplesIRI" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True"
                                        PageSize="15" AllowSorting="True" OnSorting="gvRegionSamplesIRI_Sorting">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SN" HeaderText="مسلسل" SortExpression="SN" Visible="false" />
                                            <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO" />
                                            <asp:BoundField DataField="FROM_STREET" HeaderText="من شارع" SortExpression="FROM_STREET" />
                                            <asp:BoundField DataField="TO_STREET" HeaderText="الى شارع" SortExpression="TO_STREET" />
                                            <asp:BoundField DataField="SEC_DIRECTION" HeaderText="الاتجاة" SortExpression="SEC_DIRECTION" />
                                            <asp:BoundField DataField="SEC_LANES_TYPE" HeaderText="نوع الحارة" SortExpression="SEC_LANES_TYPE" />
                                            <asp:BoundField DataField="SEC_LANES_COUNT" HeaderText="عدد الحارات" SortExpression="SEC_LANES_COUNT" />
                                            <asp:BoundField DataField="SEC_LENGTH" HeaderText="طول المقطع" SortExpression="SEC_LENGTH" />
                                            <asp:BoundField DataField="SEC_WIDTH" HeaderText="عرض المقطع" SortExpression="SEC_WIDTH" />
                                            <asp:BoundField DataField="SEC_LANES_LENGTH" HeaderText="طول كل الحارات" SortExpression="SEC_LANES_LENGTH" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
