using miesto_meras.Models;
using miesto_meras.Models.Buildings;
namespace miesto_meras.Tests;

public class CityTests
{

    private City _city;
    [SetUp]
    public void Setup()
    {
        _city = new City(
                name: "TestCity",
                population: 100,
                gold: 50,
                happiness: 70,
                buyableBuildingInformation: new List<BuyableBuildingInformation>()
            );
    }
    [Test]
    public void Name_SetInvalidValue_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => _city.Name = "");
        Assert.Throws<ArgumentException>(() => _city.Name = "   ");
    }
    [Test]
    public void AddBuilding_ShouldStoreBuildingAndCallBuild()
    {
        var building = new TestBuilding("Farm", "Test farm effect", 10);

        _city.AddBuilding(building);

        Assert.IsTrue(_city.Buildings.ContainsKey("Farm"));

        Assert.That(_city.Buildings["Farm"].Count, Is.EqualTo(1));

        Assert.That(building.BuildMock.LastPrice, Is.EqualTo(building.Price));
    }

}