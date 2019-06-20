using System;

namespace Task12
{
    internal class Program
    {
        static Random rnd = new Random();
        public static void Main(string[] args)
        {
            int arrLenght = 50;
            int swapCount = 0;
            int comparisonCount = 0;
            int[] increasingArr = new int[arrLenght];
            int[] decreasingArr = new int[arrLenght];
            int[] mixedArrQSort = new int[arrLenght];
            int[] mixedArrInsSort = new int[arrLenght];

            for (int i = 0; i < increasingArr.Length; i++)
            {
                increasingArr[i] = i;
                decreasingArr[i] = arrLenght - i;
                mixedArrQSort[i] = rnd.Next(0, arrLenght);
                mixedArrInsSort[i] = mixedArrQSort[i];
            }

            Console.WriteLine($"Размер массивов = {arrLenght}");

            Console.WriteLine("Упорядоченный по возрастанию массив");
            InsertionSort(increasingArr, out swapCount, out comparisonCount);
            Console.WriteLine($"Сортировка вставками: перестановки = {swapCount}, сравнения = {comparisonCount}");

            swapCount = 0;
            comparisonCount = 0;
            QuickSort(increasingArr, 0, increasingArr.Length - 1, ref swapCount, ref comparisonCount);
            Console.WriteLine($"Быстрая сортировка: перестановки = {swapCount}, сравнения = {comparisonCount}");

            Console.WriteLine("\nУпорядоченный по убыванию массив");
            InsertionSort(decreasingArr, out swapCount, out comparisonCount);
            Console.WriteLine($"Сортировка вставками: перестановки = {swapCount}, сравнения = {comparisonCount}");
            swapCount = 0;
            comparisonCount = 0;
            Array.Reverse(decreasingArr);
            QuickSort(decreasingArr, 0, mixedArrInsSort.Length - 1, ref swapCount, ref comparisonCount);
            Console.WriteLine($"Быстрая сортировка: перестановки = {swapCount}, сравнения = {comparisonCount}");

            Console.WriteLine("\nПроизвольный массив");
            InsertionSort(mixedArrInsSort, out swapCount, out comparisonCount);
            Console.WriteLine($"Сортировка вставками: перестановки = {swapCount}, сравнения = {comparisonCount}");
            swapCount = 0;
            comparisonCount = 0;
            QuickSort(mixedArrQSort, 0, mixedArrQSort.Length - 1, ref swapCount, ref comparisonCount);
            Console.WriteLine($"Быстрая сортировка: перестановки = {swapCount}, сравнения = {comparisonCount}");

            Console.WriteLine("\nТеоретические оценки сложности алгоритмов");
            Console.WriteLine("Сортировка вставками:");
            Console.WriteLine($"Лучший случай - O(n); Для данного количества элементов = {arrLenght} ");
            Console.WriteLine($"В среднем - O(n^2); Для данного количества элементов = {arrLenght * arrLenght} ");
            Console.WriteLine($"Худший случай - O(n^2); Для данного количества элементов = {arrLenght * arrLenght} ");

            Console.WriteLine("\nБыстрая сортировка:");
            Console.WriteLine($"Лучший случай - O(n log n); Для данного количества элементов = {Math.Round(arrLenght * Math.Log(arrLenght)),0} ");
            Console.WriteLine($"В среднем - O(n log n); Для данного количества элементов = {Math.Round(arrLenght * Math.Log(arrLenght), 0)} ");
            Console.WriteLine($"Худший случай - O(n^2); Для данного количества элементов = {arrLenght * arrLenght} ");



        }

        public static void QuickSort(int[] arr, int leftIndex, int rightIndex, ref int swapCount, ref int comparisonCount)
        {
            int pivot = arr[(rightIndex - leftIndex) / 2 + leftIndex];
            int i = leftIndex;
            int j = rightIndex;
            while (i <= j)
            {
                while (arr[i] < pivot && i <= rightIndex)
                {
                    ++i;
                    comparisonCount++;
                }
                while (arr[j] > pivot && j >= leftIndex)
                {
                    --j;
                    comparisonCount++;
                }
                if (i <= j)
                {
                    if (arr[i] != arr[j])
                    {
                        Swap(ref arr[i], ref arr[j]);
                        swapCount++;
                    }
                    comparisonCount++;
                    ++i; --j;
                }                            
            }
            if (j > leftIndex) QuickSort(arr, leftIndex, j, ref swapCount, ref comparisonCount);
            if (i < rightIndex) QuickSort(arr, i, rightIndex, ref swapCount, ref comparisonCount);
        }

        public static void InsertionSort(int[] array, out int swapCount, out int comparisonCount)
        {
            swapCount = 0;
            comparisonCount = 0;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    comparisonCount++;
                    if (array[j] < array[j - 1])
                    {
                        swapCount++;
                        Swap(ref array[j], ref array[j-1]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}