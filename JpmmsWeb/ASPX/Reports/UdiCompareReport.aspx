<%@ Page Title="تقرير مقارنة حالة رصف عناصر شبكة الطرق عبر المسوحات" Language="C#"
    MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="UdiCompareReport.aspx.cs"
    Inherits="ASPX_Reports_UdiCompareReport" %>

<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                    <strong>تقرير مقارنة حالة رصف عناصر شبكة الطرق عبر المسوحات</strong></h2>
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
                        <td style="margin-right: 80px">
                            <asp:RadioButton ID="radSection" runat="server" AutoPostBack="True" Checked="True"
                                GroupName="type" Text="مقطع" OnCheckedChanged="radSection_CheckedChanged" />
                            &nbsp;
                        </td>
                        <td rowspan="3">
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="True"
                                id="ddlMainStreets" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsMainStreets" datatextfield="MAIN_NAME" datavaluefield="street_id"
                                onselectedindexchanged="ddlMainStreets_SelectedIndexChanged" visible="False">
                                 <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="true"
                                id="ddlRegions" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsRegions" datatextfield="region_title" datavaluefield="region_id"
                                onselectedindexchanged="ddlRegions_SelectedIndexChanged" visible="False">
                                 <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
                            <br />
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
                    </tr>
                    <tr>
                        <td style="margin-right: 80px" colspan="2">
                            <asp:Panel ID="pnlSections" Visible="false" runat="server">
                                <asp:RadioButton ID="radSectionWise" runat="server" Checked="True" GroupName="sections"
                                    Text="على مستوى المقطع" />
                                <br />
                                <asp:RadioButton ID="radLaneWise" runat="server" GroupName="sections" Text="على مستوى المسارات" />
                                <br />
                                <asp:RadioButton ID="radLSampleWise" runat="server" GroupName="sections" Text="على مستوى العينات" />
                            </asp:Panel>
                            <asp:Panel ID="pnlIntersect" Visible="false" runat="server">
                                <asp:RadioButton ID="radIntersectWise" runat="server" Checked="True" GroupName="intersect"
                                    Text="على مستوى التقاطعات" />
                                <br />
                                <asp:RadioButton ID="radISampleWise" runat="server" GroupName="intersect" Text="على مستوى العينات" />
                            </asp:Panel>
                            <asp:Panel ID="pnlRegions" Visible="false" runat="server">
                                <asp:RadioButton ID="radRegionWise" runat="server" Checked="True" GroupName="secSt"
                                    Text="على مستوى المنطقة" />
                                <br />
                                <asp:RadioButton ID="radSecStWise" runat="server" GroupName="secSt" Text="على مستوى الشوارع الفرعية" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px" colspan="2">
                            &nbsp;
                            <table class="style3">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnShowMaintDecUdi" runat="server" OnClick="btnShowMaintDecUdi_Click"
                                            Text="عرض التقرير" />
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
    </table>
</asp:Content>
