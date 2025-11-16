
using miesto_meras.Models;

namespace miesto_meras.Services
{
    public class TurnService
    {
        private int TurnNumber = 1;

        private readonly City _city;
        private readonly EventService _eventService;
    
        public TurnService(City city, EventService eventService)
        {
            _city = city;
            _eventService = eventService;
        }
        private void PlayerInput()
        {
            Console.WriteLine("Your Turn:");
            Console.ReadLine();
        }
        public void RunTurns(int maxTurns)
        {
            _eventService.ReadEventsFromJson(_city);

            Console.WriteLine("===== ZAIDIMAS 'MIESTO MERAS' PRASIDEJO =====");
            Console.WriteLine("");
            while  (maxTurns >= TurnNumber)
            {
                Console.WriteLine($"Turn {TurnNumber}:");
                _city.Display();
                _eventService.ApplyRandomEvent(_city.GameEvents);
                PlayerInput();
                TurnNumber++;
            }
            Console.WriteLine("===== ZAIDIMAS 'MIESTO MERAS' PASIBAIGĖ =====");
        }
    }
}