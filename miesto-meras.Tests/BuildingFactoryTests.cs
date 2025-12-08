using NUnit.Framework;
using miesto_meras.Models.Buildings;

[TestFixture]
public class BuildingFactoryTests
{
    [TestCase("Bank", typeof(Bank))]
    [TestCase("Circus", typeof(Circus))]
    [TestCase("TouristAttraction", typeof(TouristAttraction))]
    public void Create_ReturnsCorrectBuildingType(string typeName, Type expected)
    {
        var building = BuildingFactory.Create(typeName);
        Assert.That(building, Is.TypeOf(expected));
    }

    [Test]
    public void Create_Throws_OnUnknownType()
    {
        Assert.Throws<ArgumentException>(() => BuildingFactory.Create("NoSuchBuilding"));
    }
}
