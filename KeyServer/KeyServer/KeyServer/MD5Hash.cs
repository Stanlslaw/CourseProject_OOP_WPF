using System.Security.Cryptography;
using System.Text;

namespace KeyServer;

public static class MD5Hash
{
    public static string ComputeMD5Hash(string text, string keyword)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] keywordBytes = Encoding.UTF8.GetBytes(keyword);

        using (MD5 md5 = MD5.Create())
        {
            byte[] combinedBytes = CombineBytes(textBytes, keywordBytes);
            byte[] hashBytes = md5.ComputeHash(combinedBytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }

    private static byte[] CombineBytes(byte[] first, byte[] second)
    {
        byte[] combined = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, combined, 0, first.Length);
        Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);
        return combined;
    }
}