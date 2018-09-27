using System;
using System.Windows.Forms;
using ManageUtilities;

namespace SynchroniseStudentsGUI
{
    public partial class ContentFile : Form
    {
        private string directoryMaster = "SynchroniseStudentsAccount";
        private const string DirectoryUtilConn = "ConnectionString";
        private const string FilePathFile = "UserPath.txt";
        private string strPath = "";

        public ContentFile()
        {
            InitializeComponent();
        }

        private void cmdSave_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                //Enregistrement du Contenu du fichier apres l'avoir chiffrer
                ImplementUtilities.Instance.SaveParameters(rtfFile.Text, strPath, null, false);
                lblStatus.Text = "Enregistrement effectué";

                MessageBox.Show("Enregistrement effectué", "Enregistrement contenu fichier de travail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Echec d'enregistrement, " + ex.Message;
                MessageBox.Show("Echec d'enregistrement, " + ex.Message, "Enregistrement contenu fichier de travail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ContentFile_Load(object sender, EventArgs e)
        {
            try
            {
                //Chargement du chemin d'acces du fichier de travail
                strPath = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FilePathFile);

                //Chargement contenu du fichier de travail dechifre
                string str = ImplementUtilities.Instance.LoadParameters(strPath, null, false);
                rtfFile.Text = str;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Echec de chargement du contenu du fichier de travail, " + ex.Message;
                MessageBox.Show("Echec de chargement du contenu du fichier de travail, " + ex.Message, "Chargement contenu fichier de travail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
