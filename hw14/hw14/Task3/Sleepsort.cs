using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14.Task3
{
    class Sleepsort
    {
        public static void Sort(List<string> input) { 
            if(input.Count == 0 || input.Count > 100) return;
            var threads = new List<Thread>();
            foreach (var s in input) {
                var t = new Thread(() =>
                {
                    Thread.Sleep(s.Length * 50);
                    Console.WriteLine(s);
                });
                threads.Add(t);
            }
            threads.ForEach((t) => { t.Start(); });
            threads.ForEach((t) => { t.Join(); });
        }

        public static void Sort2(List<string> input)
        {
            if (input.Count == 0 || input.Count > 100) return;
            var threads = new List<Thread>();
            var res = new LinkedList<string>();
            object locker = new();
            foreach (var s in input)
            {
                var t = new Thread(() =>
                {
                    Thread.Sleep(s.Length * 50);
                    lock (locker) { 
                        res.AddLast(s);
                    }
                });
                threads.Add(t);
            }
            threads.ForEach((t) => { t.Start(); });
            threads.ForEach((t) => { t.Join(); });
            foreach (var s in res) {
                Console.WriteLine(s);
            }
        }
    }
}
