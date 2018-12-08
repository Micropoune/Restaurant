using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
	public partial class AjoutMofifMets : System.Web.UI.Page
	{
		produits metsAAjouter = new produits();
		string cheminImage="";
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnEnregistrer_Click(object sender, EventArgs e)
		{
			produits nouveauMets = new produits();

			nouveauMets.idProduit=Convert.ToInt32(this.txtIdMets.Text);

			var listeCategorie = BDResto.Instance.GetAllCategorie().SingleOrDefault(c =>
					  (c.nomCategorie.Equals(this.ddlCategorie.SelectedValue)));

			nouveauMets.idCategorie = listeCategorie.idCategorie;
			nouveauMets.nomProd = this.txtNomMets.Text;
			nouveauMets.descProd = this.txtDescriptionMet.Text;
			nouveauMets.prixProd = Convert.ToDecimal(this.txtPrixMets.Text);
			nouveauMets.imgProd = this.cheminImage;

			BDResto.Instance.ajouterMets(nouveauMets);
			BDResto.Instance.Sauvegarder();
			Response.Redirect("~/CreationMenu.aspx");
		}

		protected void btnAnnuler_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void lnkAccueil_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void lnkDeconnecter_Click(object sender, EventArgs e)
		{

		}

		protected void lnkConsulterMenu_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/CreationMenu.aspx");
		}

		protected void btnImporter_Click(object sender, EventArgs e)
		{
			StartUpLoad();
		}

		private void StartUpLoad()
		{
			string imgName = string.Empty;
			int imgSize = 0;
			string imgPath = string.Empty;

			//on valide le fichier avant de le sauvegarder
			if (FUploadImg.PostedFile != null && FUploadImg.PostedFile.FileName != "")
			{
				//recupere le nom de l'image "posted"        
				imgName = FUploadImg.PostedFile.FileName;

				//definit le chemon ou on enregistre l'image          
				imgPath = "images/" + imgName;

				//recup'ere la taille en bytes
				imgSize = FUploadImg.PostedFile.ContentLength;

				// si l'image est plus de 10240 kb on avertit qu'elle est trop grande 
				if (imgSize > 10240)
				{
					Page.ClientScript.RegisterClientScriptBlock(typeof(Page),
					"Attention!", "alerte('Fichier trop volumineux!')", true);
				}
				else
				{
					//si la taille est correct on sauvegarde 
					FUploadImg.SaveAs(Server.MapPath(imgPath));
					Image.ImageUrl = "~/" + imgPath;
					this.cheminImage = imgPath;
					Page.ClientScript.RegisterClientScriptBlock(typeof(Page),
					"Alert", "alert('Image sauvegard!')", true);

				}
			}
		}
	}
}