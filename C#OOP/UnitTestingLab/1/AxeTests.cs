using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUpTest()
    {
        axe = new Axe(10,2);
        dummy = new Dummy(20,5);
    }
    [Test]
    public void Attack_AxeLoseDurability()
    {
        axe.Attack(dummy);
        Assert.AreEqual(1,axe.DurabilityPoints);
    }

    [Test]
    public void Attack_BrokenAxe()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.Throws<InvalidOperationException>(()=>axe.Attack(dummy));
    }

    [Test]
    public void Attack_DurabilityPointZero()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.That(()=>axe.Attack(dummy),Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}