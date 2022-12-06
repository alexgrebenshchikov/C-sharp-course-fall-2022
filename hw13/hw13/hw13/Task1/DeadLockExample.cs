using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13.Task1
{
    class DeadLockExample
    {
        private Mutex mutexA = new();
        private Mutex mutexB = new();
        void ThreadRoutine1()
        {
            mutexA.WaitOne();
            Console.WriteLine("t1 takes mutexA");
            Thread.Sleep(1000);
            mutexB.WaitOne();
            Console.WriteLine("t1 takes mutexB");
            mutexB.ReleaseMutex();
            mutexA.ReleaseMutex();
        }

        void ThreadRoutine2()
        {
            mutexB.WaitOne();
            Console.WriteLine("t2 takes mutexB");
            Thread.Sleep(1000);
            mutexA.WaitOne();
            Console.WriteLine("t2 takes mutexA");
            mutexA.ReleaseMutex();
            mutexB.ReleaseMutex();
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
