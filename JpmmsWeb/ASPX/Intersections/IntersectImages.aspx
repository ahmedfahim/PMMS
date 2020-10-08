<%@ Page Title="استعراض صور التقاطع" Language="C#" AutoEventWireup="true" CodeFile="IntersectImages.aspx.cs"
    Inherits="ASPX_Intersections_IntersectImages" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title></title>
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
    <div>
        <uc1:Header ID="Header1" runat="server" />
       <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <table border="0" width="700" style="padding: 1px; background-position: bottom; background-repeat: repeat;"
            align="center">
            <tr>
                <td align="center">
                    <h3>
                        <b style="text-align: center">استعراض صور التقاطع </b>
                    </h3>
                </td>
            </tr>
            <!-- Image -->
            <tr>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="odsIntersectionInfo">
                        <ItemTemplate>
                            <strong>رقم التقاطع: </strong>
                            <asp:Label ID="lblIntersectNo" runat="server" Text='<%# Bind("INTER_NO") %>'></asp:Label>
                            &nbsp; &nbsp; <strong>
                                <br />
                                شارع رئيسي:&nbsp; </strong>
                            <asp:Label ID="lblIntersectStreet1" runat="server" Text='<%# Bind("INTEREC_STREET1") %>'></asp:Label>
                            &nbsp; &nbsp; &nbsp; <strong>مع شارع: </strong>
                            <asp:Label ID="lblIntersectStreet2" runat="server" Text='<%# Bind("INTEREC_STREET2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="odsIntersectionInfo" runat="server" SelectMethod="GetIntersection"
                        TypeName="JpmmsClasses.BL.Intersection">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="intersectionID" QueryStringField="InterID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <!--  new Row -->
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
                                <asp:FileUpload ID="updDistressImage" Width="220px" runat="server" />
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
                                <asp:TextBox ID="txtImageDetails" runat="server" Height="62px" Width="220px" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:LinkButton ID="lbtnDelete" CommandArgument='<% #Eval("RECORD_ID") %>' runat="server"
                                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" OnCommand="lbtnDelete_click">حذف</asp:LinkButton>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--<asp:GridView ID="gvIntersectImages" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                                <a runat="server" target="_blank" href='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>'>
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
                                    SelectMethod="GetIntersectImages" TypeName="JpmmsClasses.BL.ImagesGallery" UpdateMethod="UpdateImageDetails"
                                    OnDeleted="sdsIntersectImages_Deleted" OnUpdated="sdsIntersectImages_Updated">
                                    <DeleteParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                        <asp:Parameter Name="DETAILS" Type="String" />
                                    </UpdateParameters>
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="ID" QueryStringField="InterID" Type="Int32" />
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
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
