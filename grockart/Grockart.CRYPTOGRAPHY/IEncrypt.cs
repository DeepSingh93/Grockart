using Grockart.DATALAYER;

public interface IEncrypt
{
    string Encrypt(string PlainString);
    string Decrypt(string EncryptedText);
    void GenerateKey();
    void GetKeyFromDB(ICommands cmd, string query, System.Data.CommandType commandType);
    void SetKey(string Key);
    void SetIV(string IV);
    string GetIV();
    string GetKey();

}