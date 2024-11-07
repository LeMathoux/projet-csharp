using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Compagnie
    {
        private string nom; // D�claration d'un champ priv� pour stocker le nom de la compagnie
        private List<Com�dien> com�diens; // D�claration d'un champ priv� pour stocker la liste des com�diens

        // Constructeur de la classe Compagnie
        public Compagnie(string nom)
        {
            this.nom = nom; // Initialisation du champ nom avec la valeur pass�e en param�tre
            this.com�diens = new List<Com�dien>(); // Initialisation de la liste des com�diens
        }

        // M�thode pour obtenir le nom de la compagnie
        public string GetNom()
        {
            return nom; // Retourne la valeur du champ nom
        }

        // M�thode pour d�finir le nom de la compagnie
        public void SetNom(string nom)
        {
            this.nom = nom; // Met � jour la valeur du champ nom avec la valeur pass�e en param�tre
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
            Console.WriteLine("Nom de la compagnie: " + nom); // Affiche le nom de la compagnie
            Console.WriteLine("Liste des com�diens:"); // Affiche un titre pour la liste des com�diens
            foreach (var com�dien in com�diens)
            {
                com�dien.AfficherInfos(); // Affiche les informations de chaque com�dien
            }
        }
    }
}
