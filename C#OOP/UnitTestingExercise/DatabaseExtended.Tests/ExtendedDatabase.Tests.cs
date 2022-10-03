using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddInitialPeoplesToTheDBCount()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i,$"Name{i}");
            }
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(extendedDatabase.Count,Is.EqualTo(persons.Length));
        }

        [Test]
        public void Ctor_AddInitialPeoplesToTheDBId()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name{i}");
            }
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);

            foreach (var person in persons)
            {
                Person dbPerson = extendedDatabase.FindById(person.Id);
                Assert.That(person,Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void Ctor_ThrowExeptionWhenCapacityExeeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowExeptionWhenCountExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new Person(i,$"Name{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16,"Name16")));
        }

        [Test]
        public void Add_ThrowExeptionWhenCountExceededMesage()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new Person(i, $"Name{i}"));
            }
            Assert.That(() => extendedDatabase.Add(new Person(16, "Name16")), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_ThrowExeptionWhenUsernameExisting()
        {
            var name = "Name";
            extendedDatabase.Add(new Person(1, name));
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, name)));
        }

        [Test]
        public void Add_ThrowExeptionWhenUsernameExistingMesage()
        {
            var name = "Name";
            extendedDatabase.Add(new Person(1, name));
            Assert.That(() => extendedDatabase.Add(new Person(16, name)), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Add_ThrowExeptionWhenIdExisting()
        {
            var id = 1;
            extendedDatabase.Add(new Person(id, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(id, "name")));
        }

        [Test]
        public void Add_ThrowExeptionWhenIdExistingMesage()
        {
            var id = 1;
            extendedDatabase.Add(new Person(id, "Pesho"));
            Assert.That(() => extendedDatabase.Add(new Person(id, "name")), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Add_IncrementCountWhenValidInfo()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(2, "Gosho"));
            Assert.That(extendedDatabase.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_ThrowExeptionWhenDBIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void Remove_ElementFromDb()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDatabase.Add(new Person(i, $"Name{i}"));
            }
            extendedDatabase.Remove();
            Assert.That(extendedDatabase.Count, Is.EqualTo(n-1));
        }

        [Test]
        public void FindById_ThrowExeption()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDatabase.Add(new Person(i, $"Name{i}"));
            }
            extendedDatabase.Remove();
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(n-1));
        }

        [Test]
        public void FindById_ThrowExeptionMesage()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDatabase.Add(new Person(i, $"Name{i}"));
            }
            extendedDatabase.Remove();
            Assert.That(() => extendedDatabase.FindById(n-1), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowExeptionWhenUsernameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowExeptionWhenUsernameIsNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("koko"));
        }

        [Test]
        public void FindByUsername_ValidInfo()
        {
            var person=new Person(1, "Pesho");
            extendedDatabase.Add(person);
            Assert.That(extendedDatabase.FindByUsername("Pesho"), Is.EqualTo(person));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-21)]
        public void FindById_NegativeValue(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(id));
        }

        [Test]
        public void FindById_ValidValue()
        {
            var person = new Person(1, "Pesho");
            extendedDatabase.Add(person);
            Assert.That(extendedDatabase.FindById(1), Is.EqualTo(person));
        }

        [Test]
        public void Count_ReturnDbZero()
        {
            Assert.That(extendedDatabase.Count, Is.EqualTo(0));
        }
    }
}