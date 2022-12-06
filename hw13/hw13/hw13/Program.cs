// See https://aka.ms/new-console-template for more information
using hw13.Task1;
using hw13.Task2;
using hw13.Task5;

namespace hw13
{
    class Program
    {
        public static void Task1() {
            new DeadLockExample().Run();
        }
        public static void Task2() {
            new SynchronizedOutput().Run();
        }

        public static void Task5() {
            var calculator = new PiCalculation(4);
            calculator.Start();
            while (true) {
                var input = Console.ReadLine();
                if(input == "stop")
                    break;
            }
            var res = calculator.StopAndGetResult();
            Console.WriteLine(res);
        }
        public static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task5();
        }
    }
}
