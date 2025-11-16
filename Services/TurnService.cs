
using miesto_meras.Models;

namespace miesto_meras.Services
{
    public class TurnService
    {
        private readonly Player player;
        private readonly EventService eventService;
        public bool hasGameBeenLost{get;private set;} = false;
        public TurnService(Player player, EventService eventService)
        {
            this.player =player;
            this.eventService = eventService;
        }

        public void StartGame()
        {
            foreach(City city in player.Cities)
            {
                eventService.ReadEventsFromJson(city);
            }

            Console.WriteLine("====== MIESTO MERAS PRASIDEJO ======\n");
        }
  
        public void KillUnderperformingCity(List<City> cities)
        {
            var toRemove = new List<City>();
            foreach(var city in cities){
                if(city.Gold <= 0)
                {
                    Console.WriteLine($"{city.Name} bankrutavo.");
                     toRemove.Add(city);
                }
                else if (city.Happiness <= 0)
                {
                    Console.WriteLine($"{city.Name} miesto piliečiai tapo tokie nepatenkinti kad jie sudegino miestą.");
                    toRemove.Add(city);
                }
                else if (city.Population <= 0)
                {
                    Console.WriteLine($"{city.Name} mieste nebeliko piliečių");
                     toRemove.Add(city);
                }
            }

            foreach(var city in toRemove)
            {
                cities.Remove(city);
            }
            
        }
        public void RunTurn(int turn)
        {
            Console.WriteLine($"Turn: {turn}\n");
            foreach(var city in player.Cities)
            {
                city.Display();
                eventService.ApplyRandomEvent(city);
               
            }
            KillUnderperformingCity(player.Cities);
            hasGameBeenLost = !(player.Cities.Count>0);
            
        }
    }
}