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
using TheatreBO; // Référence la couche BO
using TheatreBLL; // Référence la couche BLL

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

            if(txtIdentifiant.Text.Trim() == "")
            {
                lblIdentifiantError.Visible = true;
                txtIdentifiant.Text = "";
            }
            else
            {
                lblIdentifiantError.Visible = false;
            }

            if(txtMdp.Text.Trim() == "")
            {
                lblMdpError.Visible = true;
                txtMdp.Text = "";
            }
            else
            {
                lblMdpError.Visible = false;
            }

            foreach(Utilisateur unUtilisateur in listUser)
            {
                if(unUtilisateur.getIdentifiant() == txtIdentifiant.Text.Trim())
                {
                    if(unUtilisateur.getMotDePasse() == txtMdp.Text.Trim())
                    {
                        Gestion gestionForm = new Gestion();
                        this.Hide();
                        gestionForm.Show();
                    }
                }
            }
            lblError.Text = "Identifiant ou mot de passe incorrect";
        }

    }
}
