using System;
using System.Runtime.Caching;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for Cache
/// </summary>
namespace Grockart.STORAGE
{
    public class CacheProxy : IStorage
    {
        private static readonly CacheProxy CacheObj = new CacheProxy();
        private static readonly MemoryCache Cache = MemoryCache.Default;

        public static CacheProxy Instance()
        {
            return CacheObj;
        }


        public string[] GetAllKeys()
        {
            List<string> keys = new List<string>();

            // retrieve application Cache enumerator
            IDictionaryEnumerator enumerator = System.Web.HttpRuntime.Cache.GetEnumerator();

            // copy all keys that currently exist in Cache
            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Key.ToString());
            }

            return keys.ToArray();

        }

        public object GetValue(string keyname)
        {
            return Cache[keyname];
        }

        public bool HasKey(string input)
        {
            if (Cache[input] == null)
            {
                return false;
            }

            return true;
        }

        public void RemoveKey(string key)
        {
            if (HasKey(key))
            {
                Cache.Remove(key);
            }

        }

        public void SetValue(string key, object value, DateTime? expiryDate = null)
        {
            CacheItemPolicy cacheItemPolicy = null;
            if (expiryDate != null)
            {
                cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = (DateTime)expiryDate
                };
            }

            if (HasKey(key))
            {
                Cache.Set(key, value, cacheItemPolicy);
            }
            else
            {
                Cache.Add(key, value, cacheItemPolicy);
            }
        }
    }
}