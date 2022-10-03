using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void CounterIsZero()
        {
            Assert.That(raceEntry.Counter,Is.Zero);
        }

        [Test]
        public void CounterIncreasesWhenAddDriver()
        {
            raceEntry.AddDriver(new UnitDriver("NameDriver",new UnitCar("Model",400,500)));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriverWhenDriverIsNullThrowException()
        {
            Assert.Throws<InvalidOperationException>(()=>raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverWhenDriverNameExistsThrowException()
        {
            var driverName = "Pesho";
            raceEntry.AddDriver(new UnitDriver(driverName,new UnitCar("Model",400,500)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("ModelCar",400,500))));
        }

        [Test]
        public void AddDriverReturnsExpectedResultMessage()
        {
            var driverName = "Pesho";
            var actual=raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("Model", 400, 500)));
            Assert.That(actual,Is.EqualTo($"Driver {driverName} added in race."));
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
            raceEntry.AddDriver(new UnitDriver("Pesho",new UnitCar("ModelCar",500,600)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageReturnsExpectedResult()
        {
            double expected = 0;
            for (int i = 0; i < 10; i++)
            {
                int hp = 450 + i;
                expected += hp;
                raceEntry.AddDriver(new UnitDriver($"Name-{i}", new UnitCar("ModelCar", hp, 550)));
            }

            expected /= 10;

            Assert.That(raceEntry.CalculateAverageHorsePower,Is.EqualTo(expected));
        }

    }
}