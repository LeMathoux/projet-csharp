using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Compagnie
    {
        public int IdComp { get; set; } // Propri�t� pour stocker l'identifiant de la compagnie
        public string NomComp { get; set; } // Propri�t� pour stocker le nom de la compagnie
        public string LocComp { get; set; } // Propri�t� pour stocker la localisation de la compagnie
        public string NomDirecteur { get; set; } // Propri�t� pour stocker le nom du directeur de la compagnie
        private List<Com�dien> com�diens; // D�claration d'un champ priv� pour stocker la liste des com�diens

        // Constructeur de la classe Compagnie
        public Compagnie(int idComp, string nomComp, string locComp, string nomDirecteur)
        {
            IdComp = idComp; // Initialisation de l'identifiant de la compagnie
            NomComp = nomComp; // Initialisation du nom de la compagnie
            LocComp = locComp; // Initialisation de la localisation de la compagnie
            NomDirecteur = nomDirecteur; // Initialisation du nom du directeur de la compagnie
            com�diens = new List<Com�dien>(); // Initialisation de la liste des com�diens
        }

        // M�thode pour ajouter un com�dien � la compagnie
        public void AjouterCom�dien(Com�dien com�dien)
        {
            com�diens.Add(com�dien); // Ajoute le com�dien � la liste des com�diens
        }

        // M�thode pour obtenir la liste des com�diens
        public List<Com�dien> GetCom�diens()
        {
            return com�diens; // Retourne la liste des com�diens
        }

        public void AfficherInfos()
        {
            Console.WriteLine("ID de la compagnie: " + IdComp); // Affiche l'identifiant de la compagnie
            Console.WriteLine("Nom de la compagnie: " + NomComp); // Affiche le nom de la compagnie
            Console.WriteLine("Localisation de la compagnie: " + LocComp); // Affiche la localisation de la compagnie
            Console.WriteLine("Nom du directeur: " + NomDirecteur); // Affiche le nom du directeur de la compagnie
            Console.WriteLine("Liste des com�diens:"); // Affiche un titre pour la liste des com�diens
            foreach (var com�dien in com�diens)
            {
                com�dien.AfficherInfos(); // Affiche les informations de chaque com�dien
            }
        }
    }
}

