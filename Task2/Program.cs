// Матрица A считается меньше (больше) матрицы B, если при просмотре слева направо и сверху вниз после всех равенств
// элементов матриц следующий элемент из матрицы A меньше (больше), чем соответствующий элемент из B. 
// Такое сравнение называется лексикографическим и напоминает способ сравнения слов в словаре.
// Дана прямоугольная матрица A размером n×m, все элементы которой различны.В ней можно менять местами два произвольных столбца,
// а также менять местами две произвольных строки.
// Пусть Amax – максимальная матрица, получаемая из исходной матрицы путем любого требуемого количества вышеприведенных операций.
// Необходимо написать программу, находящую последний (правый нижний) элемент из Amax.

using System;
using System.IO;
using System.Linq;


namespace Task2
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {      
            // Создание матрицы из файла
            int[,] matr = ReadFile(@"\\Mac\Home\Desktop\projects\Учебная практика\Task1\Task2\bin\Debug\INPUT.txt");

            // Получение индекса строки с максимальным элементом
            int maxLineInd = FindLineWithMaxNumber(matr);

            // Получение индексов столбцов, содержащих максимальный и минимальный элементы максимальной строки
            int[] maxLine = CopyLineFromMatr(matr, maxLineInd);
            int maxItemIndex = MaxItemIndex(maxLine);
            int minItemIndex = MinItemIndex(maxLine);

            // Создание укороченной матрицы из максимального и минимального столбцов
            matr = GetShortMatr(matr, maxItemIndex, minItemIndex);

            // Сортировка укороченной матрицы
            SwapLines(ref matr, 0, maxLineInd);
            SortLine(ref matr, 0);
            SortColumn(ref matr, 0);

            // Запись результата в файл
            var result = matr[matr.GetLength(0) - 1, matr.GetLength(1) - 1];
            File.Create(@"\\Mac\Home\Desktop\projects\Учебная практика\Task1\Task2\bin\Debug\OUTPUT.TXT").Close();
            var sw = new StreamWriter(@"\\Mac\Home\Desktop\projects\Учебная практика\Task1\Task2\bin\Debug\OUTPUT.TXT");
            sw.Write(result);
            sw.Close();
        }            
        
        /// <summary>
        /// Возвращает двумерный массив, состоящий из двух столбцов заданного двумерного массива matr
        /// </summary>
        static int[,] GetShortMatr(int[,] matr, int column1, int column2)
        {
            int[,] shortMatr = new int[matr.GetLength(0), 2];
            for (int x = 0; x < matr.GetLength(0); x++)
            {
                shortMatr[x, 0] = matr[x, column1];
                shortMatr[x, 1] = matr[x, column2];
            }
            return shortMatr;
        }       

        /// <summary>
        /// Возвращает индекс максимального элемента массива line
        /// </summary>
        static int MaxItemIndex(int[] line)
        {
            int max = line.Max();
            int yInd = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == max)
                    yInd = i; 
            }
            return yInd;
        }

        /// <summary>
        /// Возвращает индекс минимального элемента массива line
        /// </summary>
        static int MinItemIndex(int[] line)
        {
            int min = line.Min();
            int yInd = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == min)
                    yInd = i;
            }
            return yInd;
        }

        /// <summary>
        /// Возвращает одномерный массив, состоящий из элементов заданной строки двумерного массива matr
        /// </summary>
        static int[] CopyLineFromMatr(int[,] matr, int line)
        {
            int[] outputLine = new int[matr.GetLength(1)];
            for (int i = 0;  i < matr.GetLength(1); i++)
            {
                outputLine[i] = matr[line, i];
            }
            return outputLine;
        }                      

        /// <summary>
        /// Возвращает номер строки с максимальным элементом двумерного массива
        /// </summary>
        static int FindLineWithMaxNumber(int[,] matr)
        {
            int maxLine = 0;
            int max = matr[0, 0];
            for (int x = 0; x < matr.GetLength(0); x++)
            {
                for (int y = 0; y < matr.GetLength(1); y++)
                {
                    if (matr[x, y] > max)
                    {
                        max = matr[x, y];
                        maxLine = x;
                    }

                }
            }
            return maxLine;
        }

        /// <summary>
        /// Преобразует содержимое файла filename в двумерный массив 
        /// </summary>
        public static int[,] ReadFile(string fileName)
        {
            var sr = new StreamReader(fileName);
            string[] line = sr.ReadLine().Split(' ');
            int xSize = int.Parse(line[0]);
            int ySize = int.Parse(line[1]);

            int[,] matr = new int[xSize, ySize];

            for (int x = 0; x < matr.GetLength(0); x++)
            {
                line = sr.ReadLine().Split(' ');
                for (int y = 0; y < matr.GetLength(1); y++)
                {
                    matr[x, y] = int.Parse(line[y]);
                }
            }

            return matr;
        }

        
        /// <summary>
        /// Меняет местами строки line1 и line2 в двумерном массиве matr
        /// </summary>
        static void SwapLines(ref int[,] matr, int line1, int line2)
        {
            var newMatr = new int[matr.GetLength(0), matr.GetLength(1)];
            for (int x = 0; x < matr.GetLength(0); x++)
            {
                for (int y = 0; y < matr.GetLength(1); y++)
                {
                    newMatr[x, y] = matr[x, y];
                }
            }
            for (int y = 0; y < matr.GetLength(1); y++)
            {
                newMatr[line1, y] = matr[line2, y];
            }
            for (int y = 0; y < matr.GetLength(1); y++)
            {
                newMatr[line2, y] = matr[line1, y];
            }
            matr = newMatr;
        }

        /// <summary>
        /// Меняет местами стобцы column1 и column2 в двумерном массиве matr
        /// </summary>
        static void SwapColumns(ref int[,] matr, int column1, int column2)
        {
            var newMatr = new int[matr.GetLength(0), matr.GetLength(1)];
            for (int x = 0; x < matr.GetLength(0); x++)
            {
                for (int y = 0; y < matr.GetLength(1); y++)
                {
                    newMatr[x, y] = matr[x, y];
                }
            }
            for (int x = 0; x < matr.GetLength(0); x++)
            {
                newMatr[x, column1] = matr[x, column2];
            }
            for (int x = 0; x < matr.GetLength(0); x++)
            {
                newMatr[x, column2] = matr[x, column1];
            }
            matr = newMatr;
        }

        /// <summary>
        /// Сортирует столбцы двумерного массива matr так, чтобы элементы строки
        /// line были расположены в порядке убывания
        /// </summary>
        static void SortLine(ref int[,] matr, int line = 0)
        {
            int size = matr.GetLength(1);
            for (int i = 0; i < size; i++)
            {
                int maxInd = i;

                for (int j = i; j < size; j++)
                {
                    if (matr[line, j] > matr[line,maxInd]) maxInd = j;
                }
                SwapColumns(ref matr, i, maxInd );
            }
        }

        /// <summary>
        /// Сортирует строки двумерного массива matr так, чтобы элементы столбца 
        /// column были расположены в порядке убывания
        /// </summary>        
        static void SortColumn(ref int[,] matr, int column = 0)
        {
            int size = matr.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                int maxInd = i;

                for (int j = i; j < size; j++)
                {
                    if (matr[j, column] > matr[maxInd, column]) maxInd = j;
                }
                SwapLines(ref matr, i, maxInd);
            }
        }

        /// <summary>
        /// Создает текстовый файл, содержащий входные данные для задачи
        /// </summary>
        static void CreateInputFile(int lines, int columnes)
        {
            File.Create(@"\\Mac\Home\Desktop\projects\Учебная практика\Task1\Task2\bin\Debug\INPUT.TXT").Close();

            var sw = new StreamWriter(@"\\Mac\Home\Desktop\projects\Учебная практика\Task1\Task2\bin\Debug\INPUT.TXT");
            sw.WriteLine(lines + " " + columnes);
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columnes; j++)
                    sw.Write(rnd.Next(0, 2147483647) + " ");
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
