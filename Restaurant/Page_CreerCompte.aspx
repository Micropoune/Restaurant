<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Page_CreerCompte.aspx.cs" Inherits="Restaurant.Page_CreerCompte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >
        .auto-style1 {
            height: 1168px;
        }
        .HLink {
            margin:10px;
            float:right;
            cursor:grab;
        }

        
        .auto-style2 {
            margin-left: 23px;
        }

        
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    <div class="auto-style1" id="LblConfirmMotDePasser">
        <asp:HyperLink ID="HLAccueil" runat="server" ForeColor="Blue" Class ="HLink" NavigateUrl="~/Default.aspx">Accueil</asp:HyperLink>
        &nbsp;&nbsp;
        <asp:HyperLink ID="HLConnecter" runat="server" ForeColor="Blue" Class ="HLink" style="height: 27px">Se connecter</asp:HyperLink>
        &nbsp;
        <asp:HyperLink ID="HLMenu" runat="server" ForeColor="Blue" Class ="HLink">Consulter le menu </asp:HyperLink>
        <asp:Label ID="LblCreerCompte" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Se créer un compte"></asp:Label>
        <br />
        <asp:ValidationSummary ID="ValSummCreationCompte" runat="server" ForeColor="Red" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblPrenom" runat="server" Text="Prénom: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtPrenom" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPrenomVide" runat="server" ControlToValidate="TxtPrenom" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValidPrenom" runat="server" ControlToValidate="TxtPrenom" ErrorMessage="Le format est incorrect" ForeColor="Red" ValidationExpression="^[A-Z]{1}[a-z]+[-]?[A-Z]?[a-z]+$">*</asp:RegularExpressionValidator>
        <br />
        <br />
         &nbsp;&nbsp;&nbsp;
         <asp:Label ID="LblNom" runat="server" Text="Nom: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtNom" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valNomVide" runat="server" ControlToValidate="TxtNom" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValidNom" runat="server" ControlToValidate="TxtNom" ErrorMessage="Le format est incorrect" ForeColor="Red" ValidationExpression="^[A-Z]{1}[a-z]+[-]?[A-Z]?[a-z]+$">*</asp:RegularExpressionValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
         <asp:Label ID="LblNomUtilisateur" runat="server" Text="Nom utilisateur: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="TxtNomUtilisateur" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valNomUser" runat="server" ControlToValidate="TxtNomUtilisateur" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CVNomUser" runat="server" ControlToValidate="TxtNomUtilisateur" ErrorMessage="Ce nom est déjà utilisé" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp; 
         <asp:Label ID="LblNom0" runat="server" Text="Téléphone: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtTelephone" runat="server" OnTextChanged="TxtTelephone_TextChanged" ClientIDMode="Static" >999-999-9999</asp:TextBox>
        <script type="text/javascript">var mtb;</script>
        <asp:RequiredFieldValidator ID="valTelephoneVide" runat="server" ControlToValidate="TxtTelephone" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValidTelephone" runat="server" ControlToValidate="TxtTelephone" ErrorMessage="Le format est incorrect" ForeColor="Red" ValidationExpression="\d{3}-\d{3}-\d{4}">*</asp:RegularExpressionValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp; 
         <asp:Label ID="LblNoCvq" runat="server" Text="No.cvq:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtNoCvq" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REVAdresse0" runat="server" ControlToValidate="TxtNoCvq" ErrorMessage="Le format n'est pas valide" ForeColor="Red" ValidationExpression="\d{3}">*</asp:RegularExpressionValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp; 
         <asp:Label ID="LblRue" runat="server" Text="Rue: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtRue" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valRueVide" runat="server" ControlToValidate="TxtRue" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp; 
         <asp:Label ID="LblCodePstal" runat="server" Text="Code postal:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtCodePostal" runat="server">A1A1A1</asp:TextBox>
        <asp:RegularExpressionValidator ID="REVACodePostal" runat="server" ControlToValidate="TxtCodePostal" ErrorMessage="Le format n'est pas valide" ForeColor="Red" ValidationExpression="[A-Z]{1}\d{1}[A-Z]{1}\d{1}[A-Z]\d{1}">*</asp:RegularExpressionValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblVille" runat="server" Text="Ville"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtVille" runat="server" OnTextChanged="TxtVille_TextChanged"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp; 
         <asp:Label ID="LblProvince" runat="server" Text="Province:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="LBProvince" runat="server" CssClass="auto-style2" Height="26px" ItemType="String" Rows="1" Width="187px">
            <asp:ListItem>AB</asp:ListItem>
            <asp:ListItem>BC</asp:ListItem>
            <asp:ListItem>MB</asp:ListItem>
            <asp:ListItem>NB</asp:ListItem>
            <asp:ListItem>YKNL</asp:ListItem>
            <asp:ListItem>NS</asp:ListItem>
            <asp:ListItem>NT</asp:ListItem>
            <asp:ListItem>NU</asp:ListItem>
            <asp:ListItem>ON</asp:ListItem>
            <asp:ListItem>PE</asp:ListItem>
            <asp:ListItem>QC</asp:ListItem>
            <asp:ListItem>SK</asp:ListItem>
            <asp:ListItem Value="YK"></asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
         <asp:Label ID="LblCourriel" runat="server" Text="Adresse courriel: " Width="161px"></asp:Label>
        &nbsp;<asp:TextBox ID="TxtCourriel" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valCourrielVide" runat="server" ControlToValidate="TxtCourriel" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValidCourriel" runat="server" ControlToValidate="TxtCourriel" ErrorMessage="Le format est incorrect" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
         <asp:Label ID="LblMotDePasse" runat="server" Text="Mot de passe: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtMotDePasse" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valMotDePasseVide" runat="server" ControlToValidate="TxtMotDePasse" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValidMP" runat="server" ControlToValidate="TxtMotDePasse" ErrorMessage="Le format est incorrect" ForeColor="Red" ValidationExpression="(?!^[0-9]*$)(?!^[@$*$])(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$">*</asp:RegularExpressionValidator>
        <asp:CustomValidator ID="TaillePasswordValidator" runat="server" ErrorMessage="Le mot de passe doit avoir minimum 8 caractères" ForeColor="Red" OnServerValidate="TaillePasswordValidator_ServerValidate">*</asp:CustomValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
         <asp:Label ID="LblConfirmMotDePasse" runat="server" Text="Confirmer votre mot de passe: " Font-Overline="False" Font-Size="Medium" Width="147px"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtConfirmMP" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valNom8" runat="server" ControlToValidate="TxtMotDePasse" ErrorMessage="Le champs ne doit pas être vide" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtMotDePasse" ControlToValidate="TxtConfirmMP" ErrorMessage="Les mots de passe ne corresondent pas" ForeColor="Red">*</asp:CompareValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblCommentaire" runat="server" Text="Commentaire:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtCommentaire" runat="server" Height="101px" TextMode="MultiLine" Width="265px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCreerCompte" runat="server" OnClick="BtnCreerCompte_Click" Text="Créer le compte" Width="186px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnAnnuler" runat="server" Text="Annuler" />
        <br />
    </div>
</asp:Content>
