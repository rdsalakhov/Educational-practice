using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Input
    {
        public static int IntInput(int min = int.MinValue, int max = int.MaxValue)
        {
            bool ok = false;
            int num = 0;
            while (!ok)
            {
                string input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok)
                {
                    Console.WriteLine("Введите целое число");
                    continue;
                }
                if (num <= max && num >= min)
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine($"Число должно принадлежать диапазону [{min}; {max}]");
                    ok = false;
                }
            }
            return num;
        }

        public static double DoubleInput(double min = double.MinValue, double max = double.MaxValue)
        {
            bool ok = false;
            double num = 0;
            while (!ok)
            {
                string input = Console.ReadLine();
                ok = double.TryParse(input, out num);
                if (!ok)
                {
                    Console.WriteLine("Введите целое число");
                    continue;
                }
                if (num <= max && num >= min)
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine($"Число должно принадлежать диапазону [{min}; {max}]");
                    ok = false;
                }
            }
            return num;
        }
    }
}
