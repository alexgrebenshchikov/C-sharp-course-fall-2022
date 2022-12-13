using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14.Task2
{
    class SequentialPrinter
    {
        int counter;
        object locker;

        void Print(int order, Action action)
        {
            lock (locker)
            {
                while (counter < order)
                    Monitor.Wait(locker);
                action();
                counter += 1;
                Monitor.PulseAll(locker);
            }
        }

        public void Run()
        {
            counter = 0;
            locker = new object();

            var t1 = new Thread(() => Print(0, Foo.First));
            var t2 = new Thread(() => Print(1, Foo.Second));
            var t3 = new Thread(() => Print(2, Foo.Third));
            var threads = new List<Thread> { t1, t2, t3 };

           
            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());

            Console.WriteLine();
        }
    }
}
