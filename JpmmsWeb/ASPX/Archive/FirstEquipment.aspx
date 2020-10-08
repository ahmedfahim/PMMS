<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="FirstEquipment.aspx.cs" Inherits="ASPX_Archive_FirstEquipment" %>

<%@ Register Assembly="UtilitiesLibrary" Namespace="UtilitiesLibrary.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Without
        {
            background-color: #555;
            color: Yellow;
            text-decoration: none;
            padding: 10px 21px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            width: 120px;
            top: 0px;
            right: 0px;
        }
        .Without:hover
        {
            background: none;
            color: black;
        }
        .notification
        {
            background-color: #555;
            color: white;
            text-decoration: none;
            padding: 10px 21px;
            position: relative;
            display: inline-block;
            border-radius: 2px;
            width: 120px;
            top: 0px;
            right: 0px;
        }
        
        .notification:hover
        {
            background: Aqua;
            color: Black;
        }
        
        .notification .badge
        {
            position: absolute;
            top: -10px;
            right: -10px;
            padding: 5px 10px;
            border-radius: 50%;
            background-color: red;
            color: white;
        }
        .notifyBall
        {
            display: block;
            -webkit-border-radius: 30px;
            -moz-border-radius: 30px;
            border-radius: 30px;
            background-color: #FFF;
            -webkit-box-shadow: 1px 1px 5px #808080;
            -moz-box-shadow: 1px 1px 5px #808080;
            box-shadow: 1px 1px 5px #808080;
            padding: 10px;
            width: 30px;
            height: 30px;
            margin: 0 auto;
            line-height: 30px;
            text-align: center;
            position: relative;
            -webkit-border-radius: 20px;
            -moz-border-radius: 20px;
            border-radius: 20px;
            border: 2px solid #FFF;
            width: 5px;
            height: 4px;
            background-color: #226598;
            position: relative;
            top: -25px;
            right: 30px;
            font-size: 10px;
            line-height: 7px;
            font-family: 'Roboto' , sans-serif;
            font-weight: 400;
            color: #FFF;
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                    استلام&nbsp; الشوارع الرئيسية</h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:HyperLink ID="HyperLink27" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/UpdateIRIValidate.aspx"
                    Target="_blank">
                    بيانات تحتاج التعديل <span id="spanErorrData" runat="server" class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <cc1:OneClickButton ID="BtnSHAPE" runat="server" OnClick="BtnSHAPE_Click" Text="تحديث الرسم"
                    ReplaceTitleTo="يرجى الإنتظار" />
                <cc1:OneClickButton ID="BtnIRI" runat="server" OnClick="BtnIRI_Click" Text="تحديث المعدة"
                    ReplaceTitleTo="يرجى الإنتظار" />
                <cc1:OneClickButton ID="BtnSectionsIRI" runat="server" OnClick="BtnSectionsIRI_Click"
                    Text="تحديث التفاصيل" ReplaceTitleTo="يرجى الإنتظار" />
                <cc1:OneClickButton ID="BtnFinshed" runat="server" OnClick="BtnFinshed_Click" Text="تحديث الإدخال النهائي للمعدات"
                    ReplaceTitleTo="يرجى الإنتظار" />
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" DataSourceID="ObjectDataSource1"
                    AutoGenerateColumns="False" DataKeyNames="MAIN_NO" OnDataBound="gvRegionSamples_DataBound"
                    OnSelectedIndexChanging="gvRegionSamples_SelectedIndexChanging" OnRowDeleting="gvRegionSamples_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                        <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                        <asp:CheckBoxField DataField="ROWDATA" HeaderText="مدخل علي النظام" ReadOnly="True"
                            SortExpression="ROWDATA" />
                        <asp:CommandField SelectText="حذف" ShowSelectButton="True" />
                        <asp:CommandField DeleteText="خطأ بالملف" ShowDeleteButton="True" />
                        <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" ReadOnly="True" SortExpression="SURVEY_NO" />
                          <asp:BoundField DataField="TypeOfEquipment" HeaderText="المعدة" ReadOnly="True" SortExpression="TypeOfEquipment" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <%--<asp:GridView ID="gvRegionSamples" runat="server" CellPadding="4" EnableModelValidation="True"
                    ForeColor="#333333" GridLines="None" PageSize="15" AllowSorting="True" DataSourceID="ObjectDataSource1"
                    AutoGenerateColumns="False" ondatabound="gvRegionSamples_DataBound" 
                    onselectedindexchanging="gvRegionSamples_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="م" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" ReadOnly="True" SortExpression="MAIN_NO" />
                         <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" ReadOnly="True" SortExpression="ARNAME" />
                        <asp:CheckBoxField DataField="DATAENTRYFINSH" HeaderText="مدخل علي النظام" SortExpression="DATAENTRYFINSH" />
                        <asp:CommandField SelectText="حذف" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor" runat="server">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetFinshedSTREETSMFV"
                        TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>
                    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRecivedIRI"
                        TypeName="JpmmsClasses.BL.MainStreet"></asp:ObjectDataSource>--%>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
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
