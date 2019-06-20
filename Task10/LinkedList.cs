using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Task10
{
    public class LinkedList : IEnumerable<Vertex>
    {
        private ListNode _first;

        public LinkedList()
        {
            _first = null;
        }
        public LinkedList(params Vertex[] items)
        {
            try
            {
                this._first = new ListNode(items[0], null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Невозможно создать пустой список");
                throw;
            }
            ListNode current = _first;
            for (int i = 1; i < items.Length; i++)
            {
                current.Next = new ListNode(items[i], null);
                current = current.Next;
            }
        }

        public void Add(Vertex value)
        {
            if (_first == null)
            {
                _first = new ListNode(value, null);
                return;
            }
            
            var cur = this._first;
            while (cur.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = new ListNode(value, null);
        }

        public Vertex this[int index]
        {
            get
            {
                if (index >= this.Count())
                {
                    return null;
                }
                var cur = _first;
                for (int i = 1; i <= index; i++)
                {
                    cur = cur.Next;
                }

                return cur.Value;

            }

            set
            {
                var cur = _first;
                for (int i = 1; i <= index && cur.Next != null; i++)
                {
                    cur = cur.Next;
                }

                if (cur.Next != null)
                {
                    cur.Value = value;
                }
            }
        }
        
        public void Remove(Vertex value)
        {
            if (_first.Value.Equals(value))
                _first = _first.Next;
            else
            {
                var cur = this._first;
                while (cur.Next != null && !cur.Next.Value.Equals(value))
                {
                    cur = cur.Next;
                }

                if (cur.Next != null)
                {
                    cur.Next = cur.Next.Next;
                }
            }
        }

        public void RemoveAt(int index)
        {
            var cur = _first;
            for (int i = 1; i < index && cur.Next != null; i++)
            {
                cur = cur.Next;
            }
            
            if (cur.Next != null)
            {
                cur.Next = cur.Next.Next;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LinkedList))
                return false;
            var list = obj as LinkedList;
            if (list.Count() != this.Count())
            {
                return false;
            }
            var cur = _first;
            foreach (var i in list)
            {
                if (!(i.Equals(cur)))
                {
                    return false;
                }

                cur = cur.Next;
            }

            return true;
        }

        public IEnumerator<Vertex> GetEnumerator()
        {
            return new LinkedListEnumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}