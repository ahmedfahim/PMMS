<%@ Page Title="البلديات الفرعية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="Municipality.aspx.cs" Inherits="ASPX_Lookups_Municipality" %>

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
                    <b>&nbsp; البلديات الفرعية</b></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsMunic" runat="server" SelectMethod="GetAllMunic" TypeName="JpmmsClasses.BL.Municpiality"
                    UpdateMethod="Update" OnUpdated="odsMunic_Updated">
                    <UpdateParameters>
                        <asp:Parameter Name="MUNIC_NO" Type="String" />
                        <asp:Parameter Name="ARNAME" Type="String" />
                        <asp:Parameter Name="ENNAME" Type="String" />
                        <asp:Parameter Name="MUNIC_ID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MUNIC_ID"
                    DataSourceID="odsMunic" EnableModelValidation="True" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnRowUpdating="GridView1_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="MUNIC_ID" HeaderText="MUNIC_ID" ReadOnly="True" SortExpression="MUNIC_ID"
                            Visible="False" />
                        <asp:BoundField DataField="MUNIC_NO" HeaderText="رقم البلدية" SortExpression="MUNIC_NO" />
                        <asp:BoundField DataField="ARNAME" HeaderText="الاسم العربي" SortExpression="ARNAME" />
                        <asp:BoundField DataField="ENNAME" HeaderText="الاسم الانجليزي" SortExpression="ENNAME" />
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
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
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
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
