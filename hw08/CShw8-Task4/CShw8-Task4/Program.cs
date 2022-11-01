namespace task4 {
    class Solution {
        public static String MergeStrings(String s1, String s2) {
            var words1 = s1.Split(" ").ToList();
            var words2 = s2.Split(" ").ToList();
            var res = new List<string>();
            var pos1 = 0;
            var pos2 = 0;
            while (pos1 < words1.Count && pos2 < words2.Count)
            {
                if (words1[pos1] == words2[pos2])
                {
                    res.Add(words1[pos1]);
                    pos1++;
                    pos2++;
                    continue;
                }

                var sIndex = FindStringPos(words1[pos1], words2, pos2 + 1);
                if (sIndex == -1)
                {
                    res.Add(words1[pos1]);
                    pos1++;
                }
                else
                {
                    for (var i = pos2; i < sIndex; ++i)
                        res.Add(words2[i]);
                    pos2 = sIndex;
                }
            }

            for (; pos1 < words1.Count; ++pos1)
                res.Add(words1[pos1]);
            for (; pos2 < words2.Count; ++pos2)
                res.Add(words2[pos2]);

            return string.Join(" ", res);

        }

        private static int FindStringPos(String s, List<String> list, int pos) {
            var cur = pos;
            while (cur < list.Count) {
                if (list[cur] == s)
                    return cur;
                cur++;
            }
            return -1;
        }
    
    }
    
    
    class Program {
        public static void Main(string[] args) {
            var s1 = "Шла Маша по шоссе пешком";
            var s2 = "Шла Саша по горе";
            Console.WriteLine(Solution.MergeStrings(s1, s2));
        }
    }
}
