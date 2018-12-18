<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="Restaurant.Accueil" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">

    <h2>Bienvenue dans notre restaurant</h2>
    <div class="BtnAccueil">
		<asp:Button ID="btnAuthentification" runat="server" Text="Authentification" OnClick="btnAuthentification_Click" Width="250px" CssClass="BtnAccueil" />
		<asp:Button ID="btnCreationCompte" runat="server" Text="Création d'un compte" OnClick="btnCreationCompte_Click" Width="250px" CssClass="BtnAccueil" />
		
		<br />
	</div>

</asp:Content>