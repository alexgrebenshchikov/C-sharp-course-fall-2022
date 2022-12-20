using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Task3
{
    public class Barber
    {
        private readonly int _nChairs;
        private readonly ConcurrentQueue<Client> _clientQueue;

        private bool _isTerminated;
        private readonly Task _barberTask;

        public Barber(int nChairs)
        {
            _nChairs = nChairs;
            _clientQueue = new ConcurrentQueue<Client>();
            _isTerminated = false;
            _barberTask = Task.Run(Work);
        }

        public void AddClient(Client client)
        {
            if (_clientQueue.Count == _nChairs)
            {
                Console.WriteLine("Skipped " + client);
                return;
            }

            _clientQueue.Enqueue(client);
            Console.WriteLine("Added " + client);
            lock (this)
            {
                Monitor.Pulse(this);
            }
        }

        public void EndWork()
        {
            _isTerminated = true;
            _barberTask.Wait();
        }

        private void Work()
        {
            while (!(_isTerminated && _clientQueue.IsEmpty))
            {
                lock (this)
                {
                    while (_clientQueue.IsEmpty)
                    {
                        Monitor.Wait(this);
                    }
                }
                if (_clientQueue.TryDequeue(out var client))
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Served: " + client);
                }
            }
        }
    }
}
