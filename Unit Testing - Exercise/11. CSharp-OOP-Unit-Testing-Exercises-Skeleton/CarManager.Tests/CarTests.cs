using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "640", 8, 75);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedMake = "BMW";
            string expectedModel = "640";
            double expectedFuelConsumption = 8;
            double expectedFuelCapacity = 75;
            double expectedFuelAmount = 0;

            Assert.AreEqual(expectedMake, this.car.Make);
            Assert.AreEqual(expectedModel, this.car.Model);
            Assert.AreEqual(expectedFuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, this.car.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void TestCarMakeWithNull()
        {
            Assert.That(() => new Car(null, "640", 8.4, 75), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void TestCarModelWithNull()
        {
            Assert.Throws<ArgumentException>(() => { new Car("BMW", null, 8.4, 75); }, "Model cannot be null or empty!");
        }

        [Test]
        public void TestCarFuelConsumptionWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => { new Car("BMW", "640", -5, 75); }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void TestCarFuelCapacityWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => { new Car("BMW", "640", 8.4, -75); }, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void TestIfRefuelWorksCorrectlyWithLessThanTheCapacity()
        {
            double fuelToRefuel = 22;
            double expectedFuel = 22;
            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestIfRefuelWorksCorrectlyWithMoreThanTheCapacity()
        {
            double fuelToRefuel = 1000;
            double expectedFuel = 75;
            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestRefuelWithNegativeNumber()
        {
            Assert.That(() => this.car.Refuel(-5), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void TestIfDriveWorksCorrectly()
        {
            this.car.Refuel(60);
            double distanceToDrive = 25;

            double expectedFuel = 58;

            this.car.Drive(distanceToDrive);

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestIfDriveThrowsException()
        {
            this.car.Refuel(10);
            double distanceToDrive = 500;

            Assert.That(() => this.car.Drive(distanceToDrive), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));

        }
    }
}