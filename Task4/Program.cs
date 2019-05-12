//Дано действительное положительное число е. Мето­дом деления отрезка пополам 
//найти приближенное значение корня уравнения f(x) = 0.
//Абсолютная погрешность найден­ного значения не должна превосходить е.
// х^5 — x — 0.2 =  0, [1, 1.5]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double answer = 5;
            DichotomousDivision(1, 1.5, 0.0000001, ref answer);
            Console.WriteLine($"Ответ: {answer}");
        }

        static void DichotomousDivision(double left, double right, double accuracy, ref double answer)
        { 
            if (Math.Abs(right - left) < accuracy * 2)
                answer = (right + left) / 2;
            else
            {
                double middle = (right + left) / 2;
                if (Function(left) * Function(middle) <= 0)
                    DichotomousDivision(left, middle, accuracy, ref answer);
                else if (Function(middle) * Function(right) <= 0)
                    DichotomousDivision(middle, right, accuracy, ref answer);
                else throw new Exception("Не могу");
                
            }          
        }

        static double Function(double x)
        {
            return Math.Pow(x, 5) - x - 0.2;
        }
    }
}
