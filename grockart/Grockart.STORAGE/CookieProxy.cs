using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grockart.STORAGE
{
    public class CookieProxy : IStorage
    {
        private static readonly CookieProxy cookie = new CookieProxy();

        public static CookieProxy Instance()
        {
            return cookie;
        }

        public object GetValue(string keyname)
        {
            if (HasKey(keyname))
            {
                return HttpContext.Current.Request.Cookies[keyname].Value;
            }
            return null;
        }
        public bool HasKey(string keyname)
        {
            if(HttpContext.Current.Request.Cookies[keyname.ToString()] != null)
            {
                return true;
            }

            return false;
        }

        public void SetValue(string key, object value, DateTime? expiry)
        {
            // remove the key if there is any value associated
            RemoveKey(key);

            // now set the cookie
            HttpCookie cookie = new HttpCookie(key)
            {
                Value = value.ToString(),
                Expires = (DateTime)expiry
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void RemoveKey(string key)
        {
            if (HasKey(key))
            {
                HttpContext.Current.Request.Cookies.Remove(key);
                HttpCookie cookie = new HttpCookie(key)
                {
                    Value = null,
                    Expires = DateTime.Now.AddDays(-1)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

        }

        public string[] GetAllKeys()
        {
            return HttpContext.Current.Request.Cookies.AllKeys;
        }
    }
}