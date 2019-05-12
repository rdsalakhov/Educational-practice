// Даны действительная квадратная матрица по­ рядка n, натуральные числа i, / (1 <= i <= n, 1 <= j <= n).
// Из матрицы удалить i-ю строку и j-й столбец.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static public Random rnd = new Random();
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 25; i++)
            { 
                list.Add(rnd.Next(1, 100));
            }

            Matrix matr = new Matrix(5, 5, list);
            matr.Print();
            Console.WriteLine("====================");
            matr.DeleteColumn(0);
            matr.Print();
            Console.WriteLine("====================");

            matr.DeleteLine(0);
            matr.Print();
        }
    }
}
