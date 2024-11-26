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

