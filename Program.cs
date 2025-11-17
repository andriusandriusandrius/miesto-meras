using miesto_meras.Services;
using miesto_meras.Models;
using miesto_meras.Controllers;
using miesto_meras.Utils;

int maxTurns = 3;

List<City> cities = JsonLoader.LoadCities();
List<GameEvent> gameEvents = JsonLoader.LoadEvents();

foreach (var city in cities)
{
    city.GameEvents = gameEvents;
}


Player player = new();
player.Cities = cities;


EventService eventService = new();
TurnService turnService = new(player, eventService);
TurnController turnController = new(turnService, maxTurns);
turnController.RunGame();