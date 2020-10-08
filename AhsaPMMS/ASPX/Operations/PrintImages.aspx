<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintImages.aspx.cs" Inherits="ASPX_Operations_PrintImages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p align="center">
            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <asp:GridView ID="gvImages" runat="server" AutoGenerateColumns="False" DataKeyNames="RECORD_ID"
        DataSourceID="odsImages" EnableModelValidation="True" PageSize="20" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" SortExpression="RECORD_ID"
                Visible="False" />
            <asp:TemplateField ShowHeader="False" SortExpression="PHOTO_NAME">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PHOTO_NAME") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a href='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>' runat="server" rel="lightbox" id="imgHref">
                        <asp:Image runat="server" ID="imPhoto" Width="600" Height="400" AlternateText='<% #Eval("DETAILS") %>'
                            ImageUrl='<%# "~/Uploads/"+ Eval("PHOTO_NAME") %>' />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsImages" runat="server" SelectMethod="GetImages" TypeName="JpmmsClasses.BL.ImagesGallery">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="mid" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="0" Name="RegionID" QueryStringField="rid"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
