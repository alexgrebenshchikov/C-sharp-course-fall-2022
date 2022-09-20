// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.InteropServices;
using System.Text;


// Task 1
public class MyHashMap {
    public MyHashMap() {
        capacity = 16;
        data = GetInitializedData();
        size = 0;
    }
    private LinkedList<Object>[] data;
    private Int64 capacity;
    private Int64 size;
    private const double resize_factor = 0.75;
    public void Insert(Object elem)
    {
        data[GetIndex(elem)].AddLast(elem);
        size++;
        if (size / (double)capacity > resize_factor) {
            Resize();
        }
    }

    public bool Lookup(Object elem) {
        return LookupRemove(elem, false);
    }

    public bool Remove(Object elem)
    {
        return LookupRemove(elem, true);
    }

    public void ShowElements()
    {
        foreach (var bucket in data)
        {
            foreach (var item in bucket)
            {
                Console.Write(String.Format("{0} ", item));
            }
        }
        Console.WriteLine();
    }
    private bool LookupRemove(Object elem, bool remove)
    {
        var bucket = data[GetIndex(elem)];
        foreach (var item in bucket) {
            if (elem.Equals(item))
            {
                if(remove)
                    bucket.Remove(item);
                return true;
            }
        }
        return false;
    }

    private void Resize() 
    {
        capacity *= 2;
        var new_data = GetInitializedData();
        foreach (var bucket in data) {
            foreach (var item in bucket) {
                new_data[GetIndex(item)].AddLast(item);
            }
        }
        data = new_data;
    }

    private LinkedList<Object>[] GetInitializedData() { 
        var new_data = new LinkedList<Object>[capacity];
        for (int i = 0; i < capacity; i++)
            new_data[i] = new LinkedList<Object>();
        return new_data;
    }

    private Int64 GetIndex(Object elem) { 
        return (elem.GetHashCode() % capacity + capacity) % capacity;
    }
}


// Task 2
class PasswordGenerator
{   public static string CreatePassword()
    {
        Random rnd = new Random();
        var length = rnd.Next(6, 21) - 4;
        const string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "1234567890";
        var res = new StringBuilder();
        res.Append(digits[rnd.Next(digits.Length)]);
        res.Append('_');
        for (int i = 0; i < 2; i++)
        {
            res.Append(upperLetters[rnd.Next(upperLetters.Length)]);
        }
        res.Append(digits[rnd.Next(digits.Length)]);
        while (0 < length--)
        {
            res.Append(lowerLetters[rnd.Next(lowerLetters.Length)]);
        }
        return res.ToString();
    }
}


// Task 3
class MyStack {
    public MyStack() {
        values = new LinkedList<Int64>();
        prefMins = new LinkedList<Int64>();
    }

    public void Push(Int64 elem) {
        if (values.Count == 0) { 
            prefMins.AddLast(elem);
        } else
        {
            prefMins.AddLast(Math.Min(elem, values.Last()));
        }
        values.AddLast(elem);
    }
    public Int64? GetMin() { 
        if(values.Count == 0)
            return null;
        return prefMins.Last();
    }

    public Int64? Pop() {
        if (values.Count == 0)
            return null;
        var res = values.Last();
        values.RemoveLast();
        prefMins.RemoveLast();
        return res;
    }
    private LinkedList<Int64> values;
    private LinkedList<Int64> prefMins;
}

