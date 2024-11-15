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
    public class GestionAuteurs
    {
        private static GestionAuteurs uneGestionAuteurs; // objet BLL

        // Accesseur en lecture
        public static GestionAuteurs GetGestionAuteurs()
        {
            if (uneGestionAuteurs == null)
            {
                uneGestionAuteurs = new GestionAuteurs();
            }
            return uneGestionAuteurs;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Auteur en faisant appel à la méthode GetAuteurs() de la DAL
        public static List<Auteur> GetAuteurs()
        {
            return AuteurDAO.GetInstance().GetAuteurs();
        }
    }
}
