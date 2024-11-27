using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBLL;
using TheatreBO;
using TheatreDAL;

namespace UtilisateursBLL
{
    public class GestionTarifs
    {
        private static GestionTarifs uneGestionTaifs; // objet BLL
        // Accesseur en lecture
        public static GestionTarifs getGestionTarifs()
        {
            if (uneGestionTaifs == null)
            {
                uneGestionTaifs = new GestionTarifs();
            }
            return uneGestionTaifs;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Piece en faisant appel à la méthode GetPieces() de la DAL
        public static List<Tarif> GetTarifs()
        {
            return TarifDAO.GetInstance().GetTarifs();
        }

    }
}
