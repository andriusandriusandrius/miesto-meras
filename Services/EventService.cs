using System.Diagnostics.Tracing;
using System.Text.Json;
using Microsoft.VisualBasic;
using miesto_meras.Models;
using miesto_meras.ParseClasses;

namespace miesto_meras.Services
{
    public class EventService
    {
        
        public void ApplyEvent(GameEvent gameEvent, City city)
        {
            Console.WriteLine($"=={gameEvent.Title}==");
            Console.WriteLine(gameEvent.Description);

            foreach(var choice in gameEvent.Choices)
            {
                Console.Write($"{choice.Text}; ");
            }


            while(true){
                
                Console.WriteLine($"Pasirink tarp pasirinkimų 1 - {gameEvent.Choices.Count}");

                string playerChoiceString =  Console.ReadLine() ?? "";
                int playerChoice;
                
                if(Int32.TryParse(playerChoiceString, out playerChoice))
                {
                   if(playerChoice>= 1 && playerChoice <= gameEvent.Choices.Count)
                    {
                        gameEvent.Choices[playerChoice-1].ApplyEffect(city);
                        break;
                    }
              
                    
                }
            }
             
        }
        public void ApplyRandomEvent(City city)
        {
           Random rnd = new Random();
           int index = rnd.Next(city.GameEvents.Count);
           ApplyEvent(city.GameEvents[index], city);
        }
    }
}