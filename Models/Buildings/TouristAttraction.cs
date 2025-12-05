namespace miesto_meras.Models.Buildings
{
    public class TouristAttractionBuildBehaviour : IBuildBehaviour
    {
        public void Build(City city)
        {
            city.Gold -= 20;
        }
    }

    public class TouristAttractionOneTimeEffect : IBuildingOneTimeEffect
    {
        public void Apply(City city)
        {
            city.Population += 5;
        }
    }

    public class TouristAttractionPerTurnEffect : IBuildingPerTurnEffect
    {
        public void Apply(City city)
        {
            city.Happiness += 2;
        }
    }

    public class TouristAttraction : Building
    {
        public TouristAttraction()
            : base(
                name: "Turistų lankytina vieta",
                effectDescription: "Suteikia +5 populiacijos ir +2 laimės per ėjimą. Kaina 20 aukso",
                price: 20,
                buildBehaviour: new TouristAttractionBuildBehaviour(),
                oneTimeEffect: new TouristAttractionOneTimeEffect(),
                perTurnEffect: new TouristAttractionPerTurnEffect()
            )
        {
        }
    }
}