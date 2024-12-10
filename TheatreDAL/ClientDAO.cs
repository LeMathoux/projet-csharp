using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBO;
using TheatreDAL;
using UtilisateursBO;

namespace UtilisateursDAL
{
    public class ClientDAO
    {
        private static ClientDAO instance;

        // Singleton pour obtenir une instance de ClientDAO
        public static ClientDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new ClientDAO();
            }
            return instance;
        }

        public List<Client> GetClients()
        {
            List<Client> Clients = new List<Client>(); // Liste finale des objets Representation

            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_client as id, nom_client AS Nom, prenom_client AS Prenom, mail_client AS Mail, tel_client as TEL FROM CLIENT", connection);
            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données et stockage dans la liste temporaire
            while (reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    Nom = reader["Nom"].ToString(),
                    Prenom = reader["Prenom"].ToString(),
                    Mail = reader["Mail"].ToString(),
                    Tel = reader["Tel"].ToString(),
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création des objets Representation à partir des données extraites
            foreach (var data in dataList)
            {
                Client unClient = new Client(data.Id, data.Nom, data.Prenom, data.Mail, data.Tel);
                Clients.Add(unClient);
            }

            return Clients;
        }

        public static Client GetClientById(int idCli)
        {
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_client as id, nom_client AS Nom, prenom_client AS Prenom, mail_client AS Mail, tel_client as TEL FROM CLIENT where id_client=@id", connection);
            command.Parameters.AddWithValue("@id", idCli);
            SqlDataReader reader = command.ExecuteReader();

            // Liste temporaire pour stocker les données extraites
            var dataList = new List<dynamic>();

            // Lecture des données et stockage dans la liste temporaire
            if(reader.Read())
            {
                dataList.Add(new
                {
                    Id = int.TryParse(reader["id"].ToString(), out int id) ? id : 0,
                    Nom = reader["Nom"].ToString(),
                    Prenom = reader["Prenom"].ToString(),
                    Mail = reader["Mail"].ToString(),
                    Tel = reader["Tel"].ToString(),
                });
            }

            // Fermeture du reader après lecture des données
            reader.Close();
            // Fermeture de la connexion
            connection.Close();

            // Création des objets Representation à partir des données extraites
            Client unClient = new Client(dataList[0].Id, dataList[0].Nom, dataList[0].Prenom, dataList[0].Mail, dataList[0].Tel);

            return unClient;
        }
    }
}
