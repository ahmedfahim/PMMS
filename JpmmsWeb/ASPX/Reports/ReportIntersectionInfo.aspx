<%@ Page Title="تقرير البيانات الوصفية لعناصر شبكة الطرق " Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReportIntersectionInfo.aspx.cs" Inherits="ASPX_Reports_ReportIntersectionInfo" %>

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
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <strong>تقرير البيانات الوصفية لعناصر شبكة الطرق </strong>
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ObjectDataSource ID="odsRegionwise" runat="server" SelectMethod="GetRegionElements"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radRegion" Name="regions" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radSubdist" Name="subdistrict" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radDist" Name="district" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radMunic" Name="munic" PropertyName="Checked" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
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
                <table class="style3">
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radAllSectionsOrderBySectionNo" runat="server" Checked="True"
                                GroupName="report" OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged"
                                Text="جميع المقاطع مرتبة حسب رقم المقطع" AutoPostBack="True" />
                        </td>
                        <td rowspan="7">
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreets" DataTextField="main_title" DataValueField="STREET_ID"
                                Enabled="False">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radAllSectionsOrderByStreet" runat="server" GroupName="report"
                                OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged" Text="جميع المقاطع مرتبة حسب الشارع الرئيسي"
                                AutoPostBack="True" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radSectionsbyStreet" runat="server" GroupName="report" OnCheckedChanged="radSectionsbyStreet_CheckedChanged"
                                Text="جميع مقاطع شارع محدد" AutoPostBack="True" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radAllIntersectionsOrderBySectionNo" runat="server" GroupName="report"
                                Text="جميع التقاطعات مرتبة حسب رقم التقاطع" AutoPostBack="True" OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radAllIntersectionsOrderByStreet" runat="server" GroupName="report"
                                Text="جميع التقاطعات مرتبة حسب الشارع الرئيسي" AutoPostBack="True" OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radMainstIntersects" runat="server" GroupName="report" Text="جميع تقاطعات شارع محدد"
                                AutoPostBack="True" OnCheckedChanged="radSectionsbyStreet_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radSectionsSurroundingRegion" runat="server" GroupName="report"
                                Text="المقاطع المحيطة بمنطقة محددة" AutoPostBack="True" OnCheckedChanged="radSectionsSurroundignRegion_CheckedChanged" />
                            &nbsp;<telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlRegionSurrounding" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegionwise" DataTextField="region_title" DataValueField="region_id"
                                Visible="False">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radAllOrderByRegion" runat="server" GroupName="report" Text="جميع الشوارع الفرعية مرتبة حسب المنطقة"
                                AutoPostBack="True" OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged" />
                        </td>
                        <td rowspan="3">
                            <asp:Panel ID="pnlRegions" runat="server">
                                <table class="style1">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" Checked="True"
                                                GroupName="region" Text="منطقة فرعية محددة" OnCheckedChanged="radRegion_CheckedChanged" />
                                        </td>
                                        <td rowspan="4">
                                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                                ID="ddlRegionWise" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                DataSourceID="odsRegionwise" DataTextField="region_title" DataValueField="region_id">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="radSubdist" runat="server" AutoPostBack="True" GroupName="region"
                                                Text="حي فرعي محدد" OnCheckedChanged="radRegion_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="radDist" runat="server" AutoPostBack="True" GroupName="region"
                                                Text="حي محدد" OnCheckedChanged="radRegion_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="radMunic" runat="server" AutoPostBack="True" GroupName="region"
                                                Text="بلدية فرعية محددة" OnCheckedChanged="radRegion_CheckedChanged" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radAllOrderByDistrict" runat="server" GroupName="report" Text="جميع الشوارع الفرعية مرتبة حسب الحي الفرعي"
                                AutoPostBack="True" OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged"
                                Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="radByRegionDistMunic" runat="server" GroupName="report" Text="جميع الشوارع الفرعية لمنطقة محددة"
                                AutoPostBack="True" OnCheckedChanged="radAllSectionsOrderBySectionNo_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="عرض التقرير" />
                        </td>
                        <td>
                            <asp:Button ID="UpdateCancelButton" runat="server" OnClick="UpdateCancelButton_Click"
                                Text="إلغاء" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
