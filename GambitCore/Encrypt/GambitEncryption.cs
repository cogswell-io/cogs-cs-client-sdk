namespace GambitCore
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Responsible for the enctyption of a string value
    /// </summary>
    public class GambitEncryption
    {
        /// <summary>
        /// Encrypts a string in HMACSHA256 with given key
        /// </summary>
        /// <param name="key">Key for encrryption</param>
        /// <param name="body">String to be encrypted</param>
        /// <returns>HMACSHA256 encrypted string</returns>
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

        /// <summary>
        /// Converts a string to a byte array
        /// </summary>
        /// <param name="hex">String to be converted</param>
        /// <returns>Byte array representation of the input string</returns>
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
