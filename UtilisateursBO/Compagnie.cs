using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Compagnie
    {
        private string nom; // Déclaration d'un champ privé pour stocker le nom de la compagnie
        private List<Comédien> comédiens; // Déclaration d'un champ privé pour stocker la liste des comédiens

        // Constructeur de la classe Compagnie
        public Compagnie(string nom)
        {
            this.nom = nom; // Initialisation du champ nom avec la valeur passée en paramètre
            this.comédiens = new List<Comédien>(); // Initialisation de la liste des comédiens
        }

        // Méthode pour obtenir le nom de la compagnie
        public string GetNom()
        {
            return nom; // Retourne la valeur du champ nom
        }

        // Méthode pour définir le nom de la compagnie
        public void SetNom(string nom)
        {
            this.nom = nom; // Met à jour la valeur du champ nom avec la valeur passée en paramètre
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
            Console.WriteLine("Nom de la compagnie: " + nom); // Affiche le nom de la compagnie
            Console.WriteLine("Liste des comédiens:"); // Affiche un titre pour la liste des comédiens
            foreach (var comédien in comédiens)
            {
                comédien.AfficherInfos(); // Affiche les informations de chaque comédien
            }
        }
    }
}
