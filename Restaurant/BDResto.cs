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

        /// <summary>
        /// Retourne la liste de tous les comptes. 
        /// </summary>
        public IQueryable<comptes> GetAllComptes()
        {
            return m_BD.comptes;
        }

        /// <summary>
        /// Retourne le compte dont l'ID est 
        /// p_IDCompte, ou null s'il n'y en a aucun.
        /// </summary>
        /// <param name="p_Idcompte">Identifiant à rechercher</param>
        /// <returns>Un compte ou null</returns>
        public comptes GetCompte(int p_IdCompte)
        {
            return m_BD.comptes.SingleOrDefault(
                u => (u.noCompte == p_IdCompte));
        }

        /// <summary>
        /// Retourne le type de compte de l'utilisateur dont l'ID
        /// est p_IDCompte, ou null s'il n'y en a aucun.
        /// </summary>
        /// <param name="p_Idcompte">Identifiant à rechercher</param>
        /// <returns>Un type de compte ou null</returns>
        public int GetTypeCompteUtil(int p_IdCompte)
        {
            var compte = m_BD.comptes.SingleOrDefault(
                u => (u.noCompte == p_IdCompte));
            return compte.notpCmpt;
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

        // Ajout Nathalie
        #region Restaurant

        /// <summary>
        /// Retourne la liste de tous les restaurants. 
        /// </summary>
        public IQueryable<restaurants> GetAllRestaurants()
        {
            return m_BD.restaurants;
        }

        /// <summary>
        /// Retourne le restaurant dont l'ID est 
        /// p_ID, ou null s'il n'y en a aucun.
        /// </summary>
        /// <param name="p_IdResto">Identifiant à rechercher</param>
        /// <returns>Un restaurant ou null</returns>
        public restaurants GetRestaurant(int p_IdResto)
        {
            return m_BD.restaurants.SingleOrDefault(
                u => (u.idResto == p_IdResto));
        }
        #endregion

        #region Commande
        /// <summary>
        /// Retourne la commande dont l'ID est 
        /// p_IDCommande, ou null s'il n'y en a aucun.
        /// </summary>
        /// <param name="p_Idcommande">Identifiant à rechercher</param>
        /// <returns>Une commande ou null</returns>
        public commandes GetCommande(int p_IdCommande)
        {
            return m_BD.commandes.SingleOrDefault(
                u => (u.idCommande == p_IdCommande));
        }

        /// <summary>
        /// Retourne la liste de toutes les commandes. 
        /// </summary>
        public IQueryable<commandes> GetAllCommandes()
        {
            return m_BD.commandes;
        }

        /// <summary>
        /// Retourne le montant total de la commande passée 
        /// en paramètre. 
        /// </summary>
        public double GetPrixTotalCde(int p_NumCde)
        {
            double mntRetour = 0;
            var detailCde = GetAllItemsCommande(p_NumCde);

            foreach (items_commande item in detailCde)
            {
                // On récupère les informations du produit
                var detailPdt = GetProduit(item.noProduit);
                double prix = Convert.ToDouble(detailPdt.prixProd);
                mntRetour += (item.qte * prix);
            }
            return mntRetour;
        }

        /// <summary>
        /// Modifie l'état de la commande passée en paramètre avec le
        /// nouvel état. 
        /// </summary>
        public void SetEtatCde(int p_NumCde, int p_EtatCde)
        {
            var query = (from cde in m_BD.commandes
                        where cde.idCommande == p_NumCde
                        select cde);

            foreach (commandes itemCde in query)
            {
                itemCde.idetat = p_EtatCde;
            }

            // Submit the changes to the database.
            try
            {
                m_BD.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
        }


        #endregion

        #region ItemsCommande
        /// <summary>
        /// Retourne la liste de tous les items de la commande
        /// dont l'ID est p_noCde , ou null s'il n'y en a aucun. 
        /// </summary>
        public IQueryable<items_commande> GetAllItemsCommande(int p_noCde)
        {
            var listeItem = ((from element in m_BD.items_commande
                             where element.noCommande == p_noCde
                             select element).ToList().AsQueryable());
           
            return (IQueryable<items_commande>) listeItem;
        }


        #endregion

        #region Produits
        /// <summary>
        /// Retourne la liste de tous les produits
        /// dont l'ID est passé en paramètre. 
        /// </summary>
        public IQueryable<produits> GetAllProduits()
        {
            return m_BD.produits;
        }

        /// <summary>
        /// Retourne le produit
        /// dont l'ID est p_noPdt, ou null s'il n'y en a aucun. 
        /// </summary>
        public produits GetProduit(int p_noPdt)
        {
            return m_BD.produits.SingleOrDefault(
                u => (u.idProduit == p_noPdt));
        }

        #endregion

        #region Adresse

        /// <summary>
        /// Retourne l'adresse dont l'ID est 
        /// p_ID, ou null s'il n'y en a aucune.
        /// </summary>
        /// <param name="p_IdAdresse">Identifiant à rechercher</param>
        /// <returns>Une adresse ou null</returns>
        public adresses GetAdresse(int p_IdAdresse)
        {
            return m_BD.adresses.SingleOrDefault(
                u => (u.idAdrs == p_IdAdresse));
        }
        #endregion

        #region EtatCde
        /// <summary>
        /// Retourne la liste de tous les états de commande
        /// 
        /// </summary>
        public IQueryable<etatcommandes> GetAllEtatsCde()
        {
            return m_BD.etatcommandes;
        }

        
        #endregion

    }

	}

