<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DaHausV3.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:RadioButtonList ID="rdbt_Lamps" runat="server" OnSelectedIndexChanged="rdbt_Lamps_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Lamp 0</asp:ListItem>
        <asp:ListItem>Lamp 1</asp:ListItem>
        <asp:ListItem>Lamp 2</asp:ListItem>
        <asp:ListItem>Lamp 3</asp:ListItem>
        <asp:ListItem>Lamp 4</asp:ListItem>
        <asp:ListItem>Window 0</asp:ListItem>
        <asp:ListItem>Window 1</asp:ListItem>
        <asp:ListItem>Heater</asp:ListItem>
        <asp:ListItem>All Lamps</asp:ListItem>
        <asp:ListItem>All Windows</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RadioButtonList ID="rdbt_OnOff" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem>On</asp:ListItem>
        <asp:ListItem>Off</asp:ListItem>
        <asp:ListItem>Status</asp:ListItem>
        <asp:ListItem>Where is</asp:ListItem>
        <asp:ListItem>Open</asp:ListItem>
        <asp:ListItem>Close</asp:ListItem>
        <asp:ListItem>Amount</asp:ListItem>
        <asp:ListItem>Heater Temp</asp:ListItem>
    </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;Heater temp:
    <asp:TextBox ID="txt_Heater" runat="server"></asp:TextBox>
&nbsp;<p>
        <asp:Button ID="btn_Send" runat="server" OnClick="btn_Send_Click" Text="Send" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Response" runat="server" Height="227px" ReadOnly="True" TextMode="MultiLine" Width="669px"></asp:TextBox>
    </p>
</asp:Content>

