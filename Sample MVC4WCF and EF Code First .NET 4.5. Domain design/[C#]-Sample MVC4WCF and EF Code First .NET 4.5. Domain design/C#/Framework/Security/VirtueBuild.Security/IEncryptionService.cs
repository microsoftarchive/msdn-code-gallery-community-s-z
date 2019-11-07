#region File Attributes

// AdminWeb  Project: VirtueBuild.Security
// File:  IEncryptionService.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Security {
    public interface IEncryptionService {

        string CreateSaltKey(int size);

        string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1");

        string EncryptText(string plainText, string encryptionPrivateKey = "");

        string DecryptText(string cipherText, string encryptionPrivateKey = "");

    }
}