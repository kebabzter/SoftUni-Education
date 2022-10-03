using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;
        private string manufacture;
        private string model;
        private decimal price;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            manufacture = "Manufactures";
            model = "Model";
            price = 1000;
            computer = new Computer(manufacture, model, price);
        }

        [Test]
        public void AddComputer_NullComputerThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null), "Can not be null.");
        }

        [Test]
        public void AddComputer_NullComputerThrowExceptionMessage()
        {
            Assert.That(() => computerManager.AddComputer(null), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'computer')"));
        }

        [Test]
        public void AddComputer_ManufactureAndModelThrowExeption()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer), "This computer already exists.");
        }

        [Test]
        public void AddComputer_Success()
        {
            computerManager.AddComputer(computer);

            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddComputer_Success2()
        {
            computerManager.AddComputer(computer);

            Assert.That(computerManager.Computers, Has.Member(computer));
        }

        [Test]
        public void ComputerCount_Success()
        {
            Assert.That(computerManager.Count, Is.EqualTo(0));
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveComputer_Success()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Assert.That(computerManager.Computers.Count, Is.EqualTo(2));
            computerManager.RemoveComputer(manufacture, model);
            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveComputer_SuccessReturn()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);

            Assert.That(computerManager.RemoveComputer(manufacture, model), Is.EqualTo(computerRemove));
        }
        [Test]
        public void RemoveShouldThrowExceptionWithInvalidComputer()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("Invalid", "Acer"), "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputer_NullManufactureThrowException()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, model));
            Assert.That(() => computerManager.GetComputer(null, model), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'manufacturer')"));
        }

        [Test]
        public void GetComputer_NullModelThrowException()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacture, null));
            Assert.That(() => computerManager.GetComputer(manufacture, null), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'model')"));
        }

        [Test]
        public void GetComputer_ModelAndManufactureThrowException()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer(manufacture, "DK"));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("alabala", model));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("alabala", "DK"));
        }
        [Test]
        public void GetComputer_ModelAndManufactureThrowExceptionMessage()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("alabala", "DK"));
            Assert.That(() => computerManager.GetComputer("alabala", "DK"), Throws.ArgumentException.With.Message.EqualTo("There is no computer with this manufacturer and model."));
        }

        [Test]
        public void GetComputer_Success()
        {
            Computer computerRemove = new Computer(manufacture, model, price);
            computerManager.AddComputer(computerRemove);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Assert.That(computerManager.GetComputer(manufacture, model), Is.EqualTo(computerRemove));
        }

        [Test]
        public void GetComputerByManufacture_Success()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            List<Computer> comps = new List<Computer>();
            comps.Add(computer);
            Assert.That(computerManager.GetComputersByManufacturer(manufacture), Is.EqualTo(comps));
            Assert.That(computerManager.GetComputersByManufacturer(manufacture) is List<Computer>);
        }

        [Test]
        public void GetComputerByManufacture_Success2()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);

            Assert.That(computerManager.GetComputersByManufacturer("koko").Count, Is.EqualTo(0));
        }

        [Test]
        public void GetComputerByManufacture_Success3()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Computer computer3 = new Computer(manufacture, "Assus", 3000);
            computerManager.AddComputer(computer3);
            List<Computer> comps = new List<Computer> { computer, computer3};
            Assert.That(computerManager.GetComputersByManufacturer(manufacture), Is.EqualTo(comps));
        }

        [Test]
        public void GetComputerByManufacture_Success3Count()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);
            Computer computer3 = new Computer(manufacture, "Assus", 3000);
            computerManager.AddComputer(computer3);
            List<Computer> comps = new List<Computer> { computer, computer3 };
            Assert.That(computerManager.GetComputersByManufacturer(manufacture).Count, Is.EqualTo(2));
        }

        [Test]
        public void GetComputerByManufacture_ThrowException()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("Laptop", "Hp", 2000);
            computerManager.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void Ctor()
        {
            ComputerManager manager = new ComputerManager();
            Assert.That(manager.Count, Is.EqualTo(0));
            Assert.That(manager.Computers is IReadOnlyCollection<Computer>);
            Assert.That(computerManager.Computers, Is.Empty);
        }
    }
}