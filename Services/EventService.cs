using System.Diagnostics.Tracing;
using System.Text.Json;
using Microsoft.VisualBasic;
using miesto_meras.Models;
using miesto_meras.ParseClasses;

namespace backend.Controllers
{
    public class EventService
    {

        public void ReadEventsFromJson(City city)
        {
            var json = File.ReadAllText("Database/generalEvents.json");
            var rawEvents = JsonSerializer.Deserialize<List<JsonEvent>>(json) ?? throw new ArgumentNullException("unable to parse event json correctly");

            List<GameEvent> gameEvents = rawEvents.Select(e=> new GameEvent
            {
                Title = e.Title,
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

            city.GameEvents = gameEvents;
        }
     
    }
}