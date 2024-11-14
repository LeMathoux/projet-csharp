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

            SqlCommand command = new SqlCommand("SELECT duree_piece AS Durée, tarif_base AS Prix, nom_piece AS Nom, desc_piece AS Description, lib_public as typePublic, lib_theme as Theme, nom_auteur FROM PIECE JOIN THEME ON THEME.id_theme = PIECE.theme_id_piece JOIN TYPE_PUBLIC ON TYPE_PUBLIC.id_public = PIECE.public_id_piece jOIN AUTEUR ON AUTEUR.id_auteur = PIECE.auteur_id_piece", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string theme = reader["Theme"].ToString();
                string auteur = reader["nom_auteur"].ToString();
                string typePublic = reader["typePublic"].ToString();
                string duree = reader["Durée"].ToString();
                decimal.TryParse(reader["Prix"].ToString(), out decimal tarif);

                string nom = reader["Nom"].ToString();
                string description = reader["Description"].ToString();

                // Convertir la durée en minutes (ou en heures selon vos besoins)
                Pieces piece = new Pieces(nom, description, duree, tarif, theme, typePublic,auteur);
                pieces.Add(piece);
            }

            reader.Close();
            connection.Close();

            return pieces;
        }
    }
}