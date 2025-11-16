using miesto_meras.Services;
using miesto_meras.Models;

City city = new("Siauliai", 40, 80, 10);

EventService eventService = new();
TurnService turnService = new(city, eventService);

turnService.RunTurns(10);