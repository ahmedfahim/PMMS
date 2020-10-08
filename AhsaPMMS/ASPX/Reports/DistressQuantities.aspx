<%@ Page Title="كميات العيوب على عناصر شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DistressQuantities.aspx.cs" Inherits="ASPX_Reports_DistressQuantities" %>

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
            font-weight: bold;
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
                    <b>كميات العيوب على عناصر شبكة الطرق</b></h2>
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
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetDistrictsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubdistricts" runat="server" SelectMethod="GetSubdistrictsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetRegionsHavingCalculatedUdi"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistresses"
                    TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td width="30%">
                            <b>كميات العيب </b>
                            <asp:DropDownList ID="ddlDistresses" runat="server" AppendDataBoundItems="True" DataSourceID="odsDistresses"
                                DataTextField="distress_title" DataValueField="dist_code" AutoPostBack="True"
                                CssClass="style3">
                                <asp:ListItem Selected="True" Value="0">كل العيوب</asp:ListItem>
                                <asp:ListItem Value="-1">الترقيعات وعيوبها</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="5%">
                            &nbsp;<b>في</b>
                        </td>
                        <td>
                            <b>
                                <asp:RadioButton ID="radSections" runat="server" AutoPostBack="True" Checked="True"
                                    Text="مقاطع طرق رئيسية" GroupName="type" OnCheckedChanged="radSections_CheckedChanged" />
                            </b>
                        </td>
                        <td rowspan="2">
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="True"
                                id="ddlMainStreets" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsMainStreets" datatextfield="main_title" datavaluefield="STREET_ID">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
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
                            <b>
                                <asp:RadioButton ID="radIntersects" runat="server" AutoPostBack="True" Text="تقاطعات طرق رئيسية"
                                    GroupName="type" OnCheckedChanged="radIntersects_CheckedChanged" />
                            </b>
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
                            <b>
                                <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" Text="منطقة فرعية"
                                    GroupName="type" OnCheckedChanged="radRegion_CheckedChanged" />
                            </b>
                        </td>
                        <td>
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="true"
                                id="ddlRegions" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsRegions" datatextfield="region_title" datavaluefield="region_id">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
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
                            <b>
                                <asp:RadioButton ID="radSubdist" runat="server" AutoPostBack="True" Text="حي فرعي"
                                    GroupName="type" OnCheckedChanged="radSubdist_CheckedChanged" />
                            </b>
                        </td>
                        <td>
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="true"
                                id="ddlSubDist" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsSubdistricts" datatextfield="SUBdistRICT" datavaluefield="SUBdistRICT">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
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
                            <b>
                                <asp:RadioButton ID="radDist" runat="server" AutoPostBack="True" Text="حي" GroupName="type"
                                    OnCheckedChanged="radDist_CheckedChanged" />
                            </b>
                        </td>
                        <td>
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="true"
                                id="ddlDistrict" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsDistricts" datatextfield="dist_name" datavaluefield="dist_name">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
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
                            <b>
                                <asp:RadioButton ID="radMunic" runat="server" AutoPostBack="True" Text="بلدية فرعية"
                                    GroupName="type" OnCheckedChanged="radMunic_CheckedChanged" />
                            </b>
                        </td>
                        <td rowspan="2">
                            <telerik:radcombobox filter="Contains" width="200px" font-size="Medium" autoselectfirstitem="True"
                                id="ddlMunic" runat="server" appenddatabounditems="True" autopostback="True"
                                datasourceid="odsSubMunicipality" datatextfield="munic_name" datavaluefield="MUNIC_NO">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:radcombobox>
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
                            <b>
                                <asp:RadioButton ID="radMunicSections" runat="server" AutoPostBack="True" Text="مقاطع طرق رئيسية ضمن بلدية فرعية"
                                    GroupName="type" OnCheckedChanged="radMunicSections_CheckedChanged" />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                        </td>
                        <td>
                            &nbsp;
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
