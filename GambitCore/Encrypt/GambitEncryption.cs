namespace GambitCore
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class GambitEncryption
    {

        public static string HMACSHA256(string key, string body)
        {
            byte[] secretKey = StringToByteArray(key);
            HMACSHA256 hmac = new HMACSHA256(secretKey);
            hmac.Initialize();
            byte[] bytes = Encoding.UTF8.GetBytes(body);
            byte[] rawHmac = hmac.ComputeHash(bytes);
            string hexString = BitConverter.ToString(rawHmac);
            string cleanedHexString = hexString.Replace("-", string.Empty);

            return cleanedHexString;
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
