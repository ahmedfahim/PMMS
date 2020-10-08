<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedbackFiles.aspx.cs" Inherits="ASPX_Operations_FeedbackFiles" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>إضافة/تعديل مرفقات عملية صيانة عناصر شبكة الطرق</title>
    <link href="../../Css/GeneralStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
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
        <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <table border="0" width="700" style="padding: 1px; background-position: bottom; background-repeat: repeat;"
            align="center">
            <tr>
                <td>
                    <h2 class="style1">
                        <b>إضافة/تعديل مرفقات عملية صيانة عناصر شبكة الطرق</b></h2>
                </td>
            </tr>
            <!-- Image -->
            <tr>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="odsFeedbacks" EnableModelValidation="True">
                        <EditItemTemplate>
                            FEEDBACK_ID:
                            <asp:TextBox ID="FEEDBACK_IDTextBox" runat="server" Text='<%# Bind("FEEDBACK_ID") %>' />
                            <br />
                            CONTRACT_NO:
                            <asp:TextBox ID="CONTRACT_NOTextBox" runat="server" Text='<%# Bind("CONTRACT_NO") %>' />
                            <br />
                            CONTRACTOR_NAME:
                            <asp:TextBox ID="CONTRACTOR_NAMETextBox" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                            <br />
                            JOB_ORDER_NO:
                            <asp:TextBox ID="JOB_ORDER_NOTextBox" runat="server" Text='<%# Bind("JOB_ORDER_NO") %>' />
                            <br />
                            JOB_ORDER_DATE:
                            <asp:TextBox ID="JOB_ORDER_DATETextBox" runat="server" Text='<%# Bind("JOB_ORDER_DATE") %>' />
                            <br />
                            FINISH_DATE:
                            <asp:TextBox ID="FINISH_DATETextBox" runat="server" Text='<%# Bind("FINISH_DATE") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            FEEDBACK_ID:
                            <asp:TextBox ID="FEEDBACK_IDTextBox" runat="server" Text='<%# Bind("FEEDBACK_ID") %>' />
                            <br />
                            CONTRACT_NO:
                            <asp:TextBox ID="CONTRACT_NOTextBox" runat="server" Text='<%# Bind("CONTRACT_NO") %>' />
                            <br />
                            CONTRACTOR_NAME:
                            <asp:TextBox ID="CONTRACTOR_NAMETextBox" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                            <br />
                            JOB_ORDER_NO:
                            <asp:TextBox ID="JOB_ORDER_NOTextBox" runat="server" Text='<%# Bind("JOB_ORDER_NO") %>' />
                            <br />
                            JOB_ORDER_DATE:
                            <asp:TextBox ID="JOB_ORDER_DATETextBox" runat="server" Text='<%# Bind("JOB_ORDER_DATE") %>' />
                            <br />
                            FINISH_DATE:
                            <asp:TextBox ID="FINISH_DATETextBox" runat="server" Text='<%# Bind("FINISH_DATE") %>' />
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
                                        <b>رقم العقد</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="CONTRACT_NOLabel" runat="server" Text='<%# Bind("CONTRACT_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>المقاول</b>
                                    </td>
                                    <td style="margin-right: 40px">
                                        <asp:Label ID="CONTRACTOR_NAMELabel" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>رقم أمر العمل</b>
                                    </td>
                                    <td style="margin-right: 40px">
                                        <asp:Label ID="JOB_ORDER_NOLabel" runat="server" Text='<%# Bind("JOB_ORDER_NO") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>تاريخ أمر العمل</b>
                                    </td>
                                    <td style="margin-right: 40px">
                                        <asp:Label ID="JOB_ORDER_DATELabel" runat="server" Text='<%# Bind("JOB_ORDER_DATE", "{0:d}") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>تاريخ التنفيذ</b>
                                    </td>
                                    <td style="margin-right: 40px">
                                        <asp:Label ID="FINISH_DATELabel" runat="server" Text='<%# Bind("FINISH_DATE", "{0:d}") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="odsFeedbacks" runat="server" SelectMethod="GetFeedbackByID"
                        TypeName="JpmmsClasses.BL.MaintenanceFeedback">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
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
