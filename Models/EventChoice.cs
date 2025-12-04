namespace miesto_meras.Models
{
    public class EventChoice
    {
        protected int _id;
        public int Id
        {
            get => _id;


            set
            {
                _id = value;
            }
        }
        protected string _text;
        public string Text
        {
            get => _text;


            set
            {
                _text = value;
            }
        }
        public Action<City> ApplyEffect { get; set; }


        public EventChoice(int id, string text, Action<City> applyEffect)
        {
            _id = id;
            _text = text;
            ApplyEffect = applyEffect;
        }

    }
}