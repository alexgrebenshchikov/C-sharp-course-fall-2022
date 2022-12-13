using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14.Task1
{
    class Race
    {
        private volatile int _cnt = 0;
        void Routine() {
            for (int i = 0; i < 100000; i++)
            {
                _cnt++;
            }
        }
        public int Run() { 
            var t1 = new Thread(Routine);
            var t2 = new Thread(Routine);
            t1.Start(); 
            t2.Start();
            t1.Join();
            t2.Join();
            return _cnt;
        }
    }
}
