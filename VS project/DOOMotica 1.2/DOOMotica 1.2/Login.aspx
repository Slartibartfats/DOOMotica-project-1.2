<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DOOMotica_1._2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mltvw_Login" runat="server" ActiveViewIndex="0">
    <!-- Hier wordt een de Login control geplaatst in een view. -->
        <asp:View ID="vw_login" runat="server">
            <asp:TextBox ID="txt_Username" runat="server"> </asp:TextBox><asp:Label ID="lbl_Username" runat="server" Text="   USERNAME"></asp:Label> 
            <br />
            <asp:TextBox ID="txt_Password" runat="server"> </asp:TextBox><asp:Label ID="lbl_Password" runat="server" Text="    PASSWORD"></asp:Label> 
            <br />
            <asp:Button ID="btn_CreateUser" runat="server" Text="Create a new user" OnClick="btn_CreateUser_Click1" /><asp:Button ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click" />
        </asp:View>
        <asp:View ID="vw_createuser" runat="server">
            <asp:TextBox ID="txt_User" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rqrdvldtr_User" runat="server" ControlToValidate="txt_User" ErrorMessage="User did not fill in a new Username" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:Label ID="lbl_User" runat="server" Text="Username (6-18 tekens)"></asp:Label>
            <br />
            <asp:TextBox ID="txt_Pass" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rqrdvldtr_Pass" runat="server" ControlToValidate="txt_Pass" ErrorMessage="User did not fill in a new Password" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:Label ID="lbl_Pass" runat="server" Text="Password (minimaal 6 tekens waarvan 1 hoofdletter en maximaal 15 tekens)"></asp:Label>
            <br />
            <asp:TextBox ID="txt_ConfirmPass" runat="server"></asp:TextBox>            <asp:RequiredFieldValidator ID="rqrdvldtr_ConfirmPass" runat="server" ControlToValidate="txt_Pass" ErrorMessage="You have to put in tou password a second time" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:Label ID="lbl_ConformPass" runat="server" Text="Confirm Password"></asp:Label>
            <asp:CompareValidator ID="cmprvldtr_Pass" runat="server" ControlToCompare="txt_ConfirmPass" ControlToValidate="txt_Pass" ErrorMessage="User did not give equal passwords" Font-Bold="True">Passwords aren&#39;t the same!</asp:CompareValidator>
            <br />
            <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rqrdvldtr_Email" runat="server" ControlToValidate="txt_Email" ErrorMessage="User did not fill in an Email" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:Label ID="lbl_email" runat="server" Text="E-mailadres"></asp:Label>
            <br />
            <asp:Button ID="btn_Create" runat="server" Text="Create" OnClick="btn_Create_Click" /><asp:Button ID="btn_Terug" runat="server" Text="Terug naar het inlogscherm" OnClick="btn_Terug_Click"/><asp:Label ID="lbl_gelukt" runat="server" Text=""></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>
