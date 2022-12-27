using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace hw16.Task3
{
    class H2OController
    {
        private int currentH = 0;
        private int currentO = 0;
        private int reqH = 2;
        private int reqO = 1;
        void ReleaseHydrogen()
        {
            lock (this)
            {
                while (!(currentH < reqH))
                {
                    Monitor.Wait(this);
                }

                Console.Write("H");
                currentH += 1;

                if (currentH == reqH && currentO == reqO)
                {
                    Console.Write(" ");
                    currentH = 0;
                    currentO = 0;
                    Monitor.PulseAll(this);
                }
            }
        }

        void ReleaseOxygen()
        {
            lock (this)
            {
                while (!(currentO < reqO))
                {
                    Monitor.Wait(this);
                }

                Console.Write("O");
                currentO += 1;

                if (currentH == reqH && currentO == reqO)
                {
                    currentH = 0;
                    currentO = 0;
                    Console.Write(" ");
                    Monitor.PulseAll(this);
                }
            }
        }

        public void MakeH2O(string input) {
            var h2o = new H2O();
            var tasks = input.Select(c => c == 'H' ? new Thread(() => h2o.Hydrogen(ReleaseHydrogen)) : new Thread(() => h2o.Oxygen(ReleaseOxygen))).ToList();
            foreach (var task in tasks) { 
                task.Start();
            }
            foreach (var task in tasks) { 
                task.Join();
            }
            Console.WriteLine();
        }
    }
}
