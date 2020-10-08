<%@ Page Title="تفاصيل مقترح التحسين المروري" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="TrafficEnhancesDetails.aspx.cs" Inherits="ASPX_Operations_TrafficEnhances_TrafficEnhancesDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 60%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <h2 class="style1">
                    <b>تفاصيل مقترح التحسين المروري</b></h2>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
                    DataKeyNames="RECORD_ID" DataSourceID="odsTrafficEnhancesInfo" ForeColor="#333333"
                    GridLines="None" Height="50px" Width="30%">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="PROPOSE_TITLE" HeaderText="اسم المقترح" SortExpression="PROPOSE_TITLE" />
                        <asp:BoundField DataField="MUNIC_NAME" HeaderText="البلدية الفرعية" SortExpression="MUNIC_NAME" />
                        <asp:BoundField DataField="APPROVE_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الاعتماد"
                            SortExpression="APPROVE_DATE" />
                        <asp:BoundField DataField="APPROVE_DATE_H" HeaderText="تاريخ الاعتماد بالهجري" SortExpression="APPROVE_DATE_H" />
                        <asp:BoundField DataField="LETTER_FROM" HeaderText="بخطاب وارد من" SortExpression="LETTER_FROM" />
                        <asp:BoundField DataField="LETTER_NO" HeaderText="رقم الخطاب" SortExpression="LETTER_NO" />
                        <asp:BoundField DataField="LETTER_DATE" DataFormatString="{0:d}" HeaderText="تاريخ الخطاب"
                            SortExpression="LETTER_DATE" />
                        <asp:BoundField DataField="LETTER_DATE_H" HeaderText="تاريخ الخطاب بالهجري" SortExpression="LETTER_DATE_H" />
                        <asp:BoundField DataField="COMMITTE_HEAD_NAME" HeaderText="اللجنة برئاسة" SortExpression="COMMITTE_HEAD_NAME" />
                        <asp:BoundField DataField="NOTES" HeaderText="ملاحظات" SortExpression="NOTES" />
                    </Fields>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:DetailsView>
                <asp:ObjectDataSource ID="odsTrafficEnhancesInfo" runat="server" SelectMethod="GetByID"
                    TypeName="JpmmsClasses.BL.TrafficEnhances">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="trafficEnhanceID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td rowspan="6" valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
                <asp:ObjectDataSource ID="odsDistricts" runat="server" SelectMethod="GetAllDistrictsHavingRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMunicipality" runat="server" SelectMethod="GetAllMunic"
                    TypeName="JpmmsClasses.BL.Municpiality"></asp:ObjectDataSource>
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
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections0" runat="server" SelectMethod="GetMainStreetIntersections"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsTrafficEnhanceLocations" runat="server" OnDeleted="odsTrafficEnhanceLocations_Deleted"
                    SelectMethod="GeTrafficEnhanceLocations" TypeName="JpmmsClasses.BL.TrafficEnhances"
                    DeleteMethod="DeleteTrafficEnhanceLocations">
                    <DeleteParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="TRAFF_ENHANCES_id" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsTrafficEnhanceDetails" runat="server" DeleteMethod="DeleteDetail"
                    InsertMethod="InsertDetail" OnDeleted="odsTrafficEnhanceDetails_Deleted" OnInserted="odsTrafficEnhanceDetails_Inserted"
                    OnUpdated="odsTrafficEnhanceDetails_Updated" SelectMethod="GetAllDetails" TypeName="JpmmsClasses.BL.TrafficEnhances"
                    UpdateMethod="UpdateDetail">
                    <DeleteParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:QueryStringParameter Name="TRAFFIC_ENHANCE_ID" QueryStringField="ID" Type="Int32" />
                        <asp:Parameter Name="DETAILS" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="trafficEnhanceID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="TRAFFIC_ENHANCE_ID" Type="Int32" />
                        <asp:Parameter Name="DETAILS" Type="String" />
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:FormView ID="FormView2" runat="server" DataKeyNames="RECORD_ID" DataSourceID="odsTrafficEnhanceDetails"
                    DefaultMode="Insert" OnItemInserting="FormView2_ItemInserting">
                    <EditItemTemplate>
                        RECORD_ID:
                        <asp:Label ID="RECORD_IDLabel1" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                        <br />
                        TRAFF_ENHANCE_ID:
                        <asp:TextBox ID="TRAFF_ENHANCE_IDTextBox" runat="server" Text='<%# Bind("TRAFF_ENHANCE_ID") %>' />
                        <br />
                        DETAILS:
                        <asp:TextBox ID="DETAILSTextBox" runat="server" Text='<%# Bind("DETAILS") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    تفاصيل التحسين المروري
                                </td>
                                <td>
                                    <asp:TextBox ID="DETAILSTextBox" runat="server" MaxLength="1500" Text='<%# Bind("DETAILS") %>'
                                        TextMode="MultiLine" Width="235px" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DETAILSTextBox"
                                        ErrorMessage="الرجاء إدخال بيان التفاصيل" ValidationGroup="details"></asp:RequiredFieldValidator>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        Text="حفظ" ValidationGroup="details" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="إلغاء" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        RECORD_ID:
                        <asp:Label ID="RECORD_IDLabel" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                        <br />
                        TRAFF_ENHANCE_ID:
                        <asp:Label ID="TRAFF_ENHANCE_IDLabel" runat="server" Text='<%# Bind("TRAFF_ENHANCE_ID") %>' />
                        <br />
                        DETAILS:
                        <asp:Label ID="DETAILSLabel" runat="server" Text='<%# Bind("DETAILS") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:GridView ID="gvTrafficEnhanceDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="RECORD_ID" DataSourceID="odsTrafficEnhanceDetails"
                    ForeColor="#333333" GridLines="None" OnRowDeleting="gvTrafficEnhanceDetails_RowDeleting"
                    OnRowUpdating="gvTrafficEnhanceDetails_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                            Visible="False" />
                        <asp:TemplateField HeaderText="تفاصيل التحسين المروري" SortExpression="DETAILS">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DETAILS") %>' TextMode="MultiLine"
                                    Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="الرجاء إدخال بيان التفاصيل" ValidationGroup="detailsed"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DETAILS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ"
                            ValidationGroup="detailsed" />
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
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td width="30%" colspan="2" style="width: 100%">
                            <h4>
                                <strong>أماكن التنفيذ</strong></h4>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%">
                            <b>&nbsp;شارع </b>
                        </td>
                        <td width="70%">
                            <asp:DropDownList ID="ddlMainStreets" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreets" DataTextField="main_title"
                                DataValueField="STREET_ID" OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged"
                                Visible="False">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
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
                            <asp:DropDownList ID="ddlMainStreetSection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreetSections" DataTextField="section_from_to"
                                DataValueField="section_id" Visible="False">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMainStreetIntersection" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="odsMainStreetIntersections0" DataTextField="intersection_title"
                                DataValueField="INTERSECTION_ID" Visible="False">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
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
                                    OnCheckedChanged="radRegion_CheckedChanged" Text="منطقة فرعية" />
                            </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="region_title" DataValueField="region_id"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged" Visible="False">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlSecST" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegionSecondaryStreets" DataTextField="second_st_title" 
                                DataValueField="STREET_ID">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Panel ID="pnlLandUse" runat="server" Visible="False">
                                <asp:CheckBox ID="chkLandUse" runat="server" Text="استخدام مصاحب Land Use" 
                                    oncheckedchanged="chkLandUse_CheckedChanged" />
                                <br />
                                تفاصيل الاستخدام المصاحب:<br />
                                <asp:TextBox ID="txtLandUseDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-right: 80px">
                            <table class="style3">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblAddFeedback" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddLocation" runat="server" OnClick="btnAddLocation_Click" Text="إضافة" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancelLocation" runat="server" OnClick="btnCancelLocation_Click"
                                            Text="إلغاء" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-right: 80px" colspan="2">
                            &nbsp; &nbsp;
                            <asp:GridView ID="gvLocations" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                DataSourceID="odsTrafficEnhanceLocations" DataKeyNames="RECORD_ID" ForeColor="#333333"
                                GridLines="None" AllowPaging="True" OnRowDeleting="gvLocations_RowDeleting">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" SortExpression="RECORD_ID"
                                        Visible="False" />
                                    <asp:BoundField DataField="HEADING" HeaderText="النوع" SortExpression="HEADING" />
                                    <asp:BoundField DataField="NUM" HeaderText="الرقم" SortExpression="NUM" />
                                    <asp:BoundField DataField="TITLE" HeaderText="المكان" SortExpression="TITLE" />
                                    <asp:CheckBoxField DataField="IS_LAND_USE" HeaderText="استعمال مصاحب LandUse?" />
                                    <asp:BoundField DataField="LANDUSE_DETAILS" HeaderText="تفاصيل" />
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
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
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
        </tr>
    </table>
</asp:Content>
