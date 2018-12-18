<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CommanderMets.aspx.cs" Inherits="Restaurant.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">


<asp:ListView ID="lstViewMenu" runat="server" DataSourceID="SqlDataSource1"></asp:ListView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RestaurantConceptConnectionString %>" SelectCommand="SELECT [nomProd], [descProd], [prixProd], [imgProd] FROM [produits]"></asp:SqlDataSource>


<asp:Button ID="Button3" runat="server" Text="Ajouter au panier" OnClick="Button3_Click" />
    <br />
    <br />
<asp:Label ID="Label1" runat="server" Text="Panier"></asp:Label>
<br />
<asp:ListBox ID="lstBox_Panier" runat="server"></asp:ListBox>
    <br />
<asp:Button ID="Button1" runat="server" Text="Annuler" />
<asp:Button ID="Button2" runat="server" Text="Valider" OnClick="Button2_Click" />
    
</asp:Content>
