using System;
using System.Linq;
using System.Text;

namespace ManageUtilities
{
    /// <summary>
    /// Used to saved some Parameters Files.
    /// </summary>
    public interface IUtilities
    {
        /// <summary>
        /// Allow to save some parameters (Like Database, etc.) in a custom file to the specified Directory and filename.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="formattedString">String formatted to be save</param>
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        void SaveParameters(string masterDirectory, string formattedString, string directoryName, string fileName);

        /// <summary>
        /// Allow to load some parameters (Like Database, etc.) in a custom file from the specified Directory and filename.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        /// <returns>String represent saved parametes</returns>
        string LoadParameters(string masterDirectory, string directoryName, string fileName);

        /// <summary>
        /// Allow to load some parameters (Like Database, etc.) in a custom file from the specified Directory and filename.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        /// <param name="splitChar">Split char used in saved file to separate some parameters</param>
        /// <param name="cipherKey">String represent the cipher key</param>
        /// <returns>List of string that contains all parameters</returns>
        System.Collections.Generic.List<string> LoadDatabaseParameters(string masterDirectory, string directoryName, string fileName, char? splitChar, string cipherKey);

        /// <summary>
        /// Allow to load some a Database path in a custom file from the specified Directory and filename.
        /// For Access Database.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="directoryName">Directory used to be save parameters</param>
        /// <param name="fileName">File name that contains parameters to save</param>
        /// <param name="cipherKey">String represent the cipher key</param>
        /// <returns>Cipher st</returns>
        string LoadDatabaseParameters(string masterDirectory, string directoryName, string fileName, string cipherKey);
    }
}
