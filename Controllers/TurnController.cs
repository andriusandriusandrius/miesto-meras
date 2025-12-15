using miesto_meras.Models;
using miesto_meras.Services;
using miesto_meras.Utils;
namespace miesto_meras.Controllers
{
    public class TurnController
    {
        private readonly TurnService turnService;


        public TurnController(TurnService turnService)
        {
            this.turnService = turnService;
        }

        public void RunGame(int maxTurns)
        {
            try
            {
                int turn = 1;

                List<City> cities = JsonLoader.LoadCities();
                SetUpCityEvents(cities);

                Console.WriteLine("====== MIESTO MERAS PRASIDEJO ======\n");

                while (maxTurns >= turn)
                {
                    turnService.RunTurn(turn, cities);
                    if (turnService.HasGameBeenLost) break;
                    turn++;
                }
                if (turnService.HasGameBeenLost)
                    Console.WriteLine("ZAIDIMA PRALAIMEJAI");
                else
                    Console.WriteLine("ZAIDIMA LAIMEJAI");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
        public void SetUpCityEvents(List<City> cities)
        {

            List<GameEvent> gameEvents = JsonLoader.LoadEvents();

            foreach (var city in cities)
            {
                foreach (var gameEvent in gameEvents)
                {
                    city.AddGameEvent(gameEvent);
                }
            }
        }
    }
}