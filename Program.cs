using miesto_meras.Services;
using miesto_meras.Models;
using miesto_meras.Controllers;
using miesto_meras.Utils;

int maxTurns = 3;

List<City> cities = JsonLoader.LoadCities();
List<GameEvent> gameEvents = JsonLoader.LoadEvents();
List<Building> buildings = JsonLoader.LoadAvailableBuildings();

foreach (var city in cities)
{
    city.GameEvents = gameEvents;

    foreach(var building in buildings)
    {
        city.Buildings[building.Name] = 0;
    }
}



Player player = new();
player.Cities = cities;


EventService eventService = new();
BuildingService buildingService = new(buildings);
TurnService turnService = new(player, eventService,buildingService);
TurnController turnController = new(turnService, maxTurns);
turnController.RunGame();