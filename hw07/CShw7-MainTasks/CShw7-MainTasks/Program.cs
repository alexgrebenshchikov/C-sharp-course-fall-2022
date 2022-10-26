namespace maintasks {

    class MainTasks {
        public static string Task1(List<Element> seq, char delimiter)
        {
            return seq.Count switch
            {
                <= 3 => "",
                _ => seq
                    .Skip(3)
                    .Select(elem => elem.Name)
                    .Aggregate((acc, name) => acc + delimiter + name)
            };
        }

        public static IEnumerable<Element> Task2(IEnumerable<Element> seq)
        {
            return seq
                .Where((elem, index) => elem.Name.Length > index);
        }

        public static List<List<string>> Task3(string sentence)
        {
            const string punct = ":;,?.!-()\"'";
            var filteredSent = sentence.Where(c => !punct.Contains(c));
            
            return string.Join("", filteredSent)
                .Split(" ")
                .GroupBy(word => word.Length)
                .Where(group => group.Any(word => word.Length > 0))
                .Select(group => group.ToList())
                .OrderByDescending(group => group.Count)
                .ThenByDescending(group => group.First().Length)
                .ToList();
        }

        public static IEnumerable<string> Task4(int n, List<string> enWords, Dictionary<string, string> dict)
        {
            return enWords
                .Select(word => dict[word].ToUpper())
                .Chunk(n)
                .Select(chunk => string.Join(" ", chunk));
        }

        public static IEnumerable<string> Task5(string sent, int limit)
        {
            return sent.Split(" ").Aggregate((new List<String>(), true), (acc, word) => {
                var (chunks, success) = acc;
                if(!success)
                    return (new List<string>(), false);
                if (chunks.Count > 0 && chunks.Last().Length + word.Length + 1 <= limit)
                    chunks[^1] += " " + word;
                else if (word.Length <= limit)
                    chunks.Add(word);
                else
                    return (new List<string>(), false);
                return (chunks, true);
            }).Item1;
        }
    }


    public class Element
    {
        public string Name { get; private set; }

        public Element(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return "Element(" + Name + ")";
        }
    }

    class Program {
        public static void Main(string[] args) {
            var res = MainTasks.Task3("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");
            foreach (var group in res)
            {
                Console.WriteLine("Длина " + group.First().Length + ", Количество " + group.Count);
                Console.WriteLine(string.Join("\n", group) + "\n");
            }
        }
    }
}
