namespace ConsoleApp1;

public static class Program
{
    public static void Main()
    {
        RSAEncryption.GenerateKeys();
        Console.WriteLine("private"+RSAEncryption.privateKey);
        Console.WriteLine("public"+RSAEncryption.publicKey);
        File.WriteAllText("private.txt",RSAEncryption.privateKey);
        File.WriteAllText("public.txt",RSAEncryption.publicKey);
        string encrypted = RSAEncryption.Encrypt("Hello",RSAEncryption.publicKey);
        Console.WriteLine( RSAEncryption.Decrypt(encrypted,RSAEncryption.privateKey));

    }
}

