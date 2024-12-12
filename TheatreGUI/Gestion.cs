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
using UtilisateursBLL;
using UtilisateursBO;

namespace projet_csharp
{
    public partial class Gestion : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider(); // Initialisation de ErrorProvider
        public Gestion()
        {
            InitializeComponent();

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

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

            //////////////////////////////////////////////////

            // GESTION GRAPHIQUE REPRESENTAIONS //

            //////////////////////////////////////////////////

            // Remplir la listeBox listPiecesFiltre avec les noms des pieces tout en conservant l'id
            listPiecesFiltre.DataSource = lesPieces;
            listPiecesFiltre.DisplayMember = "NomPiece";  // Affiche le nom de l'auteur
            listPiecesFiltre.ValueMember = "IdPiece";    // Utilise l'id de l'auteur comme valeur

            // Remplir la listeBox lstPieceRep avec les noms des pieces tout en conservant l'id
            lstPiecesRep.DataSource = lesPieces;
            lstPiecesRep.DisplayMember = "NomPiece";  // Affiche le nom de l'auteur
            lstPiecesRep.ValueMember = "IdPiece";    // Utilise l'id de l'auteur comme valeur

            // Remplir la listeBox AjouterTarifRep avec les libellés des tarifs tout en conservant l'id
            List<Tarif> LesTarifs = GestionTarifs.GetTarifs();
            lstTarifsRep.DataSource = LesTarifs;
            lstTarifsRep.DisplayMember = "LibelleTarif";  // Affiche les tarifs
            lstTarifsRep.ValueMember = "IdTarif";    // Utilise l'id comme valeur

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


            //Affichage de la liste des Reservations

            List<Reservation> lesReservations = GestionReservation.GetReservations();

            if (lesReservations != null && lesReservations.Count > 0)
            {
                DgvListReserv.DataSource = null;
                DgvListReserv.DataSource = lesReservations;

                DgvListReserv.DataBindingComplete += (s, e) =>
                {
                    DgvListReserv.Columns["idReservation"].HeaderText = "Reservation";
                    DgvListReserv.Columns["LieuRep"].HeaderText = "Lieu Representation";
                    DgvListReserv.Columns["DateRep"].HeaderText = "Date";
                    DgvListReserv.Columns["NombresPlaces"].HeaderText = "Nb Places";
                    DgvListReserv.Columns["InfoClient"].HeaderText = "Client";

                    DgvListReserv.Columns["idReservation"].Visible = false;
                    DgvListReserv.Columns["Representation"].Visible = false;
                    DgvListReserv.Columns["NomClient"].Visible = false;
                    DgvListReserv.Columns["Client"].Visible = false;

                    DgvListReserv.Columns["Representation"].DisplayIndex = 1;
                    DgvListReserv.Columns["NombresPlaces"].DisplayIndex = 2;
                    DgvListReserv.Columns["Client"].DisplayIndex = 3;

                };
            }

            // Remplir la listeBox cbPiece avec les noms des pieces tout en conservant l'id
            List<Pieces> lesPiecesRes = GestionPieces.GetPieces();
            cbPiece.DataSource = lesPiecesRes;
            cbPiece.DisplayMember = "NomPiece";  // Affiche le nom de l'auteur
            cbPiece.ValueMember = "IdPiece";    // Utilise l'id de l'auteur comme valeur

            int pieceBase = lesPiecesRes.FirstOrDefault()?.IdPiece ?? -1;

            List<Representation> lesRepr = GestionRepresentations.GetRepresentationByPiece(pieceBase);

            cbRepresentation.DataSource = lesRepr;
            cbRepresentation.DisplayMember = "DateRepresentation";  // Affiche la date pour affiché 
            cbRepresentation.ValueMember = "IdRepresentation";    // Utilise l'id de l'auteur comme valeur

            decimal TarifParPersonne = GestionPieces.GetTarif(pieceBase);
            txtTarifParPlace.Text = TarifParPersonne.ToString();

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
                // Validation avec ErrorProvider
                bool isNomValid = ValidateTextBox(ajouterPieceNom, "Veuillez entrer un nom pour la pièce.");
                bool isDescValid = ValidateTextBox(ajouterPieceDesc, "Veuillez entrer une description.");
                bool isDureeValid = ValidateNumericInput(ajouterPieceDuree, "La durée doit être exprimé en minutes.");
                bool isPrixValid = ValidateDecimalInput(ajouterPiecePrix, "Le prix doit être un nombre.");

                if (!isNomValid || !isDescValid || !isDureeValid || !isPrixValid)
                {
                    // Si un ou plusieurs champs ne sont pas valides, arrêter l'exécution
                    return;
                }

                // Vérification supplémentaire pour la durée
                if (int.Parse(ajouterPieceDuree.Text) > 1439)
                {
                    errorProvider.SetError(ajouterPieceDuree, "La durée de la pièce ne peut pas être supérieure ou égale à 24h.");
                    return;
                }
                else
                {
                    errorProvider.SetError(ajouterPieceDuree, ""); // Effacer l'erreur si valide
                }

                try
                {
                    // Récupération des données
                    string nomPiece = ajouterPieceNom.Text;
                    string descPiece = ajouterPieceDesc.Text;
                    string dureePiece = ajouterPieceDuree.Text;
                    decimal tarifBase = decimal.Parse(ajouterPiecePrix.Text);
                    int themePiece = int.Parse(ajouterPieceTheme.SelectedValue.ToString());
                    int publicPiece = int.Parse(ajouterPiecePublic.SelectedValue.ToString());
                    int idAuteur = int.Parse(ajouterPieceAuteur.SelectedValue.ToString());

                    // Création des objets liés
                    Auteur ObjetAuteur = new Auteur(idAuteur, null);
                    Theme ObjetTheme = new Theme(themePiece, null);
                    Public ObjetPublic = new Public(publicPiece, null);

                    Pieces nouvellePiece = new Pieces(0, nomPiece, descPiece, dureePiece, tarifBase, ObjetTheme, ObjetPublic, ObjetAuteur, null);

                    // Enregistrement de la pièce
                    bool PieceEnregistre;
                    if (!string.IsNullOrEmpty(lblIdPiece.Text))
                    {
                        int idPiece;
                        int.TryParse(lblIdPiece.Text, out idPiece);
                        PieceEnregistre = GestionPieces.modifierPiece(nouvellePiece, idPiece);
                        lblIdPiece.Text = "";
                    }
                    else
                    {
                        PieceEnregistre = GestionPieces.ajouterPiece(nouvellePiece);
                    }

                    if (PieceEnregistre)
                    {
                        MessageBox.Show("Pièce ajoutée avec succès !");

                        // Réinitialisation du formulaire
                        ajouterPieceNom.Text = "";
                        ajouterPieceDesc.Text = "";
                        ajouterPieceDuree.Text = "";
                        ajouterPiecePrix.Text = "";
                        label2.Text = "Ajouter une pièce";

                        // Navigation vers l'onglet liste des pièces
                        tabControl1.TabPages.Remove(tabAjoutPièces);
                        tabControl1.TabPages.Add(tabListPièces);
                        btnActualiserPieces_Click(sender, e); // Actualiser la liste
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

            // Ajouter une Représentation
            private void btnAjoutRep_Click(object sender, EventArgs e)
            {
                // Validation des champs avec ErrorProvider
                bool isLieuValid = ValidateTextBox(txtLieuRep, "Veuillez entrer un lieu.");
                bool isNbSpecValid = ValidateNumericInput(txtNbSpecRep, "Le nombre de spectateurs doit être un nombre.");

                // Vérification si la date est valide (optionnelle dans ce cas)
                bool isDateValid = dateTimeRep.Value != DateTime.MinValue;
                if (!isDateValid)
                {
                    errorProvider.SetError(dateTimeRep, "Veuillez sélectionner une date valide.");
                }
                else
                {
                    errorProvider.SetError(dateTimeRep, ""); // Effacer l'erreur si valide
                }

                if (!isLieuValid || !isNbSpecValid || !isDateValid)
                {
                    // Si un ou plusieurs champs ne sont pas valides, arrêter l'exécution
                    return;
                }

                try
                {
                    // Récupération des données
                    string lieuRep = txtLieuRep.Text;
                    int NbSpecMax = int.Parse(txtNbSpecRep.Text);
                    int Tarif = int.Parse(lstTarifsRep.SelectedValue.ToString());
                    int idPiece = int.Parse(lstPiecesRep.SelectedValue.ToString());

                    // Création des objets liés
                    Tarif ObjetTarif = new Tarif(Tarif, null, 0);
                    Pieces ObjetPiece = new Pieces(idPiece, null, null, null, 0, null, null, null, null);

                    DateTime ObjetDate = dateTimeRep.Value; // Utilisation directe de la date sélectionnée

                    Representation nouvelleRep = new Representation(0, ObjetPiece, ObjetDate, lieuRep, NbSpecMax, ObjetTarif);
                    bool RepresentationEnregistre;

                    // Enregistrement de la représentation
                    if (!string.IsNullOrEmpty(lblIdRep.Text))
                    {
                        // Modifier une représentation existante
                        int idRep;
                        int.TryParse(lblIdRep.Text, out idRep);
                        RepresentationEnregistre = GestionRepresentations.ModifierRepresentation(nouvelleRep, idRep);
                        lblIdRep.Text = "";
                    }
                    else
                    {
                        // Ajouter une nouvelle représentation
                        RepresentationEnregistre = GestionRepresentations.AjouterRepresentiation(nouvelleRep);
                    }

                    if (RepresentationEnregistre)
                    {
                        MessageBox.Show("Représentation ajoutée avec succès !");

                        // Réinitialisation du formulaire
                        txtLieuRep.Text = "";
                        txtNbSpecRep.Text = "";
                        dateTimeRep.Value = DateTime.Now; // Réinitialiser à la date actuelle
                        lblRepTitre.Text = "Ajouter une Représentation";

                        // Navigation vers l'onglet liste des représentations
                        tabControl1.TabPages.Remove(tabAjoutRep);
                        tabControl1.TabPages.Add(tabListRep);
                        btnActualiserRepr_Click(sender, e); // Actualiser la liste
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la Représentation dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout de la Représentation : " + ex.Message);
                }
            }

            // Filtre des représentations
            private void btnFiltreRepr_Click(object sender, EventArgs e)
            {
                dataGridView2.DataSource = null;

                int pieceFiltre = int.Parse(listPiecesFiltre.SelectedValue.ToString());
                DateTime DebutFiltre = dateDebutFiltre.Value;
                DateTime FinFiltre = dateFinFiltre.Value;

                
                List<Representation> lesRepresentations = GestionRepresentations.GetRepresentationsFiltre(pieceFiltre, DebutFiltre, FinFiltre);

                if (lesRepresentations != null && lesRepresentations.Count > 0)
                {
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

            // Méthode pour actualiser la liste des réservations
            private void btnActualiserReserv_Click(object sender, EventArgs e)
            {
                List<Reservation> lesReservations = GestionReservation.GetReservations();

                if (lesReservations != null && lesReservations.Count > 0)
                {
                    DgvListReserv.DataSource = null;
                    DgvListReserv.DataSource = lesReservations;

                    DgvListReserv.DataBindingComplete += (s, g) =>
                    {
                        DgvListReserv.Columns["idReservation"].HeaderText = "Reservation";
                        DgvListReserv.Columns["LieuRep"].HeaderText = "Lieu Representation";
                        DgvListReserv.Columns["DateRep"].HeaderText = "Date";
                        DgvListReserv.Columns["NombresPlaces"].HeaderText = "Nb Places";
                        DgvListReserv.Columns["InfoClient"].HeaderText = "Client";

                        DgvListReserv.Columns["idReservation"].Visible = false;
                        DgvListReserv.Columns["Representation"].Visible = false;
                        DgvListReserv.Columns["NomClient"].Visible = false;
                        DgvListReserv.Columns["Client"].Visible = false;


                    };
                }

            }

            //Ajouter une reservation
            private void btnValider_Click(object sender, EventArgs e)
            {
                bool isNomValid = ValidateTextBox(txtNom, "Veuillez entrer votre nom");
                bool isPrenomValid = ValidateTextBox(txtPrenom, "Veuillez entrer votre prenom");
                bool isEmailValid = ValidateTextBox(txtEmail, "Veuillez entrer votre email");
                bool isTelValid = ValidateNumericInput(txtTelephone, "Le numéro doit etre composé de chiffres");
                bool isNbPlacesValid = ValidateNumericInput(txtNbPlaces, "Le nombre de places doit etre composé de chiffres");
                bool isRepValid = ValidateTextBox(cbRepresentation, "Veuillez selectionner une représentation");


            if (!isNomValid || !isPrenomValid || !isEmailValid || !isTelValid || !isNbPlacesValid || !isRepValid)
                {
                    // Si un ou plusieurs champs ne sont pas valides, arrêter l'exécution
                    return;
                }

                try
                {
                    // Récupération des données

                    int idRepresentation = int.Parse(cbRepresentation.SelectedValue.ToString());
                    string nomClient = txtNom.Text;
                    string prenomClient = txtPrenom.Text;
                    string emailClient = txtEmail.Text;
                    string telClient = txtTelephone.Text;
                    int NbPlace = int.Parse(txtNbPlaces.Text);

                    // Création des objets liés
                    Representation representation = new Representation(idRepresentation, null, DateTime.Parse("00:00:00"), null, 0, null);
                    Client client = new Client(0, nomClient, prenomClient, emailClient, telClient);

                    Reservation reservation = new Reservation(0, representation, NbPlace, client);

                    // Enregistrement de la reservation
                    bool ReservationEnregistre;

                    if (!string.IsNullOrEmpty(lblIdReservation.Text))
                    {
                        int idReservation;
                        int.TryParse(lblIdPiece.Text, out idReservation);
                        ReservationEnregistre = GestionReservation.modifierReservation(nouvelleReservation, idReservation);
                        lblIdReservation.Text = "";
                    }
                    else
                    {
                        ReservationEnregistre = GestionReservation.AjouterReservation(reservation);
                    }

                    if (ReservationEnregistre)
                    {
                        MessageBox.Show("L'enregistrement a été effectué");

                        // Réinitialisation du formulaire
                        txtNom.Text = "";
                        txtPrenom.Text = "";
                        txtEmail.Text = "";
                        txtTelephone.Text = "";
                        txtNbPlaces.Text = "";
                        txtTarifParPlace.Text = "";
                        txtTarifReservations.Text = "";


                        // Navigation vers l'onglet liste des pièces
                        tabControl1.TabPages.Remove(tabAjoutReserv);
                        tabControl1.TabPages.Add(tabListReserv);
                        btnActualiserReserv_Click(sender, e); // Actualiser la liste
                    }
                    else
                    {
                        MessageBox.Show("Il n'y a plus assez de places pour cette reservation");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout de la reservation : " + ex.Message);
                }
            }
            // On affiche les représentations de la pièce selectionné
            private void cbPiece_SelectedIndexChanged(object sender, EventArgs e)
            {
            int pieceSelection = int.Parse(cbPiece.SelectedValue.ToString());

            List<Representation> lesRepr = GestionRepresentations.GetRepresentationByPiece(pieceSelection);

            cbRepresentation.DataSource = lesRepr;
            cbRepresentation.DisplayMember = "DateRepresentation";  // Affiche la date pour affiché 
            cbRepresentation.ValueMember = "IdRepresentation";    // Utilise l'id de l'auteur comme valeur

            }

            // On affiche les tarifs de la représentation seelctionné

            private void cbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
            {
                int pieceSelection = int.Parse(cbPiece.SelectedValue.ToString());
                decimal TarifParPersonne = GestionPieces.GetTarif(pieceSelection);
                txtTarifParPlace.Text = TarifParPersonne.ToString();
            }
            
            // Lorsque l'on met le nombre de place, on affiche le prix total
            private void txtNbPlaces_TextChanged(object sender, EventArgs e)
            {
                int NbPlacesCalcul = 0;
                decimal TarifParPersonne = 0;
                if (txtNbPlaces.Text != "")
                {
                    NbPlacesCalcul = int.Parse(txtNbPlaces.Text.ToString());
                }

                int pieceSelection = int.Parse(cbPiece.SelectedValue.ToString());
                TarifParPersonne = GestionPieces.GetTarif(pieceSelection);

            if (TarifParPersonne != 0 && NbPlacesCalcul != 0)
                {
                    decimal CalculPrix = NbPlacesCalcul * TarifParPersonne;
                    txtTarifReservations.Text = CalculPrix.ToString();
                }

        }

        

        // Méthode pour modifier une réservation
        private void btnModifierReserv_Click(object sender, EventArgs e)
            {
                
            }

            // Méthode pour supprimer une réservation
            private void btnSupprReserv_Click(object sender, EventArgs e)
            {
            List<Reservation> lesReservations = GestionReservation.GetReservations();

            //recupere le nombre de lignes selectionnées
            Int32 selectedRowsCount = DgvListReserv.SelectedCells.Count;
                if (selectedRowsCount == 1)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    //on recupere l'indice
                    sb.Append(DgvListReserv.SelectedCells[0].RowIndex.ToString());

                    //on demande confirmation de suppression
                    DialogResult Confirmation = MessageBox.Show("Vous êtes sur le point de supprimer cette reservation", "Confirmation Supression", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (Confirmation == DialogResult.OK)
                    {
                        /* L'utilisateur a choisi d'accepter. */
                        int id;
                        int.TryParse(sb.ToString(), out id);
                        int IdReservation = lesReservations[id].IdReservation;

                        //on fait la suppression. on envoie un message du resultat
                        if (GestionReservation.supprimerReservation(IdReservation) == true)
                        {
                            MessageBox.Show("La représentation a bien été supprimer.", "Suppression Reservation");
                            btnActualiserRepr_Click(sender, e); // Actualiser la liste 
                        }
                    }

                }
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

            //////////////////////////////////////////////////
            /// Gestion errorProvider
            //////////////////////////////////////////////////

            // Méthode pour valider le contenu d'un TextBox
            // Si le TextBox est vide ou contient uniquement des espaces blancs, un message d'erreur est affiché via l'ErrorProvider
            // et la méthode retourne false. Sinon, l'erreur est effacée et la méthode retourne true.
            private bool ValidateTextBox(Control control, string errorMessage)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    errorProvider.SetError(control, errorMessage);
                    return false;
                }
                else
                {
                    errorProvider.SetError(control, "");
                    return true;
                }
            }

            private bool ValidateNumericInput(TextBox textBox, string errorMessage)
            {
                if (!int.TryParse(textBox.Text, out _))
                {
                    errorProvider.SetError(textBox, errorMessage);
                    return false;
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                    return true;
                }
            }

            private bool ValidateDecimalInput(TextBox textBox, string errorMessage)
            {
                if (!decimal.TryParse(textBox.Text, out _))
                {
                    errorProvider.SetError(textBox, errorMessage);
                    return false;
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                    return true;
                }
            }

        
    }
}
