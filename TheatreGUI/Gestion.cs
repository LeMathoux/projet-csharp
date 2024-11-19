using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheatreBLL;
using TheatreBO;

namespace projet_csharp
{
    public partial class Gestion : Form
    {
        public Gestion()
        {
            InitializeComponent();

            List<Pieces> lesPieces = GestionPieces.GetPieces();

            if (lesPieces != null && lesPieces.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lesPieces;
            }
            // affiche aucun onglet liste tabpages vide
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Add(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);

            // Remplir la listeBox AjouterPieceAuteur avec les noms des auteurs tout en conservant l'id
            List<Auteur> lesAuteurs = GestionAuteurs.GetAuteurs();
            ajouterPieceAuteur.DataSource = lesAuteurs;
            ajouterPieceAuteur.DisplayMember = "NomAuteur";  // Affiche le nom de l'auteur
            ajouterPieceAuteur.ValueMember = "IdAuteur";    // Utilise l'id de l'auteur comme valeur

            // Remplir la listeBox AjouterPiecePublic avec les type de public tout en conservant l'id
            List<Public> lesPublics = GestionPublics.GetPublics();
            ajouterPiecePublic.DataSource = lesPublics;
            ajouterPiecePublic.DisplayMember = "LibPublic";  // Affiche le type
            ajouterPiecePublic.ValueMember = "IdPublic";    // Utilise l'id comme valeur

            // Remplir la listeBox AjouterPieceTheme avec les noms des themes tout en conservant l'id
            List<Theme> lesThemes = GestionThemes.GetThemes();
            ajouterPieceTheme.DataSource = lesThemes;
            ajouterPieceTheme.DisplayMember = "LibTheme";  // Affiche les themes
            ajouterPieceTheme.ValueMember = "IdTheme";    // Utilise l'id comme valeur
        }

        private void listeDesPiècesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // retire les onglets pour eviter la duplication d'onglet dans l'affichage
            // affichage de l'onglet desire avec Add
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Add(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);
        }

