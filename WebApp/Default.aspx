<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Informační systém knihovna</h2>
        <p class="lead">Ukázka implementace UI funkcionality</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h3>Aktuálně přihlášený uživatel</h3>
            <p>
               <asp:Label ID="laLoggedUser" runat="server" Text="Nepřihlášen"></asp:Label>
            </p>
        </div>
    </div>

</asp:Content>
