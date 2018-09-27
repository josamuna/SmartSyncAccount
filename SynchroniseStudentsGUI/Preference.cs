using System;
using System.Text;
using System.Windows.Forms;
using ManageConnexion;
using ManageUtilities;
using SynchroniseStudentsLIB;

namespace SynchroniseStudentsGUI
{
    public partial class Preference : Form
    {
        private const string directoryMaster = "SynchroniseStudentsAccount";
        private const string DirectoryUtilConn = "ConnectionString";
        private const string DirectoryUtilLog = "Log";
        private const string DirectoryUtilOther = "Other";
        private const string FileSQLServer = "UserSQLSever";
        private const string FileMySQL = "UserMySQL";
        private const string FileServerType = "UserServerType";
        private const string FilePathFile = "UserPath.txt";

        private bool isFile = false;

        public Preference()
        {
            InitializeComponent();
        }

        private void Preference_Load(object sender, EventArgs e)
        {
            this.Width = 403;
            //this.Height = 221;
            this.Height = 286;
            chkFichier.Checked = true;
            cmdSave.Visible = false;

            gpFile.Visible = false;
            chkFichier.Visible = false;

            pnLogin.Width = 397;
            //pnLogin.Height = 192;
            pnLogin.Height = 253;
        }

        private void LoadValues()
        {
            cboBD.DataSource = Enum.GetNames(typeof(ServerType));
            cboBD.SelectedIndex = 1;
            txtPwd.Focus();

            try
            {
                Connection connection = new Connection();

                ////string strLoad = ImplementUtilities.Instance.LoadParameters(DirectoryUtilConn, FileSQLServer);
                ////LoadParametersServeur(strLoad);
                
                //Parametres BD Par defaut uniquement pour MySQL car la sauvegarde se passe dans MySQL
                string strLoad = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FileMySQL);
                LoadParametersServeur(strLoad);

                //Chargement fichier de travail qui contient les query Chiffrer
                Utilitaires.Instance.Path = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FilePathFile);
                txtPath.Text = Utilitaires.Instance.Path;

                //Parametre preference type serveur (SQLServer ou MySQL)
                string str = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilOther, FileServerType).Split('=')[1].Trim();
                TypeServeur.Instance.MyServerType = str.Equals(Convert.ToString(ServerType.SQLServer)) ? ServerType.SQLServer : ServerType.MySQL;

