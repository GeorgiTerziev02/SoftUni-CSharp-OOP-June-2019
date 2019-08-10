using Chainblock.Models;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTest
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        [Test]
        public void TestIfConsructorWorksCorrectly()
        {
            Transaction tr = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual(id, tr.Id);
            Assert.AreEqual(ts, tr.Status);
            Assert.AreEqual(from, tr.From);
            Assert.AreEqual(to, tr.To);
            Assert.AreEqual(amount, tr.Amount);
        }

        [Test]
        public void TestWithNegtiveId()
        {
            int negativeId = -5;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(negativeId, ts, from, to, amount);
            });
        }

        [Test]
        public void TestWithWhiteSpaceFrom()
        {
            string whiteSpaceFrom = "   ";

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, whiteSpaceFrom, to, amount);
            });
        }

        [Test]
        public void TestWithWhiteSpaceTo()
        {
            string whiteSpaceTo = "   ";

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, whiteSpaceTo, amount);
            });
        }

        [Test]
        public void TestWithZeroAmount()
        {
            double zeroAmount = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, to, zeroAmount);
            });
        }

        [Test]
        public void TestWithNegativeAmount()
        {
            double negativeAmount = -5;

            Assert.Throws<ArgumentException>(() =>
            {
                Transaction tr = new Transaction(id, ts, from, to, negativeAmount);
            });
        }

    }
}
