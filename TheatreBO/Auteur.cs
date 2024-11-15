using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Auteur
    {
        private int idAuteur { get; set; }
        private string nomAuteur { get; set; }

        public Auteur(int idAuteur, string nomAuteur)
        {
            this.idAuteur = idAuteur;
            this.nomAuteur = nomAuteur;
        }
        
    }
}
