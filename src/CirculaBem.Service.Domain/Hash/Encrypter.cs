using System.Security.Cryptography;
using System.Text;

public static class Encrypter
{
    public static string Encrypt(string field, string key)
    {
        using (var aes = Aes.Create())
        {
            aes.Mode = CipherMode.ECB;
            aes.Key = Encoding.UTF8.GetBytes(key);

            using (var encryptor = aes.CreateEncryptor(aes.Key, null))
            {
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(field);
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }

    public static string Decrypt(string field, string key)
    {
        using (var aes = Aes.Create())
        {
            aes.Mode = CipherMode.ECB;
            aes.Key = Encoding.UTF8.GetBytes(key);

            using (var decryptor = aes.CreateDecryptor(aes.Key, null))
            {
                using (var ms = new MemoryStream(Convert.FromBase64String(field)))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs, Encoding.UTF8))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
