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
        // Singleton pour l'instance de ReservationDAO
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

        // Méthode pour obtenir une liste de réservations
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
                // Récupère la représentation et le client associé à la réservation
                Representation representation = RepresentationDAO.GetRepresentationById(data.IdRep);
                Client client = ClientDAO.GetClientById(data.IdClient);

                // Crée l'objet Reservation
                Reservation reservationObj = new Reservation(data.Id, representation, data.nbrePlacesReserv, client);
                Reservations.Add(reservationObj);
            }

            return Reservations;

        }

        // Méthode pour ajouter une réservation
        public static bool AjouterReservation(Reservation reservation, int idRepresentation)
        {
            int nbEnr;

            int nbPlaces = reservation.NombresPlaces;
            string nomClient = reservation.Client.NomClient;
            string prenomClient = reservation.Client.PrenomClient;
            string mailClient = reservation.Client.MailClient;
            string telClient = reservation.Client.TelClient;

            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();

            // Vérifie le nombre de places disponibles pour la représentation
            cmd.Connection = maConnexion;
            // Première requête : Récupérer le nombre de places disponibles
            cmd.CommandText = "SELECT nbre_places FROM Representation WHERE id_rep = @id_rep1";
            cmd.Parameters.AddWithValue("@id_rep1", idRepresentation);

            int nbPlacesDisponibles = 0;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Vérification pour éviter les valeurs NULL
                    if (!reader.IsDBNull(0))
                    {
                        nbPlacesDisponibles = reader.GetInt32(0);
                    }
                    else
                    {
                        nbPlacesDisponibles = 0; // Valeur par défaut si NULL
                    }
                }
            }

            cmd.Parameters.Clear();

            // Deuxième requête : Récupérer la somme des places réservées
            int nbPlacesReserv = 0;
            cmd.CommandText = "SELECT SUM(nbre_place_reserv) FROM Reservation WHERE Id_rep = @id_rep2";
            cmd.Parameters.AddWithValue("@id_rep2", idRepresentation);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Vérification pour éviter les valeurs NULL
                    if (!reader.IsDBNull(0))
                    {
                        nbPlacesReserv = reader.GetInt32(0);
                    }
                    else
                    {
                        nbPlacesReserv = 0; // Valeur par défaut si NULL
                    }
                }
            }

            cmd.Parameters.Clear();


            int nbPlacesDisponiblesReste = nbPlacesDisponibles - nbPlacesReserv;

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
                              "VALUES (@id_repp, @nbre_place_reserv, @id_client)";

            cmd.Parameters.AddWithValue("@id_repp", idRepresentation);
            cmd.Parameters.AddWithValue("@nbre_place_reserv", nbPlaces);
            cmd.Parameters.AddWithValue("@id_client", idClient);

            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr > 0;
        }

        public static bool DeleteReservation(int id)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "DELETE FROM RESERVATION WHERE id_reserv = @id";
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


        // Méthode pour mettre à jour une réservation
        public static bool ModifierReservation(Reservation reservation, int idReservation)
        {
            // Nombre d'enregistrements affectés
            int nbEnr;
            // Récupère les informations de la réservation
            int idRepresentation = reservation.Representation.IdRepresentation;
            int nbPlaces = reservation.NombresPlaces;
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            // Vérifie le nombre de places disponibles pour la représentation
            cmd.Connection = maConnexion;
            // Première requête : Récupérer le nombre de places disponibles
            cmd.CommandText = "SELECT nbre_places FROM Representation WHERE id_rep = @id_rep1";
            cmd.Parameters.AddWithValue("@id_rep1", idRepresentation);

            int nbPlacesDisponibles = 0;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Vérification pour éviter les valeurs NULL
                    if (!reader.IsDBNull(0))
                    {
                        nbPlacesDisponibles = reader.GetInt32(0);
                    }
                    else
                    {
                        nbPlacesDisponibles = 0; // Valeur par défaut si NULL
                    }
                }
            }

            cmd.Parameters.Clear();

            // Deuxième requête : Récupérer la somme des places réservées
            int nbPlacesReserv = 0;
            cmd.CommandText = "SELECT SUM(nbre_place_reserv) FROM Reservation WHERE Id_rep = @id_rep2";
            cmd.Parameters.AddWithValue("@id_rep2", idRepresentation);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Vérification pour éviter les valeurs NULL
                    if (!reader.IsDBNull(0))
                    {
                        nbPlacesReserv = reader.GetInt32(0);
                    }
                    else
                    {
                        nbPlacesReserv = 0; // Valeur par défaut si NULL
                    }
                }
            }

            cmd.Parameters.Clear();


            int nbPlacesDisponiblesReste = nbPlacesDisponibles - nbPlacesReserv;

            if (nbPlaces > nbPlacesDisponiblesReste)
            {
                // Pas assez de places disponibles
                maConnexion.Close();
                return false;
            }

            cmd.CommandText = "SELECT id_client FROM RESERVATION WHERE Id_reserv = @id_reserv";
            cmd.Parameters.AddWithValue("@id_reserv", idReservation);

            int idClient = (int)cmd.ExecuteScalar();

            // Réinitialise les paramètres de la commande
            cmd.Parameters.Clear();
            // Met à jour la réservation
            cmd.CommandText = "UPDATE RESERVATION SET nbre_place_reserv = @nbre_place_reserv, id_rep = @id_repr " +
                              "WHERE id_reserv = @id_reserv;" +
                              "UPDATE CLIENT SET nom_client = @nom_client, prenom_client = @prenom_client, mail_client = @mail_client, tel_client = @tel_client " +
                              "WHERE id_client = @id_client";
            cmd.Parameters.AddWithValue("@id_repr", idRepresentation);
            cmd.Parameters.AddWithValue("@nbre_place_reserv", nbPlaces);
            cmd.Parameters.AddWithValue("@id_reserv", idReservation);
            cmd.Parameters.AddWithValue("@nom_client", reservation.Client.NomClient);
            cmd.Parameters.AddWithValue("@prenom_client", reservation.Client.PrenomClient);
            cmd.Parameters.AddWithValue("@mail_client", reservation.Client.MailClient);
            cmd.Parameters.AddWithValue("@tel_client", reservation.Client.TelClient);
            cmd.Parameters.AddWithValue("@id_client", idClient);
            nbEnr = cmd.ExecuteNonQuery(); 
            maConnexion.Close();
            return nbEnr > 0;
        }


    }
}

