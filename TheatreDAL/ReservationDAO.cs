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

        // Méthode pour ajouter une réservation
        public static bool AjouterReservation(Reservation reservation)
        {
            int nbEnr;

            int idRepresentation = reservation.Representation.IdRepresentation;
            int nbPlaces = reservation.NombresPlaces;

            string nomClient = reservation.Client.NomClient;
            string prenomClient = reservation.Client.PrenomClient;
            string mailClient = reservation.Client.MailClient;
            string telClient = reservation.Client.TelClient;

            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();

            // Vérifie le nombre de places disponibles pour la représentation
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT NbPlacesRepresentation FROM Representation WHERE IdRepresentation = @id_rep";
            cmd.Parameters.AddWithValue("@id_rep", idRepresentation);

            int nbPlacesDisponibles = (int)cmd.ExecuteScalar();

            cmd.Parameters.Clear();

            cmd.CommandText = "SELECT SUM(nbre_place_reserv) FROM Reservation WHERE Id_rep = @id_rep";
            cmd.Parameters.AddWithValue("@id_rep", idRepresentation);

            int nbPlacesDisponiblesReste = nbPlacesDisponibles - (int)cmd.ExecuteScalar();

            if (nbPlaces > nbPlacesDisponiblesReste)
            {
                // Pas assez de places disponibles
                maConnexion.Close();
                return false;
            }

            // Réinitialise les paramètres de la commande
            cmd.Parameters.Clear();

            cmd.CommandText = "INSERT INTO CLIENT (nom_client, prenom_client, mail_client, tel_client) " +
                              "VALUES (@nom_client, @prenom_client, @mail_client, @tel_client)";

            cmd.Parameters.AddWithValue("@nom_client", nomClient);
            cmd.Parameters.AddWithValue("@prenom_client", prenomClient);
            cmd.Parameters.AddWithValue("@mail_client", mailClient);
            cmd.Parameters.AddWithValue("@tel_client", telClient);

            nbEnr = cmd.ExecuteNonQuery();
            
            cmd.CommandText = "SELECT MAX(id_client) FROM CLIENT";

            int idClient = (int)cmd.ExecuteScalar();

            // Ajoute la réservation
            cmd.CommandText = "INSERT INTO RESERVATION (id_rep, nbre_place_reserv, id_client) " +
                              "VALUES (@id_rep, @nbre_place_reserv, @id_client)";

            cmd.Parameters.AddWithValue("@id_rep", idRepresentation);
            cmd.Parameters.AddWithValue("@nbre_place_reserv", nbPlaces);
            cmd.Parameters.AddWithValue("@id_client", idClient);

            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;
        }

    }
}

