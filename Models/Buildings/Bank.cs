namespace miesto_meras.Models.Buildings
{
    public class BankBuildBehaviour : IBuildBehaviour
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
        public void Apply(City city, int count)
        {
            city.Gold += 20 * count;
        }
    }
    public class Bank : Building
    {
        public Bank()
            : base(
                name: "Bank",
                effectDescription: "Provides gold each turn and increases happiness.",
                price: 100,
                buildBehaviour: new BankBuildBehaviour(),
                oneTimeEffect: new BankOneTimeEffect(),
                perTurnEffect: new BankPerTurnEffect()
            )
        {
        }
    }
}