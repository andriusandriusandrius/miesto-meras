namespace miesto_meras.ParseClasses
{
    public class JsonEvent
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<JsonChoice> Choices { get; set; } = new();

    }
}