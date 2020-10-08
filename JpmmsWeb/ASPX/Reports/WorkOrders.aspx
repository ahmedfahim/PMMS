<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true" CodeFile="WorkOrders.aspx.cs" Inherits="ASPX_Archive_WorkOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            width: 40%;
        }
        .style4
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <h2 class="style2">
                     <strong>أوامر العمل</strong></h2>
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
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Panel ID="pnlSurveyor"  runat="server">
                  
                    <table align="center">
                        <tr>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="90%">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="style5">
                                  المقاول</td>
                            <td>
                                <asp:DropDownList ID="ddlContractors" runat="server" 
                                    AppendDataBoundItems="True" DataSourceID="odsContractors" DataTextField="CONTRACTOR_NAME" 
                                    DataValueField="CONTRACTOR_No">
                                    <asp:ListItem Value="0">اختيار</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table align="right" class="style4">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="عرض" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="طباعة" />
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
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    EnableModelValidation="True">
                                    <Columns>
                                        <asp:BoundField DataField="CONTRACT_NO" HeaderText="رقم العقد" 
                                            SortExpression="CONTRACT_NO" />
                                        <asp:BoundField DataField="CONTRACT_NAME" HeaderText="اسم العقد" 
                                            SortExpression="CONTRACT_NAME" />
                                        <asp:BoundField DataField="CONTRACTOR_NAME" HeaderText="المقاول" 
                                            SortExpression="CONTRACTOR_NAME" />
                                        <asp:BoundField DataField="CONTRACT_DATE" DataFormatString="{0:MM/dd/yyyy}" 
                                            HeaderText="تاريخ العقد" SortExpression="CONTRACT_DATE" />
                                        <asp:BoundField DataField="CONTRACT_BEGIN" DataFormatString="{0:MM/dd/yyyy}" 
                                            HeaderText="تاريخ بدء التنفيذ" SortExpression="CONTRACT_BEGIN" />
                                        <asp:BoundField DataField="CONTRACT_END" DataFormatString="{0:MM/dd/yyyy}" 
                                            HeaderText="تاريخ الانتهاء" SortExpression="CONTRACT_END" />
                                        <asp:BoundField DataField="HEADING" HeaderText="النوع" 
                                            SortExpression="HEADING" />
                                        <asp:BoundField DataField="DETAILS" HeaderText="الأعمال" 
                                            SortExpression="DETAILS" />
                                        <asp:BoundField DataField="TITLE" HeaderText="العنوان" SortExpression="TITLE" />
                                        <asp:BoundField DataField="STATUS" HeaderText="حالة التنفيذ" 
                                            SortExpression="STATUS" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                           
                        </tr>
                    </table>
                    <br />
                    <asp:ObjectDataSource ID="odsContractors" runat="server" 
                        SelectMethod="GetContractorsList" TypeName="JpmmsClasses.BL.Lookups.Contractor">
                    </asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="style3">
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
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
