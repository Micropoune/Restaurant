<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restaurant.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	<asp:LinkButton ID="lnkDeconnecter" runat="server" OnClick="lnkDeconnecter_Click">Déconnecter</asp:LinkButton>
	<fieldset>
		<legend>Interfaces</legend>
		<br />
		<asp:Button ID="btnCreationMenu" runat="server" Text="Création d'un menu" OnClick="btnCreationMenu_Click" Width="200px" />
		<br />
		<asp:Button ID="btnCommanderMets" runat="server" Text="Commander mets" OnClick="btnCommanderMets_Click" Width="200px" />
		<br />
		<asp:Button ID="btnCreerMets" runat="server" Text="Créer un mets" OnClick="btnCreerMets_Click" Width="200px" />
		<br />
		<asp:Button ID="btnListeCommande" runat="server" Text="Liste des commandes " Width="200px" OnClick="btnListeCommande_Click" />

	</fieldset>
</asp:Content>
