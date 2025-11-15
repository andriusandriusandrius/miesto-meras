namespace miesto_meras.ParseClasses
{
    public class JsonEvent
    {
        public string Title{get;set;} = String.Empty;
        public string Description{get;set;} = String.Empty;
        public List<JsonChoice> Choices{get;set;} = new();
        
    }
}