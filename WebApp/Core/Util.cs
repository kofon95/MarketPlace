using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.Core
{
    public static class Util
    {
        static Random _random = new Random();

        public static string GetRandomString()
        {
            return MD5(DateTime.Now.Ticks + "_" + _random.Next());
        }

        public static string MD5(string text)
        {
            using (HashAlgorithm provider = new MD5CryptoServiceProvider())
            {
                var bytes = provider.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter
                    .ToString(bytes)
                    .Replace("-", "")
                    .ToLower();
            }
        }
    }
}