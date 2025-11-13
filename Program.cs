using miesto_meras.Controllers;
using miesto_meras.Models;

City city = new("Siauliai", 40, 80, 10);

TurnController turnController = new(city);

turnController.RunTurns(10);