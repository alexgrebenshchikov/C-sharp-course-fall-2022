using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13.Task5
{
    class PiCalculation
    {
        private volatile bool isInterrupted = false;
        private List<Thread> threads = new List<Thread>();
        private volatile double[] partialSums = new double[] { };
        private volatile List<List<double>> snapshots = new List<List<double>>();
        private const int N_ITER = 10000000;
        public PiCalculation(int nThreads)
        {
            partialSums = new double[nThreads];
            for (int i = 0; i < nThreads; i++)
            {
                snapshots.Add(new List<double>());
                var threadRoutine = (int tn) =>
                {
                    int j = tn;
                    int iter = 0;
                    while (true)
                    {
                        
                        var sign = j % 2 == 0 ? 1.0 : -1.0;
                        partialSums[tn] += sign * 1 / (2 * j + 1);
                        j += nThreads;
                        iter++;
                        if (iter % N_ITER == 0)
                        {
                            snapshots[tn].Add(partialSums[tn]);
                            if (isInterrupted)
                            {
                                break;
                            }
                        }
                    }
                };

                var tr = new ThreadRoutine(i, (Action<int>)threadRoutine.Clone());
                threads.Add(new Thread(() => tr.Run() ));
            }
        }

        class ThreadRoutine {
            private int tn;
            private Action<int> routine;
            public ThreadRoutine(int tn, Action<int> routine)
            {
                this.tn = tn;
                this.routine = routine;
            }

            public void Run() {
                routine(tn);
            }
        }

        public void Start() {
            foreach (var thread in threads) {
                thread.Start();
            }
        }

        public double StopAndGetResult()
        {
            isInterrupted = true;
            foreach (var thread in threads)
            {
                thread?.Join();
            }
            var minIters = snapshots.MinBy((list) => list.Count).Count;
            return snapshots.Select((list) => list[minIters - 1]).Sum() * 4;
        }
    }
}
