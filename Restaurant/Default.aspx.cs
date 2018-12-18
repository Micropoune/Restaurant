using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnCreerMets_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/AjoutModifMets.aspx");
		}

		protected void btnCommanderMets_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/CommanderMets.aspx");
		}

		protected void btnCreationMenu_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/CreationMenu.aspx");
		}

		protected void btnAuthentification_Click(object sender, EventArgs e)
		{

		}

		protected void btnAfficherCmd_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/AfficherCommande.aspx");
		}

		protected void btnListeCommande_Click(object sender, EventArgs e)
		{
			// Si le type de compte de l'utilisateur connecté est un client, on doit le diriger vers
			// une page spécifique. Comme elle n'est pas développée, on l'enverra sur une page en construction
			var utilisateurConnecte = BDResto.Instance.GetCompte(Convert.ToInt32(this.Session[Site1.SESSION_IDUTILISATEURCONNECTE]));
			if (utilisateurConnecte.notpCmpt == 5)
			{
				Response.Redirect("~/EnConstruction.aspx");
			}
			else
			{
				Response.Redirect("~/ListeCommande.aspx");
			}
		}

		protected void btnCreationCompte_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Page_CreerCompte.aspx");
		}

		protected void lnkDeconnecter_Click(object sender, EventArgs e)
		{
			this.Session.Abandon();
			Response.Redirect("~/Authentification.aspx");
		}
	}
}