                if (TypeServeur.Instance.MyServerType.Equals(ServerType.MySQL))
                    chkServeur.Checked = true;
                else
                    chkServeur.Checked = false;
            }
            catch (Exception ex)
            {
                chkServeur.Checked = true;
                MessageBox.Show("Echec de chargement des paramètres d'accès, " + ex.Message, "Chargement paramètres BD/Fichier", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = false;
            Connection con = new Connection();

            if (cboBD.SelectedIndex == 0 && !isFile)
            {
                //Save Preferences SQL Server
                try
                {
                    ValuesServerSave(con);

                    //Enregistrement des parametres de connexion
                    ImplementUtilities.Instance.SaveParameters(directoryMaster, string.Format("Serveur={0}\nDBName={1}\nUserName={2}\nUserPassword={3}",
                        con.Serveur, con.Database, con.User, con.Password), DirectoryUtilConn, FileSQLServer);

                    //Enregistrement chemin d'acces fichier
                    ImplementUtilities.Instance.SaveParameters(directoryMaster, Utilitaires.Instance.Path, DirectoryUtilConn, FilePathFile);

                    MessageBox.Show("Enregistrement effectué", "Enregistrement préférences SQL Server et Fichier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec d'enregistrement, " + ex.Message, "Enregistrement préférences SQL Server et Fichier", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (cboBD.SelectedIndex == 1 && isFile)
            {
                //Save Preferences MySQL
                try
                {
                    ValuesServerSave(con);
                    
                    //Enregistrement des parametres de connexion
                    ImplementUtilities.Instance.SaveParameters(directoryMaster, string.Format("Serveur={0}\nDBName={1}\nUserName={2}\nUserPassword={3}",
                        con.Serveur, con.Database, con.User, con.Password), DirectoryUtilConn, FileMySQL);

                    //Enregistrement chemin d'acces fichier
                    ImplementUtilities.Instance.SaveParameters(directoryMaster, Utilitaires.Instance.Path, DirectoryUtilConn, FilePathFile);

                    MessageBox.Show("Enregistrement effectué", "Enregistrement préférences MySQL et Fichier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec d'enregistrement, " + ex.Message, "Enregistrement préférences MySQL et Fichier", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            try
            {
                //Enregistrement parametre du type de serveur
                ImplementUtilities.Instance.SaveParameters(directoryMaster, string.Format("ServeurType={0}", TypeServeur.Instance.MyServerType.ToString()), DirectoryUtilOther, FileServerType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec d'enregistrement, " + ex.Message, "Enregistrement préférences Type serveur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ValuesServerSave(Connection con)
        {
            con.Serveur = txtServeur.Text;
            con.Database = txtBD.Text;
            con.User = txtUser.Text;
            con.Password = ImplementChiffer.Instance.Cipher(txtMotPasse.Text, "Jos@mP@ss");
            TypeServeur.Instance.MyServerType = chkServeur.Checked ? ServerType.MySQL : ServerType.SQLServer;
        }

        private string GetFileName(string path)
        {
            string strFichier = "";
            string[] tab = path.Split('\\');

            for (int i = tab.Length - 1; i >= 0; )
            {
                strFichier = tab[i].Trim();
                break;
            }

            return strFichier;
        }

        private void cboBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMotPasse.Clear();
            if (cboBD.SelectedIndex == 0)
            {
                //Chargement Preferences BD
                try
                {
                    string paramDBSQLServer = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FileSQLServer);

                    LoadParametersServeur(paramDBSQLServer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de chargement, " + ex.Message, "Chargement préférences BD SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (cboBD.SelectedIndex == 1)
            {
                //Chargement Preferences BD
                try
                {
                    string paramDBMySQL = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FileMySQL);

                    LoadParametersServeur(paramDBMySQL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de chargement, " + ex.Message, "Chargement préférences BD MySQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void LoadParametersServeur(string paramDB)
        {
            Connection sqlServer = new Connection();

            string[] sql = paramDB.Split('\n');

            for (int i = 0; i < sql.Length; i++)
            {
                switch (i)
                {
                    case 0: sqlServer.Serveur = sql[0].Split('=')[1];
                        break;
                    case 1: sqlServer.Database = sql[1].Split('=')[1];
                        break;
                    case 2: sqlServer.User = sql[2].Split('=')[1];
                        break;
                    case 3:
                        string[] tab = sql[3].Split('=');
                        int indexTab = 0;
                        StringBuilder build = new StringBuilder();

                        foreach (string str in tab)
                        {
                            if (indexTab == 0)
                            {
                                indexTab++;
                                continue;
                            }
                            else if (indexTab == 1)
                            {
                                indexTab++;
                                build.Append(str);
                            }
                            else
                            {
                                indexTab++;
                                build.Append("=");
                                build.Append(str);
                            }
                        }

                        sqlServer.Password = ImplementChiffer.Instance.Decipher(build.ToString(), "Jos@mP@ss");
                        break;
                }
            }

            txtServeur.Text = sqlServer.Serveur;
            txtBD.Text = sqlServer.Database;
            txtUser.Text = sqlServer.User;
        }

        private void chkServeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServeur.Checked)
                TypeServeur.Instance.MyServerType = ServerType.MySQL;
            else
                TypeServeur.Instance.MyServerType = ServerType.SQLServer;
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            
            if (txtPwd.Text.Trim().Equals("IsigP@ss"))
            {
                pnLogin.Visible = false;
                lblPwd.Visible = false;
                txtPwd.Visible = false;
                cmdValidate.Visible = false;
                cmdSave.Visible = true;

                chkFichier.Visible = true;
                gpFile.Visible = true;

                LoadValues();
            }
            else
            {
                MessageBox.Show("Veuillez saisir un mot de passe valide svp !!!", "Accès aux préférences BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPwd.Text.Trim().Equals("IsigP@ss"))
                {
                    pnLogin.Visible = false;
                    lblPwd.Visible = false;
                    txtPwd.Visible = false;
                    cmdValidate.Visible = false;
                    cmdSave.Visible = true;

                    chkFichier.Visible = true;
                    gpFile.Visible = true;

                    LoadValues();
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un mot de passe valide svp !!!", "Accès aux préférences BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtMotPasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmdSave_Click(sender, e);
            }
        }

        private void lblLoadPath_MouseEnter(object sender, EventArgs e)
        {
            lblLoadPath.Cursor = Cursors.Hand;
            lblLoadPath.BackColor = System.Drawing.Color.Wheat;
        }

        private void chkFichier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFichier.Checked)
            {
                temps1.Enabled = true;
                isFile = true;
            }
            else
            {
                temps2.Enabled = true;
                isFile = false;
            }
        }

        private void temps1_Tick(object sender, EventArgs e)
        {
            this.Height = this.Height + 13;
            if (this.Height >= 299)
                temps1.Enabled = false;
        }

        private void temps2_Tick(object sender, EventArgs e)
        {
            this.Height = this.Height - 13;
            if (this.Height <= 221)
                temps2.Enabled = false;
        }

        private void lblLoadPath_MouseLeave(object sender, EventArgs e)
        {
            lblLoadPath.BackColor = System.Drawing.Color.Azure;
        }

        private void lblLoadPath_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultat = dlgOpen.ShowDialog();

                if (resultat == DialogResult.OK)
                {
                    if (System.IO.File.Exists(dlgOpen.FileName))
                    {
                        Utilitaires.Instance.Path = dlgOpen.FileName.Trim();
                        SynchroniseStudentsGUI.Properties.Settings.Default.FileName = dlgOpen.SafeFileName;
                    }

                    txtPath.Text = Utilitaires.Instance.Path; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez choisir un fichier valide svp !!!, " + ex.Message, "Sélection fichier", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
                lblViewContentFile.Enabled = false;
            else
                lblViewContentFile.Enabled = true;
        }

        private void lblViewContentFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SynchroniseStudentsGUI.Properties.Settings.Default.FileName = GetFileName(txtPath.Text);

            ContentFile frm = new ContentFile();           
            frm.Show();
        }

        private void Preference_Shown(object sender, EventArgs e)
        {
            txtPwd.Focus();
        }
    }
}
