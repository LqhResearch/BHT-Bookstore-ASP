using System;

namespace WebService
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