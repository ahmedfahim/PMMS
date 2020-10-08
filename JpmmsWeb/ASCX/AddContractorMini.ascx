<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddContractorMini.ascx.cs"
    Inherits="ASCX_AddContractorMini" %>
<p dir="rtl">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="CONTRACTOR_ID" DataSourceID="odsContractor"
        DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting">
        <EditItemTemplate>
            CONTRACTOR_ID:
            <asp:Label ID="CONTRACTOR_IDLabel1" runat="server" Text='<%# Eval("CONTRACTOR_ID") %>' />
            <br />
            CONTRACTOR_NO:
            <asp:TextBox ID="CONTRACTOR_NOTextBox" runat="server" Text='<%# Bind("CONTRACTOR_NO") %>' />
            <br />
            CONTRACTOR_NAME:
            <asp:TextBox ID="CONTRACTOR_NAMETextBox" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
            <br />
            PHONE:
            <asp:TextBox ID="PHONETextBox" runat="server" Text='<%# Bind("PHONE") %>' />
            <br />
            FAX:
            <asp:TextBox ID="FAXTextBox" runat="server" Text='<%# Bind("FAX") %>' />
            <br />
            MOBILE:
            <asp:TextBox ID="MOBILETextBox" runat="server" Text='<%# Bind("MOBILE") %>' />
            <br />
            EMAIL:
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table width="30%">
                <tr>
                    <td>
                        اسم المقاول
                    </td>
                    <td>
                        <asp:TextBox ID="CONTRACTOR_NAMETextBox" Width="120px" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="contractor"
                            ControlToValidate="CONTRACTOR_NAMETextBox" runat="server" ErrorMessage="الرجاء إدخال الاسم "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        رقم المقاول
                    </td>
                    <td>
                        <asp:TextBox ID="CONTRACTOR_NOTextBox" Width="120px" runat="server" Text='<%# Bind("CONTRACTOR_NO") %>' />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        رقم الهاتف
                    </td>
                    <td>
                        <asp:TextBox ID="PHONETextBox" Width="120px" runat="server" Text='<%# Bind("PHONE") %>' />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        فاكس
                    </td>
                    <td style="margin-right: 80px">
                        <asp:TextBox ID="FAXTextBox" Width="120px" runat="server" Text='<%# Bind("FAX") %>' />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        جوال
                    </td>
                    <td style="margin-right: 80px">
                        <asp:TextBox ID="MOBILETextBox" Width="120px" runat="server" Text='<%# Bind("MOBILE") %>' />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        بريد الكتروني
                    </td>
                    <td style="margin-right: 160px">
                        <asp:TextBox ID="EMAILTextBox" Width="120px" runat="server" Text='<%# Bind("EMAIL") %>' />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            ValidationGroup="contractor" Text="حفظ" />
                    </td>
                    <td style="margin-right: 160px">
                        <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="إلغاء" OnClick="InsertCancelButton_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
        <ItemTemplate>
            CONTRACTOR_ID:
            <asp:Label ID="CONTRACTOR_IDLabel" runat="server" Text='<%# Eval("CONTRACTOR_ID") %>' />
            <br />
            CONTRACTOR_NO:
            <asp:Label ID="CONTRACTOR_NOLabel" runat="server" Text='<%# Bind("CONTRACTOR_NO") %>' />
            <br />
            CONTRACTOR_NAME:
            <asp:Label ID="CONTRACTOR_NAMELabel" runat="server" Text='<%# Bind("CONTRACTOR_NAME") %>' />
            <br />
            PHONE:
            <asp:Label ID="PHONELabel" runat="server" Text='<%# Bind("PHONE") %>' />
            <br />
            FAX:
            <asp:Label ID="FAXLabel" runat="server" Text='<%# Bind("FAX") %>' />
            <br />
            MOBILE:
            <asp:Label ID="MOBILELabel" runat="server" Text='<%# Bind("MOBILE") %>' />
            <br />
            EMAIL:
            <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New" />
        </ItemTemplate>
    </asp:FormView>
</p>
<p dir="rtl">
    <asp:Label ID="lblFeedback" runat="server" ForeColor="Red"></asp:Label>
    <asp:ObjectDataSource ID="odsContractor" runat="server" DeleteMethod="Delete" InsertMethod="InsertNewContractor"
        OnInserted="odsContractor_Inserted" SelectMethod="GetAllContractorsList" TypeName="JpmmsClasses.BL.Lookups.Contractor"
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="CONTRACTOR_ID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CONTRACTOR_NAME" Type="String" />
            <asp:Parameter Name="PHONE" Type="String" />
            <asp:Parameter Name="FAX" Type="String" />
            <asp:Parameter Name="MOBILE" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="CONTRACTOR_NO" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CONTRACTOR_NAME" Type="String" />
            <asp:Parameter Name="PHONE" Type="String" />
            <asp:Parameter Name="FAX" Type="String" />
            <asp:Parameter Name="MOBILE" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="CONTRACTOR_NO" Type="String" />
            <asp:Parameter Name="CONTRACTOR_ID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</p>
