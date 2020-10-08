<%@ Page Title="معرض صور شبكة الطرق" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ImagesGallery.aspx.cs" Inherits="ASPX_Operations_ImagesGallery" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../ASCX/SearchRegion.ascx" TagName="SearchRegion" TagPrefix="uc1" %>
<%@ Register Src="../../ASCX/SearchSection.ascx" TagName="SearchSection" TagPrefix="uc2" %>
<%@ Register Src="../../ASCX/SearchIntersect.ascx" TagName="SearchIntersect" TagPrefix="uc2" %>
<%@ Register Src="../../ASCX/SearchMainSt.ascx" TagName="SearchMainSt" TagPrefix="uc3" %>
<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script src="../../scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
    <script src="../../scripts/lightbox.js" type="text/javascript"></script>
    <link href="../../scripts/lightbox.css" rel="stylesheet" />
    <%--<link href="../../scripts/screen.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                <h2 style="text-align: center">
                    معرض صور شبكة الطرق</h2>
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
                <asp:ObjectDataSource ID="odsMainStreets" runat="server" SelectMethod="GetAllMainStreets"
                    TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetSections" runat="server" SelectMethod="GetMainStreetSections"
                    TypeName="JpmmsClasses.BL.MainStreetSection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllRegions"
                    TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSurveyors" runat="server" SelectMethod="GetAllsurveyors"
                    TypeName="JpmmsClasses.BL.Surveyor"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMainStreetIntersections0" runat="server" SelectMethod="GetMainStreetIntersections"
                    TypeName="JpmmsClasses.BL.Intersection">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainStreets" Name="mainStreetID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            <asp:RadioButton ID="radSection" runat="server" Checked="True" GroupName="type" Text="مقاطع وتقاطعات طرق رئيسية"
                                AutoPostBack="True" OnCheckedChanged="radSection_CheckedChanged" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="radRegionSecondary" runat="server" GroupName="type" Text="مناطق شوارع فرعية"
                                AutoPostBack="True" OnCheckedChanged="radRegionSecondary_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;<asp:LinkButton ID="lbtnSearchMainSt" runat="server" OnClick="lbtnSearch_Click"
                                ToolTip="بحث بالرقم أو بجزء من الاسم">بحث متقدم</asp:LinkButton>
                            <asp:LinkButton ID="lbtnSearchRegions" runat="server" OnClick="lbtnSearch_Click"
                                ToolTip="بحث بالرقم أو بجزء من الاسم" Visible="False">بحث متقدم</asp:LinkButton>
                            &nbsp;
                            <asp:HyperLink ID="lnkPrint" runat="server" Target="_blank">عرض للطباعة</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnlMainSt" Visible="false" runat="server">
                                <table class="style1">
                                    <tr>
                                        <td>
                                            الشارع الرئيسي
                                        </td>
                                        <td>
                                            <telerik:RadComboBox Filter="Contains" Width="200px" Font-Size="Medium" AutoselectFirstItem="True"
                                                ID="ddlMainStreets" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                DataSourceID="odsMainStreets" DataTextField="main_name" DataValueField="STREET_ID"
                                                OnSelectedIndexChanged="ddlMainStreets_SelectedIndexChanged" Visible="False">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                                </Items>
                                            </telerik:RadComboBox>
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
                            </asp:Panel>
                            <asp:Panel ID="pnlRegion" Visible="false" runat="server">
                                <table class="style1">
                                    <tr>
                                        <td>
                                            المنطقة الفرعية
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc3:SearchMainSt ID="SearchMainSt1" runat="server" Visible="false" OnSetSearchChanged="OnMainStSearchChanged" />
                        </td>
                        <td>
                            <uc1:SearchRegion ID="SearchRegion1" Visible="false" OnSetSearchChanged="OnSetSearchChanged"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="style5">
                            <div id="page">
                                <div id="images">
                                    <asp:ListView ID="lvwImages" runat="server" DataKeyNames="RECORD_ID" ItemPlaceholderID="itemContainer"
                                        OnPagePropertiesChanging="lvwImages_PagePropertiesChanging" EnableModelValidation="True"
                                        DataSourceID="odsImages">
                                        <LayoutTemplate>
                                            <asp:PlaceHolder ID="itemContainer" runat="server" />
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <a href='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>' runat="server" rel="lightbox" id="imgHref">
                                                <asp:Image runat="server" ID="imPhoto" Width="200" Height="100" AlternateText='<% #Eval("DETAILS") %>'
                                                    ImageUrl='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>' />
                                            </a>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            لاتوجد صور
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                    <asp:ObjectDataSource ID="odsImages" runat="server" SelectMethod="GetImages" TypeName="JpmmsClasses.BL.ImagesGallery">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlMainStreets" Name="ID" PropertyName="SelectedValue"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="radSection" Name="mainSt" PropertyName="Checked"
                                                Type="Boolean" />
                                            <asp:ControlParameter ControlID="radRegionSecondary" Name="secST" PropertyName="Checked"
                                                Type="Boolean" />
                                            <asp:ControlParameter ControlID="ddlRegions" Name="RegionID" PropertyName="SelectedValue"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvwImages" PageSize="16"
                                        OnPreRender="DataPager1_PreRender">
                                        <Fields>
                                            <asp:NumericPagerField />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
