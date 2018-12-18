using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class CreationMenu : System.Web.UI.Page
    {
        List<menu_produits> tableauSel = new List<menu_produits>();
        protected void Page_Load(object sender, EventArgs e)
        {
			if (ddlMenu.SelectedValue.ToString() != "")
			{
				txtIdMenu.Text = ddlMenu.SelectedValue.ToString();
			}
			//this.Session[Site1.SESSION_IDMENU] = ddlMenu.SelectedValue.ToString();
			if (!IsPostBack)
            {
				if (this.Session[Site1.SESSION_IDMENU] == "")
                {
                    this.Session[Site1.SESSION_IDMENU] = 0;
                }
                var idMenu = Convert.ToInt32(this.Session[Site1.SESSION_IDMENU]);
                menus menuAAfficher = BDResto.Instance.GetMenu(idMenu);
            }

            // On charge la table contenant les produits du menu désiré
            if (ddlMenu.SelectedValue.ToString() == "")
            {
                tableauSel = chargementTable(Convert.ToString(this.Session[Site1.SESSION_IDMENU]));
            }
            else
            {
                tableauSel = chargementTable(ddlMenu.SelectedValue.ToString());
            }

            // Procédure qui supprime le gridview
            clearGridView(gvMenu);

            if (tableauSel == null)
            {
                txtMessage.Text = "Aucun élément dans ce menu.";
            }
            else
            {
                // Chargement de la gridview
                DataTable dt = new DataTable("gvMenu");
                DataColumn dcPdt = new DataColumn("Produit", typeof(String));
                DataColumn dcDesc = new DataColumn("Description", typeof(String));
                DataColumn dcPrix = new DataColumn("Prix", typeof(int));
                DataColumn dcImage = new DataColumn("Image", typeof(Image));


                dt.Columns.Add(dcPdt);
                dt.Columns.Add(dcDesc);
                dt.Columns.Add(dcPrix);
                dt.Columns.Add(dcImage);

                foreach (menu_produits item in tableauSel)
                {

                    DataRow dr = dt.NewRow();

                    // On récupère les informations du produit
                    var pdt = BDResto.Instance.GetProduit(item.idProduit);
                    Image img = new Image();
                    img.ImageUrl = ResolveUrl(pdt.imgProd);
                    dr["Produit"] = pdt.nomProd;
                    dr["Description"] = pdt.descProd;
                    dr["Prix"] = pdt.prixProd;
                    dr["Image"] = img;

                    dt.Rows.Add(dr);
                }


                // On parcoure les colonnes de la table de données pour 
                // définir le champ lié aux données de manière dynamique

                foreach (DataColumn col in dt.Columns)
                {
                    // Déclarer le champ lié et allouer de la mémoire pour le champ lié
                    BoundField bfield = new BoundField();

                    // Initialise la valeur du champ de données.
                    bfield.DataField = col.ColumnName;

                    // Initialise la valeur du champ HeaderText.
                    bfield.HeaderText = col.ColumnName;

                    if (col.ColumnName == "Prix")
                    {
                        bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else
                    {
                        if (col.ColumnName == "Image")
                        {
                            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        }
                        else
                        {
                            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                        }
                    }

                    // Ajoute le champ lié nouvellement créé au GridView.
                    gvMenu.Columns.Add(bfield);

                }


                // Initialise la DataSource
                gvMenu.DataSource = dt;

                // Lie la table de données avec le GridView.

                gvMenu.DataBind();
                //if (this.Session[Site1.SESSION_IDMENU] != null)
                //{

            }

        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
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
            Response.Redirect("~/EnConstruction.aspx");
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

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
		
			Page_Load(sender, e);
        }

        protected List<menu_produits> chargementTable(String p_idMenu)
        {
            List<menu_produits> tableauRetour = new List<menu_produits>();
            if (p_idMenu != "")
            {
                tableauRetour = BDResto.Instance.GetProduitsMenu(Convert.ToInt32(p_idMenu));
            }

            return tableauRetour;
        }

        protected void clearGridView(GridView p_GridView)
        {
            p_GridView.DataSource = null;
            p_GridView.DataBind();
            for (int i = 1; p_GridView.Columns.Count > i;)
            {
                p_GridView.Columns.RemoveAt(i);
            }
        }



		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtIdProduit.Text = this.GridView1.SelectedRow.Cells[1].Text;
			this.Session[Site1.SESSION_IDPRODUIT] = this.GridView1.SelectedRow.Cells[1].Text;
		}

		protected void btnAjouterMetsMenu_Click(object sender, EventArgs e)
		{
			BDResto.Instance.ajouterMetMenu(Convert.ToInt32(txtIdMenu.Text),Convert.ToInt32(txtIdProduit.Text));
			BDResto.Instance.Sauvegarder();
			Page_Load(sender, e);
		}
	}
}