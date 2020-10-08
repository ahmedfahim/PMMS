<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDistressImage.aspx.cs"
    Inherits="ASPX_Sections_ViewDistressImage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>إضافة/تعديل صورة العيب</title>
    <link href="../../Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Header ID="Header1" runat="server" />
        <br />
        <table border="0" width="700" style="padding: 1px; background-position: bottom; background-repeat: repeat;"
            align="center">
            <tr>
                <td>
                    <h2 class="style1">
                        <b>إضافة/تعديل صورة عيب </b>
                    </h2>
                </td>
            </tr>
            <!-- Image -->
            <tr>
                <td>
                    <br />
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="odsSectionDistress">
                        <EditItemTemplate>
                            SECTION_NO:
                            <asp:TextBox ID="SECTION_NOTextBox" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                            <br />
                            FROM_STREET:
                            <asp:TextBox ID="FROM_STREETTextBox" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                            <br />
                            TO_STREET:
                            <asp:TextBox ID="TO_STREETTextBox" runat="server" Text='<%# Bind("TO_STREET") %>' />
                            <br />
                            MAIN_NO:
                            <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                            <br />
                            MAIN_NAME:
                            <asp:TextBox ID="MAIN_NAMETextBox" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                            <br />
                            SAMPLE_NO:
                            <asp:TextBox ID="SAMPLE_NOTextBox" runat="server" Text='<%# Bind("SAMPLE_NO") %>' />
                            <br />
                            LANE_TYPE:
                            <asp:TextBox ID="LANE_TYPETextBox" runat="server" Text='<%# Bind("LANE_TYPE") %>' />
                            <br />
                            DIST_CODE:
                            <asp:TextBox ID="DIST_CODETextBox" runat="server" Text='<%# Bind("DIST_CODE") %>' />
                            <br />
                            DISTRESS_AR_TYPE:
                            <asp:TextBox ID="DISTRESS_AR_TYPETextBox" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                            <br />
                            DIST_SEVERITY:
                            <asp:TextBox ID="DIST_SEVERITYTextBox" runat="server" Text='<%# Bind("DIST_SEVERITY") %>' />
                            <br />
                            DIST_AREA:
                            <asp:TextBox ID="DIST_AREATextBox" runat="server" Text='<%# Bind("DIST_AREA") %>' />
                            <br />
                            DIST_DENSITY:
                            <asp:TextBox ID="DIST_DENSITYTextBox" runat="server" Text='<%# Bind("DIST_DENSITY") %>' />
                            <br />
                            SURVEY_NO:
                            <asp:TextBox ID="SURVEY_NOTextBox" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
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
                            FROM_STREET:
                            <asp:TextBox ID="FROM_STREETTextBox" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                            <br />
                            TO_STREET:
                            <asp:TextBox ID="TO_STREETTextBox" runat="server" Text='<%# Bind("TO_STREET") %>' />
                            <br />
                            MAIN_NO:
                            <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                            <br />
                            MAIN_NAME:
                            <asp:TextBox ID="MAIN_NAMETextBox" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                            <br />
                            SAMPLE_NO:
                            <asp:TextBox ID="SAMPLE_NOTextBox" runat="server" Text='<%# Bind("SAMPLE_NO") %>' />
                            <br />
                            LANE_TYPE:
                            <asp:TextBox ID="LANE_TYPETextBox" runat="server" Text='<%# Bind("LANE_TYPE") %>' />
                            <br />
                            DIST_CODE:
                            <asp:TextBox ID="DIST_CODETextBox" runat="server" Text='<%# Bind("DIST_CODE") %>' />
                            <br />
                            DISTRESS_AR_TYPE:
                            <asp:TextBox ID="DISTRESS_AR_TYPETextBox" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                            <br />
                            DIST_SEVERITY:
                            <asp:TextBox ID="DIST_SEVERITYTextBox" runat="server" Text='<%# Bind("DIST_SEVERITY") %>' />
                            <br />
                            DIST_AREA:
                            <asp:TextBox ID="DIST_AREATextBox" runat="server" Text='<%# Bind("DIST_AREA") %>' />
                            <br />
                            DIST_DENSITY:
                            <asp:TextBox ID="DIST_DENSITYTextBox" runat="server" Text='<%# Bind("DIST_DENSITY") %>' />
                            <br />
                            SURVEY_NO:
                            <asp:TextBox ID="SURVEY_NOTextBox" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <b>اسم الطريق الرئيسي: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم المقطع: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SECTION_NOLabel" runat="server" Text='<%# Bind("SECTION_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>من
                                            <asp:Label ID="FROM_STREETLabel" runat="server" Text='<%# Bind("FROM_STREET") %>' />
                                            &nbsp;إلى
                                            <asp:Label ID="TO_STREETLabel" runat="server" Text='<%# Bind("TO_STREET") %>' />
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>المسار: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="LANE_TYPELabel" runat="server" Text='<%# Bind("LANE_TYPE") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم العينة: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SAMPLE_NOLabel" runat="server" Text='<%# Bind("SAMPLE_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>مساحة العينة م2: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("SAMPLE_AREA", "{0:N2}") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم المسح: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>تاريخ المسح: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SURVEY_DATELabel" runat="server" Text='<%# Bind("SURVEY_DATE", "{0:d}") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>اسم العيب: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("DIST_CODE") %>' />
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>الشدة: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("DIST_SEVERITY") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>مساحة العيب م2: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("DIST_AREA", "{0:N2}") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="odsSectionDistress" runat="server" SelectMethod="GetSectionSampleDistressInfo"
                        TypeName="JpmmsClasses.BL.DistressEntry.DistressEntry">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="distID" QueryStringField="DistID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgPhoto" runat="server" Height="300px" Width="80%" />
                </td>
            </tr>
            <!--  new Row -->
            <tr>
                <td>
                    <table width="100%" border="0">
                        <tr>
                            <td width="20%">
                                <asp:Label ID="Label2" runat="server" Text="صورة العيب" Width="160px" Style="font-weight: 700"></asp:Label>
                            </td>
                            <td width="30%">
                                <asp:FileUpload ID="updDistressImage" Width="230px" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
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
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="حذف" OnClientClick="return confirm('هل تريد الحذف فعلا؟');" />
                            </td>
                            <td>
                                <input type="button" value="إغلاق الصفحة" onclick="javascript:window.close();">
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
