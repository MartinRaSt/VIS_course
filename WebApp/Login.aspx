<%@ Page Title="Přihlášení" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <table style="width:50%;">
        <tr>
            <td style="width: 75px"><asp:Label ID="Label1" runat="server" Text="Jméno"></asp:Label></td>
            <td><asp:TextBox ID="edJmeno" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px"><asp:Label ID="Label2" runat="server" Text="Heslo"></asp:Label></td>
            <td><asp:TextBox ID="edHeslo" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px"><asp:Button ID="btnLogin" runat="server" Text="Přihlásit" OnClick="btnLogin_Click" /></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    
    
</asp:Content>
