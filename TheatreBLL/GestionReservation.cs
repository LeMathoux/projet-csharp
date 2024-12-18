﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBLL;
using TheatreBO;
using TheatreDAL;
using UtilisateursBO;
using UtilisateursDAL;

namespace UtilisateursBLL
{
    public class GestionReservation
    {
        private static GestionReservation uneGestionReservation; // objet BLL

        // Accesseur en lecture
        public static GestionReservation GetGestionReservation()
        {
            if (uneGestionReservation == null)
            {
                uneGestionReservation = new GestionReservation();
            }
            return uneGestionReservation;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Reservation en faisant appel à la méthode GetReservations() de la DAL
        public static List<Reservation> GetReservations()
        {
            return ReservationDAO.GetInstance().GetReservations();
        }

        // 
        public static bool AjouterReservation(Reservation reservation, int repr)
        {
            return ReservationDAO.AjouterReservation(reservation, repr);
        }
        public static bool supprimerReservation(int id)
        {
            return ReservationDAO.DeleteReservation(id);
        }
        public static bool ModifierReservation(Reservation reservation, int id)
        {
            return ReservationDAO.ModifierReservation(reservation, id);
        }
    }
}
