﻿namespace projet_csharp
{
    partial class Gestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.piècesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesPiècesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnePièceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.representationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesReprésentationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneReprésentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesRéservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneRéservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabListPièces = new System.Windows.Forms.TabPage();
            this.btnSuppressionPiece = new System.Windows.Forms.Button();
            this.btnModifierPiece = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabAjoutPièces = new System.Windows.Forms.TabPage();
            this.ajouterPiecePrix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ajouterPieceTheme = new System.Windows.Forms.ListBox();
            this.ajouterPiecePublic = new System.Windows.Forms.ListBox();
            this.ajouterPieceAuteur = new System.Windows.Forms.ListBox();
            this.ajouterPieceDesc = new System.Windows.Forms.RichTextBox();
            this.ajouterPieceDuree = new System.Windows.Forms.TextBox();
            this.ajouterPieceNom = new System.Windows.Forms.TextBox();
            this.buttonAjouterPiece = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabListRep = new System.Windows.Forms.TabPage();
            this.tabAjoutRep = new System.Windows.Forms.TabPage();
            this.tabListReserv = new System.Windows.Forms.TabPage();
            this.tabAjoutReserv = new System.Windows.Forms.TabPage();
            this.tabAnalyse = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabListPièces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabAjoutPièces.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piècesToolStripMenuItem,
            this.representationsToolStripMenuItem,
            this.réservationsToolStripMenuItem,
            this.analyseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // piècesToolStripMenuItem
            // 
            this.piècesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesPiècesToolStripMenuItem,
            this.ajouterUnePièceToolStripMenuItem});
            this.piècesToolStripMenuItem.Name = "piècesToolStripMenuItem";
            this.piècesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.piècesToolStripMenuItem.Text = "Pièces";
            // 
            // listeDesPiècesToolStripMenuItem
            // 
            this.listeDesPiècesToolStripMenuItem.Name = "listeDesPiècesToolStripMenuItem";
            this.listeDesPiècesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listeDesPiècesToolStripMenuItem.Text = "Liste des Pièces";
            this.listeDesPiècesToolStripMenuItem.Click += new System.EventHandler(this.listeDesPiècesToolStripMenuItem_Click);
            // 
            // ajouterUnePièceToolStripMenuItem
            // 
            this.ajouterUnePièceToolStripMenuItem.Name = "ajouterUnePièceToolStripMenuItem";
            this.ajouterUnePièceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajouterUnePièceToolStripMenuItem.Text = "Ajouter une Pièce";
            this.ajouterUnePièceToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnePièceToolStripMenuItem_Click);
            // 
            // representationsToolStripMenuItem
            // 
            this.representationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesReprésentationsToolStripMenuItem,
            this.ajouterUneReprésentationToolStripMenuItem});
            this.representationsToolStripMenuItem.Name = "representationsToolStripMenuItem";
            this.representationsToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.representationsToolStripMenuItem.Text = "Representations";
            // 
            // listeDesReprésentationsToolStripMenuItem
            // 
            this.listeDesReprésentationsToolStripMenuItem.Name = "listeDesReprésentationsToolStripMenuItem";
            this.listeDesReprésentationsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.listeDesReprésentationsToolStripMenuItem.Text = "Liste des Représentations";
            this.listeDesReprésentationsToolStripMenuItem.Click += new System.EventHandler(this.listeDesReprésentationsToolStripMenuItem_Click);
            // 
            // ajouterUneReprésentationToolStripMenuItem
            // 
            this.ajouterUneReprésentationToolStripMenuItem.Name = "ajouterUneReprésentationToolStripMenuItem";
            this.ajouterUneReprésentationToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ajouterUneReprésentationToolStripMenuItem.Text = "Ajouter une Représentation";
            this.ajouterUneReprésentationToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneReprésentationToolStripMenuItem_Click);
            // 
            // réservationsToolStripMenuItem
            // 
            this.réservationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesRéservationsToolStripMenuItem,
            this.ajouterUneRéservationToolStripMenuItem});
            this.réservationsToolStripMenuItem.Name = "réservationsToolStripMenuItem";
            this.réservationsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.réservationsToolStripMenuItem.Text = "Réservations";
            // 
            // listeDesRéservationsToolStripMenuItem
            // 
            this.listeDesRéservationsToolStripMenuItem.Name = "listeDesRéservationsToolStripMenuItem";
            this.listeDesRéservationsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.listeDesRéservationsToolStripMenuItem.Text = "Liste des Réservations";
            this.listeDesRéservationsToolStripMenuItem.Click += new System.EventHandler(this.listeDesRéservationsToolStripMenuItem_Click);
            // 
            // ajouterUneRéservationToolStripMenuItem
            // 
            this.ajouterUneRéservationToolStripMenuItem.Name = "ajouterUneRéservationToolStripMenuItem";
            this.ajouterUneRéservationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.ajouterUneRéservationToolStripMenuItem.Text = "Ajouter une Réservation";
            this.ajouterUneRéservationToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneRéservationToolStripMenuItem_Click);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyseToolStripMenuItem.Text = "Analyse";
            this.analyseToolStripMenuItem.Click += new System.EventHandler(this.analyseToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabListPièces);
            this.tabControl1.Controls.Add(this.tabAjoutPièces);
            this.tabControl1.Controls.Add(this.tabListRep);
            this.tabControl1.Controls.Add(this.tabAjoutRep);
            this.tabControl1.Controls.Add(this.tabListReserv);
            this.tabControl1.Controls.Add(this.tabAjoutReserv);
            this.tabControl1.Controls.Add(this.tabAnalyse);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(803, 374);
            this.tabControl1.TabIndex = 1;
            // 
            // tabListPièces
            // 
            this.tabListPièces.Controls.Add(this.btnSuppressionPiece);
            this.tabListPièces.Controls.Add(this.btnModifierPiece);
            this.tabListPièces.Controls.Add(this.label1);
            this.tabListPièces.Controls.Add(this.btnActualiser);
            this.tabListPièces.Controls.Add(this.dataGridView1);
            this.tabListPièces.Location = new System.Drawing.Point(4, 22);
            this.tabListPièces.Margin = new System.Windows.Forms.Padding(2);
            this.tabListPièces.Name = "tabListPièces";
            this.tabListPièces.Size = new System.Drawing.Size(795, 348);
            this.tabListPièces.TabIndex = 0;
            this.tabListPièces.Text = "Liste des Pièces";
            this.tabListPièces.UseVisualStyleBackColor = true;
            this.tabListPièces.Click += new System.EventHandler(this.tabListPièces_Click);
            // 
            // btnSuppressionPiece
            // 
            this.btnSuppressionPiece.Location = new System.Drawing.Point(330, 292);
            this.btnSuppressionPiece.Name = "btnSuppressionPiece";
            this.btnSuppressionPiece.Size = new System.Drawing.Size(75, 23);
            this.btnSuppressionPiece.TabIndex = 4;
            this.btnSuppressionPiece.Text = "Supprimer";
            this.btnSuppressionPiece.UseVisualStyleBackColor = true;
            this.btnSuppressionPiece.Click += new System.EventHandler(this.btnSuppressionPiece_Click);
            // 
            // btnModifierPiece
            // 
            this.btnModifierPiece.Location = new System.Drawing.Point(233, 292);
            this.btnModifierPiece.Name = "btnModifierPiece";
            this.btnModifierPiece.Size = new System.Drawing.Size(75, 23);
            this.btnModifierPiece.TabIndex = 3;
            this.btnModifierPiece.Text = "Modifier";
            this.btnModifierPiece.UseVisualStyleBackColor = true;
            this.btnModifierPiece.Click += new System.EventHandler(this.btnModifierPiece_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liste des Pièces";
            // 
            // btnActualiser
            // 
            this.btnActualiser.Location = new System.Drawing.Point(66, 292);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(144, 22);
            this.btnActualiser.TabIndex = 1;
            this.btnActualiser.Text = "Actualiser les pièces";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(541, 227);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableauListePieces_CellContentClick);
            // 
            // tabAjoutPièces
            // 
            this.tabAjoutPièces.Controls.Add(this.ajouterPiecePrix);
            this.tabAjoutPièces.Controls.Add(this.label9);
            this.tabAjoutPièces.Controls.Add(this.ajouterPieceTheme);
            this.tabAjoutPièces.Controls.Add(this.ajouterPiecePublic);
            this.tabAjoutPièces.Controls.Add(this.ajouterPieceAuteur);
            this.tabAjoutPièces.Controls.Add(this.ajouterPieceDesc);
            this.tabAjoutPièces.Controls.Add(this.ajouterPieceDuree);
            this.tabAjoutPièces.Controls.Add(this.ajouterPieceNom);
            this.tabAjoutPièces.Controls.Add(this.buttonAjouterPiece);
            this.tabAjoutPièces.Controls.Add(this.label8);
            this.tabAjoutPièces.Controls.Add(this.label7);
            this.tabAjoutPièces.Controls.Add(this.label6);
            this.tabAjoutPièces.Controls.Add(this.label5);
            this.tabAjoutPièces.Controls.Add(this.label4);
            this.tabAjoutPièces.Controls.Add(this.label3);
            this.tabAjoutPièces.Controls.Add(this.label2);
            this.tabAjoutPièces.Location = new System.Drawing.Point(4, 22);
            this.tabAjoutPièces.Margin = new System.Windows.Forms.Padding(2);
            this.tabAjoutPièces.Name = "tabAjoutPièces";
            this.tabAjoutPièces.Size = new System.Drawing.Size(795, 348);
            this.tabAjoutPièces.TabIndex = 1;
            this.tabAjoutPièces.Text = "Ajouter une Pièce";
            this.tabAjoutPièces.UseVisualStyleBackColor = true;
            // 
            // ajouterPiecePrix
            // 
            this.ajouterPiecePrix.Location = new System.Drawing.Point(529, 215);
            this.ajouterPiecePrix.Name = "ajouterPiecePrix";
            this.ajouterPiecePrix.Size = new System.Drawing.Size(142, 20);
            this.ajouterPiecePrix.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(420, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Prix de base :";
            // 
            // ajouterPieceTheme
            // 
            this.ajouterPieceTheme.FormattingEnabled = true;
            this.ajouterPieceTheme.Location = new System.Drawing.Point(152, 230);
            this.ajouterPieceTheme.Name = "ajouterPieceTheme";
            this.ajouterPieceTheme.Size = new System.Drawing.Size(186, 17);
            this.ajouterPieceTheme.TabIndex = 20;
            // 
            // ajouterPiecePublic
            // 
            this.ajouterPiecePublic.FormattingEnabled = true;
            this.ajouterPiecePublic.Location = new System.Drawing.Point(529, 118);
            this.ajouterPiecePublic.Name = "ajouterPiecePublic";
            this.ajouterPiecePublic.Size = new System.Drawing.Size(142, 17);
            this.ajouterPiecePublic.TabIndex = 19;
            // 
            // ajouterPieceAuteur
            // 
            this.ajouterPieceAuteur.FormattingEnabled = true;
            this.ajouterPieceAuteur.Location = new System.Drawing.Point(529, 169);
            this.ajouterPieceAuteur.Name = "ajouterPieceAuteur";
            this.ajouterPieceAuteur.Size = new System.Drawing.Size(142, 17);
            this.ajouterPieceAuteur.TabIndex = 18;
            // 
            // ajouterPieceDesc
            // 
            this.ajouterPieceDesc.Location = new System.Drawing.Point(152, 117);
            this.ajouterPieceDesc.Name = "ajouterPieceDesc";
            this.ajouterPieceDesc.Size = new System.Drawing.Size(186, 96);
            this.ajouterPieceDesc.TabIndex = 17;
            this.ajouterPieceDesc.Text = "";
            // 
            // ajouterPieceDuree
            // 
            this.ajouterPieceDuree.Location = new System.Drawing.Point(529, 68);
            this.ajouterPieceDuree.Name = "ajouterPieceDuree";
            this.ajouterPieceDuree.Size = new System.Drawing.Size(142, 20);
            this.ajouterPieceDuree.TabIndex = 12;
            // 
            // ajouterPieceNom
            // 
            this.ajouterPieceNom.Location = new System.Drawing.Point(152, 69);
            this.ajouterPieceNom.Name = "ajouterPieceNom";
            this.ajouterPieceNom.Size = new System.Drawing.Size(186, 20);
            this.ajouterPieceNom.TabIndex = 10;
            // 
            // buttonAjouterPiece
            // 
            this.buttonAjouterPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterPiece.Location = new System.Drawing.Point(347, 264);
            this.buttonAjouterPiece.Name = "buttonAjouterPiece";
            this.buttonAjouterPiece.Size = new System.Drawing.Size(112, 38);
            this.buttonAjouterPiece.TabIndex = 9;
            this.buttonAjouterPiece.Text = "Enregistrer";
            this.buttonAjouterPiece.UseVisualStyleBackColor = true;
            this.buttonAjouterPiece.Click += new System.EventHandler(this.buttonAjouterPiece_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Theme :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(441, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Auteur :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(420, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Type de public :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(441, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Durée :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ajouter une pièce";
            // 
            // tabListRep
            // 
            this.tabListRep.Location = new System.Drawing.Point(4, 22);
            this.tabListRep.Margin = new System.Windows.Forms.Padding(2);
            this.tabListRep.Name = "tabListRep";
            this.tabListRep.Size = new System.Drawing.Size(795, 348);
            this.tabListRep.TabIndex = 2;
            this.tabListRep.Text = "Liste des Représentations";
            this.tabListRep.UseVisualStyleBackColor = true;
            // 
            // tabAjoutRep
            // 
            this.tabAjoutRep.Location = new System.Drawing.Point(4, 22);
            this.tabAjoutRep.Margin = new System.Windows.Forms.Padding(2);
            this.tabAjoutRep.Name = "tabAjoutRep";
            this.tabAjoutRep.Size = new System.Drawing.Size(795, 348);
            this.tabAjoutRep.TabIndex = 3;
            this.tabAjoutRep.Text = "Ajouter une Représentation";
            this.tabAjoutRep.UseVisualStyleBackColor = true;
            // 
            // tabListReserv
            // 
            this.tabListReserv.Location = new System.Drawing.Point(4, 22);
            this.tabListReserv.Margin = new System.Windows.Forms.Padding(2);
            this.tabListReserv.Name = "tabListReserv";
            this.tabListReserv.Size = new System.Drawing.Size(795, 348);
            this.tabListReserv.TabIndex = 4;
            this.tabListReserv.Text = "Liste des Réservations";
            this.tabListReserv.UseVisualStyleBackColor = true;
            // 
            // tabAjoutReserv
            // 
            this.tabAjoutReserv.Location = new System.Drawing.Point(4, 22);
            this.tabAjoutReserv.Margin = new System.Windows.Forms.Padding(2);
            this.tabAjoutReserv.Name = "tabAjoutReserv";
            this.tabAjoutReserv.Size = new System.Drawing.Size(795, 348);
            this.tabAjoutReserv.TabIndex = 5;
            this.tabAjoutReserv.Text = "Ajouter une Réservation";
            this.tabAjoutReserv.UseVisualStyleBackColor = true;
            // 
            // tabAnalyse
            // 
            this.tabAnalyse.Location = new System.Drawing.Point(4, 22);
            this.tabAnalyse.Margin = new System.Windows.Forms.Padding(2);
            this.tabAnalyse.Name = "tabAnalyse";
            this.tabAnalyse.Size = new System.Drawing.Size(795, 348);
            this.tabAnalyse.TabIndex = 6;
            this.tabAnalyse.Text = "Analyse";
            this.tabAnalyse.UseVisualStyleBackColor = true;
            // 
            // Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 421);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Gestion";
            this.Text = "Gestion du  Theatre";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gestion_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabListPièces.ResumeLayout(false);
            this.tabListPièces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabAjoutPièces.ResumeLayout(false);
            this.tabAjoutPièces.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem piècesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesPiècesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnePièceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem representationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesReprésentationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneReprésentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem réservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesRéservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneRéservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabListPièces;
        private System.Windows.Forms.TabPage tabAjoutPièces;
        private System.Windows.Forms.TabPage tabListRep;
        private System.Windows.Forms.TabPage tabAjoutRep;
        private System.Windows.Forms.TabPage tabListReserv;
        private System.Windows.Forms.TabPage tabAjoutReserv;
        private System.Windows.Forms.TabPage tabAnalyse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAjouterPiece;
        private System.Windows.Forms.TextBox ajouterPieceDuree;
        private System.Windows.Forms.TextBox ajouterPieceNom;
        private System.Windows.Forms.RichTextBox ajouterPieceDesc;
        private System.Windows.Forms.ListBox ajouterPieceAuteur;
        private System.Windows.Forms.ListBox ajouterPieceTheme;
        private System.Windows.Forms.ListBox ajouterPiecePublic;
        private System.Windows.Forms.TextBox ajouterPiecePrix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSuppressionPiece;
        private System.Windows.Forms.Button btnModifierPiece;
    }
}