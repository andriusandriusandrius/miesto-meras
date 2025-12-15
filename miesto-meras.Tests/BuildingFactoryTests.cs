using NUnit.Framework;
using miesto_meras.Models.Buildings;

public class BuildingFactoryTests
{
    [TestCase("Bankas", typeof(Bank))]
    [TestCase("Cirkas", typeof(Circus))]
    [TestCase("Turistų atrakcija", typeof(TouristAttraction))]
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
