namespace task5 {

    class Solution {
        private static int CharCompare(char a, char b) {
            if (char.IsLetter(a) && char.IsDigit(b))
                return -1;
            if (char.IsDigit(a) && char.IsLetter(b))
                return +1;
            if (char.IsDigit(a) && char.IsDigit(b))
                return a.CompareTo(b);
            if (char.IsLower(a) && char.IsLower(b) || char.IsUpper(a) && char.IsUpper(b))
                return a.CompareTo(b);
            
            if (char.Equals(char.ToLower(a), char.ToLower(b)) && a != b)
                return char.IsLower(a) ? -1 : +1;
            
            return string.Compare(a.ToString(), b.ToString(), StringComparison.OrdinalIgnoreCase);
        }
        
        public static String SortString(String s) {
            var chars = s.ToList();
            chars.Sort(CharCompare);
            return String.Join("", chars);
        }
    }
    
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine(Solution.SortString("eA2a1E"));  // "aAeE12"
            Console.WriteLine(Solution.SortString("Re4r"));    // "erR4"
            Console.WriteLine(Solution.SortString("6jnM31Q")); // "jMnQ136"
            Console.WriteLine(Solution.SortString("846ZIbo")); // "bIoZ468" 
        }
    }
}
