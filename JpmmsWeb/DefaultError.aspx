<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Services.master" AutoEventWireup="true"
    CodeFile="DefaultError.aspx.cs" Inherits="DefaultError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p dir="ltr">
        <asp:Literal ID="ltrFeedback" runat="server"></asp:Literal>
    </p>
</asp:Content>
