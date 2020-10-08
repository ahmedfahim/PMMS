<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ThirdEquipment.aspx.cs" Inherits="ASPX_Archive_ThirdEquipment" %>

<%@ Register Assembly="UtilitiesLibrary" Namespace="UtilitiesLibrary.Controls" TagPrefix="cc1" %>
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
                    رسم الشوارع الرئيسية</h2>
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
                <asp:GridView ID="gvRegionSamplesErorr" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SECTION_ID" HeaderText="الرقم الفريد للمقطع" SortExpression="SECTION_ID" />
                        <asp:BoundField DataField="SECTION_NO" HeaderText="رقم المقطع" SortExpression="SECTION_NO" />
                        <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                        <asp:BoundField DataField="MUNICIPALITY" HeaderText="البلدية" SortExpression="MUNICIPALITY" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                        <asp:BoundField DataField="Main_no" HeaderText="رقم الشارع" SortExpression="Main_no" />
                        <asp:BoundField DataField="STREET_ID" HeaderText="الرقم الفريد للشارع" SortExpression="STREET_ID" />
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
            <td>
                &nbsp;
            </td>
            <td>
                <cc1:OneClickButton ID="BtnNewSections" runat="server" OnClick="BtnNewSections_Click"
                    Text="نقل بيانات الرسم" ReplaceTitleTo="يرجى الإنتظار" />
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
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                    AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="-1">الكل</asp:ListItem>
                    <asp:ListItem Value="0">رسم بالكامل</asp:ListItem>
                    <asp:ListItem Value="1">اضافات بالرسم</asp:ListItem>
                </asp:RadioButtonList>
                <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" DataSourceID="ObjectDataSource1"
                    AutoGenerateColumns="False" DataKeyNames="main_no" OnRowUpdating="gvRegionSamples_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                        <asp:CheckBoxField DataField="UPDATING" HeaderText=" إعادة التحليل" SortExpression="UPDATING" />
                        <asp:CheckBoxField DataField="IS_DRAWINGFINSH" HeaderText="تم الرسم" SortExpression="IS_DRAWINGFINSH" />
                        <asp:CheckBoxField DataField="IS_SAMPLEDRAW" HeaderText=" رسم عينات" ReadOnly="True"
                            SortExpression="IS_SAMPLEDRAW" />
                        <asp:CheckBoxField DataField="IS_LANEDRAW" HeaderText=" رسم الحارات" SortExpression="IS_LANEDRAW" />
                        <asp:CheckBoxField DataField="IS_SAMPLEFISHED" HeaderText=" تمت العينات" ReadOnly="True"
                            SortExpression="IS_SAMPLEFISHED" />
                        <asp:CheckBoxField DataField="NEW" HeaderText="جديد" SortExpression="NEW" ReadOnly="True" />
                        <asp:CommandField CancelText="إلغاء" EditText="إدخال" ShowEditButton="True" UpdateText="حفظ" />
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" ReadOnly="True" SortExpression="SURVEY_NO" />
                        <asp:CheckBoxField DataField="IS_StreetNew" HeaderText="رسم بالكامل" ReadOnly="True"
                            SortExpression="IS_StreetNew" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRecivedDrawingIRI"
                    TypeName="JpmmsClasses.BL.MainStreet" UpdateMethod="UpdateRecivedDrawingIRI">
                    <UpdateParameters>
                        <asp:Parameter Name="MAIN_NO" Type="String" />
                        <asp:Parameter Name="IS_DRAWINGFINSH" Type="Boolean" />
                        <asp:Parameter Name="UPDATING" Type="Boolean" />
                        <asp:Parameter Name="IS_SAMPLEDRAW" Type="Boolean" />
                        <asp:Parameter Name="IS_LANEDRAW" Type="Boolean" />
                        <asp:Parameter Name="IS_SAMPLEFISHED" Type="Boolean" DefaultValue="false" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
