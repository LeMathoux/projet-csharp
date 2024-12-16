using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            var dataList = new List<dynamic>();

            // Liste finale pour stocker les objets Pieces
            List<Pieces> piecesList = new List<Pieces>();

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();


            SqlCommand command = new SqlCommand(
                "SELECT id_piece as id, duree_piece AS Durée, tarif_base AS Prix, " +
                "nom_piece AS Nom, desc_piece AS Description, lib_public as typePublic, " +
                "lib_theme as Theme, nom_auteur, id_theme, id_auteur, id_public " +
                "FROM PIECE " +
                "JOIN THEME ON THEME.id_theme = PIECE.theme_id_piece " +
                "JOIN TYPE_PUBLIC ON TYPE_PUBLIC.id_public = PIECE.public_id_piece " +
                "JOIN AUTEUR ON AUTEUR.id_auteur = PIECE.auteur_id_piece",
                connection);

            SqlDataReader reader = command.ExecuteReader();

            // Lecture des données et stockage dans la liste temporaire
            while (reader.Read())
            {
                dataList.Add(new
                {
                    id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    Nom = reader["Nom"].ToString(),
                    Description = reader["Description"].ToString(),
                    Duree = reader["Durée"].ToString(),
                    Tarif = decimal.TryParse(reader["Prix"].ToString(), out decimal prix) ? prix : 0,
                    IdTheme = int.TryParse(reader["id_theme"].ToString(), out int idTheme) ? idTheme : 0,
                    Theme = reader["Theme"].ToString(),
                    IdAuteur = int.TryParse(reader["id_auteur"].ToString(), out int idAuteur) ? idAuteur : 0,
                    NomAuteur = reader["nom_auteur"].ToString(),
                    IdPublic = int.TryParse(reader["id_public"].ToString(), out int idPublic) ? idPublic : 0,
                    TypePublic = reader["typePublic"].ToString()
                });
            }

            // Fermeture du reader
            reader.Close();

            // Création des objets Pieces à partir des données extraites
            foreach (var Piece in dataList)
            {
                // Création des objets associés
                Auteur ObjetAuteur = new Auteur(Piece.IdAuteur, Piece.NomAuteur);
                Theme ObjetTheme = new Theme(Piece.IdTheme, Piece.Theme);
                Public ObjetPublic = new Public(Piece.IdPublic, Piece.TypePublic);

                // Création de l'objet Piece
                Pieces pieceObj = new Pieces(
                    Piece.id,
                    Piece.Nom,
                    Piece.Description,
                    Piece.Duree,
                    Piece.Tarif,
                    ObjetTheme,
                    ObjetPublic,
                    ObjetAuteur,
                    null
                );
                // On recupere les représentation de la pièce (on met dans une liste)

                List<Representation> representations = new List<Representation>(); // Liste finale des objets Representation

                SqlCommand command2 = new SqlCommand("SELECT id_rep as id, id_piece_rep AS Piece, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places AS NbPlaces, id_tarif_rep AS Tarif FROM REPRESENTATION where id_piece_rep=@pieceSelection", connection);
                command2.Parameters.AddWithValue("@pieceSelection", Piece.id);
                SqlDataReader reader2 = command2.ExecuteReader();

                // Lecture des données et création directe des objets Representation
                while (reader2.Read())
                {
                    int id = int.TryParse(reader["id"].ToString(), out id) ? id : 0;
                    int idPiece = int.TryParse(reader["Piece"].ToString(), out idPiece) ? idPiece : 0;
                    DateTime date = DateTime.TryParse(reader["Date"].ToString(), out date) ? date : DateTime.MinValue;
                    string lieu = reader["Lieu"].ToString();
                    int nbPlaces = int.TryParse(reader["NbPlaces"].ToString(), out nbPlaces) ? nbPlaces : 0;
                    int idTarif = int.TryParse(reader["Tarif"].ToString(), out idTarif) ? idTarif : 0;

                    // Instantiation des objets Pieces et Tarif ici, en fonction de vos besoins
                    Tarif tarif = new Tarif(idTarif, null, 0);  // Récupérer l'objet Tarif selon id

                    // Création et ajout de l'objet Representation à la liste
                    Representation representationObj = new Representation(id, pieceObj, date, lieu, nbPlaces, tarif);
                    representations.Add(representationObj);
                }

                // Fermeture du reader après lecture des données
                reader2.Close();
                // Fermeture de la connexion
                connection.Close();

                // On les comptes(taille de la liste)

                int nbRepresentation = representations.Count;

                // On calcul le nombre de spectateur total (pour chaque representation for sum des places vendu par rapport à idPiece dans la table representation)

                int nbSpectateurs = 0;
                int nbSpec = 0;
                decimal CA = 0;
                decimal TarifBase = 0;
                decimal pourcentage = 0;

                SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
                SqlCommand cmd = new SqlCommand();

                foreach (Representation repr in representations)
                {
                    cmd.Connection = maConnexion;
                    cmd.CommandText = "SELECT SUM(nbre_place_reserv) FROM Reservation WHERE Id_rep = @id_rep";
                    cmd.Parameters.AddWithValue("@id_rep", repr.IdRepresentation);

                    using (SqlDataReader reader3 = cmd.ExecuteReader())
                    {
                        if (reader3.Read())
                        {
                            nbSpec = reader3.GetInt32(0);
                        }
                    }

                    nbSpectateurs = nbSpectateurs + nbSpec;


                    cmd.Parameters.Clear();

                    SqlCommand command3 = new SqlCommand("SELECT tarif_base AS Prix FROM PIECE WHERE id_piece = @id", connection);
                    command3.Parameters.AddWithValue("@id", Piece.id);
                    SqlDataReader reader4 = command3.ExecuteReader();

                    if (reader4.Read())
                    {
                        decimal.TryParse(reader4["Prix"].ToString(), out TarifBase);
                    }

                    reader.Close();

                    SqlCommand command4 = new SqlCommand("SELECT var_tarif AS pourcentage FROM TARIF INNER JOIN REPRESENTATION ON id_tarif_rep = id_tarif WHERE id_rep = @id2", connection);
                    command4.Parameters.AddWithValue("@id2", repr.IdRepresentation);
                    SqlDataReader reader5 = command4.ExecuteReader();

                    if (reader5.Read())
                    {
                        decimal.TryParse(reader5["pourcentage"].ToString(), out pourcentage);
                    }

                    CA = CA + (TarifBase + (TarifBase * pourcentage / 100)) * nbSpec;

                }
                int nbSpectateursMoyen = nbSpectateurs / nbRepresentation;
                decimal CAMoyen = CA / nbRepresentation;


                Analyse uneAnalyse = new Analyse(pieceObj, nbRepresentation, nbSpectateurs, nbSpectateursMoyen, CA, CAMoyen);
                liste.Add(uneAnalyse);
            }

            // Fermeture de la connexion
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

            return liste;
        }




    }
}
