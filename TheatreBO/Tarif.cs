using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Tarif
    {
        public int IdTarif { get; set; }
        public string LibelleTarif { get; set; }
        public float VariationTarif { get; set; }

        public Tarif(int id, string libelle, float variation)
        {
            IdTarif = id;
            LibelleTarif = libelle;
            VariationTarif = variation;
        }
    }
}
