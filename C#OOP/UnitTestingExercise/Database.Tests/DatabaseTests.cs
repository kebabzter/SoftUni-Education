using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void Ctor_ThrowExeptionWhenDBCountExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddValidElement()
        {
            database = new Database.Database(1,2,3);
            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void Add_IncrementCountWhenAddIsValid()
        {
            database = new Database.Database(1, 2, 3);
            database.Add(4);
            Assert.That(database.Count, Is.EqualTo(4));
        }

        [Test]
        public void Add_ThrowExeptionWhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_ThrowExeptionWhenCapacityExceededMesage()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.That(() => database.Add(17),Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_DecreaceCapacity()
        {
            database = new Database.Database(1, 2, 3);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_DbIsEmptyThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DbIsEmptyThrowExeptionMessage()
        {
            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Remove_ElementFromDb()
        {
            var n = 3;
            var lastElement = 2;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            var elements = database.Fetch();
            Assert.IsFalse(elements.Contains(lastElement));
        }

        [Test]
        public void Fetch_ReturnDbCopyNotReference()
        {
            database.Add(1);
            database.Add(2);
            var firstCopy = database.Fetch();
            database.Add(3);
            var secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void Count_ReturnDbZero()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }

    }
}