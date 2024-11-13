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

        public List<Pieces> GetPieces()
        {
            List<Pieces> pieces = new List<Pieces>();
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT duree_piece AS Durée, tarif_base AS Prix, nom_piece AS Nom, desc_piece AS Description FROM PIECE", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string duree = reader["Durée"].ToString();
                decimal.TryParse(reader["Prix"].ToString(), out decimal tarif);

                string nom = reader["Nom"].ToString();
                string description = reader["Description"].ToString();

                // Convertir la durée en minutes (ou en heures selon vos besoins)
                Pieces piece = new Pieces(nom, description, duree, tarif);
                pieces.Add(piece);
            }

            reader.Close();
            connection.Close();

            return pieces;
        }
    }
}