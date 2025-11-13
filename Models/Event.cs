namespace miesto_meras.Models
{
    public class Event
    {
        public int Id{get;set;}
        public String? Title{get;set;}
        public String? Description{get;set;}
        public required IChoice Choice {get;set;}
    }
}