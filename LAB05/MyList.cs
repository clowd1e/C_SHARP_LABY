using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyList<T>
    {
        private class Node
        {
            public T value { get; set; }
            public Node next;
        }

        private Node first = null;
        private Node last = null;

        public void Add(T element)
        {
            if (first is null)
            {
                first = last = new Node() { value = element };
            } else
            {
                last = last.next = new Node() { value = element };
            }
        }
        public int Count { 
            get
            {
                int result = 0;
                var e = first;
                while (e != null)
                {
                    result++;
                    e = e.next;
                }
                return result;
            }
        }
        public void Insert(int i, T element)
        {
            if (i < 0 || i > Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (i == 0)
            {
                first = last = new Node() { value = element };
            }
            else
            {
                Node p = first;
                Node n;
                while (i-- > 1)
                {
                    p = p.next;
                }
                n = p.next;
                p.next = new Node() { value = element, next = n };
            }
        }
        private Node Get(int i)
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            var e = first;
            while (i-- > 0 && e != null)
            {
                e = e.next;
            }
            return e;
        }
        public bool Remove(T element)
        {
            var e = first;
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(e.value, element))
                {
                    if (i == 0)
                    {
                        first = Get(i + 1);
                        e = null;
                    }
                    else if (i == Count - 1)
                    {
                        last = Get(i - 1);
                        last.next = null;
                        e = null;
                    }
                    else
                    {
                        var prev = Get(i - 1);
                        var next = Get(i + 1);
                        e = null;
                        prev.next = next;
                    }
                    return true;
                }
                e = e.next;
            }

            return false;
        }

        public bool RemoveAt(int i)
        {
            if (i < 0 || i >= Count)
            {
                return false;
            }

            var e = Get(i);
            if (i == 0)
            {
                first = Get(i + 1);
                e = null;
            }
            else if (i == Count - 1)
            {
                last = Get(i - 1);
                last.next = null;
                e = null;
            }
            else
            {
                var prev = Get(i - 1);
                var next = Get(i + 1);
                e = null;
                prev.next = next;
            }
            return true;
        }

        public T this[int i] { get => Get(i).value; set => Get(i).value = value; } 
    }
}
