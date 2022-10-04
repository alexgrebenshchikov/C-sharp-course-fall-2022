

using System.Diagnostics.Metrics;

interface Car { 
    int age { get; }
    int weight { get; }

    int height { get; }
}

class Pickup : Car
{
    public int age { get; }

    public int weight { get; }

    public int height { get; }

    public Pickup(int age, int height, int weight) { 
        this.age = age;
        this.weight = weight;
        this.height = height;
    }
}

abstract class Horse : IComparable<Horse>
{
    abstract public int age { get; }


    abstract public int weight { get; }

    abstract public int height { get; }

    public int CompareTo(Horse? other)
    {
        if (other == null) return 1;
        return (int)Math.Floor(((other.age - this.age) * 0.3 + (this.height - other.height) * 0.2 + (this.weight - other.weight) * 0.5));
    }

    public static bool operator >(Horse? a, Horse? b)
    {
        if (a == null) return b == null;
        return a.CompareTo(b) > 0;
    }

    public static bool operator <(Horse? a, Horse? b)
    {
        if (a == null) return b == null;
        return a.CompareTo(b) < 0;
    }

    public static bool operator ==(Horse? a, Horse? b)
    {
        if (a == null) return b == null;
        return a.CompareTo(b) == 0;
    }

    public static bool operator !=(Horse? a, Horse? b)
    {
        return !(a == b);
    }
}


class HeavyHorse : Horse
{
    public override int age { get; }

    public override int weight { get; }

    public override int height { get; }

    public HeavyHorse(int age, int weight, int height)
    {
        this.age = age;
        this.weight = weight;
        this.height = height; 
    }

    public static implicit operator HeavyHorse(Pickup p)
    {
        return new HeavyHorse(p.age, p.weight, p.height);
    }

    public static implicit operator Pickup(HeavyHorse h)
    {
        return new Pickup(h.age, h.weight, h.height);
    }
}



internal class Program
{
    public static void Main(string[] args)
    {
        var h1 = new HeavyHorse(10, 450, 200);
        var h2 = new HeavyHorse(8, 400, 210);
        var p1 = (Pickup)h1;
        Pickup p2 = h2;
    }
}
