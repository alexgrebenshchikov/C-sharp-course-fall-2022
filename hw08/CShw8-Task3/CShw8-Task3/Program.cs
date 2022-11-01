namespace task3 {
    class Solution {
        public static bool isDifferentInOneChar(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;
            if (s1.Length > s2.Length)
                (s1, s2) = (s2, s1);

            var pos = 0;
            for (; pos < s1.Length; pos++)
            {
                if (s1[pos] != s2[pos])
                    break;
            }

            if (pos == s1.Length)
                return s2.Length > s1.Length;

            string suf1;
            string suf2;

            if (s1.Length == s2.Length)
            {
                suf1 = s1.Substring(pos + 1, s1.Length - pos - 1);
                suf2 = s2.Substring(pos + 1, s2.Length - pos - 1);
            }
            else
            {
                suf1 = s1.Substring(pos, s1.Length - pos);
                suf2 = s2.Substring(pos + 1, s2.Length - pos - 1);
            }

            return suf1 == suf2;
        }
    }

    class Program {
        public static void Main(string[] args) {
            var s1 = "lenakukacrew";
            var s2 = "lnakukacrew";
            var s3 = "lenaakukacrew";
            var s4 = "lunakukacrew";
            Console.WriteLine(Solution.isDifferentInOneChar(s1, s2));
            Console.WriteLine(Solution.isDifferentInOneChar(s1, s3));
            Console.WriteLine(Solution.isDifferentInOneChar(s1, s4));
        }
    }
}
