namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private const string name = "AAA";
        private const int capacity = 2;
        private Spaceship spaceship;
        private Astronaut astronaut;

        [SetUp]
        public void StartUp()
        {
            this.spaceship = new Spaceship(name, capacity);
            this.astronaut = new Astronaut("Ay", 50);
        }

        [Test]
        public void TestIfAstronautConstructorWorksCorrectly()
        {
            Astronaut astronaut = new Astronaut("pp", 55);

            Assert.AreEqual("pp", astronaut.Name);
            Assert.AreEqual(55, astronaut.OxygenInPercentage);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(name, this.spaceship.Name);
            Assert.AreEqual(capacity, this.spaceship.Capacity);
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void TestNameWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship sp = new Spaceship(null, capacity);
            });
        }

        [Test]
        public void TestCapacityWithNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship sp = new Spaceship(name, -4);
            });
        }

        [Test]
        public void TestIfAddAstronautWorksCorrectly()
        {
            this.spaceship.Add(astronaut);

            Assert.AreEqual(1, this.spaceship.Count);
        }

        [Test]
        public void TestAddingToFullCapacity()
        {
            this.spaceship.Add(this.astronaut);

            Astronaut ast1 = new Astronaut("k", 70);
            Astronaut ast2 = new Astronaut("ko", 60);

            this.spaceship.Add(ast1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(ast2);
            });

        }

        [Test]
        public void TestAddingTheSameAstronaut()
        {
            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(astronaut);
            });
        }

        [Test]
        public void TestRemoveReturnsTrue()
        {
            this.spaceship.Add(this.astronaut);

            var result = this.spaceship.Remove("Ay");

            Assert.AreEqual(true, result);
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void TestRemoveReturnsFalse()
        {
            this.spaceship.Add(astronaut);

            var result = this.spaceship.Remove("Gosho");

            Assert.AreEqual(false, result);
        }
    }
}