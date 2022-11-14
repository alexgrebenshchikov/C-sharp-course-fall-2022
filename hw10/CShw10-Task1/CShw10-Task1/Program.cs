using System.Reflection;

namespace task1
{
    public class BlackBox
    {
        private int innerValue;
        private BlackBox(int innerValue)
        {
            this.innerValue = innerValue;
        }
        private BlackBox()
        {
            this.innerValue = 42;
        }
        private void Add(int addend)
        {
            this.innerValue += addend;
        }
        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }
        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }
        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var blackBoxT = typeof(BlackBox);
            var blackBox = (BlackBox)blackBoxT
                .GetConstructor(bindingFlags, null, Array.Empty<Type>(), null)!
                .Invoke(null);

            while (true)
            {
                var input = Console.ReadLine()!;
                var cmdArg = input.Split('(', ')');
                var cmdName = cmdArg[0];
                var arg = int.Parse(cmdArg[1]);

                var cmd = blackBoxT.GetMethod(cmdName, bindingFlags);
                if (cmd == null)
                {
                    Console.WriteLine("No such method in the blackbox: {0}", cmdName);
                    continue;
                }
                cmd.Invoke(blackBox, new object[] { arg });

                var innerValue = (int)blackBoxT
                    .GetField("innerValue", bindingFlags)!
                    .GetValue(blackBox)!;
                Console.WriteLine(innerValue);
            }
        }
    }
}