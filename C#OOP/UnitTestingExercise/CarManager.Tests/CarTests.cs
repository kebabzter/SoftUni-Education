using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 5, 100)]
        [TestCase(null, "Model", 5, 100)]
        [TestCase("Make", "", 5, 100)]
        [TestCase("Make", null, 5, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -5, 100)]
        [TestCase("Make", "Model", 5, 0)]
        [TestCase("Make", "Model", 5, -100)]
        public void Ctor_ThrowExeptionWhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_ThrowExeptionWhenDataIsValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void Refuel_ThrowExeptionWhenRefuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_RefuelIsValid()
        {
            car.Refuel(10);
            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void Refuel_SetToFuelCapacity()
        {
            car.Refuel(150);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowExeptionWhenFuelIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void Drive_DecreaceFuelAmountWhenDataIsValid()
        {
            var initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel-car.FuelConsumption));
        }

        [Test]
        public void Drive_DecreaceFuelAmountToZero()
        {
            var initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            double distance = car.FuelCapacity * car.FuelConsumption;
            car.Drive(distance);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Drive_NegativeValueIsPassed()
        {
            var initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            double beforeDrive = car.FuelAmount;
            car.Drive(100);
            double afterDrive = car.FuelAmount;
            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }

    }
}