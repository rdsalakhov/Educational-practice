using System.Collections.Generic;

namespace Task8
{
    public class Cycle : List<Node>
    {
        public Cycle() : base()
        {
            
        }
        public Cycle(List<Node> list) : base(list)
        {
            
        }
        public override bool Equals(object obj)
        {
            var cycle = obj as Cycle;
            if (cycle == null)
            {
                return false;
            }
            if (cycle.Count != this.Count)
            {
                return false;
            }
            bool equal = true;
            for (int i = 0; i < this.Count; i++)
            {
                equal = this[i].Equals(cycle[i]);
                if (!equal)
                {
                    break;
                }
            }

            return equal;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var node in this)
            {
                s += node.Index;
            }

            return s;
        }

        Cycle Shift(int step)
        {
           var temp = new Cycle(this);
            for (int i = 0; i < this.Count - step; i++)
            {
                temp[i + step] = this[i];
            }

            for (int i = this.Count - step, j = 0; i < this.Count; i++, j++)
            {
                temp[j] = this[i];
            }

            return temp;
        }
        
        bool IsShifted(Cycle cycle)
        {
            if (this.Count != cycle.Count)
                return false;
            bool isShifted;
            Cycle tempCycle;
            for (int i = 1; i < this.Count; i++)
            {
                tempCycle = cycle.Shift(i);
                isShifted = this.Equals(tempCycle);
                if (isShifted)
                    return true;
            }

            return false;
        }

        public bool IsContainedIn(List<Cycle> list)
        {
            bool isContained = list.Contains(this);
            if (!isContained)
            {
                bool isShifted  = false;
                foreach (var cycle in list)
                {
                    isShifted = this.IsShifted(cycle);
                    if (isShifted) break;
                }

                return isShifted;
            } 
            return true;
        }
    }
}