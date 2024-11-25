using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using TheatreBO;

namespace TheatreDAL
{
    public class PublicDAO
    {
        private static PublicDAO instance;

        // Singleton pour obtenir une instance de PublicDAO
        public static PublicDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new PublicDAO();
            }
            return instance;
        }
        public List<Public> GetPublics() // Correction du type de retour
        {
            List<Public> publics = new List<Public>(); // Correction du type de la liste
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_public as id, lib_public AS Lib FROM TYPE_PUBLIC", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id;
                int.TryParse(reader["id"].ToString(), out id);
                string lib = reader["Lib"].ToString();

                Public publicObj = new Public(id, lib); // Correction du type de l'objet et du nom de la variable
                publics.Add(publicObj);
            }

            reader.Close();
            connection.Close();

            return publics;
        }
        public Public GetPublicById(int id)
        {
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_public as id, lib_public AS Lib FROM TYPE_PUBLICE WHERE id = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();

            string lib = reader["Lib"].ToString();

            Public publicObj = new Public(id, lib); // Correction du type de l'objet et du nom de la variable
               
            reader.Close();
            connection.Close();

            return publicObj;
        }
    }
}
