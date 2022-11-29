namespace task2 {


    public enum Allergen
    {
        Eggs = 1,
        Peanuts = 2,
        Shellfish = 4,
        Strawberries = 8,
        Tomatoes = 16,
        Chocolate = 32,
        FlowerPollen = 64,
        Cats = 128,
        Unknown = 256
    }
    public class PersonAllergies
    {
        public string Name { get; }

        public int Score { get; set; }

        public PersonAllergies(string name)
        {
            Name = name;
            Score = 0;
        }

        public PersonAllergies(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public PersonAllergies(string name, string allergies)
        {
            Name = name;
            Score = ScoreFromString(allergies);
        }

        public override string ToString()
        {
            if (Score == 0)
                return Name + " doesn't have allergies";
            return Name + " is allergic to: " + AllergiesToString(AllergensFromScore(Score));
        }

        public bool IsAllergicTo(Allergen allergen) =>
            AllergensFromScore(Score).Contains(allergen);

        public bool IsAllergicTo(string allergen) =>
            IsAllergicTo(AllergenFromString(allergen));

        public void AddAllergy(Allergen allergen) =>
            Score += (int)allergen;

        public void AddAllergy(string allergen) =>
            AddAllergy(AllergenFromString(allergen));

        public void DeleteAllergy(Allergen allergen) =>
            Score -= (int)allergen;

        public void DeleteAllergy(string allergen) =>
            DeleteAllergy(AllergenFromString(allergen));


       
        private static List<Allergen> AllergensFromScore(int score)
        {
            var res = new List<Allergen>();
            for (var allergyValue = (int)Allergen.Unknown; allergyValue > 0; allergyValue /= 2)
            {
                if (score - allergyValue < 0)
                    continue;
                score -= allergyValue;
                res.Add((Allergen)allergyValue);
            }
            res.Reverse();
            return res;
        }

        private static int ScoreFromString(string allergiesString)
        {
            var res = 0;
            foreach (var s in allergiesString.Split(" ")) {
                res += (int)AllergenFromString(s);
            }
            return res;        
        }

        private static string AllergiesToString(List<Allergen> allergens) =>
            string.Join(", ", allergens);

        private static Allergen AllergenFromString(string allergenString) =>
            Enum.TryParse(allergenString, out Allergen allergy) ? allergy : Allergen.Unknown;
    }

    class Profram {
        public static void Main(String[] args)
        {
            var mary = new PersonAllergies("Mary");
            var joe = new PersonAllergies("Joe", 65);
            var rob = new PersonAllergies("Rob", "Peanuts Chocolate Cats Strawberries");
            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
        }
    }
}
