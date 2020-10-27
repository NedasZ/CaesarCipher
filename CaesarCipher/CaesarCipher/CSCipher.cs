using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class CSCipher
    {
        public static char Cipher(char ch, int key)
        {
            
            if (!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')))
            {
                return ch;
            }

            key = key % 26;
            if(key < 0)
                key += 26;

            char d;
            if (char.IsUpper(ch))
            {
                d = 'A';
            }
            else
            {
                d = 'a';
            }

            char ats = (char)((((ch + key) - d) % 26) + d);

            return ats;
        }

        public static string Encipher(string input, int key)
        {
            string output = "";
            
            foreach (char ch in input)
                output += Cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("type a message to encrypt it.");
            string message = Console.ReadLine();
            bool nokey = true;
            int key = 0;
            while (nokey)
            {
                Console.WriteLine("type a key to encrypt by (integer number)");
                string keyString = Console.ReadLine();
                nokey = false;
                try
                {
                    key = int.Parse(keyString);
                }
                catch (Exception)
                {
                    Console.WriteLine("Key can not be parsed, try again.");
                    nokey = true;
                }
            }


            string secretMessage = Encipher(message, key);
            Console.WriteLine("Encrypted message: " + secretMessage);


            Console.WriteLine("type a message to decrypt it.");
            string message2 = Console.ReadLine();



            int key2 = 0;

            nokey = true;
            while (nokey)
            {
                Console.WriteLine("type a key it was encrypted by (integer number).");
                string keyString = Console.ReadLine();
                nokey = false;
                try
                {
                    key2 = int.Parse(keyString);
                }
                catch (Exception)
                {
                    Console.WriteLine("Key can not be parsed, try again.");
                    nokey = true;
                }
            }

            string decryptedMessage = Decipher(message2, key2);
            Console.WriteLine("Decrypted message: " + decryptedMessage);

            Console.WriteLine("(Press 'Enter' to close program)");
            Console.ReadLine();


        }
    }
}
