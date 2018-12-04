<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CreationMenu.aspx.cs" Inherits="Restaurant.CreationMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">

	<fieldset class="login">
         <legend>Menu</legend> 
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idMenu" DataSourceID="SqlDataSource1">
			<Columns>
				<asp:BoundField DataField="idMenu" HeaderText="idMenu" InsertVisible="False" ReadOnly="True" SortExpression="idMenu" />
				<asp:BoundField DataField="titreMenu" HeaderText="titreMenu" SortExpression="titreMenu" />
				<asp:BoundField DataField="actif" HeaderText="actif" SortExpression="actif" />
				<asp:BoundField DataField="commentaires" HeaderText="commentaires" SortExpression="commentaires" />
				<asp:BoundField DataField="idResto" HeaderText="idResto" SortExpression="idResto" />
			</Columns>
		 </asp:GridView>
		 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [menus]"></asp:SqlDataSource>
		 <asp:LinqDataSource ID="LinqDataSource1" runat="server">
		 </asp:LinqDataSource>
	</fieldset>

</asp:Content>
