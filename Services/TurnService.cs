using miesto_meras.Models;

namespace miesto_meras.Controllers
{
    public class TurnService
    {
        private int TurnNumber = 1;

        private readonly City _city;

        public TurnService(City city)
        {
            _city = city;
        }
        private void PlayerInput()
        {
            Console.WriteLine("Your Turn:");
            Console.ReadLine();
        }
        public void RunTurns(int maxTurns)
        {
            Console.WriteLine("===== ZAIDIMAS 'MIESTO MERAS' PRASIDEJO =====");
            Console.WriteLine("");
            while  (maxTurns >= TurnNumber)
            {
                Console.WriteLine($"Turn {TurnNumber}:");
                _city.Display();
                PlayerInput();
                TurnNumber++;
            }
            Console.WriteLine("===== ZAIDIMAS 'MIESTO MERAS' PASIBAIGĖ =====");
        }
    }
}