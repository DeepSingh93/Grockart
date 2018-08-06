
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Grockart.DATALAYER;
using Grockart.LOGGER;

namespace Grockart.CRYPTOGRAPHY
{
    public class AES256 : IEncrypt
    {
        private string IV;
        private string Key;
        private static readonly AES256 aes256 = new AES256();

        public static AES256 Instance()
        {
            return aes256;
        }

        public string Encrypt(string plaintext)
        {
            try
            {
                // get the IV and key from database
                // source : https://gist.github.com/haeky/5797333
                RijndaelManaged aesEncryption = new RijndaelManaged
                {
                    KeySize = 256,
                    BlockSize = 128,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    IV = Convert.FromBase64String(IV),
                    Key = Convert.FromBase64String(Key)
                };
                byte[] plainText = ASCIIEncoding.UTF8.GetBytes(plaintext);
                ICryptoTransform crypto = aesEncryption.CreateEncryptor();
                byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
                return Convert.ToBase64String(cipherText);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }


        }

        public string Decrypt(string encryptedText)
        {
            try
            {
                RijndaelManaged aesEncryption = new RijndaelManaged
                {
                    KeySize = 256,
                    BlockSize = 128,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    IV = Convert.FromBase64String(IV),
                    Key = Convert.FromBase64String(Key)
                };
                ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length);
                return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }



        }

        public void GetKeyFromDB(ICommands cmd, string query, System.Data.CommandType commandType)
        {
            try
            {
                List<string> ivkey = new List<string>();
                ICommands command = cmd;
                System.Data.DataSet output = command.ExecuteQuery(query, commandType, null);

                // table[0].rows[0][0] should contain an IV
                // table[0].rows[0][1] should contain a key
                IV = output.Tables[0].Rows[0][0].ToString().Replace('-', '+').Replace('_', '/');
                Key = output.Tables[0].Rows[0][1].ToString().Replace('-', '+').Replace('_', '/');
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }

        }
        public string GetIV()
        {
            return IV;
        }
        public string GetKey()
        {
            return Key;
        }
        public void SetIV(string IV)
        {
            this.IV = IV;
        }

        public void SetKey(string Key)
        {
            this.Key = Key;
        }
        public void GenerateKey()
        {
            try
            {
                RijndaelManaged aesEncryption = new RijndaelManaged
                {
                    KeySize = 256,
                    BlockSize = 128,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                aesEncryption.GenerateIV();
                aesEncryption.GenerateKey();

                // get the iv and key
                IV = Convert.ToBase64String(aesEncryption.IV);
                Key = Convert.ToBase64String(aesEncryption.Key);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }

        }


    }

}
