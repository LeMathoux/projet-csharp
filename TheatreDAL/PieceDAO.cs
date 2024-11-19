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

            SqlCommand command = new SqlCommand("SELECT id_piece as id, duree_piece AS Durée, tarif_base AS Prix, nom_piece AS Nom, desc_piece AS Description, lib_public as typePublic, lib_theme as Theme, nom_auteur FROM PIECE JOIN THEME ON THEME.id_theme = PIECE.theme_id_piece JOIN TYPE_PUBLIC ON TYPE_PUBLIC.id_public = PIECE.public_id_piece jOIN AUTEUR ON AUTEUR.id_auteur = PIECE.auteur_id_piece", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id;

                int.TryParse(reader["id"].ToString(), out id);
                string theme = reader["Theme"].ToString();
                string auteur = reader["nom_auteur"].ToString();
                string typePublic = reader["typePublic"].ToString();
                string duree = reader["Durée"].ToString();
                decimal.TryParse(reader["Prix"].ToString(), out decimal tarif);

                string nom = reader["Nom"].ToString();
                string description = reader["Description"].ToString();

                // Convertir la durée en minutes (ou en heures selon vos besoins)
                Pieces piece = new Pieces(id, nom, description, duree, tarif, theme, typePublic,auteur);
                pieces.Add(piece);
            }

            reader.Close();
            connection.Close();

            return pieces;
        }


        public static bool DeletePiece(int id)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "DELETE FROM PIECE WHERE id_piece = " + id;
            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion

            maConnexion.Close();
            return true;
        }

        public static bool ajouterPiece(Pieces nouvellePiece)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "INSERT INTO PIECE (nom_piece, desc_piece, duree_piece, tarif_base, theme_id_piece, public_id_piece, auteur_id_piece) " +
                              "VALUES (@Nom, @Description, @Duree, @Tarif, @Theme, @Public, @Auteur)";

            int.TryParse(nouvellePiece.ThemePiece, out int idTheme);
            int.TryParse(nouvellePiece.PublicPiece, out int idPublic);
            int.TryParse(nouvellePiece.NomAuteur, out int idAuteur);
            double.TryParse(nouvellePiece.DureePiece, out double dureePiece);


            cmd.Parameters.AddWithValue("@Nom", nouvellePiece.NomPiece);
            cmd.Parameters.AddWithValue("@Description", nouvellePiece.DescPiece);
            cmd.Parameters.AddWithValue("@Duree", TimeSpan.FromHours(dureePiece));
            cmd.Parameters.AddWithValue("@Tarif", nouvellePiece.TarifBase);
            cmd.Parameters.AddWithValue("@Theme", idTheme);
            cmd.Parameters.AddWithValue("@Public", idPublic);
            cmd.Parameters.AddWithValue("@Auteur", idAuteur);

            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;
        }

        public static bool modifierPiece(Pieces nouvellePiece, int id)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "UPDATE PIECE SET nom_piece=@Nom, desc_piece=@Description, duree_piece=@Duree, tarif_base=@Tarif, theme_id_piece=@Theme, public_id_piece=@Public, auteur_id_piece=@Auteur WHERE id_piece=@id; ";

            int.TryParse(nouvellePiece.ThemePiece, out int idTheme);
            int.TryParse(nouvellePiece.PublicPiece, out int idPublic);
            int.TryParse(nouvellePiece.NomAuteur, out int idAuteur);
            double.TryParse(nouvellePiece.DureePiece, out double dureePiece);


            cmd.Parameters.AddWithValue("@Nom", nouvellePiece.NomPiece);
            cmd.Parameters.AddWithValue("@Description", nouvellePiece.DescPiece);
            cmd.Parameters.AddWithValue("@Duree", TimeSpan.FromHours(dureePiece));
            cmd.Parameters.AddWithValue("@Tarif", nouvellePiece.TarifBase);
            cmd.Parameters.AddWithValue("@Theme", idTheme);
            cmd.Parameters.AddWithValue("@Public", idPublic);
            cmd.Parameters.AddWithValue("@Auteur", idAuteur);
            cmd.Parameters.AddWithValue("@id", id);

            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;
        }
    }
}