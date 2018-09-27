using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceProcess;
using System.Timers;
using ManageConnexion;
using ManageUtilities;
using SynchroniseStudentsLIB;

namespace SynchroniseStudentsAccount
{
    public partial class SyncAccount : ServiceBase
    {
        private const string directoryMaster = "SynchroniseStudentsAccount";
        private const string DirectoryUtilConn = "ConnectionString";
        private const string FileLog = "SynchroniseStudentsAccountLogFile";
        private const string DirectoryUtilLog = "Log";
        private const string DirectoryUtilOther = "Other";
        private const string FileSQLServer = "UserSQLSever";
        private const string FileMySQL = "UserMySQL";
        private const string FileServerType = "UserServerType";
        private const string FilePathFile = "UserPath.txt";

        private Timer temps = null;

        public SyncAccount()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                temps = new System.Timers.Timer();
                this.temps.Interval = 1200000;//1200000msec pour 20min
                this.temps.Elapsed += new System.Timers.ElapsedEventHandler(this.temps_Elapsed);
                this.temps.Enabled = true;

                //Type de serveur utilise pour connaitre le sens des mise a jour: De SQL Server => MySQL 
                //ou Inverse
                string str = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilOther, FileServerType).Split('=')[1].Trim();

                TypeServeur.Instance.MyServerType = str.Equals(Convert.ToString(ServerType.SQLServer)) ? ServerType.SQLServer : ServerType.MySQL;

                List<string> paramDBSQLServer = new List<string>();
                List<string> paramDBMySQL = new List<string>();

                //Initialisation chaine de connexion SQL Serve ou MySQL
                Connection connection = new Connection();

                ConnectionType connectionType = new ConnectionType();

                if (str.Equals(Convert.ToString(ServerType.SQLServer)))
                {
                    TypeServeur.Instance.MyServerType = ServerType.SQLServer;
                    paramDBSQLServer = ImplementUtilities.Instance.LoadDatabaseParameters(directoryMaster, DirectoryUtilConn, FileSQLServer, Convert.ToChar('\n'), "Jos@mP@ss");
                    LoadValuesSplit(paramDBSQLServer, connection);
                    connectionType = ConnectionType.SQLServer;
                }
                else if (str.Equals(Convert.ToString(ServerType.MySQL)))
                {
                    TypeServeur.Instance.MyServerType = ServerType.MySQL;
                    paramDBMySQL = ImplementUtilities.Instance.LoadDatabaseParameters(directoryMaster, DirectoryUtilConn, FileMySQL, Convert.ToChar('\n'), "Jos@mP@ss");
                    LoadValuesSplit(paramDBMySQL, connection);
                    connectionType = ConnectionType.MySQL;
                }

                ImplementConnection.Instance.InitialiseSingleConnection(connection, connectionType);
                ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Démarrage du service Synchronise Student Account", DirectoryUtilLog, FileLog);
            }
            catch(Exception ex)
            {
                ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec du Démarrage du service Synchronise Student Account : " + ex.Message, DirectoryUtilLog, FileLog);
            }
            finally
            {
                if (ImplementConnection.Instance.Conn.State != ConnectionState.Closed)
                    ImplementConnection.Instance.Conn.Close();
            }
        }

        private static void LoadValuesSplit(List<string> paramDB, Connection connectDB)
        {
            connectDB.Serveur = paramDB[0].ToString();
            connectDB.Database = paramDB[1].ToString();
            connectDB.User = paramDB[2].ToString();
            connectDB.Password = paramDB[3].ToString();
        }

        void temps_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //thread = new Thread(new ThreadStart(DoActionBD));
                //thread.Start();
                switch(TypeServeur.Instance.MyServerType)
                {
                    case ServerType.SQLServer:
                    {
                        //MAJ de SQL Server => MySQL
                        //Appel et execution de la query pour inserer dans la BD (MySQL)
                        IActionDB actionDBSQLServer = new ImplementActionDB();
                        DoExecute(actionDBSQLServer);
                        break;
                    }
                    case ServerType.MySQL:
                    {
                        //MAJ MySQL => SQL Server
                        //Appel et execution de la query pour inserer dans la BD (SQL Server)
                        IActionDB actionDBMySQL = new ImplementActionDB();
                        DoExecute(actionDBMySQL);
                        break;
                    }
                }

                //ImplementLog.Instance.PutLogMessage(DateTime.Now + " : En cours de traitement...", DirectoryUtilLog, FileLog);
            }
            catch (Exception ex)
            {
                ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec du traitement du service Synchronise Student Account : " + ex.Message, DirectoryUtilLog, FileLog);
            }
            finally
            {
                if (ImplementConnection.Instance.Conn.State != ConnectionState.Closed)
                    ImplementConnection.Instance.Conn.Close();
            }
        }

        private static void DoExecute(IActionDB actionDB)
        {
            //Chargement du chemin d'acces du fichier de travail contenant les requetes
            string strPath = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FilePathFile);

            //Chargement contenu du fichier de travail
            string str = ImplementUtilities.Instance.LoadParameters(strPath, null, false);

            if (!string.IsNullOrEmpty(str))
                actionDB.Execute(str, TypeServeur.Instance.MyServerType);
            else
                ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : En cours de traitement...", DirectoryUtilLog, FileLog);
        }

        protected override void OnStop()
        {
            try
            {
                temps.Enabled = false;
                ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Arrêt du service Synchronise Student Account", DirectoryUtilLog, FileLog);
            }
            catch (Exception ex)
            {
                ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec de l'arrêt du service Synchronise Student Account : " + ex.Message, DirectoryUtilLog, FileLog);
            }
            finally
            {
                if (ImplementConnection.Instance.Conn.State != ConnectionState.Closed)
                    ImplementConnection.Instance.Conn.Close();
            }
        }
    }
}

/*
 //Le fichier est du répertoire partagé en lecture seul et c'est au moment de l'enregistrement qu'il est passe en lecture-eriture

    //Recuperation du fichier par son chemin d'acces
    System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);

    //Si le fichier n'est pas normal
    if(fileInfo.Attributes != System.IO.FileAttributes.Normal)
    {
	    //On change les attributs du fichier en mode normal
	    fileInfo.Attributes = System.IO.FileAttributes.Normal;

	    //On rend le fichier accessible en lecture-ecriture
	    fileInfo.IsReadOnly = false;

	    //On y inscrit un contenu
    }

    //Après toutes les opérations, cacher de nouveau le fichier
    fileInfo.Attributes = System.IO.FileAttributes.Hidden;

    //On rend le fichier inaccessible en lecture-ecriture
    fileInfo.IsReadOnly = true;



    //Modèle de requete à utiliser tout en remplaçant: username pqr le matricule étudiant et value par son mot de passe généré
    //Le point virgule à la fin est obligatoire
    insert into radcheck(username,attribute,op,value) values('test1','Cleartext-Password',':=','test1');
*/
