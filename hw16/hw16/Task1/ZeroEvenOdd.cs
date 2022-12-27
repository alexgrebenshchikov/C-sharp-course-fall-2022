using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw16.Task1
{
    public class ZeroEvenOdd
    {
        private readonly int _n;

        private int _order = 1;

        public ZeroEvenOdd(int n)
        {
            _n = n;
        }

        public void Zero(Action<int> printNumber) =>
            CommonPart(2, 1, _ => printNumber(0));

        public void Even(Action<int> printNumber) =>
            CommonPart(4, 0, order => printNumber(order / 2));

        public void Odd(Action<int> printNumber) =>
            CommonPart(4, 2, order => printNumber(order / 2));

        private void CommonPart(int size, int cycleNum, Action<int> printNumberByOrder)
        {
            while (_order <= 2 * _n)
            {
                lock (this)
                {
                    while (_order % size != cycleNum)
                    {
                        Monitor.Wait(this);
                    }

                    if (_order <= 2 * _n)
                    {
                        printNumberByOrder(_order);
                    }

                    _order += 1;
                    Monitor.PulseAll(this);
                }
            }
        }
    }
}
