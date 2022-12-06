using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13.Task2
{
    public class SynchronizedOutput
    {
        private Mutex mutexA = new();
        private Mutex mutexB = new();
        private int cnt = 0;
        void ThreadRoutine1()
        {

            for (int i = 0; i < 10; i++)
            {
                mutexA.WaitOne();
                if (cnt % 2 == 0)
                {
                    Console.WriteLine("t1 out {0}", i);
                    cnt++;
                }
                mutexA.ReleaseMutex();
            }

        }

        void ThreadRoutine2()
        {

            for (int i = 0; i < 10; i++)
            {

                mutexA.WaitOne();
                if (cnt % 2 == 1)
                {
                    Console.WriteLine("t2 out {0}", i);
                    cnt++;
                }
                mutexA.ReleaseMutex();
            }

        }

        public void Run()
        {
            var t1 = new Thread(new ThreadStart(ThreadRoutine1));
            var t2 = new Thread(new ThreadStart(ThreadRoutine2));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
    }
}
