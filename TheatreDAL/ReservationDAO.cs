using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TheatreBO;
using TheatreDAL;
using UtilisateursBO;

namespace UtilisateursDAL
{
    public class ReservationDAO
    {
        private static ReservationDAO instance;

        // Singleton pour obtenir une instance de ReservationDAO
        public static ReservationDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new ReservationDAO();
            }
            return instance;
        }

        public List<Reservation> GetReservations()
        {
            List<Reservation> Reservations = new List<Reservation>(); // Liste finale des objets Reservations

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_reserv as id, id_rep AS idRepresentation, nbre_place_reserv AS Places, id_client AS idClient FROM RESERVATION", connection);
            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données et stockage dans la liste temporaire
            while (reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    IdRep = int.TryParse(reader["idRepresentation"].ToString(), out int idRep) ? idRep : 0,
                    IdClient = int.TryParse(reader["IdClient"].ToString(), out int idClient) ? idClient : 0,
                    nbrePlacesReserv = int.TryParse(reader["Places"].ToString(), out int nbrePlaces) ? nbrePlaces : 0,
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création des objets Reservations à partir des données extraites
            foreach (var data in dataList)
            {
                Representation representation = RepresentationDAO.GetRepresentationById(data.IdRep);
                Client client = ClientDAO.GetClientById(data.IdClient);

                Reservation reservationObj = new Reservation(data.Id, representation, data.nbrePlacesReserv, client);
                Reservations.Add(reservationObj);
            }

            return Reservations;

        }
    }
}
