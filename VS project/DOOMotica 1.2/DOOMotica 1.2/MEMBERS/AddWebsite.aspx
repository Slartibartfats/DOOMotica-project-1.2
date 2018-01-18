<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="AddWebsite.aspx.cs" Inherits="DOOMotica_1._2.MEMBERS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntnt_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntnt_Body" runat="server">

    <asp:MultiView ID="mltvw_AddSite" runat="server" ActiveViewIndex="0">
        <asp:View ID="AddSite" runat="server">
            <asp:Label ID="lbl_Kiezen" runat="server" Text="Je kan ook 1 website kiezen van deze dropdownlist:"></asp:Label>
            <br />
            <asp:DropDownList ID="ddl_Voorbeeldlinkjes" runat="server" AutoPostBack="True" DataSourceID="AccdbSourceWebsites" DataTextField="Website_naam" DataValueField="URLnr" OnSelectedIndexChanged="ddl_Voorbeeldlinkjes_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lbl_Hyperlink"  runat="server" Text="Hyperlink: "></asp:Label><br /><asp:TextBox ID="txt_Hyperlink" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqrdfldvldtr_Hyperlink" runat="server" ControlToValidate="txt_Hyperlink" ErrorMessage="Je moet een Hyperlink opgeven"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lbl_NaamWebsite" runat="server" Text="Naam Website: "></asp:Label><br /><asp:TextBox ID="txt_NaamWebsite" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqrdfldvldtr_NaamWebsite" runat="server" ErrorMessage="Je moet een naam geven invullen" ControlToValidate="txt_NaamWebsite"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lbl_URLPlaatje" runat="server" Text="URL plaatje: "></asp:Label><br /><asp:TextBox ID="txt_URLplaatje" runat="server"></asp:TextBox>
            
            <br />
            <asp:ValidationSummary ID="vldtnsmmr_ErrorAddSite" runat="server" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Home" runat="server" Text="Terug" CausesValidation="False" OnClick="btn_terug_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_VoegToe" runat="server" Text="Voeg toe" OnClick="btn_VoegToe_Click" />
            <br />

        </asp:View>
        <asp:View ID="AddSiteconfirm" runat="server">



            <asp:Label ID="lbl_toegevoegd" runat="server" Text="Je website is succesvol toegevoegd! Druk op onderstaande knop om terug naar je dashbord te gaan."></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="btn_terug" runat="server" OnClick="btn_terug_Click" Text="Terug naar het webdashboard" />



        </asp:View>
       
    </asp:MultiView>
 <asp:AccessDataSource runat="server" DataFile="~/App_Data/Web-Applicatie Database.accdb" SelectCommand="SELECT [URLnr], [Website_naam] FROM [WEBSITES]" ID="AccdbSourceWebsites"></asp:AccessDataSource>

</asp:Content>
