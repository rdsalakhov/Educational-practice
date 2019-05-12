using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class MatrixItem : IComparable, IComparer
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Value { get; set; }

        public MatrixItem(int x, int y, int value)
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
            this.Value = value;
        }

        public int CompareTo(object obj)
        {
            MatrixItem item = obj as MatrixItem;
            return this.Value.CompareTo(item.Value);
        }

        public int Compare(object x, object y)
        {
            MatrixItem item1 = x as MatrixItem;
            MatrixItem item2 = y as MatrixItem;
            return Compare(item1.Value, item2.Value);
        }
    }
}
