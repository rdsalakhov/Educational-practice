using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class FrequencyComparer : IComparer<CodeTreeNode>
    {
        public int Compare(CodeTreeNode x, CodeTreeNode y)
        {
            return x.Frequency.CompareTo(y.Frequency);
        }
    }
}
