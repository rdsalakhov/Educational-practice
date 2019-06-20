using System;
using Utilities;

namespace Task9
{
    internal class Program
    {
        public static void Main(string[] args)
        { 
            Console.WriteLine("Введите N - количество элементов списка");
            int n = Input.IntInput(1, 100000);
            var linkedList = new LinkedList(n);
            linkedList.Show();
        }
    }
}