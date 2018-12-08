using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Restaurant
{
	public class BDResto
	{
		private RestoConceptDataContext m_BD;
		private static BDResto m_BDResto;

		private BDResto()
		{
			this.m_BD = new RestoConceptDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		}

		public static BDResto Instance
		{
			get
			{
				if (m_BDResto == null)
				{
					m_BDResto = new BDResto();
				}
				return m_BDResto;
			}
		}

		public void Sauvegarder()
		{
			this.m_BD.SubmitChanges();
		}
		#region Comptes Utilisateurs
		public void ajouterComptes(comptes p_Comptes)
		{
			Debug.Assert((p_Comptes!= null), "p_Comptes doit être différent de null");
			this.m_BD.comptes.InsertOnSubmit(p_Comptes);
		}
		#endregion

		#region Menu
		public void ajouterMenu(menus p_Menus)
		{
			Debug.Assert((p_Menus!=null), "p_Menu doit être différent de null");
			this.m_BD.menus.InsertOnSubmit(p_Menus);
		}
		public menus GetMenu(int p_id)
		{

			return this.m_BD.menus.SingleOrDefault(
				Menu => (Menu.idMenu == p_id));
		}

		#endregion

		#region Mets
		public void ajouterMets(produits p_Mets)
		{
			Debug.Assert((p_Mets != null), "p_Mets doit être différent de null");
			this.m_BD.produits.InsertOnSubmit(p_Mets);
		}
		#endregion

		#region Categorie

		/// <summary>
		/// Retourne la liste de toutes les categories
		/// </summary>
		/// <returns></returns>
		public IQueryable<categories> GetAllCategorie()
		{
			return m_BD.categories;

		}
		#endregion
	}
}