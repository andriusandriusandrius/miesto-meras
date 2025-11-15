namespace miesto_meras.Models
{
    public abstract class Event
    {
        public Guid Id{get;init;} = Guid.NewGuid();
        public string? Title{get;set;}
        public string? Description{get;set;}
    }
}