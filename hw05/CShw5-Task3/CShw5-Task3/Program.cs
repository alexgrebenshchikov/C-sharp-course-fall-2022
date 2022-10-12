namespace task3 {
    class Solution {
        public static int SunLoungers(string initial) {
            var padded_initial = "0" + initial + "0";
            return padded_initial.Split("1")
                .Select(gap => gap.Length)
                .Where(length => length != 0)
                .Select(length => (length - 1) / 2)
                .Sum();
        }
    }

    class Program {
        public static void Main(string[] args) {
            string[] inputs = { "0", "00", "000", "10001", "00101", "010101010" }; // 1 1 2 1 1 0
            foreach (string input in inputs) {
                Console.Write(string.Format("{0}, ", Solution.SunLoungers(input)));
            }
        }
    }

}
