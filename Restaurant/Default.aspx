﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restaurant.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	<fieldset>
		<legend>Interfaces</legend>
		<asp:Button ID="btnAuthentification" runat="server" Text="Authentification" OnClick="btnAuthentification_Click" Width="200px" />
		<br />
		<asp:Button ID="btnCreationCompte" runat="server" Text="Création compte" Width="200px" OnClick="btnCreationCompte_Click" />
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
