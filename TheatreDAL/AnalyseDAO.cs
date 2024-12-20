using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using TheatreBO;

namespace TheatreDAL
{
    public class AnalyseDAO
    {
        private static AnalyseDAO instance;

        public object GestionAnalyse { get; private set; }

        // Singleton pour obtenir une instance de AnalyseDAO
        public static AnalyseDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new AnalyseDAO();
            }
            return instance;
        }

        public static List<Analyse> AnalyseList()
        {
            List<Analyse> liste = new List<Analyse>();

            // Connexion SQL partagée pour toutes les requêtes
            using (SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                // Récupération des pièces
                List<Pieces> piecesList = GetPieces(connection);

                foreach (Pieces pieceObj in piecesList)
                {
                    // Récupérer les représentations pour chaque pièce
                    List<Representation> representations = GetRepresentations(pieceObj, connection);

                    int nbRepresentation = representations.Count;
                    int nbSpectateurs = 0;
                    decimal CA = 0;

                    // Calcul des statistiques pour chaque représentation
                    foreach (Representation repr in representations)
                    {
                        int nbSpec = GetTotalSpectateurs(repr.IdRepresentation, connection);
                        decimal TarifBase = GetTarifBase(pieceObj.IdPiece, connection);
                        decimal pourcentage = GetPourcentageTarif(repr.IdRepresentation, connection);

                        nbSpectateurs += nbSpec;
                        CA += (TarifBase + (TarifBase * pourcentage / 100)) * nbSpec;
                    }

                    // Calcul des moyennes
                    decimal nbSpectateursMoyen = nbRepresentation > 0 ? (decimal)nbSpectateurs / nbRepresentation : 0;
                    decimal CAMoyen = nbRepresentation > 0 ? CA / nbRepresentation : 0;

                    // Ajout de l'analyse à la liste
                    Analyse uneAnalyse = new Analyse(pieceObj, nbRepresentation, nbSpectateurs, nbSpectateursMoyen, CA, CAMoyen);
                    liste.Add(uneAnalyse);
                }
            }

            return liste;
        }

        private static List<Pieces> GetPieces(SqlConnection connection)
        {
            List<Pieces> piecesList = new List<Pieces>();

            string query = @"
        SELECT id_piece as id, duree_piece AS Durée, tarif_base AS Prix, 
               nom_piece AS Nom, desc_piece AS Description, lib_public as typePublic, 
               lib_theme as Theme, nom_auteur, id_theme, id_auteur, id_public 
        FROM PIECE 
        JOIN THEME ON THEME.id_theme = PIECE.theme_id_piece 
        JOIN TYPE_PUBLIC ON TYPE_PUBLIC.id_public = PIECE.public_id_piece 
        JOIN AUTEUR ON AUTEUR.id_auteur = PIECE.auteur_id_piece";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Auteur auteur = new Auteur(Convert.ToInt32(reader["id_auteur"]), reader["nom_auteur"].ToString());
                    Theme theme = new Theme(Convert.ToInt32(reader["id_theme"]), reader["Theme"].ToString());
                    Public publicType = new Public(Convert.ToInt32(reader["id_public"]), reader["typePublic"].ToString());

                    Pieces piece = new Pieces(
                        Convert.ToInt32(reader["id"]),
                        reader["Nom"].ToString(),
                        reader["Description"].ToString(),
                        reader["Durée"].ToString(),
                        Convert.ToDecimal(reader["Prix"]),
                        theme,
                        publicType,
                        auteur,
                        null
                    );

                    piecesList.Add(piece);
                }
            }

            return piecesList;
        }

        private static List<Representation> GetRepresentations(Pieces piece, SqlConnection connection)
        {
            List<Representation> representations = new List<Representation>();

            string query = "SELECT id_rep, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places, id_tarif_rep FROM REPRESENTATION WHERE id_piece_rep = @idPiece";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idPiece", piece.IdPiece);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarif tarif = new Tarif(Convert.ToInt32(reader["id_tarif_rep"]), null, 0);
                        Representation representation = new Representation(
                            Convert.ToInt32(reader["id_rep"]),
                            piece,
                            Convert.ToDateTime(reader["Date"]),
                            reader["Lieu"].ToString(),
                            Convert.ToInt32(reader["nbre_places"]),
                            tarif
                        );

                        representations.Add(representation);
                    }
                }
            }

            return representations;
        }

        private static int GetTotalSpectateurs(int idRepresentation, SqlConnection connection)
        {
            string query = "SELECT SUM(nbre_place_reserv) FROM Reservation WHERE Id_rep = @id_rep";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id_rep", idRepresentation);
                return (command.ExecuteScalar() as int?) ?? 0;
            }
        }

        public static decimal GetTarifBase(int idPiece, SqlConnection connection)
        {
            decimal tarifBase = 0;

            string query = "SELECT ISNULL(tarif_base, 0) FROM PIECE WHERE id_piece = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", idPiece);

                var result = command.ExecuteScalar();

                // Convertir le résultat en decimal, peu importe le type initial
                tarifBase = Convert.ToDecimal(result);

                return tarifBase;
            }
        }


        private static decimal GetPourcentageTarif(int idRepresentation, SqlConnection connection)
        {
            decimal pourcentage = 0;

            string query = "SELECT var_tarif FROM TARIF INNER JOIN REPRESENTATION ON REPRESENTATION.id_tarif_rep = TARIF.id_tarif WHERE REPRESENTATION.id_rep = @id_rep;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id_rep", idRepresentation);
                var result = command.ExecuteScalar();

                // Convertir le résultat en decimal, peu importe le type initial
                pourcentage = Convert.ToDecimal(result);

                return pourcentage;
            }
        }

        public static List<Analyse> AnalyseListFiltre(DateTime Debut, DateTime Fin)
        {
            List<Analyse> liste = new List<Analyse>();

            // Connexion SQL partagée pour toutes les requêtes
            using (SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                // Récupération des pièces
                List<Pieces> piecesList = GetPieces(connection);

                foreach (Pieces pieceObj in piecesList)
                {
                    // Récupérer les représentations pour chaque pièce
                    List<Representation> representations = GetRepresentationsFiltre(pieceObj, Debut, Fin, connection);

                    int nbRepresentation = representations.Count;
                    int nbSpectateurs = 0;
                    decimal CA = 0;

                    // Calcul des statistiques pour chaque représentation
                    foreach (Representation repr in representations)
                    {
                        int nbSpec = GetTotalSpectateurs(repr.IdRepresentation, connection);
                        decimal TarifBase = GetTarifBase(pieceObj.IdPiece, connection);
                        decimal pourcentage = GetPourcentageTarif(repr.IdRepresentation, connection);

                        nbSpectateurs += nbSpec;
                        CA += (TarifBase + (TarifBase * pourcentage / 100)) * nbSpec;
                    }

                    // Calcul des moyennes
                    decimal nbSpectateursMoyen = nbRepresentation > 0 ? (decimal)nbSpectateurs / nbRepresentation : 0;
                    decimal CAMoyen = nbRepresentation > 0 ? CA / nbRepresentation : 0;

                    // Ajout de l'analyse à la liste
                    Analyse uneAnalyse = new Analyse(pieceObj, nbRepresentation, nbSpectateurs, nbSpectateursMoyen, CA, CAMoyen);
                    liste.Add(uneAnalyse);
                }
            }

            return liste;
        }

        private static List<Representation> GetRepresentationsFiltre(Pieces piece, DateTime Debut, DateTime Fin, SqlConnection connection)
        {
            List<Representation> representations = new List<Representation>();

            string query = "SELECT id_rep, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places, id_tarif_rep FROM REPRESENTATION WHERE id_piece_rep = @idPiece AND horaire_rep BETWEEN @Debut AND @Fin";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idPiece", piece.IdPiece);
                command.Parameters.AddWithValue("@Debut", Debut);
                command.Parameters.AddWithValue("@Fin", Fin);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarif tarif = new Tarif(Convert.ToInt32(reader["id_tarif_rep"]), null, 0);
                        Representation representation = new Representation(
                            Convert.ToInt32(reader["id_rep"]),
                            piece,
                            Convert.ToDateTime(reader["Date"]),
                            reader["Lieu"].ToString(),
                            Convert.ToInt32(reader["nbre_places"]),
                            tarif
                        );

                        representations.Add(representation);
                    }
                }
            }

            return representations;
        }
    }
}
