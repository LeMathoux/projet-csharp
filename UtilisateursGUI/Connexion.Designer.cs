namespace projet_csharp
{
    partial class Connexion
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
            this.titreForm = new System.Windows.Forms.Label();
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.lblMdp = new System.Windows.Forms.Label();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.Connexionbtn = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titreForm
            // 
            this.titreForm.AutoSize = true;
            this.titreForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titreForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.8F);
            this.titreForm.Location = new System.Drawing.Point(426, 25);
            this.titreForm.Name = "titreForm";
            this.titreForm.Size = new System.Drawing.Size(249, 56);
            this.titreForm.TabIndex = 0;
            this.titreForm.Text = "Connexion";
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblIdentifiant.Location = new System.Drawing.Point(359, 149);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(118, 26);
            this.lblIdentifiant.TabIndex = 1;
            this.lblIdentifiant.Text = "Identifiant :";
            // 
            // lblMdp
            // 
            this.lblMdp.AutoSize = true;
            this.lblMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblMdp.Location = new System.Drawing.Point(323, 208);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(154, 26);
            this.lblMdp.TabIndex = 2;
            this.lblMdp.Text = "Mot de passe :";
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Location = new System.Drawing.Point(512, 149);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(208, 22);
            this.txtIdentifiant.TabIndex = 3;
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(512, 208);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.Size = new System.Drawing.Size(208, 22);
            this.txtMdp.TabIndex = 4;
            // 
            // Connexionbtn
            // 
            this.Connexionbtn.Location = new System.Drawing.Point(491, 281);
            this.Connexionbtn.Name = "Connexionbtn";
            this.Connexionbtn.Size = new System.Drawing.Size(125, 33);
            this.Connexionbtn.TabIndex = 5;
            this.Connexionbtn.Text = "Connexion";
            this.Connexionbtn.UseVisualStyleBackColor = true;
            this.Connexionbtn.Click += new System.EventHandler(this.Connexionbtn_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(322, 356);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 31);
            this.lblError.TabIndex = 6;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 582);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.Connexionbtn);
            this.Controls.Add(this.txtMdp);
            this.Controls.Add(this.txtIdentifiant);
            this.Controls.Add(this.lblMdp);
            this.Controls.Add(this.lblIdentifiant);
            this.Controls.Add(this.titreForm);
            this.Name = "Connexion";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titreForm;
        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label lblMdp;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtMdp;
        private System.Windows.Forms.Button Connexionbtn;
        private System.Windows.Forms.Label lblError;
    }
}