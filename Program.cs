using miesto_meras.Services;
using miesto_meras.Models;
using miesto_meras.Controllers;
using miesto_meras.Utils;
using miesto_meras.Models.Buildings;

int maxTurns = 3;
TurnService turnService = new();
TurnController turnController = new(turnService);

turnController.RunGame(maxTurns);