using System;

namespace ClassLibrary
{
    public class Comédien
    {
        private string nom; // Déclaration d'un champ privé pour stocker le nom du comédien
        private string rôle; // Déclaration d'un champ privé pour stocker le rôle du comédien

        // Constructeur de la classe Comédien
        public Comédien(string nom, string rôle)
        {
            this.nom = nom; // Initialisation du champ nom avec la valeur passée en paramètre
            this.rôle = rôle; // Initialisation du champ rôle avec la valeur passée en paramètre
        }

        // Méthode pour obtenir le nom du comédien
        public string GetNom()
        {
            return nom; // Retourne la valeur du champ nom
        }

        // Méthode pour définir le nom du comédien
        public void SetNom(string nom)
        {
            this.nom = nom; // Met à jour la valeur du champ nom avec la valeur passée en paramètre
        }

        // Méthode pour obtenir le rôle du comédien
        public string GetRôle()
        {
            return rôle; // Retourne la valeur du champ rôle
        }

        // Méthode pour définir le rôle du comédien
        public void SetRôle(string rôle)
        {
            this.rôle = rôle; // Met à jour la valeur du champ rôle avec la valeur passée en paramètre
        }

        public void AfficherInfos()
        {
            Console.WriteLine("Nom du comédien: " + nom); // Affiche le nom du comédien
            Console.WriteLine("Rôle du comédien: " + rôle); // Affiche le rôle du comédien
        }
    }
}
