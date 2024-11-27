using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using TheatreBO;

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
                    Lieu = reader["Lieu"].ToString(),
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

                Representation representationObj = new Representation(data.Id, piece, data.Date, data.Lieu, data.NbPlaces, tarif);
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
            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;
        }


    }
}
