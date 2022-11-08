using System.Text;

const long n = 100_000_000;
const long flushRate = 10_000_000;
const long k = 50_376_689;
const long sh = 2_171_327;
const int length = 8;

using Stream s = new FileStream("many_nums.txt", FileMode.Create);
for (long i = 1; i <= n; ++i)
{
    var number = (i * k + sh) % n;
    var line = new string('0', length - number.ToString().Length) + number + "\n";
    s.Write(Encoding.ASCII.GetBytes(line));
    if (i % flushRate == 0)
    {
        s.Flush();
    }
}
