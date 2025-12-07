using System.Numerics;
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

        private readonly Dictionary<string, List<Building>> _buildings = new();
        public IReadOnlyDictionary<string, List<Building>> Buildings => _buildings;

        private readonly List<BuyableBuildingInformation> _buyableBuildings;
        public IReadOnlyList<BuyableBuildingInformation> BuyableBuildings => _buyableBuildings;

        public void AddGameEvent(GameEvent e)
        {
            _gameEvents.Add(e);
        }
        public void AddBuilding(Building building)
        {
            if (_buildings.TryGetValue(building.Name, out var buildingsList))
            {
                buildingsList.Add(building);
            }
            else
                _buildings.Add(building.Name, new List<Building> { building });

            building.Build(this);

        }

        public City(string name, int population, int gold, int happiness, List<BuyableBuildingInformation> buyableBuildingInformation)
        {
            _name = name;
            _population = population;
            _gold = gold;
            _happiness = happiness;
            _buyableBuildings = buyableBuildingInformation;
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
                Console.WriteLine($"{building.Key} - {building.Value.Count}");
            }
            Console.WriteLine($"=================\n");
        }

        public void DisplayBuyableBuildings()
        {
            Console.WriteLine($"=====PASIRINK PASTATA=====");
            Console.WriteLine($"\nPasirink nuo 1 iki {BuyableBuildings.Count}:");
            Console.WriteLine($"Pasirink 0 jeigu nenori nieko statyti\n");
            int index = 1;
            foreach (var buyableBuildingInformation in BuyableBuildings)
            {
                Console.WriteLine($"({index}) {buyableBuildingInformation.Name} - {buyableBuildingInformation.Description}");
                index++;
            }
        }
        public void BuildingsActionsPerTurn()
        {
            foreach (var element in Buildings)
            {
                var buildings = element.Value;
                foreach (var building in buildings)
                {
                    building.ApplyPerTurnEffect(this);
                }

            }
        }
        public void HandleBuildingPhase()
        {
            DisplayBuyableBuildings();
            while (true)
            {
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                        return;

                    if (choice >= 1 && choice <= BuyableBuildings.Count)
                    {
                        BuyableBuildingInformation selected = BuyableBuildings[choice - 1];
                        Building building = BuildingFactory.Create(selected.Name);
                        if (Gold < building.Price)
                        {
                            Console.WriteLine("Neturi pakankamai aukso!");
                            continue;
                        }
                        AddBuilding(building);
                        Console.WriteLine($"{selected.Name} pastatytas sėkmingai!");
                        return;
                    }
                }
                Console.WriteLine("Neteisingas pasirinkimas, bandyk dar kartą.");
            }

        }

        public void ApplyRandomEvent()
        {
            Random rnd = new Random();
            int index = rnd.Next(GameEvents.Count);
            ApplyEvent(GameEvents[index]);
        }
        public void ApplyEvent(GameEvent gameEvent)
        {
            Console.WriteLine($"=={gameEvent.Title}==");
            Console.WriteLine(gameEvent.Description);

            foreach (var choice in gameEvent.Choices)
            {
                Console.Write($"{choice.Text}; ");
            }


            while (true)
            {

                Console.WriteLine($"Pasirink tarp pasirinkimų 1 - {gameEvent.Choices.Count}");

                string playerChoiceString = Console.ReadLine() ?? "";
                int playerChoice;

                if (int.TryParse(playerChoiceString, out playerChoice))
                {
                    if (playerChoice >= 1 && playerChoice <= gameEvent.Choices.Count)
                    {
                        gameEvent.Choices[playerChoice - 1].ApplyEffect(this);
                        break;
                    }


                }
            }

        }
    }
}