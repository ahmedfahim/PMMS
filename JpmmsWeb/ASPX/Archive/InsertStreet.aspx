<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="InsertStreet.aspx.cs" Inherits="ASPX_Archive_InsertStreet" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchRegion.ascx" TagName="SearchRegion" TagPrefix="uc1" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
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
        .style5
        {
            font-weight: bold;
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
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    لإ<strong>دخال شارع جديد راجع GIS</strong></h2>
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
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurvey"  runat="server">
                  
                    <table align="center" width="60%">
                        <tr>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="90%">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="style5">
                                  المنطقة الفرعية </td>
                            <td>
                                <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" 
                                    AutoPostBack="True" DataSourceID="odsRegions" DataTextField="region_title" 
                                    DataValueField="region_id" 
                                    onselectedindexchanged="ddlRegions_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                رقم العينة</td>
                            <td>
                                <asp:TextBox ID="txtSECOND_ST_NO" runat="server" CssClass="style5" 
                                    Width="9%" MaxLength="2"></asp:TextBox>
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
                                <table align="right" class="style4">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="حفظ" Visible="false" 
                                                Enabled="False" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                        
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td colspan="2">
                            <asp:Panel ID="PanelNewStreets"  runat="server" Visible="false">
                            <strong>شوارع جديدة مدخلة سابقا</strong>
                                <asp:GridView ID="gvRegionSamples" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="STREET_ID" 
                                    DataSourceID="odsRegionSamples" EnableModelValidation="True" 
                                    ForeColor="#333333" GridLines="None" 
                                    OnPageIndexChanged="gvRegionSamples_PageIndexChanged" 
                                    OnRowUpdating="gvRegionSamples_RowUpdating" PageSize="15">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="STREET_ID" HeaderText="STREET_ID" ReadOnly="True" 
                                            SortExpression="STREET_ID" Visible="False" />
                                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="الرقم" ReadOnly="True" 
                                            SortExpression="SECOND_ST_NO" />
                                        <asp:BoundField DataField="SECOND_AR_NAME" HeaderText="اسم الشارع الفرعي" 
                                            SortExpression="SECOND_AR_NAME" />
                                        <asp:TemplateField HeaderText="الطول" SortExpression="SECOND_ST_LENGTH">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="rntxtLengthSecST" runat="server" Culture="ar-QA" 
                                                    DataType="System.Double" DbValue='<%# Bind("SECOND_ST_LENGTH") %>' MinValue="0" 
                                                    Width="125px">
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" 
                                                    Text='<%# Bind("SECOND_ST_LENGTH", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="العرض" SortExpression="SECOND_ST_WIDTH">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="rntxtWidthSecST" runat="server" Culture="ar-QA" 
                                                    DataType="System.Double" DbValue='<%# Bind("SECOND_ST_WIDTH") %>' MinValue="0" 
                                                    Width="125px">
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" 
                                                    Text='<%# Bind("SECOND_ST_WIDTH", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" 
                                            ReadOnly="True" SortExpression="AREA" />
                                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" 
                                            UpdateText="حفظ" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsRegionSamples" runat="server" 
                                    OnUpdated="odsRegionSamples_Updated" SelectMethod="GetRegionSamplesNewStreets" 
                                    TypeName="JpmmsClasses.BL.Region" 
                                    UpdateMethod="UpdateSecondaryStreetSampleArea">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" 
                                            PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="STREET_ID" Type="Int32" />
                                        <asp:Parameter Name="SECOND_AR_NAME" Type="String" />
                                        <asp:Parameter Name="SECOND_ST_LENGTH" Type="Double" />
                                        <asp:Parameter Name="SECOND_ST_WIDTH" Type="Double" />
                                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                                        <asp:Parameter Name="NOTES" Type="String" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                    </table>
                         <br />
                    <asp:ObjectDataSource ID="odsRegions" runat="server" 
                        SelectMethod="GetAllRegions" TypeName="JpmmsClasses.BL.Region">
                    </asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
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


