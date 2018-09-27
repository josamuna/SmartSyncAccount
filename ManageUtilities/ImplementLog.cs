using System.IO;
using System.Linq;
using System.Text;

namespace ManageUtilities
{
    public class ImplementLog:ILog
    {
        private ImplementLog()
        {
        }

        private static ImplementLog _instance;

        /// <summary>
        /// Allow to use public members of class.
        /// </summary>
        public static ImplementLog Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new ImplementLog();
                return ImplementLog._instance; 
            }
        }

        #region ILog Members

        /// <summary>
        /// Allow to read some informations from a file (LogFile) using a specified file name
        /// in a specified directory.
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.
        /// <param name="directoryName">String represent Directory name that storage the Log File</param>
        /// <param name="fileName">String represent the File Name</param>
        /// <returns>String that represent the Log Messag</returns>
        public string ShowLogMessage(string masterDirectory, string directoryName, string fileName)
        {
            StringBuilder build = new StringBuilder();

            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultLogFile_Manage";
            else if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultLodDirectory_Manage";

            using (StreamReader sr = new StreamReader(UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName))
            {
                build.Append(sr.ReadToEnd());
                sr.Close();
            }
            return build.ToString();
        }

        /// <summary>
        /// Allow to read a specific ligne in a file passed in parameter.
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.
        /// <param name="directoryName">String represent Directory name that storage the Log File</param>
        /// <param name="fileName">String represent the File Name</param>
        /// <param name="ligne">The specific line in the File</param>
        /// <returns>String that represent the Log Messag</returns>
        public string ShowLogMessage(string masterDirectory, string directoryName, string fileName, int line)
        {
            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultLogFile_Manage";
            else if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultLodDirectory_Manage";

            string path = UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName;

            return File.ReadAllLines(path).ElementAt(line); 
        }

        /// <summary>
        /// Allow to log file with some texte passed in parameter and using a custom Directory.
        /// </summary>
        /// <param name="masterDirectory">String represent the master directory for saving all configurations files for application.
        /// <param name="message">String represent message to save in a File</param>
        /// <param name="directoryName">String represent Directory name that storage the Log File</param>
        /// <param name="fileName">String represent the File Name</param>
        public void PutLogMessage(string masterDirectory, string message, string directoryName, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                fileName = "defaultLogFile_Manage";
            else if (string.IsNullOrEmpty(directoryName))
                directoryName = "defaultLodDirectory_Manage";

            using (System.IO.StreamWriter sr = new System.IO.StreamWriter(UseDirectory.Instance.UpdateCreateDirectory(masterDirectory, directoryName) + @"\" + fileName, true))
            {
                sr.WriteLine(message);
                sr.Flush();
                sr.Close();
            }
        }

        #endregion
    }
}
