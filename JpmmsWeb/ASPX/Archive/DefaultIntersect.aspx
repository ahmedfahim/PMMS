<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultIntersect.aspx.cs" Inherits="ASPX_Archive_DefaultIntersect" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="../../ASCX/SearchIntersect.ascx" TagName="SearchIntersect" TagPrefix="uc2" %>
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
            vertical-align: baseline;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
        }
        
        .RadInput_Default
        {
            vertical-align: middle;
            font: 12px "segoe ui" ,arial,sans-serif;
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
                    <strong>استلام تقاطعات الطرق الرئيسية</strong></h2>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor" runat="server">
                    <table align="center" width="65%">
                        <tr>
                            <td width="20%">
                                &nbsp;
                            </td>
                            <td width="80%">
                                &nbsp;
                                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td rowspan="14">
                                <uc2:SearchIntersect ID="SearchIntersect1" runat="server" 
                                    OnSetSearchChanged="onIntersectSearchChanged" Visible="False" />
                                <asp:FormView ID="frvIntersectInfo" runat="server" 
                                    DataSourceID="odsIntersectionInfo">
                                    <EditItemTemplate>
                                        INTER_NO:
                                        <asp:TextBox ID="INTER_NOTextBox" runat="server" 
                                            Text='<%# Bind("INTER_NO") %>' />
                                        <br />
                                        INTEREC_STREET1:
                                        <asp:TextBox ID="INTEREC_STREET1TextBox" runat="server" 
                                            Text='<%# Bind("INTEREC_STREET1") %>' />
                                        <br />
                                        INTEREC_STREET2:
                                        <asp:TextBox ID="INTEREC_STREET2TextBox" runat="server" 
                                            Text='<%# Bind("INTEREC_STREET2") %>' />
                                        <br />
                                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                                            CommandName="Update" Text="Update" />
                                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        INTER_NO:
                                        <asp:TextBox ID="INTER_NOTextBox0" runat="server" 
                                            Text='<%# Bind("INTER_NO") %>' />
                                        <br />
                                        INTEREC_STREET1:
                                        <asp:TextBox ID="INTEREC_STREET1TextBox0" runat="server" 
                                            Text='<%# Bind("INTEREC_STREET1") %>' />
                                        <br />
                                        INTEREC_STREET2:
                                        <asp:TextBox ID="INTEREC_STREET2TextBox0" runat="server" 
                                            Text='<%# Bind("INTEREC_STREET2") %>' />
                                        <br />
                                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                                            CommandName="Insert" Text="Insert" />
                                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    <b>
                                                    <asp:Label ID="Label7" runat="server" Text="رقم التقاطع"></asp:Label>
                                                    </b>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="INTER_NOLabel" runat="server" Text='<%# Bind("INTER_NO") %>' />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <b></b>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>
                                                    <asp:Label ID="Label8" runat="server" Text="شارع رئيسي"></asp:Label>
                                                    </strong>
                                                </td>
                                                <td>
                                                    <asp:Label ID="INTEREC_STREET1Label" runat="server" 
                                                        Text='<%# Bind("INTEREC_STREET1") %>' />
                                                </td>
                                                <td>
                                                    <strong>
                                                    <asp:Label ID="Label9" runat="server" Text="مع شارع"></asp:Label>
                                                    </strong>
                                                </td>
                                                <td>
                                                    <asp:Label ID="INTEREC_STREET2Label" runat="server" 
                                                        Text='<%# Bind("INTEREC_STREET2") %>' />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </ItemTemplate>
                                </asp:FormView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                الشارع
                            </td>
                            <td>
                            <telerik:RadComboBox ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                    AutoPostBack="True" AutoselectFirstItem="True"
                                    DataTextField="main_title" DataValueField="STREET_ID" Filter="Contains" 
                                    Font-Size="Medium" Width="200px" Enabled="False">
                                </telerik:RadComboBox>
                      
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                التقاطع
                            </td>
                            <td>
                            <asp:DropDownList ID="ddlMainStreetIntersection" runat="server" 
                                    AppendDataBoundItems="True"  DataTextField="intersection_title"
                                    DataValueField="INTERSECTION_ID" Enabled="False">
                                </asp:DropDownList>
                               
                                <asp:LinkButton ID="lbtnSearchIntersect" runat="server" 
                                    OnClick="lbtnSearchIntersect_Click" 
                                    ToolTip="بحث متقدم بجزء من اسم أو رقم التقاطع">بحث متقدم </asp:LinkButton>
                            </td>
                            <td>
                                &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                المساح
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSurveyor" runat="server" AppendDataBoundItems="True" DataSourceID="odsSurveyors"
                                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSurveyor_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                المدخل
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDataEntry" runat="server" AppendDataBoundItems="True" DataSourceID="odsDataEntry"
                                    DataTextField="USERNAME" DataValueField="USER_ID">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                شهر التقرير
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlReportMonth" runat="server" AppendDataBoundItems="True"
                                    DataSourceID="odsReportMonth" DataTextField="REPORTMONTH_TITLE" DataValueField="REPORTMONTH_ID">
                                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                تاريخ الاستلام
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="raddtpIssueDate" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                تاريخ التسليم
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="raddtpDeliveryDate" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                رقم المسح
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="rntxtSurveyNo" runat="server" CssClass="style5" MinValue="0"
                                    Value="3">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                سنة المسح
                            </td>
                            <td>
                                <asp:DropDownList ID="DrpDwnYear" runat="server">
                                    <asp:ListItem Value="1" Enabled="False">السنة الأولي</asp:ListItem>
                                    <asp:ListItem Value="2" Enabled="False">السنة الثانية</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">السنة الثالثة</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                مساحة التقاطع
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="RadNumericRegionSum" runat="server" CssClass="style5"
                                    MinValue="0">
                                    <NumberFormat DecimalDigits="2" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                ملاحظات
                            </td>
                            <td>
                                <asp:TextBox ID="txtNotes" runat="server" CssClass="style5" Height="24px" TextMode="MultiLine"
                                    Width="50%"></asp:TextBox>
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
                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="إلغاء" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblFeedbackSave" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvSurveyorJob" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="style5" DataKeyNames="RECORD_ID" DataSourceID="odsSurveySubmitJobs"
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" SortExpression="RECORD_ID"
                                            Visible="False" />
                              
                                        <asp:TemplateField HeaderText="اسم المساح" SortExpression="SURVEYOR_NAME">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlSurveyor0" runat="server" AppendDataBoundItems="True" DataSourceID="odsSurveyors"
                                                    DataTextField="SURVEYOR_NAME" DataValueField="SURVEYOR_NO" 
                                                    SelectedValue='<%# Bind("SURVEYOR_ID") %>'>
                                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("SURVEYOR_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رقم المسح" SortExpression="SURVEY_NO">
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="rntxtSurveyNo1" runat="server" DbValue='<%# Bind("SURVEY_NO") %>'
                                                    MinValue="0" Width="60px">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("SURVEY_NO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ الاستلام" SortExpression="ISSUE_DATE">
                                            <EditItemTemplate>
                                                <telerik:RadDatePicker ID="raddtpIssueDate1" runat="server" Culture="ar-QA" DbSelectedDate='<%# Bind("ISSUE_DATE", "{0:d}") %>'
                                                    Width="150px">
                                                </telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" 
                                                    Text='<%# Bind("ISSUE_DATE", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ التسليم" SortExpression="RECEIVE_DATE">
                                            <EditItemTemplate>
                                                <telerik:RadDatePicker ID="raddtpDeliveryDate0" runat="server" Culture="ar-QA" 
                                                    DbSelectedDate='<%# Bind("RECEIVE_DATE", "{0:d}") %>'>
                                                </telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" 
                                                    Text='<%# Bind("RECEIVE_DATE", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ملاحظات" SortExpression="NOTES">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("NOTES") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("NOTES") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:ObjectDataSource ID="odsIntersectionInfo" runat="server" 
                        SelectMethod="GetIntersection" TypeName="JpmmsClasses.BL.Intersection">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlMainStreetIntersection" 
                                Name="intersectionID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSurveySubmitJobs" runat="server" 
                        DeleteMethod="Delete" OnDeleted="odsSurveySubmitJobs_Deleted" 
                        OnUpdated="odsSurveySubmitJobs_Updated" 
                        SelectMethod="GetIntersectionSurveyingWork" 
                        TypeName="JpmmsClasses.BL.SurveyorSubmitJob" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="id" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="RECORD_ID" Type="Int32" />
                            <asp:Parameter Name="SURVEYOR_ID" Type="Int32" />
                            <asp:Parameter Name="ISSUE_DATE" Type="String" />
                            <asp:Parameter Name="RECEIVE_DATE" Type="String" />
                            <asp:Parameter Name="SURVEY_NO" Type="String" />
                            <asp:Parameter Name="notes" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSurveyors" runat="server" 
                        SelectMethod="GetSurveyorsInterSections" TypeName="JpmmsClasses.BL.Surveyor">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsDataEntry" runat="server" SelectMethod="GetFilterIntersectionsUsers"
                        TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>
              
                    <asp:ObjectDataSource ID="odsReportMonth" runat="server" SelectMethod="GetMonthsTitle"
                        TypeName="JpmmsClasses.BL.Lookups.SystemUsers"></asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
