<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="AjoutModifMenu.aspx.cs" Inherits="Restaurant.AjoutModifMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	<fieldset>
	<legend>Menu</legend>
	<asp:Label ID="lblTitreMenu" runat="server" Text="Titre menu :" Width="140px"></asp:Label>
	<asp:TextBox ID="txtTitreMenu" runat="server"></asp:TextBox>
	<br />
	<br />
	<asp:Label ID="status" runat="server" Text="Status :" Width="140px"></asp:Label>
	<asp:DropDownList ID="ddlStatut" runat="server">
		<asp:ListItem Value="1">Actif</asp:ListItem>
		<asp:ListItem Value="0">Inactif</asp:ListItem>
		</asp:DropDownList>
	<br />
	<br />
	<asp:Label ID="lblCommentaires" runat="server" Text="Commentaires :" Width="140px"></asp:Label>
	<asp:TextBox ID="txtCommentaires" runat="server"></asp:TextBox>
	<br />
	<br />
	<asp:Label ID="lblIdResto" runat="server" Text="Restaurant:" Width="140px"></asp:Label>
	<asp:DropDownList ID="ddlResto" runat="server" DataSourceID="SqlDataSource1" DataTextField="nomResto" DataValueField="nomResto"></asp:DropDownList>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [nomResto] FROM [restaurants]"></asp:SqlDataSource>
		<br />
		<br />
		<asp:Button ID="txtEnregistrer" runat="server" OnClick="txtEnregistrer_Click" Text="Enregistrer" Width="140px" />
		<asp:Button ID="btnAnnuler" runat="server" OnClick="btnAnnuler_Click" Text="Annuler" Width="140px" />
	<br />
	<br />
</fieldset>
</asp:Content>
