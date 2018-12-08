<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="AjoutMofifMets.aspx.cs" Inherits="Restaurant.AjoutMofifMets" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	
	<asp:LinkButton ID="lnkAccueil" runat="server">Accueil</asp:LinkButton>
	<asp:LinkButton ID="lnkDeconnecter" runat="server">Déconnecter</asp:LinkButton>
	<asp:LinkButton ID="lnkConsulterMenu" runat="server">Consulter le menu</asp:LinkButton>
	<fieldset class="Mets">
				<legend> Mets </legend>
				<br />
		<asp:Label ID="lblNumero" runat="server" Text="Numéro :" Width="120px"></asp:Label>
		<asp:TextBox ID="txtIdMets" runat="server"></asp:TextBox>
				<br />
				<br />
		<asp:Label ID="lblNom" runat="server" Text="Nom :" Width="120px"></asp:Label>
		<asp:TextBox ID="txtNomMets" runat="server"></asp:TextBox>
				<br />
				<br />
		<asp:Label ID="lbldescription" runat="server" Text="Description :" Width="120px"></asp:Label>
	
		<asp:TextBox ID="txtDescriptionMet" runat="server" Height="89px"></asp:TextBox>
				<br />
				<br />
		<asp:Label ID="lblPrix" runat="server" Text="Prix" Width="120px"></asp:Label>
		<asp:TextBox ID="txtPrixMets" runat="server"></asp:TextBox>

				<br />
				<br />

	<asp:Button ID="btnEnregistrer" runat="server" Text="Enregistrer" />
	<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" />
	</fieldset>
		<br />
</asp:Content>
