using System.Runtime.ExceptionServices;

namespace Task2 {
    class Program {
        public static void Main(string[] args) {
            ExceptionDispatchInfo? dispatchInfo = null;
            try
            {
                var div = 0;
                var undef = 0 / div;
                Console.WriteLine(undef);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Message: '{0}'", ex.Message);
                dispatchInfo = ExceptionDispatchInfo.Capture(ex);
            }

            try
            {
                dispatchInfo?.Throw();
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Message: '{0}'", ex.Message);
            }

        }
    }
}