        private void ajouterUnePièceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Add(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);

        }

        // Méthode pour ajouter une pièce

        private void buttonAjouterPiece_Click(object sender, EventArgs e)
        {
            if (ajouterPieceNom.Text == "" || ajouterPieceDesc.Text == "" || ajouterPieceDuree.Text == "" || ajouterPiecePrix.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }
            else
            {
                try
                {
                    string nomPiece = ajouterPieceNom.Text;
                    string descPiece = ajouterPieceDesc.Text;
                    string dureePiece = ajouterPieceDuree.Text;
                    decimal tarifBase = decimal.Parse(ajouterPiecePrix.Text);
                    string themePiece = ajouterPieceTheme.SelectedValue.ToString();
                    string publicPiece = ajouterPiecePublic.SelectedValue.ToString();
                    string nomAuteur = ajouterPieceAuteur.SelectedValue.ToString();

                    Pieces nouvellePiece = new Pieces(0, nomPiece, descPiece, dureePiece, tarifBase, themePiece, publicPiece, nomAuteur);
                    bool PieceEnregistre;
                    // Enregistrer la nouvelle pièce dans la base de données
                    if (lblIdPiece.Text != "")
                    {
                        int idPiece;
                        int.TryParse(lblIdPiece.Text, out idPiece);
                        PieceEnregistre = GestionPieces.modifierPiece(nouvellePiece,idPiece);
                    }
                    else
                    {
                        PieceEnregistre = GestionPieces.ajouterPiece(nouvellePiece);
                    }
                    if (PieceEnregistre)
                    {
                        MessageBox.Show("Pièce ajoutée avec succès !");

                        // Vider le formulaire
                        ajouterPieceNom.Text = "";
                        ajouterPieceDesc.Text = "";
                        ajouterPieceDuree.Text = "";
                        ajouterPiecePrix.Text = "";
                        label2.Text = "Ajouter une piece";

                        tabControl1.TabPages.Remove(tabAjoutPièces);
                        tabControl1.TabPages.Add(tabListPièces);
                        btnActualiser_Click(sender, e); // Actualiser la liste des pièces
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la pièce dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout de la pièce : " + ex.Message);
                }
            }

        }

        private void listeDesReprésentationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Add(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);
        }

        private void ajouterUneReprésentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Add(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);
        }

        private void listeDesRéservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Add(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);
        }

        private void ajouterUneRéservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Add(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);
        }

        private void analyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabListPièces);
            tabControl1.TabPages.Remove(tabAjoutPièces);
            tabControl1.TabPages.Remove(tabListRep);
            tabControl1.TabPages.Remove(tabAjoutRep);
            tabControl1.TabPages.Remove(tabListReserv);
            tabControl1.TabPages.Remove(tabAjoutReserv);
            tabControl1.TabPages.Remove(tabAnalyse);
            tabControl1.TabPages.Add(tabAnalyse);
        }

        private void Gestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tabListPièces_Click(object sender, EventArgs e)
        {

        }

        private void tableauListePieces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            // Récupère la liste des pièces en appelant la méthode GetPieces de la classe GestionPieces
            List<Pieces> lesPieces = GestionPieces.GetPieces();

            // Vérifie si la liste des pièces n'est pas nulle et contient des éléments
            if (lesPieces != null && lesPieces.Count > 0)
            {
                // Réinitialise la source de données du DataGridView pour éviter les problèmes de rafraîchissement
                dataGridView1.DataSource = null;

                // Assigne la liste des pièces comme source de données du DataGridView
                dataGridView1.DataSource = lesPieces;
            }
            else
            {
                // Affiche un message si aucune pièce n'est trouvée ou s'il y a une erreur lors de la récupération des données
                MessageBox.Show("Aucune pièce trouvée ou erreur lors de la récupération des données.");
            }
        }

        //modifier une piece
        private void btnModifierPiece_Click(object sender, EventArgs e)
        {
            //on recupere la liste des pieces
            List<Pieces> lesPieces = GestionPieces.GetPieces();

            //nb de lignes selectionnées
            Int32 selectedRowsCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowsCount == 1)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //on recupere l'indice
                sb.Append(dataGridView1.SelectedRows[0].Index.ToString());

                DialogResult Confirmation = MessageBox.Show("Vous êtes sur le point de modifier cette pièce", "Confirmation modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (Confirmation == DialogResult.OK)
                {
                    /* L'utilisateur a choisi d'accepter. */
                    //on recupere l'id grace a l'indice obtenue
                    int id;
                    int.TryParse(sb.ToString(), out id);
                    int idPiece = lesPieces[id].IdPiece;

                    //affichage de l'onglet ajouter
                    tabControl1.TabPages.Remove(tabListPièces);
                    tabControl1.TabPages.Remove(tabAjoutPièces);
                    tabControl1.TabPages.Add(tabAjoutPièces);
                    tabControl1.TabPages.Remove(tabListRep);
                    tabControl1.TabPages.Remove(tabAjoutRep);
                    tabControl1.TabPages.Remove(tabListReserv);
                    tabControl1.TabPages.Remove(tabAjoutReserv);
                    tabControl1.TabPages.Remove(tabAnalyse);

                    //parcours la liste pour trouver la piece a modifier
                    foreach(Pieces unePiece in lesPieces)
                    {
                        if(unePiece.IdPiece == idPiece)
                        {
                            //on affiche toutes les infos dans le formulaire
                            int idPublic;
                            int.TryParse(unePiece.PublicPiece, out idPublic);

                            int idTheme;
                            int.TryParse(unePiece.ThemePiece, out idTheme);

                            int idAuteur;
                            int.TryParse(unePiece.NomAuteur, out idAuteur);

                            ajouterPiecePublic.SetSelected(idPublic, true);
                            ajouterPieceAuteur.SetSelected(idAuteur, true);
                            ajouterPieceTheme.SetSelected(idTheme, true);
                            ajouterPieceNom.Text = unePiece.NomPiece;
                            ajouterPieceDesc.Text = unePiece.DescPiece;
                            ajouterPiecePrix.Text = unePiece.TarifBase.ToString();
                            ajouterPieceDuree.Text = unePiece.DureePiece.ToString();

                            label2.Text = "Modifier une piece";
                            lblIdPiece.Text = idPiece.ToString();
                        }
                    }
                }
            }
        }

        private void btnSuppressionPiece_Click(object sender, EventArgs e)
        {
            //recuperation de la liste des pieces
            List<Pieces> lesPieces = GestionPieces.GetPieces();

            //recupere le nombre de lignes selectionnées
            Int32 selectedRowsCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //parcours s'il y en a qu'une
            if (selectedRowsCount == 1)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //recupere l'indice de la piece demande
                sb.Append(dataGridView1.SelectedRows[0].Index.ToString());

                //on demande confirmation de suppression
                DialogResult Confirmation = MessageBox.Show("Vous êtes sur le point de supprimer cette pièce", "Confirmation Supression", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (Confirmation == DialogResult.OK)
                {
                    /* L'utilisateur a choisi d'accepter. */
                    int id;
                    int.TryParse(sb.ToString(), out id);
                    int idPiece = lesPieces[id].IdPiece;

                    //on fait la suppression. on envoie un message du resultat
                    if (GestionPieces.supprimerPiece(idPiece) == true)
                    {
                        MessageBox.Show("La piece a bien été supprimmer.","Suppression Piece");
                        btnActualiser_Click(sender, e); // Actualiser la liste des pièces
                    }
                    else
                    {
                        MessageBox.Show("La piece a rencontré une erreur lors de la suppression.","Suppression Piece");
                    }
                }
            }
        }


        
    }
}
