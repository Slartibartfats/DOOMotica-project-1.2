<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DOOMotica_1._2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_ConnFeedBack" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
    <br />
    <asp:TextBox ID="txt_Username" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <br />
    <asp:TextBox ID="txt_Password" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click" />


</asp:Content>
