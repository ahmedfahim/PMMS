<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="InsertFile.aspx.cs" Inherits="ASPX_Archive_InsertFile" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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
    &nbsp;<table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    إستلام ملفات المسح البصري</h2>
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
                <asp:Panel ID="pnlSurveyor"  runat="server">
                  
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
                                  مدخل البيانات</td>
                            <td>
                                <asp:DropDownList ID="ddlFilterUsers" runat="server" AppendDataBoundItems="True" 
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td class="style5">
                                المنطقة الفرعية
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" 
                                    AutoPostBack="True" DataSourceID="odsRegions" DataTextField="region_title" 
                                    DataValueField="region_id">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsRegions" runat="server" 
                                    SelectMethod="GetAllRegions" TypeName="JpmmsClasses.BL.Region">
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table align="right" class="style4">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                                        </td>
                                         <td>
                                            <asp:Button ID="btnAll" runat="server" OnClick="btnAll_Click" Text="عرض" />
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
                                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="PanelNewStreets" runat="server" Visible="false">
                                    <strong>ملفات مدخلة سابقا</strong>
                                    <br />
                                    <asp:GridView ID="gvRegionSamples" runat="server" 
                                        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                                        GridLines="None" PageSize="15" 
                                        AllowSorting="True" DataSourceID="ObjectDataSource1" 
                                        AutoGenerateColumns="False" 
                                        onselectedindexchanging="gvRegionSamples_SelectedIndexChanging" 
                                        onrowupdating="gvRegionSamples_RowUpdating">
                                        <AlternatingRowStyle BackColor="White" />
                                          <Columns>
                                              <asp:TemplateField HeaderText="رقم الملف" SortExpression="FILENAME">
                                                  <EditItemTemplate>
                                                      <asp:Label ID="Label6" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label4" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="رقم المنطقة" SortExpression="REGION_NO">
                                                  <EditItemTemplate>
                                                      <asp:Label ID="Label9" runat="server" Text='<%# Eval("REGION_NO") %>' ToolTip='<%# Eval("ID") %>' ></asp:Label>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("REGION_NO") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="اسم المستخدم" SortExpression="USERNAME">
                                                  <EditItemTemplate>
                                                      <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" 
                                                          DataSourceID="ObjecDataTemplate1" DataTextField="USERNAME" 
                                                          DataValueField="USER_ID">
                                                          <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                      </asp:DropDownList>
                                                      <asp:ObjectDataSource ID="ObjecDataTemplate1" runat="server" 
                                                          SelectMethod="GetFilterUsers" TypeName="JpmmsClasses.BL.Lookups.SystemUsers">
                                                      </asp:ObjectDataSource>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("USERNAME") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="تاريخ استلام الملف" 
                                                  SortExpression="RECEIVED_STARTDATE">
                                                  <EditItemTemplate>
                                                      <asp:Label ID="Label7" runat="server" 
                                                          Text='<%# Eval("RECEIVED_STARTDATE", "{0:yyyy/MM/dd}") %>'></asp:Label>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label3" runat="server" 
                                                          Text='<%# Eval("RECEIVED_STARTDATE", "{0:yyyy/MM/dd}") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="تاريخ تسليم الملف" 
                                                  SortExpression="RECEIVED_ENDDATE">
                                                  <EditItemTemplate>
                                                      <asp:Label ID="Label8" runat="server" 
                                                          Text='<%# Eval("RECEIVED_ENDDATE", "{0:yyyy/MM/dd}") %>'></asp:Label>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label5" runat="server" 
                                                          Text='<%# Eval("RECEIVED_ENDDATE", "{0:yyyy/MM/dd}") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                       
                                            <asp:CommandField ShowSelectButton="True" SelectText="تسليم" 
                                                  ShowEditButton="True" CancelText="إلغاء" EditText="تعديل" 
                                                  UpdateText="حفظ" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                       
                                    </asp:GridView>
                                    <%--<asp:GridView ID="gvRegionSamples" runat="server" 
                                        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                                        GridLines="None" PageSize="15" AutoGenerateColumns="False" 
                                        AllowSorting="True" onsorting="gvRegionSamples_Sorting">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="FILENAME" HeaderText="رقم الملف" 
                                                SortExpression="FILENAME" />
                                            <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" 
                                                SortExpression="REGION_NO" />
                                            <asp:BoundField DataField="USERNAME" HeaderText="اسم المستخدم" 
                                                SortExpression="USERNAME" />
                                            <asp:BoundField DataField="RECEIVED_STARTDATE" HeaderText="تاريخ استلام الملف" 
                                                SortExpression="RECEIVED_STARTDATE" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:CheckBoxField DataField="SUSPENDED" HeaderText="جاري العمل" 
                                                SortExpression="SUSPENDED" />
                                               
                                            <asp:BoundField DataField="RECEIVED_ENDDATE" DataFormatString="{0:MM/dd/yyyy}" 
                                                HeaderText="تاريخ تسليم الملف" SortExpression="RECEIVED_ENDDATE" />
                                               
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                       
                                    </asp:GridView>--%>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        SelectMethod="GetReceivedFiles" 
                                        TypeName="JpmmsClasses.BL.Lookups.SystemUsers" 
                                        UpdateMethod="UpdateReceivedFiles">
                                        <UpdateParameters>
                                            <asp:Parameter Name="ID_REGION_NO" Type="String"  />
                                            <asp:Parameter Name="RECEIVEDUSERNO" Type="String" />
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
