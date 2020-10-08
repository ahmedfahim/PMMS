<%@ Page Title="تقييم الأنفاق والجسور" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master"
    AutoEventWireup="true" CodeFile="TunnelBridgesEval.aspx.cs" Inherits="ASPX_Operations_TunnelBridgesEval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style2">
                <h2>
                    <b>تقييم الأنفاق والجسور</b></h2>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>بيانات الجسر/النفق </b>
            </td>
            <td>
                &nbsp;<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
                    CellPadding="4" DataSourceID="odsBridgeTunnelInfo" ForeColor="#333333" GridLines="None"
                    Height="50px" Width="30%">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="HEADER" HeaderText="النوع" ReadOnly="True" SortExpression="HEADER" />
                        <asp:BoundField DataField="NAME" HeaderText="الاسم" SortExpression="NAME" />
                        <asp:BoundField DataField="MAIN_STREET_NAME" HeaderText="اسم الشارع الرئيسي" SortExpression="MAIN_STREET_NAME" />
                        <asp:BoundField DataField="LOC_NO" HeaderText="رقم الموقع" ReadOnly="True" SortExpression="LOC_NO" />
                        <asp:BoundField DataField="BRIDGE_LOCATION" HeaderText="الموقع" SortExpression="BRIDGE_LOCATION" />
                        <asp:BoundField DataField="TITLE1" ReadOnly="True" SortExpression="TITLE1" />
                        <asp:BoundField DataField="TITLE2" ReadOnly="True" SortExpression="TITLE2" />
                    </Fields>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:DetailsView>
                <asp:ObjectDataSource ID="odsBridgeTunnelInfo" runat="server" SelectMethod="GetInfo"
                    TypeName="JpmmsClasses.BL.BridgeTunnelEvaluation">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="bridgeID" QueryStringField="bridgeID" Type="Int32" />
                        <asp:QueryStringParameter Name="tunnelID" QueryStringField="tunnelID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                &nbsp;
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="RECORD_ID" DataSourceID="odsEvaluation"
                    DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting">
                    <EditItemTemplate>
                        RECORD_ID:
                        <asp:Label ID="RECORD_IDLabel1" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                        <br />
                        BRIDGE_ID:
                        <asp:TextBox ID="BRIDGE_IDTextBox" runat="server" Text='<%# Bind("BRIDGE_ID") %>' />
                        <br />
                        TUNNEL_ID:
                        <asp:TextBox ID="TUNNEL_IDTextBox" runat="server" Text='<%# Bind("TUNNEL_ID") %>' />
                        <br />
                        ELEMENT_ID:
                        <asp:TextBox ID="ELEMENT_IDTextBox" runat="server" Text='<%# Bind("ELEMENT_ID") %>' />
                        <br />
                        EVAL_ID:
                        <asp:TextBox ID="EVAL_IDTextBox" runat="server" Text='<%# Bind("EVAL_ID") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <b>العنصر </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlElement" runat="server" DataSourceID="odsElements" DataTextField="B_ELEMENT_NAME"
                                        DataValueField="B_ELEMENT_ID" SelectedValue='<%# Bind("ELEMENT_ID") %>' AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlElement"
                                        ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValidationGroup="eval" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>التقييم </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEval" runat="server" DataSourceID="odBridgeTunnelEvalCriteria"
                                        DataTextField="CRITERIA_title" DataValueField="CRITERIA_ID" SelectedValue='<%# Bind("EVAL_ID") %>'
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">اختيار</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlEval"
                                        ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValidationGroup="eval" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>تفاصيل </b>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DETAILS") %>' TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        Text="حفظ" ValidationGroup="eval" CssClass="style3" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="إلغاء" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        RECORD_ID:
                        <asp:Label ID="RECORD_IDLabel" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                        <br />
                        BRIDGE_ID:
                        <asp:Label ID="BRIDGE_IDLabel" runat="server" Text='<%# Bind("BRIDGE_ID") %>' />
                        <br />
                        TUNNEL_ID:
                        <asp:Label ID="TUNNEL_IDLabel" runat="server" Text='<%# Bind("TUNNEL_ID") %>' />
                        <br />
                        ELEMENT_ID:
                        <asp:Label ID="ELEMENT_IDLabel" runat="server" Text='<%# Bind("ELEMENT_ID") %>' />
                        <br />
                        EVAL_ID:
                        <asp:Label ID="EVAL_IDLabel" runat="server" Text='<%# Bind("EVAL_ID") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:GridView ID="gvEval" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="odsEvaluation" ForeColor="#333333" GridLines="None"
                    DataKeyNames="RECORD_ID" OnSelectedIndexChanged="gvEval_SelectedIndexChanged"
                    OnRowDeleting="gvEval_RowDeleting" OnRowUpdating="gvEval_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" SortExpression="RECORD_ID"
                            Visible="False" />
                        <asp:BoundField DataField="B_ELEMENT_NAME" HeaderText="العنصر" ReadOnly="True" SortExpression="B_ELEMENT_NAME" />
                        <asp:TemplateField HeaderText="التقييم" SortExpression="CRITERIA_title">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEval1" runat="server" AppendDataBoundItems="True" DataSourceID="odBridgeTunnelEvalCriteria"
                                    DataTextField="CRITERIA_title" DataValueField="CRITERIA_ID" SelectedValue='<%# Bind("EVAL_ID") %>'>
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlEval1"
                                    ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValidationGroup="eval"></asp:CompareValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CRITERIA_title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DETAILS" HeaderText="تفاصيل" SortExpression="DETAILS" />
                        <asp:CommandField CancelText="إلغاء" EditText="تعديل" ShowEditButton="True" UpdateText="حفظ"
                            ValidationGroup="editel" />
                        <asp:CommandField SelectText="العيوب" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <%--  <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsEvaluation" runat="server" DeleteMethod="DeleteElementEvaluation"
                    InsertMethod="InsertElementEvaluation" SelectMethod="Search" TypeName="JpmmsClasses.BL.BridgeTunnelEvaluation"
                    UpdateMethod="UpdateElementEvaluation" OnDeleted="odsEvaluation_Deleted" OnInserted="odsEvaluation_Inserted"
                    OnUpdated="odsEvaluation_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:QueryStringParameter Name="BRIDGE_ID" QueryStringField="bridgeID" Type="Int32" />
                        <asp:QueryStringParameter Name="TUNNEL_ID" QueryStringField="tunnelID" Type="Int32" />
                        <asp:Parameter Name="ELEMENT_ID" Type="Int32" />
                        <asp:Parameter Name="EVAL_ID" Type="Int32" />
                        <asp:Parameter Name="DETAILS" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="bridgeID" QueryStringField="bridgeID" Type="Int32" />
                        <asp:QueryStringParameter Name="tunnelID" QueryStringField="tunnelID" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                        <asp:Parameter Name="EVAL_ID" Type="Int32" />
                        <asp:Parameter Name="DETAILS" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDistress" runat="server" SelectMethod="GetBridgeTunnelDistressTypes"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odBridgeTunnelEvalCriteria" runat="server" SelectMethod="GetBridgeTunnelEvalCriteria"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsElements" runat="server" SelectMethod="GetBridgeTunnelElements"
                    TypeName="JpmmsClasses.BL.Lookups.BridgeTunnelLookups">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="bridgeID" QueryStringField="bridgeID" Type="Int32" />
                        <asp:QueryStringParameter Name="tunnelID" QueryStringField="tunnelID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel runat="server" ID="pnlDist" Visible="false">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:FormView ID="FormView2" runat="server" DataKeyNames="RECORD_ID" DataSourceID="odsEvalDistresses"
                                    DefaultMode="Insert" OnItemInserting="FormView2_ItemInserting">
                                    <EditItemTemplate>
                                        RECORD_ID:
                                        <asp:Label ID="RECORD_IDLabel1" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                                        <br />
                                        BRIDGE_ID:
                                        <asp:TextBox ID="BRIDGE_IDTextBox" runat="server" Text='<%# Bind("BRIDGE_ID") %>' />
                                        <br />
                                        TUNNEL_ID:
                                        <asp:TextBox ID="TUNNEL_IDTextBox" runat="server" Text='<%# Bind("TUNNEL_ID") %>' />
                                        <br />
                                        BT_DISTRESS_TYPE_ID:
                                        <asp:TextBox ID="BT_DISTRESS_TYPE_IDTextBox" runat="server" Text='<%# Bind("BT_DISTRESS_TYPE_ID") %>' />
                                        <br />
                                        EVAL_RECORD_ID:
                                        <asp:TextBox ID="EVAL_RECORD_IDTextBox" runat="server" Text='<%# Bind("EVAL_RECORD_ID") %>' />
                                        <br />
                                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" />
                                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" />
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    <b>اسم العيب </b>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlDist" runat="server" DataSourceID="odsDistress" DataTextField="DISTRESS_title"
                                                        DataValueField="DISTRESS_TYPE_ID" SelectedValue='<%# Bind("BT_DISTRESS_TYPE_ID") %>'
                                                        AppendDataBoundItems="True">
                                                        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlDist"
                                                        ErrorMessage="الرجاء الاختيار" Operator="NotEqual" ValidationGroup="dist" ValueToCompare="0"></asp:CompareValidator>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                                        Text="حفظ" ValidationGroup="dist" CssClass="style3" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                        Text="إلغاء" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        RECORD_ID:
                                        <asp:Label ID="RECORD_IDLabel" runat="server" Text='<%# Eval("RECORD_ID") %>' />
                                        <br />
                                        BRIDGE_ID:
                                        <asp:Label ID="BRIDGE_IDLabel" runat="server" Text='<%# Bind("BRIDGE_ID") %>' />
                                        <br />
                                        TUNNEL_ID:
                                        <asp:Label ID="TUNNEL_IDLabel" runat="server" Text='<%# Bind("TUNNEL_ID") %>' />
                                        <br />
                                        BT_DISTRESS_TYPE_ID:
                                        <asp:Label ID="BT_DISTRESS_TYPE_IDLabel" runat="server" Text='<%# Bind("BT_DISTRESS_TYPE_ID") %>' />
                                        <br />
                                        EVAL_RECORD_ID:
                                        <asp:Label ID="EVAL_RECORD_IDLabel" runat="server" Text='<%# Bind("EVAL_RECORD_ID") %>' />
                                        <br />
                                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" />
                                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                                            Text="New" />
                                    </ItemTemplate>
                                </asp:FormView>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="direction: rtl">
                                <asp:GridView ID="gvDistress" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="RECORD_ID" DataSourceID="odsEvalDistresses" ForeColor="#333333"
                                    GridLines="None" OnRowDeleting="gvDistress_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="حذف"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="DISTRESS_TITLE" HeaderText="العيب" ReadOnly="True" SortExpression="DISTRESS_TITLE" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                  <%--  <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsEvalDistresses" runat="server" DeleteMethod="DeleteEvalDistress"
                                    InsertMethod="InsertEvalDistress" SelectMethod="GetEvalDistress" TypeName="JpmmsClasses.BL.BridgeTunnelEvaluation"
                                    OnDeleted="odsEvalDistresses_Deleted" OnInserted="odsEvalDistresses_Inserted">
                                    <DeleteParameters>
                                        <asp:Parameter Name="RECORD_ID" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:QueryStringParameter Name="BRIDGE_ID" QueryStringField="bridgeID" Type="Int32" />
                                        <asp:QueryStringParameter Name="TUNNEL_ID" QueryStringField="tunnelID" Type="Int32" />
                                        <asp:Parameter Name="BT_DISTRESS_TYPE_ID" Type="Int32" />
                                        <asp:ControlParameter ControlID="gvEval" Name="EVAL_RECORD_ID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvEval" Name="EVAL_RECORD_ID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
