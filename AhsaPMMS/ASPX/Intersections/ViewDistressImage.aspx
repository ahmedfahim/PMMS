<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDistressImage.aspx.cs"
    Inherits="ASPX_Intersections_ViewDistressImage" %>

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
            width: 100%;
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
                    <h3>
                        <b>إضافة/تعديل صورة العيب </b>
                    </h3>
                </td>
            </tr>
            <!-- Image -->
            <tr>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="odsIntersectDistress">
                        <EditItemTemplate>
                            MAIN_NO:
                            <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                            <br />
                            MAIN_NAME:
                            <asp:TextBox ID="MAIN_NAMETextBox" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                            <br />
                            INTER_NO:
                            <asp:TextBox ID="INTER_NOTextBox" runat="server" Text='<%# Bind("INTER_NO") %>' />
                            <br />
                            INTEREC_STREET1:
                            <asp:TextBox ID="INTEREC_STREET1TextBox" runat="server" Text='<%# Bind("INTEREC_STREET1") %>' />
                            <br />
                            INTEREC_STREET2:
                            <asp:TextBox ID="INTEREC_STREET2TextBox" runat="server" Text='<%# Bind("INTEREC_STREET2") %>' />
                            <br />
                            INTER_SAMP_NO:
                            <asp:TextBox ID="INTER_SAMP_NOTextBox" runat="server" Text='<%# Bind("INTER_SAMP_NO") %>' />
                            <br />
                            SURVEY_NO:
                            <asp:TextBox ID="SURVEY_NOTextBox" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
                            <br />
                            SURVEY_DATE:
                            <asp:TextBox ID="SURVEY_DATETextBox" runat="server" Text='<%# Bind("SURVEY_DATE") %>' />
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
                            INTERSEC_SAMP_AREA:
                            <asp:TextBox ID="INTERSEC_SAMP_AREATextBox" runat="server" Text='<%# Bind("INTERSEC_SAMP_AREA") %>' />
                            <br />
                            DIST_DENSITY:
                            <asp:TextBox ID="DIST_DENSITYTextBox" runat="server" Text='<%# Bind("DIST_DENSITY") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            MAIN_NO:
                            <asp:TextBox ID="MAIN_NOTextBox" runat="server" Text='<%# Bind("MAIN_NO") %>' />
                            <br />
                            MAIN_NAME:
                            <asp:TextBox ID="MAIN_NAMETextBox" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                            <br />
                            INTER_NO:
                            <asp:TextBox ID="INTER_NOTextBox" runat="server" Text='<%# Bind("INTER_NO") %>' />
                            <br />
                            INTEREC_STREET1:
                            <asp:TextBox ID="INTEREC_STREET1TextBox" runat="server" Text='<%# Bind("INTEREC_STREET1") %>' />
                            <br />
                            INTEREC_STREET2:
                            <asp:TextBox ID="INTEREC_STREET2TextBox" runat="server" Text='<%# Bind("INTEREC_STREET2") %>' />
                            <br />
                            INTER_SAMP_NO:
                            <asp:TextBox ID="INTER_SAMP_NOTextBox" runat="server" Text='<%# Bind("INTER_SAMP_NO") %>' />
                            <br />
                            SURVEY_NO:
                            <asp:TextBox ID="SURVEY_NOTextBox" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
                            <br />
                            SURVEY_DATE:
                            <asp:TextBox ID="SURVEY_DATETextBox" runat="server" Text='<%# Bind("SURVEY_DATE") %>' />
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
                            INTERSEC_SAMP_AREA:
                            <asp:TextBox ID="INTERSEC_SAMP_AREATextBox" runat="server" Text='<%# Bind("INTERSEC_SAMP_AREA") %>' />
                            <br />
                            DIST_DENSITY:
                            <asp:TextBox ID="DIST_DENSITYTextBox" runat="server" Text='<%# Bind("DIST_DENSITY") %>' />
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
                                        <asp:Label ID="MAIN_NAMELabel" runat="server" Text='<%# Bind("MAIN_NAME") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم التقاطع: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="INTER_NOLabel" runat="server" Text='<%# Bind("INTER_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>تقاطع
                                            <asp:Label ID="INTEREC_STREET1Label" runat="server" Text='<%# Bind("INTEREC_STREET1") %>' />
                                            &nbsp;مع<asp:Label ID="INTEREC_STREET2Label" runat="server" Text='<%# Bind("INTEREC_STREET2") %>' />
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم العينة: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="INTER_SAMP_NOLabel" runat="server" Text='<%# Bind("INTER_SAMP_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>مساحة العينة م2: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="INTERSEC_SAMP_AREALabel" runat="server" Text='<%# Bind("INTERSEC_SAMP_AREA", "{0:N2}") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم المسح: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SURVEY_NOLabel" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
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
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DIST_CODE") %>' />
                                        <asp:Label ID="DISTRESS_AR_TYPELabel" runat="server" Text='<%# Bind("DISTRESS_AR_TYPE") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>الشدة: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="DIST_SEVERITYLabel" runat="server" Text='<%# Bind("DIST_SEVERITY") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>مساحة العيب م2: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="DIST_AREALabel" runat="server" Text='<%# Bind("DIST_AREA", "{0:N2}") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="odsIntersectDistress" runat="server" SelectMethod="GetIntersectDistressInfo"
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
                                <asp:Label ID="Label2" runat="server" Text="صورة العيب" Width="160px"></asp:Label>
                            </td>
                            <td width="30%">
                                <asp:FileUpload ID="updDistressImage" runat="server" />
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
                                &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="حذف"
                                    OnClientClick="return confirm('هل تريد الحذف فعلا؟');" />
                            </td>
                            <td>
                                &nbsp;
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
