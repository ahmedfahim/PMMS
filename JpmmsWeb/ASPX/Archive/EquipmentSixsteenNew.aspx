<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EquipmentSixsteenNew.aspx.cs" Inherits="ASPX_Archive_EquipmentSixsteenNew" %>

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
                    تحويل&nbsp;الشوارع الرئيسية للإدخال</h2>
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
                <cc1:OneClickButton ID="BtnFinshed" runat="server" OnClick="BtnStreet_Click" Text="تحديث الشوارع"
                    ReplaceTitleTo="يرجى الإنتظار" />
                <cc1:OneClickButton ID="BtnLength" runat="server" OnClick="BtnLength_Click" Text="تحديث الأطوال"
                    ReplaceTitleTo="يرجى الإنتظار" />
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                <br />
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
                <b>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Value="3">المسح الثالث</asp:ListItem>
                        <asp:ListItem Value="4">المسح الرابع</asp:ListItem>
                        <asp:ListItem Value="5">المسح الخامس</asp:ListItem>
                        <asp:ListItem Value="6">المسح السادس</asp:ListItem>
                        <asp:ListItem Value="7">المسح السابع</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="STREETS" HeaderText="المسح السابق" SortExpression="STREETS" />
                            <asp:BoundField DataField="ALLSTREETS" HeaderText="شوارع المسح" SortExpression="ALLSTREETS" /> 
                            <asp:BoundField DataField="CLOSEDMINUSIRI" HeaderText="مقفول IRI" SortExpression="CLOSEDMINUSIRI" />
                            
              
                            <asp:BoundField DataField="OPENMINUSIRI" HeaderText="مفتوح IRI" SortExpression="OPENMINUSIRI" />
                            <asp:BoundField DataField="COMPLETEIRI" HeaderText="مكتمل IRI" SortExpression="COMPLETEIRI" />
                            <asp:BoundField DataField="MINUSIRI" HeaderText="ناقص IRI" SortExpression="MINUSIRI" />
                            <asp:BoundField DataField="STREETSQC" HeaderText=" شوارع المعالجة" SortExpression="STREETSQC" />
                            
              
                            <asp:BoundField DataField="ERORRS" HeaderText="يحتاج تحويل " SortExpression="ERORRS" />
                            
              
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    </asp:GridView>
                </b>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="center">
                <asp:GridView ID="gvERorrLength" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="Black" GridLines="Vertical" EnableModelValidation="True" PageSize="15"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="STREET_ID" HeaderText="رقم الشارع الفريد" SortExpression="STREET_ID" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع " SortExpression="MAIN_NO" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:Label ID="lblFeedback0" runat="server" ForeColor="Red"></asp:Label>
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
                    AutoGenerateColumns="False" DataKeyNames="MAIN_NO,SURVEY_NO" OnRowUpdating="gvRegionSamples_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" ReadOnly="True" SortExpression="SURVEY_NO" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                        <asp:CheckBoxField DataField="IS_TRANSFARE" HeaderText="ادخال للتحليل" SortExpression="IS_TRANSFARE" />
                        <asp:CheckBoxField DataField="IS_Equipment" HeaderText="اعادة للمعدة" SortExpression="IS_Equipment" />
                        <asp:CheckBoxField DataField="TRANSFARE_ERROR" HeaderText="الملف غير موجود" ReadOnly="True"
                            SortExpression="TRANSFARE_ERROR" />
                        <asp:CommandField CancelText="الغاء" EditText="تحويل" ShowEditButton="True" UpdateText="تحديث" />
                        <asp:BoundField DataField="TypeOfEquipment" HeaderText="المعدة" ReadOnly="True" SortExpression="TypeOfEquipment" />
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
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRecivedMFVNext"
                        TypeName="JpmmsClasses.BL.MainStreet" UpdateMethod="UpdateRecivedIRIMFV">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="SURVEY_NO" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="MAIN_NO" Type="String" />
                            <asp:Parameter Name="IS_TRANSFARE" Type="Boolean" />
                            <asp:Parameter Name="IS_Equipment" Type="Boolean" />
                            <asp:Parameter Name="SURVEY_NO" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
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
