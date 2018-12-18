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

        int numCompte = 1;
        int idAdresse = 1;

        public bool compteValide()
        {
            return this.Page.IsValid;
        }

        public void creerCompte()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnCreerCompte_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                comptes newCompte = new comptes();
                adresses newAdresse = new adresses();

                foreach (comptes user in BDResto.Instance.GetAllComptes())
                {
                    if (user.noAdrs == this.numCompte)
                    {
                        this.numCompte++;
                    }
                }

                newCompte.noCompte = numCompte;
                newCompte.notpCmpt = 5;
                newCompte.prenom = this.TxtPrenom.Text;
                newCompte.nom = this.TxtNom.Text;
                newCompte.nomUtilisateur = this.TxtNomUtilisateur.Text;
                newCompte.telephone = this.TxtTelephone.Text;
                newCompte.motPasse = this.TxtMotDePasse.Text;
                newCompte.Courriel = this.TxtCourriel.Text;
                newCompte.Actif = 1;


                foreach (comptes user in BDResto.Instance.GetAllComptes())
                {
                    if (user.noAdrs == this.idAdresse)
                    {
                        this.idAdresse++;
                    }
                }

                newAdresse.idAdrs = this.idAdresse;
                newAdresse.noCvq = this.TxtNoCvq.Text;
                newAdresse.Rue = this.TxtRue.Text;
                newAdresse.codePostal = this.TxtCodePostal.Text;
                newAdresse.province = this.LBProvince.SelectedItem.Text;
                newCompte.noAdrs = this.idAdresse;
                newCompte.adresses = newAdresse;

                BDResto.Instance.ajouterComptes(newCompte);
                BDResto.Instance.Sauvegarder();


                Response.Redirect("Default.aspx");
            }


        }

        protected void TxtTelephone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}