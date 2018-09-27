namespace SynchroniseStudentsGUI
{
    partial class Preference
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preference));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.MaskedTextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.chkServeur = new System.Windows.Forms.CheckBox();
            this.cboBD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMotPasse = new System.Windows.Forms.MaskedTextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.txtServeur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.chkFichier = new System.Windows.Forms.CheckBox();
            this.gpFile = new System.Windows.Forms.GroupBox();
            this.lblViewContentFile = new System.Windows.Forms.LinkLabel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblLoadPath = new System.Windows.Forms.Label();
            this.temps1 = new System.Windows.Forms.Timer(this.components);
            this.temps2 = new System.Windows.Forms.Timer(this.components);
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.pnLogin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnLogin);
            this.groupBox1.Controls.Add(this.chkServeur);
            this.groupBox1.Controls.Add(this.cboBD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.cmdValidate);
            this.pnLogin.Controls.Add(this.txtPwd);
            this.pnLogin.Controls.Add(this.lblPwd);
            this.pnLogin.Location = new System.Drawing.Point(-5, 0);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(328, 131);
            this.pnLogin.TabIndex = 8;
            // 
            // cmdValidate
            // 
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmdValidate.Location = new System.Drawing.Point(246, 81);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(76, 23);
            this.cmdValidate.TabIndex = 4;
            this.cmdValidate.Text = "&Valider";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(145, 55);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(177, 20);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(62, 58);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(77, 13);
            this.lblPwd.TabIndex = 2;
            this.lblPwd.Text = "Mot de passe :";
            // 
            // chkServeur
            // 
            this.chkServeur.AutoSize = true;
            this.chkServeur.ForeColor = System.Drawing.Color.Purple;
            this.chkServeur.Location = new System.Drawing.Point(295, 14);
            this.chkServeur.Name = "chkServeur";
            this.chkServeur.Size = new System.Drawing.Size(61, 17);
            this.chkServeur.TabIndex = 5;
            this.chkServeur.Text = "MySQL";
            this.chkServeur.UseVisualStyleBackColor = true;
            this.chkServeur.CheckedChanged += new System.EventHandler(this.chkServeur_CheckedChanged);
            // 
            // cboBD
            // 
            this.cboBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBD.FormattingEnabled = true;
            this.cboBD.Location = new System.Drawing.Point(161, 12);
            this.cboBD.Name = "cboBD";
            this.cboBD.Size = new System.Drawing.Size(123, 21);
            this.cboBD.TabIndex = 0;
            this.cboBD.SelectedIndexChanged += new System.EventHandler(this.cboBD_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type de base de données :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.txtMotPasse);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.txtBD);
            this.groupBox2.Controls.Add(this.txtServeur);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(7, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtMotPasse
            // 
            this.txtMotPasse.Location = new System.Drawing.Point(114, 79);
            this.txtMotPasse.Name = "txtMotPasse";
            this.txtMotPasse.PasswordChar = '*';
            this.txtMotPasse.Size = new System.Drawing.Size(242, 20);
            this.txtMotPasse.TabIndex = 4;
            this.txtMotPasse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMotPasse_KeyDown);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(114, 55);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(242, 20);
            this.txtUser.TabIndex = 3;
            // 
            // txtBD
            // 
            this.txtBD.Location = new System.Drawing.Point(114, 32);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(242, 20);
            this.txtBD.TabIndex = 2;
            // 
            // txtServeur
            // 
            this.txtServeur.Location = new System.Drawing.Point(114, 10);
            this.txtServeur.Name = "txtServeur";
            this.txtServeur.Size = new System.Drawing.Size(242, 20);
            this.txtServeur.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mot de passe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nom d\'utilisateur :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base des données :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Serveur :";
            // 
            // cmdSave
            // 
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmdSave.Location = new System.Drawing.Point(314, 162);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "&Enregistrer";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // chkFichier
            // 
            this.chkFichier.AutoSize = true;
            this.chkFichier.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFichier.Location = new System.Drawing.Point(7, 166);
            this.chkFichier.Name = "chkFichier";
            this.chkFichier.Size = new System.Drawing.Size(114, 17);
            this.chkFichier.TabIndex = 6;
            this.chkFichier.Text = "Utiliser fichier texte";
            this.chkFichier.UseVisualStyleBackColor = true;
            this.chkFichier.CheckedChanged += new System.EventHandler(this.chkFichier_CheckedChanged);
            // 
            // gpFile
            // 
            this.gpFile.Controls.Add(this.lblViewContentFile);
            this.gpFile.Controls.Add(this.txtPath);
            this.gpFile.Controls.Add(this.lblLoadPath);
            this.gpFile.Location = new System.Drawing.Point(7, 193);
            this.gpFile.Name = "gpFile";
            this.gpFile.Size = new System.Drawing.Size(381, 69);
            this.gpFile.TabIndex = 10;
            this.gpFile.TabStop = false;
            this.gpFile.Text = "Sélection du fichier à utiliser";
            // 
            // lblViewContentFile
            // 
            this.lblViewContentFile.AutoSize = true;
            this.lblViewContentFile.Location = new System.Drawing.Point(108, 48);
            this.lblViewContentFile.Name = "lblViewContentFile";
            this.lblViewContentFile.Size = new System.Drawing.Size(142, 13);
            this.lblViewContentFile.TabIndex = 11;
            this.lblViewContentFile.TabStop = true;
            this.lblViewContentFile.Text = "Afficher le contenu du fichier";
            this.lblViewContentFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewContentFile_LinkClicked);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(6, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(317, 20);
            this.txtPath.TabIndex = 9;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // lblLoadPath
            // 
            this.lblLoadPath.BackColor = System.Drawing.Color.Azure;
            this.lblLoadPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoadPath.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoadPath.Location = new System.Drawing.Point(327, 20);
            this.lblLoadPath.Name = "lblLoadPath";
            this.lblLoadPath.Size = new System.Drawing.Size(47, 20);
            this.lblLoadPath.TabIndex = 7;
            this.lblLoadPath.Text = "...........";
            this.lblLoadPath.MouseLeave += new System.EventHandler(this.lblLoadPath_MouseLeave);
            this.lblLoadPath.Click += new System.EventHandler(this.lblLoadPath_Click);
            this.lblLoadPath.MouseEnter += new System.EventHandler(this.lblLoadPath_MouseEnter);
            // 
            // temps1
            // 
            this.temps1.Tick += new System.EventHandler(this.temps1_Tick);
            // 
            // temps2
            // 
            this.temps2.Tick += new System.EventHandler(this.temps2_Tick);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Text Files (*.txt) | (*.txt)|All files(*.*)|*.*";
            this.dlgOpen.InitialDirectory = ".";
            this.dlgOpen.Title = "Sélection du fichier de travail";
            // 
            // Preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 270);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkFichier);
            this.Controls.Add(this.gpFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Preference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préférence pour BD";
            this.Load += new System.EventHandler(this.Preference_Load);
            this.Shown += new System.EventHandler(this.Preference_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpFile.ResumeLayout(false);
            this.gpFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtMotPasse;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtBD;
        private System.Windows.Forms.TextBox txtServeur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBD;
        private System.Windows.Forms.CheckBox chkServeur;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.MaskedTextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.CheckBox chkFichier;
        private System.Windows.Forms.GroupBox gpFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblLoadPath;
        private System.Windows.Forms.Timer temps1;
        private System.Windows.Forms.Timer temps2;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.LinkLabel lblViewContentFile;
    }
}