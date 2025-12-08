using NUnit.Framework;
using miesto_meras.Models;

[TestFixture]
public class GameEventTests
{
    [Test]
    public void Constructor_SetsPropertiesCorrectly()
    {
        var choices = new List<EventChoice>
        {
            new EventChoice(1, "Option A", c => {}),
            new EventChoice(2, "Option B", c => {})
        };

        var gameEvent = new GameEvent("Title", "Description", choices);

        Assert.That(gameEvent.Title, Is.EqualTo("Title"));
        Assert.That(gameEvent.Description, Is.EqualTo("Description"));
        Assert.That(gameEvent.Choices.Count, Is.EqualTo(2));
    }

    [Test]
    public void Setting_Empty_Title_Throws()
    {
        var ge = new GameEvent("Test", "Desc", new());
        Assert.Throws<ArgumentException>(() => ge.Title = "");
    }

    [Test]
    public void Setting_Empty_Description_Throws()
    {
        var ge = new GameEvent("Test", "Desc", new());
        Assert.Throws<ArgumentException>(() => ge.Description = "");
    }
}
