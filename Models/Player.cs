namespace miesto_meras.Models
{
    public class Player
    {
        public List<City> Cities { get; } = new();

        public Player(List<City> cities)
        {
            Cities = cities;
        }
    }
}