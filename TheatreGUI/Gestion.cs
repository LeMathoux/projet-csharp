﻿using System;
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
using UtilisateursBLL;

namespace projet_csharp
{
    public partial class Gestion : Form
    {
        public Gestion()
        {
            InitializeComponent();

            //////////////////////////////////////////////////

            // GESTION GRAPHIQUE PIECES //

            //////////////////////////////////////////////////

            //Affichage de la liste des pièces

            List<Pieces> lesPieces = GestionPieces.GetPieces();

            if (lesPieces != null && lesPieces.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lesPieces;

                // Définir les en-têtes de colonnes
                dataGridView1.Columns["NomPiece"].HeaderText = "Nom de la Pièce";
                dataGridView1.Columns["DescPiece"].HeaderText = "Description";
                dataGridView1.Columns["DureePiece"].HeaderText = "Durée";
                dataGridView1.Columns["TarifBase"].HeaderText = "Prix";
                dataGridView1.Columns["ThemeLibelle"].HeaderText = "Thème";
                dataGridView1.Columns["PublicLibelle"].HeaderText = "Public";
                dataGridView1.Columns["AuteurNom"].HeaderText = "Auteur";

                dataGridView1.Columns["TarifBase"].Width = 40;

                // Ordre des colonnes
                dataGridView1.Columns["NomPiece"].DisplayIndex = 0;
                dataGridView1.Columns["DescPiece"].DisplayIndex = 2;
                dataGridView1.Columns["DureePiece"].DisplayIndex = 3;
                dataGridView1.Columns["TarifBase"].DisplayIndex = 6;
                dataGridView1.Columns["ThemeLibelle"].DisplayIndex = 4;
                dataGridView1.Columns["PublicLibelle"].DisplayIndex = 5;
                dataGridView1.Columns["AuteurNom"].DisplayIndex = 1;
                dataGridView1.Columns["IdPiece"].Visible = false;
                dataGridView1.Columns["NomAuteur"].Visible = false;
                dataGridView1.Columns["PublicPiece"].Visible = false;
                dataGridView1.Columns["ThemePiece"].Visible = false;
                dataGridView1.Columns["AuteurId"].Visible = false;
                dataGridView1.Columns["PublicId"].Visible = false;
                dataGridView1.Columns["ThemeId"].Visible = false;
                dataGridView1.Columns["CompagniePiece"].Visible = false;
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

            // Remplir la listeBox AjouterPieceRep avec les noms des auteurs tout en conservant l'id
            lstPiecesRep.DataSource = lesPieces;
            lstPiecesRep.DisplayMember = "NomPiece";  // Affiche le nom de l'auteur
            lstPiecesRep.ValueMember = "IdPiece";    // Utilise l'id de l'auteur comme valeur

            // Remplir la listeBox AjouterTarifRep avec les libellés des tarifs tout en conservant l'id
            List<Tarif> LesTarifs = GestionTarifs.GetTarifs();
            lstTarifsRep.DataSource = LesTarifs;
            lstTarifsRep.DisplayMember = "LibelleTarif";  // Affiche les tarifs
            lstTarifsRep.ValueMember = "IdTarif";    // Utilise l'id comme valeur

            //////////////////////////////////////////////////

            // GESTION GRAPHIQUE REPRESENTAIONS //

            //////////////////////////////////////////////////

            //Affichage de la liste des pièces

            List<Representation> lesRepresentations = GestionRepresentations.GetRepresentations();

            if (lesRepresentations != null && lesRepresentations.Count > 0)
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lesRepresentations;

                // Définir les en-têtes de colonnes
                dataGridView2.DataBindingComplete += (s, e) =>
                {
                    dataGridView2.Columns["NomPiece"].HeaderText = "Pièce";
                    dataGridView2.Columns["DateRepresentation"].HeaderText = "Date";
                    dataGridView2.Columns["LieuRepresentation"].HeaderText = "Lieu";
                    dataGridView2.Columns["NbPlacesRepresentation"].HeaderText = "Nombre de places";
                    dataGridView2.Columns["IdRepresentation"].Visible = false;
                    dataGridView2.Columns["TarifRepresentation"].Visible = false;
                    dataGridView2.Columns["PieceRepresentation"].Visible = false;

                    dataGridView2.Columns["NomPiece"].DisplayIndex = 0;
                    dataGridView2.Columns["DateRepresentation"].DisplayIndex = 1;
                    dataGridView2.Columns["NbPlacesRepresentation"].DisplayIndex = 2;
                    dataGridView2.Columns["LieuRepresentation"].DisplayIndex = 3;
                };

            }
            //////////////////////////////////////////////////

            // GESTION GRAPHIQUE RESERVATIONS //

            //////////////////////////////////////////////////







            //////////////////////////////////////////////////

            // GESTION GRAPHIQUE ANALYSE //

            //////////////////////////////////////////////////













        }

