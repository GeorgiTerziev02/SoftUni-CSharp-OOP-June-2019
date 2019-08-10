using NUnit.Framework;

namespace UnitTesting.Test
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateAxe()
        {
            this.axe = new Axe(10, 10);
        }

        [TearDown]
        public void DeleteAxe()
        {
            this.axe = null;
        }

        [SetUp]
        public void CreateDummy()
        {
            this.dummy = new Dummy(10, 10);
        }

        [TearDown]
        public void DeleteDummy()
        {
            this.dummy = null;
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            this.axe.Attack(this.dummy);
            int expectedResult = 5;

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(expectedResult), "Axe Durability doesn't change ater attack.");
        }

        [Test]
        public void TestingAttackWithBrokenAxe()
        {
            Assert.That(() => new Axe(10, -10).Attack(this.dummy), Throws.Exception.With.Message.EqualTo("Axe is broken."));
        }
    }
}
