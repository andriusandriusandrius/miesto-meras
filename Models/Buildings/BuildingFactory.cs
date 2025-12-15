namespace miesto_meras.Models.Buildings
{
    public static class BuildingFactory
    {
        public static Building Create(string buildingType)
        {
            return buildingType switch
            {
                "Bankas" => new Bank(),
                "Cirkas" => new Circus(),
                "Turistų atrakcija" => new TouristAttraction(),
                _ => throw new ArgumentException($"Unknown building type: {buildingType}")
            };
        }
    }
}