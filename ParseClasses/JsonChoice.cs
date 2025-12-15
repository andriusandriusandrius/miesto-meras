namespace miesto_meras.ParseClasses
{
    public class JsonChoice
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Dictionary<string, int> Effects { get; set; } = new();
    }
}