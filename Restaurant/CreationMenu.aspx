<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CreationMenu.aspx.cs" Inherits="Restaurant.CreationMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
	<asp:LinkButton ID="lnkAccueil" runat="server" OnClick="lnkAccueil_Click">Accueil</asp:LinkButton>
	<asp:LinkButton ID="lnkDeconnecter" runat="server" OnClick="lnkDeconnecter_Click">Déconnecter</asp:LinkButton>
	<asp:LinkButton ID="lnkGestionMenu" runat="server" OnClick="lnkGestionMenu_Click">Gestion menu</asp:LinkButton>
	<fieldset class="menu">
         <legend>Menu</legend> 
		
		<br />
		<asp:Label ID="lblTitreMenu" runat="server" Text="Titre du menu" Width="150px"></asp:Label>
		
		
		 <asp:DropDownList ID="ddlMenu" runat="server" DataSourceID="SqlDataSource2" DataTextField="titreMenu" DataValueField="idMenu" AutoPostBack="True">
         </asp:DropDownList>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [idMenu], [titreMenu] FROM [menus]"></asp:SqlDataSource>
		
		
		 <br />
		<br />
        <asp:TextBox ID="txtMessage" runat="server" BorderStyle="None" ForeColor="Red" Width="647px"></asp:TextBox>
        <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/fleche.png" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#D5EAFF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
			<fieldset class="gestionMets">
				<legend> Gestions mets</legend>
				<br />
				<asp:Button ID="btnAjouterMets" runat="server" Text="Ajouter mets" OnClick="btnAjouterMets_Click" />
				<asp:Button ID="btnModifierMets" runat="server" Text="Modifier mets" OnClick="btnModifierMets_Click" />
				<asp:Button ID="btnDesactiverMets" runat="server" Text="Désactiver mets" OnClick="btnDesactiverMets_Click" />
				<br />
				<br />
				<asp:TextBox ID="txtRecherche" runat="server"></asp:TextBox>
				<asp:Label ID="lblRecherche" runat="server" Text="Recherche"></asp:Label>
				<br />
			</fieldset>
		<br />
		<br />
		<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" />
		</fieldset>
</asp:Content>
