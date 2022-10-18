using System.Collections;

namespace task1 {
    class Lake : IEnumerable<int>
    {
        public int[] Rocks { get; private set; } 

        public Lake(int[] rocks)
        {
            Rocks = rocks;
        }

        public IEnumerator<int> GetEnumerator()
        {
            var i = 0;
            for (; i < Rocks.Length; i += 2) { 
                yield return Rocks[i];
            }
            i = Rocks.Length % 2 == 0 ? i - 1 : i - 3;
            for (; i >= 0; i -= 2)
            {
                yield return Rocks[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program {
        public static void Main(string[] args) {
            var lake = new Lake(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            foreach(var r in lake) { 
                Console.Write("{0} ", r);
            }
            Console.WriteLine();

            var lake2 = new Lake(new int[] {  13, 23, 1, -8, 4, 9, 7 });
            foreach (var r in lake2)
            {
                Console.Write("{0} ", r);
            }
            Console.WriteLine();
        }

    }
}
