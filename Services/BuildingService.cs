using miesto_meras.Models;
using miesto_meras.Models.Buildings;
namespace miesto_meras.Services
{
    public class BuildingService
    {
        private readonly List<Building> availableBuildings;
        public BuildingService(List<Building> availableBuildings)
        {
            this.availableBuildings = availableBuildings;
        }
        public void HandleBuildingPhase(City city)
        {

            Console.WriteLine("==PASTATŲ STATYMAS==\n");
            Console.WriteLine("Kuri pastatą norėtum pasistatyti?\n");
            foreach (var element in availableBuildings)
            {
                Console.Write($"{element.Name}({element.EffectDescription}); ");
            }

            while (true)
            {
                Console.WriteLine($"\nPasirink nuo 0 iki {availableBuildings.Count}:");
                Console.WriteLine($"Pasirink 0 jeigu nenori nieko statyti");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                        return;

                    if (choice >= 1 && choice <= availableBuildings.Count)
                    {
                        Building selected = availableBuildings[choice - 1];
                        if (city.Gold < selected.Price)
                        {
                            Console.WriteLine("Neturi pakankamai aukso!");
                            continue;
                        }
                        city.Gold -= selected.Price;

                        if (!city.Buildings.ContainsKey(selected.Name))
                        {
                            city.Buildings[selected.Name] = 0;
                        }

                        city.Buildings[selected.Name]++;

                        Console.WriteLine($"{selected.Name} pastatytas sėkmingai!");
                        return;
                    }
                }

                Console.WriteLine("Neteisingas pasirinkimas, bandyk dar kartą.");
            }

        }
        public void BuildingsAction(City city)
        {
            foreach (var element in city.Buildings)
            {
                string buildingName = element.Key;
                int count = element.Value;

                Building? building = availableBuildings
                    .FirstOrDefault(b => b.Name == buildingName);

                if (building == null)
                    continue;

                for (int i = 0; i < count; i++)
                {
                    building.ApplyEffect(city);
                }
            }
        }
    }
}