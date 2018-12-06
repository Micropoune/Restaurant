<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CreationMenu.aspx.cs" Inherits="Restaurant.CreationMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">

	<fieldset class="menu">
         <legend>Menu</legend> 
		<asp:Label ID="lblNumeroMenu" runat="server" Text="Numero de menu"></asp:Label>
		<asp:TextBox ID="txtNumeroMenu" runat="server"></asp:TextBox>
		
		<br />
		<br />
		 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idProduit" DataSourceID="SqlDataSource1">
			 <Columns>
				 <asp:BoundField DataField="idProduit" HeaderText="idProduit" InsertVisible="False" ReadOnly="True" SortExpression="idProduit" />
				 <asp:BoundField DataField="nomProd" HeaderText="nomProd" SortExpression="nomProd" />
				 <asp:BoundField DataField="descProd" HeaderText="descProd" SortExpression="descProd" />
				 <asp:BoundField DataField="prixProd" HeaderText="prixProd" SortExpression="prixProd" />
			 </Columns>
		 </asp:GridView>
		 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RestaurantConcept.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [idProduit], [nomProd], [descProd], [prixProd] FROM [produits]"></asp:SqlDataSource>
		<br />
			<fieldset class="gestionMets">
				<legend> Gestions mets</legend>
				<br />
				<asp:Button ID="btnAjouterMets" runat="server" Text="Ajouter mets" />
				<asp:Button ID="btnModifierMets" runat="server" Text="Modifier mets" />
				<asp:Button ID="btnDesactiverMets" runat="server" Text="Désactiver mets" />
				<br />
				<asp:TextBox ID="txtRecherche" runat="server"></asp:TextBox>
				<asp:Label ID="lblRecherche" runat="server" Text="Recherche"></asp:Label>
				<br />
			</fieldset>
		<br />
		<br />
		<asp:Button ID="btnEnregistrer" runat="server" Text="Enregistrer" />
		<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" />
		</fieldset>
</asp:Content>
