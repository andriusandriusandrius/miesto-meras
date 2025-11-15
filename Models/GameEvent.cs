
namespace miesto_meras.Models
{
    public class GameEvent
    {
        public Guid Id{get;init;} = Guid.NewGuid();
        public string Title{get;set;} = String.Empty;
        public string? Description{get;set;} = String.Empty;
        public List<EventChoice> Choices = new();
    }
}