using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class Accueil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAuthentification_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Authentification.aspx");
        }

        protected void btnCreationCompte_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Page_CreerCompte.aspx");
        }

        protected void btnConsulterMenu_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/EnConstruction.aspx");
        }
    }
}