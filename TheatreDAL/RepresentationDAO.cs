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
        public List<Representation> GetRepresentations() // Correction du type de retour
        {
            List<Representation> representations = new List<Representation>(); // Correction du type de la liste

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_rep as id, id_piece_rep AS Piece, horaire_rep AS Date, lieu_rep AS Lieu, nbre_places AS NbPlaces, id_tarif_rep AS Tarif FROM REPRESENTATION", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int.TryParse(reader["id"].ToString(), out int id);
                Pieces piece = PieceDAO.GetPieceById(int.Parse(reader["Piece"].ToString()));
                DateTime date = DateTime.Parse(reader["Date"].ToString());
                string lieu = reader["Lieu"].ToString();
                int.TryParse(reader["NbPlaces"].ToString(), out int nbPlaces);
                Tarif tarif = TarifDAO.GetTarifById(int.Parse(reader["Tarif"].ToString()));

                Representation representationObj = new Representation(id, piece, date, lieu, nbPlaces, tarif); // Correction du type de l'objet et du nom de la variable
                representations.Add(representationObj);
            }

            reader.Close();
            connection.Close();

            return representations;
        }

    }
}
