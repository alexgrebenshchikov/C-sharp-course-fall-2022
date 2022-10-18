using System.Collections;
using System.Threading;
using System.Xml.Linq;

namespace task3 {
    class MyNode<T>
    {
        public T Value { get; private set; }

        public MyNode<T>? Next { get; set; }

        public MyNode(T value, MyNode<T>? next = null)
        {
            Value = value;
            Next = next;
        }
    }

    class MyLinkedList<T> : IEnumerable<T>
    {
        public MyNode<T>? Head { get; private set; }
        public MyNode<T>? Tail { get; private set; }
        public int Count { get; private set; }


        public MyLinkedList() {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Push(T value) {
            var node = new MyNode<T>(value);
            if (Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        public bool DeleteFirst(T value) {
            MyNode<T>? prev = null;
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value?.Equals(value) == true)
                {
                    if (Tail == currentNode)
                    {
                        Tail = prev;
                    }
                    if (prev == null)
                    {
                        Head = currentNode.Next;
                    }
                    else
                    {
                        prev.Next = currentNode.Next;
                    }
                    Count -= 1;
                    return true;
                }

                prev = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

       
        public IEnumerator<T> GetEnumerator()
        {
            var cur = Head;
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    class Program {
        public static void Main(string[] args) { 
            var list = new MyLinkedList<int>();

            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(1);
            Console.WriteLine(list.Count);
            list.DeleteFirst(1);
            Console.WriteLine(list.Count);

            foreach (var elem in list) {
                Console.Write("{0} ", elem);
            }
        }
    }
}