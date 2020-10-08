<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="SecoundEquipment.aspx.cs" Inherits="ASPX_Archive_SecoundEquipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<table>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    مراجعه الشوارع الرئيسية</h2>
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
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
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
                <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" DataSourceID="ObjectDataSource1"
                    AutoGenerateColumns="False" DataKeyNames="main_no" OnRowUpdating="gvRegionSamples_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                        <asp:CheckBoxField DataField="IS_TRANSFARE_ERROR" HeaderText="خطأ بالملف" ReadOnly="True"
                            SortExpression="IS_TRANSFARE_ERROR" />
                        <asp:CheckBoxField DataField="UPDATING" HeaderText="إعادة تحليل" SortExpression="UPDATING" />
                        <asp:CheckBoxField DataField="IS_Equipment" HeaderText="اعادة للمعدة" SortExpression="IS_Equipment" />
                        <asp:CheckBoxField DataField="IS_REVIEW_EDITING" HeaderText="إدخال نهائي" SortExpression="IS_REVIEW_EDITING" />
                        <asp:CheckBoxField DataField="EDITING" HeaderText="إعادة إدخال" SortExpression="EDITING" />
                        <asp:CheckBoxField DataField="DRAWING" HeaderText="يحتاج رسم" SortExpression="DRAWING" />
                        <asp:CheckBoxField DataField="NEW" HeaderText="جديد" SortExpression="NEW" ReadOnly="True" />
                        <asp:CheckBoxField DataField="IS_StreetNew" HeaderText="رسم بالكامل" ReadOnly="True"
                            SortExpression="IS_StreetNew" />
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" ReadOnly="True" SortExpression="SURVEY_NO" />
                        <asp:BoundField DataField="TypeOfEquipment" HeaderText="المعدة" ReadOnly="True" SortExpression="TypeOfEquipment" />
                        <asp:CommandField CancelText="إلغاء" EditText="إدخال" ShowEditButton="True" UpdateText="حفظ" />
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
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor" runat="server">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRecivedEditingIRI"
                        TypeName="JpmmsClasses.BL.MainStreet" UpdateMethod="UpdateRecivedEditingIRI">
                        <UpdateParameters>
                            <asp:Parameter Name="MAIN_NO" Type="String" />
                            <asp:Parameter Name="IS_REVIEW_EDITING" Type="Boolean" />
                            <asp:Parameter Name="EDITING" Type="Boolean" />
                            <asp:Parameter Name="DRAWING" Type="Boolean" />
                            <asp:Parameter Name="IS_Equipment" Type="Boolean" />
                            <asp:Parameter Name="UPDATING" Type="Boolean" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
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
