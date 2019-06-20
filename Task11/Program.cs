using System;
using System.Linq;

namespace Task11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = InputEncryptedString();
            string decrypted = Decrypt(s);
            Console.WriteLine(decrypted);
        }

        public static string InputEncryptedString()
        {
            bool ok;
            string input;
            do
            {
                ok = true;
                Console.WriteLine("Введите зашифрованное сообщение из нулей и единиц");
                input = Console.ReadLine();
                if (input.Length == 0)
                {
                    Console.WriteLine("Введена пустая строка");
                    continue;
                }
                if (input.Length % 3 != 0)
                {
                    ok = false;
                }

                foreach (var c in input)
                {
                    string s = c.ToString();

                    if (s != "0" && s != "1")
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok)
                {
                    Console.WriteLine(
                        "Некорректный ввод! Строка должна состоять из нулей и единиц, а ее длина должна быть кратна трем");
                }
            } while (!ok);

            return input;
        }

        public static string Decrypt(string encyptedString)
        {
            string decryptedString = "";
            for (int i = 0; i < encyptedString.Length; i += 3)
            {
                int sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    //var c = encyptedString[i + j];
                    sum += Convert.ToInt32(encyptedString[i + j].ToString());
                }

                if (sum >= 2)
                {
                    decryptedString += 1;
                }
                else decryptedString += 0;
            }

            return decryptedString;
        }
    }
}