namespace miesto_meras.Models.Buildings
{
    public static class BuildingFactory
    {
        public static Building Create(string buildingType)
        {
            return buildingType switch
            {
                "Bank" => new Bank(),
                "Cirkas" => new Circus(),
                "TouristAttraction" => new TouristAttraction(),
                _ => throw new ArgumentException($"Unknown building type: {buildingType}")
            };
        }
    }
}