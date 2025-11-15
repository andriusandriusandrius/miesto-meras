namespace miesto_meras.Models{
    public class City
    {
        public Guid Id {get;init;} = Guid.NewGuid();
        public string? Name {get;set;}
        public int Population {get;set;}
        public double Gold {get;set;}
        public int Happiness{get;set;}
        public City(string Name, int Population, double Gold, int Happiness )
        {
            this.Name = Name;
            this.Population = Population;
            this.Gold = Gold;
            this.Happiness = Happiness;
        }
        public void Display()
        {
            Console.WriteLine($"=====MIESTAS=====");
            Console.WriteLine($"City Name: {Name}");
            Console.WriteLine($"Population: {Population}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine($"Happiness: {Happiness}");
            Console.WriteLine($"=================");
        }
    }
}