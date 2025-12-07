using System.Linq.Expressions;
using miesto_meras.Models;
using miesto_meras.Models.Buildings;
namespace miesto_meras.Services
{
    public class BuildingService
    {
        public void HandleBuildingPhase(City city)
        {

            city.DisplayBuyableBuildings();

            while (true)
            {
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                        return;

                    if (choice >= 1 && choice <= city.BuyableBuildings.Count)
                    {
                        BuyableBuildingInformation selected = city.BuyableBuildings[choice - 1];
                        Building building = BuildingFactory.Create(selected.Name);
                        if (city.Gold < building.Price)
                        {
                            Console.WriteLine("Neturi pakankamai aukso!");
                            continue;
                        }

                        city.AddBuilding(building);

                        Console.WriteLine($"{selected.Name} pastatytas sėkmingai!");
                        return;
                    }
                }

                Console.WriteLine("Neteisingas pasirinkimas, bandyk dar kartą.");
            }

        }

    }
}