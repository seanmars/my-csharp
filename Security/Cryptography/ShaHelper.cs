using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Security.Cryptography
{
    public class ShaHelper
    {
        public static string GenerateSHA256String(Stream stream)
        {
            using(var sha = SHA256Managed.Create())
            {
                var hashValue = sha.ComputeHash(stream);
                return GetStringFromHash(hashValue);
            }
        }

        public static string GenerateSHA256String(object inputObject)
        {
            var context = JsonConvert.SerializeObject(inputObject);
            return GenerateSHA256String(context);
        }

        public static string GenerateSHA256String(string inputString)
        {
            using(var sha = SHA256Managed.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hash = sha.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
        }

        public static string GenerateSHA512String(Stream stream)
        {
            using(var sha = SHA512Managed.Create())
            {
                var hashValue = sha.ComputeHash(stream);
                return GetStringFromHash(hashValue);
            }
        }

        public static string GenerateSHA512String(object inputObject)
        {
            var context = JsonConvert.SerializeObject(inputObject);
            return GenerateSHA512String(context);
        }

        public static string GenerateSHA512String(string inputString)
        {
            using(var sha = SHA512Managed.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hash = sha.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
        }

        private static string GetStringFromHash(byte[] hash)
        {
            var result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
