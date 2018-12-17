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
                
                //ddlEtatCommande.SelectedIndex = 7;
                //ddlEtatCommande.SelectedValue = "7";
            }

            // Chargement de la dropdownlist avec les valeurs possibles
            // selon la personne connectée
            if (!IsPostBack)
            {
                var listeEtat = chargerDDL();
                ddlEtatCommande.DataValueField = "idEtat";
                ddlEtatCommande.DataTextField = "etat";

                ddlEtatCommande.DataSource = listeEtat;
                ddlEtatCommande.DataBind();
            }

            // On charge la table contenant les commandes avec le bon état
            tableauSel = chargementTable(ddlEtatCommande.SelectedValue.ToString());

            // Procédure qui supprime le gridview
            clearGridView(gvCommandes);

            if (tableauSel.Count == 0)
            {
                txtMessage.Text = "Aucune commande avec l'état sélectionné.";
            }
            else
            {


                

                // Chargement de la gridview
                DataTable dt = new DataTable("gvCommande");
                DataColumn dcNum = new DataColumn("N° Commande", typeof(int));
                DataColumn dcDate = new DataColumn("Date Commande", typeof(DateTime));
                DataColumn dcClient = new DataColumn("Nom du client", typeof(String));
                DataColumn dcMntTotal = new DataColumn("Montant Total", typeof(Decimal));


                dt.Columns.Add(dcNum);
                dt.Columns.Add(dcDate);
                dt.Columns.Add(dcClient);
                dt.Columns.Add(dcMntTotal);

                foreach (commandes item in tableauSel)
                {

                    DataRow dr = dt.NewRow();

                    // On récupère les infos du client de la commande pour pouvoir
                    // afficher son nom
                    var CltCde = BDResto.Instance.GetCompte(item.noClient);


                    dr["N° Commande"] = item.idCommande;
                    dr["Date Commande"] = item.datecommande;
                    dr["Nom du client"] = CltCde.nom + " " + CltCde.prenom;
                    dr["Montant Total"] = BDResto.Instance.GetPrixTotalCde(item.idCommande);

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
                    gvCommandes.Columns.Add(bfield);

                }


                // Initialise la DataSource
                gvCommandes.DataSource = dt;

                // Lie la table de données avec le GridView.

                gvCommandes.DataBind();



            }
            

            // Affichage du nom du restaurant
            var Resto = BDResto.Instance.GetAllRestaurants();
            txtNomResto.Text = BDResto.Instance.GetRestaurant(Convert.ToInt32(this.Session[Site1.SESSION_IDRESTO])).nomResto.ToString();

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

            if (p_EtatCde != "")
            {
                tableauRetour = (from element in ensembleCommandes
                                              where Convert.ToString(element.idetat) == p_EtatCde
                                              select element).ToList();
            }
            //else
            //{
            //    tableauRetour = (from element in ensembleCommandes
            //                                  select element).ToList();
            //}  

            

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

        protected void BtnAccueil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnDeconnecter_Click(object sender, EventArgs e)
        {
            this.Session.Abandon();
            this.Response.Redirect("~/Default.aspx");
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected List<etatcommandes> chargerDDL()
        {
            int cpt = 0;
            List<etatcommandes> element = new List<etatcommandes>();

            etatcommandes etat;

            var typeCompte = BDResto.Instance.GetTypeCompteUtil(Convert.ToInt32(this.Session[Site1.SESSION_IDUTILISATEURCONNECTE]));
            // Le gérant a accès à tous les états
            if (typeCompte == 2)
            {
                var listeEtat = BDResto.Instance.GetAllEtatsCde();
                foreach (etatcommandes item in listeEtat)
                {
                    element.Add(item);
                    cpt += 1;
                }
            }
            else
            {
                if (typeCompte == 3)
                {
                    // Le chef peut voir les commandes acceptée ou en préparation
                    etat = BDResto.Instance.GetEtatCde(1);
                    element.Add(etat);
                    etat = BDResto.Instance.GetEtatCde(2);
                    element.Add(etat);

                }
                else
                {
                    if (typeCompte == 4)
                    {
                        // Le livreur peut voir les commandes prêtes à livrer
                        etat = BDResto.Instance.GetEtatCde(3);
                        element.Add(etat);
                    }
                }

            }
            
            return element;
        }
    }
}