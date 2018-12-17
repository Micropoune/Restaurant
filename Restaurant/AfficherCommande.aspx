<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="AfficherCommande.aspx.cs" Inherits="Restaurant.AfficherCommande" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">

    
    <div >
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BtnAccueil_Click" CssClass="BtnAccueil" >Accueil</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BtnDeconnecter_Click" CssClass="BtnDeconnecter">Déconnecter</asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="BtnListeCde_Click">Liste des commandes</asp:LinkButton>
   
    </div>
        
    <div>
        <asp:TextBox ID="txtTypeCpte" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
        <asp:TextBox ID="txtEtatCde" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
    </div>
   
    <fieldset id="idInfoCde" class="idInfoCde">
        <div>
            <asp:Label ID="lblInfoCommande0" runat="server" Text="N° Commande : " Width="166px"></asp:Label>
            <asp:TextBox ID="txtNumCde" runat="server" BorderStyle="None" ReadOnly="True" ForeColor="Black"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblInfoCommande" runat="server" Text="Client : " Width="92px"></asp:Label>
            <asp:TextBox ID="txtNomClient" runat="server" Width="354px" BorderStyle="None" Height="32px" ReadOnly="True" TextMode="SingleLine" Font-Names="Adobe Caslon Pro" Font-Size="Medium" CssClass="txtNomClient" ></asp:TextBox>
            <br />
            <asp:TextBox ID="txtAdrClient" runat="server" Width="354px" BorderStyle="None" Height="32px" ReadOnly="True" TextMode="SingleLine" Font-Names="Adobe Caslon Pro" Font-Size="Medium" CssClass="txtAdrClient" ></asp:TextBox>
        </div>
            
    </fieldset>
    
    <div>
        <asp:TextBox ID="txtMessage" runat="server" BorderStyle="None" ForeColor="Red" ReadOnly="True" Width="925px"></asp:TextBox>
    </div>

    <asp:GridView ID="gvDetailCde" runat="server" AutoGenerateColumns="False" Width="806px">
            <Columns>
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
    <br />
    <div>
        <asp:Label ID="lblTotal" runat="server" Text="Montant Total :" style="text-align: right;" Width="534px"></asp:Label>
        <asp:TextBox ID="txtMntTotal" runat="server" BorderStyle="None" Width="265px" ReadOnly="True" style="text-align: right;"></asp:TextBox>
    </div>
        
    <div>
        <asp:Label ID="lblTPS" runat="server" Text="TPS :" style="text-align: right;" Width="534px"></asp:Label>
        <asp:TextBox ID="txtTPS" runat="server" BorderStyle="None" Width="265px" style="text-align: right;"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblTVQ" runat="server" Text="TVQ :" style="text-align: right;" Width="534px"></asp:Label>
        <asp:TextBox ID="txtTVQ" runat="server" BorderStyle="None" Width="265px" style="text-align: right;"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblMntAPayer" runat="server" Text="Montant à payer :" style="text-align: right;" Width="534px"></asp:Label>
        <asp:TextBox ID="txtMntPayer" runat="server" BorderStyle="None" Width="265px" style="text-align: right;"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btn1" runat="server" OnClick="Button1_Click" Text="Bouton1" />
        <asp:Button ID="btn2" runat="server" OnClick="btn2_Click" Text="Button" />
        <asp:Button ID="btnAnnuler" runat="server" OnClick="btnAnnuler_Click" Text="Annuler" />
        <br />
   </div>
</asp:Content>
