using miesto_meras.Services;
namespace miesto_meras.Controllers
{
    public class TurnController
    {
        private readonly TurnService turnService;
        private readonly int maxTurns;

        
        public TurnController(TurnService turnService, int maxTurns)
        {
            this.turnService = turnService;
            this.maxTurns = maxTurns;
        }

        public void RunGame()
        {
            int turn = 1;
            turnService.StartGame();

            while(maxTurns>=turn){
                turnService.RunTurn(turn);
                if(turnService.hasGameBeenLost) break;
                turn++;
            }
            if(turnService.hasGameBeenLost)
            Console.WriteLine("ZAIDIMA PRALAIMEJAI");
            else
            Console.WriteLine("ZAIDIMA LAIMEJAI");
        }
    }
}