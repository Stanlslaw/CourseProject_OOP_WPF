using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1;

public class RSAEncryption
{ 
    public static string publicKey;
    public static string privateKey;

    public static string Encrypt(string message, string publicKey)
    {
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(message);

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
            return Convert.ToBase64String(encryptedData);
        }
    }

    public static string Decrypt(string encryptedMessage, string privateKey)
    {
        byte[] encryptedData = Convert.FromBase64String(encryptedMessage);

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(encryptedData, true);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}