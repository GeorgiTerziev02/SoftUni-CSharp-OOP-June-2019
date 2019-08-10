namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.car = new Car("BMW", "E41");
        }

        [Test]
        public void TestIfCarConstructorWorksCorrectly()
        {
            string make = "BMW";
            string regNumber = "E41";

            Assert.AreEqual(make, this.car.Make);
            Assert.AreEqual(regNumber, this.car.RegistrationNumber);

        }

        [Test]
        public void TestIfSoftParkConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.softPark.Parking);
            Assert.AreEqual(12, this.softPark.Parking.Count);
        }

        [Test]
        public void TestIfParkCarWorksCorrectly()
        {
            var parkSpot = "A1";
            this.softPark.ParkCar(parkSpot, this.car);

            Assert.AreSame(car, this.softPark.Parking[parkSpot]);
        }

        [Test]
        public void TestParkCarWithInvalidParkSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("D5", this.car);
            });
        }

        [Test]
        public void TestParkCarWithAlreadyTakenSpot()
        {
            var parkSpot = "A1";
            this.softPark.ParkCar(parkSpot, this.car);

            var newCar = new Car("MC", "AAA");

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar(parkSpot, newCar);
            });
               
        }

        [Test]
        public void TestParkCarWithAlreadyParkedCar()
        {
            this.softPark.ParkCar("A1", this.car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("A2", this.car);

            });

        }

        [Test]
        public void TestIfRemoveCarWorksCorrectly()
        {
            string expectedOutput = $"Remove car:{this.car.RegistrationNumber} successfully!";
            this.softPark.ParkCar("A1", this.car);

            var result = this.softPark.RemoveCar("A1", this.car);

            Assert.IsNull(this.softPark.Parking["A1"]);
            Assert.AreEqual(expectedOutput, result);

        }

        [Test]
        public void TestRemoveCarWithNotExistingParkSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("D5", this.car);
            });
        }

        [Test]
        public void TestRemoveCarWithNotExistingCar()
        {
            Car fakeCar = new Car("XX", "op");

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("A1", fakeCar);
            });
        }

    }
}