<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CommanderMets.aspx.cs" Inherits="Restaurant.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">


<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RestaurantConceptConnectionString %>" SelectCommand="SELECT [nomProd], [descProd], [prixProd], [imgProd] FROM [produits]"></asp:SqlDataSource>


    <br />
    <asp:GridView ID="gv_Menu" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="nomProd" HeaderText="nomProd" SortExpression="nomProd" />
            <asp:BoundField DataField="descProd" HeaderText="descProd" SortExpression="descProd" />
            <asp:BoundField DataField="prixProd" HeaderText="prixProd" SortExpression="prixProd" />
            <asp:BoundField DataField="imgProd" HeaderText="imgProd" SortExpression="imgProd" />
        </Columns>
    </asp:GridView>
    <br />
    

<asp:Button ID="btn_Ajouter_au_Panier" runat="server" Text="Ajouter au panier" OnClick="Button3_Click" />


<asp:Button ID="Button4" runat="server" Text="Retirer du panier" OnClick="Button3_Click" />
    <br />
    
<asp:Label ID="Label1" runat="server" Text="Panier"></asp:Label>
    <br />
    <asp:GridView ID="gv_panier" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/fleche.png" ShowSelectButton="True" />
            </Columns>
    </asp:GridView>
<br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    <br />
<asp:Button ID="Button1" runat="server" Text="Annuler" OnClick="Button1_Click" />
<asp:Button ID="Button2" runat="server" Text="Valider" OnClick="Button2_Click" />
    </asp:Content>
