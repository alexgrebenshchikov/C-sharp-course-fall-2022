namespace task5
{
    class LuckyTicketCounter {
        public static Int64 Count(int len) { 
            if(len % 2 != 0)
                return 0;
            var half = len / 2;
            var max_sum = half * 9;
            var dp = new Int64[half + 1, max_sum + 1];
            dp[0,0] = 1;
            for (var i = 1; i <= half; i++) {
                for (var j = 0; j <= max_sum; j++) {
                    for (var k = 0; k <= 9; k++)
                    {
                        if(j >= k)
                            dp[i, j] += dp[i - 1, j - k];
                    }
                }
            }
            Int64 answer = 0;
            for(var i = 0;i <= max_sum; i++)
            {
                answer += dp[half, i] * dp[half, i];
            }
            
            return answer;
        }
    }
    
    
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            int[] inputs = { 2, 4, 6 , 12};
            foreach (var input in inputs)
            {
                Console.WriteLine(LuckyTicketCounter.Count(input));
            }
        }

    }


}
