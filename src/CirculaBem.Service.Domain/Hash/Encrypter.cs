using System.Security.Cryptography;
using System.Text;

namespace CirculaBem.Service.Domain.Hash
{
    public static class Encrypter
    {
        public static string Encrypt(string field, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            byte[] plainTextBytes = Encoding.UTF8.GetBytes(field);
                            cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        }
                        return Convert.ToBase64String(ms.ToArray()) + "|" + Convert.ToBase64String(aes.IV);
                    }
                }
            }
        }

        public static string Decrypt(string field, string key)
        {
            string[] parts = field.Split('|');
            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid encrypted registration number format");
            }

            string encryptedData = parts[0];
            string ivString = parts[1];

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Convert.FromBase64String(ivString);

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(Convert.FromBase64String(encryptedData)))
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


}
