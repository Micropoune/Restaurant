<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Authentification.aspx.cs" Inherits="Restaurant.Authentification" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    <h2>se connecter</h2>
	 <asp:Login ID="LoginUser" runat="server" EnableViewState="False" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333">
         <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup" Width="657px"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Informations de compte</legend>
                    <p>
                        <asp:Label ID="labelNomUtilisateur" runat="server" Width="150px" Text="Nom d'utilisateur:"></asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="Un nom d'utilisateur est requis." ToolTip="Un nom d'utilisateur est requis." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>

                    </p>
                    <p>
                        <asp:Label ID="labelMonDePasse" runat="server" Text="Mot de passe:" Width="150px"></asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Un mot de passe est requis." ToolTip="Un mot de passe est requis." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>

                        <asp:CustomValidator ID="CustomValidatorCNX" runat="server"  CssClass="failureNotification"  
                            OnServerValidate="Utilisateur" ValidationGroup="LoginUserValidationGroup"
                            ErrorMessage="Le nom d'utilisateur ou le mot de passe n'est pas valide!">*</asp:CustomValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Maintenir la connexion</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="btnSeConnecter" runat="server" CommandName="Login" 
                        Text="Se connecter" ValidationGroup="LoginUserValidationGroup" 
                        onclick="btnAuthentification_Click" CssClass="bouton"/>
                </p>
            </div>
        </LayoutTemplate>
    	 <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
		 <TextBoxStyle Font-Size="0.8em" />
		 <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
</asp:Content>

