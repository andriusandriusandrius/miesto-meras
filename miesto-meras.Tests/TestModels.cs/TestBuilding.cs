using miesto_meras.Models;
using miesto_meras.Models.Buildings;

public class TestBuildBehaviour : IBuildBehaviour
{
    public bool WasCalled = false;
    public City? LastCity;
    public int LastPrice;

    public void Build(City city, int price)
    {
        WasCalled = true;
        LastCity = city;
        LastPrice = price;
    }
}

public class TestOneTimeEffect : IBuildingOneTimeEffect
{
    public bool WasCalled = false;
    public City? LastCity;

    public void Apply(City city)
    {
        WasCalled = true;
        LastCity = city;
    }
}

public class TestPerTurnEffect : IBuildingPerTurnEffect
{
    public bool WasCalled = false;
    public City? LastCity;

    public void Apply(City city)
    {
        WasCalled = true;
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
