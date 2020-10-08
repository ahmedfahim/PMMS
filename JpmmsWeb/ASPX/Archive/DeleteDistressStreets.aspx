<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DeleteDistressStreets.aspx.cs" Inherits="ASPX_Archive_DeleteDistressStreets" %>
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
            text-align: right;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 70%;
        }
        .style6
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
                    حذف عيوب المعده من&nbsp; الشارع الرئيسي
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:SiteMapPath ID="SiteMapPath2" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            الشارع الرئيسي
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsRegions" DataTextField="arname" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetStreetsDistress"
                                TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                            &nbsp;
                        </td>
                        <td rowspan="5">
                            &nbsp;
                        </td>
                        <td rowspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            المقاطع
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlMainStreetSection_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="BtnEND" runat="server" ForeColor="Red" OnClick="BtnEND_Click" Text="حذف جميع المقاطع من العيوب " />
                            <asp:Button ID="BtnYes" runat="server" OnClick="BtnYes_Click" Text="نعم"
                                Visible="False" />
                            <asp:Button ID="BtnNO" runat="server" OnClick="BtnNO_Click" Text="لا" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:FormView ID="frvSectionInfo" runat="server" DataSourceID="odsSectionInfo" Width="45%">
                    <EditItemTemplate>
                        SECTION_NO:
                        <asp:TextBox ID="SECTION_NOTextBox" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                        <br />
                        SEC_DIRECTION:
                        <asp:TextBox ID="SEC_DIRECTIONTextBox" runat="server" Text='<%# Bind("SEC_DIRECTION") %>' />
                        <br />
                        SEC_ORDER:
                        <asp:TextBox ID="SEC_ORDERTextBox" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                        <br />
                        SEC_LENGTH:
                        <asp:TextBox ID="SEC_LENGTHTextBox" runat="server" Text='<%# Bind("SEC_LENGTH") %>' />
                        <br />
                        SEC_WIDTH:
                        <asp:TextBox ID="SEC_WIDTHTextBox" runat="server" Text='<%# Bind("SEC_WIDTH") %>' />
                        <br />
                        FROM_STREET:
                        <asp:TextBox ID="FROM_STREETTextBox" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                        <br />
                        TO_STREET:
                        <asp:TextBox ID="TO_STREETTextBox" runat="server" Text='<%# Bind("TO_STREET") %>' />
                        <br />
                        DISTRICT:
                        <asp:TextBox ID="DISTRICTTextBox" runat="server" Text='<%# Bind("DISTRICT") %>' />
                        <br />
                        MUNICIPALITY:
                        <asp:TextBox ID="MUNICIPALITYTextBox" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                        <br />
                        MAIN_NO:
                        <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                        <br />
                        SUBDIST_ID:
                        <asp:TextBox ID="SUBDIST_IDTextBox" runat="server" Text='<%# Bind("SUBDIST_ID") %>' />
                        <br />
                        MAIN_ST_TITLE:
                        <asp:TextBox ID="MAIN_ST_TITLETextBox" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        SECTION_NO:
                        <asp:TextBox ID="SECTION_NOTextBox" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                        <br />
                        SEC_DIRECTION:
                        <asp:TextBox ID="SEC_DIRECTIONTextBox" runat="server" Text='<%# Bind("SEC_DIRECTION") %>' />
                        <br />
                        SEC_ORDER:
                        <asp:TextBox ID="SEC_ORDERTextBox" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                        <br />
                        SEC_LENGTH:
                        <asp:TextBox ID="SEC_LENGTHTextBox" runat="server" Text='<%# Bind("SEC_LENGTH") %>' />
                        <br />
                        SEC_WIDTH:
                        <asp:TextBox ID="SEC_WIDTHTextBox" runat="server" Text='<%# Bind("SEC_WIDTH") %>' />
                        <br />
                        FROM_STREET:
                        <asp:TextBox ID="FROM_STREETTextBox" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                        <br />
                        TO_STREET:
                        <asp:TextBox ID="TO_STREETTextBox" runat="server" Text='<%# Bind("TO_STREET") %>' />
                        <br />
                        DISTRICT:
                        <asp:TextBox ID="DISTRICTTextBox" runat="server" Text='<%# Bind("DISTRICT") %>' />
                        <br />
                        MUNICIPALITY:
                        <asp:TextBox ID="MUNICIPALITYTextBox" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                        <br />
                        MAIN_NO:
                        <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                        <br />
                        SUBDIST_ID:
                        <asp:TextBox ID="SUBDIST_IDTextBox" runat="server" Text='<%# Bind("SUBDIST_ID") %>' />
                        <br />
                        MAIN_ST_TITLE:
                        <asp:TextBox ID="MAIN_ST_TITLETextBox" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
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
                                    <b>البلدية</b>
                                </td>
                                <td>
                                    <asp:Label ID="MUNICIPALITYLabel" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                                </td>
                                <td>
                                    <b>الحي</b>
                                </td>
                                <td>
                                    <asp:Label ID="DISTRICTLabel" runat="server" Text='<%# Bind("DISTRICT") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>رقم المقطع</b>
                                </td>
                                <td>
                                    <asp:Label ID="SECTION_NOLabel" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                                </td>
                                <td>
                                    <b></b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>الشارع الرئيسي</b>
                                </td>
                                <td>
                                    <asp:Label ID="MAIN_ST_TITLELabel" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
                                </td>
                                <td>
                                    <b>الاتجاه</b>
                                </td>
                                <td>
                                    <asp:Label ID="SEC_DIRECTIONLabel" runat="server" Text='<%# Bind("DIRECTION_name") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>من</b>
                                </td>
                                <td>
                                    <asp:Label ID="FROM_STREETLabel" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                                </td>
                                <td class="style6">
                                    <b>إلى </b>
                                </td>
                                <td>
                                    <asp:Label ID="TO_STREETLabel" runat="server" Text='<%# Bind("TO_STREET") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>رقم تسلسل<br />
                                        المقطع</b>
                                </td>
                                <td>
                                    <asp:Label ID="SEC_ORDERLabel" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                                </td>
                                <td>
                                    <b>&nbsp; الطول</b> (م)
                                </td>
                                <td>
                                    &nbsp;<asp:Label ID="SEC_ORDERLabel0" runat="server" Text='<%# Bind("SEC_LENGTH", "{0:N2}") %>' />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="odsSectionInfo" runat="server" SelectMethod="GetSectionInfo"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:RadioButtonList ID="radlLanes" runat="server" AutoPostBack="True" DataSourceID="odsSectionLanes"
                    DataTextField="LANE_TYPE" DataValueField="LANE_ID" OnSelectedIndexChanged="radlLanes_SelectedIndexChanged"
                    RepeatDirection="Horizontal" OnDataBound="radlLanes_DataBound">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:ObjectDataSource ID="odsSectionLanes" runat="server" SelectMethod="GetSectionLanes"
                    TypeName="JpmmsClasses.BL.Lane">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreetSection" Name="sectionID" PropertyName="SelectedValue"
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
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource ID="odsDistresses" runat="server" SelectMethod="GetAllDistressesWithCleanOne"
                    TypeName="JpmmsClasses.BL.Distress"></asp:ObjectDataSource>
                <asp:GridView ID="gvLaneSamples" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="SAMPLE_ID" DataSourceID="odsLaneSamples" ForeColor="#333333" GridLines="None"
                    EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SAMPLE_ID" HeaderText="SAMPLE_ID" ReadOnly="True" SortExpression="SAMPLE_ID"
                            Visible="False" />
                        <asp:BoundField DataField="SAMPLE_NO" HeaderText="رقم العينة" SortExpression="SAMPLE_NO"
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="الطول" SortExpression="SAMPLE_LENGTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Culture="ar-QA"
                                    DataType="System.Decimal" DbValue='<%# Bind("SAMPLE_LENGTH") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SAMPLE_LENGTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العرض" SortExpression="SAMPLE_WIDTH">
                            <EditItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Culture="ar-QA"
                                    DataType="System.Decimal" DbValue='<%# Bind("SAMPLE_WIDTH") %>' MinValue="0"
                                    Width="125px">
                                </telerik:RadNumericTextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SAMPLE_WIDTH", "{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AREA" DataFormatString="{0:N2}" HeaderText="المساحة" ReadOnly="True"
                            SortExpression="AREA" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <%-- <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsLaneSamples" runat="server" SelectMethod="GetLaneSamples"
                    TypeName="JpmmsClasses.BL.LaneSample" UpdateMethod="UpdateLaneInfo">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radlLanes" Name="laneID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SAMPLE_LENGTH" Type="Double" />
                        <asp:Parameter Name="SAMPLE_WIDTH" Type="Double" />
                        <asp:Parameter Name="SAMPLE_ID" Type="Int32" />
                        <asp:SessionParameter Name="user" SessionField="UserName" Type="String" />
                        <asp:Parameter Name="NOTES" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
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
    </table>
</asp:Content>
