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

		}

		protected void btnCreationMenu_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/AjoutModifMenu.aspx");
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
			Response.Redirect("~/ListeCommande.aspx");
		}
	}
}