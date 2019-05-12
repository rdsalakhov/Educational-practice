using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Matrix
    {
        List<MatrixItem> items;
        int xLength;
        int yLength;       

        public int XLength
        {
            get { return xLength; }
            set
            {
                if (value <= 0) throw new InvalidLenghtException("Количество столбцов не может быть меньше или равно нулю", value);
                else xLength = value;
            }
        }

        public int YLength
        {
            get { return yLength; }
            set
            {
                if (value <= 0) throw new InvalidLenghtException("Количество строк не может быть меньше или равно нулю", value);
                else yLength = value;
            }
        }

        public Matrix(int xLen, int yLen)
        {
            this.XLength = xLen;
            this.yLength = yLen;
            items = new List<MatrixItem>(xLen * yLen);
        }

        public Matrix(int xLen, int yLen, List<int> items)
        {
            if (items.Count != xLen * yLen)
                throw new InvalidNumberOfItemsException($"Матрица должна содержать {xLen*yLen} элементов. Передано элементов {items.Count}.", items.Count);
            this.XLength = xLen;
            this.yLength = yLen;
            this.items = new List<MatrixItem>(xLen * yLen);
            int count = 0;
            for (int x = 0; x < xLen; x++)
            {
                for (int y = 0; y < yLen; y++)
                {
                    this.items.Add(new MatrixItem(x, y, items[count]));
                    count++;
                }
            }
        }

        public int this[int xCoordinate, int yCoordinate]
        {
            get
            {
                CheckIndex(xCoordinate, yCoordinate);
                var item =  from i in items
                               where (i.XCoordinate == xCoordinate && i.YCoordinate == yCoordinate)
                               select i.Value;
                if (item.Count() == 0) throw new Exception($"Не найден элемент с таким индексом [{xCoordinate},{yCoordinate}]");
                else return item.ToList<int>()[0];
            }
            set
            {
                CheckIndex(xCoordinate, yCoordinate);
                for (int count = 0; count < items.Count; count++)
                {
                    MatrixItem i = items[count];
                    if (i.XCoordinate == xCoordinate && i.YCoordinate == yCoordinate)
                        i.Value = value;
                }
            }
        }

        private void CheckIndex(int x, int y)
        {
            if (!(x < XLength && x >= 0))
                throw new InvalidIndexException("Индекс находился за границей диапазона", x);
            if (!(y < XLength && y >= 0))
                throw new InvalidIndexException("Индекс находился за границей диапазона", y);
        }       

        public void DeleteColumn(int yCoordinate)
        {
            CheckIndex(0, yCoordinate);
            var leftPart = from i in items
                           where i.YCoordinate < yCoordinate
                           select i;
            var rightPart = from i in items
                            where i.YCoordinate > yCoordinate
                            select i;
            var rightList = rightPart.ToList<MatrixItem>();

            for (int i = 0; i < rightList.Count(); i++)
            {
                rightList[i].YCoordinate--;
            }

            items = leftPart.ToList<MatrixItem>();
            items.AddRange(rightList);
            YLength--;      
        }

        public void DeleteLine(int xCoordinate)
        {
            CheckIndex(xCoordinate, 0);
            var upperPart = from i in items
                           where i.XCoordinate < xCoordinate
                           select i;
            var lowerPart = from i in items
                            where i.XCoordinate > xCoordinate
                            select i;
            var lowerList = lowerPart.ToList<MatrixItem>();
            for (int i = 0; i < lowerList.Count(); i++)
            {
                lowerList[i].XCoordinate--;
            }
            items = upperPart.ToList<MatrixItem>();
            items.AddRange(lowerList);
            XLength--;
        }

        public void Print()
        {
            for (int x = 0; x < XLength; x++)
            {
                for (int y = 0; y < YLength; y++)
                {
                    Console.Write($"{this[x, y]} ");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return $"Матрица {XLength} х {YLength}";
        }
    }

    internal class InvalidNumberOfItemsException : Exception
    {
        public int Value { get; }
        public InvalidNumberOfItemsException(string message, int value) : base(message)
        {
            this.Value = value;
        }       
    }

    class InvalidLenghtException : Exception
    {
        public int Value { get; }
        public InvalidLenghtException(string message, int value) : base(message)
        {
            this.Value = value;
        }
    }

    class InvalidIndexException : Exception
    {
        public int Value { get; }
        public InvalidIndexException(string message, int value) : base(message)
        {
            this.Value = value;
        }
    }

}
