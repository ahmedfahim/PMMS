<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SectionImages.aspx.cs" Inherits="ASPX_Sections_SectionImages" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>استعراض صور المقطع</title>
    <link href="../../Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 10%;
        }
        div.img
        {
            margin: 2px;
            border: 1px solid #0000ff;
            height: auto;
            width: auto;
            float: left;
            text-align: center;
        }
        div.img img
        {
            display: inline;
            margin: 3px;
            border: 1px solid #ffffff;
        }
        div.img a:hover img
        {
            border: 1px solid #0000ff;
        }
        div.desc
        {
            text-align: center;
            font-weight: normal;
            width: 120px;
            margin: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Header ID="Header1" runat="server" />
    <div>
      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <br />
        <table border="0" width="700" style="padding: 1px; background-position: bottom; background-repeat: repeat;"
            align="center">
            <tr>
                <td>
                    <h3>
                        <b style="text-align: center">استعراض صور المقطع</b></h3>
                </td>
            </tr>
            <!-- Image -->
            <tr>
                <td>
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
                            <asp:TextBox ID="SECTION_NOTextBox0" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                            <br />
                            SEC_DIRECTION:
                            <asp:TextBox ID="SEC_DIRECTIONTextBox0" runat="server" Text='<%# Bind("SEC_DIRECTION") %>' />
                            <br />
                            SEC_ORDER:
                            <asp:TextBox ID="SEC_ORDERTextBox0" runat="server" Text='<%# Bind("SEC_ORDER") %>' />
                            <br />
                            SEC_LENGTH:
                            <asp:TextBox ID="SEC_LENGTHTextBox0" runat="server" Text='<%# Bind("SEC_LENGTH") %>' />
                            <br />
                            SEC_WIDTH:
                            <asp:TextBox ID="SEC_WIDTHTextBox0" runat="server" Text='<%# Bind("SEC_WIDTH") %>' />
                            <br />
                            FROM_STREET:
                            <asp:TextBox ID="FROM_STREETTextBox0" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                            <br />
                            TO_STREET:
                            <asp:TextBox ID="TO_STREETTextBox0" runat="server" Text='<%# Bind("TO_STREET") %>' />
                            <br />
                            DISTRICT:
                            <asp:TextBox ID="DISTRICTTextBox0" runat="server" Text='<%# Bind("DISTRICT") %>' />
                            <br />
                            MUNICIPALITY:
                            <asp:TextBox ID="MUNICIPALITYTextBox0" runat="server" Text='<%# Bind("MUNICIPALITY") %>' />
                            <br />
                            MAIN_NO:
                            <asp:TextBox ID="MAIN_NOTextBox0" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                            <br />
                            SUBDIST_ID:
                            <asp:TextBox ID="SUBDIST_IDTextBox0" runat="server" Text='<%# Bind("SUBDIST_ID") %>' />
                            <br />
                            MAIN_ST_TITLE:
                            <asp:TextBox ID="MAIN_ST_TITLETextBox0" runat="server" Text='<%# Bind("MAIN_ST_TITLE") %>' />
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
                                    <td>
                                        <b>إلى</b>
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
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
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
                            </table>
                            <br />
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="odsSectionInfo" runat="server" SelectMethod="GetSectionInfo"
                        TypeName="JpmmsClasses.BL.MainStreetSection">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="sectionID" QueryStringField="sectionID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <!--  new Row -->
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table width="50%" border="0">
                        <tr>
                            <td width="10%">
                                <b>
                                    <asp:Label ID="Label2" runat="server" Text="الصورة" Width="160px"></asp:Label>
                                </b>
                            </td>
                            <td width="30%">
                                <asp:FileUpload ID="updDistressImage" Width="235px" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <b>تفاصيل</b>
                            </td>
                            <td width="30%" colspan="2">
                                <asp:TextBox ID="txtImageDetails" runat="server" Height="62px" Width="235px" TextMode="MultiLine"></asp:TextBox>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOperation" runat="server" ForeColor="#C60000" Font-Bold="True"
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <!-- new Row button-->
            <tr>
                <td>
                    <table width="100%" border="0">
                        <tr>
                            <td width="20%">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="حفظ" Width="100px"
                                    ValidationGroup="save" />
                            </td>
                            <td width="30%">
                                <input type="button" value="إغلاق الصفحة" onclick="javascript:window.close();">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" colspan="3">
                                <asp:ListView ID="lvwImages" GroupItemCount="3" runat="server" DataKeyNames="RECORD_ID"
                                    DataSourceID="sdsIntersectImages" OnItemDeleting="lvwImages_ItemDeleting">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <div>
                                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                        </div>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <div class="img">
                                            <a id="A1" runat="server" target="_blank" href='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>'>
                                                <asp:Image runat="server" ID="picAlbum" Width="200" Height="100" AlternateText='<% #Eval("DETAILS") %>'
                                                    ImageUrl='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>' />
                                            </a>
                                            <div class="desc">
                                                <asp:LinkButton ID="lbtnDelete" CommandArgument='<% #Eval("RECORD_ID") %>' OnClientClick="return confirm('هل تريد الحذف فعلا؟');"
                                                    runat="server" OnCommand="lbtnDelete_click">حذف</asp:LinkButton>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--<asp:GridView ID="gvImages" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataKeyNames="RECORD_ID" DataSourceID="sdsIntersectImages" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                                            Visible="False" />
                                        <asp:TemplateField HeaderText="الصورة" SortExpression="PHOTO_NAME">
                                            <EditItemTemplate>
                                                <asp:Image ID="Image1" runat="server" Height="375px" ImageUrl='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>'
                                                    Width="500px" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <a id="A1" runat="server" target="_blank" href='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>'>
                                                    <asp:Image ID="Image1" runat="server" Height="375px" ImageUrl='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>'
                                                        Width="500px" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DETAILS" HeaderText="تفاصيل" SortExpression="DETAILS" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="حذف"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>--%>
                                <asp:ObjectDataSource ID="sdsIntersectImages" runat="server" DeleteMethod="DeleteImage"
                                    SelectMethod="GetSectionImages" TypeName="JpmmsClasses.BL.ImagesGallery" UpdateMethod="UpdateImageDetails"
                                    OnDeleted="sdsIntersectImages_Deleted" OnUpdated="sdsIntersectImages_Updated">
                                    <DeleteParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                        <asp:Parameter Name="DETAILS" Type="String" />
                                    </UpdateParameters>
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="ID" QueryStringField="sectionID" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
