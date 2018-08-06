
using System.Collections.Generic;
using System.Web;

namespace Grockart.STORAGE
{
    public class SessionProxy : IStorage
    {
        private static readonly SessionProxy session = new SessionProxy();

        public static SessionProxy Instance()
        {
            return session;
        }

        public object GetValue(string keyname)
        {
            if (HasKey(keyname))
            {
                return HttpContext.Current.Session[keyname];
            }
            return null;
        }

        public bool HasKey(string keyname)
        {
            if (HttpContext.Current.Session[keyname] != null)
            {
                return true;
            }

            return false;
        }

        public void SetValue(string key, object value, System.DateTime? time)
        {
            HttpContext.Current.Session[key] = value;
        }

        public void RemoveKey(string key)
        {
            if (HasKey(key))
            {
                HttpContext.Current.Session[key] = null;
            }
        }

        public string[] GetAllKeys()
        {
            List<string> keys = new List<string>();

            foreach (string S in HttpContext.Current.Session.Keys)
            {
                keys.Add(S);
            }
            return keys.ToArray();
        }
    }
}