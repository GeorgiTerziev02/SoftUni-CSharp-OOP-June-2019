using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Ivan", 15, 100);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Ivan";
            int expectedDamage = 15;
            int expectedHP = 100;

            Assert.AreEqual(expectedName, this.warrior.Name);
            Assert.AreEqual(expectedDamage, this.warrior.Damage);
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        public void TestWithEmptyName()
        {
            Assert.That(() => new Warrior("", 15, 100), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void TestWithNullName()
        {
            Assert.That(() => new Warrior(null, 15, 100), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void TestWithWhiteSpaceName()
        {
            Assert.That(() => new Warrior("    ", 15, 100), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void TestDamageWithZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", 0, 10);
            }, "Damage value should be positive!");
        }

        [Test]
        public void TestDamageWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", -10, 10);
            }, "Damage value should be positive!");
        }

        [Test]
        public void TestHPWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", 10, -10);
            }, "HP should not be negative!");
        }

        [Test]
        public void TestIfAttackMethodWorksCorrectly()
        {
            Warrior defender = new Warrior("Pesho", 10, 100);

            int expectedWarriorHp = 90;
            int expectedDefenderHp = 85;

            this.warrior.Attack(defender);

            Assert.AreEqual(expectedWarriorHp, this.warrior.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void TestKillingEnemy()
        {
            Warrior attacker = new Warrior("Toni", 55, 100);
            Warrior defender = new Warrior("Pesho", 12, 35);

            int expectedDefenderHp = 0;
            int expectedAttackerHp = 88;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void TestAttackingWithLowHp()
        {
            Warrior attacker = new Warrior("Toni", 10, 25);
            Warrior defender = new Warrior("Pesho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void TestAttackingEnemyWithLowHp()
        {
            Warrior attacker = new Warrior("Toni", 10, 45);
            Warrior defender = new Warrior("Pesho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void TestAttackingStrongerEnemy()
        {
            Warrior attacker = new Warrior("Toni", 10, 35);
            Warrior defender = new Warrior("Pesho", 40, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "You are trying to attack too strong enemy");
        }
    }
}