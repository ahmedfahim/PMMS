<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="DefaultRegions.aspx.cs" Inherits="ASPX_Archive_DefaultRegions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.button.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.combobox.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            text-align: right;
        }
        .bold
        {
            text-align: right;
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
                    <strong>المناطق القابلة للمسح </strong>
                </h2>
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
                <table align="center" class="style3">
                    <tr>
                        <td>
                            <b>البلدية </b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="munic_title" DataValueField="munic_id">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;<asp:ObjectDataSource ID="odsRegionInfo" runat="server" SelectMethod="GET_SURVEYABLE"
                                TypeName="JpmmsClasses.BL.Region" UpdateMethod="Update_SURVEYABLE">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlRegions" Name="SUBMUNICIPID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="REGION_NO" Type="String" />
                                    <asp:Parameter Name="REGION_ID" Type="Int32" />
                                    <asp:Parameter Name="SURVEYABLE" Type="Boolean" />
                                    <asp:Parameter Name="NOTES" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="GetAllMunic" TypeName="JpmmsClasses.BL.Municpiality">
                            </asp:ObjectDataSource>
                        </td>
                        <td rowspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CellPadding="4" DataSourceID="odsRegionInfo" EnableModelValidation="True" ForeColor="#333333"
                                GridLines="None" DataKeyNames="REGION_ID" OnRowUpdating="GridView1_RowUpdating">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="REGION_ID" HeaderText="رقم المنطقة الفريد" ReadOnly="True"
                                        SortExpression="REGION_ID" Visible="False" />
                                    <asp:BoundField DataField="REGION_NO" HeaderText="رقم المنطقة" SortExpression="REGION_NO" />
                                    <asp:CheckBoxField DataField="SURVEYABLE" HeaderText="نوع المنطقة" SortExpression="SURVEYABLE" />
                                    <asp:TemplateField HeaderText="ملاحظات">
                                        <EditItemTemplate>
                                            <%--       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NOTES") %>'></asp:TextBox>--%>
                                            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectsNOTES"
                                                DataTextField="NOTES" DataValueField="NOTES" SelectedValue='<%# Bind("NOTES") %>'>
                                                <%-- <asp:ListItem>منطقة بكامل حدود الحي</asp:ListItem>
                                                <asp:ListItem>منطقة جبلية</asp:ListItem>
                                                <asp:ListItem>منطقة مغلقة امنيا</asp:ListItem>
                                                <asp:ListItem>شوارع مغلقة</asp:ListItem>
                                                <asp:ListItem>المدرسة البريطانية</asp:ListItem>
                                                <asp:ListItem>محاطة بسور ترابي</asp:ListItem>
                                                <asp:ListItem>داخل المطار</asp:ListItem>
                                                <asp:ListItem>قصر</asp:ListItem>
                                                <asp:ListItem>القنصلية الكويتية</asp:ListItem>
                                                <asp:ListItem>جامعة الملك عبد العزيز</asp:ListItem>
                                                <asp:ListItem>منطقة مغلقة</asp:ListItem>
                                                <asp:ListItem>ملكية خاصة</asp:ListItem>
                                                <asp:ListItem>عمائر سكنية متلاصقة</asp:ListItem>
                                                <asp:ListItem>مجمع شركة</asp:ListItem>
                                                <asp:ListItem>مجمع مدارس</asp:ListItem>
                                                <asp:ListItem>مستشفي</asp:ListItem>
                                                <asp:ListItem>مدرسة تعليم القيادة</asp:ListItem>
                                                <asp:ListItem>منطقة عسكرية</asp:ListItem>
                                                <asp:ListItem>سجن بريمان</asp:ListItem>
                                                <asp:ListItem>أملاك حكومية</asp:ListItem>
                                                <asp:ListItem>مجمع ارامكو</asp:ListItem>
                                                <asp:ListItem>منطقة ترابية</asp:ListItem>
                                                <asp:ListItem>لايوجد بها شوارع</asp:ListItem>
                                                <asp:ListItem>الهيئة العامه للطيران</asp:ListItem>
                                                <asp:ListItem>قيادة سلاح المشاة</asp:ListItem>
                                                <asp:ListItem>ارض فضاء</asp:ListItem>
                                                <asp:ListItem>منطقة مسورة</asp:ListItem>
                                                <asp:ListItem>المحكمه العامة</asp:ListItem>
                                                <asp:ListItem>شركه المياة</asp:ListItem>
                                                <asp:ListItem>حرس الحدود</asp:ListItem>
                                                <asp:ListItem>مصفاة بترومين</asp:ListItem>
                                                <asp:ListItem>معهد الدفاع الجوي</asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectsNOTES" runat="server" SelectMethod="GetNoteRegions"
                                                TypeName="JpmmsClasses.BL.Region"></asp:ObjectDataSource>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("NOTES") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField CancelText="الغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ" />
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
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
