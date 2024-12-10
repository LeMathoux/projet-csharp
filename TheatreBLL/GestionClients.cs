using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBLL;
using TheatreBO;
using TheatreDAL;
using UtilisateursBO;
using UtilisateursDAL;

namespace UtilisateursBLL
{
    public class GestionClients
    {
        private static GestionClients uneGestionClients; // objet BLL

        // Accesseur en lecture
        public static GestionClients GetGestionClients()
        {
            if (uneGestionClients == null)
            {
                uneGestionClients = new GestionClients();
            }
            return uneGestionClients;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Clients en faisant appel à la méthode GetClients() de la DAL
        public static List<Client> GetClients()
        {
            return ClientDAO.GetInstance().GetClients();
        }
    }
}
