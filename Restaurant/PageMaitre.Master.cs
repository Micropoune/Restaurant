using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
	public partial class Site1 : System.Web.UI.MasterPage
	{

		public static string SESSION_IDUTILISATEURCONNECTE = "IDUtilisateurConnecte";
		public static string SESSION_IDRESTO = "idResto";
		public static string SESSION_IDCOMMANDE = "idCommande";
		protected void Page_Load(object sender, EventArgs e)

		{
            // On considère que le gérant est signé car on doit tester l'acceptation d'une commande
            this.Session[Site1.SESSION_IDUTILISATEURCONNECTE] = 4;
            this.Session[Site1.SESSION_IDRESTO] = 1;
            //this.Session[Site1.SESSION_IDUTILISATEURCONNECTE] = 2;


        }
	}
}