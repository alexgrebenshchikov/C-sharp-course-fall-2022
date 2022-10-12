namespace task1 {
    public interface Publisher
    {
        public event Action OnPost;

        public void Post();

        public void ClearObservers();
    }

    public class PublisherImpl1 : Publisher
    {
        public event Action OnPost = delegate { };

        public void Post()
        {
            Console.WriteLine("Publisher #1 posted");
            OnPost.Invoke();
        }

        public void ClearObservers()
        {
            OnPost = delegate { };
        }
    }

    public class PublisherImpl2 : Publisher
    {
        public event Action OnPost = delegate { };

        public void Post()
        {
            Console.WriteLine("Publisher #2 posted");
            OnPost.Invoke();
        }

        public void ClearObservers()
        {
            OnPost = delegate { };
        }
    }


    public interface Observer
    {
        public void OnEvent();
    }

    public class ObserverImpl1 : Observer
    {
        public void OnEvent()
        {
            Console.WriteLine("Event handled by Observer #1");
        }
    }

    public class ObserverImpl2 : Observer
    {
        public void OnEvent()
        {
            Console.WriteLine("Event handled by Observer #2");
        }
    }

    public class EventBus
    {
        public Dictionary<string, Publisher> Publishers { get; private set; }

        public EventBus()
        {
            Publishers = new Dictionary<string, Publisher>();
        }

        public void AddPublisher(string id, Publisher publisher)
        {
            Publishers[id] = publisher;
        }

        public void RemovePublisher(string id)
        {
            Publishers[id].ClearObservers();
            Publishers.Remove(id);
        }

        public void Observe(string id, Observer subscriber)
        {
            Publishers[id].OnPost += subscriber.OnEvent;
        }

        public void RemoveObserve(string id, Observer subscriber)
        {
            Publishers[id].OnPost -= subscriber.OnEvent;
        }
    }

    class Program {
        public static void Main(string[] args) {
            var observer1 = new ObserverImpl1();
            var observer2 = new ObserverImpl2();

            var publisher1 = new PublisherImpl1();
            var publisher2 = new PublisherImpl2();

            var eventBus = new EventBus();
            const string pubId1 = "#1";
            const string pubId2 = "#2";
            eventBus.AddPublisher(pubId1, publisher1);
            eventBus.AddPublisher(pubId2, publisher2);

            eventBus.Observe(pubId1, observer1);
            eventBus.Observe(pubId2, observer2);

            publisher1.Post();
            publisher2.Post();
            
            

            eventBus.RemoveObserve(pubId2, observer2);
            eventBus.Observe(pubId2, observer1);
            publisher2.Post();
            
        }
    }

}


