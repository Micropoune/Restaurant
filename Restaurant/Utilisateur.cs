using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant
{
    public class Utilisateur
    {
        private string m_IdUtilisateur;
        private string m_MotDePasse;
        private string m_Prenom;
        private string m_Nom;

        public Utilisateur()
        {

        }

        public string getId()
        {
            return this.m_IdUtilisateur;
        }

        public void setId(string p_Id)
        {
            this.m_IdUtilisateur = p_Id;
        }

        public string getMotDePasse()
        {
            return this.m_MotDePasse;
        }

        public void setMotDePasse(string p_MotDePasse)
        {
            this.m_MotDePasse = p_MotDePasse;
        }

        public string getPrenom()
        {
            return this.m_Prenom;
        }

        public void setPrenom(string p_Prenom)
        {
            this.m_Prenom = p_Prenom; 
        }

        public string getNom()
        {
            return this.m_Nom;
        }

        public void setNom(string p_Nom)
        {
            this.m_Nom = p_Nom;
        }

        public void authentifier(string p_Id, string p_MotDePasse, string p_Url)
        {

        }
    }
}