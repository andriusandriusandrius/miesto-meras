using System.Text.Json;
using miesto_meras.Models;
using miesto_meras.ParseClasses;

namespace miesto_meras.Utils
{
    public class JsonLoader
    {
        public static List<City> LoadCities()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Database/cities.json");
            var json = File.ReadAllText(path);
            var rawEvents = JsonSerializer.Deserialize<List<JsonCity>>(json) ?? throw new ArgumentNullException("unable to parse event json correctly");
            List<City> cities = rawEvents.Select(e=> new City (e.Name, e.Population, e.Gold, e.Happiness)).ToList();
            return cities;
        }
        public static List<GameEvent> LoadEvents()
        {
           string path = Path.Combine(AppContext.BaseDirectory, "Database/generalEvents.json");
            var json = File.ReadAllText(path);
            var rawEvents = JsonSerializer.Deserialize<List<JsonEvent>>(json) ?? throw new ArgumentNullException("unable to parse event json correctly");

            List<GameEvent> gameEvents = rawEvents.Select(e=> new GameEvent
            {
                Title = e.Title.ToUpper(),
                Description = e.Description,
                Choices = e.Choices.Select(c=> new EventChoice
                {
                    
                    Id = c.Id,
                    Text = c.Text,
                    ApplyEffect = city =>
                    {
                        
                        foreach(var effect in c.Effects)
                        {
                            switch (effect.Key)
                            {
                                case "Gold": city.Gold += effect.Value;break;
                                case "Population": city.Population += effect.Value;break;
                                case "Happiness": city.Happiness += effect.Value;break;
                            }
                        }
                    }
                }).ToList()
            }).ToList();

            return gameEvents;
        }
    }
}