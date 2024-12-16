using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Analyse
    {
        public Pieces pieces { get; set; }

        public int nbRepresentations { get; set; }

        public int nbSpectateurTotal { get; set; }

        public int nbSpectateurMoyen { get; set; }

        public decimal ChiffreAffaire { get; set; }

        public decimal ChiffreAffaireMoyen { get; set; }

        public string Pièce => pieces?.NomPiece;

        public Analyse(Pieces pieces, int nbRepresentations, int nbSpectateurTotal, int nbSpectateurMoyen, decimal ChiffreAffaire, decimal ChiffreAffaireMoyen)
        {
            this.pieces = pieces;
            this.nbRepresentations = nbRepresentations;
            this.nbSpectateurTotal = nbSpectateurTotal;
            this.nbSpectateurMoyen = nbSpectateurMoyen;
            this.ChiffreAffaire = ChiffreAffaire;
            this.ChiffreAffaireMoyen = ChiffreAffaireMoyen;
        }


    }

}
