namespace task3
{

    public delegate double Function(double x);

    internal static class Program
    {
        private static double Integrate(Function f, double a, double b)
        {
            const int n = (int)1e5;

            double result = 0.0;
            double step = (b - a) / n;
            for (var i = 1; i <= n; i++)
            {
                double x1 = a + step * (i - 1);
                double x2 = i < n ? a + step * i : b;
                result += (f(x1) + f(x2)) / 2 * step;
            }
            return result;
        }

        public static void Main()
        {
            var constant = new Function(x => 2);
            var sin = new Function(Math.Sin);
            var exp = new Function(x => Math.Exp(x));

            Console.WriteLine(Integrate(constant, 0, 1));                       // ~ 2
            Console.WriteLine(Integrate(sin, 0, 2 * Math.PI));                  // ~ 0
            Console.WriteLine(Integrate(exp, 0, 1));                            // ~ e - 1
        }
    }
}