namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;
        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
        }
        [Test]
        public void Ctor()
        {
            present = new Present("kkk",5);
            Assert.That(present.Name, Is.EqualTo("kkk"));
            Assert.That(present.Magic, Is.EqualTo(5));
        }

        [Test]
        public void CreateBag_NullPresentThrowException()
        {
           
            Assert.Throws<ArgumentNullException>(()=>bag.Create(null));
        }

        [Test]
        public void CreateBag_PresentThrowException()
        {
            present = new Present("kkk", 5);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateBag_Present()
        {
            present = new Present("kkk", 5);
            string expectedResult = "Successfully added present kkk.";
            Assert.That(bag.Create(present), Is.EqualTo(expectedResult));
        }

        [Test]
        public void Remove_ReturnTrue()
        {
            present = new Present("kkk", 5);
            bag.Create(present);
            Assert.That(bag.Remove(present), Is.EqualTo(true));
        }

        [Test]
        public void Remove_ReturnFalse()
        {
            present = new Present("kkk", 5);
            Present present2 = new Present("kkki", 6);
            bag.Create(present);
            Assert.That(bag.Remove(present2), Is.EqualTo(false));
        }

        [Test]
        public void GetPresentWithLeastMagic_Success()
        {
            present = new Present("kkk", 5);
            Present present2 = new Present("kkki", 6);
            bag.Create(present);
            bag.Create(present2);
            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(present));
        }

        [Test]
        public void GetPresent_Success()
        {
            present = new Present("kkk", 5);
            Present present2 = new Present("kkki", 6);
            bag.Create(present);
            bag.Create(present2);
            Assert.That(bag.GetPresent("kkk"), Is.EqualTo(present));
        }

        [Test]
        public void GetPresentsReturnsBagAsReadOnlyCollection()
        {
            Assert.That(bag.GetPresents(), Is.InstanceOf<IReadOnlyCollection<Present>>());
        }
    }
}
