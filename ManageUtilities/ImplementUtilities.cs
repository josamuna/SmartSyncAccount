using System;
using System.IO;
using System.Collections.Generic;

namespace ManageUtilities
{
    public class ImplementUtilities:IUtilities
    {

        private ImplementUtilities()
        {
        }

        private static ImplementUtilities _instance;

        /// <summary>
        /// Allow to use public members of class.
        /// </summary>
        public static ImplementUtilities Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new ImplementUtilities();
                return ImplementUtilities._instance; 
            }
        }

        #region IUtilities Members

        /// <summary>
        /// Allow to save some parameters (Like Database, etc.) in a custom file to the specified Directory and filename.
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.
        /// <param name="formattedString">String formatted to be save</param>
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        /// <param name="clearPasswordChifferKey">Array contains respectively user password and cipher key</param>
        public void SaveParameters(string masterDirectory, string formattedString, string directoryName, string fileName)
        {
            if (string.IsNullOrEmpty(formattedString))
                throw new Exception("La chaîne des caractères à formatter ne peut être nulle");
            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultUtilitiesFile_Manage";
            if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultUtilitiesDirectory_Manage";

            using (System.IO.StreamWriter sr = new StreamWriter(UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName, false))
            {
                sr.Write(formattedString);
                sr.Flush();
                sr.Close();
            }
        }

        public void SaveParameters(string formattedString, string path, string cipherKey, bool cipher)
        {
            if (string.IsNullOrEmpty(formattedString))
                throw new Exception("La chaîne des caractères à formatter ne peut être nulle");
            if (string.IsNullOrEmpty(path))
                throw new Exception("Le chemin d'accès du fichier ne peut être nul");

            //On commence par verifier si le fichier est caché ou non
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);

            if (fileInfo.Attributes != System.IO.FileAttributes.Normal)
            {
                //On change les attributs du fichier en mode normal
                fileInfo.Attributes = System.IO.FileAttributes.Normal;
                //On rend le fichier accessible en lecture-ecriture
                fileInfo.IsReadOnly = false;

                using (System.IO.StreamWriter sr = new StreamWriter(path, false))
                {
                    if (cipher)
                    {
                        sr.Write(ImplementChiffer.Instance.Cipher(formattedString, cipherKey));
                        sr.Flush();
                        sr.Close();
                    }
                    else
                    {
                        sr.Write(formattedString);
                        sr.Flush();
                        sr.Close();
                    }

                    //Apres toutes les operations, cacher de nouveau le fichier
                    fileInfo.Attributes = System.IO.FileAttributes.Hidden;
                    //On rend le fichier inaccessible en lecture-ecriture
                    fileInfo.IsReadOnly = true;
                }
            }
            else
            {
                using (System.IO.StreamWriter sr = new StreamWriter(path, false))
                {
                    if (cipher)
                    {
                        sr.Write(ImplementChiffer.Instance.Cipher(formattedString, cipherKey));
                        sr.Flush();
                        sr.Close();
                    }
                    else
                    {
                        sr.Write(formattedString);
                        sr.Flush();
                        sr.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Allow to load some parameters (Like Database, etc.) in a custom file from the specified Directory and filename.
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.</param>
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        /// <returns>String represent saved parametes</returns>
        public string LoadParameters(string masterDirectory, string directoryName, string fileName)
        {
            string strParameter = "";

            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultLogFile_Manage";
            if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultLodDirectory_Manage";

            using (StreamReader sr = new StreamReader(UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName))
            {
                string t = sr.ReadToEnd();
                strParameter = t;
            }

            return strParameter;
        }

        public string LoadParameters(string pathFile, string decipherKey, bool cipherContent)
        {
            string strParameter = "";

            if (string.IsNullOrEmpty(pathFile))
                throw new Exception("Veuillez spécifier un chemin d'accès valide svp");

            using (StreamReader sr = new StreamReader(pathFile))
            {
                if (cipherContent)
                {
                    string t = sr.ReadToEnd();
                    strParameter = ImplementChiffer.Instance.Decipher(t, decipherKey);
                }
                else
                {
                    string t = sr.ReadToEnd();
                    strParameter = t;
                }
            }

            return strParameter;
        }

        /// <summary>
        /// Allow to load Database parameters in a custom file from the specified Directory and filename.
        /// It load that like this : Server name, Database name, User DB, AES cipher Password and Port number.
        /// Cipher key can'nt be null and the default Split character is the new line (\n) if is set to null value.
        /// For that method work properly, you must use that format when save file :
        /// Server=Value_Server
        /// Database=Value_Database
        /// User=Value_User
        /// Password=Value_Cipher_Password
        /// Port=Value_PortNumber
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        /// <param name="splitChar">Char represent the Split character for items in connection string</param>
        /// <param name="chifferKey">String represent the cipher key</param>
        /// <returns>List of items</returns>
        public List<string> LoadDatabaseParameters(string masterDirectory, string directoryName, string fileName, char? splitChar, string cipherKey)
        {
            List<string> allItems = new List<string>();

            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultUtilitiesFile_Manage";
            if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultUtilitiesDirectory_Manage";
            if (string.IsNullOrEmpty(splitChar.ToString()))
                splitChar = '\n';
            if (string.IsNullOrEmpty(cipherKey))
                throw new Exception("Please provide a valide cipher key");

            using (StreamReader sr = new StreamReader(UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName))
            {
                //string chaine = sr.ReadToEnd();
                string[] sql = sr.ReadToEnd().Split(Convert.ToChar(splitChar));

                for (int i = 0; i < sql.Length; i++)
                {
                    switch (i)
                    {
                        case 0: allItems.Add(sql[0].Split('=')[1]);//Server
                            break;
                        case 1: allItems.Add(sql[1].Split('=')[1]);//Database
                            break;
                        case 2: allItems.Add(sql[2].Split('=')[1]);//DatabaseUser
                            break;
                        case 3:
                        {
                            //Database Password
                            string[] tab = sql[3].Split('=');
                            int indexTab = 0;
                            System.Text.StringBuilder build = new System.Text.StringBuilder();

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

                            allItems.Add(ImplementChiffer.Instance.Decipher(build.ToString(), cipherKey));
                            break;
                        }
                        case 4: allItems.Add(sql[4].Split('=')[1]);//Port Number
                        break;
                    }
                }
                return allItems;
            }
        }

        /// <summary>
        /// Allow to load Database path in a custom file from the specified Directory and filename.
        /// Cipher key can'nt be null
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.
        /// <param name="directoryName">Directory used to be save database path</param>
        /// <param name="fileName">File name that contains cipher path</param>
        /// <param name="cipherKey">String represent the cipher key</param>
        /// <returns>String that represent the Path</returns>
        public string LoadDatabaseParameters(string masterDirectory, string directoryName, string fileName, string cipherKey)
        {
            string strPath = "";

            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultUtilitiesFile_Manage";
            if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultUtilitiesDirectory_Manage";
            if (string.IsNullOrEmpty(cipherKey))
                throw new Exception("Please provide a valide cipher key");

            using (StreamReader sr = new StreamReader(UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName))
            {
                string t = ImplementChiffer.Instance.Decipher(sr.ReadToEnd(), cipherKey);
                strPath = t;
            }

            return strPath;
        }

        #endregion
    }
}
