using miesto_meras.Services;
using miesto_meras.Models;
using miesto_meras.Controllers;
using miesto_meras.Utils;
using miesto_meras.Models.Buildings;

int maxTurns = 3;

List<City> cities = JsonLoader.LoadCities();
List<GameEvent> gameEvents = JsonLoader.LoadEvents();

foreach (var city in cities)
{
    foreach (var gameEvent in gameEvents)
    {
        city.AddGameEvent(gameEvent);
    }
}

Player player = new(cities);
EventService eventService = new();
BuildingService buildingService = new();
TurnService turnService = new(player, eventService, buildingService);
TurnController turnController = new(turnService, maxTurns);

turnController.RunGame();