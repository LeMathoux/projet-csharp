using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheatreBO;

namespace TheatreDAL
{
    public class PieceDAO
    {
        private static PieceDAO instance;

        // Singleton pour obtenir une instance de PieceDAO
        public static PieceDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new PieceDAO();
            }
            return instance;
        }

        // Méthode pour récupérer les données des pièces
        public static List<Pieces> GetPieces()
        {
            List<Pieces> pieces = new List<Pieces>();
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT * FROM PIECE", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int.TryParse(reader["id_piece"].ToString(), out int id);
                int.TryParse(reader["duree_piece"].ToString(), out int duree);
                decimal.TryParse(reader["tarif_base"].ToString(), out decimal tarif);
                
               string nom = reader["nom_piece"].ToString();
               string description = reader["desc_piece"].ToString();

               Pieces piece = new Pieces(id, nom, description, duree, tarif);
               pieces.Add(piece);
                
            }

            reader.Close();
            connection.Close();

            return pieces;
        }
    }
}
