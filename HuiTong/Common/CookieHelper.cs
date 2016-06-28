using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiTong.Common
{
    public class CookieHelper
    {
        public string keyName = string.Empty;
        public string value = string.Empty;
        public string domian = string.Empty;
        public double expires = 0;
        public Dictionary<string, string> values = new Dictionary<string, string>();

        public void Add()
        {
            HttpCookie cookie = new HttpCookie(keyName);
            if(!string.IsNullOrEmpty (value ))
            {}
            cookie.Value = value;
            HttpContext.Current.Response.Cookies.Add(cookie);
        } 
    }
}