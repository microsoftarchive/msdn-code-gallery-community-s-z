#region File Attributes

// AdminWeb  Project: VirtueBuild.Security
// File:  EncryptionService.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Security {
    #region

    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;

    #endregion

    public class EncryptionService : IEncryptionService {

        private readonly SecuritySettings _securitySettings;

        public EncryptionService()
        {
            _securitySettings = new SecuritySettings {EncryptionKey = "A9C7A8FA-BD16-445B-82BC-37730E683B10"};
        }

        public EncryptionService(SecuritySettings securitySettings)
        {
            _securitySettings = securitySettings;
        }

        #region IEncryptionService Members

        public virtual string CreateSaltKey(int size = 16)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public virtual string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat)) {
                passwordFormat = "SHA1";
            }
            string saltAndPassword = String.Concat(password, saltkey);
            string hashedPassword =
                FormsAuthentication.HashPasswordForStoringInConfigFile(
                    saltAndPassword, passwordFormat);
            return hashedPassword;
        }

        public virtual string EncryptText(string plainText, string encryptionPrivateKey = "")
        {
            if (string.IsNullOrEmpty(plainText)) {
                return plainText;
            }

            if (String.IsNullOrEmpty(encryptionPrivateKey)) {
                encryptionPrivateKey = _securitySettings.EncryptionKey;
            }

            var tDeSalg = new TripleDESCryptoServiceProvider {
                Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16)),
                IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8))
            };

            byte[] encryptedBinary = EncryptTextToMemory(plainText, tDeSalg.Key, tDeSalg.IV);
            return Convert.ToBase64String(encryptedBinary);
        }

        public virtual string DecryptText(string cipherText, string encryptionPrivateKey = "")
        {
            if (String.IsNullOrEmpty(cipherText)) {
                return cipherText;
            }

            if (String.IsNullOrEmpty(encryptionPrivateKey)) {
                encryptionPrivateKey = _securitySettings.EncryptionKey;
            }

            var tDeSalg = new TripleDESCryptoServiceProvider {
                Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16)),
                IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8))
            };

            byte[] buffer = Convert.FromBase64String(cipherText);
            return DecryptTextFromMemory(buffer, tDeSalg.Key, tDeSalg.IV);
        }

        #endregion

        #region Utilities

        private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream()) {
                using (
                    var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv),
                                              CryptoStreamMode.Write)) {
                    byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

        private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream(data)) {
                using (
                    var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv),
                                              CryptoStreamMode.Read)) {
                    var sr = new StreamReader(cs, new UnicodeEncoding());
                    return sr.ReadToEnd();
                }
            }
        }

        #endregion
    }
}