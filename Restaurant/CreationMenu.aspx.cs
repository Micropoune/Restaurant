using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
	public partial class CreationMenu : System.Web.UI.Page
	{
		menus menuAAjouter = new menus();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnEnregistrer_Click(object sender, EventArgs e)
		{
			menuAAjouter.idMenu = Convert.ToInt32(this.txtIdMenu.Text);
			menuAAjouter.titreMenu = this.txtDescriptionMenu.Text;
			BDResto.Instance.Sauvegarder();
		}

		protected void btnAnnuler_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void valNomUnique_ServerValidate(object source, ServerValidateEventArgs args)
		{
			menus menuReponse = BDResto.Instance.GetMenu(Convert.ToInt32(txtIdMenu.Text));
			if (menuReponse == null)
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = false;
			}

		}

		protected void btnAjouterMets_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/AjoutModifMets.aspx");
		}
	}
}