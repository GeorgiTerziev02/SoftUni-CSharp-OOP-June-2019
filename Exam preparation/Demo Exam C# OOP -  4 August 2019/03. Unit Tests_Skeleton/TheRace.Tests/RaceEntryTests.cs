using NUnit.Framework;
using System;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitRider rider;
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.rider = new UnitRider("Ivan", new UnitMotorcycle("Xpo", 70, 155));
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.raceEntry.Counter);
        }

        [Test]
        public void TestIfAddRiderWorksCorrectly()
        {
            int expectedCount = 1;

            raceEntry.AddRider(this.rider);

            Assert.AreEqual(expectedCount, this.raceEntry.Counter);
        }

        [Test]
        public void TestAddRiderWithNull()
        {
            UnitRider nullRider = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(nullRider);
            }, "Rider cannot be null.");
        }

        [Test]
        public void TestAddingAlreadyAddedRider()
        {
            this.raceEntry.AddRider(this.rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddRider(this.rider);
            }, string.Format("Rider {0} is already added.", rider.Name));
        }

        [Test]
        public void TestIfAddRiderRetursRightMessage()
        {
            string expectedOutput = string.Format("Rider {0} added in race.", "Ivan");

            string actualOutput = this.raceEntry.AddRider(this.rider);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestIfCalculateAverageHorsePowerWorksCorrectly()
        {
            double expectedOutput = 140;

            UnitRider secondRider= new UnitRider("Gosho", new UnitMotorcycle("Xpo1", 140, 160));
            UnitRider thirdRider= new UnitRider("Pesho", new UnitMotorcycle("Xpo2", 210, 150));

            this.raceEntry.AddRider(this.rider);
            this.raceEntry.AddRider(secondRider);
            this.raceEntry.AddRider(thirdRider);

            double output = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TestIfCalculateAverageHorsePowerThrowsException()
        {
            string expectedMessage = "The race cannot start with less than 2 participants.";

            this.raceEntry.AddRider(this.rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            }, expectedMessage);
        }
    }
}