using System;
using System.Collections.Generic;
using System.Configuration;
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
			this.m_BD = new RestoConceptDataContext(ConfigurationManager.ConnectionStrings["RestaurantConceptConnectionString"].ConnectionString);
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
		public void ajouterComptes(comptes p_Comptes)
		{
			this.m_BD.comptes.InsertOnSubmit(p_Comptes);
		}
		public void ajouterMenu(menus p_Menus)
		{
			this.m_BD.menus.InsertOnSubmit(p_Menus);
		}
	}
}