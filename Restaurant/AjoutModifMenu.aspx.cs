using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
	public partial class AjoutModifMenu : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void txtEnregistrer_Click(object sender, EventArgs e)
		{
			menus menuAAjouter = new menus();
			menuAAjouter.titreMenu = txtTitreMenu.Text;
			menuAAjouter.actif = Convert.ToInt16(ddlStatut.SelectedValue);
			menuAAjouter.commentaires = txtCommentaires.Text;

			var listeRestaurant = BDResto.Instance.GetAllRestaurants().SingleOrDefault(c =>
				  c.nomResto.Equals(this.ddlResto.SelectedValue));

			menuAAjouter.idResto = listeRestaurant.idResto;
			BDResto.Instance.ajouterMenu(menuAAjouter);
			BDResto.Instance.Sauvegarder();
			
			this.Session[Site1.SESSION_IDMENU]= menuAAjouter.idMenu;
			Response.Redirect("~/CreationMenu.aspx");
		}

		protected void btnAnnuler_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void lnkDeconnecter_Click(object sender, EventArgs e)
		{
			this.Session.Abandon();
			Response.Redirect("~/Authentification.aspx");
		}
	}
}