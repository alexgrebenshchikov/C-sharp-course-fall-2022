using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Task1
{
    class BearAndBees
    {
        int cnt = 0;

        void BeeWork(int beeIndex, int maxHoney)
        {
            var random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next() % 100);

                lock (this)
                {
                    if (cnt < maxHoney)
                    {
                        cnt++;
                        Console.WriteLine("Bee " + beeIndex + ", Honey = " + cnt);
                        Monitor.PulseAll(this);
                    }
                }
            }
        }

        void BearWork(int maxHoney)
        {
            while (true)
            {
                lock (this)
                {
                    while (cnt < maxHoney)
                    {
                        Monitor.Wait(this);
                    }

                    cnt = 0;
                    Console.WriteLine("Bear, Honey = 0");
                }
            }
        }

        public void Simulate(int nBees, int maxHoneyPortions)
        {
            for (var i = 0; i < nBees; ++i)
            {
                var beeIndex = i;
                Task.Run(() => BeeWork(beeIndex, maxHoneyPortions));
            }
            Task.Run(() => BearWork(maxHoneyPortions)).Wait();
        }
    }
}
