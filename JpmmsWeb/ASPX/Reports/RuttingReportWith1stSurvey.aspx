<%@ Page Title="تقرير مستوى تخدد الطرق الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="RuttingReportWith1stSurvey.aspx.cs" Inherits="ASPX_Reports_RuttingReportWith1stSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            width: 150px;
            height: 16px;
        }
        .style4
        {
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <strong>تقرير مستوى تخدد الطرق الرئيسية</strong></h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="LoadMainStreetsHavingCalculatedRutting"
                    TypeName="JpmmsClasses.BL.MainStreet">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radByIntersects" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByMainLanes" runat="server" Checked="True" GroupName="report"
                        Text="مسارات شارع محدد" AutoPostBack="True" OnCheckedChanged="radByMainLanes_CheckedChanged" />
                </b>
            </td>
            <td>
                <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                    AutoPostBack="True" DataSourceID="odsMainStreets" 
                    DataTextField="main_title" DataValueField="main_no"
                    OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByIntersects" runat="server" GroupName="report" Text="تقاطعات شارع محدد"
                        AutoPostBack="True" OnCheckedChanged="radByIntersects_CheckedChanged" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByAllLanes" runat="server" GroupName="report" Text="مسارات كل الطرق الرئيسية"
                        AutoPostBack="True" OnCheckedChanged="radByAllLanes_CheckedChanged" />
                </b>
            </td>
            <td>
                &nbsp;
                </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>
                    <asp:RadioButton ID="radByAllinters122" runat="server" GroupName="report" Text="تقاطعات كل الطرق الرئيسية"
                        AutoPostBack="True" OnCheckedChanged="radByAllLanes_CheckedChanged" />
                </b>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                <b>رقم المسح </b>
            </td>
            <td style="text-align: right">
                <asp:RadioButtonList ID="radlOldSurveys" runat="server" DataSourceID="odsRuttingSurveys"
                    DataTextField="survey_title" DataValueField="survey_no" Height="27px" 
                    >
                </asp:RadioButtonList>
                <asp:ObjectDataSource ID="odsRuttingSurveys" runat="server" SelectMethod="GetMainStreetIriSurveys"
                    TypeName="JpmmsClasses.BL.RuttingReport">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainNo" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="radByAllLanes" Name="allRoads" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByIntersects" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radByAllinters122" DefaultValue="true" 
                            Name="allintersect" PropertyName="Checked" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
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
</asp:Content>
