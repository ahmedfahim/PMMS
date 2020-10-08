<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDistressImage.aspx.cs"
    Inherits="ASPX_Regions_ViewDistressImage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>إضافة/تعديل صورة العيب</title>
    <link href="../../Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
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
                <td style="text-align: center">
                    <h3>
                        <b>إضافة/تعديل صورة عيب </b>
                    </h3>
            </tr>
            <!-- Image -->
            <tr>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="odsRegionDistress">
                        <EditItemTemplate>
                            MUNIC_NAME:
                            <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                            <br />
                            DIST_NAME:
                            <asp:TextBox ID="DIST_NAMETextBox" runat="server" Text='<%# Bind("DIST_NAME") %>' />
                            <br />
                            SUBDISTRICT:
                            <asp:TextBox ID="SUBDISTRICTTextBox" runat="server" Text='<%# Bind("SUBDISTRICT") %>' />
                            <br />
                            REGION_NO:
                            <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                            <br />
                            SECOND_ST_NO:
                            <asp:TextBox ID="SECOND_ST_NOTextBox" runat="server" Text='<%# Bind("SECOND_ST_NO") %>' />
                            <br />
                            SECOND_AR_NAME:
                            <asp:TextBox ID="SECOND_AR_NAMETextBox" runat="server" Text='<%# Bind("SECOND_AR_NAME") %>' />
                            <br />
                            SECOND_ST_AREA:
                            <asp:TextBox ID="SECOND_ST_AREATextBox" runat="server" Text='<%# Bind("SECOND_ST_AREA") %>' />
                            <br />
                            SURVEY_DATE:
                            <asp:TextBox ID="SURVEY_DATETextBox" runat="server" Text='<%# Bind("SURVEY_DATE") %>' />
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
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            MUNIC_NAME:
                            <asp:TextBox ID="MUNIC_NAMETextBox" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                            <br />
                            DIST_NAME:
                            <asp:TextBox ID="DIST_NAMETextBox" runat="server" Text='<%# Bind("DIST_NAME") %>' />
                            <br />
                            SUBDISTRICT:
                            <asp:TextBox ID="SUBDISTRICTTextBox" runat="server" Text='<%# Bind("SUBDISTRICT") %>' />
                            <br />
                            REGION_NO:
                            <asp:TextBox ID="REGION_NOTextBox" runat="server" Text='<%# Bind("REGION_NO") %>' />
                            <br />
                            SECOND_ST_NO:
                            <asp:TextBox ID="SECOND_ST_NOTextBox" runat="server" Text='<%# Bind("SECOND_ST_NO") %>' />
                            <br />
                            SECOND_AR_NAME:
                            <asp:TextBox ID="SECOND_AR_NAMETextBox" runat="server" Text='<%# Bind("SECOND_AR_NAME") %>' />
                            <br />
                            SECOND_ST_AREA:
                            <asp:TextBox ID="SECOND_ST_AREATextBox" runat="server" Text='<%# Bind("SECOND_ST_AREA") %>' />
                            <br />
                            SURVEY_DATE:
                            <asp:TextBox ID="SURVEY_DATETextBox" runat="server" Text='<%# Bind("SURVEY_DATE") %>' />
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
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <table class="style2">
                                <tr>
                                    <td>
                                        <b>البلدية: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="MUNIC_NAMELabel" runat="server" Text='<%# Bind("MUNIC_NAME") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>الحي: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="DIST_NAMELabel" runat="server" Text='<%# Bind("DIST_NAME") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>الحي الفرعي: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SUBDISTRICTLabel" runat="server" Text='<%# Bind("SUBDISTRICT") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم المنطقة: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="REGION_NOLabel" runat="server" Text='<%# Bind("REGION_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم الشارع الفرعي: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SECOND_ST_NOLabel" runat="server" Text='<%# Bind("SECOND_ST_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>اسم الشارع الفرعي: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SECOND_AR_NAMELabel" runat="server" Text='<%# Bind("SECOND_AR_NAME") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>مساحة الشارع الفرعي م2: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="SECOND_ST_AREALabel" runat="server" Text='<%# Bind("SECOND_ST_AREA", "{0:N2}") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم المسح: </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SURVEY_NO") %>' />
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
                                        <asp:Label ID="DIST_CODELabel" runat="server" Text='<%# Bind("DIST_CODE") %>' />
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
                    <asp:ObjectDataSource ID="odsRegionDistress" runat="server" SelectMethod="GetSecondaryStreetDistressInfo"
                        TypeName="JpmmsClasses.BL.DistressEntry.DistressEntry">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="distID" QueryStringField="DistID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--   <asp:SqlDataSource ID="sdsRegionSecondStDistress" runat="server" ConnectionString="<%$ ConnectionStrings:JPMMS_ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:JPMMS_ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MUNIC_NAME&quot;, &quot;DIST_NAME&quot;, &quot;SUBDISTRICT&quot;, &quot;REGION_NO&quot;, &quot;SECOND_ST_NO&quot;, &quot;SECOND_AR_NAME&quot;, &quot;SECOND_ST_AREA&quot;, &quot;SURVEY_DATE&quot;, &quot;DIST_CODE&quot;, &quot;DISTRESS_AR_TYPE&quot;, &quot;DIST_SEVERITY&quot;, &quot;DIST_AREA&quot;, &quot;DIST_DENSITY&quot; FROM &quot;GV_SEC_ST_DISTRESS&quot;">
                    </asp:SqlDataSource>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgPhoto" runat="server" Height="300px" Width="400px" />
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
                                <asp:FileUpload ID="updDistressImage" Width="235px" runat="server" />
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
                                &nbsp;<input type="button" value="إغلاق الصفحة" onclick="javascript:window.close();">
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
