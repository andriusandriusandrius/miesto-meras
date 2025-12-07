using System.Text.Json;
using miesto_meras.Models;
using miesto_meras.Models.Buildings;
using miesto_meras.ParseClasses;
namespace miesto_meras.Utils
{
    public class JsonLoader
    {
        private static Action<City> BuildEffectAction(Dictionary<string, int> effects)
        {
            return city =>
            {
                foreach (var effect in effects)
                {
                    switch (effect.Key)
                    {
                        case "Gold": city.Gold += effect.Value; break;
                        case "Population": city.Population += effect.Value; break;
                        case "Happiness": city.Happiness += effect.Value; break;
                    }
                }
            };
        }
        public static List<City> LoadCities()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Database/cities.json");
            var json = File.ReadAllText(path);
            var rawCities = JsonSerializer.Deserialize<List<JsonCity>>(json) ?? throw new ArgumentNullException("unable to parse city json correctly");
            List<City> cities = new List<City>();

            foreach (var e in rawCities)
            {
                List<BuyableBuildingInformation> buildingNames = new();
                foreach (var buildingName in e.AvailableBuildings)
                {
                    Building building = BuildingFactory.Create(buildingName);
                    BuyableBuildingInformation buildingInformation = new(building.Name, building.EffectDescription);
                    buildingNames.Add(buildingInformation);
                }

                City city = new City(e.Name, e.Population, e.Gold, e.Happiness, buildingNames);
                cities.Add(city);
            }

            return cities;
        }
        public static List<GameEvent> LoadEvents()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Database/generalEvents.json");
            var json = File.ReadAllText(path);
            var rawEvents = JsonSerializer.Deserialize<List<JsonEvent>>(json) ?? throw new ArgumentNullException("unable to parse event json correctly");

            List<GameEvent> gameEvents = rawEvents.Select(e => new GameEvent(e.Title, e.Description, e.Choices.Select(c => new EventChoice(c.Id, c.Text, BuildEffectAction(c.Effects))).ToList())).ToList();

            return gameEvents;
        }
    }

}