using System;
using Utilities;

namespace Task10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Test();
            var adjMatr = MatrixInput(out int[] values);
            var graph = new Graph(adjMatr, values);
            Console.WriteLine("Исходный граф:");
            graph.Show();
            Console.WriteLine("Введите значение вершины, которую нужно удалить");
            int removeVal = Input.IntInput();
            Console.WriteLine("Граф после удаления:");
            graph.Show();
        }

        static void Test()
        {
            var adjMatr = new int[,]
            {
                {0, 1, 1}, {1, 0, 1}, {1, 1, 0}
            };
            int[] values = {10, 12, 12};
            
            var graph = new Graph(adjMatr, values);
            
            graph.Show();
            
            graph.RemoveVertexes(12);
            Console.WriteLine("-------");
            graph.Show();
        }
        
        static int[,] MatrixInput(out int[] values)
        {
            Console.WriteLine("Ввод матрицы смежности:");
            Console.WriteLine("Введите количество вершин в графе");
            int vertexCount = Input.IntInput(0, int.MaxValue);
            var matr = new int[vertexCount, vertexCount];
            values = new int[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    Console.WriteLine($"Введите элемент матрицы ({i}, {j})");
                    matr[i, j] = Input.IntInput(0, 1);
                }
            }
            
            Console.WriteLine("Введите значения информационных полей вершин");
            for (int i = 0; i < vertexCount; i++)
            {
                Console.WriteLine($"Введите значение вершины {i}");
                values[i] = Input.IntInput(-100, 100);
            }

            return matr;
        }
    }
}