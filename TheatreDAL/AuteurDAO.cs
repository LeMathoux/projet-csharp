using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheatreBO;

namespace TheatreDAL
{
    public class AuteurDAO
    {
        private static AuteurDAO instance;

        // Singleton pour obtenir une instance de AuteurDAO
        public static AuteurDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new AuteurDAO();
            }
            return instance;
        }
        public List<Auteur> GetAuteurs() // Correction du type de retour
        {
            List<Auteur> auteurs = new List<Auteur>(); // Correction du type de la liste
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_auteur as id, nom_auteur AS Nom FROM AUTEUR", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id;

                int.TryParse(reader["id"].ToString(), out id);
                string nom = reader["Nom"].ToString();

                Auteur auteur = new Auteur(id, nom); // Correction du type de l'objet
                auteurs.Add(auteur);
            }

            reader.Close();
            connection.Close();

            return auteurs;
        }
    }
}
