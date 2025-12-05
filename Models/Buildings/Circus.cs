namespace miesto_meras.Models.Buildings
{
    public class CircusBuildBehaviour : IBuildBehaviour
    {
        public void Build(City city)
        {
            city.Gold -= 10;
        }
    }

    public class CircusOneTimeEffect : IBuildingOneTimeEffect
    {
        public void Apply(City city)
        {

        }
    }

    public class CircusPerTurnEffect : IBuildingPerTurnEffect
    {
        public void Apply(City city)
        {
            city.Happiness += 8;
        }
    }

    public class Circus : Building
    {
        public Circus()
            : base(
                name: "Cirkas",
                effectDescription: "Suteikia +8 laimės per ėjimą. Kaina 10 aukso",
                price: 10,
                buildBehaviour: new CircusBuildBehaviour(),
                oneTimeEffect: new CircusOneTimeEffect(),
                perTurnEffect: new CircusPerTurnEffect()
            )
        {
        }
    }
}
