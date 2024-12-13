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
    public class GestionPieces
    {

        private static GestionPieces uneGestionPieces; // objet BLL

        // Accesseur en lecture
        public static GestionPieces GetGestionPieces()
        {
            if (uneGestionPieces == null)
            {
                uneGestionPieces = new GestionPieces();
            }
            return uneGestionPieces;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Piece en faisant appel à la méthode GetPieces() de la DAL
        public static List<Pieces> GetPieces()
        {
            return PieceDAO.GetInstance().GetPieces();
        }

        public static bool supprimerPiece(int id)
        {
            return PieceDAO.DeletePiece(id);
        }

        public static bool modifierPiece(Pieces nouvellePiece, int id)
        {
            return PieceDAO.modifierPiece(nouvellePiece,id);
        }

        public static bool ajouterPiece(Pieces nouvellePiece)
        {
            return PieceDAO.ajouterPiece(nouvellePiece);
        }
        public static decimal GetTarif(int PieceTarif)
        {
            return PieceDAO.GetTarif(PieceTarif);
        }

    }
}
