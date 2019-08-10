using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIfEnrollMethodWorksCorrectly()
        {
            Warrior warrior = new Warrior("Gosho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Gosho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            int expectedCount = 1;
            Warrior warrior = new Warrior("Gosho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void TestIfFightWorksCorrectly()
        {
            int expectedAttackerHp = 95;
            int expectedDefenderHp = 40;

            Warrior attacker = new Warrior("Gosho", 10, 100);
            Warrior defender = new Warrior("Ivan", 5, 50);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void TestFightingMissingWorrior()
        {
            Warrior attacker = new Warrior("Gosho", 10, 100);
            Warrior defender = new Warrior("Ivan", 5, 50);

            this.arena.Enroll(attacker);
            //Missing enroll on defender

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, defender.Name);
            });
        }
    }
}
