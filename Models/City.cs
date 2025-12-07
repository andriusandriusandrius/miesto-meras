using miesto_meras.Models.Buildings;

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
                _population = value;
            }
        }
        protected int _gold;
        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
            }
        }
        protected int _happiness;
        public int Happiness
        {
            get => _happiness;
            set
            {
                _happiness = value;
            }

        }

        private readonly List<GameEvent> _gameEvents = new();
        public IReadOnlyList<GameEvent> GameEvents => _gameEvents;

        private readonly Dictionary<string, Building> _buildings = new();
        public IReadOnlyDictionary<string, Building> Buildings => _buildings;

        public void AddAvailableBuilding(string buildingName)
        {
            _buildings[buildingName] = BuildingFactory.Create(buildingName);
        }

        public void AddGameEvent(GameEvent e)
        {
            _gameEvents.Add(e);
        }

        public City(string name, int population, int gold, int happiness)
        {
            _name = name;
            _population = population;
            _gold = gold;
            _happiness = happiness;
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