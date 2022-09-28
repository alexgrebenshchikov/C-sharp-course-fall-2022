var examples = new List<Int64> { 4884, 1, 11, 3113, 8836886388 };
var answers = new List<(Int64, int)> { (69, 4), (1, 0), (10, 1), (199, 3), (177, 15) };
for (var i = 0; i < examples.Count; i++)
{
    Console.WriteLine(PalindromeEnjoyer.PalSeq(examples[i]) == answers[i]);
}

class PalindromeEnjoyer
{
    private static bool IsPalindrome(long n)
    {
        var s = n.ToString();
        for (var i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    public static (Int64, int)? PalSeq(Int64 pal)
    {
        if (pal < 10)
        {
            return (pal, 0);
        }

        for (Int64 start = 10; start < 1e4; start++)
        {
            var cnt = 0;
            var cur = start;
            while (cur < pal && !IsPalindrome(cur))
            {
                var rev = string.Join("", cur.ToString().Reverse());
                cur += Int64.Parse(rev);
                cnt += 1;
            }

            if (cur == pal)
            {
                return (start, cnt);
            }
        }
        return null;
    }
}

