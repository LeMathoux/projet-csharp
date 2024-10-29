using System;

namespace ClassLibrary
{
    public class Com�dien
    {
        private string nom; // D�claration d'un champ priv� pour stocker le nom du com�dien
        private string r�le; // D�claration d'un champ priv� pour stocker le r�le du com�dien

        // Constructeur de la classe Com�dien
        public Com�dien(string nom, string r�le)
        {
            this.nom = nom; // Initialisation du champ nom avec la valeur pass�e en param�tre
            this.r�le = r�le; // Initialisation du champ r�le avec la valeur pass�e en param�tre
        }

        // M�thode pour obtenir le nom du com�dien
        public string GetNom()
        {
            return nom; // Retourne la valeur du champ nom
        }

        // M�thode pour d�finir le nom du com�dien
        public void SetNom(string nom)
        {
            this.nom = nom; // Met � jour la valeur du champ nom avec la valeur pass�e en param�tre
        }

        // M�thode pour obtenir le r�le du com�dien
        public string GetR�le()
        {
            return r�le; // Retourne la valeur du champ r�le
        }

        // M�thode pour d�finir le r�le du com�dien
        public void SetR�le(string r�le)
        {
            this.r�le = r�le; // Met � jour la valeur du champ r�le avec la valeur pass�e en param�tre
        }

        public void AfficherInfos()
        {
            Console.WriteLine("Nom du com�dien: " + nom); // Affiche le nom du com�dien
            Console.WriteLine("R�le du com�dien: " + r�le); // Affiche le r�le du com�dien
        }
    }
}
