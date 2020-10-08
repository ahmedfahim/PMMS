<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="ReadyFWD.aspx.cs" Inherits="ASPX_Archive_ReadyFWD" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SelectAll(CheckBoxControl, Control) {



            if (CheckBoxControl.checked == true) {

                var i;

                for (i = 0; i < document.forms[0].elements.length; i++) {



                    if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].id.includes('ChkBoxDelete')) &&



                    (document.forms[0].elements[i].name.indexOf('' + Control + '') > -1)) {

                        if (document.forms[0].elements[i].disabled) {

                            document.forms[0].elements[i].checked = false;

                        }

                        else {

                            document.forms[0].elements[i].checked = true;

                        }

                    }

                }

            }

            else {

                var i;

                for (i = 0; i < document.forms[0].elements.length; i++) {



                    if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].id.includes('ChkBoxDelete')) &&



                    (document.forms[0].elements[i].name.indexOf('' + Control + '') > -1)) {

                        document.forms[0].elements[i].checked = false;

                    }

                }

            }

        }
        function InsertAll(CheckBoxControl, Control) {



            if (CheckBoxControl.checked == true) {

                var i;

                for (i = 0; i < document.forms[0].elements.length; i++) {



                    if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].id.includes('ChkBoxSave')) &&



                    (document.forms[0].elements[i].name.indexOf('' + Control + '') > -1)) {

                        if (document.forms[0].elements[i].disabled) {

                            document.forms[0].elements[i].checked = false;

                        }

                        else {

                            document.forms[0].elements[i].checked = true;

                        }

                    }

                }

            }

            else {

                var i;

                for (i = 0; i < document.forms[0].elements.length; i++) {



                    if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].id.includes('ChkBoxSave')) &&



                    (document.forms[0].elements[i].name.indexOf('' + Control + '') > -1)) {

                        document.forms[0].elements[i].checked = false;

                    }

                }

            }

        }
    </script>
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
                    &nbsp;معالجة الحمل الساقط &nbsp; FWD</h2>
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
                <table align="center" class="style3">
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblSumReadyFWDNULL" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblSumReadyFWDTrue" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblSumReadyFWDFalse" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;
                            <asp:Label ID="lblSum" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>الشارع الرئيسي </b>
                        </td>
                        <td>
                             <asp:DropDownList ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="MAIN_NO" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                            </asp:DropDownList>
                             <%--  <telerik:RadComboBox Filter="Contains" Width="75px" Font-Size="Medium" AutoselectFirstItem="True"
                                ID="ddlRegions" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="odsRegions" DataTextField="MAIN_NO" DataValueField="STREET_ID"
                                OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="اختيار" Value="0" />
                                </Items>
                            </telerik:RadComboBox>--%>&nbsp;<asp:Button ID="BtnFinshed" runat="server" OnClick="BtnFinshed_Click" Text="تم الإنتهاء "
                                Visible="False" />
                            <asp:Label ID="lblFeedback0" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;<asp:ObjectDataSource ID="odsRegions" runat="server" SelectMethod="ReadyFWD"
                                TypeName="JpmmsClasses.BL.MainStreet">
                                <SelectParameters>
                                    <asp:Parameter Name="MAIN_NO" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;
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
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:GridView ID="gvRegionIRI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" EnableModelValidation="True" PageSize="15">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ARNAME" HeaderText="اسم الشارع" SortExpression="ARNAME" />
                                    <asp:BoundField DataField="COUNTSECTION" HeaderText="المقاطع من النظام" SortExpression="COUNTSECTION" />
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
                            <asp:GridView ID="gvFWD" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" EnableModelValidation="True" PageSize="15" AllowSorting="True"
                                GridLines="None" DataKeyNames="RECORD_ID" OnSelectedIndexChanging="gvFWD_SelectedIndexChanging"
                                OnRowDeleting="gvFWD_RowDeleting">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="DROP_ID" HeaderText="DID" />
                                    <asp:BoundField DataField="STATION_ID" HeaderText="SID" />
                                    <asp:BoundField DataField="D1" HeaderText="D1" />
                                    <asp:BoundField DataField="ASPHALT_TEMPERATURE" HeaderText="الإسفلت" />
                                    <asp:BoundField DataField="SURFACE_TEMPERATURE" HeaderText="السطح" />
                                    <asp:BoundField DataField="AIR_TEMPERATURE" HeaderText="الهواء" />
                                    <asp:BoundField DataField="SURVEY_TIME" HeaderText="الوقت" />
                                    <asp:BoundField DataField="SURVEY_DATE" HeaderText="التاريخ" />
                                    <asp:BoundField DataField="STATION" HeaderText="المحطة" />
                                    <asp:TemplateField HeaderText="الحارة">
                                        <ItemTemplate>
                                            <asp:Label ID="LblLANE" runat="server" Text='<%# Eval("LANE") %>'></asp:Label>
                                            <asp:DropDownList ID="DrpDwnListLane" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="-1">الحارة</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="رقم المقطع">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSECTION_NO" runat="server" Text='<%# Eval("SECTION_NO") %>'></asp:Label>
                                            <asp:DropDownList ID="DrpDwnListSection" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="-1">المقطع</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField SelectText="إضافة" ShowSelectButton="True" />
                                    <asp:BoundField DataField="RECORD_ID" Visible="False" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkInsert" runat="server" Checked="false" onclick="InsertAll(this,'gvFWD')"
                                                Text="الكل" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBoxSave" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField DataField="FINSHED" HeaderText="النظام" />
                                    <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" Checked="false" onclick="SelectAll(this,'gvFWD')"
                                                Text="الكل" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBoxDelete" runat="server" BackColor="Red" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
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
