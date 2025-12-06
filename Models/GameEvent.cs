
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

        public GameEvent(string title, string description, List<EventChoice> choices)
        {
            _title = title;
            _description = description;
            Choices = choices;

        }
    }
}