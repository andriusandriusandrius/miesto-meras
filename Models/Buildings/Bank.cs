namespace miesto_meras.Models.Buildings
{
    public class BankBuildBehaviour : IBuildBehaviour
    {
        public void Build(City city)
        {

            city.Gold -= 50;
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