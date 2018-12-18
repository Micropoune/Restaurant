using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        items_commande panier = new items_commande();
        commandes comm = new commandes();
        List<produits> lst_produits = new List<produits>();



        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (this.Session[Site1.SESSION_IDUTILISATEURCONNECTE] != null)

            {
                if (this.Session[Site1.SESSION_IDMENU] != null)
                {
                    int idMenu = (int)this.Session[Site1.SESSION_IDMENU];
                    int idResto = (int)this.Session[Site1.SESSION_IDRESTO];
                    int idUsager = (int)this.Session[Site1.SESSION_IDUTILISATEURCONNECTE];
                    int idCommande = (int)this.Session[Site1.SESSION_IDCOMMANDE];

                    comptes usager = BDResto.Instance.GetCompte(idUsager);                  
                    restaurants resto = BDResto.Instance.GetRestaurant(idResto);
                    menus menu = BDResto.Instance.GetMenu(idMenu);

                    produits idProduit = BDResto.Instance.GetProduit();


                    clearGridView(gv_panier);


                }
                
                 

            }
            else
            {
                this.Response.Redirect("~/Default.aspx");
            }
        }

        protected void btn_ajouter_Click(object sender, EventArgs e)
        {




        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //comm.adresses = this.Session[Site1.SESSION_IDUTILISATEURCONNECTE];

            items_commande panier = new items_commande();

            this.Response.Redirect("~/AfficherCommande.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // ajouter dans la listview item_commande

            produits selectedItems = gv_Menu.SelectedValue;

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        protected List<produits> chargementTable(String p_idProduit)
        {
            List<produits> tableauRetour = new List<produits>();
            if (p_idProduit != "")
            {
                tableauRetour = BDResto.Instance.GetProduit(Convert.ToInt32(p_idProduit));
            }

            return tableauRetour;
        }
    }
}