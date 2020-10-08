<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="EquipmentTwelve.aspx.cs" Inherits="ASPX_Archive_EquipmentTwelve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/Icons/load.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 35%; left: 40%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <%--  <tr>
            <td colspan="3" align="center">
                <h3>
                    الشوارع الرئيسية بالنظام</h3>
            </td>
        </tr>--%>
                <tr>
                    <td colspan="3" align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="RadioBtnListClearance" runat="server" RepeatDirection="Horizontal"
                                        AutoPostBack="True" OnSelectedIndexChanged="RadioBtnListClearance_SelectedIndexChanged">
                                        <asp:ListItem Value="True">مستخلصات سابقة</asp:ListItem>
                                        <asp:ListItem Value="False">مستخلصات حالية</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                        Visible="false">
                                        <asp:ListItem Selected="True" Value="0">المعده</asp:ListItem>
                                        <asp:ListItem Value="1">الرسم</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:Button ID="Button1" runat="server" Text="احسب المجموع" OnClick="Button1_Click" />
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="-1">اختيار المجموع </asp:ListItem>
                                        <asp:ListItem Value="4">مدخل بالنظام</asp:ListItem>
                                        <asp:ListItem Value="5">تعديل التحليل</asp:ListItem>
                                        <asp:ListItem Value="6">تعديل الإدخال</asp:ListItem>
                                        <asp:ListItem Value="7">تحت المراجعة</asp:ListItem>
                                        <asp:ListItem Value="8">تم الرسم</asp:ListItem>
                                        <asp:ListItem Value="9">انتظار الرسم</asp:ListItem>
                                        <asp:ListItem Value="10">انتظار العيوب</asp:ListItem>
                                        <asp:ListItem Value="11">خطأ بالملف</asp:ListItem>
                                        <asp:ListItem Value="12">إعادة للمعدة</asp:ListItem>
                                        <asp:ListItem Value="13">ضبط الجودة</asp:ListItem>
                                        <asp:ListItem Value="0">الكل</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblCount" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                            PageSize="15" AllowSorting="True" AutoGenerateColumns="False" OnRowCreated="gvRegionSamplesIRI_RowCreated"
                            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                            OnDataBound="gvRegionSamples_DataBound" OnSorting="gvRegionSamples_Sorting">
                            <Columns>
                                <%-- <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />--%>
                                <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                                <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                                <asp:BoundField DataField="lengthIRI" HeaderText="الطول الممسوحKM" ReadOnly="True"
                                    SortExpression="lengthIRI" />
                                <asp:BoundField DataField="LENGTHSHAPE" HeaderText="الطول المرسومKM" ReadOnly="True"
                                    SortExpression="LENGTHSHAPE" />
                                <asp:CheckBoxField DataField="Finshed" HeaderText="مدخل بالنظام" SortExpression="Finshed" />
                                <asp:CheckBoxField DataField="UPDATING" HeaderText="تعديل التحليل" SortExpression="UPDATING" />
                                <asp:CheckBoxField DataField="EDITING" HeaderText="تعديل الإدخال" SortExpression="EDITING" />
                                <asp:CheckBoxField DataField="IS_REVIEW_DRAWING" HeaderText="تحت المراجعة" SortExpression="IS_REVIEW_DRAWING" />
                                <asp:CheckBoxField DataField="IS_DRAWINGFINSH" HeaderText="تم الرسم" SortExpression="IS_DRAWINGFINSH" />
                                <asp:CheckBoxField DataField="DRAWING" HeaderText="انتظار الرسم" SortExpression="DRAWING" />
                                <asp:CheckBoxField DataField="IS_REVIEW_EDITING" HeaderText="انتظار العيوب" SortExpression="IS_REVIEW_EDITING" />
                                <asp:CheckBoxField DataField="IS_TRANSFARE_ERROR" HeaderText="خطأ بالملف" SortExpression="IS_TRANSFARE_ERROR" />
                                <asp:CheckBoxField DataField="IS_EQUIPMENT" HeaderText="إعادة للمعدة" SortExpression="IS_EQUIPMENT" />
                                <asp:CheckBoxField DataField="IS_QC" HeaderText="ضبط الجودة" SortExpression="IS_QC" />
                            </Columns>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <%--     <asp:Panel ID="pnlSurveyor" runat="server">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="FinshedStreetsMFV"
                        TypeName="JpmmsClasses.BL.MainStreet">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="RadioBtnListClearance" Name="CLEARANCE" 
                                PropertyName="SelectedValue" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>--%>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
