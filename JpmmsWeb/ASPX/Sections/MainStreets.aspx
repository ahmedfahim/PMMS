<%@ Page Title="البيانات العامة للطرق والشوارع الرئيسية" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="MainStreets.aspx.cs" Inherits="ASPX_Sections_MainStreets" %>

<%@ Register Src="~/ASCX/AddContractorMini.ascx" TagName="addcontractormini" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 60%;
        }
        .style2
        {
            text-align: center;
        }
        .style11
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
                    <b>البيانات العامة للطرق والشوارع الرئيسية</b></h2>
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
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllFullInfo"
                    TypeName="JpmmsClasses.BL.MainStreet" OnUpdated="odsMainStreets_Updated"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsCategories" runat="server" SelectMethod="GetMainStreetCategories"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsContractors" runat="server" SelectMethod="GetContractorsList"
                    TypeName="JpmmsClasses.BL.Lookups.Contractor"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetsSelecting" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/loading2.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <b>اسم الطريق الرئيسي: </b>
                <asp:DropDownList ID="ddlMainSt" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                    DataSourceID="odsMainStreetsSelecting" DataTextField="main_title" DataValueField="STREET_ID"
                    OnSelectedIndexChanged="ddlMainSt_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                </asp:DropDownList>
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
                <asp:Panel runat="server" Visible="false" ID="pnlEdit">
                    <table class="style1">
                        <tr>
                            <td>
                                <b>رقم الطريق الرئيسي </b>
                            </td>
                            <td>
                                <asp:Label ID="lblMainNo" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>اسم الطريق الرئيسي </b>
                            </td>
                            <td>
                                <asp:TextBox ID="MAIN_NAMETextBox" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="MAIN_NAMETextBox"
                                    ErrorMessage="الرجاء الإدخال"></asp:RequiredFieldValidator>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>الاسم الانجليزي </b>
                            </td>
                            <td>
                                <asp:TextBox ID="MAIN_EN_NAMETextBox" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>ترقيم الأمانة للطريق</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOfficialNum" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>تصنيف الطريق الرئيسي </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategories" runat="server" AppendDataBoundItems="True" DataSourceID="odsCategories"
                                    DataTextField="MAINST_CATEGORY" DataValueField="MAINST_CATEGORY_ID" Width="80px">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>مقاول التنفيذ </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlContractors" runat="server" AppendDataBoundItems="True"
                                    DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_ID"
                                    Width="80px">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="btnAddContractor" runat="server" OnClick="btnAddContractor_Click">إضافة مقاول</asp:LinkButton>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <b>&nbsp; </b>
                                <asp:CheckBox ID="chkIsR4" runat="server" Style="font-weight: 700" Text="الطريق مستحدث؟" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>تبعية مقاطع الطريق</b>
                            </td>
                            <td>
                                <asp:RadioButton ID="radFully" runat="server" GroupName="type" Text="تابع للأمانة كليا" />
                                <br />
                                <asp:RadioButton ID="radPartially" runat="server" GroupName="type" Text="تتبع للأمانة مقاطع محددة فقط" />
                                <br />
                                <asp:RadioButton ID="radNot" runat="server" Text="غير تابع للأمانة" GroupName="type" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox ID="chkIntersectSamples" runat="server" Style="font-weight: 700" Text="كل عينات تقاطعات الطريق تتبع للأمانة؟" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>تفاصيل</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="حفظ" CssClass="style11" OnClick="UpdateButton_Click" />
                            </td>
                            <td>
                                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="إلغاء" OnClick="UpdateCancelButton_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%-- <asp:FormView ID="frvMainStEdit" runat="server" DataSourceID="odsMainStreetInfoEdit"
                    DataKeyNames="MAIN_ST_ID" DefaultMode="Edit" OnItemUpdating="frvMainStEdit_ItemUpdating">
                    <EditItemTemplate>
                        
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        MAIN_NO:
                        <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                        <br />
                        MAIN_NAME:
                        <asp:TextBox ID="MAIN_NAMETextBox" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                        <br />
                        MAIN_EN_NAME:
                        <asp:TextBox ID="MAIN_EN_NAMETextBox" runat="server" Text='<%# Bind("MAIN_EN_NAME") %>' />
                        <br />
                        MAIN_ST_ID:
                        <asp:TextBox ID="MAIN_ST_IDTextBox" runat="server" Text='<%# Bind("MAIN_ST_ID") %>' />
                        <br />
                        CONTRACTOR_ID:
                        <asp:TextBox ID="CONTRACTOR_IDTextBox" runat="server" Text='<%# Bind("CONTRACTOR_ID") %>' />
                        <br />
                        IS_R4:
                        <asp:TextBox ID="IS_R4TextBox" runat="server" Text='<%# Bind("IS_R4") %>' />
                        <br />
                        OFFICIAL_MUNIC_NUM:
                        <asp:TextBox ID="OFFICIAL_MUNIC_NUMTextBox" runat="server" Text='<%# Bind("OFFICIAL_MUNIC_NUM") %>' />
                        <br />
                        PAVED_BY_MUNIC:
                        <asp:TextBox ID="PAVED_BY_MUNICTextBox" runat="server" Text='<%# Bind("PAVED_BY_MUNIC") %>' />
                        <br />
                        OWNED_BY_MUNIC:
                        <asp:TextBox ID="OWNED_BY_MUNICTextBox" runat="server" Text='<%# Bind("OWNED_BY_MUNIC") %>' />
                        <br />
                        MAINST_CATEGORY_ID:
                        <asp:TextBox ID="MAINST_CATEGORY_IDTextBox" runat="server" Text='<%# Bind("MAINST_CATEGORY_ID") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        MAIN_NO:
                        <asp:Label ID="MAIN_NOLabel" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                        <br />
                        MAIN_NAME:
                        <asp:Label ID="MAIN_NAMELabel" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                        <br />
                        MAIN_EN_NAME:
                        <asp:Label ID="MAIN_EN_NAMELabel" runat="server" Text='<%# Bind("MAIN_EN_NAME") %>' />
                        <br />
                        MAIN_ST_ID:
                        <asp:Label ID="MAIN_ST_IDLabel" runat="server" Text='<%# Eval("MAIN_ST_ID") %>' />
                        <br />
                        CONTRACTOR_ID:
                        <asp:Label ID="CONTRACTOR_IDLabel" runat="server" Text='<%# Bind("CONTRACTOR_ID") %>' />
                        <br />
                        IS_R4:
                        <asp:Label ID="IS_R4Label" runat="server" Text='<%# Bind("IS_R4") %>' />
                        <br />
                        OFFICIAL_MUNIC_NUM:
                        <asp:Label ID="OFFICIAL_MUNIC_NUMLabel" runat="server" Text='<%# Bind("OFFICIAL_MUNIC_NUM") %>' />
                        <br />
                        PAVED_BY_MUNIC:
                        <asp:Label ID="PAVED_BY_MUNICLabel" runat="server" Text='<%# Bind("PAVED_BY_MUNIC") %>' />
                        <br />
                        OWNED_BY_MUNIC:
                        <asp:Label ID="OWNED_BY_MUNICLabel" runat="server" Text='<%# Bind("OWNED_BY_MUNIC") %>' />
                        <br />
                        MAINST_CATEGORY_ID:
                        <asp:Label ID="MAINST_CATEGORY_IDLabel" runat="server" Text='<%# Bind("MAINST_CATEGORY_ID") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>--%>
                <asp:ObjectDataSource ID="odsMainStreetInfoEdit" runat="server" SelectMethod="GetByID"
                    TypeName="JpmmsClasses.BL.MainStreet" UpdateMethod="Update" OnUpdated="odsMainStreetInfoEdit_Updated">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainSt" Name="MAIN_ST_ID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="MAIN_NAME" Type="String" />
                        <asp:Parameter Name="MAIN_EN_NAME" Type="String" />
                        <asp:Parameter Name="CONTRACTOR_ID" Type="Int32" />
                        <asp:Parameter Name="IS_R4" Type="Boolean" />
                        <asp:Parameter Name="FULLY_MUNIC_OWNED" Type="Boolean" />
                        <asp:Parameter Name="PARTIALLY_MUNIC_OWNED" Type="Boolean" />
                        <asp:Parameter Name="NOT_MUNIC_OWNED" Type="Boolean" />
                        <asp:Parameter Name="OWNERSHIP_DETAILS" Type="String" />
                        <asp:Parameter Name="MAINST_CATEGORY_ID" Type="Int32" />
                        <asp:Parameter Name="MAIN_NO" Type="String" />
                        <asp:Parameter Name="ALL_INTERSAMP_OWNED_MUNIC" Type="Boolean" />
                        <asp:ControlParameter ControlID="ddlMainSt" Name="MAIN_ST_ID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                <uc1:addcontractormini ID="AddContractorMini1" runat="server" OnOnContractorAdded="OnOnContractorAdded"
                    Visible="False" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
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
