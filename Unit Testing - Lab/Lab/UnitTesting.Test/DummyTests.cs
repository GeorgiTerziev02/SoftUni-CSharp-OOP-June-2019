using NUnit.Framework;

namespace UnitTesting.Test
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void CreateDummy()
        {
            this.dummy = new Dummy(10, 10);
        }

        [TearDown]
        public void ClearAxe()
        {
            this.dummy = null;
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            this.dummy.TakeAttack(6);
            int expectedResult = 4;

            Assert.That(this.dummy.Health, Is.EqualTo(expectedResult), "Dummy's health doesn't change after it gets attacked.");
        }

        [Test]
        public void DummyThrowExceptionWhenAttacked()
        {
            Assert.That(() => new Dummy(-1, 5).TakeAttack(6), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            var newDummy = new Dummy(-5, 22);
            int expectedResult = 22;
            Assert.That(newDummy.GiveExperience(), Is.EqualTo(expectedResult), "Dead Dummy doesn't give expected experience.");
        }

        [Test]
        public void AliveDummyCanNotGiveExperience()
        {
            Assert.That(() => this.dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
