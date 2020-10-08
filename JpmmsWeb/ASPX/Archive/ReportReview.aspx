<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="ReportReview.aspx.cs" Inherits="ASPX_Archive_ReportReview" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
	vertical-align:baseline;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    مراجعة الملفات لحساب حالة الرصف وقرارات الصيانة</h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor"  runat="server">
                  
                    <table align="center" width="60%">

                        <tr>
                            <td>
                                <asp:Button ID="BtnEND" runat="server" ForeColor="Red" onclick="BtnEND_Click" 
                                    Text="نهاية الشهر" />
                                <asp:Button ID="BtnYes" runat="server" onclick="BtnYes_Click" Text="نعم" 
                                    Visible="False" />
                                <asp:Button ID="BtnNO" runat="server" onclick="BtnNO_Click" Text="لا" 
                                    Visible="False" />
                                <asp:Button ID="BtnNEW" runat="server" onclick="BtnNEW_Click" 
                                    Text="نقل الشوارع الجديده "  Width="120px" /> 
                                     <asp:Button ID="btnMainStreetsUdi" runat="server" 
                                    OnClick="btnMainStreetsUdi_Click" 
                                    OnClientClick="return confirm('حساب حالة الرصف سيستغرق وقتا، هل تريد مواصلة الحساب؟');" 
                                    Text="حساب حالة الرصف للكل" Width="130px" />
                                <asp:Button ID="btnMainStreetsMin" runat="server" 
                                    OnClick="btnMainStreetsMin_Click" 
                                    OnClientClick="return confirm('حساب قرارات الصيانة  سيستغرق وقتا، هل تريد مواصلة الحساب؟');" 
                                    Text="حساب قرارات الصيانة للكل" Width="140px" />
                              
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                 <asp:Panel ID="PanelNewStreets" runat="server" Visible="true">
                                    <asp:GridView ID="gvRegionSamples" runat="server" AllowSorting="True" 
                                        AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                        onrowupdating="gvRegionSamples_RowUpdating" PageSize="15" 
                                         ondatabound="gvRegionSamples_DataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="NUMROW" HeaderText="مسلسل" ReadOnly="True" 
                                                SortExpression="NUMROW" />
                                            <asp:BoundField DataField="FILENAME" HeaderText="رقم الملف" ReadOnly="True" 
                                                SortExpression="FILENAME" />
                                            <asp:TemplateField HeaderText="رقم المنطقة" SortExpression="REGION_NO">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("REGION_NO") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("REGION_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رقم المسح" SortExpression="SURVEY_NO">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="USERNAME" HeaderText="اسم المستخدم" ReadOnly="True" 
                                                SortExpression="USERNAME" />
                                            <asp:TemplateField HeaderText="تاريخ استلام الملف" 
                                                SortExpression="RECEIVED_STARTDATE">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" 
                                                        Text='<%# Eval("RECEIVED_STARTDATE", "{0:yyyy/MM/dd}") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" 
                                                        Text='<%# Eval("RECEIVED_STARTDATE", "{0:yyyy/MM/dd}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CheckBoxField DataField="IS_DATAENTRYFINSH" HeaderText="حالة الإدخال" 
                                                SortExpression="IS_DATAENTRYFINSH" Visible="False" />
                                            <asp:CheckBoxField DataField="IS_REVIEWREPORT" HeaderText="جاهز للتقرير" 
                                                SortExpression="IS_REVIEWREPORT" />
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
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        SelectMethod="GetReceivedReports" TypeName="JpmmsClasses.BL.Lookups.SystemUsers" 
                                        UpdateMethod="UpdateRePortReviewed">
                                        <UpdateParameters>
                                            <asp:Parameter Name="REGION_NO" Type="String" />
                                            <asp:Parameter Name="IS_REVIEWREPORT" Type="Boolean" />
                                            <asp:Parameter Name="SURVEY_NO" Type="String" />
                                        </UpdateParameters>
                                    </asp:ObjectDataSource>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
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

