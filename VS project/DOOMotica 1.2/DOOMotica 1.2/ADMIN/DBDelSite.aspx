<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="DBDelSite.aspx.cs" Inherits="DOOMotica_1._2.ADMIN.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntnt_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntnt_Body" runat="server">


    
    <asp:Label ID="lbl_text" runat="server" Text="Deze website staan in de Database:"></asp:Label>
    <br />
    <br />
    <asp:ListBox ID="lstbx_Websites" runat="server" DataSourceID="Accesdbsrc_WebsitesUser" DataTextField="W_Omschrijving" DataValueField="Webnr" CssClass="Listbox" Height="223px"></asp:ListBox>
    <br />
    <asp:AccessDataSource ID="Accesdbsrc_WebsitesUser" runat="server" DataFile="~/App_Data/Web-Applicatie Database.accdb" SelectCommand="SELECT W_Omschrijving, Webnr FROM WEBSITE">
    </asp:AccessDataSource>
    
    <asp:Button runat="server" Text="Delete geselecteerde website" ID="btn_Deleterecord" OnClick="Unnamed1_Click" CssClass="Button" />



</asp:Content>
