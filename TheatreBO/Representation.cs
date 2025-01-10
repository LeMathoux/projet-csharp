using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Representation
    {
        public int IdRepresentation { get; set; }
        public Pieces PieceRepresentation { get; set; }
        public DateTime DateRepresentation { get; set; }
        public Lieu LieuRepresentation { get; set; }
        public int NbPlacesRepresentation { get; set; }
        public Tarif TarifRepresentation { get; set; }

        public string NomPiece => PieceRepresentation?.NomPiece;
        public string NomLieu => LieuRepresentation?.LibelleLieu;

        public Representation(int Id, Pieces unePiece, DateTime date, Lieu Lieu, int NbPlaces, Tarif unTarif )
        {
            IdRepresentation = Id;
            PieceRepresentation = unePiece;
            DateRepresentation = date;
            LieuRepresentation = Lieu;
            NbPlacesRepresentation = NbPlaces;
            TarifRepresentation = unTarif;
        }

    }
}
