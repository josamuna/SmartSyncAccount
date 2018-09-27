using System;
using System.Collections.Generic;
using System.Data;
using ManageConnexion;
using ManageUtilities;

namespace SynchroniseStudentsLIB
{
    public class ImplementActionDB:IActionDB
    {
        public ImplementActionDB()
        {
        }

        private string directoryMaster = "SynchroniseStudentsAccount";
        private const string FileLog = "SynchroniseStudentsAccountLogFile";
        private const string DirectoryUtilLog = "Log";
        private const string FilePathFile = "UserPath.txt";
        private const string DirectoryUtilConn = "ConnectionString";

        #region IActionDB Members

        public void Execute(List<Queries> lstQueries, ServerType serveurType)
        {
            IDbTransaction transaction = null, transaction1 = null;

            try
            {
                foreach (IDbConnection connectDB in ImplementConnection.Instance.Conns)
                {
                    if (connectDB.State != ConnectionState.Open)
                        connectDB.Open();
                }

                switch(serveurType)
                {
                    case ServerType.SQLServer:
                    {
                        //Indice 1 Pour connexion MySQL et 0 pour SQLServer
                        transaction = ImplementConnection.Instance.Conns[1].BeginTransaction(IsolationLevel.Serializable);
                        transaction1 = ImplementConnection.Instance.Conns[0].BeginTransaction(IsolationLevel.Serializable);
                        break;
                    }
                    case ServerType.MySQL:
                    {
                        transaction = ImplementConnection.Instance.Conns[0].BeginTransaction(IsolationLevel.Serializable);
                        transaction1 = ImplementConnection.Instance.Conns[1].BeginTransaction(IsolationLevel.Serializable);
                        break;
                    }
                }

                //Insertion des records
                foreach (Queries req in lstQueries)
                {
                    IDbCommand cmd = null;
                    //Execution des requetes dans la bloucle
                    if (serveurType.Equals(ServerType.SQLServer))
                        cmd = ImplementConnection.Instance.Conns[1].CreateCommand();
                    else
                        cmd = ImplementConnection.Instance.Conns[0].CreateCommand();

                    cmd.CommandText = req.Requete;
                    cmd.Transaction = transaction;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                //Suppression des tous les records inseres
                foreach (Queries req in lstQueries)
                {
                    IDbCommand cmd = null;
                    //Execution des requetes dans la bloucle
                    if (serveurType.Equals(ServerType.SQLServer))
                        cmd = ImplementConnection.Instance.Conns[0].CreateCommand();
                    else
                        cmd = ImplementConnection.Instance.Conns[1].CreateCommand();

                    cmd.CommandText = "delete from tmp_query where id=@id";
                    IDbDataParameter param = cmd.CreateParameter();
                    param.ParameterName = "@id";
                    param.Value = req.Id;
                    cmd.Parameters.Add(param);
                    
                    cmd.Transaction = transaction1;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                transaction.Commit();
                transaction1.Commit();
                transaction.Dispose();
                transaction1.Dispose();

                //Enregistrement dans le fichier Log
                if (serveurType.Equals(ServerType.SQLServer))
                    ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Enregistrement comptes SQL Server => MySQL avec succès", DirectoryUtilLog, FileLog);
                else
                    ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Enregistrement comptes MySQL => SQL Server avec succès", DirectoryUtilLog, FileLog);
            }
            catch (Exception ex)
            {
                if (transaction != null || transaction1 != null)
                {
                    transaction.Rollback();
                    transaction1.Rollback();

                    //Enregistrement dans le fichier Log
                    if (serveurType.Equals(ServerType.SQLServer))
                        ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec de l'insertion des comptes étudiant-SQL Server : " + ex.Message, DirectoryUtilLog, FileLog);
                    else
                        ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec de l'insertion des comptes étudiant-MySQL : " + ex.Message, DirectoryUtilLog, FileLog);
                }
            }
            finally
            {
                foreach (IDbConnection connectDB in ImplementConnection.Instance.Conns)
                {
                    if (connectDB.State != ConnectionState.Closed)
                        connectDB.Close();
                }
            }
        }

        public List<Queries> LoadRecord(ServerType serveurType)
        {
            List<Queries> lstQueries = new List<Queries>();

            foreach (IDbConnection connectDB in ImplementConnection.Instance.Conns)
            {
                if (connectDB.State != ConnectionState.Open)
                    connectDB.Open();
            }

            IDbCommand cmd = null;

            //Indice 1 Pour connexion MySQL et 0 pour SQLServer
            if (serveurType.Equals(ServerType.SQLServer))
                cmd = ImplementConnection.Instance.Conns[0].CreateCommand();
            else
                cmd = ImplementConnection.Instance.Conns[1].CreateCommand();

            cmd.CommandText = "select id,requete from tmp_query";
            IDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Queries req = new Queries();
                req.Id = Convert.ToInt32(rd["id"]);
                req.Requete = Convert.ToString(rd["requete"]);
                lstQueries.Add(req);
            }

            rd.Dispose();
            cmd.Dispose();

            return lstQueries;
        }

        public int CoutRecord(ServerType serveurType)
        {
            int countQueries = 0;

            foreach (IDbConnection connectDB in ImplementConnection.Instance.Conns)
            {
                if (connectDB.State != ConnectionState.Open)
                    connectDB.Open();
            }

            IDbCommand cmd = null;

            //Indice 1 Pour connexion MySQL et 0 pour SQLServer
            if (serveurType.Equals(ServerType.SQLServer))
                cmd = ImplementConnection.Instance.Conns[0].CreateCommand();
            else
                cmd = ImplementConnection.Instance.Conns[1].CreateCommand();

            cmd.CommandText = "select count(id) as nbrRec from tmp_query";
            IDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                countQueries = Convert.ToInt32(rd["nbrRec"]);
            }

            rd.Dispose();
            cmd.Dispose();
            return countQueries;
        }

