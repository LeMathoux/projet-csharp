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
    public class GestionPublics
    {
        private static GestionPublics uneGestionPublics; // objet BLL

        // Accesseur en lecture
        public static GestionPublics GetGestionPublics()
        {
            if (uneGestionPublics == null)
            {
                uneGestionPublics = new GestionPublics();
            }
            return uneGestionPublics;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Public en faisant appel à la méthode GetPublic() de la DAL
        public static List<Public> GetPublics()
        {
            return PublicDAO.GetInstance().GetPublics();
        }
    }
}
