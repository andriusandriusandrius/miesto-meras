namespace miesto_meras.ParseClasses
{
    public class JsonChoice
    {
        public int Id {get;set;}
        public string Text {get;set;} = String.Empty;
        public Dictionary<string,int> Effects = new();
    }
}