        public int Execute(string strQuery, ServerType serveurType)
        {
            int nbRecord = 0;
            IDbTransaction transaction = null;
            System.IO.FileInfo fileInfo = null;

            try
            {
                if (ImplementConnection.Instance.Conn.State != ConnectionState.Open)
                    ImplementConnection.Instance.Conn.Open();

                string strPath = ImplementUtilities.Instance.LoadParameters(directoryMaster, DirectoryUtilConn, FilePathFile);
                transaction = ImplementConnection.Instance.Conn.BeginTransaction(IsolationLevel.Serializable);

                //On set le fichier
                fileInfo = new System.IO.FileInfo(strPath);

                //Changement attribut du fichier pour etre en lecture seul - Eviter d'ajouter contenu pendant execution query
                fileInfo.IsReadOnly = true;

                //connexion MySQL pour inserer les requetes venant de SQLServer est enregistrees dans le fichier
                nbRecord = DoExecuteQueryFile(strQuery, nbRecord, transaction);

                //On rend le fichier accessible en lecture-ecriture
                fileInfo.IsReadOnly = false;

                //Vider le fichier de son contenu
                switch (fileInfo.Attributes)
                {
                    case System.IO.FileAttributes.Normal:
                        System.IO.File.WriteAllText(strPath, string.Empty);
                        break;
                    case System.IO.FileAttributes.Hidden:
                        fileInfo.Attributes = System.IO.FileAttributes.Normal;
                        System.IO.File.WriteAllText(strPath, string.Empty);
                        break;
                    default:
                        fileInfo.Attributes = System.IO.FileAttributes.Normal;
                        System.IO.File.WriteAllText(strPath, string.Empty);
                        break;
                }

                fileInfo.Attributes = System.IO.FileAttributes.Hidden;
                //On rend le fichier inaccessible en lecture-ecriture
                fileInfo.IsReadOnly = true;

                switch (serveurType)
                {
                    case ServerType.SQLServer:
                    {
                        //Enregistrement dans le fichier Log
                        if (nbRecord > 0)
                            ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Enregistrement comptes MySQL => SQL Server avec succès", DirectoryUtilLog, FileLog);
                        break;
                    }
                    case ServerType.MySQL:
                    {
                        //Enregistrement dans le fichier Log
                        if(nbRecord > 0)
                            ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Enregistrement comptes SQL Server => MySQL avec succès", DirectoryUtilLog, FileLog);                           
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                fileInfo.Attributes = System.IO.FileAttributes.Hidden;
                //On rend le fichier inaccessible en lecture-ecriture
                fileInfo.IsReadOnly = true;

                if (transaction != null)
                {
                    transaction.Rollback();

                    //Enregistrement dans le fichier Log
                    if (serveurType.Equals(ServerType.SQLServer))
                        ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec de l'insertion des comptes étudiant-SQL Server : " + ex.Message, DirectoryUtilLog, FileLog);
                    else
                        ImplementLog.Instance.PutLogMessage(directoryMaster, DateTime.Now + " : Echec de l'insertion des comptes étudiant-MySQL : " + ex.Message, DirectoryUtilLog, FileLog);
                }
            }
            return nbRecord;
        }

        private static int DoExecuteQueryFile(string strQuery, int nbRecord, IDbTransaction transaction)
        {
            IDbCommand cmd = ImplementConnection.Instance.Conn.CreateCommand();
            cmd.CommandText = strQuery;
            cmd.Transaction = transaction;
            nbRecord = cmd.ExecuteNonQuery();
            transaction.Commit();
            return nbRecord;
        }

        #endregion
    }
}
