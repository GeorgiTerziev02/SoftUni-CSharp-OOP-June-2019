namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void StartUp()
        {
            this.phone = new Phone("HUA", "5s");
        }

        [Test]
        public void TestIfConstructorWokrsCorrectly()
        {
            string make = "HUA";
            string model = "5s";

            Assert.AreEqual(make, this.phone.Make);
            Assert.AreEqual(model, this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);
        }

        [Test]
        public void TestMakeWithNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Phone(null, "5S");
            });
        }

        [Test]
        public void TestModelWithNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Phone("HUW", null);
            });
        }

        [Test]
        public void TestIfAddContactWorksCorrectly()
        {
            int expectedCount = 1;

            string name = "OP";
            string phone = "Ad";

            this.phone.AddContact(name, phone);

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestAddContactWithAlreadyExisting()
        {
            string name = "OP";
            string phone = "Ad";

            this.phone.AddContact(name, phone);

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact(name, "popo"));
        }

        [Test]
        public void TestIfCallWorksCorrectly()
        {
            string expectedResult = "Calling OP - Ad...";

            string name = "OP";
            string phone = "Ad";

            this.phone.AddContact(name, phone);

            var actual = this.phone.Call(name);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void TestCallingNonExistingName()
        {
            string name = "OP";

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call(name);
            });
        }
    }
}