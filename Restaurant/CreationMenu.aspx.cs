﻿using Microsoft.CSharp.RuntimeBinder;
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

		protected void Page_Load(object sender, EventArgs e)
		{
			//if (this.Session[Site1.SESSION_IDMENU] != null)
			//{
			if (!IsPostBack)
			{
				var idMenu = Convert.ToInt32(this.Session[Site1.SESSION_IDMENU]);
				menus menuAAfficher = BDResto.Instance.GetMenu(idMenu);
				ddlTitre.SelectedValue = menuAAfficher.titreMenu;
			}

			//}
		}

		protected void btnAnnuler_Click(object sender, EventArgs e)
		{
			this.Session.Abandon();
			Response.Redirect("~/Default.aspx");
		}


		protected void btnAjouterMets_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/AjoutModifMets.aspx");
		}

		protected void lnkAccueil_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void lnkDeconnecter_Click(object sender, EventArgs e)
		{
			this.Session.Abandon();
			Response.Redirect("~/Authentification.aspx");
		}

		protected void lnkGestionMenu_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/EnConstruction.aspx");
		}

		protected void btnModifierMets_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/EnConstruction.aspx");
		}

		protected void btnDesactiverMets_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/EnConstruction.aspx");
		}
		protected void ddlTitre_SelectedIndexChanged(object sender, EventArgs e)
		{
			menus menuAAfficher = BDResto.Instance.GetMenu(ddlTitre.SelectedIndex);

		}
	}
}
