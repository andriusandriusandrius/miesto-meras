namespace miesto_meras.Models
{
    public class Building
    {
        protected string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name cannot be null");
                _name = value;
            }
        }
        protected string _effectDescription;
        public string EffectDescription
        {
            get => _effectDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("An effect description cannot be null");
                _effectDescription = value;
            }
        }
        protected int _price;

        public int Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new ArgumentException("Price cannot be negative or 0");
                _price = value;
            }
        }
        public Action<City> ApplyEffect { get; set; }

        public Building(string name, string effectDescription, int price, Action<City> applyEffect)
        {
            _name = name;
            _effectDescription = effectDescription;
            _price = price;
            ApplyEffect = applyEffect;
        }

    }
}