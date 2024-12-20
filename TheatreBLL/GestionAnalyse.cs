using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TheatreBO;
using TheatreDAL;

namespace TheatreBLL
{
    public class GestionAnalyse
    {
        private static GestionAnalyse uneGestionAnalyse; // objet BLL

        // Accesseur en lecture
        public static GestionAnalyse GetGestionAnalyse()
        {
            if (uneGestionAnalyse == null)
            {
                uneGestionAnalyse = new GestionAnalyse();
            }
            return uneGestionAnalyse;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

       
        public static List<Analyse> AnalyseList()
        {
            return AnalyseDAO.AnalyseList();
        }
        public static List<Analyse> AnalyseListFiltre(DateTime Debut, DateTime Fin)
        {
            return AnalyseDAO.AnalyseListFiltre(Debut, Fin);
        }
    }
}
