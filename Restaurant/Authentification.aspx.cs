using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class Authentification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Session[pageMaitre.SESSION_UTILISATEURID] != null)
            if (this.Session[Site1.SESSION_IDUTILISATEURCONNECTE] != null)
            {

                int id = (int)this.Session[Site1.SESSION_IDUTILISATEURCONNECTE];
                comptes utilisateurConnecte = BDResto.Instance.GetCompte(id);
                
                this.Response.Redirect("~/Default.aspx");


            }
            LoginUser.RememberMeSet = true;

        }


        protected void btnAuthentification_Click(object sender, EventArgs e)
        {

            if (this.IsValid)
            {
                comptes utilisateurConnecte = BDResto.Instance.GetUtilisateur(LoginUser.UserName);
                
                // On sauvegarde les données de l'utilisateur connecté
                this.Session[Site1.SESSION_IDUTILISATEURCONNECTE] = utilisateurConnecte.noCompte;

                

                BDResto.Instance.Sauvegarder();
				this.Response.Redirect("~/Default.aspx");
				this.Response.Redirect("~/Default.aspx");
                
            }
        }
        //methode Utilisateur qui fait la validation côté serveur
        protected void Utilisateur(object source, ServerValidateEventArgs args)
        {
            comptes utilisateurConnecte = BDResto.Instance.GetUtilisateur(LoginUser.UserName);
            if ((utilisateurConnecte == null) || (utilisateurConnecte.motPasse != LoginUser.Password))
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