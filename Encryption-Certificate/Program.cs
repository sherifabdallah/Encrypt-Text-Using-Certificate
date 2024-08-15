using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string certPassword = "P@ssw0rd";
        string certPath = "certificate.pfx";

        // Load the certificate from the file
        var cert = new X509Certificate2(certPath, certPassword);

        // Encrypt
        string originalText = "ORIGINAL TEXT";
        byte[] encryptedData = EncryptData(originalText, cert);
        Console.WriteLine("Encrypted Data: " + Convert.ToBase64String(encryptedData));

        // Decrypt
        string decryptedText = DecryptData(encryptedData, cert);
        Console.WriteLine("Decrypted Data: " + decryptedText);
    }

    

    public static byte[] EncryptData(string plainText, X509Certificate2 cert)
    {
        using (RSA rsa = cert.GetRSAPublicKey())
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            return rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);
        }
    }

    public static string DecryptData(byte[] cipherText, X509Certificate2 cert)
    {
        using (RSA rsa = cert.GetRSAPrivateKey())
        {
            byte[] decryptedData = rsa.Decrypt(cipherText, RSAEncryptionPadding.OaepSHA256);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
