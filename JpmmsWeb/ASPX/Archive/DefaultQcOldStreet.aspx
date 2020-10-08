<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultQcOldStreet.aspx.cs" Inherits="ASPX_Archive_DefaultQcOldStreet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchRegion.ascx" TagName="SearchRegion" TagPrefix="uc1" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            text-align: right;
        }
        .bold
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    <strong>مساحة الشوارع للطرق الفرعية</strong></h2>
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
                <table align="center" class="style3">
                    <tr>
                        <td>
                            <b>المنطقة الفرعية </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:ObjectDataSource ID="odsRegionInfo" runat="server" SelectMethod="GetRegionInfo"
                                TypeName="JpmmsClasses.BL.Region">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                                TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                        </td>
                        <td rowspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FormView ID="frvRegionInfo" runat="server" DataSourceID="odsRegionInfo" Width="80%">
                                <EditItemTemplate>
                                    REGION_NO:
                                    <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                    <br />
                                    ARNAME:
                                    <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                                    <br />
                                    MUNIC_NAME:
                                    <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                    <br />
                                    REGION_NAME:
                                    <asp:TextBox ID="REGION_NAMETextBox" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                    <br />
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Update" />
                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    REGION_NO:
                                    <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                    <br />
                                    ARNAME:
                                    <asp:TextBox ID="ARNAMETextBox" runat="server" Text='<%# Bind("ARNAME") %>' />
                                    <br />
                                    MUNIC_NAME:
                                    <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                    <br />
                                    REGION_NAME:
                                    <asp:TextBox ID="REGION_NAMETextBox" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                    <br />
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        Text="Insert" />
                                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel" />
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <b>رقم المنطقة </b>
                                            </td>
                                            <td>
                                                <b>اسم المنطقة</b>
                                            </td>
                                            <td>
                                                <b>البلدية الفرعية </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="REGION_NOLabel" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="REGION_NAMELabel" runat="server" Text='<%# Bind("REGION_NAME") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="MUNIC_NAMELabel" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:FormView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbtnPagingNO" runat="server" OnClick="lbtnPagingNO_Click">صفحات</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtnPagingYes" runat="server" OnClick="lbtnPagingYes_Click">الكل</asp:LinkButton>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">إلغاء</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <h2>
                    <strong>المسح الحالي</strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvRegionSamples" runat="server" DataSourceID="odsRegionSamples"
                    AutoGenerateColumns="False" DataKeyNames="STREET_ID" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AllowPaging="True" EnableModelValidation="True" PageSize="15"
                    OnPageIndexChanged="gvRegionSamples_PageIndexChanged" OnSelectedIndexChanging="gvRegionSamples_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="الرقم" SortExpression="SECOND_ST_NO"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SECOND_AR_NAME" HeaderText="اسم الشارع الفرعي" SortExpression="SECOND_AR_NAME" />
                        <asp:TemplateField HeaderText="الطول" SortExpression="SECOND_ST_LENGTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtLengthSecST" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_LENGTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SECOND_ST_LENGTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العرض" SortExpression="SECOND_ST_WIDTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtWidthSecST" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_WIDTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SECOND_ST_WIDTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" SortExpression="AREA"
                            ReadOnly="True" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRegionSamples" runat="server" SelectMethod="GetRegionSamples"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <h2>
                    <strong>المسح رقم&nbsp; 3</strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvRegionSamplesSurveyThree" runat="server" 
                    DataSourceID="odsRegionSamplesSurveyThree" AutoGenerateColumns="False"
                    DataKeyNames="STREET_ID" CellPadding="4" ForeColor="#333333" GridLines="None"
                    AllowPaging="True" EnableModelValidation="True" PageSize="15" OnPageIndexChanged="gvRegionSamples_PageIndexChanged"
                    OnSelectedIndexChanging="gvRegionSamples_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="الرقم" SortExpression="SECOND_ST_NO"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SECOND_AR_NAME" HeaderText="اسم الشارع الفرعي" SortExpression="SECOND_AR_NAME" />
                        <asp:TemplateField HeaderText="الطول" SortExpression="SECOND_ST_LENGTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtLengthSecST" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_LENGTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SECOND_ST_LENGTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العرض" SortExpression="SECOND_ST_WIDTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtWidthSecST" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_WIDTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SECOND_ST_WIDTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" SortExpression="AREA"
                            ReadOnly="True" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRegionSamplesSurveyThree" runat="server" SelectMethod="GetRegionSamplesSurveyThree"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <h2>
                    <strong>المسح رقم&nbsp; 1 - 2</strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvRegionSamplesOLD" runat="server" DataSourceID="odsRegionSamplesOLD"
                    AutoGenerateColumns="False" DataKeyNames="STREET_ID" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AllowPaging="True" EnableModelValidation="True" PageSize="15"
                    OnPageIndexChanged="gvRegionSamples_PageIndexChanged" OnSelectedIndexChanging="gvRegionSamples_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SECOND_ST_NO" HeaderText="الرقم" SortExpression="SECOND_ST_NO"
                            ReadOnly="True" />
                        <asp:BoundField DataField="SECOND_AR_NAME" HeaderText="اسم الشارع الفرعي" SortExpression="SECOND_AR_NAME" />
                        <asp:TemplateField HeaderText="الطول" SortExpression="SECOND_ST_LENGTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtLengthSecST0" runat="server" Culture="ar-QA"
                                    DataType="System.Double" DbValue='<%# Bind("SECOND_ST_LENGTH") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SECOND_ST_LENGTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العرض" SortExpression="SECOND_ST_WIDTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="rntxtWidthSecST0" runat="server" Culture="ar-QA" DataType="System.Double"
                                    DbValue='<%# Bind("SECOND_ST_WIDTH") %>' MinValue="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("SECOND_ST_WIDTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" SortExpression="AREA"
                            ReadOnly="True" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsRegionSamplesOLD" runat="server" SelectMethod="GetRegionSamplesOLD"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
