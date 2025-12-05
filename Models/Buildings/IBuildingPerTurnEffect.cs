namespace miesto_meras.Models.Buildings
{
    public interface IBuildingPerTurnEffect
    {
        public void Apply(City city);
    }
}