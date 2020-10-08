<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="EquipmentThrteen.aspx.cs" Inherits="ASPX_Archive_EquipmentThrteen" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td colspan="3" align="center">
                <h3>
                    الشوارع الرئيسية بالمعدة</h3>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" DataSourceID="ObjectDataSource1"
                    AutoGenerateColumns="False" OnRowCreated="gvRegionSamplesIRI_RowCreated">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                        <%--<asp:BoundField DataField="STREET_ID" HeaderText="الرقم الفريد" ReadOnly="True" SortExpression="STREET_ID" />--%>
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                          <asp:BoundField DataField="length" HeaderText="الطول المرسومKM" ReadOnly="True"
                            SortExpression="length" />
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" 
                            SortExpression="SURVEY_NO" />
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" >
                <asp:Panel ID="pnlSurveyor" runat="server">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="FinshedRowDataMFV"
                        TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

