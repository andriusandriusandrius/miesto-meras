
namespace miesto_meras.Models
{
    public class GameEvent
    {
        protected string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Game event must have a title");
                _title = value;
            }
        }
        protected string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Game event must have a description");
                _description = value;
            }
        }
        public List<EventChoice> Choices { get; } = new();

        public GameEvent(string Title, string Description, List<EventChoice> Choices)
        {
            _title = Title;
            _description = Description;
            this.Choices = Choices;

        }
    }
}