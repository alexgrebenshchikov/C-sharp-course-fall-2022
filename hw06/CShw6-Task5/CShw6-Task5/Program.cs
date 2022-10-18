namespace task5 {

    public class Sparse3DArray<T> : IEnumerable<T>
    {
        private Dictionary<Tuple<int, int, int>, T> data;

        public Sparse3DArray()
        {
            data = new Dictionary<Tuple<int, int, int>, T>();
        }

        public T this[int i, int j, int k]
        {
            get => data[new Tuple<int, int, int>(i, j, k)];
            set => data[new Tuple<int, int, int>(i, j, k)] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var (_, value) in data)
            {
                yield return value;
            }
        }

     

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program {
        public static void Main(string[] args) {
            var arr = new Sparse3DArray<int>
            {
                [101, 4, 23] = 328,
                [26, 117, 122] = 280,
                [33798211, 33224982, 17979331] = -12566743,
                [3371, 11224982, 93331] = 43,
            };

            Console.WriteLine(string.Join(", ", arr));

            arr[10, 22, 333] = 9173;
            
            
            Console.WriteLine(string.Join(", ", arr));

        }
     }
}
