using miesto_meras.Services;
using miesto_meras.Models;
using miesto_meras.Controllers;

int maxTurns = 10;

City city1 = new("Siauliai", 40, 80, 10);
City city2 = new("Vilnius", 30, 50, 20 );

Player player = new();
player.Cities.Add(city1);
player.Cities.Add(city2);

EventService eventService = new();
TurnService turnService = new(player, eventService);
TurnController turnController = new(turnService, maxTurns);
turnController.RunGame();