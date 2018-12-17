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
        public static int SESSION_IDRESTO;
        public static int SESSION_IDCOMMANDE;
        public static int SESSION_IDMENU;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            commandes comm = new commandes();

            if (this.Session[Site1.SESSION_IDUTILISATEURCONNECTE] != null)

            {
                if (this.Session[Site1.SESSION_IDMENU] != null)
                {
                    int idMenu = (int)this.Session[Site1.SESSION_IDMENU];
                    int idResto = (int)this.Session[Site1.SESSION_IDRESTO];
                    int idUsager = (int)this.Session[Site1.SESSION_IDUTILISATEURCONNECTE];

                    menus menu = BDResto.Instance.GetMenu(idMenu);

                    //int idProduit = BDResto.Instance.GetProduit((int)lstViewMenu.SelectedValue());

                    
                }
                
                 

            }
            else
            {
                this.Response.Redirect("~/Default.aspx");
            }
        }

		protected void btn_ajouter_Click(object sender, EventArgs e)
		{
            produits temp = (produits)this.lstViewMenu.SelectedValue;
            this.lstBox_Panier.Items.Add(temp.nomProd);
            this.lstBox_Panier.Items.Add(temp.prixProd.ToString());

            //this.lstBox_Panier.Show();

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Session[SESSION_IDCOMMANDE] = new commandes();

            this.Response.Redirect("~/AfficherCommande.aspx");
        }
    }
}