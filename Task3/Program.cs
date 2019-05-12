using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координату X");
            double x = DoubleInput();
            Console.WriteLine("Введите координату Y");
            double y = DoubleInput();
            double answer;
            bool underLine = y < x / 2;
            bool inCircle = (x * x + y * y) < 1;
            if (underLine && inCircle)
                answer = 0;
            else answer = y * y;
            Console.WriteLine($"u = {answer}");
        }

        static double DoubleInput()
        {
            bool ok = false;
            double num = 0;
            while (!ok)
            {
                string input = Console.ReadLine();
                ok = double.TryParse(input, out num);
                if (!ok)
                    Console.WriteLine("Некорректный ввод. Введите действительное число");
            }
            return num;
        }
    }
}
