using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using TheatreBO;
using UtilisateursDAL;

namespace TheatreDAL
{
    public class RepresentationDAO
    {
        private static RepresentationDAO instance;

        // Singleton pour obtenir une instance de RepresentationDAO
        public static RepresentationDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new RepresentationDAO();
            }
            return instance;
        }
        public List<Representation> GetRepresentations()
        {
            List<Representation> representations = new List<Representation>(); // Liste finale des objets Representation

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_rep as id, id_piece_rep AS Piece, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places AS NbPlaces, id_tarif_rep AS Tarif FROM REPRESENTATION", connection);
            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données et stockage dans la liste temporaire
            while (reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    IdPiece = int.TryParse(reader["Piece"].ToString(), out int idPiece) ? idPiece : 0,
                    Date = DateTime.TryParse(reader["Date"].ToString(), out DateTime date) ? date : DateTime.MinValue,
                    IdLieu = int.TryParse(reader["Lieu"].ToString(), out int idLieu) ? idLieu : 0,
                    NbPlaces = int.TryParse(reader["NbPlaces"].ToString(), out int nbPlaces) ? nbPlaces : 0,
                    IdTarif = int.TryParse(reader["Tarif"].ToString(), out int idTarif) ? idTarif : 0
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création des objets Representation à partir des données extraites
            foreach (var data in dataList)
            {
                Pieces piece = PieceDAO.GetPieceById(data.IdPiece);
                Tarif tarif = TarifDAO.GetTarifById(data.IdTarif);
                Lieu unLieu = LieuDAO.GetLieuById(data.IdLieu);

                Representation representationObj = new Representation(data.Id, piece, data.Date, unLieu, data.NbPlaces, tarif);
                representations.Add(representationObj);
            }

            return representations;
        }

        public static Representation GetRepresentationById(int idrep)
        {

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_rep as id, id_piece_rep AS Piece, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places AS NbPlaces, id_tarif_rep AS Tarif FROM REPRESENTATION where id_rep=@id", connection);
            command.Parameters.AddWithValue("@id", idrep);
            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données
            if(reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    IdPiece = int.TryParse(reader["Piece"].ToString(), out int idPiece) ? idPiece : 0,
                    Date = DateTime.TryParse(reader["Date"].ToString(), out DateTime date) ? date : DateTime.MinValue,
                    IdLieu = int.TryParse(reader["Lieu"].ToString(), out int idLieu) ? idLieu : 0,
                    NbPlaces = int.TryParse(reader["NbPlaces"].ToString(), out int nbPlaces) ? nbPlaces : 0,
                    IdTarif = int.TryParse(reader["Tarif"].ToString(), out int idTarif) ? idTarif : 0
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création de l'objet Representation à partir des données extraites
            Pieces piece = PieceDAO.GetPieceById(dataList[0].IdPiece);
            Tarif tarif = TarifDAO.GetTarifById(dataList[0].IdTarif);
            Lieu lieu = LieuDAO.GetLieuById(dataList[0].IdLieu);

            Representation representation = new Representation(dataList[0].Id, piece, dataList[0].Date, lieu, dataList[0].NbPlaces, tarif);

            return representation;
        }

        public static List<Representation> GetRepresentationByPiece(int pieceSelection)
        {
            List<Representation> representations = new List<Representation>(); // Liste finale des objets Representation

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_rep as id, id_piece_rep AS Piece, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places AS NbPlaces, id_tarif_rep AS Tarif FROM REPRESENTATION where id_piece_rep=@pieceSelection", connection);
            command.Parameters.AddWithValue("@pieceSelection", pieceSelection);
            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données et stockage dans la liste temporaire
            while (reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    IdPiece = int.TryParse(reader["Piece"].ToString(), out int idPiece) ? idPiece : 0,
                    Date = DateTime.TryParse(reader["Date"].ToString(), out DateTime date) ? date : DateTime.MinValue,
                    IdLieu = int.TryParse(reader["Lieu"].ToString(), out int idLieu) ? idLieu : 0,
                    NbPlaces = int.TryParse(reader["NbPlaces"].ToString(), out int nbPlaces) ? nbPlaces : 0,
                    IdTarif = int.TryParse(reader["Tarif"].ToString(), out int idTarif) ? idTarif : 0
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création des objets Representation à partir des données extraites
            foreach (var data in dataList)
            {
                Pieces piece = null;
                Tarif tarif = null;
                Lieu lieu = null;

                Representation representationObj = new Representation(data.Id, piece, data.Date, lieu, data.NbPlaces, tarif);
                representations.Add(representationObj);
            }

            return representations;
        }




        public List<Representation> GetRepresentationsFiltre(int pieceFiltre, DateTime DebutFiltre, DateTime FinFiltre)
        {
            List<Representation> representations = new List<Representation>(); // Liste finale des objets Representation

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Requête SQL avec un WHERE et des paramètres
            string query = @"
            SELECT 
                id_rep as id, 
                id_piece_rep AS Piece, 
                horaire_rep AS Date, 
                lieu_rep AS Lieu, 
                nbre_places AS NbPlaces, 
                id_tarif_rep AS Tarif 
            FROM REPRESENTATION 
            WHERE 
                id_piece_rep = @IdPiece 
                AND horaire_rep BETWEEN @DateStart AND @DateEnd";

            // Création de la commande
            SqlCommand command = new SqlCommand(query, connection);

            // Ajout des paramètres
            command.Parameters.AddWithValue("@IdPiece", pieceFiltre); 
            command.Parameters.AddWithValue("@DateStart", DebutFiltre); 
            command.Parameters.AddWithValue("@DateEnd", FinFiltre); 

            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données et stockage dans la liste temporaire
            while (reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    IdPiece = int.TryParse(reader["Piece"].ToString(), out int idPiece) ? idPiece : 0,
                    Date = DateTime.TryParse(reader["Date"].ToString(), out DateTime date) ? date : DateTime.MinValue,
                    IdLieu = int.TryParse(reader["Lieu"].ToString(), out int idLieu) ? idLieu : 0,
                    NbPlaces = int.TryParse(reader["NbPlaces"].ToString(), out int nbPlaces) ? nbPlaces : 0,
                    IdTarif = int.TryParse(reader["Tarif"].ToString(), out int idTarif) ? idTarif : 0
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création des objets Representation à partir des données extraites
            foreach (var data in dataList)
            {
                Pieces piece = PieceDAO.GetPieceById(data.IdPiece);
                Tarif tarif = TarifDAO.GetTarifById(data.IdTarif);
                Lieu lieu = LieuDAO.GetLieuById(data.IdLieu);

                Representation representationObj = new Representation(data.Id, piece, data.Date, lieu, data.NbPlaces, tarif);
                representations.Add(representationObj);
            }

            return representations;
        }

        public static bool DeleteRepresentation(int id)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "DELETE FROM REPRESENTATION WHERE id_rep = @id";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                nbEnr = cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                maConnexion.Close();
                return nbEnr > 0;
            }
            catch
            {
                maConnexion.Close();
                return false;
            }
        }

        public static bool AjouterRepresentiation(Representation representation)
        {
            int nbEnr;

            int idPiece = representation.PieceRepresentation.IdPiece;
            int idTarif = representation.TarifRepresentation.IdTarif;
            int nbPlaces = representation.NbPlacesRepresentation;
            int lieuRepresentation = representation.LieuRepresentation.IdLieu;
            DateTime date = representation.DateRepresentation.Date;

            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = maConnexion;
            cmd.CommandText = "INSERT INTO REPRESENTATION (horaire_rep, lieu_rep, nbre_places, id_piece_rep, id_tarif_rep) " +
                              "VALUES (@date, @lieu, @places, @piece,@tarif)";

            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@lieu", lieuRepresentation);
            cmd.Parameters.AddWithValue("@places", nbPlaces);
            cmd.Parameters.AddWithValue("@piece", idPiece);
            cmd.Parameters.AddWithValue("@tarif", idTarif);

            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;

        }

        public static bool ModifierRepresentation(Representation representation, int id)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "UPDATE REPRESENTATION SET horaire_rep=@Horaire, lieu_rep=@Lieu, nbre_places=@NombreDePlaces, id_piece_rep=@Piece, id_tarif_rep=@Tarif WHERE id_rep=@id";

            // Récupérer les valeurs de la représentation
            int idPiece = representation.PieceRepresentation.IdPiece;
            int idTarif = representation.TarifRepresentation.IdTarif;
            int nbPlaces = representation.NbPlacesRepresentation;
            int lieuRepresentation = representation.LieuRepresentation.IdLieu;
            DateTime date = representation.DateRepresentation;

            // Ajouter les paramètres à la commande
            cmd.Parameters.AddWithValue("@Horaire", date);
            cmd.Parameters.AddWithValue("@Lieu", lieuRepresentation);
            cmd.Parameters.AddWithValue("@NombreDePlaces", nbPlaces);
            cmd.Parameters.AddWithValue("@Piece", idPiece);
            cmd.Parameters.AddWithValue("@Tarif", idTarif);
            cmd.Parameters.AddWithValue("@id", id);

            // Exécuter la commande
            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;
        }
    }
}
