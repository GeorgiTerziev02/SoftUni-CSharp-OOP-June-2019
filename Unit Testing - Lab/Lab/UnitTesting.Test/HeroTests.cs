using NUnit.Framework;
using Skeleton.Contracts;

namespace UnitTesting.Test
{
    [TestFixture]
    public class HeroTests
    {
        private IWeapon weapon;
        private ITarget target;

        [SetUp]
        public void CreateWeapon()
        {
            this.weapon = new Axe(10, 10);
        }

        [TearDown]
        public void ClearWeapon()
        {
            this.weapon = null;
        }

        [SetUp]
        public void CreateTarget()
        {
            this.target = new Dummy(10, 20);
        }

        [TearDown]
        public void ClearTarget()
        {
            this.target = null;
        }

        [Test]
        public void HeroGainingExperience()
        {

            Hero hero = new Hero("sasho", this.weapon);
            hero.Attack(this.target);

            int expectedCurrentExperience = 20;

            Assert.That(hero.Experience, Is.EqualTo(expectedCurrentExperience));
        }
    }
}
