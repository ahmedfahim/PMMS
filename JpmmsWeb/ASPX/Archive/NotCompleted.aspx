<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="NotCompleted.aspx.cs" Inherits="ASPX_Archive_NotCompleted" %>

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
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
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
                    غير مدخلة بمستخلص لمعدة</h2>
                <h2 class="style2">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="LinkErorrSurvey" runat="server" CssClass="notification" NavigateUrl="~/ASPX/Archive/ErorrSurvey.aspx?ID="
                    Target="_blank">
                     المسح غير مطابق <span id="spanErorrData" runat="server" class="badge"></span>
                </asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblSum" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="LENGTH" HeaderText="طول الشارع" SortExpression="LENGTH" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" SortExpression="SURVEY_NO" />
                                   <asp:BoundField DataField="SURVEY_MONTH" HeaderText="شهر المسح" 
                                        SortExpression="SURVEY_MONTH" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:GridView ID="gvErorr" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="LENGTH" HeaderText="طول الشارع" SortExpression="LENGTH" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" SortExpression="SURVEY_NO" />
                                    <%--<asp:BoundField DataField="CLEARANCE" HeaderText="المستخلص" 
                                        SortExpression="CLEARANCE" />--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:GridView ID="gvErorrIRIDDF" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="MAIN_NO" HeaderText="رقم الشارع" SortExpression="MAIN_NO" />
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="LENGTH" HeaderText="طول الشارع" SortExpression="LENGTH" />
                                    <asp:BoundField DataField="SURVEY_NO" HeaderText="المسحة" SortExpression="SURVEY_NO" />
                                    <asp:BoundField DataField="CLEARANCE_IRI" HeaderText="IRI المستخلص" SortExpression="CLEARANCE_IRI" />
                                    <asp:BoundField DataField="CLEARANCE_DDF" HeaderText="DDF المستخلص" SortExpression="CLEARANCE_DDF" />
                                    <asp:CheckBoxField DataField="IS_IRI" HeaderText="مدخل IRI" SortExpression="IS_IRI" />
                                    <asp:CheckBoxField DataField="IS_DDF" HeaderText="مدخل DDF" SortExpression="IS_DDF" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
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
                            &nbsp;
                        </td>
                    </tr>
                </table>
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
