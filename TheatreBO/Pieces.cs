using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Pieces
    {
        public int IdPiece { get; set; } // Propriété pour stocker le nom de la pièce
        public string NomPiece { get; set; } // Propriété pour stocker le nom de la pièce
        public string DescPiece { get; set; } // Propriété pour stocker la description de la pièce
        public string DureePiece { get; set; } // Propriété pour stocker la durée de la pièce
        public Theme ThemePiece { get; set; } // Propriété pour stocker la theme de la pièce
        public Public PublicPiece { get; set; } // Propriété pour stocker la public de la pièce
        public Auteur NomAuteur { get; set; } // Propriété pour stocker la public de la pièce
        public decimal TarifBase { get; set; } // Propriété pour stocker le tarif de base de la pièce
        public Compagnie compagnie { get; set; } // Propriété pour stocker la compagnie jouant la pièce

        // Propriétés calculées pour les libellés et les affiché dans le DataGridView
        public string ThemeLibelle => ThemePiece?.LibTheme;
        public int ThemeId => ThemePiece?.IdTheme ?? 0;
        public string PublicLibelle => PublicPiece?.LibPublic;
        public int PublicId => PublicPiece?.IdPublic ?? 0;
        public string AuteurNom => NomAuteur?.NomAuteur;
        public int AuteurId => NomAuteur?.IdAuteur ?? 0;

        // Constructeur de la classe Pieces
        public Pieces(int idPiece, string nomPiece, string descPiece,string dureePiece, decimal tarifBase, Theme themePiece, Public publicPiece, Auteur nomAuteur, Compagnie comp)
        {
            IdPiece = idPiece;
            NomPiece = nomPiece; // Initialisation du nom de la pièce
            DescPiece = descPiece; // Initialisation de la description de la pièce
            DureePiece = dureePiece; // Initialisation de la durée de la pièce
            TarifBase = tarifBase; // Initialisation du tarif de base de la pièce
            PublicPiece = publicPiece;
            ThemePiece = themePiece;
            NomAuteur = nomAuteur;
            compagnie = comp;
        }

        // Méthode pour afficher les informations de la pièce
        public void AfficherInfos()
        {
            Console.WriteLine("Nom de la pièce: " + NomPiece); // Affiche le nom de la pièce
            Console.WriteLine("Description de la pièce: " + DescPiece); // Affiche la description de la pièce
            Console.WriteLine("Durée de la pièce: " + DureePiece + " minutes"); // Affiche la durée de la pièce
            Console.WriteLine("Tarif de base: " + TarifBase + " €"); // Affiche le tarif de base de la pièce
        }
    }
}

