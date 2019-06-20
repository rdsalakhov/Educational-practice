using System.Collections;
using System.Collections.Generic;

namespace Task10
{
    public class LinkedListEnumerator : IEnumerator<Vertex>
    {
        ListNode startItem;
        ListNode curItem;

        public LinkedListEnumerator(ListNode startItem)
        {
            this.startItem = startItem;
            this.curItem = new ListNode(null, startItem);
        }

        public Vertex Current
        {
            get { return curItem.Value; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        

        public bool MoveNext()
        {
            if (curItem.Next == null) return false;
            else
            {
                curItem = curItem.Next;
                return true;
            }
        }

        public void Reset()
        {
            curItem = startItem;
        }

        public void Dispose()
        {
            
        }
    }
}