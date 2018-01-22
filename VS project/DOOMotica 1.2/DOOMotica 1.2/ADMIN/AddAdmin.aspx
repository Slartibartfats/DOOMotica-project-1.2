<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="DOOMotica_1._2.ADMIN.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntnt_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntnt_Body" runat="server">


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
     <asp:Label ID="lbl_Rol" runat="server" Text="Welke rol?"></asp:Label>
     <br />
     <asp:DropDownList ID="ddl_Rol" runat="server" DataSourceID="AccesDBsrc_Rollen" DataTextField="Omschrijving" DataValueField="Rolnr">
     </asp:DropDownList>
     <br />
            <br />
            <asp:ValidationSummary ID="vldtnsmmr_CreateUser" runat="server" DisplayMode="List" Font-Bold="True" />
            <asp:AccessDataSource ID="AccesDBsrc_Rollen" runat="server" DataFile="~/App_Data/Web-Applicatie Database.accdb" OnSelecting="AccesDBsrc_Rollen_Selecting" SelectCommand="SELECT [Rolnr], [Omschrijving] FROM [ROL]"></asp:AccessDataSource>
            <br />
            <br />
            <asp:Button ID="btn_Create" runat="server" Text="Create" OnClick="btn_Create_Click" CssClass="Button" /><asp:Label ID="lbl_gelukt" runat="server" Text=""></asp:Label>



</asp:Content>
