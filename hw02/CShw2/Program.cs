// See https://aka.ms/new-console-template for more information


class Launcher {
    static void Main(string[] args)
    {
        var p = new Person ("John", "Doe" );
        var w = new Worker (p);
        Console.WriteLine(w.Person.FirstName);
        Console.WriteLine(w.GetSalary());

    }
}

// Task 1
public class MyHashMap
{
    public MyHashMap()
    {
        capacity = 16;
        data = new Object?[capacity];
        size = 0;
    }
    private Object?[] data;
    private Int64 capacity;
    private Int64 size;
    private const double resize_factor = 0.75;
    private const int c = 5;
    private const int d = 3;
    public void Insert(Object elem)
    {
        InsertInto(elem, data);
        size++;
        if (size / (double)capacity > resize_factor)
        {
            Resize();
        }
    }

    public bool Lookup(Object elem)
    {
        return LookupRemove(elem, false);
    }

    public bool Remove(Object elem)
    {
        return LookupRemove(elem, true);
    }

    public void ShowElements()
    {
        foreach (var item in data)
        {
            if(item != null)
                Console.Write(String.Format("{0} ", item));
        }
        Console.WriteLine();
    }

    private void InsertInto(Object elem, Object?[] dst) {
        var i = 0;
        for (; ;) {
            var index = GetIndex(elem, i);
            if (dst[index] == null)
            {
                dst[index] = elem;
                break;
            }
            else {
                if (dst[index].Equals(elem))
                    break;
            }
            i++;
        }
    }
    
    private bool LookupRemove(Object elem, bool remove)
    {
        var i = 0;
        for(; ;) {
            var index = GetIndex(elem, i);
            var item = data[index];
            if (item == null)
                return false;
            if (elem.Equals(item))
            {
                if (remove)
                    data[index] = null;
                return true;
            }
            i++;
        }
    }

    private void Resize()
    {
        capacity *= 2;
        var new_data = new Object?[capacity];
        foreach (var item in data)
        {
            if (item != null) {
                InsertInto(item, new_data);        
            }   
        }
        data = new_data;
    }

    private Int64 GetIndex(Object elem, int i)
    {
        return ((elem.GetHashCode() % capacity + capacity) % capacity + c * i + d * i * i) % capacity;
    }
}


// Task 2
struct Pair<T, U> {
    public T First { get; private set; }
    public U Second { get; private set; }

    Pair(T value1, U value2) { 
        First = value1;
        Second = value2;
    }
    public static Pair<T, U> MakePair(T value1, U value2) {
        return new Pair<T, U> (value1, value2);
    }
    public Pair<T, U> GetPairModifiedFirst(T value) { 
        return new Pair<T, U> (value, Second);
    }

    public Pair<T, U> GetPairModifiedSecond(U value)
    {
        return new Pair<T, U>(First, value);
    }
}

// Task 3
struct Person { 
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }
    public Person(string first, string second) {
        FirstName = first;
        SecondName = second;
    }

}

struct Worker
{
    public Person Person { get; private set; }

    public Worker(Person p) {
        Person = p;
    }
    public int GetSalary()
    {
        return Person.FirstName.Length * 31 + Person.SecondName.Length * 51;
    }
}

/* 
 var p = new Person ("John", "Doe" );
 var w = new Worker (p);
 Console.WriteLine(w.Person.FirstName);
 Console.WriteLine(w.GetSalary());
 */


// Task 4
class DiceRoller
{
    public static int DiceRoll(int n, int m)
    {
        var dp = new int[n + 1, m + 1];
        dp[0, 0] = 1;

        for (var i = 1; i <= n; i++)
        {
            for (var j = i; j <= m; j++)
            {
                for (var p = 1; p <= 6; p++)
                {
                    if (j >= p)
                    {
                        dp[i, j] += dp[i - 1, j - p];
                    }
                }

            }
        }
        return dp[n, m];
    }
}

// Task 5
class WaterSaver
{
    public static int HowMuch(int[] h)
    {
        int l = 0;
        int r = h.Length - 1;
        int max_l = h[l];
        int max_r = h[r];
        var res = 0;
        while (l + 1 < r)
        {
            if (max_l < max_r)
            {
                res += Math.Max(max_l - h[l + 1], 0);
                l++;
                max_l = Math.Max(max_l, h[l]);

            }
            else
            {
                res += Math.Max(max_r - h[r - 1], 0);
                r--;
                max_r = Math.Max(max_r, h[r]);
            }
        }
        return res;
    }
}