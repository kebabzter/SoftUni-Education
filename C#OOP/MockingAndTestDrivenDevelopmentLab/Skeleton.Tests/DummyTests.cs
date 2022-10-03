using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;
    [SetUp]
    public void SetUpTest()
    {
        axe = new Axe(10, 10);
        dummy = new Dummy(20, 5);
    }

    [Test]
    public void DummyLosesHealth()
    {
        axe.Attack(dummy);
        Assert.That(dummy.Health,Is.EqualTo(10));
    }

    [Test]
    public void DummyDeadThrowsExceptionIfAttacked()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.That(dummy.GiveExperience(), Is.EqualTo(5));
    }

    [Test]
    public void DummyCanNotGiveXP()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
