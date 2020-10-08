<%@ Page Title="حالة رصف عناصر شبكة الطرق وقرارات الصيانة - البلاغات" Language="C#"
    MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="MaintDecUdi.aspx.cs"
    Inherits="ASPX_Operations_MaintDecUdi" %>

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
                    <strong>حالة رصف عناصر شبكة الطرق وقرارات الصيانة - البلاغات</strong></h2>
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
                            <telerik:RadComboBox Filter="Contains" Width="500px" Font-Size="Medium" AutoselectFirstItem="true"
                                ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsMainStreetSections" DataTextField="section_from_to" DataValueField="section_id"
                                Visible="False" OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>
                            <telerik:RadComboBox Filter="Contains" Width="400px" Font-Size="Medium" AutoselectFirstItem="true"
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
                                DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" DataValueField="street_id">
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
                                            Text="عرض حالة الرصف وقرارات الصيانة" />
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
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblAddFeedback" runat="server" ForeColor="Red"></asp:Label>
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
                <h3>
                    حالة الرصف وقرارات الصيانة</h3>
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
                <asp:GridView ID="gvMaintDecUdi" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None" EmptyDataText="لاتوجد سجلات لحالة الرصف وقرارات الصيانة">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="رقم المسح" />
                        <asp:BoundField DataField="SURVEY_DATE" DataFormatString="{0:d}" HeaderText="تاريخ المسح" />
                        <asp:BoundField DataField="UDI" DataFormatString="{0:N0}" HeaderText="قيمة حالة الرصف" />
                        <asp:BoundField DataField="UDI_RATE" HeaderText="حالة الرصف" />
                        <asp:BoundField DataField="RECOMMENDED_DECISION" HeaderText="قرار الصيانة" />
                        <asp:BoundField DataField="MAINT_AREA" DataFormatString="{0:N2}" HeaderText="مساحة الصيانة" />
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
            <td>
                &nbsp;
            </td>
            <td>
                <h3>
                    أوامر الصيانة الصادرة</h3>
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
                <asp:GridView ID="gvMaintOrders" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None" EmptyDataText="لاتوجد بيانات للعرض">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CONTRACT_NO" HeaderText="رقم العقد" SortExpression="CONTRACT_NO" />
                        <asp:BoundField DataField="CONTRACT_NAME" HeaderText="اسم العقد" SortExpression="CONTRACT_NAME" />
                        <asp:BoundField DataField="CONTRACTOR_NAME" HeaderText="المقاول" SortExpression="CONTRACTOR_NAME" />
                        <asp:BoundField DataField="CONTRACT_DATE" DataFormatString="{0:d}" HeaderText="تاريخ العقد"
                            SortExpression="CONTRACT_DATE" />
                        <asp:BoundField DataField="CONTRACT_BEGIN" DataFormatString="{0:d}" HeaderText="تاريخ البدء"
                            SortExpression="CONTRACT_BEGIN" />
                        <asp:BoundField DataField="CONTRACT_END" DataFormatString="{0:d}" HeaderText="نهاية العقد"
                            SortExpression="CONTRACT_END" />
                        <asp:BoundField DataField="STATUS" HeaderText="حالة العقد" />
                        <asp:BoundField DataField="DETAILS" HeaderText="تفاصيل" SortExpression="DETAILS" />
                        <asp:BoundField DataField="MAINTAIN_ORDER_ID" HeaderText="MAINTAIN_ORDER_ID" SortExpression="MAINTAIN_ORDER_ID"
                            Visible="False" />
                        <asp:BoundField DataField="MAINTAIN_ORDER_DET_ID" HeaderText="MAINTAIN_ORDER_DET_ID"
                            SortExpression="MAINTAIN_ORDER_DET_ID" Visible="False" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsMaintOrders" runat="server" SelectMethod="GetMaintenanceOrdersByLocation"
                    TypeName="JpmmsClasses.BL.MaintenanceOrders">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radSection" Name="section" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radIntersect" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radRegion" Name="region" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="intersectID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlRegionSecondaryStreets" Name="secStreetID" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
                <h3>
                    عمليات صيانة عناصر شبكة الطرق</h3>
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
                <asp:GridView ID="gvFeedbacks" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                    CellPadding="4" EmptyDataText="لاتوجد بيانات للعرض" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CONTRACT_NO" HeaderText="رقم العقد" SortExpression="CONTRACT_NO" />
                        <asp:BoundField DataField="JOB_ORDER_NO" HeaderText="رقم أمر العمل" SortExpression="JOB_ORDER_NO" />
                        <asp:BoundField DataField="JOB_ORDER_DATE" DataFormatString="{0:d}" HeaderText="تاريخ أمر العمل"
                            SortExpression="JOB_ORDER_DATE" />
                        <asp:BoundField DataField="FINISH_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الانتهاء"
                            SortExpression="FINISH_DATE" />
                        <asp:BoundField DataField="CONTRACTOR_NAME" HeaderText="المقاول" SortExpression="CONTRACTOR_NAME" />
                        <asp:BoundField DataField="RECOMMENDED_DECISION" HeaderText="قرار الصيانة" SortExpression="RECOMMENDED_DECISION" />
                        <asp:BoundField DataField="MAINT_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الصيانة"
                            SortExpression="MAINT_DATE" />
                        <asp:BoundField DataField="UDI_BEFORE" HeaderText="حالة الرصف قبل" SortExpression="UDI_BEFORE" />
                        <asp:BoundField DataField="UDI_AFTER" HeaderText="حالة الرصف بعد" SortExpression="UDI_AFTER" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsMaintFeedbacks" runat="server" SelectMethod="Search"
                    TypeName="JpmmsClasses.BL.MaintenanceFeedback">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radSection" Name="section" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="radIntersect" Name="intersect" PropertyName="Checked"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlRegions" Name="region" PropertyName="SelectedValue"
                            Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainSt" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlMainStreetIntersection" Name="interID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:Parameter DefaultValue="0" Name="sampleID" Type="String" />
                        <asp:ControlParameter ControlID="ddlRegions" DefaultValue="" Name="regionID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="ddlRegionSecondaryStreets" Name="secondID" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
