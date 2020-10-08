<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EquipmentASSETS.aspx.cs" Inherits="ASPX_Archive_EquipmentASSETS" %>

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
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <h2 class="style2">
                            الأصول ASSETS</h2>
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
                        <asp:Label ID="Label1" runat="server" Text="المستخلص رقم"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            DataSourceID="ObjectDataSource1" DataTextField="CLEARANCE_ASSETS" DataValueField="CLEARANCE_ASSETS"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="-1">اختر</asp:ListItem>
                            <asp:ListItem Value="ALL">الكل</asp:ListItem>
                        </asp:DropDownList>
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
                        <asp:Label ID="lblFeedbackTotal" runat="server" ForeColor="Red"></asp:Label>
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
                        <asp:Label ID="lblFeedbackClearance" runat="server" ForeColor="Red"></asp:Label>
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
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                            EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        </asp:GridView>
                        <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                            ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" AutoGenerateColumns="False"
                            DataKeyNames="MAIN_NO">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                                <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                                <%--<asp:BoundField DataField="SECTIONS_SYS" HeaderText="مقاطع النظام" SortExpression="SECTIONS_SYS" />
                        <asp:BoundField DataField="LANES_SYS" HeaderText="حارات النظام" SortExpression="LANES_SYS" />--%>
                                <asp:BoundField DataField="STREET_ASSETS_LEN" HeaderText="طول اتجاهي الطريق" SortExpression="STREET_ASSETS_LEN" />
                                <asp:BoundField DataField="CLEARANCE_ASSETS" HeaderText="المستخلص رقم" SortExpression="CLEARANCE_ASSETS" />
                                <%--  <asp:BoundField DataField="STREET_SHAPE_LEN" HeaderText="الطول المرسوم" SortExpression="STREET_SHAPE_LEN" />
                        <asp:BoundField DataField="STREET_IRI_LEN" HeaderText="الطول الممسوح" SortExpression="STREET_IRI_LEN" />--%>
                                <asp:CheckBoxField DataField="is_closed" HeaderText="تقاطعات" SortExpression="is_closed" />
                                <asp:BoundField DataField="SURVEY_NO" HeaderText="مسحة" SortExpression="SURVEY_NO" />
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
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="CompareASSETS"
                                TypeName="JpmmsClasses.BL.MainStreet">
                                <SelectParameters>
                                    <asp:Parameter Name="CLEARANCE" Type="String" />
                                </SelectParameters>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
