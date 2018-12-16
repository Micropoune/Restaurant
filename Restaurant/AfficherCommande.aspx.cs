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
            //this.Session[Site1.SESSION_IDCOMMANDE] = 2;
            // On récupère les informations de la commande
            var commande = BDResto.Instance.GetCommande(Convert.ToInt32(this.Session[Site1.SESSION_IDCOMMANDE]));
            var info = recupererInfoCde(commande.idCommande, commande.noClient, commande.noAdrs);
            infoCommande.Text = info;

            // Préparation de la table de données
            DataTable tabDetail = new DataTable();

            // Création de l'ID colonne pour l'ajouter à la table de données
            DataColumn dcol = new DataColumn("NOM", typeof(System.String));
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
                drow["NOM"] = detailPdt.nomProd;
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

        }




        private String recupererInfoCde(int p_NumCde, int p_NumClt, int p_NumAdr)
        {
            // On récupère le client de la commande
            var client = BDResto.Instance.GetCompte(p_NumClt);

            // On récupère l'adresse
            var adresse = BDResto.Instance.GetAdresse(p_NumAdr);

            var info = p_NumCde + " " + client.nom + " " + client.prenom;
            info = info + "\r\n" + adresse.noCvq + " " + adresse.Rue + " " + adresse.ville + " " + adresse.codePostal;

            return info;
            throw new NotImplementedException();
        }
    }
}
