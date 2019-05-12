//Ввести а1, а2, а3, N, E. Построить N элементов последовательности ак = 1/3*ак–1 + 1/2*ак-2 + 2/3*ак–3.
//Выяснить, сколько пар удовлетворяют условию | ак – ак–1 | < E. Напечатать их номера

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N - количество элементов последовательности.");
            int n = IntInput();
            double[] sequence = new double[n];

            Console.WriteLine("Введите первый элемент последовательности.");
            sequence[0] = DoubleInput();

            Console.WriteLine("Введите второй элемент последовательности");
            sequence[1] = DoubleInput();

            Console.WriteLine("Введите третий элемент последовательности");
            sequence[2] = DoubleInput();

            Console.WriteLine("Введите число E");
            double e = DoubleInput();

            CreateSequence(sequence[0], sequence[1], sequence[2], sequence, 4, n);

            foreach (var i in sequence)
                Console.WriteLine(i);

            Console.WriteLine("Элементы, удовлетворяющие условию | ак – ак–1 | < E:");
            Dictionary<int, double> pairs = CountPairs(sequence, e);
            foreach (var i in pairs)            
                Console.WriteLine($"№{i.Key} {i.Value}");
            Console.WriteLine($"Всего {pairs.Count} пар элементов");

            
        }
        static double CreateSequence(double a1, double a2, double a3, double[] sequence, int curNum, int endNum)
        {
            if (curNum == sequence.Length)
            {
                double a4 = 1 / (a3 * 3) + 1 / (a2 * 2) + 2 / (3 * a1);
                sequence[curNum-1] = a4;
                return a4;
            }
            else
            {
                double a4 = 1 / (a3 * 3) + 1 / (a2 * 2) + 2 / (3 * a1);
                sequence[curNum-1] = a4;
                
                double a5 = CreateSequence(a2, a3, a4, sequence, ++curNum, endNum);
                return a4;
            }
        }

        static Dictionary<int,double> CountPairs(double[] sequence, double e)
        {
            var pairs = new Dictionary<int, double>();
            for(int i = 1; i < sequence.Length; i++)
            {
                double pairDifference = Math.Abs(sequence[i] - sequence[i - 1]);
                if (pairDifference < e)
                    pairs.Add(i, sequence[i]);
            }
            return pairs;
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

        static int IntInput()
        {
            bool ok = false;
            int num = 0;
            while (!ok)
            {
                string input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok)
                    Console.WriteLine("Некорректный ввод. Введите целое число");
            }
            return num;
        }
    }
}
