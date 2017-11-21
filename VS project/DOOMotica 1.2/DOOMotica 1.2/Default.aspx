<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DOOMotica_1._2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblInfo" runat="server" Text="Druk op de knop!"></asp:Label>
    <br />
    <asp:Button ID="btn_DrukHierop" runat="server" OnClick="btn_DrukHierop_Click" Text="Druk Hierop!" />
    <br />
</asp:Content>
