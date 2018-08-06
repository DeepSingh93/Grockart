using Grockart.LOGGER;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Grockart.CRYPTOGRAPHY
{
    public class SHA256 : IHash
    {
        private static readonly SHA256 crypt = new SHA256();
        public static SHA256 Instance()
        {
            return crypt;
        }

        public string hash(string input)
        {
            try
            {
                var crypt = new SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                return null;
            }


        }

        // source : https://stackoverflow.com/a/1344255
        public string GetUniqueKey(int maxSize)
        {
            try
            {
                char[] chars = new char[62];
                chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                byte[] data = new byte[1];
                using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                {
                    crypto.GetNonZeroBytes(data);
                    data = new byte[maxSize];
                    crypto.GetNonZeroBytes(data);
                }
                StringBuilder result = new StringBuilder(maxSize);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                return null;
            }


        }
    }
}
