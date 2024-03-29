﻿// Даны действительная квадратная матрица по­ рядка n, натуральные числа i, / (1 <= i <= n, 1 <= j <= n).
// Из матрицы удалить i-ю строку и j-й столбец.
using System;
using System.Collections.Generic;
using Utilities;
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

            var matr = MatrixCreationMenu();            
            matr.Print();


            Console.WriteLine("Введите номер столбца, который нужно удалить.");
            int i = Input.IntInput(1, matr.YLength);
            matr.DeleteColumn(i-1);
            matr.Print();

            Console.WriteLine("Введите номер строки, которую нужно удалить.");
            int j = Input.IntInput(1, matr.XLength);
            matr.DeleteLine(j-1);
            matr.Print();
        }

        static Matrix MatrixCreationMenu()
        {
            Console.WriteLine("Введите порядок матрицы:");
            int n = Input.IntInput(1, int.MaxValue);

            var matrList = new List<int>();

            Console.WriteLine("1: Создать матрицу вручную\n2: Создать матрицу из случайных чисел");
            int answer = Input.IntInput(1, 2);
            if (answer == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine($"Введите элемент ({i}; {j})");
                        int num = Input.IntInput();
                        matrList.Add(num);
                    }
                }                
            }
            else if (answer == 2)
            {
                for (int i = 0; i < n*n; i++)
                {
                    matrList.Add(rnd.Next(-100, 100));
                }
            }
            var matr = new Matrix(n, n, matrList);
            return matr;
        }

        static Matrix CreateRandomMatrix(int n)
        {
            var list = new List<int>();
            for (int i = 0; i < 25; i++)
            {
                list.Add(rnd.Next(1, 100));
            }

            Matrix matr = new Matrix(n, n, list);
            return matr;
        }

        
    }
}
