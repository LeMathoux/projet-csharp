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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnModifierPiece_Click(object sender, EventArgs e)
        {
            Int32 selectedRowsCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowsCount > 0 && selectedRowsCount<2)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowsCount; i++)
                {
                    sb.Append("index de la ligne dans le data : ");
                    sb.Append(dataGridView1.SelectedRows[i].Index
                        .ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append(" nb de ligne : " + selectedRowsCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Columns");
            }
        }

        private void btnSuppressionPiece_Click(object sender, EventArgs e)
        {

        }
    }
}
