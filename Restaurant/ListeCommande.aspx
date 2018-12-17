<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="ListeCommande.aspx.cs" Inherits="Restaurant.ListeCommande" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    
    <div></div>
    <div>
        <asp:LinkButton ID="BtnAccueil" runat="server" OnClick="BtnAccueil_Click" CssClass="BtnAccueil">Accueil</asp:LinkButton>
        <asp:LinkButton ID="BtnDeconnecter" runat="server" OnClick="BtnDeconnecter_Click" CssClass="BtnDeconnecter">Déconnecter</asp:LinkButton>
    </div>
    <div></div>
    <div id="Restaurant" class="Restaurant">
        
        <asp:Label runat="server" Text="Restaurant : " Font-Bold="True" Font-Size="Large" ></asp:Label>
        
        <asp:TextBox runat="server" Width="749px" BorderStyle="None" ID="txtNomResto" Font-Bold="True" Font-Size="Large"></asp:TextBox>
        
    </div>

   

    <fieldset class="Mets">
        <div class="EtatCommande">
            <asp:Label ID="lblEtatCommande" runat="server" Text="Etat Commande : " Width="120px"></asp:Label>
            <asp:DropDownList ID="ddlEtatCommande" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="RechCommande">
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