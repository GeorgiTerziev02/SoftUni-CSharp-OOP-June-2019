using NUnit.Framework;
using Service.Models.Contracts;
using Service.Models.Devices;
using Service.Models.Parts;
using System.Linq;

namespace Service.Tests
{
    public class DeviceTests
    {
        private Laptop laptop;

        [SetUp]
        public void Setup()
        {
            this.laptop = new Laptop("Acer");
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedMake = "Acer";

            Assert.IsNotNull(this.laptop.Parts);
            Assert.AreEqual(expectedMake, this.laptop.Make);
        }

        [Test]
        public void TestMakePropertyWithNull()
        {
            Assert.That(() => new PC(null), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void TestMakePropertyWithEmptyString()
        {
            Assert.That(() => new PC(""), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void TestIfLaptopAddPartWorksCorrectly()
        {
            IPart part = new LaptopPart("GPU", 150, false);

            this.laptop.AddPart(part);

            Assert.That(this.laptop.Parts, Has.Member(part));
        }

        [Test]
        public void TestIfPhoneAddPartWorksCorrectly()
        {
            IPart part = new PhonePart("GPU", 150, false);

            Phone phone = new Phone("Samsung");
            phone.AddPart(part);

            Assert.That(phone.Parts, Has.Member(part));
        }

        [Test]
        public void TestIfPCAddPartWorksCorrectly()
        {
            IPart part = new PCPart("GPU", 150, false);

            PC pc = new PC("Asus");
            pc.AddPart(part);

            Assert.That(pc.Parts, Has.Member(part));
        }

        [Test]
        public void TestAddPartWithAlreadyAddedPart()
        {
            IPart part = new LaptopPart("GPU", 150, false);
            this.laptop.AddPart(part);

            Assert.That(() => this.laptop.AddPart(part), Throws.InvalidOperationException.With.Message.EqualTo("This part already exists!"));
        }

        [Test]
        public void TestAddPartLaptopWithNonLaptopPart()
        {
            IPart part = new PCPart("GPU", 150, false);
            string expectedExceptionMessage = $"You cannot add {part.GetType().Name} to {this.laptop.GetType().Name}!";

            Assert.That(() => this.laptop.AddPart(part), Throws.InvalidOperationException.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void TestAddPartPhoneWithNonPhonePart()
        {
            IPart part = new PCPart("GPU", 150, false);
            Phone phone = new Phone("Samsung");

            string expectedExceptionMessage = $"You cannot add {part.GetType().Name} to {phone.GetType().Name}!";

            Assert.That(() => phone.AddPart(part), Throws.InvalidOperationException.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void TestAddPartPCeWithNonPCPart()
        {
            IPart part = new PhonePart("GPU", 150, false);
            PC pc = new PC("Asus");

            string expectedExceptionMessage = $"You cannot add {part.GetType().Name} to {pc.GetType().Name}!";

            Assert.That(() => pc.AddPart(part), Throws.InvalidOperationException.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void TestIfRemovePartWorksCorrectly()
        {
            int expectedCount = 1;
            IPart firstPart = new LaptopPart("GPU", 150, false);
            IPart secondPart = new LaptopPart("CCP", 150, false);
            this.laptop.AddPart(firstPart);
            this.laptop.AddPart(secondPart);
            this.laptop.RemovePart("GPU");

            Assert.That(this.laptop.Parts.Count == expectedCount);
        }

        [Test]
        public void TestRemovePartWithEmptyString()
        {
            Assert.That(() => this.laptop.RemovePart(""), Throws.ArgumentException.With.Message.EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void TestRemovePartWithNull()
        {
            Assert.That(() => this.laptop.RemovePart(null), Throws.ArgumentException.With.Message.EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void TestRemovePartWithInvalidPart()
        {
            Assert.That(() => this.laptop.RemovePart("ROM"), Throws.InvalidOperationException.With.Message.EqualTo("You cannot remove part which does not exist!"));
        }

        [Test]
        public void TestIfRepairPartWorksCorrectly()
        {
            bool expectedResult = false;

            string partName = "GPU";
            IPart part = new LaptopPart(partName, 150, true);
            this.laptop.AddPart(part);
            this.laptop.RepairPart(partName);

            Assert.AreEqual(expectedResult, this.laptop.Parts.First(p => p.Name == partName).IsBroken);
        }

        [Test]
        public void TestRepairPartWithEmptyString()
        {
            Assert.That(() => this.laptop.RepairPart(""), Throws.ArgumentException.With.Message.EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void TestRepairPartWithNull()
        {
            Assert.That(() => this.laptop.RepairPart(null), Throws.ArgumentException.With.Message.EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void TestRepairPartWithInvalidPart()
        {
            Assert.That(() => this.laptop.RepairPart("VOLUME"), Throws.InvalidOperationException.With.Message.EqualTo("You cannot repair part which does not exist!"));
        }

        [Test]
        public void TestRepairPartWithNotBrokenPart()
        {
            string partName = "GPU";
            IPart part = new LaptopPart(partName, 150, false);
            this.laptop.AddPart(part);

            Assert.That(() => this.laptop.RepairPart(partName), Throws.InvalidOperationException.With.Message.EqualTo("You cannot repair part which is not broken!"));
        }

        [TearDown]
        public void DestroyObject()
        {
            this.laptop = null;
        }
    }
}
