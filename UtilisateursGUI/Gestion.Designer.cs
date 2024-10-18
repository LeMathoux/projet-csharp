namespace projet_csharp
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
            this.tabAjoutPièces = new System.Windows.Forms.TabPage();
            this.tabListRep = new System.Windows.Forms.TabPage();
            this.tabAjoutRep = new System.Windows.Forms.TabPage();
            this.tabListReserv = new System.Windows.Forms.TabPage();
            this.tabAjoutReserv = new System.Windows.Forms.TabPage();
            this.tabAnalyse = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1071, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // piècesToolStripMenuItem
            // 
            this.piècesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesPiècesToolStripMenuItem,
            this.ajouterUnePièceToolStripMenuItem});
            this.piècesToolStripMenuItem.Name = "piècesToolStripMenuItem";
            this.piècesToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.piècesToolStripMenuItem.Text = "Pièces";
            // 
            // listeDesPiècesToolStripMenuItem
            // 
            this.listeDesPiècesToolStripMenuItem.Name = "listeDesPiècesToolStripMenuItem";
            this.listeDesPiècesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.listeDesPiècesToolStripMenuItem.Text = "Liste des Pièces";
            this.listeDesPiècesToolStripMenuItem.Click += new System.EventHandler(this.listeDesPiècesToolStripMenuItem_Click);
            // 
            // ajouterUnePièceToolStripMenuItem
            // 
            this.ajouterUnePièceToolStripMenuItem.Name = "ajouterUnePièceToolStripMenuItem";
            this.ajouterUnePièceToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ajouterUnePièceToolStripMenuItem.Text = "Ajouter une Pièce";
            this.ajouterUnePièceToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnePièceToolStripMenuItem_Click);
            // 
            // representationsToolStripMenuItem
            // 
            this.representationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesReprésentationsToolStripMenuItem,
            this.ajouterUneReprésentationToolStripMenuItem});
            this.representationsToolStripMenuItem.Name = "representationsToolStripMenuItem";
            this.representationsToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.representationsToolStripMenuItem.Text = "Representations";
            // 
            // listeDesReprésentationsToolStripMenuItem
            // 
            this.listeDesReprésentationsToolStripMenuItem.Name = "listeDesReprésentationsToolStripMenuItem";
            this.listeDesReprésentationsToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.listeDesReprésentationsToolStripMenuItem.Text = "Liste des Représentations";
            this.listeDesReprésentationsToolStripMenuItem.Click += new System.EventHandler(this.listeDesReprésentationsToolStripMenuItem_Click);
            // 
            // ajouterUneReprésentationToolStripMenuItem
            // 
            this.ajouterUneReprésentationToolStripMenuItem.Name = "ajouterUneReprésentationToolStripMenuItem";
            this.ajouterUneReprésentationToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.ajouterUneReprésentationToolStripMenuItem.Text = "Ajouter une Représentation";
            this.ajouterUneReprésentationToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneReprésentationToolStripMenuItem_Click);
            // 
            // réservationsToolStripMenuItem
            // 
            this.réservationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesRéservationsToolStripMenuItem,
            this.ajouterUneRéservationToolStripMenuItem});
            this.réservationsToolStripMenuItem.Name = "réservationsToolStripMenuItem";
            this.réservationsToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.réservationsToolStripMenuItem.Text = "Réservations";
            // 
            // listeDesRéservationsToolStripMenuItem
            // 
            this.listeDesRéservationsToolStripMenuItem.Name = "listeDesRéservationsToolStripMenuItem";
            this.listeDesRéservationsToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.listeDesRéservationsToolStripMenuItem.Text = "Liste des Réservations";
            this.listeDesRéservationsToolStripMenuItem.Click += new System.EventHandler(this.listeDesRéservationsToolStripMenuItem_Click);
            // 
            // ajouterUneRéservationToolStripMenuItem
            // 
            this.ajouterUneRéservationToolStripMenuItem.Name = "ajouterUneRéservationToolStripMenuItem";
            this.ajouterUneRéservationToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.ajouterUneRéservationToolStripMenuItem.Text = "Ajouter une Réservation";
            this.ajouterUneRéservationToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneRéservationToolStripMenuItem_Click);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1071, 460);
            this.tabControl1.TabIndex = 1;
            // 
            // tabListPièces
            // 
            this.tabListPièces.Location = new System.Drawing.Point(4, 25);
            this.tabListPièces.Name = "tabListPièces";
            this.tabListPièces.Size = new System.Drawing.Size(1063, 431);
            this.tabListPièces.TabIndex = 0;
            this.tabListPièces.Text = "Liste des Pièces";
            this.tabListPièces.UseVisualStyleBackColor = true;
            // 
            // tabAjoutPièces
            // 
            this.tabAjoutPièces.Location = new System.Drawing.Point(4, 25);
            this.tabAjoutPièces.Name = "tabAjoutPièces";
            this.tabAjoutPièces.Size = new System.Drawing.Size(1063, 431);
            this.tabAjoutPièces.TabIndex = 1;
            this.tabAjoutPièces.Text = "tabPage4";
            this.tabAjoutPièces.UseVisualStyleBackColor = true;
            // 
            // tabListRep
            // 
            this.tabListRep.Location = new System.Drawing.Point(4, 25);
            this.tabListRep.Name = "tabListRep";
            this.tabListRep.Size = new System.Drawing.Size(1063, 431);
            this.tabListRep.TabIndex = 2;
            this.tabListRep.Text = "Liste des Représentations";
            this.tabListRep.UseVisualStyleBackColor = true;
            // 
            // tabAjoutRep
            // 
            this.tabAjoutRep.Location = new System.Drawing.Point(4, 25);
            this.tabAjoutRep.Name = "tabAjoutRep";
            this.tabAjoutRep.Size = new System.Drawing.Size(1063, 431);
            this.tabAjoutRep.TabIndex = 3;
            this.tabAjoutRep.Text = "Ajouter une Représentation";
            this.tabAjoutRep.UseVisualStyleBackColor = true;
            // 
            // tabListReserv
            // 
            this.tabListReserv.Location = new System.Drawing.Point(4, 25);
            this.tabListReserv.Name = "tabListReserv";
            this.tabListReserv.Size = new System.Drawing.Size(1063, 431);
            this.tabListReserv.TabIndex = 4;
            this.tabListReserv.Text = "Liste des Réservations";
            this.tabListReserv.UseVisualStyleBackColor = true;
            // 
            // tabAjoutReserv
            // 
            this.tabAjoutReserv.Location = new System.Drawing.Point(4, 25);
            this.tabAjoutReserv.Name = "tabAjoutReserv";
            this.tabAjoutReserv.Size = new System.Drawing.Size(1063, 431);
            this.tabAjoutReserv.TabIndex = 5;
            this.tabAjoutReserv.Text = "Ajouter une Réservation";
            this.tabAjoutReserv.UseVisualStyleBackColor = true;
            // 
            // tabAnalyse
            // 
            this.tabAnalyse.Location = new System.Drawing.Point(4, 25);
            this.tabAnalyse.Name = "tabAnalyse";
            this.tabAnalyse.Size = new System.Drawing.Size(1063, 431);
            this.tabAnalyse.TabIndex = 6;
            this.tabAnalyse.Text = "Analyse";
            this.tabAnalyse.UseVisualStyleBackColor = true;
            // 
            // Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Gestion";
            this.Text = "Gestion du  Theatre";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
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
    }
}