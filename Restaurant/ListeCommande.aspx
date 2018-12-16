<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="ListeCommande.aspx.cs" Inherits="Restaurant.ListeCommande" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    
    
    <div id="lien">
        <asp:LinkButton ID="BtnAccueil" runat="server" >Accueil</asp:LinkButton>
        <asp:LinkButton ID="BtnDeconnecter" runat="server">Déconnecter</asp:LinkButton>
        <asp:LinkButton ID="BtnGererRestaurant" runat="server">Gérer restaurant</asp:LinkButton>
    </div>

    <div class="Restaurant">
        
        <asp:Label ID="Restaurant" runat="server" Text="Restaurant : "> </asp:Label>
        
        <asp:TextBox ID="txtNomResto" runat="server" Width="482px" BorderStyle="None"></asp:TextBox>
        
    </div>

   

    <fieldset class="Mets">
        <div class="EtatCommande">
            <asp:Label ID="lblEtatCommande" runat="server" Text="Etat Commande : " Width="120px"></asp:Label>
            <asp:DropDownList ID="ddlEtatCommande" runat="server" DataSourceID="DSEtatCommande" DataTextField="Etat" DataValueField="idEtat" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="DSEtatCommande" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RestaurantConcept.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [idEtat], [Etat] FROM [etatcommandes]"></asp:SqlDataSource>
        </div>
        <div class="Commande">
            <asp:Label ID="lblNumCommande" runat="server" Text="N° Commande : " Width="120px"></asp:Label>
            <asp:TextBox ID="numCommande" runat="server" Width="80px"></asp:TextBox>
        </div>
        <br />
    </fieldset>

     <h2>Liste des commandes</h2>

    <div>
        <asp:TextBox ID="txtMessage" runat="server" BorderStyle="None" ForeColor="Red" Width="647px"></asp:TextBox>
        <asp:GridView ID="gvCommandes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCommandes_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/fleche.png" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>


    <div>

       
        <asp:Button ID="btnAfficher" runat="server" CssClass="bouton" OnClick="btnAfficher_Click" Text="Afficher" Width="150px" />
        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" Width="150px" />
        <br />
    

    </div>
    </asp:Content>