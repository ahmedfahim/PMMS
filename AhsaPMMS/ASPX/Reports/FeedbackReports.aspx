<%@ Page Title="تقرير عمليات صيانة عناصر شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="FeedbackReports.aspx.cs" Inherits="ASPX_Reports_FeedbackReports" %>

<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
            width: 30%;
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
                <h2 style="text-align: center">
                    تقرير عمليات صيانة عناصر شبكة الطرق</h2>
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
                <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="GetMainStreetSectionsNonR4R3"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSamples" runat="server" SelectMethod="GetMainStreetSamples"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radIntersect" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="interID" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsAllMaintDecisions" runat="server" SelectMethod="GetAllDecisionsNonDoNothing"
                    TypeName="JpmmsClasses.BL.Lookups.MaintDecision"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections0" runat="server" SelectMethod="GetMainStreetIntersections"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" class="style3" src="../../Images/loading2.gif" />
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
                <table width="60%">
                    <tr>
                        <td width="30%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <b>
                                <asp:RadioButton ID="radSection" runat="server" AutoPostBack="True" Checked="True"
                                    GroupName="type" Text="مقطع" OnCheckedChanged="radSection_CheckedChanged" />
                                &nbsp; </b>
                        </td>
                        <td rowspan="2">
                            <asp:Panel runat="server" Visible="false" ID="pnlMainSt">
                                شارع
                                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" ID="ddlMainStreets"
                                    runat="server" AppendDataBoundItems="True" AutoPostBack="True" AutoselectFirstItem="True"
                                    DataSourceID="odsMainStreets" DataTextField="MAIN_NAME" DataValueField="STREET_ID"
                                    OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                    </Items>
                                </telerik:RadComboBox>
                                <br />
                                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" ID="ddlMainStreetSection"
                                    runat="server" AppendDataBoundItems="True" AutoPostBack="True" AutoselectFirstItem="true"
                                    DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                    OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                    </Items>
                                </telerik:RadComboBox>
                                <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" ID="ddlMainStreetIntersection"
                                    runat="server" AppendDataBoundItems="True" AutoPostBack="True" AutoselectFirstItem="true"
                                    DataSourceID="odsMainStreetIntersections0" DataTextField="intersection_title"
                                    DataValueField="INTERSECTION_ID" OnSelectedIndexChanged="ddlMainStreetIntersection_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                    </Items>
                                </telerik:RadComboBox>
                                <br />
                                العينة
                                <asp:DropDownList ID="ddlSamples" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="odsSamples" DataTextField="sample_title" DataValueField="sample_id">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <b>
                                <asp:RadioButton ID="radIntersect" runat="server" AutoPostBack="True" GroupName="type"
                                    Text="تقاطع" OnCheckedChanged="radIntersect_CheckedChanged" />&nbsp; </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <b>
                                <asp:RadioButton ID="radRegion" runat="server" AutoPostBack="True" GroupName="type"
                                    OnCheckedChanged="radRegion_CheckedChanged" Text="منطقة" />
                            </b>
                        </td>
                        <td>
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlRegionSecondaryStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" DataValueField="STREET_ID">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px" class="ui-priority-primary">
                            <b>قرار الصيانة </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMaintDecisions" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsAllMaintDecisions" DataTextField="RECOMMENDED_DECISION_AR"
                                DataValueField="RECOMMENDED_DECISION_ID">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <strong>تنفيذ المقاول</strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlContractors" Width="100px" runat="server" DataSourceID="odsContractors"
                                DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_ID" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            <b>تاريخ تنفيذ الصيانة بين التاريخين </b>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="rdtpFinishDate" runat="server">
                            </telerik:RadDatePicker>
                            &nbsp;و
                            <telerik:RadDatePicker ID="rdtpFinishDateTo" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px" colspan="2">
                            <table class="style2">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="عرض التقرير" />
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
            <<td colspan="3">
                <asp:Label ID="lblAddFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
