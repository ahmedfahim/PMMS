<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesWorkOrders.master" AutoEventWireup="true" CodeFile="CreateWorkOrder.aspx.cs" Inherits="ASPX_Operations_CreateWorkOrder" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchRegion.ascx" TagName="SearchRegion" TagPrefix="uc1" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <h2 class="style2">
                    <b>إنشاء امر عمل </b></h2>
            </td>
            <td rowspan="3">
                &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:ObjectDataSource ID="odsRegionSecondaryStreets" runat="server" SelectMethod="GetSecondaryStreetsInRegion"
                    TypeName="JpmmsClasses.BL.SecondaryStreets">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownddlRegions" Name="regionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownddlMunic" Name="SUBMUNICIP" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownddlsubDisticts" Name="DISTRICTNO" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="OdsDistricts" runat="server" 
                    SelectMethod="GetDistrictFullInfo" 
                    TypeName="JpmmsClasses.BL.Lookups.DistrictSubdistrict">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownddlMunic" Name="MUNIC_ID" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="OdsSubDisticts" runat="server" 
                    SelectMethod="GetSubDistFullInfo" 
                    TypeName="JpmmsClasses.BL.Lookups.DistrictSubdistrict">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownddlDisticts" Name="DIST_ID" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractor" runat="server"
                    SelectMethod="GetAllContractorsList" 
                    TypeName="JpmmsClasses.BL.Lookups.Contractor">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsProjects" runat="server"
                    SelectMethod="GetAllProjectssList" 
                    TypeName="JpmmsClasses.BL.Lookups.Projects">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="OdsProjectNO" runat="server" 
                    SelectMethod="GetProjectssInfo" TypeName="JpmmsClasses.BL.Lookups.Projects">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DrpDwnListProjectName" Name="Projects_No" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <br />
                <asp:Panel runat="server" ID="pnlEntry">
                    <table width="80%">
                        <tr>
                            <td width="20%">
                                <b>رقم&nbsp; امر العمل </b>
                            </td>
                            <td width="50%">
                                <asp:TextBox ID="TxtBoxWorkOrderNO" runat="server" Enabled="False" 
                                    Width="195px"></asp:TextBox>
                            </td>
                            <td width="30%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>اسم المشروع </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpDwnListProjectName" runat="server" 
                                    AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="odsProjects" 
                                    DataTextField="Projects_NAME" DataValueField="Projects_No" 
                                    ValidationGroup="insert" Width="200px">
                                    <asp:ListItem Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>اسم المقاول </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpDwnListProjectName0" runat="server" 
                                    AppendDataBoundItems="True" DataSourceID="odsContractor" 
                                    DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_No" 
                                    ValidationGroup="insert" Width="200px">
                                    <asp:ListItem Selected="True" Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>رقم المشروع </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpDwnListProjectNO" runat="server" 
                                    DataSourceID="OdsProjectNO" DataTextField="PROJECTS_NO" 
                                    DataValueField="PROJECTS_NO" Enabled="False" ValidationGroup="insert" 
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>البلدية </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownddlMunic" runat="server" AutoPostBack="True" 
                                    DataSourceID="odsSubMunicipality" DataTextField="ARNAME" 
                                    DataValueField="MUNIC_ID" Width="200px" AppendDataBoundItems="True" 
                                    ValidationGroup="insert">
                                    <asp:ListItem Selected="True" Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>الأحياء</b></td>
                            <td>
                                <asp:DropDownList ID="DropDownddlDisticts" runat="server" AutoPostBack="True" 
                                    DataSourceID="OdsDistricts" DataTextField="ARNAME" DataValueField="DIST_ID" 
                                    Width="200px" AppendDataBoundItems="True" ValidationGroup="insert">
                                    <asp:ListItem Selected="True" Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>الأحياء الفرعية</b></td>
                            <td>
                                <asp:DropDownList ID="DropDownddlsubDisticts" runat="server" 
                                    AutoPostBack="True" DataSourceID="OdsSubDisticts" DataTextField="ARNAME" 
                                    DataValueField="DISTRICTNO" Width="200px" AppendDataBoundItems="True" 
                                    ValidationGroup="insert">
                                    <asp:ListItem Selected="True" Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>اسم المنطقة</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownddlRegions" runat="server" 
                                    DataSourceID="odsRegions" DataTextField="region_title" 
                                    DataValueField="region_id" Width="200px" AppendDataBoundItems="True" 
                                    AutoPostBack="True" ValidationGroup="insert">
                                    <asp:ListItem Selected="True" Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" 
                                    ControlToValidate="DropDownddlRegions" ErrorMessage="الرجاء اختيار المنطقة" 
                                    Operator="NotEqual" ValidationGroup="insert" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>الشارع الفرعي</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownddlRegionSecondaryStreets" runat="server" 
                                    AppendDataBoundItems="True" DataSourceID="odsRegionSecondaryStreets" 
                                    DataTextField="second_st_title" DataValueField="STREET_ID" 
                                    ValidationGroup="insert" Width="200px">
                                    <asp:ListItem Value="-1">اختر</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator5" runat="server" 
                                    ControlToValidate="DropDownddlRegionSecondaryStreets" 
                                    ErrorMessage="الرجاء اختيار الشارع الفرعي" Operator="NotEqual" 
                                    ValidationGroup="insert" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>تاريخ فتح أمر العمل</b></td>
                            <td>
                                &nbsp;<telerik:RadDatePicker ID="rdtpStartWorkOrder" runat="server" 
                                    Culture="Arabic (Qatar)" Width="200px">
                                    <Calendar ID="Calendar1" runat="server" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>تاريخ اغلاق أمر العمل</b></td>
                            <td>
                                <telerik:RadDatePicker ID="rdtpCloseWorkOrder" runat="server" 
                                    Culture="Arabic (Qatar)" Width="200px">
                                    <Calendar ID="Calendar3" runat="server" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;</td>
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
                            <td>
                                <asp:Button ID="btnSave" runat="server" OnClick="UpdateButton_Click" ValidationGroup="insert"
                                    Text="حفظ" />
                            </td>
                            <td>
                                <asp:Button ID="UpdateCancelButton" runat="server" OnClick="UpdateCancelButton_Click"
                                    Text="عرض الأولويات" />
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
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="direction: rtl">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        </table>
</asp:Content>