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
    public class GestionThemes
    {
        private static GestionThemes uneGestionThemes; // objet BLL

        // Accesseur en lecture
        public static GestionThemes GetGestionThemes()
        {
            if (uneGestionThemes == null)
            {
                uneGestionThemes = new GestionThemes();
            }
            return uneGestionThemes;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Theme en faisant appel à la méthode GetThemes() de la DAL
        public static List<Theme> GetThemes()
        {
            return ThemeDAO.GetInstance().GetThemes();
        }
        public static Theme GetThemeById(int id)
        {
            return ThemeDAO.GetInstance().GetThemeById(id);
        }
    }
}
