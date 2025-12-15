using miesto_meras.Models;
using miesto_meras.Models.Buildings;

public class TestBuildBehaviour : ICostBehaviour
{
    public City? LastCity;
    public int LastPrice;

    public void Build(City city, int price)
    {
        LastCity = city;
        LastPrice = price;
    }
}

public class TestOneTimeEffect : IBuildingOneTimeEffect
{
    public City? LastCity;

    public void Apply(City city)
    {
        LastCity = city;
    }
}

public class TestPerTurnEffect : IBuildingPerTurnEffect
{
    public City? LastCity;

    public void Apply(City city)
    {
        LastCity = city;
    }
}

public class TestBuilding : Building
{
    public TestBuildBehaviour BuildMock { get; }
    public TestOneTimeEffect OneTimeMock { get; }
    public TestPerTurnEffect PerTurnMock { get; }

    public TestBuilding(string name = "TestBuilding", string effectDescription = "Test Effect", int price = 10)
        : base(
            name,
            effectDescription,
            price,
            new TestBuildBehaviour(),
            new TestOneTimeEffect(),
            new TestPerTurnEffect())
    {
        BuildMock = (TestBuildBehaviour)_buildBehaviour;
        OneTimeMock = (TestOneTimeEffect)_oneTimeEffect;
        PerTurnMock = (TestPerTurnEffect)_perTurnEffect;
    }
}
