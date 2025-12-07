namespace miesto_meras.Models.Buildings
{
    public abstract class Building
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
        protected readonly IBuildBehaviour _buildBehaviour;
        protected readonly IBuildingOneTimeEffect _oneTimeEffect;
        protected readonly IBuildingPerTurnEffect _perTurnEffect;

        protected int _count = 0;
        public int Count
        {
            get => _count;
        }
        public void RemoveBuilding(int difference)
        {
            if (_count >= difference)
                _count -= difference;
            else
                throw new ArgumentException($"Cant remove {difference} buildings since there are only {_count} of them ");
        }
        public void AddBuilding()
        {
            _count += 1;
        }

        public void Build(City city)
        {
            AddBuilding();
            _buildBehaviour.Build(city, _price);
            Console.WriteLine($"A {_name} was built.");
        }
        public void ApplyOneTimeEffect(City city)
        {

            _oneTimeEffect.Apply(city);
            Console.WriteLine($"{_name} one-time effect applied.");
        }
        public void ApplyPerTurnEffect(City city, int _count)
        {
            _perTurnEffect.Apply(city, _count);
            Console.WriteLine($"{_name} per-turn effect applied");
        }

        public Building(string name, string effectDescription, int price, IBuildBehaviour buildBehaviour, IBuildingOneTimeEffect oneTimeEffect, IBuildingPerTurnEffect perTurnEffect)
        {
            _name = name;
            _effectDescription = effectDescription;
            _price = price;
            _buildBehaviour = buildBehaviour;
            _oneTimeEffect = oneTimeEffect;
            _perTurnEffect = perTurnEffect;
        }

    }
}