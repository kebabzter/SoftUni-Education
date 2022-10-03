namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUpTest()
        {
            
        }
        [Test]
        public void Ctor_Work()
        {
            aquarium = new Aquarium("Name", 100);
            Assert.That(aquarium.Name, Is.EqualTo("Name"));
            Assert.That(aquarium.Capacity, Is.EqualTo(100));
        }

        [TestCase(null, 1)]
        [TestCase("", 1)]
        public void Ctor_NameThrowExeption(string name, int capacity)
        {

            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aquarium(name, capacity);
            }, "Invalid aquarium name!");
        }

        [Test]
        public void Ctor_CapacityThrowExeption()
        {

            Assert.Throws<ArgumentException>(() => new Aquarium("Aqua", -5));
            Assert.That(() => new Aquarium("Aqua", -5), Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void Count()
        {
            aquarium = new Aquarium("Aqua",10);
            aquarium.Add(new Fish("fishName"));
            Assert.That(aquarium.Count,Is.EqualTo(1));
        }

        [Test]
        public void AddFish_ThrowExeption()
        {
            aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("fishName"));
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("roro")));
            Assert.That(() => aquarium.Add(new Fish("roro")), Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void RemoveFish_ThrowExeption()
        {
            aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("fishName"));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("koko"));
            Assert.That(() => aquarium.RemoveFish("koko"), Throws.InvalidOperationException.With.Message.EqualTo("Fish with the name koko doesn't exist!"));
        }

        [Test]
        public void RemoveFish_Success()
        {
            aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("fishName"));
            aquarium.RemoveFish("fishName");
            Assert.That(aquarium.Count,Is.EqualTo(0));
        }

        [Test]
        public void SellFish_ThrowExeption()
        {
            aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("fishName"));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("koko"));
            Assert.That(() => aquarium.SellFish("koko"), Throws.InvalidOperationException.With.Message.EqualTo("Fish with the name koko doesn't exist!"));
        }

        [Test]
        public void SellFish_Success()
        {
            aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("fishName"));
            Fish sellFish=aquarium.SellFish("fishName");
            Assert.That(sellFish.Name, Is.EqualTo("fishName"));
            Assert.That(sellFish.Available, Is.EqualTo(false));
        }

        [Test]
        public void Report_Success()
        {
            aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("fishName"));
            string expectedReport = "Fish available at Aqua: fishName";
            Assert.That(aquarium.Report(), Is.EqualTo(expectedReport));
        }

    }
}
