<%@ Page Title="مقارنة حالة رصف عناصر شبكة الطرق عبر المسوحات" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="UdiCompare.aspx.cs" Inherits="ASPX_Operations_UdiCompare" %>

<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <%--  <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
            width: 60%;
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
                    <strong>مقارنة حالة رصف عناصر شبكة الطرق عبر المسوحات</strong></h2>
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
                &nbsp;
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                    TypeName="JpmmsClasses.BL.SecondaryStreets">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="GetMainStreetSections"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections0" runat="server" SelectMethod="GetMainStreetIntersections"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="60%">
                    <tr>
                        <td width="30%">
                            &nbsp;شارع
                        </td>
                        <td width="70%">
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="MAIN_NAME" DataValueField="street_id"
                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged" Visible="False">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <asp:RadioButton ID="radSection" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="type" Text="مقطع" OnCheckedChanged="radSection_CheckedChanged" />
                            &nbsp;
                        </td>
                        <td rowspan="2">
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                Visible="False" OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreetIntersection" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreetIntersections0" DataTextField="intersection_title"
                                DataValueField="INTERSECTION_ID" Visible="False" OnSelectedIndexChanged="ddlMainStreetIntersection_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <asp:RadioButton ID="radIntersect" runat="server" AutoPostBack="True" GroupName="type"
                                Text="تقاطع" OnCheckedChanged="radIntersect_CheckedChanged" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" GroupName="type"
                                OnCheckedChanged="radRegion_CheckedChanged" Text="منطقة فرعية" />
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged" Visible="False">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlRegionSecondaryStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" DataValueField="street_id"
                                OnSelectedIndexChanged="ddlRegionSecondaryStreets_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px" colspan="2">
                            &nbsp;
                            <table class="style3">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnShowMaintDecUdi" runat="server" OnClick="btnShowMaintDecUdi_Click"
                                            Text="عرض حالة الرصف " />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancelContract" runat="server" Text="إلغاء" OnClick="btnCancelContract_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblAddFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvUdi" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" SortExpression="SURVEY_NO" />
                        <asp:BoundField DataField="SURVEY_DATE" DataFormatString="{0:d}" HeaderText="تاريخ المسح"
                            SortExpression="SURVEY_DATE" />
                        <asp:BoundField DataField="UDI_DATE" HeaderText="UDI_DATE" SortExpression="UDI_DATE"
                            Visible="False" />
                        <asp:BoundField DataField="UDI_VALUE" HeaderText="قيمة حالة الرصف" SortExpression="UDI_VALUE" />
                        <asp:BoundField DataField="UDI_RATE" HeaderText="تقييم الرصف" SortExpression="UDI_RATE" />
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
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
