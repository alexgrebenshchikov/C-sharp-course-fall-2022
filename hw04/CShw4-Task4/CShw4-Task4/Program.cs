namespace task4
{

    public class Hamster : IComparable
    {
        private readonly int _age;
        private readonly int _weight;
        private readonly int _height;
        private readonly int _wool;

        private Hamster(int age, int weight, int height, int wool)
        {
            _age = age;
            _weight = weight;
            _height = height;
            _wool = wool;
        }

        public override string ToString()
        {
            return "Hamster(" + _age + ", " + _weight + ", " + _height + ", " + _wool + ")";
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Hamster other)
                return 1;

            return (int)Math.Floor((_age - other._age) * 0.2 + (_weight - other._weight) * 0.3 + (other._height - _height) * 0.1 + (_wool - other._wool) * 0.4);
        }

        public static Hamster CreateRandom()
        {
            var random = new Random();
            return new Hamster(
                age: Math.Abs(random.Next()) % 730,
                weight: Math.Abs(random.Next()) % 65,
                height: Math.Abs(random.Next()) % 10,
                wool: Math.Abs(random.Next()) % 5
            );
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var hamsters = Enumerable
            .Repeat(0, 7)
            .Select(_ => Hamster.CreateRandom())
            .ToList();

            Console.WriteLine("Before sort");
            hamsters.ForEach(hamster => Console.WriteLine(hamster));

            hamsters.Sort();

            Console.WriteLine("\nAfter sort");
            hamsters.ForEach(hamster => Console.WriteLine(hamster));
        }
    }



}
