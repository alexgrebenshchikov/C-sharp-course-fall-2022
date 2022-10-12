using System.Globalization;
using System.Net.Mail;

namespace task4 {
    class PrimeFactor {
        private List<int> primes = new();
        private int MAX_N = 10000;

        public PrimeFactor()
        {
            var marks = new bool[MAX_N + 1];
            for (var i = 2; i <= MAX_N; i++) {
                if (!marks[i]) {
                    primes.Add(i);
                    for (var j = i; j <= MAX_N; j += i)
                    {
                        marks[j] = true;
                    }
                }
            }
        }
        
        public string ExpressFactors(int number) {
            var cur = number;
            var res = "";
            foreach (var p in primes) {
                var pow = 0;
                while (cur % p == 0) {
                    cur /= p;
                    pow++;
                }
                if (pow != 0) {
                    if (res.Length != 0)
                        res += " x ";
                    res +=  pow > 1 ? string.Format("{0}^{1}", p, pow) : p.ToString();
                }
                if (cur == 1)
                    break;
            }
            return res;
        }
    
    }

    class Program {
        public static void Main(string[] args) {
            var pf = new PrimeFactor();
            int[] inputs = { 2, 4, 10, 60, 1001, 2178 };
            foreach (var input in inputs) {
                Console.WriteLine(pf.ExpressFactors(input));
            }
        }
    }


}


