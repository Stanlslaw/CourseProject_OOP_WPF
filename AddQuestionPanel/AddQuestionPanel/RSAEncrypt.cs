using System;
using System.Security.Cryptography;
using System.Text;

namespace AddQuestionPanel;

public class RSAEncryption
{ 
    private static readonly string publicKey=
        "<RSAKeyValue><Modulus>1xY/19gJE46QyqHTllS7XIGrb+DgJoRVnLH" +
        "rbzgEyd/DljEBfKON5NHH48B+QYsA6DPcbJwOsDpa2Zf0U56FulSeMPmx" +
        "l7J21Qwmfw8jRkSkEoJ5jumSeuwdCF/MEPg9eVoKik2J6fPOXHPrzPinF" +
        "sUSva0MhlCdf6TzLHOfHId1wd+5OEj7SSuFob1c8oh61Pxw1XZUhtoZvi" +
        "I4gpk4QeuK5FL4eW4CvleH9X2ZhueJs+L79rsf4GV2Ubcmf/2mdVjqFQxZ" +
        "g8M1iqkGvMZpiJEGndbEorDd3MQ/IDskcb9omnTqvMGERkkWrsCez6L6Y7" +
        "G12PmJQ6Xy4cauDay7PQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

    public static string Encrypt(string message)
    {
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(message);

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
            return Convert.ToBase64String(encryptedData);
        }
    }
    
}