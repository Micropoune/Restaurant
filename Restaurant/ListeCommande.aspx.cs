using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class ListeCommande : System.Web.UI.Page
    {
        List<commandes> tableauSel = new List<commandes>();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            
            // Si on est avec état différent de Autre, on doit sélectionner que
            // les commandes avec l'état choisi
            if (ddlEtatCommande.SelectedValue == "")
            {
                ddlEtatCommande.SelectedIndex = 7;
            }

            // On charge la table contenant les commandes avec le bon état
            tableauSel = chargementTable(ddlEtatCommande.SelectedValue.ToString());

            if (tableauSel.Count == 0)
            {
                txtMessage.Text = "Aucune commande avec l'état sélectionné.";
            }

            

            // Procédure qui supprime le gridview
            clearGridView(gvCommandes);

            // Chargement de la gridview
            DataTable dt = new DataTable("gvCommande");
            DataColumn dcNum = new DataColumn("idCommande", typeof(int));
            DataColumn dcDate = new DataColumn("datecommande", typeof(DateTime));
            DataColumn dcEtat = new DataColumn("idetat", typeof(string));


            dt.Columns.Add(dcNum);
            dt.Columns.Add(dcDate);
            dt.Columns.Add(dcEtat);

            foreach (commandes item in tableauSel)
            {
                
                DataRow dr = dt.NewRow();

                
                dr["idCommande"] = item.idCommande;
                dr["datecommande"] = item.datecommande;
                dr["idetat"] = Convert.ToString(item.etatcommandes);

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

                // Ajoute le champ lié nouvellement créé au GridView.
                gvCommandes.Columns.Add(bfield);

            }
            // Initialise la DataSource
            gvCommandes.DataSource = dt;

            // Lie la table de données avec le GridView.

            gvCommandes.DataBind();

            this.Session[Site1.SESSION_IDRESTO] = "1";
            
            

            // Affichage du nom du restaurant
            var Resto = BDResto.Instance.GetAllRestaurants();
            txtNomResto.Text = (BDResto.Instance.GetRestaurant(Convert.ToInt32(this.Session[Site1.SESSION_IDRESTO])).nomResto).ToString();

            if (!IsPostBack)
            {
                this.Session[Site1.SESSION_IDCOMMANDE] = null;
            }

        }

        // Si on change notre choix dans la liste de choix
        protected void ddlEtatCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected List<commandes> chargementTable(String p_EtatCde)
        {
            

            var ensembleCommandes = BDResto.Instance.GetAllCommandes();
            List<commandes> tableauRetour = new List<commandes>();

            if (p_EtatCde != "" && p_EtatCde != "7")
            {
                tableauRetour = (from element in ensembleCommandes
                                              where Convert.ToString(element.idetat) == p_EtatCde
                                              select element).ToList();
            }
            else
            {
                tableauRetour = (from element in ensembleCommandes
                                              select element).ToList();
            }

            

            return tableauRetour;

           

        }

       
        protected void btnAfficher_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            if (this.Session[Site1.SESSION_IDCOMMANDE] != null)
            {
                Response.Redirect("~/AfficherCommande.aspx");
                
            }
            else
            {
                txtMessage.Text = "Vous devez sélectionner une ligne.";
            }
        }

        protected void gvCommandes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session[Site1.SESSION_IDCOMMANDE] = Convert.ToInt32(this.gvCommandes.SelectedRow.Cells[1].Text);
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
    }
}