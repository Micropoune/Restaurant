using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Restaurant
{
    public partial class Page_CreerCompte : System.Web.UI.Page
    {


        public bool compteValide()
        {
            return this.Page.IsValid;
        }

       
        public void creerCompte()
        {
            comptes newCompte = new comptes();
            adresses newAdresse = new adresses();

           

            newCompte.notpCmpt = 5;
            newCompte.prenom = this.TxtPrenom.Text;
            newCompte.nom = this.TxtNom.Text;
            newCompte.telephone = this.TxtTelephone.Text;
            newCompte.Courriel = this.TxtCourriel.Text;
            newCompte.nomUtilisateur = this.TxtNomUtilisateur.Text;
            newCompte.motPasse = this.TxtMotDePasse.Text;
            newCompte.commentaires = this.TxtCommentaire.Text;
            newCompte.Actif = 1;


            newAdresse.noCvq = this.TxtNoCvq.Text;
            newAdresse.Rue = this.TxtRue.Text;
            newAdresse.codePostal = this.TxtCodePostal.Text;
            newAdresse.province = this.LBProvince.SelectedItem.Text;
            newAdresse.ville = this.TxtVille.Text;
            newAdresse.telephone = newCompte.telephone;
            newCompte.adresses = newAdresse;

            BDResto.Instance.ajouterComptes(newCompte);
            BDResto.Instance.Sauvegarder();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnCreerCompte_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                creerCompte();

                Response.Redirect("~/Accueil.aspx");
            }


        }

        protected void TxtTelephone_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtVille_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            foreach (comptes user in BDResto.Instance.GetAllComptes())
            {
                if (user.nomUtilisateur == this.TxtNomUtilisateur.Text)
                {
                    args.IsValid = false;
                }

                else
                {
                    args.IsValid = true;
                }
            }
        }

        protected void TaillePasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(this.TxtMotDePasse.Text.Length < 8)
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }
    }
}