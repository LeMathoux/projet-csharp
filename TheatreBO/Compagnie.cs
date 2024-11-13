using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Compagnie
    {
        public int IdComp { get; set; } // Propriété pour stocker l'identifiant de la compagnie
        public string NomComp { get; set; } // Propriété pour stocker le nom de la compagnie
        public string LocComp { get; set; } // Propriété pour stocker la localisation de la compagnie
        public string NomDirecteur { get; set; } // Propriété pour stocker le nom du directeur de la compagnie
        private List<Comédien> comédiens; // Déclaration d'un champ privé pour stocker la liste des comédiens

        // Constructeur de la classe Compagnie
        public Compagnie(int idComp, string nomComp, string locComp, string nomDirecteur)
        {
            IdComp = idComp; // Initialisation de l'identifiant de la compagnie
            NomComp = nomComp; // Initialisation du nom de la compagnie
            LocComp = locComp; // Initialisation de la localisation de la compagnie
            NomDirecteur = nomDirecteur; // Initialisation du nom du directeur de la compagnie
            comédiens = new List<Comédien>(); // Initialisation de la liste des comédiens
        }

        // Méthode pour ajouter un comédien à la compagnie
        public void AjouterComédien(Comédien comédien)
        {
            comédiens.Add(comédien); // Ajoute le comédien à la liste des comédiens
        }

        // Méthode pour obtenir la liste des comédiens
        public List<Comédien> GetComédiens()
        {
            return comédiens; // Retourne la liste des comédiens
        }

        public void AfficherInfos()
        {
            Console.WriteLine("ID de la compagnie: " + IdComp); // Affiche l'identifiant de la compagnie
            Console.WriteLine("Nom de la compagnie: " + NomComp); // Affiche le nom de la compagnie
            Console.WriteLine("Localisation de la compagnie: " + LocComp); // Affiche la localisation de la compagnie
            Console.WriteLine("Nom du directeur: " + NomDirecteur); // Affiche le nom du directeur de la compagnie
            Console.WriteLine("Liste des comédiens:"); // Affiche un titre pour la liste des comédiens
            foreach (var comédien in comédiens)
            {
                comédien.AfficherInfos(); // Affiche les informations de chaque comédien
            }
        }
    }
}

