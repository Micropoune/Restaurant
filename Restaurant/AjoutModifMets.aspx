<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="AjoutModifMets.aspx.cs" Inherits="Restaurant.AjoutMofifMets" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	
	<asp:LinkButton ID="lnkAccueil" runat="server" OnClick="lnkAccueil_Click" CssClass="BtnAccueil">Accueil</asp:LinkButton>
	<asp:LinkButton ID="lnkDeconnecter" runat="server" OnClick="lnkDeconnecter_Click" CssClass="BtnDeconnecter">Déconnecter</asp:LinkButton>
	<asp:LinkButton ID="lnkConsulterMenu" runat="server" OnClick="lnkConsulterMenu_Click">Consulter le menu</asp:LinkButton>
	<fieldset class="Mets">
				<legend> Mets </legend>
				<br />
		<asp:ValidationSummary ID="ValidationAjoutMets" runat="server" ForeColor="Red" ValidationGroup="ValidationAjoutMets"/>
				<br />
		<asp:Label ID="lblCategorie" runat="server" Text="Catégorie :" Width="120px"></asp:Label>
			<asp:DropDownList ID="ddlCategorie" runat="server" DataSourceID="DSCategories" DataTextField="nomCategorie" DataValueField="nomCategorie"></asp:DropDownList>
				<asp:SqlDataSource ID="DSCategories" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [nomCategorie] FROM [categories]"></asp:SqlDataSource>
				<br />
				<br />
		<asp:Label ID="lblNom" runat="server" Text="Nom :" Width="120px"></asp:Label>
		<asp:TextBox ID="txtNomMets" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ID="ValidateurNomMets" ValidationGroup="ValidationAjoutMets" runat="server" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red" ControlToValidate="txtNomMets">*</asp:RequiredFieldValidator>
				<br />
				<br />
		<asp:Label ID="lbldescription" runat="server" Text="Description :" Width="120px"></asp:Label>
	
		<asp:TextBox ID="txtDescriptionMet" runat="server" Height="89px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="ValidateurDescription" ValidationGroup="ValidationAjoutMets" runat="server" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red" ControlToValidate="txtDescriptionMet">*</asp:RequiredFieldValidator>
				<br />
				<br />
				<asp:Label ID="Label1" runat="server" Text="Image :" Width="120px"></asp:Label>
				<asp:FileUpload ID="FUploadImg" runat="server" />
		<asp:Button ID="btnImporter" runat="server" Text="Importer" OnClick="btnImporter_Click" />
		<asp:Image ID="Image" runat="server" />
				<asp:Label ID="lblImageAImporter" runat="server" Text="Selectionner une image à importer"></asp:Label>
				<br />
					
		<br />
				<br />
		<asp:Label ID="lblPrix" runat="server" Text="Prix" Width="120px"></asp:Label>
		<asp:TextBox ID="txtPrixMets" runat="server"></asp:TextBox>

		<asp:RequiredFieldValidator ID="ValidateurPrix" ValidationGroup="ValidationAjoutMets" runat="server" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red" ControlToValidate="txtPrixMets">*</asp:RequiredFieldValidator>

				<br />
				<br />

	<asp:Button ID="btnEnregistrer" runat="server" Text="Enregistrer" OnClick="btnEnregistrer_Click" Width="100px" ValidationGroup="ValidationAjoutMets" />
	<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" Width="100px" />
	</fieldset>
		<br />
</asp:Content>
