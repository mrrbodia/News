using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace News.Business.Components
{
    public class HashDecoder
    {
        private static Random random = new Random();
        private const int MinSaltSize = 4;
        private const int MaxSaltSize = 8;
        private const int MaxLengthSalt = 32;

        public static string ComputeHash(string plainText, string saltValue)
        {
            byte[] plainTextWithSaltBytes = Encoding.Unicode.GetBytes(String.Concat(plainText, saltValue));

            MD5 hash = new MD5CryptoServiceProvider();

            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
            string hashValue = Convert.ToBase64String(hashBytes);
            return hashValue;
        }

        public static bool VerifyHash(string plainText, string hashValue, string saltValue)
        {
            string expectedHashString = ComputeHash(plainText, saltValue);
            return (hashValue == expectedHashString);
        }

        public static string GenerateHashString()
        {
            byte[] saltBytes = null;

            int saltSize = random.Next(MinSaltSize, MaxSaltSize);
            saltBytes = new byte[saltSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetNonZeroBytes(saltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return ComputeHash(salt, salt);
        }

        public static string GenarateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[MaxLengthSalt];
            random.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
