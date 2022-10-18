namespace task2 {
    class Person
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return "Person(" + Name + ", " + Age + ")";
        }
    }

    class PersonComparerByName : IComparer<Person>
    {
        public int Compare(Person? p1, Person? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Null argument");
            if (p1.Name.Length != p2.Name.Length)
                return p1.Name.Length - p2.Name.Length;
            
            return p1.Name.Length == 0 ?
                0 : p1.Name.ToLower()[0].CompareTo(p2.Name.ToLower()[0]);
        }
    }

    class PersonComparerByAge : IComparer<Person>
    {
        public int Compare(Person? p1, Person? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Null argument");
            return p1.Age.CompareTo(p2.Age);
        }
    }

    class Program {
        public static void Main(string[] args) {
            var persons = new List<Person>()
            {
                new Person("Pepe", 11),
                new Person("Billy", 17),
                new Person("Ricardo", 31),
                new Person("Johny", 19),
                new Person("Joe", 20),
                new Person("Natasha", 21),
                new Person("Taylor", 22),
                new Person("Misha", 38),
            };

            persons.Sort(new PersonComparerByName());
            Console.WriteLine(string.Join("\n", persons));

            Console.WriteLine();

            persons.Sort(new PersonComparerByAge());
            Console.WriteLine(string.Join("\n", persons));
        }
    }
}
