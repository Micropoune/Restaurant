<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="AfficherCommande.aspx.cs" Inherits="Restaurant.AfficherCommande" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">

    <div id="lien">
        <asp:LinkButton ID="BtnAccueil" runat="server" >Accueil</asp:LinkButton>
        <asp:LinkButton ID="BtnDeconnecter" runat="server">Déconnecter</asp:LinkButton>
        <asp:LinkButton ID="BtnListeCde" runat="server">Liste des commandes</asp:LinkButton>
    </div>


   <div>
        <div class="Commande">
            <asp:Label ID="lblInfoCommande" runat="server" Text="Commande : " Width="166px"></asp:Label>
            <asp:TextBox ID="infoCommande" runat="server" Width="769px" BorderStyle="None" Height="49px" ReadOnly="True" TextMode="MultiLine" Font-Names="Adobe Caslon Pro" Font-Size="Medium"></asp:TextBox>
        </div>
        <asp:GridView ID="gvDetailCde" runat="server" AutoGenerateColumns="False">
            <Columns>
            </Columns>
        </asp:GridView>
        <br />
    </div>
</asp:Content>
