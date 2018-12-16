<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="ListeCommande.aspx.cs" Inherits="Restaurant.ListeCommande" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    
    
    <div id="lien">
        <asp:LinkButton ID="BtnAccueil" runat="server" OnClick="BtnAccueil_Click">Accueil</asp:LinkButton>
        <asp:LinkButton ID="BtnDeconnecter" runat="server" OnClick="BtnDeconnecter_Click">Déconnecter</asp:LinkButton>
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

       
        <asp:Button ID="btnAfficher" runat="server" CssClass="bouton" OnClick="btnAfficher_Click" Text="Afficher" Width="150px" />
        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" Width="150px" OnClick="btnAnnuler_Click" />
        <br />
    

    </div>
    <div>
        <asp:TextBox ID="txtMessage" runat="server" BorderStyle="None" ForeColor="Red" Width="647px"></asp:TextBox>
        <asp:GridView ID="gvCommandes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCommandes_SelectedIndexChanged">
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
    </div>


    
    </asp:Content>