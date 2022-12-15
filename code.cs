using System.Security.Cryptography;

namespace ConsoleApp2
{
    internal class Program
    {
        public static int[] Encrypt(int[] message, int[] key)
        {
            int[] encryptedMessage = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                encryptedMessage[i] = message[i] ^ key[i % key.Length];
            }
            return encryptedMessage;
        }
        public static int[] CryptAnalysis(int[] message, int keyLength)
        {
            int maxsize = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] > maxsize) maxsize = message[i];
            }

            int[,] aMessage = new int[keyLength, maxsize + 1];
            int[] key = new int[keyLength];

            for (int i = 0; i < message.Length; i++)
            {
                int j = i % keyLength; aMessage[j, message[i]]++; if (aMessage[j, message[i]] > aMessage[j, key[j]])
                    key[j] = message[i];
            }

            int spaceAscii = 32;
            for (int i = 0; i < keyLength; i++)
            {
                key[i] = key[i] ^ spaceAscii;
            }

            return key;
        }

        static void Main(string[] args)
        { 
            //main loop
            const int keyLength = 3;

            int[] message = new int[] { 67, 111, 110, 118, 101, 114, 116, 32, 67, 104, 97, 114, 97, 99, 116, 101, 114, 115, 32, 116, 111, 32, 65, 83, 67, 73, 73, 32, 67, 111, 100, 101, 115 };

            int[] key = CryptAnalysis(message, keyLength);
            int[] decryptedMessage = Encrypt(message, key);
            int result = decryptedMessage.Sum();
            Console.WriteLine("Result " + result);


        }
    }
}
