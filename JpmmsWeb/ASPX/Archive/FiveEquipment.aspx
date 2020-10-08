<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="FiveEquipment.aspx.cs" Inherits="ASPX_Archive_FiveEquipment" %>


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
        .bold
        {
            text-align: right;
        }
        
        .RadPicker_Default
        {
            vertical-align: middle;
        }
        .RadPicker_Default table.rcTable .rcInputCell
        {
            padding: 0 4px 0 0;
        }
        .style3
        {
            height: 18px;
        }
        
        .RadPicker_Default .RadInput
        {
            vertical-align: baseline;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    تعديل الشوارع الرئيسية</h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" DataSourceID="ObjectDataSource1"
                    AutoGenerateColumns="False" DataKeyNames="main_no" 
                    onrowupdating="gvRegionSamples_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                        <asp:CheckBoxField DataField="EDITING" HeaderText="تعديل الإدخال" SortExpression="EDITING" />
                        <asp:CheckBoxField DataField="DRAWING" HeaderText="اعادة الرسم" 
                            SortExpression="DRAWING" />
                        <asp:CheckBoxField DataField="IS_REVIEW_EDITING" HeaderText="إدخال نهائي" SortExpression="IS_REVIEW_EDITING" />
                        <asp:CommandField CancelText="إلغاء" EditText="إدخال" ShowEditButton="True" 
                                                UpdateText="حفظ" />
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
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRecivedUpdateingIRI"
                        TypeName="JpmmsClasses.BL.MainStreet" 
                        UpdateMethod="UpdateRecivedUpdateingIRI">
                        <UpdateParameters>
                            <asp:Parameter Name="MAIN_NO" Type="String" />
                            <asp:Parameter Name="EDITING" Type="Boolean" />
                            <asp:Parameter Name="DRAWING" Type="Boolean" />
                            <asp:Parameter Name="IS_REVIEW_EDITING" Type="Boolean" />
                            
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

