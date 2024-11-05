using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using UtilisateursBO; // Référence la couche BO
using UtilisateursBLL; // Référence la couche BLL

namespace projet_csharp
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
            // Récupération de chaîne de connexion à la BD à l'ouverture du formulaire
            GestionUtilisateurs.SetchaineConnexion(ConfigurationManager.ConnectionStrings["Utilisateur"]);

        }

        private void Connexionbtn_Click(object sender, EventArgs e)
        {
            List<Utilisateur> listUser = GestionUtilisateurs.GetUtilisateurs();

            foreach(Utilisateur unUtilisateur in listUser)
            {
                if(unUtilisateur.getIdentifiant() == txtIdentifiant.Text)
                {
                    if(unUtilisateur.getMotDePasse() == txtMdp.Text)
                    {
                        Gestion gestionForm = new Gestion();
                        this.Hide();
                        gestionForm.Show();
                    }
                }
            }
        }
    }
}
