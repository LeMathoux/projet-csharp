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
    public class GestionRepresentations
    {
        private static GestionRepresentations uneGestionRepresentations; // objet BLL

        // Accesseur en lecture
        public static GestionRepresentations GetGestionRepresentations()
        {
            if (uneGestionRepresentations == null)
            {
                uneGestionRepresentations = new GestionRepresentations();
            }
            return uneGestionRepresentations;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Representations en faisant appel à la méthode GetRepresentations() de la DAL
        public static List<Representation> GetRepresentations()
        {
            return RepresentationDAO.GetInstance().GetRepresentations();
        }
    }
}
