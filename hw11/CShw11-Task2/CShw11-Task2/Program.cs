using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Text;

namespace task2 {
    class Solution {
        public static string Permutations(string input) { 
            var charsSet = new SortedSet<char>();
            input.ToList().ForEach(c => charsSet.Add(c));
            if(input.Length != charsSet.Count)
                return "";
            var res = new List<string>();
            GeneratePermutations(res, "", charsSet);
            return String.Join(" ", res);
        }

        private static void GeneratePermutations(List<string> res, string cur, SortedSet<char> charSet) {
            
            if (charSet.Count == 0) {
                res.Add(cur);
            }
            foreach (char c in charSet.ToList()) { 
                charSet.Remove(c);
                GeneratePermutations(res, cur + c, charSet);
                charSet.Add(c);
            }
        }
    }
    class Program {
        public static void Main(string[] args) {
            var inputs = new List<string> { "ABC", "RAM", "YAW", "NAVI" };
            foreach (var input in inputs) { 
                Console.WriteLine(Solution.Permutations(input));
            }
        }
    }
}
