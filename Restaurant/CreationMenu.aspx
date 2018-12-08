<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CreationMenu.aspx.cs" Inherits="Restaurant.CreationMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	<asp:LinkButton ID="lnkAccueil" runat="server" OnClick="lnkAccueil_Click">Accueil</asp:LinkButton>
	<asp:LinkButton ID="lnkDeconnecter" runat="server" OnClick="lnkDeconnecter_Click">Déconnecter</asp:LinkButton>
	<asp:LinkButton ID="lnkGestionMenu" runat="server" OnClick="lnkGestionMenu_Click">Gestion menu</asp:LinkButton>
	<fieldset class="menu">
         <legend>Menu</legend> 
		<asp:Label ID="lblNumeroMenu" runat="server" Text="Numero de menu" Width="150px"></asp:Label>
		<asp:TextBox ID="txtIdMenu" runat="server"></asp:TextBox>
		 <asp:CustomValidator ID="valNomUnique" runat="server" ControlToValidate="txtIdMenu" ErrorMessage="Ce numero de menu existe deja" OnServerValidate="valNomUnique_ServerValidate" ValidationGroup="ValidationGroupeChamps">*</asp:CustomValidator>
		
		<br />
		<asp:Label ID="lblTitreMenu" runat="server" Text="Titre du menu" Width="150px"></asp:Label>
		
		
		 <asp:TextBox ID="txtDescriptionMenu" runat="server"></asp:TextBox>
		
		
		 <br />
		<br />
		 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idProduit" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
			 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
			 <Columns>
				 <asp:BoundField DataField="idProduit" HeaderText="idProduit" InsertVisible="False" ReadOnly="True" SortExpression="idProduit" />
				 <asp:BoundField DataField="nomProd" HeaderText="nomProd" SortExpression="nomProd" />
				 <asp:BoundField DataField="descProd" HeaderText="descProd" SortExpression="descProd" />
				 <asp:BoundField DataField="prixProd" HeaderText="prixProd" SortExpression="prixProd" />
			 </Columns>
		 	<EditRowStyle BackColor="#999999" />
			 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
			 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
			 <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
			 <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
			 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			 <SortedAscendingCellStyle BackColor="#E9E7E2" />
			 <SortedAscendingHeaderStyle BackColor="#506C8C" />
			 <SortedDescendingCellStyle BackColor="#FFFDF8" />
			 <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
		 </asp:GridView>
		 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RestaurantConcept.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [idProduit], [nomProd], [descProd], [prixProd] FROM [produits]"></asp:SqlDataSource>
		<br />
			<fieldset class="gestionMets">
				<legend> Gestions mets</legend>
				<br />
				<asp:Button ID="btnAjouterMets" runat="server" Text="Ajouter mets" OnClick="btnAjouterMets_Click" />
				<asp:Button ID="btnModifierMets" runat="server" Text="Modifier mets" />
				<asp:Button ID="btnDesactiverMets" runat="server" Text="Désactiver mets" />
				<br />
				<asp:TextBox ID="txtRecherche" runat="server"></asp:TextBox>
				<asp:Label ID="lblRecherche" runat="server" Text="Recherche"></asp:Label>
				<br />
			</fieldset>
		<br />
		<br />
		<asp:Button ID="btnEnregistrer" runat="server" Text="Enregistrer" OnClick="btnEnregistrer_Click" />
		<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" />
		</fieldset>
</asp:Content>
