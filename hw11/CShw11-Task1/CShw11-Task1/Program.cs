namespace task1 {
    public class Cache<T> where T : class, IDisposable
    {
        private Dictionary<int, T> _data;
        private Dictionary<int, DateTime> _lastAccessTime;

        private int _maxSize;
        private volatile bool _needToClear;
        private TimeSpan _maxTimeWithoutAccess;

        private int _nextId;
        private Thread _gcThread;
        private volatile bool _gcThreadIsCancelled = false;

        public int Count { get { return _data.Count; } } 
        

        public Cache(int maxSize, TimeSpan maxTimeWithoutAccess)
        {
            _data = new Dictionary<int, T>(capacity: maxSize);
            _lastAccessTime = new Dictionary<int, DateTime>(capacity: maxSize);
            _maxSize = maxSize;
            _needToClear = false;
            _maxTimeWithoutAccess = maxTimeWithoutAccess;
            _nextId = 0;
            

            GC.RegisterForFullGCNotification(10, 10);
            StartGcThread();
        }

        ~Cache()
        {
            Clear();
        }

        public int? Add(T element)
        {
            if (_needToClear || _data.Count >= _maxSize)
                Clear();
            if (_data.Count >= _maxSize)
                return null;

            _data[_nextId] = element;
            _lastAccessTime[_nextId] = DateTime.Now;
            return _nextId++;
        }

        public T? Get(int id)
        {
            if (_needToClear)
                Clear();
            if (!_data.ContainsKey(id))
                return null;

            _lastAccessTime[id] = DateTime.Now;
            return _data[id];
        }

        private void Clear()
        {
            foreach (var (id, dateTime) in _lastAccessTime)
            {
                var timeLeft = DateTime.Now - dateTime;
                if (timeLeft > _maxTimeWithoutAccess)
                {
                    _data[id].Dispose();
                    _data.Remove(id);
                    _lastAccessTime.Remove(id);
                }
            }
            
            if (_needToClear)
            {
                StartGcThread();
                _needToClear = false;
            }
        }

        private void StartGcThread()
        {
            _gcThread = new Thread(CheckTheGc);
            _gcThread.Start();
        }

        public void StopGcTHread() 
        {
            _gcThreadIsCancelled = true;
        }

        private void CheckTheGc()
        {
            while (!_gcThreadIsCancelled)
            {
                var status = GC.WaitForFullGCApproach();
                if (status == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("gc");
                    _needToClear = true;
                    break;
                }
            }
        }
    }

    class MyResource : IDisposable
    {
        private int _id;
        public MyResource(int id) {
            _id = id;
        }
        ~MyResource() { 
            Dispose();   
        }
        public void Dispose()
        {
            Console.WriteLine(string.Format("{0} disposed", this.ToString()));
        }
        public override string ToString()
        {
            return String.Format("MyResource({0})", _id);
        }
    }
    class Program {


        static void ClearAfterAddExample() 
        {
            const int maxSize = 4;
            var maxTimeSpan = new TimeSpan(0, 0, seconds: 1);
            var cache = new Cache<MyResource>(maxSize, maxTimeSpan);

            var myResources = new List<MyResource>();
            for (var i = 0; i < maxSize; ++i)
            {
                myResources.Add(new MyResource(i));
            }

            var idsInCache = new List<int>();
            foreach (var res in myResources)
            {
                var newId = cache.Add(res);
                idsInCache.Add(newId!.Value);
            }

            foreach (var id in idsInCache)
            {
                Console.WriteLine(cache.Get(id));
            }


            var nullId = cache.Add(new MyResource(5));
            Console.WriteLine(nullId != null ? nullId : "null");

            Thread.Sleep(maxTimeSpan);

            var notNullId = cache.Add(new MyResource(5));
            Console.WriteLine(notNullId);

            foreach (var id in idsInCache)
            {
                var elem = cache.Get(id);
                Console.WriteLine(elem != null ? elem : "null");
            }
            GC.CancelFullGCNotification();
            cache.StopGcTHread();
        }

        static void ClearAfterGc() 
        {
            var data = new List<int[]>();

            const int maxSize = 1000;
            var maxTimeSpan = new TimeSpan(0, 0, seconds: 1);
            var cache = new Cache<MyResource>(maxSize, maxTimeSpan);
            var cnt = 0;
            var prevSize = 0;
            while (true)
            {
                for (var i = 0; i < 10; i++)
                    data.Add(new int[10000000]);

                cache.Add(new MyResource(cnt++));
                Console.WriteLine("cache size:" + cache.Count);

                if (cache.Count < prevSize)
                    break;
                prevSize = cache.Count;
                if (cnt % 2 == 0) {
                    data = new List<int[]>();
                    GC.Collect();
                }
                Thread.Sleep(1000);
            }
        }
        
        public static void Main(string[] args) 
        {
           ClearAfterAddExample();
            //Не смог воспроизести ситуацию, в которой ловилось бы событие сборки мусора в CheckTheGc()(
            // Здесь сборка мусора происходит, но уведомление не ловится
            //ClearAfterGc();
        }
    }
}