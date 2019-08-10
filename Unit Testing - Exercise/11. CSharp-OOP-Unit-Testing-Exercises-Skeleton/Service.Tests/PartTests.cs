using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        private PCPart pcPart;

        [SetUp]
        public void Setup()
        {
            this.pcPart = new PCPart("VideoCard", 500m, false);
        }

        [Test]
        public void TestIfPCPartConstructorWorksCorrectly()
        {
            string expectedName = "VideoCard";
            int expectedePrice = 600;
            bool expectedAnswerIfIsBroken = false;

            Assert.That(expectedName, Is.EqualTo(pcPart.Name));
            Assert.That(expectedePrice, Is.EqualTo(pcPart.Cost));
            Assert.That(expectedAnswerIfIsBroken, Is.EqualTo(pcPart.IsBroken));
        }

        [Test]
        public void TestIfLaptopPartConstructorWorksCorrectly()
        {
            string expectedName = "Keyboard";
            int expectedePrice = 300;
            bool expectedAnswerIfIsBroken = false;
            LaptopPart laptopPart = new LaptopPart("Keyboard", 200m, false);

            Assert.That(expectedName, Is.EqualTo(laptopPart.Name));
            Assert.That(expectedePrice, Is.EqualTo(laptopPart.Cost));
            Assert.That(expectedAnswerIfIsBroken, Is.EqualTo(laptopPart.IsBroken));
        }

        [Test]
        public void TestIfPhonePartConstructorWorksCorrectly()
        {
            string expectedName = "Screen";
            int expectedePrice = 130;
            bool expectedAnswerIfIsBroken = false;
            PhonePart phonePart = new PhonePart("Screen", 100m, false);

            Assert.That(expectedName, Is.EqualTo(phonePart.Name));
            Assert.That(expectedePrice, Is.EqualTo(phonePart.Cost));
            Assert.That(expectedAnswerIfIsBroken, Is.EqualTo(phonePart.IsBroken));
        }

        [Test]
        public void TestNameWithNull()
        {
            Assert.That(() => new PCPart(null, 150, false), Throws.ArgumentException.With.Message.EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void TestNameWithEmptyString()
        {
            Assert.That(() => new PCPart("", 150, false), Throws.ArgumentException.With.Message.EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void TestCostWithZero()
        {
            Assert.That(() => new PCPart("GPU", 0, false), Throws.ArgumentException.With.Message.EqualTo("Part cost cannot be zero or negative!"));
        }

        [Test]
        public void TestCostWithNegativeNumber()
        {
            Assert.That(() => new PCPart("GPU", -90, false), Throws.ArgumentException.With.Message.EqualTo("Part cost cannot be zero or negative!"));
        }

        [Test]
        public void TestIfRepairPartWorksCorrectly()
        {
            bool expectedResult = false;
            PCPart pcPart = new PCPart("VideoCard", 500m, true);

            pcPart.Repair();

            Assert.AreEqual(expectedResult, pcPart.IsBroken);
        }

        [Test]
        public void TestIfReportWorksCorrectly()
        {
            string expectedResult = $"VideoCard - 600.00$" + Environment.NewLine + $"Broken: False";

            string actualResult = this.pcPart.Report();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TearDown]
        public void DestroyObjects()
        {
            this.pcPart = null;
        }
    }
}