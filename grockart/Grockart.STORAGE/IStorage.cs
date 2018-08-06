namespace Grockart.STORAGE
{
    public interface IStorage
    {
        object GetValue(string keyname);
        void SetValue(string key, object value, System.DateTime? expiryDate);
        bool HasKey(string input);
        void RemoveKey(string key);
        string[] GetAllKeys();
    }
}