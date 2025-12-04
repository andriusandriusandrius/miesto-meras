namespace miesto_meras.ParseClasses
{
    public class JsonBuilding
    {
        public string Name { get; set; } = string.Empty;
        public string EffectDescription { get; set; } = string.Empty;
        public int Price { get; set; }
        public Dictionary<string, int> Effects { get; set; } = new();
    }
}