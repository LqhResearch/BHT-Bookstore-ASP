using System;

namespace BHT_Bookstore_ASP_NET
{
    public class Encryption
    {
        [Obsolete]
        public static string EncodeSHA1(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "SHA1");
        }
    }
}