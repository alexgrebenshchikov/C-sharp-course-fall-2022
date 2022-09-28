
var t1 = new Node<int>(12, null);
var t2 = new Node<int>(12, t1);
var cmn = new Node<int>(11, t2);

var l1 = new LinkedList<int>(new Node<int>(9, new Node<int>(10, cmn)));
var l2 = new LinkedList<int>(new Node<int>(100, cmn));
Console.WriteLine(ListInstersector<int>.Found(l1, l2) == cmn);




class Node<T>
{
    public T Value { get; private set; }
    public Node<T>? Next { get; private set; }

    public Node(T value, Node<T>? next)
    {
        this.Value = value;
        this.Next = next;
    }
}
class LinkedList<T>
{
    public Node<T>? Head { get; private set; }
    public LinkedList(Node<T>? head)
    {
        Head = head;
    }

    public int Length()
    {
        var cur = Head;
        var res = 0;
        while (cur != null)
        {
            cur = cur.Next;
            res++;
        }
        return res;
    }
}


class ListInstersector<T>
{
    public static Node<T>? Found(LinkedList<T> l1, LinkedList<T> l2)
    {
        var len1 = l1.Length();
        var len2 = l2.Length();
        var cur1 = l1.Head;
        var cur2 = l2.Head;
        if (len1 > len2)
        {
            for (var i = 0; i < len1 - len2; i++)
            {
                cur1 = cur1.Next;
            }
        }
        else
        {
            for (var i = 0; i < len2 - len1; i++)
            {
                cur2 = cur2.Next;
            }
        }
        while (cur1 != null && cur2 != null)
        {
            if (cur1 == cur2)
            {
                return cur1;
            }
            cur1 = cur1.Next;
            cur2 = cur2.Next;
        }
        return null;
    }
}



