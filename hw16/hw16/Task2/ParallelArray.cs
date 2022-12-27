using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw16.Task2
{
    public class ParallelArray
    {
        private readonly List<int> data;
        private readonly Random rnd;
        private bool isTerminated;
        private readonly ReaderWriterLockSlim rwLock;

        public ParallelArray(List<int> array)
        {
            data = array;
            isTerminated = false;
            rnd = new Random();
            rwLock = new ReaderWriterLockSlim();
        }

        public void ThreadAverage()
        {
            while (!isTerminated)
            {
                rwLock.EnterReadLock();
                var result = data.Average();
                Console.WriteLine("Average: " + result);
                rwLock.ExitReadLock();
                Thread.Sleep(50);
            }
        }

        public void ThreadMin()
        {
            while (!isTerminated)
            {
                rwLock.EnterReadLock();
                var result = data.Min();
                Console.WriteLine("Min: " + result);
                rwLock.ExitReadLock();
                Thread.Sleep(50);
            }
        }

        public void ThreadSwap()
        {
            while (!isTerminated)
            {
                rwLock.EnterWriteLock();
                var (i, j) = (rnd.Next(data.Count), rnd.Next(data.Count));
                (data[i], data[j]) = (data[j], data[i]);
                Console.WriteLine("Swap: {0}, {1}", i, j);
                rwLock.ExitWriteLock();
                Thread.Sleep(50);
            }
        }

        public void ThreadSort()
        {
            while (!isTerminated)
            {
                rwLock.EnterWriteLock();
                data.Sort();
                Console.WriteLine("Sort: [" + string.Join(", ", data) + "]");
                rwLock.ExitWriteLock();
                Thread.Sleep(50);
            }
        }

        public void Terminate()
        {
            isTerminated = true;
        }
    }
}
