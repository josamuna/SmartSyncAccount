using System;
using System.IO;

namespace ManageUtilities
{
    internal class UseDirectory
    {
        private UseDirectory()
        {
        }

        private static UseDirectory _instance;

        internal static UseDirectory Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new UseDirectory();
                return UseDirectory._instance; 
            }
        }

        internal string UpdateCreateDirectory(string masterDirectory, string nomRepertoire)
        {
            //ParametersProgramms
            string cheminAccesRepertoire = "";
            //Recuperation du nom du chemin d'acces du repertoire ProgramData de windows
            string programeDataFolder = Environment.GetEnvironmentVariables()["ALLUSERSPROFILE"].ToString();
            DirectoryInfo directory = null;
            if(string.IsNullOrEmpty(masterDirectory))
                directory = new DirectoryInfo(programeDataFolder + @"\" + nomRepertoire);
            else
                directory = new DirectoryInfo(programeDataFolder + @"\" + masterDirectory + @"\" + nomRepertoire);
            if (!directory.Exists)
            {
                //Creation du repertoire
                directory.Create();
                cheminAccesRepertoire = directory.FullName;
            }
            else
            {
                //Dossier existant
                cheminAccesRepertoire = directory.FullName;
            }

            return cheminAccesRepertoire;
        }
    }
}
