using NUnit.Framework;
using System;
using ExtendedDatabase;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private readonly Person[] people = new Person[] { new Person(334, "Ivan"), new Person(22, "Sasho") };

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddingWorksCorrectly()
        {
            int expectedCount = 3;
            Person person = new Person(34, "Gosho");

            this.database.Add(person);

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }


        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(new Person(i, i.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(45, "Aleks"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void TestAddingSameId()
        {
            Person personWithSameId = new Person(22, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(personWithSameId);
            }, "There is already user with this Id!");
        }

        [Test]
        public void TestAddingSameName()
        {
            Person personWithSameId = new Person(20, "Ivan");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(personWithSameId);
            }, "There is already user with this username!");
        }

        [Test]
        public void TestAddRangeWithWrongProvidedData()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i, i.ToString());
            }

            Assert.Throws<ArgumentException>(()=> 
            {
                ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void TestRemovingCorrectly()
        {
            int expectedCount = 1;
            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingWhenEmpty()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => { this.database.Remove(); });
        }

        [Test]
        public void TestIfFindingByUsernameWorksCorrectly()
        {
            string nameToFind = "Ivan";
            Person expectedPerson = this.people[0];
            Person personFound = this.database.FindByUsername(nameToFind);

            Assert.AreEqual(expectedPerson, personFound);
        }

        [Test]
        public void TestFindingByUsernameWithFakeUsername()
        {
            string nameToFind = "Iva";

            Assert.Throws<InvalidOperationException>(() => { this.database.FindByUsername(nameToFind); }, "No user is present by this username!");
        }

        [Test]
        public void TestFindingByUsernameWithNullUsername()
        {
            string nameToFind = null;

            Assert.Throws<ArgumentNullException>(() => { this.database.FindByUsername(nameToFind); }, "Username parameter is null!");
        }

        [Test]
        public void TestIfFindingByUsernameIsCaseSensitive()
        {
            string nameToFind = "ivan";

            Assert.Throws<InvalidOperationException>(() => { this.database.FindByUsername(nameToFind); }, "No user is present by this username!");
        }

        [Test]
        public void TestIfFindingByIdWorksCorrectly()
        {
            long idToFind = 334;
            Person expectedPerson = this.people[0];
            Person personFound = this.database.FindById(idToFind);

            Assert.AreEqual(expectedPerson, personFound);
        }

        [Test]
        public void TestFindingByIdWithNegativeIdNumber()
        {
            long idToFind = -66;

            Assert.Throws<ArgumentOutOfRangeException>(() => { this.database.FindById(idToFind); }, "Id should be a positive number!");
        }

        [Test]
        public void TestFindingByIdWithNotExistingIdNumber()
        {
            long idToFind = 555;

            Assert.Throws<InvalidOperationException>(() => { this.database.FindById(idToFind); }, "No user is present by this ID!");
        }


    }
}