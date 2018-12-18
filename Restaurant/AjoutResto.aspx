<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="AjoutResto.aspx.cs" Inherits="Restaurant.AjoutResto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    
    <asp:Label ID="lbl_Titre" runat="server" Text="Gestion des Restaurants"></asp:Label>
    <br />
    <div style="height:20px;border-bottom:1px dotted blue;">
        <div style="float:left;">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idResto" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="idResto" HeaderText="idResto" InsertVisible="False" ReadOnly="True" SortExpression="idResto" />
                    <asp:BoundField DataField="nomResto" HeaderText="nomResto" SortExpression="nomResto" />
                    <asp:BoundField DataField="idAdrs" HeaderText="idAdrs" SortExpression="idAdrs" />
                    <asp:BoundField DataField="Actif" HeaderText="Actif" SortExpression="Actif" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RestaurantConceptConnectionString %>" SelectCommand="SELECT [idResto], [nomResto], [idAdrs], [Actif] FROM [restaurants]"></asp:SqlDataSource>
        </div>
   
        <div>    
        <asp:Button ID="btn_AjouterResto" runat="server" Text="Ajouter un Restaurant" OnClick="btn_AjouterResto_Click" Width="250px" />
            <br />
        <asp:Button ID="btn_ModifierResto" runat="server" Text="Modifier un Restaurant" OnClick="btn_ModifierResto_Click" Width="250px" />
        <br />
        <asp:Button ID="btn_DesactiverResto" runat="server" Text="Desactiver un Restaurant" CssClass="auto-style1" OnClick="btn_DesactiverResto_Click" Width="250px" />
    </div>
    </div>
    
    <br />
    
       
</asp:Content>
