using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class AfficherCommande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On récupère les informations de la commande
            txtNumCde.Text = Convert.ToString(this.Session[Site1.SESSION_IDCOMMANDE]);
            var commande = BDResto.Instance.GetCommande(Convert.ToInt32(this.Session[Site1.SESSION_IDCOMMANDE]));

            // On récupère l'état de la commande   
            txtEtatCde.Text = Convert.ToString(commande.idetat);

            var info = recupererInfoCde(commande.noClient, commande.noAdrs);
            txtInfoClient.Text = info;

            // Procédure qui supprime le gridview
            clearGridView(gvDetailCde);

            // Préparation de la table de données
            DataTable tabDetail = new DataTable();

            // Création de l'ID colonne pour l'ajouter à la table de données
            DataColumn dcol = new DataColumn("Mets", typeof(System.String));
            tabDetail.Columns.Add(dcol);

            //Création de l'ID colonne pour l'ajouter à la table de données
            dcol = new DataColumn("QTE", typeof(System.Int32));
            tabDetail.Columns.Add(dcol);

            //Création de l'ID colonne pour l'ajouter à la table de données
            dcol = new DataColumn("PU", typeof(System.Int32));
            tabDetail.Columns.Add(dcol);

            //Création de l'ID colonne pour l'ajouter à la table de données
            dcol = new DataColumn("PxTotal", typeof(System.Int32));
            tabDetail.Columns.Add(dcol);

            // On récupère le détail de la commande
            var detailCde = BDResto.Instance.GetAllItemsCommande(commande.idCommande);

            foreach (items_commande item in detailCde)
            {
                // On récupère les informations du produit
                var detailPdt = BDResto.Instance.GetProduit(item.noProduit);

                // Création d'une nouvelle ligne
                DataRow drow = tabDetail.NewRow();

                // On initialise les données de la ligne 
                drow["Mets"] = detailPdt.nomProd;
                drow["QTE"] = item.qte;
                drow["PU"] = detailPdt.prixProd;
                drow["PxTotal"] = item.qte * detailPdt.prixProd;

                // On ajoute la ligne à la table de données
                tabDetail.Rows.Add(drow);

            }

            // On parcoure les colonnes de la table de données pour 
            // définir le champ lié aux données de manière dynamique

            foreach (DataColumn col in tabDetail.Columns)
            {

                // Déclarer le champ lié et allouer de la mémoire pour le champ lié
                BoundField bfield = new BoundField();

                // Initialise la valeur du champ de données.
                bfield.DataField = col.ColumnName;

                // Initialise la valeur du champ HeaderText.
                bfield.HeaderText = col.ColumnName;

                // Ajoute le champ lié nouvellement créé au GridView.
                gvDetailCde.Columns.Add(bfield);

            }
            // Initialise la DataSource
            gvDetailCde.DataSource = tabDetail;

            // Lie la table de données avec le GridView.

            gvDetailCde.DataBind();

            // On récupère le total de la commande
            double mntCde = BDResto.Instance.GetPrixTotalCde(Convert.ToInt32(txtNumCde.Text));
            txtMntTotal.Text = Convert.ToString(mntCde);

            // On calcule le montant TPS et TVQ
            // On récupère le total de la commande
            double mntTPS = Math.Round(mntCde * 0.05, 2);
            double mntTVQ = Math.Round(mntCde * 0.09975, 2);
            double total = Math.Round(mntCde + mntTPS + mntTVQ, 2);
            txtTPS.Text = Convert.ToString(mntTPS);
            txtTVQ.Text = Convert.ToString(mntTVQ);
            txtMntPayer.Text = Convert.ToString(total);

            // On définit le texte des boutons 
            // On récupère le type de compte de l'utilisateur connecté 
            txtTypeCpte.Text = Convert.ToString(BDResto.Instance.GetTypeCompteUtil(Convert.ToInt32(this.Session[Site1.SESSION_IDUTILISATEURCONNECTE])));
            if (txtTypeCpte.Text == "2")
            { 
                // Gérant
                btn1.Text = "Accepter";
                btn2.Text = "Refuser";
            }
        }




        private String recupererInfoCde(int p_NumClt, int p_NumAdr)
        {
            // On récupère le client de la commande
            var client = BDResto.Instance.GetCompte(p_NumClt);

            // On récupère l'adresse
            var adresse = BDResto.Instance.GetAdresse(p_NumAdr);

            var info = client.nom + " " + client.prenom;
            info = info + "\r\n" + adresse.noCvq + " " + adresse.Rue + " " + adresse.ville + " " + adresse.codePostal;

            return info;
            throw new NotImplementedException();
        }

        protected void BtnAccueil_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void BtnDeconnecter_Click(object sender, EventArgs e)
        {
            this.Session.Abandon();
            this.Response.Redirect("~/Default.aspx");
        }

        protected void BtnListeCde_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/ListeCommande.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtTypeCpte.Text == "2")
            {
                txtMessage.Text = "";
                if (txtEtatCde.Text != "7")
                {
                    txtMessage.Text = "Action impossible. Cette commande n'est pas en attente de validation.";
                }
                else
                {
                    // On passe la commande à l'état Accepté
                    BDResto.Instance.SetEtatCde(Convert.ToInt32(txtNumCde.Text), 1);
                    this.Response.Redirect("~/ListeCommande.aspx");
                }
                
            }
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

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/ListeCommande.aspx");
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            if (txtTypeCpte.Text == "2")
            {
                txtMessage.Text = "";
                if (txtEtatCde.Text != "7")
                {
                    txtMessage.Text = "Action impossible. Cette commande n'est pas en attente de validation.";
                }
                else
                {
                    // On passe la commande à l'état Refusé
                    BDResto.Instance.SetEtatCde(Convert.ToInt32(txtNumCde.Text), 0);
                    this.Response.Redirect("~/ListeCommande.aspx");
                }
            }
        }
    }
}
