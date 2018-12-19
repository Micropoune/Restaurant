<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CommanderMets.aspx.cs" Inherits="Restaurant.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">

    <div>

        <asp:Label ID="Label2" runat="server" Text="Client :"></asp:Label>
        <asp:TextBox ID="txtNomClient" runat="server" BorderStyle="None" Width="809px"></asp:TextBox>

    </div>

    <div>
        <asp:TextBox ID="txtMessage" runat="server" BorderStyle="None" ForeColor="Red" Width="647px"></asp:TextBox>
        <asp:GridView ID="gvPdtMenu" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPdtMenu_SelectedIndexChanged">
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

<asp:Button ID="btnAjoutPanier" runat="server" Text="Ajouter au panier" OnClick="btnAjoutPanier_Click" />
    <br />
    <br />
<asp:Label ID="Label1" runat="server" Text="Panier"></asp:Label>
<br />
    <div>
        <asp:TextBox ID="txtMessage2" runat="server" BorderStyle="None" ForeColor="Red" Width="647px"></asp:TextBox>
        <asp:GridView ID="gvPanier" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
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
    <br />
<asp:Button ID="Button1" runat="server" Text="Annuler" OnClick="Button1_Click" />
<asp:Button ID="btnValider" runat="server" Text="Valider" OnClick="btnValider_Click" />
    
</asp:Content>
