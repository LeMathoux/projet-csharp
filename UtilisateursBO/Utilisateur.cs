using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilisateursBO
{
    public class Utilisateur
    {
        private int id;
        private string identifiant;
        private string motDePasse;

        public Utilisateur(int id, string identifiant, string motDePasse)
        {
            this.id = id;
            this.identifiant = identifiant;
            this.motDePasse = motDePasse;
        }

        public int getId() { return id; }
        public string getIdentifiant() { return identifiant; }
        public string getMotDePasse() { return motDePasse; }

        public void setId(int id)
        {
            this.id = id;
        }
        public void setIdentifiant(string identifiant)
        {
            this.identifiant = identifiant;
        }

        public void setMotDePasse(string motDePasse)
        {
            this.motDePasse = motDePasse;
        }

    }
}
