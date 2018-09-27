using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ManageUtilities
{
    public class ImplementChiffer:IChiffer
    {
        private ImplementChiffer()
        {
        }

        private static ImplementChiffer instance;

        /// <summary>
        /// Allow to use public members of class.
        /// </summary>
        public static ImplementChiffer Instance
        {
            get 
            {
                if (instance == null)
                    instance = new ImplementChiffer();
                return instance; 
            }
        }

        private static int getSaltSize(byte[] keyByte)
        {
            var key = new Rfc2898DeriveBytes(keyByte, keyByte, 1000);

            byte[] bt = key.GetBytes(2);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bt.Length; i++)
            {
                sb.Append(Convert.ToInt32(bt[i]).ToString());
            }

            int saltSize = 0;
            string str = sb.ToString();

            foreach (char car in str)
            {
                int i = Convert.ToInt32(car.ToString());
                saltSize = saltSize + i;
            }

            return saltSize;
        }

        private static byte[] getRandomBytes(int taille)
        {
            byte[] btReturn = new byte[taille];
            RNGCryptoServiceProvider.Create().GetBytes(btReturn);
            return btReturn;
        }

        //Chiffrement proprement dit avec AES
        private static byte[] AES_Encrypt(byte[] bytesToEncrypt, byte[] keyBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = keyBytes;

            //On do le chiffrement AES
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    //Taille de la cle AES
                    AES.KeySize = 256;

                    //Taille du bloc AES pour le chiffrement
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);

                    //On considere une taille de 32 caracteres en AES256 et un bloc de 16 caracteres
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    //Mode AES
                    AES.Mode = CipherMode.CBC;

                    //Ecriture dans le MemoryStream
                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        //Dechiffrement proprement dit avec AES
        private static byte[] AES_Decrypt(byte[] bytesToDecrypte, byte[] keyBytes)
        {
            byte[] decryptedBytes = null;

            byte[] saltBytes = keyBytes;

            //On do le dechiffrement AES
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    //Taille de la cle AES
                    AES.KeySize = 256;

                    //Taille du bloc AES pour le chiffrement
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);

                    //On considere une taille de 32 caracteres en AES256 et un bloc de 16 caracteres
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    //Mode AES
                    AES.Mode = CipherMode.CBC;

                    //Recuperation du MemoryStream 
                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToDecrypte, 0, bytesToDecrypte.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        #region IChiffer Members

        /// <summary>
        /// Allow to perform AES Cipher.
        /// </summary>
        /// <param name="chaine">String to cipher</param>
        /// <param name="key">String password used as key</param>
        /// <returns>Cipher string</returns>
        public string Cipher(string chaine, string key)
        {
            if (string.IsNullOrEmpty(key)) throw new Exception("Veuillez spécifier une clé valide svp !!!");
            else if (string.IsNullOrEmpty(chaine)) throw new Exception("Veuillez spécifier la valeure à chiffrer svp !!!");

            //Tableau des bytes contenant le resultat crypte
            byte[] crypteByte = null;

            //On place le texte a chiffrer dans un tableau d'octets
            byte[] crypteText = Encoding.UTF8.GetBytes(chaine);

            //On place la cle de chiffrement dans un tableau d'octet
            //Et on le hashe avec SHA256
            byte[] crypteKey = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(key));

            //Recuperation du salt size
            int saltSize = getSaltSize(crypteKey);

            //On place le salt dans un tableau des bytes
            byte[] salt = getRandomBytes(saltSize);

            // Ajout des bytes du salt au bytes originaux
            byte[] bytesToBeEncrypted = new byte[salt.Length + crypteText.Length];
            for (int i = 0; i < salt.Length; i++)
            {
                bytesToBeEncrypted[i] = salt[i];
            }
            for (int i = 0; i < crypteText.Length; i++)
            {
                bytesToBeEncrypted[i + salt.Length] = crypteText[i];
            }

            crypteByte = AES_Encrypt(bytesToBeEncrypted, crypteKey);

            return Convert.ToBase64String(crypteByte);
        }

        /// <summary>
        /// Allow to perform AES decipher.
        /// </summary>
        /// <param name="chaine">String to decipher</param>
        /// <param name="key">String used as a cipher key</param>
        /// <returns>Decipher string</returns>
        public string Decipher(string chaine, string key)
        {
            if (string.IsNullOrEmpty(key)) throw new Exception("Veuillez spécifier une clé valide svp !!!");
            else if (string.IsNullOrEmpty(chaine)) throw new Exception("Veuillez spécifier la valeure à déchiffrer svp !!!");

            //On place le texte a dechiffrer dans un tableau d'octets
            byte[] crypteText = Convert.FromBase64String(chaine);

            //On place la cle de chiffrement dans un tableau d'octet
            //Et on le hashe avec SHA256
            byte[] crypteKey = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(key));

            byte[] decryptedBytes = AES_Decrypt(crypteText, crypteKey);

            //Recuperation de la taille du salt
            int saltSize = getSaltSize(crypteKey);

            //Suppression des bytes ajoutes pour retrouver la taille des bytes originaux
            byte[] originalBytes = new byte[decryptedBytes.Length - saltSize];

            for (int i = saltSize; i < decryptedBytes.Length; i++)
            {
                originalBytes[i - saltSize] = decryptedBytes[i];
            }

            return Encoding.UTF8.GetString(originalBytes);
        }

        #endregion
    }
}
