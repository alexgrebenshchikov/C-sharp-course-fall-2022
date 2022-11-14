using System.Reflection;

namespace task2 {
    public class Custom : Attribute
    {
        public string AuthorName { get; }
        public int RevisionNumber { get; }
        public string Description { get; }
        public string[] Reviewers { get; }

        public Custom(string authorName, int revisionNumber, string description, params string[] reviewers)
        {
            AuthorName = authorName;
            RevisionNumber = revisionNumber;
            Description = description;
            Reviewers = reviewers;
        }

        public override string ToString()
        {
            return string.Format("Custom({0}, {1}, {2}, [{3}])", AuthorName, RevisionNumber, Description, string.Join(", ", Reviewers));
        }
    }



    [Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
    public class HealthScore
    {
        [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
        public static long CalcScoreData() {
            return 0;
        }

    }

    class Program {
        public static void Main(string[] args) {
            var healthScoreT = typeof(HealthScore);

            Console.WriteLine("HealthScore class attributes:");
            healthScoreT.GetCustomAttributes().ToList().ForEach(Console.WriteLine);

            Console.WriteLine("HealthScore methods:");
            foreach (var method in healthScoreT.GetMethods())
            {
                Console.WriteLine("- " + method.Name);
                foreach (var attr in method.GetCustomAttributes())
                {
                    if (attr is Custom)
                        Console.WriteLine("  " + attr);
                }
            }
        }
    }
}
