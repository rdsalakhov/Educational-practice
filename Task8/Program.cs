using System;
using System.Collections.Generic;
using Utilities;

namespace Task8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestingProcedure();
            var matr = MatrixInput();
            Console.WriteLine("Введите длину цикла К");
            int k = Input.IntInput(0, Int32.MaxValue);
            var graph = new Graph(matr);
            var cycles = graph.Cycles();
            var output = new List<Cycle>();
            foreach (var cycle in cycles)
            {
                if (cycle.Count == k)
                {
                    output.Add(cycle);
                }
            }

            if (output.Count == 0)
            {
                Console.WriteLine($"В графе нет простых циклов длины {k}");
            }
            else
            {
                foreach (var cycle in output)
                {
                    Console.WriteLine(cycle);
                }
            }
        }

        private static void TestingProcedure()
        {
//            int[,] testIncMatr =
//            {
//                {1, 0, 1, 0, 1, 0, 0}, {1, 1, 0, 0, 0, 1, 0}, {0, 1, 1, 1, 0, 0, 0}, {0, 0, 0, 1, 1, 1, 1},
//                {0, 0, 0, 0, 0, 0, 1}
//            };
            int[,] testIncMatr =
            {
                {1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0}, {1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0}, {0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0},
                {0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1}, {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0}
            };
            
            var graph = new Graph(testIncMatr);
            var cycles = graph.Cycles();
            
            if (cycles.Count == 0)
            {
                Console.WriteLine($"В графе нет простых циклов");
            }
            else
            {
                foreach (var cycle in cycles)
                {
                    Console.WriteLine(cycle);
                }
            }
        }

        static int[,] MatrixInput()
        {
            Console.WriteLine("Введите количество вершин в графе");
            int nodeCount = Input.IntInput(0, int.MaxValue);
            Console.WriteLine("Введите количество ребер в графе");
            int edgeCount = Input.IntInput(0, int.MaxValue);
            var matr = new int[nodeCount, edgeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < edgeCount; j++)
                {
                    Console.WriteLine($"Введите элемент матрицы ({i}, {j})");
                    matr[i, j] = Input.IntInput(0, 1);
                }
            }

            return matr;
        }
    }
}