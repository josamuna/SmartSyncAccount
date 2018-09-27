using System;

namespace ManageUtilities
{
    /// <summary>
    /// Used to manage cipher and decipher.
    /// </summary>
    public interface IChiffer
    {
        /// <summary>
        /// Allow to cipher a string.
        /// </summary>
        /// <param name="chaine">String to cipher</param>
        /// <param name="key">String password used as key</param>
        /// <returns>Cipher string</returns>
        string Cipher(string chaine, string key);

        /// <summary>
        /// Allow to decipher a string.
        /// </summary>
        /// <param name="chaine">String to decipher</param>
        /// <param name="key">String password used as key</param>
        /// <returns>Decipher string</returns>
        string Decipher(string chaine, string key);
    }
}
