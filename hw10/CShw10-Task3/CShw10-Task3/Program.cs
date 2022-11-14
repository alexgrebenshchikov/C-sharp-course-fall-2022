namespace task3 {

    class Solution {
        static int GetPairMin((int, int) pair)
        {
            return Math.Min(pair.Item1, pair.Item2);
        }

        static int GetPairMax((int, int) pair)
        {
            return Math.Max(pair.Item1, pair.Item2);
        }

        static bool IsNested((int, int) e1, (int, int) e2)
        {
            return GetPairMax(e1) < GetPairMax(e2) && GetPairMin(e1) < GetPairMin(e2);
        }

        public static int MaxEnvelopesSeq(List<(int, int)> envelopes)
        {
            if (envelopes.Count == 0)
                return 0;

            envelopes.Sort((l, r) => GetPairMin(l).CompareTo(GetPairMin(r)));

            var maxSeq = new int[envelopes.Count];
            for (var i = 0; i < envelopes.Count; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (IsNested(envelopes[j], envelopes[i]) && maxSeq[j] + 1 > maxSeq[i])
                    {
                        maxSeq[i] = maxSeq[j] + 1;
                    }
                }
            }

            return maxSeq.Max() + 1;
        }

    }
    
    
    class Program 
    {
        public static void Main(string[] args) {
            Console.WriteLine(Solution.MaxEnvelopesSeq(new List<(int, int)> { (1, 1), (1, 1), (1, 1) }));
            Console.WriteLine(Solution.MaxEnvelopesSeq(new List<(int, int)> { (5, 4), (6, 4), (6, 7), (2, 3) }));
        }
    }
}
