<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DOOMotica_1._2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntnt_Head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntnt_Body" runat="server">
    <div class="LeftColumn"></div>
    <div class="MiddleColumn">


<asp:MultiView ID="mltvw_Login" runat="server" ActiveViewIndex="0">
    <!-- Hier wordt een de Login control geplaatst in een view. -->
        <asp:View ID="vw_login" runat="server">
            <asp:Label ID="lbl_Username" runat="server" Text="USERNAME"></asp:Label><br /><asp:TextBox ID="txt_Username" runat="server"> </asp:TextBox> 
            <br />
            <asp:Label ID="lbl_Password" runat="server" Text="PASSWORD"></asp:Label><br /><asp:TextBox ID="txt_Password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btn_CreateUser" runat="server" Text="Create a new user" OnClick="btn_CreateUser_Click1" /><asp:Button ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click" />
        </asp:View>

        <!-- Hier wordt de Create User view geplaats -->
        <asp:View ID="vw_createuser" runat="server">
            <asp:Label ID="lbl_User" runat="server" Text="Username (6-18 tekens)"></asp:Label>
            &nbsp;&nbsp;<br />
            <asp:TextBox ID="txt_User" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqrdvldtr_User" runat="server" ControlToValidate="txt_User" ErrorMessage="Vul een username in!" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regex_User" runat="server" ControlToValidate="txt_User" ErrorMessage="  Username invalide (Moet tussen 6-18 letters/cijfers zijn en alleen '_'-teken mag)" Font-Bold="True" ValidationExpression="([A-Z|a-z|0-9|_]{6,18})">*</asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lbl_Pass" runat="server" Text="Password (6-15 tekens waarvan 1 hoofdletter en 1 cijfer)"></asp:Label><br />
            <asp:TextBox ID="txt_Pass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqrdvldtr_Pass" runat="server" ControlToValidate="txt_Pass" ErrorMessage="Vul een wachtwoord in!" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regex_Password" runat="server" ControlToValidate="txt_Pass" ErrorMessage="Password invalide (6-15 cijfers/letters waarvan minimaal 1 hoofdletter)" Font-Bold="True" ValidationExpression="^(?=.*\d)(?=.*[A-Z])(.{6,15})$">*</asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lbl_ConformPass" runat="server" Text="Confirm Password"></asp:Label>
            &nbsp;<br /><asp:TextBox ID="txt_ConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;
            <asp:CompareValidator ID="cmprvldtr_Pass" runat="server" ControlToCompare="txt_ConfirmPass" ControlToValidate="txt_Pass" ErrorMessage="User did not give equal passwords" Font-Bold="True">*</asp:CompareValidator>
            <br />
            <asp:Label ID="lbl_email" runat="server" Text="E-mailadres"></asp:Label>&nbsp;&nbsp;<br />
            
            <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqrdvldtr_Email" runat="server" ControlToValidate="txt_Email" ErrorMessage="Vul een Email in!" Font-Bold="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regex_Email" runat="server" ControlToValidate="txt_Email" ErrorMessage="Email Invalide" Font-Bold="True" ValidationExpression="([A-Z|a-z|0-9](\.|_){0,1})+[A-Z|a-z|0-9]\@([A-Z|a-z|0-9])+((\.){0,1}[A-Z|a-z|0-9]){2}\.[a-z]{2,3}">*</asp:RegularExpressionValidator>
            <br />
            <asp:ValidationSummary ID="vldtnsmmr_CreateUser" runat="server" DisplayMode="List" Font-Bold="True" />
            <br />
            <br />
            <asp:Button ID="btn_Create" runat="server" Text="Create" OnClick="btn_Create_Click" /><asp:Button ID="btn_Terug" runat="server" Text="Terug naar het inlogscherm" OnClick="btn_Terug_Click" CausesValidation="False"/><asp:Label ID="lbl_gelukt" runat="server" Text=""></asp:Label>
        </asp:View>
        <asp:View ID="vw_gebruiker" runat="server">
            <asp:Label ID="lbl_Appeltjeeitje" runat="server" Font-Bold="True" Text="Alles is netjes weggeschreven, druk op de knop om verder te gaan met inloggen. :)"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btn_TerugLogin" runat="server" Text="Terug" OnClick="btn_TerugLogin_Click" Width="133px" />

        </asp:View>
    </asp:MultiView>


    </div>
    <div class="RightColumn"></div>

    
</asp:Content>
