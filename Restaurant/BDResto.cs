using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Linq;
using System.Configuration;

namespace Restaurant
{
	public class BDResto
	{
		private RConceptDataContext m_BD;
		private static BDResto m_BDResto;

		private BDResto()
		{
			this.m_BD = new RConceptDataContext(ConfigurationManager.ConnectionStrings["RestaurantConceptConnectionString"].ConnectionString);
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
	}
}