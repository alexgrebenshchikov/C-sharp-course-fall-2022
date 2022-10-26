namespace maxmin {

    class Solution {
        static List<char> Swap(int i, int j, List<char> list)
        {
            var result = new List<char>(list);
            (result[i], result[j]) = (result[j], result[i]);
            return result;
        }

        static ulong CharsListToUlong(List<char> digits)
        {
            return ulong.Parse(string.Join("", digits));
        }

        public static (ulong, ulong) MaxMin(ulong number)
        {
            var digits = number.ToString().ToList();

            var perms = new List<ulong> { number };
            for (var i = 0; i < digits.Count; i++)
            {
                for (int j = i + 1; j < digits.Count; j++)
                {
                    var newDigits = Swap(i, j, digits);
                    if (newDigits[0] == '0')
                        continue;
                    perms.Add(CharsListToUlong(newDigits));
                }
            }

            return (perms.Max(), perms.Min());
        }
    }
    
    
    class Program {
        public static void Main(string[] args) {
            var inputs = new ulong[]{ 12340, 98761, 9000, 11321 };
            foreach (var input in inputs) {
                Console.WriteLine(Solution.MaxMin(input));
            }
        }
    
    }

}
