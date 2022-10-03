using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
public class HeroTests
{
    [Test]
    public void Test1()
    {
        string name = "Pesho";
        Mock<IWeapon> fakeAxe = new Mock<IWeapon>();
        Mock<ITarget> fakeTarget = new Mock<ITarget>();

        fakeTarget.Setup(p => p.IsDead()).Returns(true);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeAxe.Setup(p => p.Attack(It.IsAny<ITarget>())).Callback((ITarget target) => target.TakeAttack(10));

        Hero hero = new Hero(name,fakeAxe.Object);
        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience,Is.EqualTo(20));
    }
}