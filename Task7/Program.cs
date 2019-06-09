using System;
using Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            //var frequencies = new FrequencyTable();
            //frequencies.Add("A", 0.02);
            //frequencies.Add("B", 0.02);
            //frequencies.Add("C", 0.03);
            //frequencies.Add("D", 0.03);
            //frequencies.Add("E", 0.1);
            //frequencies.Add("F", 0.4);
            //frequencies.Add("G", 0.4);
            var frequencies = FrequencyTableInput();
            var codeTree = new CodeTree(frequencies);
            var dict = codeTree.CreateCodeTable();
            foreach (var i in dict)
            {
                Console.WriteLine($"{i.Key}: {i.Value}");
            }
            
        }

        static FrequencyTable FrequencyTableInput()
        {
            var frequencies = new FrequencyTable();
            Console.WriteLine("Введите количество символов в исходном алфавите");
            int n = Input.IntInput(1, int.MaxValue);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите символ");
                string letter = Console.ReadLine();
                Console.WriteLine("Введите частоту символа");
                double frequency = Input.DoubleInput(0, 1);
                frequencies.Add(letter, frequency);
            }
            return frequencies;
        }
    }
}
