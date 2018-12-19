using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class AjoutResto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_AjouterResto_Click(object sender, EventArgs e)
        {
            restaurants resto = new restaurants();
            adresses add = new adresses();

            resto.idResto = 5;
            resto.nomResto = this.tbx_NomResto.Text;
            add.idAdrs = Convert.ToInt32(this.tbx_AdresseResto);

            add.noCvq = tbx_civic.Text;
            add.province = this.LBProvince.SelectedItem.Text;
            add.Rue = this.tbx_rue.Text;
            add.telephone = this.tbx_tel.Text;
            add.ville = this.tbx_ville.Text;
            add.codePostal = this.tbx_codePostal.Text;
            resto.Actif = (bool)this.cbx_Activer.Checked;
            resto.idAdrs = add.idAdrs;

            BDResto.Instance.ajouterRestaurant(resto);
            BDResto.Instance.Sauvegarder();
            Response.Redirect("~/AjoutResto.aspx");

            BDResto.Instance.ajouterRestaurant(resto);
            BDResto.Instance.Sauvegarder();
        }

        protected void btn_ModifierResto_Click(object sender, EventArgs e)
        {

        }

        protected void btn_DesactiverResto_Click(object sender, EventArgs e)
        {

        }
    }
}