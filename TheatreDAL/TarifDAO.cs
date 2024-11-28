using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheatreBO;

namespace TheatreDAL
{
    public class TarifDAO
    {
        private static TarifDAO instance;

        // Singleton pour obtenir une instance de TarifDAO
        public static TarifDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new TarifDAO();
            }
            return instance;
        }
        public List<Tarif> GetTarifs() // Correction du type de retour
        {
            List<Tarif> tarifs = new List<Tarif>(); // Correction du type de la liste
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_tarif as id, lib_tarif AS Lib, var_tarif as tarif FROM TARIF", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id;
                int.TryParse(reader["id"].ToString(), out id);
                string lib = reader["Lib"].ToString();
                float tarif;
                float.TryParse(reader["tarif"].ToString(),out tarif);

                Tarif tarifObj = new Tarif(id, lib,tarif); // Correction du type de l'objet et du nom de la variable
                tarifs.Add(tarifObj);
            }

            reader.Close();
            connection.Close();

            return tarifs;
        }
        public static Tarif GetTarifById(int id)
        {
            SqlConnection connection = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand command = new SqlCommand("SELECT id_tarif as id, lib_tarif AS Lib, var_tarif AS Prix FROM TARIF WHERE id_tarif = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string lib = reader["Lib"].ToString();
                float.TryParse(reader["Prix"].ToString(), out float prix);

                Tarif tarif = new Tarif(id, lib, prix);
                reader.Close();
                connection.Close();

                return tarif;
            }
            else
            {
                reader.Close();
                connection.Close();
                return null;
            }
        }
    }
}

