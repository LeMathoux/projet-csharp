﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBO;

namespace UtilisateursBO
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public Representation Representation { get; set; }
        public int NombresPlaces { get; set; }
        public Client Client { get; set; }

        public string NomPiece => Representation?.NomPiece;
        public string NomClient => Client?.NomCient;
        public string LieuRep => Representation?.LieuRepresentation;
        public DateTime DateRep => Representation.DateRepresentation;

        public string InfoClient => Client.NomCient + " " + Client.PrenomCient;

        public Reservation(int Id, Representation uneRepresentation, int unNombresPlaces, Client unClient)
        {
            IdReservation = Id;
            Representation = uneRepresentation;
            NombresPlaces = unNombresPlaces;
            Client = unClient;
        }
    }
}
