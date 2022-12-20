using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Task4
{
    public class ParallellMergeSort
    {
        void Sort(ref List<int> elementsToSort, int startIndex, int len)
        {
            len = Math.Min(len, elementsToSort.Count - startIndex);
            elementsToSort.Sort(startIndex, len, Comparer<int>.Default);
            Thread.Sleep(500);
        }

        List<int> Merge(IReadOnlyList<int> left, IReadOnlyList<int> right)
        {
            var result = new List<int>();
            var (leftIndex, rightIndex) = (0, 0);

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex]) {
                    result.Add(left[leftIndex++]);
                } else {
                    result.Add(right[rightIndex++]);
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex++]);
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex++]);
            }

            return result;
        }

        public List<int> MergeSort(List<int> input, int nThreads)
        {
            var segLen = (input.Count + nThreads - 1) / nThreads;

            var result = new List<int>();
            var finishedTasks = new ConcurrentQueue<int>();

            var tasks = new List<Task>();
            for (var i = 0; i < nThreads; ++i)
            {
                var startIndex = i * segLen;
                var task = Task.Run(() =>
                {
                    Sort(ref input, startIndex, segLen);
                });
                task.ContinueWith(_ =>
                {
                    lock (this)
                    {
                        finishedTasks.Enqueue(startIndex);
                        Monitor.Pulse(this);
                    }
                });
                tasks.Add(task);
            }

            while (result.Count != input.Count)
            {
                lock (this)
                {
                    while (finishedTasks.IsEmpty)
                    {
                        Monitor.Wait(this);
                    }
                    if (finishedTasks.TryDequeue(out var startIndex))
                    {
                        var realSegLen = Math.Min(segLen, input.Count - startIndex);
                        var sortedBatch = input.GetRange(startIndex, realSegLen);
                        result = Merge(result, sortedBatch);
                    }
                }
            }

            Task.WaitAll(tasks.ToArray());
            return result;
        }
    }
}
