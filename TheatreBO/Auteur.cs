using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Auteur
    {
        public int IdAuteur { get; set; }
        public string NomAuteur { get; set; }

        public Auteur(int idAuteur, string nomAuteur)
        {
            IdAuteur = idAuteur;
            NomAuteur = nomAuteur;
        }
        public int GetId()
        {
            return IdAuteur;
        }
    }
}
