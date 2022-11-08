using System.Text;

Console.WriteLine(Rational(2, 5));
Console.WriteLine(Rational(1, 6));
Console.WriteLine(Rational(1, 3));
Console.WriteLine(Rational(1, 7));
Console.WriteLine(Rational(1, 77));
Console.WriteLine(Rational(0, 77));
Console.WriteLine(Rational(124201, 999000));


string Rational(int a, int b)
{
    if (a >= b)
        return "";
    if (a == 0)
        return "0";

    var res = new StringBuilder();
    var rems = new List<int>();

    res.Append(a / b);

    res.Append('.');
    rems.Add(a % b);

    a = a % b * 10;
    var havePeriod = false;
    var startInd = -1;
    while (a % b != 0)
    {
        startInd = rems.IndexOf(a % b);
        if (startInd != -1)
        {
            havePeriod = true;
            break;
        }
        res.Append(a / b);
        rems.Add(a % b);
        a = a % b * 10;
    }
    
    res.Append(a / b);
    
    if (!havePeriod)
        return res.ToString();

    var sRes = res.ToString();
    var beforePeriod = sRes[..(startInd + 2)];
    var period = sRes[(startInd + 2)..];
    return beforePeriod + "(" + period + ")";
}