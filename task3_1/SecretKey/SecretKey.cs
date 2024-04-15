using System.Security.Cryptography;

namespace task3_1.SecretKey;

public class SecretKey
{
    public static byte[] GenerateKey()
    {
        byte[] key = new byte[32];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            // Создание массива для хранения ключа
           

            // Генерация случайного ключа
            rng.GetBytes(key);

            // Преобразование массива байтов в строку для вывода
           
        }

        return key;
    }
}