        //////////////////////////////////////////////////

        // GESTION METHODES PIECES //

        //////////////////////////////////////////////////

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

            lblIdPiece.Text = "";
            ajouterPieceNom.Text = "";
            ajouterPieceDesc.Text = "";
            ajouterPieceDuree.Text = "";
            ajouterPiecePrix.Text = "";
            label2.Text = "Ajouter une piece";
        }

        // Méthode pour ajouter une pièce

        private void buttonAjouterPiece_Click(object sender, EventArgs e)
        {
            if (ajouterPieceNom.Text == "" || ajouterPieceDesc.Text == "" || ajouterPieceDuree.Text == "" || ajouterPiecePrix.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }
            else if (int.Parse(ajouterPieceDuree.Text.ToString()) > 1439)
            {
                MessageBox.Show("La durée de la pièce ne peut pas être supérieur ou égale à 24h");
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
                    int themePiece = int.Parse(ajouterPieceTheme.SelectedValue.ToString());
                    int publicPiece = int.Parse(ajouterPiecePublic.SelectedValue.ToString());
                    int idAuteur = int.Parse(ajouterPieceAuteur.SelectedValue.ToString());

                    Auteur ObjetAuteur = new Auteur(idAuteur, null);
                    Theme ObjetTheme = new Theme(themePiece, null);
                    Public ObjetPublic = new Public(publicPiece, null);

                    Pieces nouvellePiece = new Pieces(0, nomPiece, descPiece, dureePiece, tarifBase, ObjetTheme, ObjetPublic, ObjetAuteur, null);
                    bool PieceEnregistre;
                    // Enregistrer la nouvelle pièce dans la base de données
                    if (lblIdPiece.Text != "")
                    {
                        int idPiece;
                        int.TryParse(lblIdPiece.Text, out idPiece);
                        PieceEnregistre = GestionPieces.modifierPiece(nouvellePiece,idPiece);
                        lblIdPiece.Text = "";
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
                        btnActualiserPieces_Click(sender, e); // Actualiser la liste des pièces
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

        private void btnActualiserPieces_Click(object sender, EventArgs e)
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

                // Définir les en-têtes de colonnes
                dataGridView1.Columns["NomPiece"].HeaderText = "Nom de la Pièce";
                dataGridView1.Columns["DescPiece"].HeaderText = "Description";
                dataGridView1.Columns["DureePiece"].HeaderText = "Durée";
                dataGridView1.Columns["TarifBase"].HeaderText = "Prix";
                dataGridView1.Columns["ThemeLibelle"].HeaderText = "Thème";
                dataGridView1.Columns["PublicLibelle"].HeaderText = "Public";
                dataGridView1.Columns["AuteurNom"].HeaderText = "Auteur";

                dataGridView1.Columns["TarifBase"].Width = 40;

                // Ordre des colonnes
                dataGridView1.Columns["NomPiece"].DisplayIndex = 0;
                dataGridView1.Columns["DescPiece"].DisplayIndex = 2;
                dataGridView1.Columns["DureePiece"].DisplayIndex = 3;
                dataGridView1.Columns["TarifBase"].DisplayIndex = 6;
                dataGridView1.Columns["ThemeLibelle"].DisplayIndex = 4;
                dataGridView1.Columns["PublicLibelle"].DisplayIndex = 5;
                dataGridView1.Columns["AuteurNom"].DisplayIndex = 1;
                dataGridView1.Columns["IdPiece"].Visible = false;
                dataGridView1.Columns["NomAuteur"].Visible = false;
                dataGridView1.Columns["PublicPiece"].Visible = false;
                dataGridView1.Columns["ThemePiece"].Visible = false;
                dataGridView1.Columns["AuteurId"].Visible = false;
                dataGridView1.Columns["PublicId"].Visible = false;
                dataGridView1.Columns["ThemeId"].Visible = false;
                dataGridView1.Columns["CompagniePiece"].Visible = false;
            }
            else
            {
                // Affiche un message si aucune pièce n'est trouvée ou s'il y a une erreur lors de la récupération des données
                MessageBox.Show("Aucune pièce trouvée ou erreur lors de la récupération des données.");
            }
        }

        //Modifier une piece
        private void btnModifierPiece_Click(object sender, EventArgs e)
        {
            //on recupere la liste des pieces
            List<Pieces> lesPieces = GestionPieces.GetPieces();

            //nb de lignes selectionnées
            Int32 selectedRowsCount = dataGridView1.SelectedCells.Count;
            if (selectedRowsCount == 1)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //on recupere l'indice
                sb.Append(dataGridView1.SelectedCells[0].RowIndex.ToString());

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
                            int idAuteur = unePiece.AuteurId - 1;
                            int idPublic = unePiece.PublicId - 1; 
                            int idTheme = unePiece.ThemeId - 1; 

                            //Convertir la durée en minutes
                            TimeSpan timeSpan = TimeSpan.Parse(unePiece.DureePiece); // Conversion en TimeSpan
                            int totalMinutes = (int)timeSpan.TotalMinutes; // Obtenir le total en minutes

                            ajouterPiecePublic.SetSelected(idPublic, true);
                            ajouterPieceAuteur.SetSelected(idAuteur, true);
                            ajouterPieceTheme.SetSelected(idTheme, true);
                            ajouterPieceNom.Text = unePiece.NomPiece;
                            ajouterPieceDesc.Text = unePiece.DescPiece;
                            ajouterPiecePrix.Text = unePiece.TarifBase.ToString();
                            ajouterPieceDuree.Text = totalMinutes.ToString();

                            label2.Text = "Modifier une piece";
                            lblIdPiece.Text = idPiece.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une pièce", "Erreur");
            }
        }
        // Methode pour supprimer une piece
        private void btnSuppressionPiece_Click(object sender, EventArgs e)
        {
            //recuperation de la liste des pieces
            List<Pieces> lesPieces = GestionPieces.GetPieces();

            //recupere le nombre de lignes selectionnées
            Int32 selectedRowsCount = dataGridView1.SelectedCells.Count;
            if (selectedRowsCount == 1)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //on recupere l'indice
                sb.Append(dataGridView1.SelectedCells[0].RowIndex.ToString());

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
                        btnActualiserPieces_Click(sender, e); // Actualiser la liste des pièces
                    }
                    else
                    {
                        MessageBox.Show("Une représentation dépend de cette pièce, Suppression Impossible.","Suppression Piece");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une pièce", "Erreur");
            }
        }

        //////////////////////////////////////////////////

        // GESTION METHODES REPRESENTATION //

        //////////////////////////////////////////////////
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

    //Ajouter une représentation

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

        //Actualiser une représentation
        private void btnActualiserRepr_Click(object sender, EventArgs e)
        {
            List<Representation> lesRepresentations = GestionRepresentations.GetRepresentations();

            if (lesRepresentations != null && lesRepresentations.Count > 0)
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lesRepresentations;

                // Définir les en-têtes de colonnes
                dataGridView2.DataBindingComplete += (s, f) =>
                {
                    dataGridView2.Columns["NomPiece"].HeaderText = "Pièce";
                    dataGridView2.Columns["DateRepresentation"].HeaderText = "Date";
                    dataGridView2.Columns["LieuRepresentation"].HeaderText = "Lieu";
                    dataGridView2.Columns["NbPlacesRepresentation"].HeaderText = "Nombre de places";
                    dataGridView2.Columns["IdRepresentation"].Visible = false;
                    dataGridView2.Columns["TarifRepresentation"].Visible = false;
                    dataGridView2.Columns["PieceRepresentation"].Visible = false;

                    dataGridView2.Columns["NomPiece"].DisplayIndex = 0;
                    dataGridView2.Columns["DateRepresentation"].DisplayIndex = 1;
                    dataGridView2.Columns["NbPlacesRepresentation"].DisplayIndex = 2;
                    dataGridView2.Columns["LieuRepresentation"].DisplayIndex = 3;
                };

            }
        }
        //Modifier une représentation
        private void btnModifierRepr_Click(object sender, EventArgs e)
        {
            //on recupere la liste des représentations
            List<Representation> lesRepresentations = GestionRepresentations.GetRepresentations();

            //nb de lignes selectionnées
            Int32 selectedRowsCount = dataGridView2.SelectedCells.Count;
            if (selectedRowsCount == 1)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //on recupere l'indice
                sb.Append(dataGridView2.SelectedCells[0].RowIndex.ToString());

                DialogResult Confirmation = MessageBox.Show("Vous êtes sur le point de modifier cette représentation", "Confirmation modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (Confirmation == DialogResult.OK)
                {
                    /* L'utilisateur a choisi d'accepter. */
                    //on recupere l'id grace a l'indice obtenue
                    int id;
                    int.TryParse(sb.ToString(), out id);
                    int idRepresentation = lesRepresentations[id].IdRepresentation;

                    //affichage de l'onglet ajouter
                    tabControl1.TabPages.Remove(tabListRep);
                    tabControl1.TabPages.Remove(tabAjoutRep);
                    tabControl1.TabPages.Add(tabAjoutRep);
                    tabControl1.TabPages.Remove(tabListPièces);
                    tabControl1.TabPages.Remove(tabAjoutPièces);
                    tabControl1.TabPages.Remove(tabListReserv);
                    tabControl1.TabPages.Remove(tabAjoutReserv);
                    tabControl1.TabPages.Remove(tabAnalyse);

                    //parcours la liste pour trouver la représentation à modifier
                    foreach (Representation uneRepresentation in lesRepresentations)
                    {
                        if (uneRepresentation.IdRepresentation == idRepresentation)
                        {
                            //on affiche toutes les infos dans le formulaire
                            lstPiecesRep.SelectedValue = uneRepresentation.PieceRepresentation.IdPiece;
                            lstTarifsRep.SelectedValue = uneRepresentation.TarifRepresentation.IdTarif;
                            txtLieuRep.Text = uneRepresentation.LieuRepresentation;
                            txtNbSpecRep.Text = uneRepresentation.NbPlacesRepresentation.ToString();
                            dateTimeRep.Value = uneRepresentation.DateRepresentation;

                            lblRepTitre.Text = "Modifier une représentation";
                            lblIdRep.Text = idRepresentation.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une représentation", "Erreur");
            }
        }



        //Supprimer une représentation
        private void btnSupprimerRep_Click(object sender, EventArgs e)
        {

            //recuperation de la liste des pieces
            List<Representation> lesRepresentations = GestionRepresentations.GetRepresentations();

            //recupere le nombre de lignes selectionnées
            Int32 selectedRowsCount = dataGridView2.SelectedCells.Count;
            if (selectedRowsCount == 1)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //on recupere l'indice
                sb.Append(dataGridView2.SelectedCells[0].RowIndex.ToString());

                //on demande confirmation de suppression
                DialogResult Confirmation = MessageBox.Show("Vous êtes sur le point de supprimer cette représentation", "Confirmation Supression", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (Confirmation == DialogResult.OK)
                {
                    /* L'utilisateur a choisi d'accepter. */
                    int id;
                    int.TryParse(sb.ToString(), out id);
                    int IdRepresentation = lesRepresentations[id].IdRepresentation;

                    //on fait la suppression. on envoie un message du resultat
                    if (GestionRepresentations.supprimerRepresentation(IdRepresentation) == true)
                    {
                        MessageBox.Show("La représentation a bien été supprimmer.", "Suppression Représentation");
                        btnActualiserRepr_Click(sender, e); // Actualiser la liste des pièces
                    }
                    else
                    {
                        MessageBox.Show("Une réservation dépend de cette représentation, Suppression Impossible.", "Suppression Représentation");
                    }
                }

            }
        }

        private void btnAjoutRep_Click(object sender, EventArgs e)
        {
            if (txtLieuRep.Text == "" || txtNbSpecRep.Text == "" || dateTimeRep.Value.ToString("yyyyMMddHHmmssffff") == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }
            else
            {
                try
                {
                    string lieuRep = txtLieuRep.Text;
                    int NbSpecMax = int.Parse(txtNbSpecRep.Text);
                    int Tarif = int.Parse(lstTarifsRep.SelectedValue.ToString());
                    int idPiece = int.Parse(lstPiecesRep.SelectedValue.ToString());

                    Tarif ObjetTarif = new Tarif(Tarif, null,0);
                    Pieces ObjetPiece = new Pieces(idPiece, null, null, null ,0 , null, null, null, null);


                    MessageBox.Show(Tarif.ToString());
                    long timestamp = DateTime.Parse(dateTimeRep.Value.ToString()).Ticks;

                    DateTime ObjetDate = new DateTime(timestamp);

                    Representation nouvelleRep = new Representation(0, ObjetPiece, ObjetDate, lieuRep, NbSpecMax, ObjetTarif);
                    bool RepresentationEnregistre;
                    // Enregistrer la nouvelle pièce dans la base de données
                    if (lblIdRep.Text != " ")
                    {
                        //modifier une representation
                        int idRep;
                        int.TryParse(lblIdRep.Text, out idRep);
                        RepresentationEnregistre = GestionRepresentations.ModifierRepresentation(nouvelleRep, idPiece);
                        lblIdRep.Text = "";
                    }
                    else
                    {
                        //ajouter une representation
                        RepresentationEnregistre = GestionRepresentations.AjouterRepresentiation(nouvelleRep);
                    }
                    if (RepresentationEnregistre)
                    {
                        MessageBox.Show("Representation ajoutée avec succès !");

                        // Vider le formulaire
                        txtLieuRep.Text = "";
                        txtNbSpecRep.Text = "";
                        dateTimeRep.Text = "";
                        lblRepTitre.Text = "Ajouter une Representation";

                        tabControl1.TabPages.Remove(tabAjoutRep);
                        tabControl1.TabPages.Add(tabListRep);
                        btnActualiserRepr_Click(sender, e); // Actualiser la liste des pièces
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la Representation dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout de la Representation : " + ex.Message);
                }
            }

        }


        //////////////////////////////////////////////////

        // GESTION METHODES RESERVATION //

        //////////////////////////////////////////////////

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

        //////////////////////////////////////////////////

        // GESTION METHODES ANALYSE //

        //////////////////////////////////////////////////

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



        //////////////////////////////////////////////////
        //////////////////////////////////////////////////
        private void Gestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void representationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
