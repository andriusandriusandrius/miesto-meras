namespace miesto_meras.Models
{
    public class City
    {
        protected string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name cannot be null");
                _name = value;
            }
        }
        protected int _population;
        public int Population
        {
            get => _population;
            set
            {
                if (value <= 0) throw new ArgumentException("Population cannot be negative or 0");
                _population = value;
            }
        }
        protected int _gold;
        public int Gold
        {
            get => _gold;
            set
            {
                if (value <= 0) throw new ArgumentException("Gold cannot be negative or 0");
                _gold = value;
            }
        }
        protected int _happiness;
        public int Happiness
        {
            get => _happiness;
            set
            {
                if (value <= 0) throw new ArgumentException("Happiness cannot be negative or 0");
                _happiness = value;
            }

        }

        public List<GameEvent> GameEvents { get; set; } = new();
        public Dictionary<string, int> Buildings { get; set; } = new();
        public City(string Name, int Population, int Gold, int Happiness)
        {
            _name = Name;
            _population = Population;
            _gold = Gold;
            _happiness = Happiness;
        }
        public void Display()
        {
            Console.WriteLine($"=====MIESTAS=====");
            Console.WriteLine($"Miesto pavadinimas: {Name}");
            Console.WriteLine($"Populiacija: {Population}");
            Console.WriteLine($"Auksas: {Gold}");
            Console.WriteLine($"Laimė: {Happiness}");
            foreach (var building in Buildings)
            {
                Console.WriteLine($"{building.Key}: {building.Value}");
            }
            Console.WriteLine($"=================\n");
        }

    }
}