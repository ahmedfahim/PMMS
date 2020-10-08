<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="TrafficEnhanceFiles.aspx.cs"
    Inherits="ASPX_Operations_TrafficEnhances_TrafficEnhanceFiles" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>ملفات مخططات التحسينات المرورية</title>
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
        <br />
        <table border="0" width="700" style="padding: 1px; background-position: bottom; background-repeat: repeat;"
            align="center">
            <tr>
                <td align="center">
                    <h3>
                        <b style="text-align: center">ملفات مخططات التحسينات المرورية</b>
                    </h3>
                </td>
            </tr>
            <!-- Image -->
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsTrafficEnhancesInfo" runat="server" SelectMethod="GetByID"
                        TypeName="JpmmsClasses.BL.TrafficEnhances">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="trafficEnhanceID" QueryStringField="ID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
                        DataKeyNames="RECORD_ID" DataSourceID="odsTrafficEnhancesInfo" ForeColor="#333333"
                        GridLines="None" Height="50px" Width="40%">
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
                </td>
            </tr>
            <!--  new Row -->
            <tr>
                <td>
                    <table width="50%" border="0">
                        <tr>
                            <td width="10%">
                                <b>
                                    <asp:Label ID="Label2" runat="server" Text="الملف" Width="160px"></asp:Label>
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
                                <input type="button" value="إغلاق الصفحة" onclick="javascript:window.close();" />
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
                                <asp:GridView ID="gvIntersectImages" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataKeyNames="RECORD_ID" DataSourceID="odsTrafficEnhanceFiles" ForeColor="#333333"
                                    GridLines="None" AllowPaging="True" OnRowDeleting="gvIntersectImages_RowDeleting"
                                    OnRowUpdating="gvIntersectImages_RowUpdating">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                                            Visible="False" />
                                        <asp:TemplateField HeaderText="الملف" SortExpression="PHOTO_NAME">
                                            <ItemTemplate>
                                                <a id="A1" runat="server" target="_blank" href='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>'>
                                                    ... </a>
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
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsTrafficEnhanceFiles" runat="server" DeleteMethod="DeleteImage"
                                    SelectMethod="GetImages" TypeName="JpmmsClasses.BL.TrafficEnhances" UpdateMethod="UpdateImageDetails"
                                    OnDeleted="odsTrafficEnhanceFiles_Deleted" OnUpdated="odsTrafficEnhanceFiles_Updated">
                                    <DeleteParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                        <asp:Parameter Name="DETAILS" Type="String" />
                                    </UpdateParameters>
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
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
