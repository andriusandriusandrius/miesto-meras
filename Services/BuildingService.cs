using miesto_meras.Models;
using miesto_meras.Models.Buildings;
namespace miesto_meras.Services
{
    public class BuildingService
    {
        public void HandleBuildingPhase(City city)
        {

            Console.WriteLine("==PASTATŲ STATYMAS==\n");
            Console.WriteLine("Kuri pastatą norėtum pasistatyti?\n");
            List<Building> availableBuildings = new();

            foreach (var keyValuePair in city.Buildings)
            {
                availableBuildings.Add(keyValuePair.Value);
                Console.WriteLine($"{keyValuePair.Key}({keyValuePair.Value.EffectDescription}); ");
            }

            while (true)
            {
                Console.WriteLine($"\nPasirink nuo 0 iki {city.Buildings.Count}:");
                Console.WriteLine($"Pasirink 0 jeigu nenori nieko statyti");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                        return;

                    if (choice >= 1 && choice <= city.Buildings.Count)
                    {
                        Building selected = availableBuildings[choice - 1];
                        if (city.Gold < selected.Price)
                        {
                            Console.WriteLine("Neturi pakankamai aukso!");
                            continue;
                        }

                        selected.AddBuilding();

                        Console.WriteLine($"{selected.Name} pastatytas sėkmingai!");
                        return;
                    }
                }

                Console.WriteLine("Neteisingas pasirinkimas, bandyk dar kartą.");
            }

        }
        public void BuildingsActionPerTurn(City city)
        {
            foreach (var element in city.Buildings)
            {
                Building building = element.Value;


                if (building == null || building.Count == 0)
                    continue;

                building.ApplyPerTurnEffect(city, building.Count);

            }
        }
    }
}