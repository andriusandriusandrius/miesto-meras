namespace miesto_meras.Models
{
    public class Building
    {
        public string Name{get;set;} = string.Empty;
        public string EffectDescription{get;set;} = string.Empty;
        public int Price { get; set; }
        public required Action<City> ApplyEffect{get;set;}

    }
}