using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class AutokeyCipher
    {
        // Набір символів, які підтримуються
        private static readonly string SupportedChars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + 
            "abcdefghijklmnopqrstuvwxyz" + 
            "АБВГДЕЄЁЖЗІЇИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" +
            "абвгдеєёжзіїийклмнопрстуфхцчшщъыьэюя" + 
            "0123456789" + 
            " .,!?@#$%^&*()-_=+[]{}|;:'\"<>/\\`~";

        public static string Encrypt(string plaintext, string key)
        {
            StringBuilder ciphertext = new StringBuilder();
            key += plaintext;

            for (int i = 0; i < plaintext.Length; i++)
            {
                char p = plaintext[i];
                char k = key[i];

                // Перевіряємо, чи входять символи у підтримуваний набір
                if (SupportedChars.Contains(p) && SupportedChars.Contains(k))
                {
                    int pIndex = SupportedChars.IndexOf(p);
                    int kIndex = SupportedChars.IndexOf(k);

                    // Виконуємо шифрування за формулою (pIndex + kIndex) % SupportedChars.Length
                    int cIndex = (pIndex + kIndex) % SupportedChars.Length;
                    ciphertext.Append(SupportedChars[cIndex]);
                }
                else
                {
                    // Якщо символ не підтримується, додаємо його без змін
                    ciphertext.Append(p);
                }
            }

            return ciphertext.ToString();
        }

        public static string Decrypt(string ciphertext, string key)
        {
            StringBuilder plaintext = new StringBuilder();

            for (int i = 0; i < ciphertext.Length; i++)
            {
                char c = ciphertext[i];
                char k = key[i];

                // Перевіряємо, чи входять символи у підтримуваний набір
                if (SupportedChars.Contains(c) && SupportedChars.Contains(k))
                {
                    int cIndex = SupportedChars.IndexOf(c);
                    int kIndex = SupportedChars.IndexOf(k);

                    // Виконуємо розшифрування за формулою (cIndex - kIndex + SupportedChars.Length) % SupportedChars.Length
                    int pIndex = (cIndex - kIndex + SupportedChars.Length) % SupportedChars.Length;
                    char p = SupportedChars[pIndex];
                    plaintext.Append(p);

                    // Доповнюємо ключ розшифрованим символом
                    key += p;
                }
                else
                {
                    // Якщо символ не підтримується, додаємо його без змін
                    plaintext.Append(c);
                }
            }

            return plaintext.ToString();
        }
    }
}
