using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheatreBO;

namespace TheatreDAL
{
    public class ThemeDAO
    {
        private static ThemeDAO instance;

        // Singleton pour obtenir une instance de ThemeDAO
        public static ThemeDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new ThemeDAO();
            }
            return instance;
        }
        public List<Theme> GetThemes() // Correction du type de retour
        {
            List<Theme> themes = new List<Theme>(); // Correction du type de la liste
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_theme as id, lib_theme AS Lib FROM THEME", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id;

                int.TryParse(reader["id"].ToString(), out id);
                string lib = reader["Lib"].ToString();

                Theme theme = new Theme(id, lib); // Correction du type de l'objet
                themes.Add(theme);
            }

            reader.Close();
            connection.Close();

            return themes;
        }
        public Theme GetThemeById(int id) 
        {
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_theme as id, lib_theme AS Lib FROM THEME WHERE id = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();
            
            string lib = reader["Lib"].ToString();

            Theme theme = new Theme(id, lib);    

            reader.Close();
            connection.Close();

            return theme;
        }
    }
}

