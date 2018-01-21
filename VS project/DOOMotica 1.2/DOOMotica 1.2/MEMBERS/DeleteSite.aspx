<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="DeleteSite.aspx.cs" Inherits="DOOMotica_1._2.MEMBERS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntnt_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntnt_Body" runat="server">
    
    <asp:Label ID="lbl_user" runat="server" Text=""></asp:Label>
    <asp:Label ID="lbl_text" runat="server" Text=", deze website(s) zijn aan je account verbonden:"></asp:Label>
    <br />
    <asp:Label ID="lbl_Lidnr" runat="server"></asp:Label>
    <br />
    <asp:ListBox ID="lstbx_Websites" runat="server" DataSourceID="Accesdbsrc_WebsitesUser" DataTextField="W_Omschrijving" DataValueField="Webnr" CssClass="Listbox" Height="233px"></asp:ListBox>
    <br />
    <asp:AccessDataSource ID="Accesdbsrc_WebsitesUser" runat="server" DataFile="~/App_Data/Web-Applicatie Database.accdb" SelectCommand="SELECT WEBSITE.W_Omschrijving, WEBSITE.Webnr FROM ((WEBSITE INNER JOIN toegevoegd ON WEBSITE.Webnr = toegevoegd.Webnr) INNER JOIN LID ON toegevoegd.Lidnr = LID.Lidnr)
WHERE LID.Gebruikersnaam = ?">
        <SelectParameters>
            <asp:ControlParameter ControlID="lbl_user" Name="?" PropertyName="Text" Type="String" />
        </SelectParameters>    
    </asp:AccessDataSource>
    
    <asp:Button runat="server" Text="Delete geselecteerde website" ID="btn_Deleterecord" OnClick="Unnamed1_Click" CssClass="Button" />
    </asp:Content>

