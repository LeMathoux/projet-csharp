﻿using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Pieces
    {
        public int IdPiece { get; set; } // Propriété pour stocker l'identifiant de la pièce
        public string NomPiece { get; set; } // Propriété pour stocker le nom de la pièce
        public string DescPiece { get; set; } // Propriété pour stocker la description de la pièce
        public int DureePiece { get; set; } // Propriété pour stocker la durée de la pièce
        public decimal TarifBase { get; set; } // Propriété pour stocker le tarif de base de la pièce

        // Constructeur de la classe Pieces
        public Pieces(int idPiece, string nomPiece, string descPiece, int dureePiece, decimal tarifBase)
        {
            IdPiece = idPiece; // Initialisation de l'identifiant de la pièce
            NomPiece = nomPiece; // Initialisation du nom de la pièce
            DescPiece = descPiece; // Initialisation de la description de la pièce
            DureePiece = dureePiece; // Initialisation de la durée de la pièce
            TarifBase = tarifBase; // Initialisation du tarif de base de la pièce
        }

        // Méthode pour afficher les informations de la pièce
        public void AfficherInfos()
        {
            Console.WriteLine("ID de la pièce: " + IdPiece); // Affiche l'identifiant de la pièce
            Console.WriteLine("Nom de la pièce: " + NomPiece); // Affiche le nom de la pièce
            Console.WriteLine("Description de la pièce: " + DescPiece); // Affiche la description de la pièce
            Console.WriteLine("Durée de la pièce: " + DureePiece + " minutes"); // Affiche la durée de la pièce
            Console.WriteLine("Tarif de base: " + TarifBase + " €"); // Affiche le tarif de base de la pièce
        }
    }
}

