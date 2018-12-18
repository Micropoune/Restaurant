<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="testCommanderMet.aspx.cs" Inherits="Restaurant.testCommanderMet" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idCommande" DataSourceID="SqlDataSource1">
		<Columns>
			<asp:BoundField DataField="idCommande" HeaderText="idCommande" InsertVisible="False" ReadOnly="True" SortExpression="idCommande" />
			<asp:BoundField DataField="datecommande" HeaderText="datecommande" SortExpression="datecommande" />
			<asp:BoundField DataField="idetat" HeaderText="idetat" SortExpression="idetat" />
			<asp:BoundField DataField="descProd" HeaderText="descProd" SortExpression="descProd" />
			<asp:BoundField DataField="nomProd" HeaderText="nomProd" SortExpression="nomProd" />
			<asp:BoundField DataField="noCommande" HeaderText="noCommande" SortExpression="noCommande" />
			<asp:BoundField DataField="noProduit" HeaderText="noProduit" SortExpression="noProduit" />
			<asp:BoundField DataField="qte" HeaderText="qte" SortExpression="qte" />
			<asp:BoundField DataField="prixProd" HeaderText="prixProd" SortExpression="prixProd" />
		</Columns>
	</asp:GridView>
	
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT commandes.idCommande, commandes.datecommande, commandes.idetat, commandes.idModePaiement, produits.descProd, produits.nomProd, items_commande.noCommande, items_commande.noProduit, items_commande.qte, produits.prixProd FROM commandes INNER JOIN items_commande ON commandes.idCommande = items_commande.noCommande INNER JOIN produits ON items_commande.noProduit = produits.idProduit"></asp:SqlDataSource>
	
</asp:Content>
