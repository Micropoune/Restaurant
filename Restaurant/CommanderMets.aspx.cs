using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<produits> tableauSel = new List<produits>();
        List<produits> panier = new List<produits>();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            txtMessage2.Text = "";

            if (!IsPostBack)
            {
                // on crée la commande
                //BDResto.Instance.ajouterCde(Convert.ToInt32(this.Session[Site1.SESSION_IDUTILISATEURCONNECTE]), Convert.ToInt32(this.Session[Site1.SESSION_IDUTILISATEURCONNECTE]));
                //this.Session[Site1.SESSION_IDCOMMANDE] = numCde;
                //panier = new List<produits>();
            }

            

            // On récupère le nom du client
            var client = BDResto.Instance.GetCompte(Convert.ToInt32(this.Session[Site1.SESSION_IDUTILISATEURCONNECTE]));
            txtNomClient.Text = client.nom + " " + client.prenom;

            // On charge la table avec les produits du menu
            if (this.Session[Site1.SESSION_IDMENU] == null)
            {
                this.Session[Site1.SESSION_IDMENU] = 1;
            }

            tableauSel = chargementTable(Convert.ToString(this.Session[Site1.SESSION_IDMENU]));

            // Chargement de la gridview contenant les produits déjà affectés au menu
            // Procédure qui supprime le gridview
            clearGridView(gvPdtMenu);

            if (tableauSel.Count == 0)
            {
                txtMessage.Text = "Aucun mets pour ce menu.";
            }
            else
            {
                // Chargement de la gridview
                DataTable dt = new DataTable("gvPdtMenu");
                DataColumn dcNum = new DataColumn("N° Produit", typeof(int));
                DataColumn dcNom = new DataColumn("Nom Produit", typeof(String));
                DataColumn dcDesc = new DataColumn("Description", typeof(String));
                DataColumn dcPrix = new DataColumn("Prix", typeof(int));


                dt.Columns.Add(dcNum);
                dt.Columns.Add(dcNom);
                dt.Columns.Add(dcDesc);
                dt.Columns.Add(dcPrix);

                foreach (produits item in tableauSel)
                {

                    DataRow dr = dt.NewRow();

                    dr["N° Produit"] = item.idProduit;
                    dr["Nom Produit"] = item.nomProd;
                    dr["Description"] = item.descProd;
                    dr["Prix"] = item.prixProd;

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

                    if (col.ColumnName == "Nom du client")
                    {
                        bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else
                    {
                        if (col.ColumnName == "Montant Total")
                        {
                            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        }
                    }

                    // Ajoute le champ lié nouvellement créé au GridView.
                    gvPdtMenu.Columns.Add(bfield);

                }


                // Initialise la DataSource
                gvPdtMenu.DataSource = dt;

                // Lie la table de données avec le GridView.

                gvPdtMenu.DataBind();
            }


            // Chargement de la gridview contenant le panier
            // Procédure qui supprime le gridview
            clearGridView(gvPanier);

            // panier = chargementTable(Convert.ToString(this.Session[Site1.SESSION_IDCOMMANDE]));

            if (panier.Count == 0 || panier == null)
            {
                txtMessage2.Text = "Aucun mets dans le panier.";
            }
            else
            {
                // Chargement de la gridview
                DataTable dt = new DataTable("gvPanier");
                DataColumn dcNum = new DataColumn("N° Produit", typeof(int));
                DataColumn dcNom = new DataColumn("Nom Produit", typeof(String));
                DataColumn dcDesc = new DataColumn("Description", typeof(String));
                DataColumn dcPrix = new DataColumn("Prix", typeof(int));


                dt.Columns.Add(dcNum);
                dt.Columns.Add(dcNom);
                dt.Columns.Add(dcDesc);
                dt.Columns.Add(dcPrix);

                foreach (produits item in panier)
                {

                    DataRow dr = dt.NewRow();

                    dr["N° Produit"] = item.idProduit;
                    dr["Nom Produit"] = item.nomProd;
                    dr["Description"] = item.descProd;
                    dr["Prix"] = item.prixProd;

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

                    if (col.ColumnName == "Nom du client")
                    {
                        bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else
                    {
                        if (col.ColumnName == "Montant Total")
                        {
                            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        }
                    }

                    // Ajoute le champ lié nouvellement créé au GridView.
                    gvPanier.Columns.Add(bfield);

                }


                // Initialise la DataSource
                gvPanier.DataSource = dt;

                // Lie la table de données avec le GridView.

                gvPanier.DataBind();
            }
        }

		protected void btn_ajouter_Click(object sender, EventArgs e)
		{

		}

        
        // Méthode qui permet de clearer le gridview
        protected void clearGridView(GridView p_GridView)
        {
            p_GridView.DataSource = null;
            p_GridView.DataBind();
            for (int i = 1; p_GridView.Columns.Count > i;)
            {
                p_GridView.Columns.RemoveAt(i);
            }
        }

        // Méthode pour récupérer les produits du menu qui permettront de charger la table
        protected List<produits> chargementTable(String p_idMenu)
        {



            List<produits> tableauRetour = new List<produits>();

            if (p_idMenu != "")
            {
                // On charge les produits présents dans le menu
                var ensembleProduitsMenu = BDResto.Instance.GetProduitsMenu(Convert.ToInt32(p_idMenu));
                foreach (menu_produits item in ensembleProduitsMenu)
                {
                    var pdt = BDResto.Instance.GetProduit(item.idProduit);
                    tableauRetour.Add(pdt);
                }
            
            }

            return tableauRetour;



        }

        protected void btnAjoutPanier_Click(object sender, EventArgs e)
        {
            produits pdt = new produits();
			pdt = BDResto.Instance.GetProduit(Convert.ToInt32(this.Session[Site1.SESSION_IDPRODUIT]));
			this.panier.Add(pdt);
            Page_Load(sender, e);
            //BDResto.Instance.ajouterPdtCde(Convert.ToInt32(this.Session[Site1.SESSION_IDCOMMANDE]), Convert.ToInt32(this.Session[Site1.SESSION_IDPRODUIT]));
            //BDResto.Instance.Sauvegarder();
            //Page_Load(sender, e);
        }

		protected void btnValider_Click(object sender, EventArgs e)
		{
			int noCommande=BDResto.Instance.ajouterCde(Convert.ToInt32(Session[Site1.SESSION_IDUTILISATEURCONNECTE]), Convert.ToInt32(Session[Site1.SESSION_IDMENU]));
			this.panier=BDResto.Instance.GetAllItemsCommande(noCommande);
			foreach (produits item in this.panier)
			{
				BDResto.Instance.ajouterPdtCde(noCommande, item.idProduit);
			}
				
			BDResto.Instance.Sauvegarder();
		}

        protected void gvPdtMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session[Site1.SESSION_IDPRODUIT] = this.gvPdtMenu.SelectedRow.Cells[1].Text;
        }

		protected void Button1_Click(object sender, EventArgs e)
		{
			this.Response.Redirect("~/Default.aspx");
		}
	}
}