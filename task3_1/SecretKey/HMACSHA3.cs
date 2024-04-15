using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;

namespace task3_1.SecretKey;

public class HMACSHA3
{
    public static byte[] CalculateHMACSHA3(string compMove,byte[] key)
    {
        using (HMACSHA256 hmac = new HMACSHA256(key))
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(compMove);
            return hmac.ComputeHash(messageBytes);
        }
    }

}