namespace miesto_meras.Models
{
    public class EventChoice
    {
    public int Id {get;set;}
    public string Text {get;set;} = String.Empty;
    public required Action<City> ApplyEffect {get;set;}

    }
}