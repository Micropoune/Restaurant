using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant
{
    public class Client : Utilisateur
    {
        private string m_Email;
        private string m_Adresse;
        private string m_Telephone;

        public string getEmail()
        {
            return this.m_Email;
        }

        public void setEmail(string p_Email)
        {
            this.m_Email = p_Email;
        }

        public string getAdresse()
        {
            return this.m_Adresse;
        }

        public string getTelephone()
        {
            return this.m_Telephone;
        }

        public void setTelephone(string p_Telephone)
        {
            this.m_Telephone = p_Telephone;  
        }
    }
}