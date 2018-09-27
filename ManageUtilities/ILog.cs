using System;

namespace ManageUtilities
{
    /// <summary>
    /// Used to open saved Log File.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Allow to show message log.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="directoryName">String represent Directory name that storage the Log File</param>
        /// <param name="fileName">String represent the File Name</param>
        /// <returns>String that represent the Log Message</returns>
        string ShowLogMessage(string masterDirectory, string directoryName, string fileName);

        /// <summary>
        /// Allow to show message log at a specific ligne in the file.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="directoryName">String represent Directory name that storage the Log File</param>
        /// <param name="fileName">String represent the File Name</param>
        /// <param name="ligne">The specific line in the File</param>
        /// <returns>String that represent the Log Message</returns>
        string ShowLogMessage(string masterDirectory, string directoryName, string fileName, int line);

        /// <summary>
        /// Allow to save a specifiaue string in a specific File.
        /// </summary>
        /// <param name="masterDirectory">Allow to specifie the master directory to be used for saving all configurations files for application.
        /// <param name="message">String represent message to save in a File</param>
        /// <param name="directoryName">String represent Directory name that storage the Log File</param>
        /// <param name="fileName">String represent the File Name</param>
        void PutLogMessage(string masterDirectory, string message, string directoryName, string fileName);
    }
}
