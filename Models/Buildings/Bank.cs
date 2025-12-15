namespace miesto_meras.Models.Buildings
{
    public class BankCostBehaviour : ICostBehaviour
    {
        public void Build(City city, int price)
        {
            city.Gold -= price;
        }
    }
    public class BankOneTimeEffect : IBuildingOneTimeEffect
    {
        public void Apply(City city)
        {
            city.Happiness += 5;
        }
    }
    public class BankPerTurnEffect : IBuildingPerTurnEffect
    {
        public void Apply(City city)
        {
            city.Gold += 20;
        }
    }
    public class Bank : Building
    {
        public Bank()
            : base(
                name: "Bankas",
                effectDescription: "Suteikia +5 laimės pastačius. Suteikia +20 aukso per ėjimą. Kainuoja 100 aukso",
                price: 100,
                buildBehaviour: new BankCostBehaviour(),
                oneTimeEffect: new BankOneTimeEffect(),
                perTurnEffect: new BankPerTurnEffect()
            )
        {
        }
    }
}