
Console.WriteLine(FracSimplifier.Simplify("4/6") == "2/3");
Console.WriteLine(FracSimplifier.Simplify("10/11") == "10/11");
Console.WriteLine(FracSimplifier.Simplify("100/400") == "1/4");
Console.WriteLine(FracSimplifier.Simplify("8/4") == "2");




class FracSimplifier
{
    public static string Simplify(string arg)
    {
        var ab = arg.Split("/");
        var a = int.Parse(ab[0]);
        var b = int.Parse(ab[1]);
        var d = gcd(a, b);
        a /= d;
        b /= d;
        return b != 1 ? a.ToString() + "/" + b.ToString() : a.ToString();
    }

    private static int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }
}
